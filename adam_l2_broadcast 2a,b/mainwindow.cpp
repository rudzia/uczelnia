#include "mainwindow.h"
#include "ui_mainwindow.h"
#include "qcustomplot.h"

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);

    udpSocket = new QUdpSocket(this);
    udpSocket->bind(1234);
    connect(udpSocket, SIGNAL(readyRead()), this, SLOT(ReadAndProcessData()));

    ramka_danych = NULL;
    zbior_ramek = NULL;
    pozwolenie_zapisu = true;
    stoper_start = true;
    koniec_wyswietlania = false;
    ilosc_ramek = 0.0;
    zapisujDoPliku = 0;
    sumaImped = 0;
    sumaTemp=0;

    ui->widget_imped->addGraph();
    ui->widget_ekg->addGraph();
    ui->widget_impedFormat->addGraph();
    ui->widget_imped->xAxis->setLabel("Ilosc ramek");
    ui->widget_imped->yAxis->setLabel("Impedancja");
    ui->widget_ekg->xAxis->setLabel("numer ramki");
    ui->widget_ekg->yAxis->setLabel("EKG");
    ui->widget_tem->xAxis->setLabel("numer ramki");
    ui->widget_tem->yAxis->setLabel("Temperatura");
    ui->widget_impedFormat->xAxis->setLabel("numer ramki");
    ui->widget_impedFormat->yAxis->setLabel("Impedancja Format.");
}

MainWindow::~MainWindow()
{
    delete ui;
}


double MainWindow::Srednia_sygnalu(QVector<double> vekt)
{
    double sum = 0;
    for(int i = 0; i < vekt.size(); i++)
    {
        sum += vekt[i];
    }
    double srednia_tem = sum/vekt.size();
    return srednia_tem;
}

/*double MainWindow::UsunStalaSkladowa(QVector<double> vektImped)
{
    double srednia_imped = Srednia_sygnalu(vektImped);
    vektImped[0] -= srednia_imped;
    return vektImped[0];
}
*/


//GLOWNY PROGRAM

void MainWindow::ReadAndProcessData()
{
//TU WPISUJEMY POLECENIE ODBIERANIA DANYCH
    if(stoper_start == true)
    {
        Stoper.start();
        stoper_start = false;
    }

    QByteArray Buffer;
    do{
        Buffer.resize(udpSocket->pendingDatagramSize());
        QHostAddress sender;
        quint16 senderPort;
        udpSocket->readDatagram(Buffer.data(), Buffer.size(), &sender, &senderPort);
    }
    while(udpSocket->hasPendingDatagrams());

//TU WPISUJEMY POLECENIA PRZETWARZANIA DANYCH

    if((Buffer.at(0) == '<') && ramka_danych.isNull())
    {
        ramka_danych.append(Buffer.data());
    }
    if((Buffer.at(0) == ',') && !(Buffer.contains('>')) && !ramka_danych.isNull() && !(ramka_danych.contains(',')))
    {
        ramka_danych.append(Buffer.data());
    }
    if(Buffer.contains('>') && (Buffer.at(0) == ',') && ramka_danych.contains('<') && ramka_danych.contains(',') && !ramka_danych.isNull())
    {
        if(koniec_wyswietlania==false)
        {
            ilosc_ramek++;
            zapisujDoPliku++;
            int mili_sekundy = Stoper.elapsed();

            ramka_danych.append(Buffer.data());
            ramka_danych.remove(0,1);
            ramka_danych.remove(ramka_danych.lastIndexOf('>'),1);
            zbior_ramek.append(ramka_danych + '\n');
            ui->textEdit->clear();
            ui->textEdit->append(ramka_danych);

//RYSOWANIE WYKRESU

            ui->widget_imped->replot();
            ui->widget_ekg->replot();
            ui->widget_tem->replot();
            ui->widget_impedFormat->replot();
//wykres EKG
            QString ramka = (ramka_danych);
            zmienna_xE.push_back(ilosc_ramek);
            vektor_ekg.push_back(ramka.mid(9,7).toDouble());
            ui->widget_ekg->graph(0)->setData(zmienna_xE,vektor_ekg);
            ui->widget_ekg->graph(0)->rescaleAxes();

            if (ilosc_ramek >= 50)
            {
               vektor_ekg.removeFirst();
               zmienna_xE.removeFirst();
            }

//tworzenie wektora uśrednionej temperatury z przesunieciem 50 ramek

            ui->widget_tem->addGraph();
            ui->widget_tem->graph(0)->setPen(QPen(Qt::blue)); // niebieski dla temperatury
            ui->widget_tem->addGraph();
            ui->widget_tem->graph(1)->setPen(QPen(Qt::red)); // czerwony dla usrednionej temperatury

            vekt_50_temp.push_back(ramka.mid(17,2).toDouble());
            sumaTemp += ramka.mid(17,2).toDouble();
           // vektor_temp.push_back(ramka.mid(17,2).toDouble());
            //zmienna_xT.push_back(ilosc_ramek);
            //vekt_usred_temp.push_back(Srednia_sygnalu(vekt_50_temp));

           /* if(ilosc_ramek == 50)
            {
                //vektor_temp.remove(0,25);
                //zmienna_xT.remove(0,25);
                vekt_usred_temp.remove(0,25);
            }
            */
            if(ilosc_ramek >= 50)
            {
                vekt_usred_temp.push_back(sumaTemp/50);
                sumaTemp -= vekt_50_temp[0];
               // vekt_usred_temp.push_back(Srednia_sygnalu(vekt_50_temp));
                zmienna_xT.push_back(ilosc_ramek-50.0);
                vektor_temp.push_back(vekt_50_temp[0]);
                //ui->widget_tem->graph(0)->setData(zmienna_xT, vektor_temp);
                ui->widget_tem->graph(1)->setData(zmienna_xT, vekt_usred_temp);
                //ui->widget_tem->graph(0)->rescaleAxes();
                ui->widget_tem->graph(1)->rescaleAxes(); //jak chce wyswitlic dwa na raz to dopisac (true)

                if(ilosc_ramek >= 100)
                {
                    vekt_50_temp.removeFirst();
                    zmienna_xT.removeFirst();
                    vektor_temp.removeFirst();
                    vekt_usred_temp.removeFirst();
                }
            }

 //tworzenie wektora impedancji bez stalej skladowej

            vekt_300_imped.push_back(ramka.mid(0,8).toDouble());
            sumaImped += ramka.mid(0,8).toDouble();


            if(ilosc_ramek >= 200)
            {
                vekt_impedFormat.push_back(vekt_300_imped[0] - sumaImped/200);
                zmienna_xI.push_back(ilosc_ramek-200.0);
                vektor_imped.push_back(vekt_300_imped[0]);
                //vekt_impedFormat.append(UsunStalaSkladowa(vekt_300_imped));
                ui->widget_impedFormat->graph(0)->setData(zmienna_xI,vekt_impedFormat); //dziala z opoxnieniem o 300
                ui->widget_impedFormat->graph(0)->rescaleAxes();

                ui->widget_imped->graph(0)->setData(zmienna_xI,vektor_imped);
                ui->widget_imped->graph(0)->rescaleAxes();
                sumaImped -= vekt_300_imped[0];
                vekt_300_imped.removeFirst();

                if(ilosc_ramek >= 250)
                {
                    zmienna_xI.removeFirst();
                    vekt_impedFormat.removeFirst();
                    vektor_imped.removeFirst();
                }
            }

            //ZAPIS PLIKU DO TXT
            if(zapisujDoPliku == 100)
            {
                QFile plik_txt("D:\\uczelnia\\adam_l2_broadcast 2a,b\\test.txt");
                plik_txt.open(QIODevice::ReadWrite | QIODevice::Append);
                if (!plik_txt.open(QIODevice::ReadWrite | QIODevice::Append))
                {
                       qDebug() << "Plik nie zostal otwarty";
                }
                QTextStream out(&plik_txt);
                out << (QString)zbior_ramek;

                zapisujDoPliku = 0;
                zbior_ramek.clear();

                if(mili_sekundy >= PIEC_MINUT && pozwolenie_zapisu == true)
                {
                   ui->textEdit->append("Zapisano dane do pliku txt.");
                   pozwolenie_zapisu = false;
                   koniec_wyswietlania = true;
                   plik_txt.close();
                }
            }
            ramka_danych = NULL;
        }
    }
}

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
    ilosc_ramek=0;
    poczatek_Osi_X = 0.0;
    bufor_temp20 = 0;

    ui->widget_imped->addGraph();
    ui->widget_ekg->addGraph();
    ui->widget_tem->addGraph();

    ui->widget_imped->xAxis->setLabel("Ilosc ramek");
    ui->widget_imped->yAxis->setLabel("Impedancja");
    ui->widget_ekg->xAxis->setLabel("Ilosc ramek");
    ui->widget_ekg->yAxis->setLabel("EKG");
    ui->widget_tem->xAxis->setLabel("Ilosc ramek");
    ui->widget_tem->yAxis->setLabel("Temperatura");
}

MainWindow::~MainWindow()
{
    delete ui;
}

QByteArray MainWindow::Ramka(QByteArray ramka_danych)
{
    ramka_danych.remove(0,1);
    ramka_danych.remove(ramka_danych.lastIndexOf('>'),1);
    return ramka_danych;
}

void MainWindow::ZapisDoPliku(QByteArray zbior_ramek)
{
    QFile plik_txt("C:\\Users\\Alicja\\Downloads\\ADAM\\test.txt");
    plik_txt.open(QIODevice::ReadWrite | QIODevice::Append);
    if (!plik_txt.open(QIODevice::ReadWrite | QIODevice::Append))
    {
           qDebug() << "Plik nie zostal otwarty";
    }
    QTextStream out(&plik_txt);
    out << (QString)zbior_ramek << "\n";

    plik_txt.close();
}

Qvector<double> MainWindow::Srednia_temp(QVector<double> vekt)
{
    double sum =0;
    for(int i =0; i < vekt.size(); i++)
    {
        sum += vekt[i];
    }
    double srednia_tem = sum/vekt.size();
    QVector vekt_sr_temp;
    return vekt_sr_temp = srednia_tem;

}
void MainWindow::ReadAndProcessData()
{
//TU WPISUJEMY POLECENIE ODBIERANIA DANYCH
    if(stoper_start == true)
    {
        Stoper.start();
        stoper_start = false;

       for (int j = 0; j < 300; j++)
        {
            zmienna_x.push_back((double)j);
        }

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

    //IMP
    if((Buffer.at(0) == '<') && ramka_danych.isNull())
    {
        ramka_danych.append(Buffer.data());
    }
    //EKG
    if((Buffer.at(0) == ',') && !(Buffer.contains('>')) && !ramka_danych.isNull() && !(ramka_danych.contains(',')))
    {
        ramka_danych.append(Buffer.data());
    }
    //TEMP
    if(Buffer.contains('>') && (Buffer.at(0) == ',') && ramka_danych.contains('<') && ramka_danych.contains(',') && !ramka_danych.isNull())
    {
        if(koniec_wyswietlania==false)
        {

            int mili_sekundy = Stoper.elapsed();
            ilosc_ramek++;

            ramka_danych.append(Buffer.data());
            zbior_ramek.append(Ramka(ramka_danych) + '\n');
            ui->textEdit->append(Ramka(ramka_danych));

//RYSOWANIE WYKRESU

            QString ramka = (Ramka(ramka_danych));
            vektor_imped.push_back(ramka.mid(0,8).toDouble());
            vektor_ekg.push_back(ramka.mid(9,7).toDouble());
            vektor_temp.push_back(ramka.mid(17,2).toDouble());

            ui->widget_imped->replot();
            ui->widget_ekg->replot();
            ui->widget_tem->replot();

            ui->widget_imped->graph(0)->setData(zmienna_x,vektor_imped);
            ui->widget_imped->graph(0)->rescaleValueAxis();
            ui->widget_imped->xAxis->setRange(poczatek_Osi_X,poczatek_Osi_X+300.0);

            ui->widget_ekg->graph(0)->setData(zmienna_x,vektor_ekg);
            ui->widget_ekg->graph(0)->rescaleValueAxis();
            ui->widget_ekg->xAxis->setRange(poczatek_Osi_X,poczatek_Osi_X+300.0);

            ui->widget_tem->graph(0)->setData(zmienna_x,vektor_temp);
            ui->widget_tem->graph(0)->rescaleValueAxis();
            ui->widget_tem->xAxis->setRange(poczatek_Osi_X,poczatek_Osi_X+300.0);
            ui->widget_tem->graph(1)->setPen(QPen(Qt::red));
            ui->widget_tem->graph(1)->setData(zmienna_x,Srednia_temp(vektor_temp));

            ramka_danych = NULL;

            if (ilosc_ramek >= MAX_RAMEK)
            {
               vektor_imped.removeFirst();
               vektor_ekg.removeFirst();
               vektor_temp.removeFirst();
               zmienna_x.removeFirst();
               zmienna_x.push_back(ilosc_ramek);
               poczatek_Osi_X++;
            }

            if(ilosc_ramek >= 20)//bufor ramek
//ZAPIS PLIKU DO TXT
            if(mili_sekundy >= PIEC_MINUT && pozwolenie_zapisu == true)
            {
               ZapisDoPliku(zbior_ramek);
               ui->textEdit->append("Zapisano dane do pliku txt.");
               pozwolenie_zapisu = false;
               koniec_wyswietlania = true;
            }
        }
    }
}

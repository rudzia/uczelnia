#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QUdpSocket>
#include <QByteArray>
#include <QFile>
#include <QTime>
#include <QVector>

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT
public:
    QUdpSocket *udpSocket;
    int index;
public slots:
    void ReadAndProcessData();
public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();

    double Srednia_sygnalu(QVector<double> vekt);
    double UsunStalaSkladowa(QVector<double> vektImped);


private:
    Ui::MainWindow *ui;
    QByteArray ramka_danych;
    QByteArray zbior_ramek;
    bool pozwolenie_zapisu;
    bool stoper_start;
    bool koniec_wyswietlania;
    QTime Stoper;
    double ilosc_ramek;
    int zapisujDoPliku;
    double sumaImped;
    double sumaTemp;

    QVector<double> vektor_imped,vektor_ekg,vektor_temp, zmienna_xE, zmienna_xT, zmienna_xI,
    vekt_50_temp, vekt_200_imped, vekt_usred_temp, vekt_impedFormat;

    const int PIEC_MINUT = 360000;
    const int MAX_RAMEK = 100;

};

#endif // MAINWINDOW_H

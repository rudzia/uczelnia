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

    QByteArray Ramka(QByteArray ramka_danych);
    void ZapisDoPliku(QByteArray zbior_ramek);
    double Srednia_temp(QVector<double> vekt);


private:
    Ui::MainWindow *ui;
    QByteArray ramka_danych;
    QByteArray zbior_ramek;
    bool pozwolenie_zapisu;
    bool stoper_start;
    bool koniec_wyswietlania;
    QTime Stoper;
    int ilosc_ramek;

    QVector<double> vektor_imped,vektor_ekg,vektor_temp, zmienna_x,
    vekt_srednia_TEMP, vekt_20_temp, vekt_usred_temp,zmienna_x2;

    const int PIEC_MINUT = 360000;
    const int MAX_RAMEK = 310;
    double poczatek_Osi_X;
    int bufor_temp20;

};

#endif // MAINWINDOW_H

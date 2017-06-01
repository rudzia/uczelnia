package com.example.alicja.dziennikdiety;

import android.app.Dialog;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

public class kalkBMIActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_kalk_bmi);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
    }

    public void oblicz(View view) {
        TextView wynik = (TextView) findViewById(R.id.tv_wynik);
        TextView opis = (TextView) findViewById(R.id.tv_opis);
        TextView praw = (TextView) findViewById(R.id.tv_prawidlowe);
        String s_waga = ((EditText)findViewById(R.id.et_waga)).getText().toString();
        String s_wzrost = ((EditText)findViewById(R.id.et_wzrost)).getText().toString();
        String ocena, prawidlowe;

        if (s_waga.length() == 0 || s_wzrost.length() == 0) {
            Toast.makeText( this, "Wpisz dane", Toast.LENGTH_SHORT).show();
            return;
        }

        float waga, wzrost;
        waga = Float.valueOf(s_waga);
        wzrost = Float.valueOf(s_wzrost);
        wzrost /= 100;

        float bmi = waga/(wzrost*wzrost)*100;
        bmi = (float) (((int) bmi)/100.0);
        float min = (float) ((int)(185*wzrost*wzrost) / 10.0);
        float max = (float) ((int)(250*wzrost*wzrost) / 10.0);
        wynik.setText(""+bmi);
        if (bmi < 16) {
            ocena = "Wygłodzenie";
        } else if ( bmi < 17){
            ocena = "Wychudzenie";
        } else if ( bmi < 18.5){
            ocena = "Niedowaga";
        } else if ( bmi < 25){
            ocena = "Idealnie";
        } else if ( bmi < 30){
            ocena = "Nadwaga";
        } else if ( bmi < 35){
            ocena = "I stopień otyłości";
        } else if ( bmi < 40){
            ocena = "II stopień otyłości";
        } else {
            ocena = "III stopień otyłości!";
        }
        prawidlowe = "Prawidłowy zakres wagi:\n" + min + " - " + max + " kg";
        opis.setText(ocena);
        praw.setText(prawidlowe);
    }

}

package com.example.alicja.dziennikdiety;

import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.View;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.TextView;
import android.widget.Toast;


public class LimitActivity extends AppCompatActivity {

    private EditText wiekTextEdit;
    private EditText wagaTextEdit;
    private EditText wzrostTextEdit;
    private EditText PPMTextEdit;
    private TextView WynikPPM;
    private TextView WynikCPM;
    private Integer wiek;
    private Integer wzrost;
    private Integer waga;
    private Integer K_czy_M;
    private Integer aktywnosc;
    private double PPM;
    private double CPM1;
    private double CPM2;

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_limit);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        wiekTextEdit = (EditText)findViewById(R.id.editTextWiek);
        wagaTextEdit = (EditText)findViewById(R.id.editTextWaga);
        wzrostTextEdit = (EditText)findViewById(R.id.editTextWzrost);
        //WynikPPM = (TextView)findViewById(R.id.textViewWynikPPM);
        WynikCPM = (TextView)findViewById(R.id.textViewWynikCPP);

        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
    }

    public void onRadioButtonClickPlec(View view)
    {
        switch(view.getId())
        {
            case R.id.radioButtonKobieta: K_czy_M = 1;
                break;
            case R.id.radioButtonMezyczna: K_czy_M = 2;
                break;
        }
    }
    public void onRadioButtonClickSport(View view)
    {
        switch(view.getId())
        {
            case R.id.radioButtonMala: aktywnosc = 0;
                break;
            case R.id.radioButtonUmiar: aktywnosc = 1;
                break;
            case R.id.radioButtonWysoka: aktywnosc = 2;
                break;
        }
    }

    public void ObliczBMI(View view)
    {
        wiek = Integer.parseInt(wiekTextEdit.getText().toString());
        wzrost = Integer.parseInt(wzrostTextEdit.getText().toString());
        waga = Integer.parseInt(wagaTextEdit.getText().toString());

        if(K_czy_M == 1)
        {
            PPM = 665.09 + (9.56*waga)+(1.85*wzrost)-(4.67*wiek);
        }
        else if(K_czy_M == 2)
        {
            PPM = 66.47 + (13.75*waga)+(5*wzrost)-(6.75*wiek);
        }

        //int wynikPPM = ((int) (PPM+0.5));
       // String tekstPPM = String.valueOf(wynikPPM) + " kcal";
        //WynikPPM.setText(tekstPPM);

        if(aktywnosc == 0)
        {
            CPM1 = PPM*1.4;
            CPM2 = PPM*1.5;
        }
        else if(aktywnosc == 1)
        {
            CPM1 = PPM*1.7;
            CPM2 = PPM*1.9;
        }
        else if(aktywnosc == 2)
        {
            CPM1 = PPM*2.2;
            CPM2 = PPM*2.4;
        }
        int wynikCPM1 = ((int) (CPM1 + 0.5));
        int wynikCPM2 = ((int) (CPM2 + 0.5));
        String tekstCPM = String.valueOf(wynikCPM1) + "-" + String.valueOf(wynikCPM2) + " kcal";
        WynikCPM.setText(tekstCPM);
    }
}

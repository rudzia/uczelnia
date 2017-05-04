package com.example.alicja.dziennikdiety;

import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.View;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.Toast;


public class LimitActivity extends AppCompatActivity {

    private EditText wiekTextEdit;
    private EditText wagaTextEdit;
    private EditText wzrostTextEdit;
    private EditText wynikTextEdit;
    private Integer wiek;
    private Integer wzrost;
    private Integer waga;
    private Integer K_czy_M;
    private double PPM;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_limit);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);
        wiekTextEdit = (EditText)findViewById(R.id.editTextWiek);
        wagaTextEdit = (EditText)findViewById(R.id.editTextWaga);
        wzrostTextEdit = (EditText)findViewById(R.id.editTextWzrost);
        wynikTextEdit = (EditText)findViewById(R.id.editTextWynik);

        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
    }

    public void onRadioButtonClick(View view)
    {
        //rzutujemy widok kontrolki, której stan został zmieniony na RadioButton,
        // sprawdzamy czy jest wybrana i zapisujemy jej stan do zmiennej zaznaczona

        boolean zaznaczony =((RadioButton)view).isChecked();

        //sprawdzamy zmiana której kontrolki wywołała funkcję, poprzez sprawdzenie id widoku tej kontrolki
        switch(view.getId())
        {
            case R.id.radioButtonKobieta: //gdy chodzi o pierwszy RadioButton
//to mi zbedne, tutaj kod do obliczania
                //wyswietlamy, którką informację Toast kontrolce, której stan został zmieniony
                Toast.makeText(LimitActivity.this, "Stan RadioButton'a 1 został zmieniony na" + String.valueOf(zaznaczony),
                        Toast.LENGTH_SHORT).show();
                K_czy_M = 1;

                break;
            case R.id.radioButtonMezyczna: //gdy chodzi o drugi RadioButton

                Toast.makeText(LimitActivity.this, "Stan RadioButton'a 1 został zmieniony na" + String.valueOf(zaznaczony),
                        Toast.LENGTH_SHORT).show();
                K_czy_M = 2;
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
        else
        {
            PPM = 66.47 + (13.75*waga)+(5*wzrost)-(6.75*wiek);
        }

        String tekst = String.valueOf(PPM);
        wynikTextEdit.setText(tekst);

    }
}

package com.example.alicja.dziennikdiety;

import android.content.Intent;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.View;
import android.widget.RadioButton;
import android.widget.Toast;

public class DietaAlergie extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_dieta_alergie);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
    }
    boolean CzyBezlaktozowa;
    boolean CzyBezglutenowa;
    boolean CzybrakAlergii;
    int licznik_kilkniec_laktoza = 0;
    int licznik_kilkniec_gluten = 0;
    int licznik_kilkniec_brak = 0;


    public void onRadioButtonClickAlergia(View view)
    {
        switch(view.getId())
        {
            case R.id.radioButtonLaktoza: CzyBezlaktozowa = true;
                licznik_kilkniec_laktoza++;
                if(licznik_kilkniec_laktoza%2 !=0) {
                    ((RadioButton) view).setChecked(true);
                }
                else {
                    ((RadioButton) view).setChecked(false);
                    CzyBezlaktozowa = false;
                }
                break;

            case R.id.radioButtonGluten: CzyBezglutenowa = true;
                licznik_kilkniec_gluten++;
                if(licznik_kilkniec_gluten%2 !=0) {
                    ((RadioButton) view).setChecked(true);
                }
                else {
                    ((RadioButton) view).setChecked(false);
                    CzyBezglutenowa = false;
                }
                break;

            case R.id.radioButtonBrakAlergii: CzybrakAlergii = true;
                licznik_kilkniec_brak++;
                if(licznik_kilkniec_brak%2 !=0) {
                    ((RadioButton) view).setChecked(true);
                }
                else {
                    ((RadioButton) view).setChecked(false);
                    CzybrakAlergii = false;
                }
                break;
        }
    }
    public void click_ZapisAlergie(View view) {
        switch (view.getId()) {
            case R.id.button_zapiszAlergie:
                if (CzyBezglutenowa == true && CzyBezlaktozowa==true && CzybrakAlergii==false)
                {
                    Toast.makeText(getApplicationContext(), "Zapisano ustawienia", Toast.LENGTH_SHORT).show();
                }
                else if (CzybrakAlergii==false && CzyBezglutenowa == true && CzyBezlaktozowa== false)
                {
                    Toast.makeText(getApplicationContext(), "Zapisano ustawienia", Toast.LENGTH_SHORT).show();
                }
                else if (CzybrakAlergii==false && CzyBezglutenowa == false && CzyBezlaktozowa== true)
                {
                    Toast.makeText(getApplicationContext(), "Zapisano ustawienia", Toast.LENGTH_SHORT).show();
                }
                else if(CzybrakAlergii == true && CzyBezglutenowa == false && CzyBezlaktozowa==false)
                {
                    Toast.makeText(getApplicationContext(), "Zapisano ustawienia", Toast.LENGTH_SHORT).show();
                }
                else
                {
                    Toast.makeText(getApplicationContext(), "Wprowadź poprawne ustawienia", Toast.LENGTH_SHORT).show();
                }
        }
    }
}

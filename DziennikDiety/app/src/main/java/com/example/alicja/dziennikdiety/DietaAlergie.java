package com.example.alicja.dziennikdiety;

import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.View;

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
    public void onRadioButtonClickAlergia(View view)
    {
        switch(view.getId())
        {
            case R.id.radioButtonLaktoza: CzyBezlaktozowa = true;
                break;
            case R.id.radioButtonGluten: CzyBezglutenowa = true;
                break;
            case R.id.radioButtonBrakAlergii: CzybrakAlergii = true;
                break;
        }
    }

}

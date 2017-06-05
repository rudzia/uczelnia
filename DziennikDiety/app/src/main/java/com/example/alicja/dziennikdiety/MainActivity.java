package com.example.alicja.dziennikdiety;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.os.Bundle;



public class MainActivity extends AppCompatActivity {
    public static TextView Powitanie;
    public static String zalogowany;
    public static String LogOut = "Zaloguj";


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        Powitanie = (TextView)findViewById(R.id.textViewPowitanie);
        Powitanie.setText(zalogowany);

        Button mButton = (Button)findViewById(R.id.button_logInOut);
        mButton.setText(LogOut);
    }

    public void click(View view) {
        Intent intent;
        switch(view.getId())
        {
            case R.id.button_kalk_BMI:
                intent = new Intent(MainActivity.this, kalkBMIActivity.class);
                startActivity(intent);
                break;
            case R.id.button_limit:
                intent = new Intent(MainActivity.this, LimitActivity.class);
                startActivity(intent);
                break;
            case R.id.button_bazaProd:
                intent = new Intent(MainActivity.this, BazaProduktowActivity.class);
                startActivity(intent);
                break;
            case R.id.button_dzien_diety:
                intent = new Intent(MainActivity.this, Kalendarz.class);
                startActivity(intent);
                break;
            case R.id.button_logInOut:
                if(LogOut == "Wyloguj")
                {
                    LogOut = "Zaloguj";
                    zalogowany = null;
                }
                intent = new Intent(MainActivity.this, logowanie.class);
                startActivity(intent);
                break;
            case R.id.button_DietaAlergie:
                intent = new Intent(MainActivity.this, DietaAlergie.class);
                startActivity(intent);
                break;
            case R.id.button_rejestr:
                intent = new Intent(MainActivity.this, Rejestr.class);
                startActivity(intent);
                break;
        }
    }
}

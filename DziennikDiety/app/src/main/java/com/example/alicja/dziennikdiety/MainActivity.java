package com.example.alicja.dziennikdiety;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.view.menu.ListMenuItemView;
import android.view.View;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    public void click(View view) {
        Intent intent;
        switch(view.getId())
        {
            case R.id.button_kalk_kalorii:
                break;
            case R.id.button_kalk_BMI:
                intent = new Intent(MainActivity.this, kalkBMIActivity.class);
                startActivity(intent);
                break;
            case R.id.button_limit:
                intent = new Intent(MainActivity.this, LimitActivity.class);
                startActivity(intent);
                break;
            case R.id.button_bazaProd:
                break;
            case R.id.button_dzien_diety:
                intent = new Intent(MainActivity.this, Kalendarz.class);
                startActivity(intent);
                break;
            case R.id.button_logInOut:
                intent = new Intent(MainActivity.this, logowanie.class);
                startActivity(intent);
                break;
            case R.id.button_DietaAlergie:
                intent = new Intent(MainActivity.this, DietaAlergie.class);
                startActivity(intent);
                break;
        }
    }
}

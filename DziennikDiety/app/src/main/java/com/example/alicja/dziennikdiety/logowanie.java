package com.example.alicja.dziennikdiety;

import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.View;
import android.widget.EditText;
import android.widget.Toast;

public class logowanie extends AppCompatActivity {
    private EditText editTextLogin, editTextHaslo;
    private String login, haslo;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_logowanie);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
    }

    public void click_ZapisDane(View view) {

        editTextLogin = (EditText)findViewById(R.id.editTextLogin);
        editTextHaslo = (EditText)findViewById(R.id.editTextHaslo);
        login = editTextLogin.getText().toString();
        haslo = editTextHaslo.getText().toString();

        switch (view.getId()) {
            case R.id.button_LogRejestr:
                if(login.isEmpty() && haslo.isEmpty())
                {
                    Toast.makeText(getApplicationContext(), "Wprowadź dane", Toast.LENGTH_SHORT).show();
                }
                else if((login.isEmpty() ||haslo.isEmpty()))
                {
                    Toast.makeText(getApplicationContext(), "Wprowadź wszystkie dane", Toast.LENGTH_SHORT).show();
                }
                else
                {
                    Toast.makeText(getApplicationContext(), "Zarejestrowano", Toast.LENGTH_SHORT).show();
                }
                break;
        }
    }
}

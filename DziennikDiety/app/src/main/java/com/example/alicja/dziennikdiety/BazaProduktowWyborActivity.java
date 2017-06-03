package com.example.alicja.dziennikdiety;

import android.content.Intent;
import android.os.Bundle;
import android.os.Parcel;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentTransaction;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.text.Editable;
import android.text.TextWatcher;
import android.widget.EditText;

import com.example.alicja.dziennikdiety.modele.ProduktContent;

public class BazaProduktowWyborActivity extends AppCompatActivity implements ProduktWyborFragment.OnListFragmentInteractionListener {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_baza_produktow);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        final FragmentManager fm = getSupportFragmentManager();
        FragmentTransaction ft = fm.beginTransaction();
        ft.add(R.id.lista_produktow, new ProduktWyborFragment());
        ft.commit();
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);

        EditText szukaj = (EditText) findViewById(R.id.tv_szukaj);
        szukaj.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {

            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {
                ((ProduktWyborFragment)fm.findFragmentById(R.id.lista_produktow)).przewin(s.toString());
            }

            @Override
            public void afterTextChanged(Editable s) {

            }
        });
    }

    @Override
    public void onBackPressed() {
        this.finish();
    }

    @Override
    public boolean onSupportNavigateUp() {
        this.finish();
        return true;
    }

    @Override
    public void onListFragmentInteraction(ProduktContent.Produkt item) {

    }
}

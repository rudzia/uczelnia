package com.example.alicja.dziennikdiety;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.widget.ExpandableListView;
import android.widget.TextView;

import com.example.alicja.dziennikdiety.modele.Artykul;
import com.example.alicja.dziennikdiety.modele.ProduktContent;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.Locale;

public class DzienneMenu extends AppCompatActivity {
    DzienneMenuAdapter adapter;
    ExpandableListView lista;
    ArrayList<String> nazwyPosilkow = new ArrayList<>();

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        if (resultCode == RESULT_OK) {
            ProduktContent.Produkt prod = data.getParcelableExtra("produkt");
            adapter.dodaj(new Artykul(nazwyPosilkow.get(requestCode), prod));
            lista.expandGroup(requestCode);
            przelicz();
        }
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_dzienne_menu);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);

        Intent intent = this.getIntent();
        int dzien, miesiac, rok;
        dzien = intent.getIntExtra("dzien", 0);
        miesiac = intent.getIntExtra("miesiac", 0);
        rok = intent.getIntExtra("rok", 0);

        Calendar data = new GregorianCalendar(rok, miesiac, dzien);
        SimpleDateFormat sdf = new SimpleDateFormat("EEEE,\n d MMMM y");
        toolbar.setTitle(sdf.format(data.getTime()));

        setSupportActionBar(toolbar);
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        getSupportActionBar().setTitle(sdf.format(data.getTime()));

        ArrayList<ArrayList<Artykul>> listaArt = new ArrayList<ArrayList<Artykul>>();

        nazwyPosilkow.add("Śniadanie");
        nazwyPosilkow.add("II śniadanie");
        nazwyPosilkow.add("Obiad");
        nazwyPosilkow.add("Podwieczorek");
        nazwyPosilkow.add("Kolacja");
        for (int i=0; i<5; ++i) {
            listaArt.add(new ArrayList<Artykul>());
        }

        adapter = new DzienneMenuAdapter(this, nazwyPosilkow, listaArt);

        lista = (ExpandableListView) findViewById(R.id.elv_dzienne_menu_lista);

        lista.setAdapter(adapter);
        przelicz();
    }

    void przelicz() {
        TextView tv = (TextView) findViewById(R.id.tv_podsumowanie_dnia);
        float kcal = 0, weglowodany = 0, bialko = 0, tluszcz = 0;
        for (int i=0; i<5; i++) {
            int ile = adapter.getChildrenCount(i);
            for (int j=0; j<ile; j++) {
                Artykul art = adapter.getChild(i,j);
                kcal += Float.valueOf(art.getInfo().kcal);
                weglowodany += Float.valueOf(art.getInfo().weglowodany);
                bialko += Float.valueOf(art.getInfo().bialko);
                tluszcz += Float.valueOf(art.getInfo().tluszcz);
            }
        }

        tv.setText(String.format("kcal: %.1f, węglowodany: %.1fg, białko %.1fg, tłuszcz %.1fg", kcal, weglowodany, bialko, tluszcz));
    }

}

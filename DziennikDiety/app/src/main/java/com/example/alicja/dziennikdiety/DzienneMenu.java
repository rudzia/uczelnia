package com.example.alicja.dziennikdiety;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.ExpandableListView;
import android.widget.TextView;

import com.example.alicja.dziennikdiety.modele.Artykul;
import com.example.alicja.dziennikdiety.modele.ProduktContent;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.GregorianCalendar;

public class DzienneMenu extends AppCompatActivity {
    DzienneMenuAdapter adapter;
    ExpandableListView lista;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_dzienne_menu);

        Intent intent = this.getIntent();
        TextView tv = (TextView) findViewById(R.id.tv_dzien);
        int dzien, miesiac, rok;
        dzien = intent.getIntExtra("dzien", 0);
        miesiac = intent.getIntExtra("miesiac", 0);
        rok = intent.getIntExtra("rok", 0);

        Calendar data = new GregorianCalendar(rok, miesiac, dzien);
        SimpleDateFormat sdf = new SimpleDateFormat("EEEE,\n d MMMM y");
        tv.setText(sdf.format(data.getTime()));

        ArrayList<String> nazwyPosilkow = new ArrayList<>();
        ArrayList<ArrayList<Artykul>> listaArt = new ArrayList<ArrayList<Artykul>>();

        // TODO: przenieść do values/strings.xml
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

        adapter.dodaj(new Artykul("Śniadanie", new ProduktContent.Produkt(1, "Bułka", "500", "400", "300", "200", false, false)));
        adapter.dodaj(new Artykul("Śniadanie", new ProduktContent.Produkt(1, "Mleko", "500", "400", "300", "200", false, false)));
        adapter.dodaj(new Artykul("Śniadanie", new ProduktContent.Produkt(1, "coś", "500", "400", "300", "200", false, false)));
        adapter.dodaj(new Artykul("Śniadanie", new ProduktContent.Produkt(1, "Kawa", "500", "400", "300", "200", false, false)));
        adapter.dodaj(new Artykul("Obiad", new ProduktContent.Produkt(1, "Bułka", "500", "400", "300", "200", false, false)));
        adapter.dodaj(new Artykul("Obiad", new ProduktContent.Produkt(1, "Bułka", "500", "400", "300", "200", false, false)));
        adapter.dodaj(new Artykul("Obiad", new ProduktContent.Produkt(1, "Bułka", "500", "400", "300", "200", false, false)));

        lista.setAdapter(adapter);
    }

}

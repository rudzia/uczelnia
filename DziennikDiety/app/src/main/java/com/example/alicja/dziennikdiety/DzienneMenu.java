package com.example.alicja.dziennikdiety;

import android.content.ContentValues;
import android.content.Intent;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteException;
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

public class DzienneMenu extends AppCompatActivity {
    DzienneMenuAdapter adapter;
    DziennaBaza bazaHelper;
    ExpandableListView lista;
    ArrayList<String> nazwyPosilkow = new ArrayList<>();
    private String tabela;

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        if (resultCode == RESULT_OK) {
            ProduktContent.Produkt prod = data.getParcelableExtra("produkt");
            float porcja = data.getFloatExtra("porcja", 100);

            adapter.dodaj(new Artykul(nazwyPosilkow.get(requestCode), prod, porcja));

            SQLiteDatabase sqlDb = bazaHelper.getWritableDatabase();
            ContentValues cv = new ContentValues();
            cv.put("NAME", prod.nazwa);
            cv.put("MGROUP", nazwyPosilkow.get(requestCode));
            cv.put("KCAL", prod.kcal);
            cv.put("WEGLOWODANY", prod.weglowodany);
            cv.put("BIALKO", prod.bialko);
            cv.put("TLUSZCZ", prod.tluszcz);
            cv.put("GLUTEN", (prod.gluten ? 1 : 0));
            cv.put("LAKTOZA", (prod.laktoza ? 1 : 0));
            cv.put("PORCJA", porcja);
            sqlDb.insert(tabela, null, cv);

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
        SimpleDateFormat sdf = new SimpleDateFormat("EEEE");
        toolbar.setTitle(sdf.format(data.getTime()));

        setSupportActionBar(toolbar);
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
        getSupportActionBar().setTitle(sdf.format(data.getTime()));
        sdf = new SimpleDateFormat("d MMMM y");
        getSupportActionBar().setSubtitle(sdf.format(data.getTime()));
        sdf = new SimpleDateFormat("'d'yyyy_MM_dd");
        tabela = sdf.format(data.getTime());

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

        bazaHelper = new DziennaBaza(this, "dziennabaza", null, 1, tabela);
        SQLiteDatabase sqlDb = bazaHelper.getReadableDatabase();
        try {
            Cursor cur = sqlDb.rawQuery("SELECT * from " + tabela, null);
            while (cur.moveToNext()) {
                int id = cur.getInt(0);
                String nazwa = cur.getString(1);
                String posilek = cur.getString(2);
                String kcal = String.valueOf(cur.getFloat(3));
                String weglowodany = String.valueOf(cur.getFloat(4));
                String bialko = String.valueOf(cur.getFloat(5));
                String tluszcz = String.valueOf(cur.getFloat(6));
                Boolean gluten = (cur.getInt(7) == 1);
                Boolean laktoza = (cur.getInt(8) == 1);
                float porcja = cur.getFloat(9);
                adapter.dodaj(new Artykul(posilek, new ProduktContent.Produkt(id, nazwa, kcal, weglowodany, bialko, tluszcz, gluten, laktoza), porcja));
            }
            cur.close();
        }
        catch (SQLiteException ex) {
            bazaHelper.onCreate(sqlDb);
        }



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

    void usunZBazy(Artykul art) {
        SQLiteDatabase sqlDb = bazaHelper.getReadableDatabase();

        sqlDb.delete(tabela, "NAME=? and MGROUP=? and PORCJA=?",
                    new String[]{art.getName(), art.getGroup(), String.valueOf(art.getPortion())});

    }

}

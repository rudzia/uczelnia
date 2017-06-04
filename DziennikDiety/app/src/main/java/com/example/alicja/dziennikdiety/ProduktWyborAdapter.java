package com.example.alicja.dziennikdiety;

import android.content.Context;
import android.content.Intent;
import android.database.DataSetObserver;
import android.graphics.Color;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.ListAdapter;
import android.widget.TextView;

import com.example.alicja.dziennikdiety.modele.ProduktContent;

import java.util.List;

import static android.app.Activity.RESULT_OK;


public class ProduktWyborAdapter implements ListAdapter {
    private final LayoutInflater inflater;
    private final Context context;
    private List<ProduktContent.Produkt> lista;

    public ProduktWyborAdapter(Context context, List<ProduktContent.Produkt> lista) {
        this.context = context;
        this.inflater = LayoutInflater.from(context);
        this.lista = lista;
    }

    @Override
    public boolean areAllItemsEnabled() {
        return true;
    }

    @Override
    public boolean isEnabled(int position) {
        return true;
    }

    @Override
    public void registerDataSetObserver(DataSetObserver observer) {

    }

    @Override
    public void unregisterDataSetObserver(DataSetObserver observer) {

    }

    @Override
    public int getCount() {
        return lista.size();
    }

    @Override
    public ProduktContent.Produkt getItem(int position) {
        return lista.get(position);
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    @Override
    public boolean hasStableIds() {
        return true;
    }

    @Override
    public View getView(final int position, View convertView, ViewGroup parent) {
        final ProduktContent.Produkt produkt = getItem(position);

        if (convertView == null) {
            convertView = inflater.inflate(R.layout.caly_produkt, null);
        }

        TextView tv_nazwa = (TextView) convertView.findViewById(R.id.tv_nazwa_produktu);
        TextView kcalView = (TextView) convertView.findViewById(R.id.tv_kcal);
        TextView weglowodanyView = (TextView) convertView.findViewById(R.id.tv_weglowodany);
        TextView bialkoView = (TextView) convertView.findViewById(R.id.tv_bialko);
        TextView tluszczView = (TextView) convertView.findViewById(R.id.tv_tluszcz);
        TextView glutenView = (TextView) convertView.findViewById(R.id.tv_gluten);
        TextView laktozaView = (TextView) convertView.findViewById(R.id.tv_laktoza);

        ImageView iv_plus = (ImageView) convertView.findViewById(R.id.iv_wybierz_produkt);

        tv_nazwa.setText(produkt.nazwa);
        kcalView.setText(produkt.kcal);
        weglowodanyView.setText(produkt.weglowodany);
        bialkoView.setText(produkt.bialko);
        tluszczView.setText(produkt.tluszcz);
        if (produkt.gluten) {
            glutenView.setTextColor(Color.RED);
            glutenView.setAlpha((float)1);
        } else {
            glutenView.setTextColor(Color.GRAY);
            glutenView.setAlpha((float)0.3);
        }
        if (produkt.laktoza) {
            laktozaView.setTextColor(Color.RED);
            laktozaView.setAlpha((float)1);
        } else {
            laktozaView.setTextColor(Color.GRAY);
            laktozaView.setAlpha((float)0.3);
        }

        iv_plus.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                BazaProduktowWyborActivity bpwa = (BazaProduktowWyborActivity) context;
                bpwa.intent = new Intent();
                bpwa.intent.putExtra("produkt", getItem(position));
                bpwa.wyborPorcji();
            }
        });

        return convertView;
    }

    @Override
    public int getItemViewType(int position) {
        return 1;
    }

    @Override
    public int getViewTypeCount() {
        return 1;
    }

    @Override
    public boolean isEmpty() {
        return false;
    }

    public int znajdz(String co) {
        for (int i=0; i<lista.size(); i++) {
            if(lista.get(i).nazwa.toLowerCase().startsWith(co.toLowerCase())) {
                return i;
            }
        }

        return -1;
    }
}

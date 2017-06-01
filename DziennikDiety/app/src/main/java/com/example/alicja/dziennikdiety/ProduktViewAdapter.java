package com.example.alicja.dziennikdiety;

import android.content.Context;
import android.graphics.Color;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseExpandableListAdapter;
import android.widget.TextView;

import com.example.alicja.dziennikdiety.modele.ProduktContent;

import java.util.ArrayList;
import java.util.List;

public class ProduktViewAdapter extends BaseExpandableListAdapter {
    private final LayoutInflater inflater;
    private final Context context;

    private List<ProduktContent.Produkt> groups;

    public ProduktViewAdapter(Context context, List<ProduktContent.Produkt> groups) {
        this.inflater = LayoutInflater.from(context);
        this.context = context;
        this.groups = groups;
    }

    /*
    public void dodaj(Artykul artykul) {
        if (!groups.contains(artykul.getGroup())) {
            //groups.add(artykul.getGroup());
            Log.e("DzienneMenuAdapter", "Próbuje dodać: "+artykul.getGroup());
            return;
        }
        int index = groups.indexOf(artykul.getGroup());
        children.get(index).add(artykul);
        this.notifyDataSetChanged();
    }

    public void usun(int grPos, int chPos) {
        children.get(grPos).remove(chPos);
        this.notifyDataSetChanged();
    }
    */

    @Override
    public int getGroupCount() {
        return groups.size();
    }

    @Override
    public int getChildrenCount(int groupPosition) {
        return 1;
    }

    @Override
    public Object getGroup(int groupPosition) {
        return groups.get(groupPosition);
    }

    @Override
    public Object getChild(int groupPosition, int childPosition) {
        return groups.get(groupPosition).getChildItemList().get(childPosition);
    }

    @Override
    public long getGroupId(int groupPosition) {
        return groupPosition;
    }

    @Override
    public long getChildId(int groupPosition, int childPosition) {
        return childPosition;
    }

    @Override
    public boolean hasStableIds() {
        return true;
    }

    @Override
    public View getGroupView(final int groupPosition, boolean isExpanded, View convertView, ViewGroup parent) {
        final String group = ((ProduktContent.Produkt) getGroup(groupPosition)).nazwa;
        if (convertView == null) {
            convertView = inflater.inflate(R.layout.fragment_produkt, null);
        }

        TextView tv_nazwa = (TextView) convertView.findViewById(R.id.tv_nazwa_produktu);

        tv_nazwa.setText(group);
        return convertView;
    }

    @Override
    public View getChildView(final int groupPosition, final int childPosition, boolean isLastChild, View convertView, ViewGroup parent) {
        final ProduktContent.ProduktInfo posilek = (ProduktContent.ProduktInfo) getChild(groupPosition, childPosition);
        if (convertView == null) {
            convertView = inflater.inflate(R.layout.fragment_produkt_info, null);
        }

        TextView kcalView = (TextView) convertView.findViewById(R.id.tv_kcal);
        TextView weglowodanyView = (TextView) convertView.findViewById(R.id.tv_weglowodany);
        TextView bialkoView = (TextView) convertView.findViewById(R.id.tv_bialko);
        TextView tluszczView = (TextView) convertView.findViewById(R.id.tv_tluszcz);
        TextView glutenView = (TextView) convertView.findViewById(R.id.tv_gluten);
        TextView laktozaView = (TextView) convertView.findViewById(R.id.tv_laktoza);

        kcalView.setText(posilek.kcal);
        weglowodanyView.setText(posilek.weglowodany);
        bialkoView.setText(posilek.bialko);
        tluszczView.setText(posilek.tluszcz);
        if (posilek.gluten) {
            glutenView.setTextColor(Color.RED);
            glutenView.setAlpha((float)1);
        } else {
            glutenView.setTextColor(Color.GRAY);
            glutenView.setAlpha((float)0.3);
        }
        if (posilek.laktoza) {
            laktozaView.setTextColor(Color.RED);
            laktozaView.setAlpha((float)1);
        } else {
            laktozaView.setTextColor(Color.GRAY);
            laktozaView.setAlpha((float)0.3);
        }

        return convertView;
    }

    @Override
    public boolean areAllItemsEnabled() {
        return true;
    }

    @Override
    public boolean isChildSelectable(int groupPosition, int childPosition) {
        return true;
    }

}


package com.example.alicja.dziennikdiety;

import android.content.Context;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseExpandableListAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import com.example.alicja.dziennikdiety.modele.Artykul;
import com.example.alicja.dziennikdiety.modele.ProduktContent;

import java.util.ArrayList;

public class DzienneMenuAdapter extends BaseExpandableListAdapter {
    private final LayoutInflater inflater;
    private final Context context;
    private ArrayList<String> groups;
    private ArrayList<ArrayList<Artykul>> children;

    public DzienneMenuAdapter(Context context, ArrayList<String> groups,
                              ArrayList<ArrayList<Artykul>> children) {

        inflater = LayoutInflater.from(context);
        this.context = context;
        this.groups = groups;
        this.children = children;
    }

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

    @Override
    public int getGroupCount() {
        return groups.size();
    }

    @Override
    public int getChildrenCount(int groupPosition) {
        return children.get(groupPosition).size();
    }

    @Override
    public Object getGroup(int groupPosition) {
        return groups.get(groupPosition);
    }

    @Override
    public Object getChild(int groupPosition, int childPosition) {
        return children.get(groupPosition).get(childPosition);
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
        final String group = (String) getGroup(groupPosition);
        if (convertView == null) {
            convertView = inflater.inflate(R.layout.fragment_posilek, null);
        }

        TextView tv = (TextView) convertView.findViewById(R.id.tv_nazwa_posilku);
        ImageView iv = (ImageView) convertView.findViewById(R.id.iv_dodawanie);

        iv.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                // TODO: okienko wyboru produktu
                dodaj(new Artykul(group, new ProduktContent.Produkt(2, "Dodany", "123", "234", "345", "456", false, true)));
                ((DzienneMenu) context).lista.expandGroup(groupPosition);
            }
        });

        tv.setText(group);
        return convertView;
    }

    @Override
    public View getChildView(final int groupPosition, final int childPosition, boolean isLastChild, View convertView, ViewGroup parent) {
        final Artykul posilek = (Artykul) getChild(groupPosition, childPosition);
        if (convertView == null) {
            convertView = inflater.inflate(R.layout.fragment_posilek_lista, null);
        }
        TextView tv = (TextView) convertView.findViewById(R.id.tv_artykul_posilku);
        ImageView iv = (ImageView) convertView.findViewById(R.id.iv_usun);

        iv.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                // TODO: okienko z potwierdzeniem?
                usun(groupPosition, childPosition);
            }
        });

        tv.setText(posilek.getName()+"\n"+posilek.getInfo().kcal);

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
package com.example.alicja.dziennikdiety;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseExpandableListAdapter;
import android.widget.TextView;

import com.example.alicja.dziennikdiety.modele.Artykul;
import com.example.alicja.dziennikdiety.modele.ProduktContent;

import java.util.ArrayList;

public class DzienneMenuAdapter extends BaseExpandableListAdapter {
    private final LayoutInflater inflater;
    private Context context;
    private ArrayList<String> groups;
    private ArrayList<ArrayList<Artykul>> children;

    public DzienneMenuAdapter(Context context, ArrayList<String> groups,
                              ArrayList<ArrayList<Artykul>> children) {

        inflater = LayoutInflater.from(context);
        this.context = context;
        this.groups = groups;
        this.children = children;
    }

    public void dodaj(String posilek, Artykul artykul) {
        if (!groups.contains(posilek)) {
            groups.add(posilek);
        }
        int index = groups.indexOf(posilek);
        if (children.size() < index + 1) {
            children.add(new ArrayList<Artykul>());
        }
        children.get(index).add(artykul);
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
    public View getGroupView(int groupPosition, boolean isExpanded, View convertView, ViewGroup parent) {
        String group = (String) getGroup(groupPosition);
        if (convertView == null) {
            convertView = inflater.inflate(R.layout.fragment_posilek, null);
        }
        TextView tv = (TextView) convertView.findViewById(R.id.tv_nazwa_posilku);
        tv.setText(group);
        return convertView;
    }

    @Override
    public View getChildView(int groupPosition, int childPosition, boolean isLastChild, View convertView, ViewGroup parent) {
        Artykul posilek = (Artykul) getChild(groupPosition, childPosition);
        if (convertView == null) {
            convertView = inflater.inflate(R.layout.fragment_posilek_lista, null);
        }
        TextView tv = (TextView) convertView.findViewById(R.id.tv_artykul_posilku);

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

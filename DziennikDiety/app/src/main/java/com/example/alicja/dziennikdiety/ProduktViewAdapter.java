package com.example.alicja.dziennikdiety;

import android.content.Context;
import android.graphics.Color;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import com.bignerdranch.expandablerecyclerview.Adapter.ExpandableRecyclerAdapter;
import com.bignerdranch.expandablerecyclerview.Model.ParentListItem;
import com.bignerdranch.expandablerecyclerview.ViewHolder.ChildViewHolder;
import com.bignerdranch.expandablerecyclerview.ViewHolder.ParentViewHolder;
import com.example.alicja.dziennikdiety.ProduktFragment.OnListFragmentInteractionListener;
import com.example.alicja.dziennikdiety.modele.ProduktContent;
import com.example.alicja.dziennikdiety.modele.ProduktContent.Produkt;

import java.util.ArrayList;
import java.util.List;

/**
 * {@link RecyclerView.Adapter} that can display a {@link ProduktContent.Produkt} and makes a call to the
 * specified {@link OnListFragmentInteractionListener}.
 * TODO: Replace the implementation with code for your data type.
 */
public class ProduktViewAdapter
        //extends ExpandableListView {
        extends ExpandableRecyclerAdapter<ProduktViewAdapter.ProduktViewHolder, ProduktViewAdapter.ProduktInfoViewHolder> {

    private List<Produkt> mValues;
    private final LayoutInflater inflater;
    private int num_expanded = 0;

    public ProduktViewAdapter(Context ctx, List<Produkt> items) {
        super(items);

        mValues = new ArrayList<>(items);
        inflater = LayoutInflater.from(ctx);
    }

    @Override
    public ProduktViewHolder onCreateParentViewHolder(ViewGroup viewGroup) {
        View view = inflater.inflate(R.layout.fragment_produkt, viewGroup, false);
        return new ProduktViewHolder(view);
    }

    @Override
    public ProduktInfoViewHolder onCreateChildViewHolder(ViewGroup viewGroup) {
        View view = inflater.inflate(R.layout.fragment_produkt_info, viewGroup, false);
        return new ProduktInfoViewHolder(view);
    }

    @Override
    public void onBindParentViewHolder(ProduktViewHolder produktViewHolder, int i, ParentListItem parentListItem) {
        Produkt parent = (Produkt) parentListItem;
        produktViewHolder.mNazwaView.setText(parent.nazwa);
        //produktViewHolder.mIdView.setText(parent.id.toString());
    }

    @Override
    public void onBindChildViewHolder(ProduktInfoViewHolder produktInfoViewHolder, int i, Object o) {
        ProduktContent.ProduktInfo child = (ProduktContent.ProduktInfo) o;
        produktInfoViewHolder.kcalView.setText(child.kcal);
        produktInfoViewHolder.weglowodanyView.setText(child.weglowodany);
        produktInfoViewHolder.bialkoView.setText(child.bialko);
        produktInfoViewHolder.tluszczView.setText(child.tluszcz);
        if (child.gluten) {
            produktInfoViewHolder.glutenView.setTextColor(Color.RED);
            produktInfoViewHolder.glutenView.setAlpha((float)1);
        } else {
            produktInfoViewHolder.glutenView.setTextColor(Color.GRAY);
            produktInfoViewHolder.glutenView.setAlpha((float)0.3);
        }
        if (child.laktoza) {
            produktInfoViewHolder.laktozaView.setTextColor(Color.RED);
            produktInfoViewHolder.laktozaView.setAlpha((float)1);
        } else {
            produktInfoViewHolder.laktozaView.setTextColor(Color.GRAY);
            produktInfoViewHolder.laktozaView.setAlpha((float)0.3);
        }
    }

    @Override
    public void onParentListItemExpanded(int position) {
        super.onParentListItemExpanded(position);
        num_expanded++;
    }

    @Override
    public void onParentListItemCollapsed(int position) {
        super.onParentListItemCollapsed(position);
        num_expanded--;
    }

    @Override
    public int getItemCount() {
        return mValues.size()+num_expanded;
    }

    public void setData(List<Produkt> data) {
        mValues.clear();
        mValues.addAll(data);
        //mValues = data;
        notifyDataSetChanged();
    }


    public class ProduktViewHolder extends ParentViewHolder {
        public final View mView;
        //public final TextView mIdView;
        public final TextView mNazwaView;
        public Produkt mItem;

        public ProduktViewHolder(View view) {
            super(view);
            mView = view;
           // mIdView = (TextView) view.findViewById(R.id.tv_id);
            mNazwaView = (TextView) view.findViewById(R.id.tv_nazwa_produktu);
        }

        @Override
        public String toString() {
            return super.toString() + " '" + mNazwaView.getText() + "'";
        }
    }

    public class ProduktInfoViewHolder extends ChildViewHolder {
        public final View mView;

        public final TextView kcalView;
        public final TextView weglowodanyView;
        public final TextView bialkoView;
        public final TextView tluszczView;

        public final TextView glutenView;
        public final TextView laktozaView;

        public ProduktInfoViewHolder(View view) {
            super(view);

            mView = view;

            kcalView = (TextView) mView.findViewById(R.id.tv_kcal);
            weglowodanyView = (TextView) mView.findViewById(R.id.tv_weglowodany);
            bialkoView = (TextView) mView.findViewById(R.id.tv_bialko);
            tluszczView = (TextView) mView.findViewById(R.id.tv_tluszcz);

            glutenView = (TextView) mView.findViewById(R.id.tv_gluten);
            laktozaView = (TextView) mView.findViewById(R.id.tv_laktoza);
        }
    }
}

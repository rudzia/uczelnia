package com.example.alicja.dziennikdiety;

import android.content.Context;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.support.v4.app.LoaderManager;
import android.support.v4.content.Loader;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ExpandableListView;
import android.widget.Toast;

import com.example.alicja.dziennikdiety.modele.ProduktContent;

import java.util.ArrayList;
import java.util.List;

/**
 * A fragment representing a list of Items.
 * <p/>
 * Activities containing this fragment MUST implement the {@link OnListFragmentInteractionListener}
 * interface.
 */
public class ProduktFragment extends Fragment implements LoaderManager.LoaderCallbacks<List<ProduktContent.Produkt>> {

    private OnListFragmentInteractionListener mListener;
    private ProduktViewAdapter mAdapter;
    private Baza loader;

    /**
     * Mandatory empty constructor for the fragment manager to instantiate the
     * fragment (e.g. upon screen orientation changes).
     */
    public ProduktFragment() {
    }

    // TODO: Customize parameter initialization
    @SuppressWarnings("unused")
    public static ProduktFragment newInstance(int columnCount) {
        ProduktFragment fragment = new ProduktFragment();
        Bundle args = new Bundle();
        fragment.setArguments(args);
        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        mAdapter = new ProduktViewAdapter(getContext(), new ArrayList<ProduktContent.Produkt>());
    }

    @Override
    public void onActivityCreated(@Nullable Bundle savedInstanceState) {
        super.onActivityCreated(savedInstanceState);

        loader = (Baza) getLoaderManager().initLoader(0, null, this);
        loader.forceLoad();
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_produkt_list, container, false);

        ((ExpandableListView) view).setAdapter(mAdapter);
        ((ExpandableListView) view).setGroupIndicator(null);
        return view;
    }


    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
        if (context instanceof OnListFragmentInteractionListener) {
            mListener = (OnListFragmentInteractionListener) context;
        } else {
            throw new RuntimeException(context.toString()
                    + " must implement OnListFragmentInteractionListener");
        }
    }

    @Override
    public void onDetach() {
        super.onDetach();
        mListener = null;
    }

    @Override
    public Loader<List<ProduktContent.Produkt>> onCreateLoader(int id, Bundle args) {
        return new Baza(getActivity());
    }

    @Override
    public void onLoadFinished(Loader<List<ProduktContent.Produkt>> loader, List<ProduktContent.Produkt> data) {
        if (data == null) {
            Toast.makeText(getContext(), "Brak połączenia z bazą danych", Toast.LENGTH_LONG).show();
            return;
        }

        mAdapter = new ProduktViewAdapter(getContext(), data);
        mAdapter.notifyDataSetChanged();
        ((ExpandableListView) getView()).setAdapter(mAdapter);
    }

    @Override
    public void onLoaderReset(Loader<List<ProduktContent.Produkt>> loader) {

    }




    /**
     * This interface must be implemented by activities that contain this
     * fragment to allow an interaction in this fragment to be communicated
     * to the activity and potentially other fragments contained in that
     * activity.
     * <p/>
     * See the Android Training lesson <a href=
     * "http://developer.android.com/training/basics/fragments/communicating.html"
     * >Communicating with Other Fragments</a> for more information.
     */
    public interface OnListFragmentInteractionListener {
        // TODO: Update argument type and name
        void onListFragmentInteraction(ProduktContent.Produkt item);
    }
}

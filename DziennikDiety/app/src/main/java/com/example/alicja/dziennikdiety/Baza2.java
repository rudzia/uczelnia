package com.example.alicja.dziennikdiety;

import android.content.Context;
import android.support.v4.content.AsyncTaskLoader;
import android.util.Log;

import com.example.alicja.dziennikdiety.dummy.DummyContent;

import java.nio.charset.Charset;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

public class Baza2 extends AsyncTaskLoader<List<DummyContent.DummyItem>>{
    private Connection conn;

    public Baza2(Context context) {
        super(context);
        try {
            // The newInstance() call is a work around for some
            // broken Java implementations

            Class.forName("com.mysql.jdbc.Driver").newInstance();
        } catch (Exception ex) {
            // handle the error
            Log.e("mySQL", "Driver nie znaleziony: "+ex.toString());
        }
    }

    @Override
    public List<DummyContent.DummyItem> loadInBackground() {
        List<DummyContent.DummyItem> list = null;
        polacz();
        if (conn != null) {
            list = pobierz_dane();
            rozlacz();
        }
        return list;
    }

    @Override
    protected void onStopLoading() {
        cancelLoad();
    }

    private void polacz() {
        try {
            conn = DriverManager.getConnection("jdbc:mysql://188.68.237.63?" +
                    "user=produkty&password=produkty123");

        } catch (SQLException ex) {
            // handle any errors
            Log.e("mySQL", "SQLException: " + ex.getMessage());
            Log.e("mySQL", "SQLState: " + ex.getSQLState());
            Log.e("mySQL", "VendorError: " + ex.getErrorCode());
        }
    }

    private void rozlacz() {
        try {
            conn.close();
        } catch (Exception ignored) {}
        conn = null;
    }

    private List<DummyContent.DummyItem> pobierz_dane() {
        Statement stmt = null;
        ResultSet rs = null;
        ArrayList<DummyContent.DummyItem> list = new ArrayList<>();
        try {
            stmt = conn.createStatement();
            rs = stmt.executeQuery("SELECT produkty.jedzenie.* FROM produkty.jedzenie");
            rs.beforeFirst();

            while(rs.next()) {
                // polskie znaki
                String nazwa = new String(rs.getString(2).getBytes(Charset.forName("cp1252")));
                //Log.d(this.getClass().getSimpleName(), "Mam: "+nazwa);
                list.add(new DummyContent.DummyItem(rs.getInt(1), nazwa, rs.getString(3), rs.getString(4), rs.getString(5), rs.getString(6), rs.getBoolean(7), rs.getBoolean(8)));
            }
        } catch (SQLException ex) {
            Log.e("mySQL", "SQLException: " + ex.getMessage());
            Log.e("mySQL", "SQLState: " + ex.getSQLState());
            Log.e("mySQL", "VendorError: " + ex.getErrorCode());
        } catch (NullPointerException ignored) {}
        finally {
            if (rs != null) {
                try {
                    rs.close();
                } catch (SQLException ignored) {}
            }

            if (stmt != null) {
                try {
                    stmt.close();
                } catch (SQLException ignored) {}
            }
        }

        return list;
    }
}

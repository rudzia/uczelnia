package com.example.alicja.dziennikdiety;

import android.app.Activity;
import android.app.Fragment;
import android.content.Context;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.widget.TextView;
import android.widget.Toast;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

enum TYP {
    POLACZ,
    POBIERZ_BAZE
}

class Baza extends AsyncTask<TYP, Void, Void> {


    private static Connection conn = null;
    private Context ctx;
    private Integer status= 0;

    @Override
    protected void onPostExecute(Void aVoid) {
        super.onPostExecute(aVoid);

        if (conn == null) {
            Toast.makeText(ctx,
                    "Błąd połączenia z bazą, niektóre funkcje nie będą działać prawidłowo",
                    Toast.LENGTH_LONG).show();
        } else {
            Toast.makeText(ctx, "Połączono z bazą", Toast.LENGTH_SHORT).show();
        }
        rozlacz();
    }

    Baza(Context ctx) {
        this.ctx = ctx;
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
    protected Void doInBackground(TYP... params) {
        switch (params[0]) {
            case POLACZ:
                polacz();
                break;
            case POBIERZ_BAZE:
                polacz();
                pobierz_dane();
        }

        return null;
    }

    private Void polacz() {
        try {
            conn = DriverManager.getConnection("jdbc:mysql://188.68.237.63?" +
                    "user=produkty&password=produkty123");

        } catch (SQLException ex) {
            // handle any errors
            Log.e("mySQL", "SQLException: " + ex.getMessage());
            Log.e("mySQL", "SQLState: " + ex.getSQLState());
            Log.e("mySQL", "VendorError: " + ex.getErrorCode());
        }

        return null;
    }

    private Void rozlacz() {
        try {
            conn.close();
        } catch (Exception ignored) {}
        conn = null;
        return null;
    }
    private Void pobierz_dane() {
        Statement stmt = null;
        ResultSet rs = null;
        try {
            stmt = conn.createStatement();
            stmt.setFetchSize(5);
            rs = stmt.executeQuery("SELECT produkty.jedzenie.nazwa FROM produkty.jedzenie");
            rs.first();
            //((BazaProduktowActivity) ctx).tekst = rs.getString("nazwa");
            //((BazaProduktowActivity) ctx).wyswietl();
            Log.d("nazwa", rs.getString(1));
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

        return null;
    }
}

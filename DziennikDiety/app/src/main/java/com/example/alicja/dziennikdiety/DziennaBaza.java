package com.example.alicja.dziennikdiety;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.util.Log;

public class DziennaBaza extends SQLiteOpenHelper {
    static String SQL_BAZA;

    public DziennaBaza(Context context, String name, SQLiteDatabase.CursorFactory factory, int version, String dzien) {
        super(context, name, factory, version);
        Log.e("dzienne", "konstruktor: "+dzien);
        SQL_BAZA = "CREATE TABLE " +
                dzien+" (" +
                " _ID INTEGER PRIMARY KEY, " +
                " NAME TEXT," +
                " MGROUP TEXT, " +
                " KCAL REAL, " +
                " WEGLOWODANY REAL, " +
                " BIALKO REAL, " +
                " TLUSZCZ REAL, " +
                " GLUTEN INTEGER, " +
                " LAKTOZA INTEGER, " +
                " PORCJA REAL )";

    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        db.execSQL(SQL_BAZA);
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        db.execSQL("DROP TABLE *");
        db.execSQL(SQL_BAZA);
    }
}

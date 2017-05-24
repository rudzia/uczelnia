package com.example.alicja.dziennikdiety;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.TextView;
import android.widget.Toast;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.GregorianCalendar;

public class DzienneMenu extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_dzienne_menu);

        Intent intent = this.getIntent();
        TextView tv = (TextView) findViewById(R.id.tv_dzien);
        int dzien, miesiac, rok;
        dzien = intent.getIntExtra("dzien", 0);
        miesiac = intent.getIntExtra("miesiac", 0);
        rok = intent.getIntExtra("rok", 0);

        Calendar data = new GregorianCalendar(rok, miesiac, dzien);
        SimpleDateFormat sdf = new SimpleDateFormat("EEEE,\n d MMMM y");
        tv.setText(sdf.format(data.getTime()));
    }

}

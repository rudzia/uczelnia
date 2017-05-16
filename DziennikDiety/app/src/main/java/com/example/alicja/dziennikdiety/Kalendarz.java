package com.example.alicja.dziennikdiety;

import android.content.Intent;
import android.support.annotation.NonNull;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.CalendarView;

public class Kalendarz extends AppCompatActivity {

    CalendarView cv;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_kalendarz);

        cv = (CalendarView)findViewById(R.id.calendarView);
        cv.setOnDateChangeListener(new CalendarView.OnDateChangeListener() {
            @Override
            public void onSelectedDayChange(@NonNull CalendarView view, int year, int month, int dayOfMonth) {
                Intent intent = new Intent(Kalendarz.this, DzienneMenu.class);
                intent.putExtra("rok", year);
                intent.putExtra("miesiac", month);
                intent.putExtra("dzien", dayOfMonth);
                startActivity(intent);
            }
        });
    }
}

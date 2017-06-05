package com.example.alicja.dziennikdiety;

import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;
import android.app.ProgressDialog;
import android.content.Intent;
import android.net.Uri;
import android.os.AsyncTask;
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;


public class logowanie extends AppCompatActivity {
    // private EditText editTextLogin, editTextHaslo;
    // private String login, haslo;

    //@Override
   /* protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_logowanie);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        getSupportActionBar().setDisplayHomeAsUpEnabled(true);
    }

    /*public void click_ZapisDane(View view) {

        editTextLogin = (EditText)findViewById(R.id.editTextLogin);
        editTextHaslo = (EditText)findViewById(R.id.editTextHaslo);
        login = editTextLogin.getText().toString();
        haslo = editTextHaslo.getText().toString();

        switch (view.getId()) {
            case R.id.button_LogRejestr:
                if(login.isEmpty() && haslo.isEmpty())
                {
                    Toast.makeText(getApplicationContext(), "Wprowadź dane", Toast.LENGTH_SHORT).show();
                }
                else if((login.isEmpty() ||haslo.isEmpty()))
                {
                    Toast.makeText(getApplicationContext(), "Wprowadź wszystkie dane", Toast.LENGTH_SHORT).show();
                }
                else
                {
                    Toast.makeText(getApplicationContext(), "Zarejestrowano", Toast.LENGTH_SHORT).show();
                }
                break;
        }
    }*/
    public static final int CONNECTION_TIMEOUT = 10000;
    public static final int READ_TIMEOUT = 15000;
    private EditText editLogin;
    private EditText editPassword;

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_logowanie);

        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        getSupportActionBar().setDisplayHomeAsUpEnabled(true);

        editLogin = (EditText) findViewById(R.id.editTextLogin);
        editPassword = (EditText) findViewById(R.id.editTextHaslo);
    }

    public void checkLogin(View arg0)
    {
        MainActivity.LogOut = "Zaloguj";
        final String login = editLogin.getText().toString();
        final String password = editPassword.getText().toString();
        new AsyncLogin().execute(login, password);
    }

    private class AsyncLogin extends AsyncTask<String, String, String>
    {
        ProgressDialog pdLoading = new ProgressDialog(logowanie.this);
        HttpURLConnection conn;
        URL url = null;

        @Override
        protected void onPreExecute()
        {
            super.onPreExecute();

            pdLoading.setMessage("\tLoading...");
            pdLoading.setCancelable(false);
            pdLoading.show();
        }

        @Override
        protected String doInBackground(String... params)
        {
            try
            {
                url = new URL("http://147.135.197.248/logowanie/login.inc.php");
            }
            catch (MalformedURLException e)
            {
                e.printStackTrace();
                return "exception";
            }
            try
            {
                conn = (HttpURLConnection) url.openConnection();
                conn.setReadTimeout(READ_TIMEOUT);
                conn.setConnectTimeout(CONNECTION_TIMEOUT);
                conn.setRequestMethod("POST");
                conn.setDoInput(true);
                conn.setDoOutput(true);

                Uri.Builder builder = new Uri.Builder()
                        .appendQueryParameter("login", params[0])
                        .appendQueryParameter("password", params[1]);
                String query = builder.build().getEncodedQuery();

                OutputStream os = conn.getOutputStream();
                BufferedWriter writer = new BufferedWriter(new OutputStreamWriter(os, "UTF-8"));
                writer.write(query);
                writer.flush();
                writer.close();
                os.close();
                conn.connect();
            }
            catch (IOException e1)
            {
                e1.printStackTrace();
                return "exception";
            }

            try
            {
                int response_code = conn.getResponseCode();
                if (response_code == HttpURLConnection.HTTP_OK)
                {
                    InputStream input = conn.getInputStream();
                    BufferedReader reader = new BufferedReader(new InputStreamReader(input));
                    StringBuilder result = new StringBuilder();
                    String line;

                    while ((line = reader.readLine()) != null)
                    {
                        result.append(line);
                    }
                    return (result.toString());
                }
                else
                {
                    return ("unsuccessful");
                }
            }
            catch (IOException e)
            {
                e.printStackTrace();
                return "exception";
            }
            finally
            {
                conn.disconnect();
            }
        }
        @Override
        protected void onPostExecute(String result)
        {
            pdLoading.dismiss();

            if (result.equalsIgnoreCase("true"))
            {
                MainActivity.zalogowany = "Zalogowany jako " + editLogin.getText().toString();
                MainActivity.LogOut= "Wyloguj";
                Intent intent = new Intent(logowanie.this, Udane_logowanie.class);
                startActivity(intent);
                logowanie.this.finish();
            }
            else if (result.equalsIgnoreCase("false"))
            {
                Toast.makeText(logowanie.this, "Nieprawidłowy login lub hasło", Toast.LENGTH_LONG).show();
            }
            else if (result.equalsIgnoreCase("exception") || result.equalsIgnoreCase("unsuccessful"))
            {
                Toast.makeText(logowanie.this, "Problem połączenia z bazą.", Toast.LENGTH_LONG).show();
            }
        }
    }
}

package com.example.alicja.dziennikdiety;

import android.app.Activity;
import android.app.Dialog;
import android.content.Context;
import android.content.DialogInterface;
import android.os.Bundle;
import android.support.annotation.IdRes;
import android.support.annotation.NonNull;
import android.support.v4.app.DialogFragment;
import android.support.v7.app.AlertDialog;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.EditText;
import android.widget.RadioGroup;


public class PorcjaDialog extends DialogFragment {
    // Use this instance of the interface to deliver action events
    NoticeDialogListener mListener;
    float porcja;

    public interface NoticeDialogListener {
        public void onDialogPositiveClick(PorcjaDialog dialog);
        public void onDialogNegativeClick(PorcjaDialog dialog);
    }

    @NonNull
    @Override
    public Dialog onCreateDialog(Bundle savedInstanceState) {
        AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());

        LayoutInflater inflater = getActivity().getLayoutInflater();
        final View dialogView = inflater.inflate(R.layout.dialog_porcja, null);
        final EditText et = (EditText) dialogView.findViewById(R.id.et_porcja);
        final RadioGroup rg = (RadioGroup) dialogView.findViewById(R.id.rg_porcja);

        builder.setView(dialogView)
                .setPositiveButton("Zatwierdź", new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int id) {

                        switch (rg.getCheckedRadioButtonId()) {
                            case R.id.rb0:
                                porcja = 50;
                                break;
                            case R.id.rb1:
                                porcja = 200;
                                break;
                            case R.id.rb_wlasna_porcja:
                                porcja = Float.valueOf(et.getText().toString());
                                break;
                            default:
                                porcja = 100;

                        }

                        mListener.onDialogPositiveClick(PorcjaDialog.this);
                    }
                })
                .setNegativeButton("Anuluj", new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int id) {
                        // Send the negative button event back to the host activity
                        mListener.onDialogNegativeClick(PorcjaDialog.this);
                    }
                });

        final AlertDialog ad = builder.create();


        rg.setOnCheckedChangeListener(new RadioGroup.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(RadioGroup group, @IdRes int checkedId) {
                if (checkedId == R.id.rb_wlasna_porcja) {
                    et.setEnabled(true);
                    if (et.getText().length() <= 0) {
                        ad.getButton(AlertDialog.BUTTON_POSITIVE).setEnabled(false);
                    }
                }
                else {
                    et.setEnabled(false);
                    ad.getButton(AlertDialog.BUTTON_POSITIVE).setEnabled(true);
                }
            }
        });

        et.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {
                if (after <= 0) {
                    ad.getButton(AlertDialog.BUTTON_POSITIVE).setEnabled(false);
                }
                else {
                    ad.getButton(AlertDialog.BUTTON_POSITIVE).setEnabled(true);
                }
            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {

            }

            @Override
            public void afterTextChanged(Editable s) {

            }
        });

        ad.setOnShowListener(new DialogInterface.OnShowListener() {
            @Override
            public void onShow(DialogInterface dialog) {
                ((AlertDialog)dialog).getButton(AlertDialog.BUTTON_POSITIVE).setEnabled(false);
            }
        });
        return ad;
    }

    // Override the Fragment.onAttach() method to instantiate the NoticeDialogListener
    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
        // Verify that the host activity implements the callback interface
        try {
            // Instantiate the NoticeDialogListener so we can send events to the host
            mListener = (NoticeDialogListener) context;
        } catch (ClassCastException e) {
            // The activity doesn't implement the interface, throw exception
            throw new ClassCastException(context.toString()
                    + " must implement NoticeDialogListener");
        }
    }

}

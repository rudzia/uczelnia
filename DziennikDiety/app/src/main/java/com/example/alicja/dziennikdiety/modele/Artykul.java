package com.example.alicja.dziennikdiety.modele;


public class Artykul {

    private String name;
    private String group;
    private ProduktContent.ProduktInfo info;
    private float portion;

    public Artykul(String group, ProduktContent.Produkt produkt, float portion) {
        this.name = produkt.nazwa;
        this.group = group;
        this.info = new ProduktContent.ProduktInfo(produkt.kcal, produkt.weglowodany, produkt.bialko, produkt.tluszcz, produkt.gluten, produkt.laktoza, portion);
        this.portion = portion;
    }

    public String getGroup() {
        return group;
    }
    public void setGroup(String group) {
        this.group = group;
    }

    public String getName() {
        return name;
    }
    public void setName(String name) {
        this.name = name;
    }

    public float getPortion() {
        return portion;
    }

    @Override
    public String toString() {
        return (name+"\n"+info.kcal+" kcal");
    }

    public ProduktContent.ProduktInfo getInfo() {
        return this.info;
    }
}

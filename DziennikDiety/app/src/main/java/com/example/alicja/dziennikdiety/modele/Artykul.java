package com.example.alicja.dziennikdiety.modele;


public class Artykul {

    private String name;
    private String group;
    private ProduktContent.ProduktInfo info;

    public Artykul(ProduktContent.Produkt produkt) {
        this.name = produkt.nazwa;
        this.info = new ProduktContent.ProduktInfo(produkt.kcal, produkt.weglowodany, produkt.bialko, produkt.tluszcz, produkt.gluten, produkt.laktoza);
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

    public ProduktContent.ProduktInfo getInfo() {
        return this.info;
    }
}

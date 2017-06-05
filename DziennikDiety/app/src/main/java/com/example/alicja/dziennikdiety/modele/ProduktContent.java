package com.example.alicja.dziennikdiety.modele;

import android.os.Parcel;
import android.os.Parcelable;

import com.bignerdranch.expandablerecyclerview.Model.ParentListItem;

import java.util.ArrayList;
import java.util.List;

/**
 * Helper class for providing sample content for user interfaces created by
 * Android template wizards.
 * <p>
 * TODO: Replace all uses of this class before publishing your app.
 */
public class ProduktContent {

    /**
     * An array of sample (dummy) items.
     */
    public static final List<Produkt> ITEMS = new ArrayList<Produkt>();

    /**
     * A map of sample (dummy) items, by ID.
     */
    //public static final Map<String, Produkt> ITEM_MAP = new HashMap<String, Produkt>();

    private static final int COUNT = 25;

    static {
        // Add some sample items.
        for (int i = 1; i <= COUNT; i++) {
            addItem(createDummyItem(i));
        }
    }

    private static void addItem(Produkt item) {
        ITEMS.add(item);
        //ITEM_MAP.put(item.id, item);
    }

    private static Produkt createDummyItem(int position) {
        return new Produkt(position, "Item " + position, "13", "17", "55", "12313", (position%3==0), (position%5==0));
    }


    /**
     * A dummy item representing a piece of content.
     */
    public static class Produkt implements ParentListItem,Parcelable {
        public final Integer id;
        public final String nazwa;
        public final String kcal;
        public final String weglowodany;
        public final String bialko;
        public final String tluszcz;
        public final Boolean gluten;
        public final Boolean laktoza;

        private List<Object> mChildrenItemList = null;

        public Produkt(Integer id, String nazwa, String kcal,
                       String weglowodany, String bialko, String tluszcz,
                       Boolean gluten, Boolean laktoza) {
            this.id = id;
            this.nazwa = nazwa;
            this.kcal = kcal;
            this.weglowodany = weglowodany;
            this.bialko = bialko;
            this.tluszcz = tluszcz;
            this.gluten = gluten;
            this.laktoza = laktoza;
            this.mChildrenItemList = new ArrayList<>();
            this.mChildrenItemList.add(new ProduktInfo(kcal, weglowodany, bialko, tluszcz, gluten, laktoza));
        }

        @Override
        public String toString() {
            return nazwa;
        }

        @Override
        public List<?> getChildItemList() {
            return mChildrenItemList;
        }

        public void setChildItemList(List<Object> mChildrenItemList) {
            this.mChildrenItemList = mChildrenItemList;
        }

        @Override
        public boolean isInitiallyExpanded() {
            return false;
        }

        public int describeContents() {
            return 0;
        }

        public void writeToParcel(Parcel out, int flags) {
            out.writeInt(id);
            out.writeString(nazwa);
            out.writeString(kcal);
            out.writeString(weglowodany);
            out.writeString(bialko);
            out.writeString(tluszcz);
            out.writeInt(gluten ? 1 : 0);
            out.writeInt(laktoza ? 1 : 0);
        }

        public static final Parcelable.Creator<Produkt> CREATOR
                = new Parcelable.Creator<Produkt>() {
            public Produkt createFromParcel(Parcel in) {
                return new Produkt(in);
            }

            public Produkt[] newArray(int size) {
                return new Produkt[size];
            }
        };

        private Produkt(Parcel in) {
            id = in.readInt();
            nazwa = in.readString();
            kcal = in.readString();
            weglowodany = in.readString();
            bialko = in.readString();
            tluszcz = in.readString();
            gluten = in.readInt() != 0;
            laktoza = in.readInt() != 0;
        }

    }

    public static class ProduktInfo {
        public final String kcal;
        public final String weglowodany;
        public final String bialko;
        public final String tluszcz;
        public final Boolean gluten;
        public final Boolean laktoza;

        public ProduktInfo(String kcal,
                           String weglowodany, String bialko, String tluszcz,
                           Boolean gluten, Boolean laktoza) {
            this.kcal = kcal;
            this.weglowodany = weglowodany;
            this.bialko = bialko;
            this.tluszcz = tluszcz;
            this.gluten = gluten;
            this.laktoza = laktoza;
        }

        public ProduktInfo(String kcal,
                           String weglowodany, String bialko, String tluszcz,
                           Boolean gluten, Boolean laktoza, float porcja) {
            this.kcal = String.valueOf(Float.valueOf(kcal) * porcja/100);
            this.weglowodany = String.valueOf(Float.valueOf(weglowodany) * porcja/100);
            this.bialko = String.valueOf(Float.valueOf(bialko) * porcja/100);
            this.tluszcz = String.valueOf(Float.valueOf(tluszcz) * porcja/100);
            this.gluten = gluten;
            this.laktoza = laktoza;
        }
    }
}

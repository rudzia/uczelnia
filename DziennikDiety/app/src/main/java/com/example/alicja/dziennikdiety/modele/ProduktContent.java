package com.example.alicja.dziennikdiety.modele;

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
    public static class Produkt implements ParentListItem {
        public final Integer id;
        public final String nazwa;
        public final String kcal;
        public final String weglowodany;
        public final String bialko;
        public final String tluszcz;
        public final Boolean gluten;
        public final Boolean laktoza;

        private List<Object> mChildrenItemList;

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
    }
}

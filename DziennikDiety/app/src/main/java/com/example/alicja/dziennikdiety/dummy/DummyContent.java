package com.example.alicja.dziennikdiety.dummy;

import com.bignerdranch.expandablerecyclerview.Model.ParentListItem;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.StringTokenizer;

/**
 * Helper class for providing sample content for user interfaces created by
 * Android template wizards.
 * <p>
 * TODO: Replace all uses of this class before publishing your app.
 */
public class DummyContent {

    /**
     * An array of sample (dummy) items.
     */
    public static final List<DummyItem> ITEMS = new ArrayList<DummyItem>();

    /**
     * A map of sample (dummy) items, by ID.
     */
    //public static final Map<String, DummyItem> ITEM_MAP = new HashMap<String, DummyItem>();

    private static final int COUNT = 25;

    static {
        // Add some sample items.
        for (int i = 1; i <= COUNT; i++) {
            addItem(createDummyItem(i));
        }
    }

    private static void addItem(DummyItem item) {
        ITEMS.add(item);
        //ITEM_MAP.put(item.id, item);
    }

    private static DummyItem createDummyItem(int position) {
        return new DummyItem(position, "Item " + position, "13", "17", "55", "12313", (position%3==0), (position%5==0));
    }


    /**
     * A dummy item representing a piece of content.
     */
    public static class DummyItem implements ParentListItem {
        public final Integer id;
        public final String nazwa;
        public final String kcal;
        public final String weglowodany;
        public final String bialko;
        public final String tluszcz;
        public final Boolean gluten;
        public final Boolean laktoza;

        private List<Object> mChildrenItemList;

        public DummyItem(Integer id, String nazwa, String kcal,
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
            this.mChildrenItemList.add(new DummyItemInfo(kcal, weglowodany, bialko, tluszcz, gluten, laktoza));
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

    public static class DummyItemInfo {
        public final String kcal;
        public final String weglowodany;
        public final String bialko;
        public final String tluszcz;
        public final Boolean gluten;
        public final Boolean laktoza;

        public DummyItemInfo(String kcal,
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

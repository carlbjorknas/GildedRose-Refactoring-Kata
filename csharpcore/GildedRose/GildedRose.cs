using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> _items;

    public GildedRose(IList<Item> items)
    {
        _items = items;
    }

    public void UpdateQuality()
    {
        foreach(var item in _items)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros")
                continue;
            
            var newQuality = CalcualteNewQuality(item.Name, item.SellIn, item.Quality);
            item.Quality = AdjustQualityToLimits(newQuality);

            item.SellIn--;
        }
    }

    private static int CalcualteNewQuality(string name, int sellIn, int quality)
    {
        if (name == "Aged Brie")
            return sellIn <= 0
            ? quality + 2
            : quality + 1;

        if (name == "Backstage passes to a TAFKAL80ETC concert")
        {
            return sellIn switch
            {
                <= 0 => 0,
                <= 5 => quality + 3,
                <= 10 => quality + 2,
                _ => quality + 1,
            };
        }

        if (name.StartsWith("Conjured"))
        {
            return sellIn <= 0
                ? quality - 4
                : quality - 2;
        }

        return sellIn <= 0
            ? quality - 2
            : quality - 1;
    }

    private static int AdjustQualityToLimits(int quality)
    {
        if (quality < 0)
            return 0;

        if (quality > 50)
            return 50;

        return quality;
    }
}
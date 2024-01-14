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

            item.SellIn--;
            var newQuality = CalcualteNewQuality(item);
            item.Quality = AdjustQualityToLimits(newQuality);
        }
    }

    private static int CalcualteNewQuality(Item item)
    {
        if (item.Name == "Aged Brie")
            return item.SellIn < 0
            ? item.Quality + 2
            : item.Quality + 1;

        if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
        {
            return item.SellIn switch
            {
                < 0 => 0,
                < 5 => item.Quality + 3,
                < 10 => item.Quality + 2,
                _ => item.Quality + 1,
            };
        }

        return item.SellIn < 0
            ? item.Quality - 2
            : item.Quality - 1;
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
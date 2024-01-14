﻿using System.Collections.Generic;

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

            if (item.Name == "Aged Brie")
            {
                item.SellIn--;
                if (item.Quality < 50)
                    item.Quality++;
                continue;
            }

            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {

                item.Quality++;

                if (item.SellIn < 11)
                {
                    item.Quality++;
                }

                if (item.SellIn < 6)
                {
                    item.Quality++;
                }

                if (item.Quality > 50)
                    item.Quality = 50;

                item.SellIn--;

                if (item.SellIn < 0)
                    item.Quality = 0;

                continue;
            }
            
            if (item.Quality > 0)
            {
                item.Quality--;
            }

            item.SellIn--;

            if (item.SellIn < 0)
            {
                if (item.Quality > 0)
                {
                    item.Quality--;
                }
            }
        }
    }
}
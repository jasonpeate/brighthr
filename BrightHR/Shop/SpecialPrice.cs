﻿namespace Shop
{
    public class SpecialPrice
    {
        public string SKU { get; } //TODO : Should be a char as its a single character

        public int NumberOfItems { get; }

        public int Price { get; }

        public SpecialPrice(string SKU, int NumberOfItems, int Price)
        {
            //TODO : check for nulls and empty here.
            this.SKU = SKU;
            this.NumberOfItems = NumberOfItems;
            this.Price = Price;
        }
    }
}

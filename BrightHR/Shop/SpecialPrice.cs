namespace Shop
{
    public class SpecialPrice
    {
        public char SKU { get; }

        public int NumberOfItems { get; }

        public double Price { get; }

        public SpecialPrice(char SKU, int NumberOfItems, double Price)
        {
            this.SKU = SKU;
            this.NumberOfItems = NumberOfItems;
            this.Price = Price;
        }
    }
}

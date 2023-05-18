namespace Shop
{
    public class StockItem
    {
        public string SKU { get; } //TODO : Should be a char as its a single character

        public string Description { get; }

        public double Price { get; }

        public StockItem(string SKU, string Description, double Price)
        {
            //TODO : check for nulls and empty here.
            this.SKU = SKU;
            this.Description = Description;
            this.Price = Price;
        }
    }
}
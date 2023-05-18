namespace Shop
{
    public class StockItem
    {
        public char SKU { get; }

        public string Description { get; }

        public double Price { get; }

        public StockItem(char SKU, string Description, double Price)
        {
            //TODO : check for nulls and empty here.
            this.SKU = SKU;
            this.Description = Description;
            this.Price = Price;
        }
    }
}
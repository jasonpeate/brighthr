namespace Shop
{
    public class Checkout : ICheckout
    {
        public Checkout(HashSet<StockItem> StockItems, HashSet<SpecialPrice> specialPrices)
        {
            
        }

        public int GetTotalPrice()
        {
            throw new NotImplementedException();
        }

        public void Scan(string item)
        {
            throw new NotImplementedException();
        }
    }
}

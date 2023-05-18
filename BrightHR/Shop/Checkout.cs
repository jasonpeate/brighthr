namespace Shop
{
    public class Checkout : ICheckout
    {
        private Dictionary<string, StockItem> _stockItems;

        private int Price;

        public Checkout(HashSet<StockItem> StockItems, HashSet<SpecialPrice> specialPrices)
        {
            _stockItems = StockItems.ToDictionary(a => a.SKU, StringComparer.OrdinalIgnoreCase);
        }

        public int GetTotalPrice()
        {
            //TODO : should this not be a double?
            return Price;
        }

        public void Scan(string item)
        {
            if (_stockItems.TryGetValue(item, out StockItem val))
            {
                Price += val.Price;
            } 
            else
            {
                //TODO : validate here
            }
        }
    }
}

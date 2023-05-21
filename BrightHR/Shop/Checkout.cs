namespace Shop
{
    public class Checkout : ICheckout
    {
        private Dictionary<string, StockItem> _stockItems;
        private Dictionary<string, SpecialPrice> _specialPrices;

        private Dictionary<string, int> SKU_Count = new(StringComparer.OrdinalIgnoreCase);

        private int Price;

        public Checkout(HashSet<StockItem> StockItems, HashSet<SpecialPrice> specialPrices)
        {
            _stockItems = StockItems.ToDictionary(a => a.SKU, StringComparer.OrdinalIgnoreCase); //TODO : Assuming single sku this could be worng
            _specialPrices = specialPrices?.ToDictionary(a => a.SKU, StringComparer.OrdinalIgnoreCase); //TODO : Assuming single sku this could be worng
        }

        public int GetTotalPrice()
        {
            foreach (var AddedAlready in SKU_Count)
            {
                if (_specialPrices?.TryGetValue(AddedAlready.Key, out SpecialPrice sp) ?? false)
                {
                    int Count = AddedAlready.Value / sp.NumberOfItems;

                    if (Count > 0)
                    {
                        Price += Count * sp.Price;
                    }

                    int SingleItems = AddedAlready.Value - (Count * sp.NumberOfItems);

                    ComputeSingleItems(AddedAlready.Key, SingleItems);
                }
                else
                {
                    ComputeSingleItems(AddedAlready.Key, SKU_Count[AddedAlready.Key]);
                }
            }

            //TODO : should this return not be a double?
            return Price;
        }

        public void Scan(string item)
        {
            if (!SKU_Count.ContainsKey(item))
                SKU_Count.Add(item, 0);

            SKU_Count[item]++;             
        }

        private void ComputeSingleItems(string SKU, int Count)
        {
            if (_stockItems.TryGetValue(SKU, out StockItem val))
            {
                Price += val.Price * Count;
            }
            else
            {
                //TODO : validate here
            }
        }
    }
}

namespace Shop.Test
{
    [TestClass]
    public class Tests
    {
        private HashSet<StockItem> StockItems;

        [TestInitialize]
        public void Setup()
        {
            StockItems = new HashSet<StockItem>()
            {
                new StockItem("A","Item A",50),
                new StockItem("B","Item B",30)
            };
        }

        [TestMethod]
        public void PassingInSingleItemToCheckOutReturnsDefaultPriceWhenGetTotalPriceCalled()
        {
            //Arrange
            ICheckout ic = new Checkout(StockItems,null);
            int Amount;

            //Act
            Random random = new();
            int toCheck = random.Next(0, StockItems.Count);

            StockItem item = StockItems.ElementAt(toCheck);

            ic.Scan(item.SKU);
            Amount = ic.GetTotalPrice();

            Assert.AreEqual(item.Price, Amount);

        }

    }
}
using System;

namespace Shop.Test
{
    [TestClass]
    public class Tests
    {
        private HashSet<StockItem> StockItems;

        private HashSet<SpecialPrice> SpecialPrices;

        [TestInitialize]
        public void Setup()
        {
            StockItems = new HashSet<StockItem>()
            {
                new StockItem("A","Item A",50),
                new StockItem("B","Item B",30),
                new StockItem("C","Item C",20),
                new StockItem("D","Item D",15)
            };

            SpecialPrices = new HashSet<SpecialPrice>()
            {
                new SpecialPrice("A",3,130),
                new SpecialPrice("B",2,45)
            };
        }

        [TestMethod]
        public void PassingInSingleItemToCheckOutReturnsDefaultPriceWhenGetTotalPriceCalled()
        {
            //Arrange
            ICheckout ic = new Checkout(StockItems, null);
            int Amount;

            //Act
            Random random = new();
            int toCheck = random.Next(0, StockItems.Count);

            StockItem item = StockItems.ElementAt(toCheck);

            ic.Scan(item.SKU);
            Amount = ic.GetTotalPrice();

            Assert.AreEqual(item.Price, Amount);

        }

        [TestMethod]
        public void PassingInThreeDifferentItemsToCheckOutReturnsDefaultPriceWhenGetTotalPriceCalled()
        {
            //Arrange
            ICheckout ic = new Checkout(StockItems, null);
            HashSet<int> AlreadyAddedInIndexes = new();
            int RetunedAmount, CheckAmount = 0;

            //Act
            Random random = new();

            do
            {

                int toCheck = random.Next(0, StockItems.Count);

                if (!AlreadyAddedInIndexes.Contains(toCheck))
                    AlreadyAddedInIndexes.Add(toCheck);

            } while (AlreadyAddedInIndexes.Count < 3);

            foreach (int i in AlreadyAddedInIndexes)
            {
                StockItem item = StockItems.ElementAt(i);

                CheckAmount += item.Price;

                ic.Scan(item.SKU);
            }

            RetunedAmount = ic.GetTotalPrice();

            Assert.AreEqual(CheckAmount, RetunedAmount);

        }

        [TestMethod]
        public void PassingInDifferentItemsToCheckOutReturnsDefaultPriceWhenGetTotalPriceCalled()
        {
            //Arrange
            ICheckout ic = new Checkout(StockItems, null);
            List<int> AlreadyAddedInIndexes = new();
            int RetunedAmount, CheckAmount = 0, LoopingCount;

            //Act
            Random random = new();
            LoopingCount = random.Next(5, 10);

            for (int i = 0; i < LoopingCount; i++)
            {
                int toCheck = random.Next(0, StockItems.Count);

                StockItem item = StockItems.ElementAt(toCheck);

                CheckAmount += item.Price;

                ic.Scan(item.SKU);
            } 

            RetunedAmount = ic.GetTotalPrice();

            Assert.AreEqual(CheckAmount, RetunedAmount);

        }

        [TestMethod]
        public void PassingInDifferentItemsWithSpecialsOnlyCalucatesCorrectly()
        {
            //Arrange
            ICheckout ic = new Checkout(StockItems, SpecialPrices);
            int RetunedAmount;
            string Item = "A"; // TODO : this has holes in it


            //Act
            StockItem item = StockItems.Single(a => a.SKU == Item);

            SpecialPrice SpecialPrice = SpecialPrices.Single(a => a.SKU.Equals(Item));


            for (int i = 0; i < SpecialPrice.NumberOfItems; i++)
            {
                ic.Scan(item.SKU);
            }  

            RetunedAmount = ic.GetTotalPrice();

            Assert.AreEqual(RetunedAmount, SpecialPrice.Price);

        }

        [TestMethod]
        public void PassingInDifferentItemsWithSpecialsAndNormalPricesCalucatesCorrectly()
        {
            //Arrange
            ICheckout ic = new Checkout(StockItems, SpecialPrices);
            int RetunedAmount;
            string Item = "A"; // TODO : this has holes in it


            //Act
            StockItem item = StockItems.Single(a => a.SKU == Item);

            SpecialPrice SpecialPrice = SpecialPrices.Single(a => a.SKU.Equals(Item));

            for (int i = 0; i < SpecialPrice.NumberOfItems + 1; i++)
            {
                ic.Scan(item.SKU);
            }

            RetunedAmount = ic.GetTotalPrice();

            Assert.AreEqual(RetunedAmount, SpecialPrice.Price + item.Price);

        }

    }
}
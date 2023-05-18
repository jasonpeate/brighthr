namespace Shop.Test
{
    [TestClass]
    public class Tests
    {
        [TestInitialize]
        public void Setup()
        {
            // Runs before each test. (Optional)
        }

        [TestMethod]
        public void PassingInSingleItemToCheckOutReturnsDefaultPriceWhenGetTotalPriceCalled()
        {
            //Arrange
            ICheckout ic = new Checkout();
            int Amount;

            //Act
            ic.Scan("");
            Amount = ic.GetTotalPrice();

            Assert.AreEqual(0, Amount);

        }
    }
}
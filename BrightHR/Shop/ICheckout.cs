namespace Shop
{
    public interface ICheckout
    {
        void Scan(string item); //TODO : should this not be char as you scan the SKU?
        int GetTotalPrice();
    }
}

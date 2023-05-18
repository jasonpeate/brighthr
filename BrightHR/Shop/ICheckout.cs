namespace Shop
{
    interface ICheckout
    {
        void Scan(string item);
        int GetTotalPrice();
    }
}

namespace CoffeeShopUser.Services
{
    public class CartStateService
    {
        public event Action? OnChange;

        public bool HasItemsInCart { get; private set; }
        public int CartItemCount { get; private set; }

        public void SetCartItemCount(int count)
        {
            CartItemCount = count;
            HasItemsInCart = count > 0;
            NotifyStateChanged();
        }

        public void ClearCart()
        {
            CartItemCount = 0;
            HasItemsInCart = false;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }

}

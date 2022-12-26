using BO;

namespace BlApi
{
    public interface ICart
    {
        public Cart AddProduct(Cart cart, int id);
        public Cart UpdateCart(Cart cart, int id, int amount);
        public bool AprrovedCart(Cart cart);
        void ClearItems(Cart cart);
    }
}

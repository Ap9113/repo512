using ProductSelling.Models;

namespace ProductSelling.Services
{
    public interface ICartService
    {
        List<CartItem> GetCart();
        void AddToCart(Product product, int quantity);
        void RemoveFromCart(int productId);
        void ClearCart();
    }
}
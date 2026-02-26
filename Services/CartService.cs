using System.Text.Json;
using ProductSelling.Models;

namespace ProductSelling.Services
{
    public class CartService : ICartService
    {
        private const string SessionKey = "CartSession";
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private ISession Session => _httpContextAccessor.HttpContext!.Session;

        public List<CartItem> GetCart()
        {
            var data = Session.GetString(SessionKey);
            return data == null
                ? new List<CartItem>()
                : JsonSerializer.Deserialize<List<CartItem>>(data)!;
        }

        public void AddToCart(Product product, int quantity)
        {
            var cart = GetCart();
            var existing = cart.FirstOrDefault(c => c.ProductId == product.Id);
            if (existing != null)
            {
                existing.Quantity += quantity;
            }
            else
            {
                cart.Add(new CartItem
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = quantity
                });
            }
            SaveCart(cart);
        }

        public void RemoveFromCart(int productId)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(c => c.ProductId == productId);
            if (item != null)
            {
                cart.Remove(item);
                SaveCart(cart);
            }
        }

        public void ClearCart()
        {
            SaveCart(new List<CartItem>());
        }

        private void SaveCart(List<CartItem> cart)
        {
            Session.SetString(SessionKey, JsonSerializer.Serialize(cart));
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using ProductSelling.Services;

namespace ProductSelling.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;

        public CartController(IProductService productService, ICartService cartService)
        {
            _productService = productService;
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            var cart = _cartService.GetCart();
            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> Add(int productId, int quantity = 1)
        {
            var product = await _productService.GetByIdAsync(productId);
            if (product == null)
                return NotFound();

            _cartService.AddToCart(product, quantity);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Remove(int productId)
        {
            _cartService.RemoveFromCart(productId);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Clear()
        {
            _cartService.ClearCart();
            return RedirectToAction(nameof(Index));
        }
    }
}
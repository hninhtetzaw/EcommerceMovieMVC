using EcommerceMVC.Interfaces.IServices;
using EcommerceMVC.Models.CartDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EcommerceMVC.Controllers
{
    public class CartController : Controller
    {
        private readonly IMovieService _movieService;
        public CartController(IMovieService movieService)
        {
            _movieService =movieService;

        }
        [HttpPost]
        public IActionResult AddtoCart(RequestAddtoCart reqeust)
        {
            var cartObject = new List<ResponseCartItem>();
           
            var movie = _movieService.GetMovieById(reqeust.Id); 
            if(movie is null)
            {
                return NotFound();
            }

            // Read existing cart from session
            string cartJson = HttpContext.Session.GetString("Cart");
            if(cartJson is null)
            {
                cartObject = new List<ResponseCartItem>();
            }
            else
            {
                cartObject = JsonConvert.DeserializeObject<List<ResponseCartItem>>(cartJson);

            }

            var existingCartItem = cartObject.FirstOrDefault(c => c.Id == reqeust.Id);
            if (existingCartItem is null)
            {
                cartObject.Add(new ResponseCartItem
                {
                    Id = movie.Id,
                    MovieName = movie.Title,
                    Price = movie.Price,
                    Quantity = reqeust.Quantity,
                    Total = movie.Price * reqeust.Quantity
                });
            }
            else
            {
                existingCartItem.Quantity += reqeust.Quantity;
                existingCartItem.Total = existingCartItem.Price * existingCartItem.Quantity;
            }

           
            // Save cart back to session
            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cartObject));

            //
            int totalQuantity = cartObject.Sum(x => x.Quantity);
            HttpContext.Session.SetInt32("Quantity", totalQuantity);

            return RedirectToAction("UserDashboard", "Dashboard");
        }

        [HttpGet]
        public IActionResult Cart()
        {
            string cartJson = HttpContext.Session.GetString("Cart");
            List<ResponseCartItem> cart = cartJson == null
                ? new List<ResponseCartItem>()
                : JsonConvert.DeserializeObject<List<ResponseCartItem>>(cartJson);

            return View(cart);
        }

        [HttpGet]
        public IActionResult IncreaseCart(string id)
        {
            string cartJson = HttpContext.Session.GetString("Cart");
            var cartObject = JsonConvert.DeserializeObject<List<ResponseCartItem>>(cartJson);

            var existingCartItem = cartObject.FirstOrDefault(c => c.Id == id);
            if (existingCartItem != null)
            {
                existingCartItem.Quantity += 1;
                existingCartItem.Total = existingCartItem.Price * existingCartItem.Quantity;
            }


            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cartObject));
            HttpContext.Session.SetInt32("Quantity", cartObject.Sum(x => x.Quantity));

            return RedirectToAction("Cart");

        }

        [HttpGet]
        public IActionResult DecreaseCart(string id)
        {
            string cartJson = HttpContext.Session.GetString("Cart");
            var cartObject = JsonConvert.DeserializeObject<List<ResponseCartItem>>(cartJson);

            var existingCartItem = cartObject.FirstOrDefault(c => c.Id == id);
            if (existingCartItem != null)
            {
                existingCartItem.Quantity -= 1;
                existingCartItem.Total = existingCartItem.Price * existingCartItem.Quantity;
            }

            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cartObject));
            HttpContext.Session.SetInt32("Quantity", cartObject.Sum(x => x.Quantity));

            return RedirectToAction("Cart");

        }

        [HttpPost]
        public IActionResult RemoveCart(string id)
        {
            string cartJson = HttpContext.Session.GetString("Cart");
            var cartObject = JsonConvert.DeserializeObject<List<ResponseCartItem>>(cartJson);
            var existingCartItem = cartObject.FirstOrDefault(c => c.Id == id);
            if (existingCartItem != null)
            {
                cartObject.Remove(existingCartItem);
            }

            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cartObject));
            HttpContext.Session.SetInt32("Quantity", cartObject.Sum(x => x.Quantity));

            return RedirectToAction("Cart");
        }

        public IActionResult TestSession()
        {
            HttpContext.Session.SetString("TestKey", "Hello Session");
            var value = HttpContext.Session.GetString("TestKey");
            return Content($"Session value: {value}");
        }
    }
}

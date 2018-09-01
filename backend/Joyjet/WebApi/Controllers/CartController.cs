using Joyjet.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Joyjet.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        [HttpPost]
        [Route("checkout")]
        public IActionResult CheckoutCarts([FromBody]PostCheckoutCartsModel model)
        {
            try
            {
                var articles = model.Articles;
                var carts = model.Carts
                    .Select(c => new CartCheckout
                    {
                        Id = c.Id,
                        Total = GetCartTotal(c, articles)
                    });

                var response = new CheckoutCartsResponse
                {
                    Carts = carts
                };

                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        private double GetCartTotal(Cart cart, IEnumerable<Article> articles) =>
            cart.Items.Sum(i => articles.Single(a => a.Id == i.ArticleId).Price * i.Quantity);
    }
}

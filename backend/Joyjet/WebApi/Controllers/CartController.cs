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
        [HttpPut]
        [Route("checkout")]
        public IActionResult CheckoutCarts([FromBody]PutCheckoutCartsModel model)
        {
            try
            {
                ValidateRequestModel(model);

                var articles = model.Articles;
                var fees = model.DeliveryFees;
                var carts = model.Carts
                    .Select(c => new CartCheckout
                    {
                        Id = c.Id,
                        Total = GetCartTotal(c, articles, fees)
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

        #region Helpers

        private double GetCartTotal(Cart cart, IEnumerable<Article> articles, IEnumerable<DeliveryFees> deliveryFees)
        {
            var articlesTotal = cart.Items.Sum(i =>
                articles.Single(a => a.Id == i.ArticleId).Price * i.Quantity);

            var fee = GetDeliveryFee(articlesTotal, deliveryFees);

            return articlesTotal + fee;
        }

        private double GetDeliveryFee(double articleTotal, IEnumerable<DeliveryFees> deliveryFees)
        {
            var fee = deliveryFees.FirstOrDefault(f => f.EligibleTransactionVolume.MinPrice <= articleTotal
                && (f.EligibleTransactionVolume.MaxPrice ?? double.PositiveInfinity) > articleTotal);

            if (fee != null)
            {
                return fee.Price;
            }

            return 0;
        }

        private void ValidateRequestModel(PutCheckoutCartsModel model)
        {
            if (model.Articles == null || model.Articles.Count() <= 0)
            {
                throw new Exception("Articles not found.");
            }

            if (model.Carts == null || model.Carts.Count() <= 0)
            {
                throw new Exception("Carts not found.");
            }

            if (model.DeliveryFees == null || model.DeliveryFees.Count() <= 0)
            {
                throw new Exception("Delivery Fees not found.");
            }
        }

        #endregion
    }
}

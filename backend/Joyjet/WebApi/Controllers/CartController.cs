﻿using Joyjet.WebApi.Models;
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
                ValidateModel();

                var articles = model.Articles;
                var fees = model.DeliveryFees;
                var discounts = model.Discounts;
                var carts = model.Carts
                    .Select(c => new CartCheckout
                    {
                        Id = c.Id,
                        Total = GetCartTotal(c, articles, fees, discounts)
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

        private double GetCartTotal(Cart cart, IEnumerable<Article> articles, IEnumerable<DeliveryFees> deliveryFees,
            IEnumerable<ArticleDiscount> discounts)
        {
            var articlesTotal = GetArticlesTotal(cart, articles, discounts);
            var fee = GetDeliveryFee(articlesTotal, deliveryFees);

            return articlesTotal + fee;
        }

        private double GetArticlesTotal(Cart cart, IEnumerable<Article> articles,
            IEnumerable<ArticleDiscount> discounts)
        {
            double total = 0;

            foreach (var item in cart.Items)
            {
                var article = articles.Single(a => a.Id == item.ArticleId);
                var price = article.Price;
                var discount = GetDiscount(article, discounts);
                var finalValue = (price + discount) * item.Quantity;

                total += finalValue;
            }

            return total;
        }

        private double GetDiscount(Article article, IEnumerable<ArticleDiscount> discounts)
        {
            var discount = discounts.SingleOrDefault(d => d.ArticleId == article.Id);

            if (discount == null)
            {
                return 0;
            }

            switch (discount.Type)
            {
                case ArticleDiscountType.Amount:
                    return -discount.Value;

                case ArticleDiscountType.Percentage:
                    return -(article.Price * discount.Value / 100);

                default:
                    return 0;
            }
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

        private void ValidateModel()
        {
            if (!ModelState.IsValid)
            {
                var entry = ModelState.First().Value;
                var error = entry.Errors.First();

                throw new Exception(error.ErrorMessage);
            }
        }

        #endregion
    }
}

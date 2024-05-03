﻿using Microservice.Web.Frontend.Models.Dtos;
using Microservice.Web.Frontend.Servcies.BasketService;
using Microservice.Web.Frontend.Servcies.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Web.Frontend.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService basketService;
        private readonly IProductService productService;
        private readonly string UserId = "1";
        public BasketController(IBasketService basketService,
            IProductService productService)
        {
            this.basketService = basketService;
            this.productService = productService;
        }
        public IActionResult Index()
        {
            var basket = basketService.GetBasket(UserId);

            if (basket.discountId.HasValue)
            {
                basket.DiscountDetail = new DiscountInBasketDto
                {
                };
            }

            return View(basket);
        }

        public IActionResult Delete(Guid Id)
        {
            basketService.DeleteFromBasket(Id);
            return RedirectToAction("Index");
        }

        public IActionResult AddToBasket(Guid ProductId)
        {
            var product = productService.Getproduct(ProductId);
            var basket = basketService.GetBasket(UserId);

            AddToBasketDto item = new AddToBasketDto()
            {
                BasketId = basket.id,
                ImageUrl = product.image,
                ProductId = product.id,
                ProductName = product.name,
                Quantity = 1,
                UnitPrice = product.price,
            };
            basketService.AddToBasket(item, UserId);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid BasketItemId, int quantity)
        {
            basketService.UpdateQuantity(BasketItemId, quantity);
            return RedirectToAction("Index");

        }




        [HttpPost]
        public IActionResult ApplyDiscount(string DiscountCode)
        {
            if (string.IsNullOrWhiteSpace(DiscountCode))
            {
                return Json(new ResultDto
                {
                    IsSuccess = false,
                    Message = "لطفا کد تخفیف را وارد نمایید"
                });
            }
            //if (discount.IsSuccess == true)
            //{
            //    if (discount.Data.Used)
            //    {
            //        return Json(new ResultDto
            //        {
            //            IsSuccess = false,
            //            Message = "این کد تخفیف قبلا استفاده شده است"
            //        });
            //    }

            //    var basket = basketService.GetBasket(UserId);
            //    basketService.ApplyDiscountToBasket(Guid.Parse(basket.id), discount.Data.Id);
            //    discountService.UseDiscount(discount.Data.Id);
            //    return Json(new ResultDto
            //    {
            //        IsSuccess = true,
            //        Message = "کد تخفیف با موفقیت به سبد خرید شما اعمال شد",
            //    });
            //}
            return Json(new ResultDto
                {
                    IsSuccess = false,
                });
        }
    }


}

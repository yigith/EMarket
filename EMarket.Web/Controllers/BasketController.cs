using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMarket.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EMarket.Web.Controllers
{
    public class BasketController : Controller
    {
        IBasketViewModelService _basketViewModelService;
        public BasketController(IBasketViewModelService basketViewModelService)
        {
            _basketViewModelService = basketViewModelService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddItem(int productId)
        {
            return Json(_basketViewModelService.AddItemToBasket(productId));
        }
    }
}
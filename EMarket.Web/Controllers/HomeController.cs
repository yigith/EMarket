﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EMarket.Web.Models;
using EMarket.ApplicationCore.Interfaces;

namespace EMarket.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index([FromServices] ICategoryService categoryService)
        {
            return View(categoryService.ListCategories());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

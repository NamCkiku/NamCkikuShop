using AutoMapper;
using NamCkikuShop.Entities.Models;
using NamCkikuShop.Service;
using NamCkikuShop.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NamCkikuShop.Web.Controllers
{
    public class HomeController : Controller
    {
        IProductService _productService;
        public HomeController(IProductService productService)
        {
            this._productService = productService;
        }
        public ActionResult Index()
        {
            var lastestProduct = _productService.GetLastest(8);
            var hotProduct = _productService.GetLastest(8);
            var lastestProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(lastestProduct);
            var hotProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(hotProduct);
            ViewBag.lastestProduct = lastestProductViewModel;
            ViewBag.hotProduct = hotProductViewModel;
            return View();
        }
    }
}
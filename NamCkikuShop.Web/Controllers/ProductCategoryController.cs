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
    public class ProductCategoryController : Controller
    {
        IProductCategoryService _productCategoryService;
        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            this._productCategoryService = productCategoryService;
        }
        // GET: ProductCategory
        [ChildActionOnly]
        public PartialViewResult _MenuLeft()
        {
            var model = _productCategoryService.GetAll();
            var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
            return PartialView(listProductCategoryViewModel);
        }
    }
}
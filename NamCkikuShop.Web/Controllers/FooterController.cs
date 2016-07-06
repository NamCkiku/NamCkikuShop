using AutoMapper;
using NamCkikuShop.Entities.Models;
using NamCkikuShop.Service;
using NamCkikuShop.Web.Models;
using NamCkikuShop.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NamCkikuShop.Web.Controllers
{
    public class FooterController : Controller
    {
        IFooterService _footerService;
        public FooterController(IFooterService footerService)
        {
            this._footerService = footerService;
        }
        // GET: Footer
        [ChildActionOnly]
        public PartialViewResult _FooterMiddle()
        {
            var footerModel = _footerService.GetFooter();
            var footerViewModel = Mapper.Map<Footer, FooterViewModel>(footerModel);
            return PartialView(footerViewModel);
        }
    }
}
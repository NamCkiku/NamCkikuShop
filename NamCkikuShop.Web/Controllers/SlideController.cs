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
    public class SlideController : Controller
    {
        ISliderService _sliderService;
        public SlideController(ISliderService sliderService)
        {
            this._sliderService = sliderService;
        }
        // GET: Slide
        [ChildActionOnly]
        public PartialViewResult _Slider()
        {
            var slideModel = _sliderService.GetSlide();
            var slideView = Mapper.Map<IEnumerable<Slide>, IEnumerable<SlideViewModel>>(slideModel);
            return PartialView(slideView);
        }
    }
}
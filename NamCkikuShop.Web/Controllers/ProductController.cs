﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NamCkikuShop.Web.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Detail(int id)
        {
            return View();
        }
        public ActionResult Category()
        {
            return View();
        }
    }
}
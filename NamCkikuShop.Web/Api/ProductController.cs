﻿using AutoMapper;
using NamCkikuShop.Entities.Models;
using NamCkikuShop.Service;
using NamCkikuShop.Web.Infrastructure.Core;
using NamCkikuShop.Web.Infrastructure.Extensions;
using NamCkikuShop.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace NamCkikuShop.Web.Api
{
    [RoutePrefix("api/product")]
    [Authorize]
    public class ProductController : ApiControllerBase
    {
        IProductService _productService;
        public ProductController(IErrorService errorService, IProductService productService) :
            base(errorService)
        {
            this._productService = productService;
        }
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _productService.GetAll(keyword);
                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);
                var responseData = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(query);

                var paginationSet = new PaginationSet<ProductViewModel>()
                {
                    Items = responseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };

                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }

        [Route("getallparents")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _productService.GetAll();

                var responseData = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _productService.GetByID(id);

                var responseData = Mapper.Map<Product, ProductViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, ProductViewModel productVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newProduct = new Product();
                    newProduct.UpdateProduct(productVm);
                    newProduct.CreatedDate = DateTime.Now;
                    newProduct.CreatedBy = User.Identity.Name;
                    _productService.Add(newProduct);
                    _productService.SaveChanges();
                    var responseData = Mapper.Map<Product, ProductViewModel>(newProduct);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }
        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, ProductViewModel productVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var dbProduct = _productService.GetByID(productVm.ID);
                    dbProduct.UpdateProduct(productVm);
                    dbProduct.UpdatedDate = DateTime.Now;
                    dbProduct.CreatedBy = User.Identity.Name;
                    _productService.Update(dbProduct);
                    _productService.SaveChanges();
                    var responseData = Mapper.Map<Product, ProductViewModel>(dbProduct);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("delete")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var oldProductCategory = _productService.Delete(id);
                    _productService.SaveChanges();

                    var responseData = Mapper.Map<Product, ProductViewModel>(oldProductCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }



        [Route("deletemulti")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedProducts)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var listProduct = new JavaScriptSerializer().Deserialize<List<int>>(checkedProducts);
                    foreach (var item in listProduct)
                    {
                        _productService.Delete(item);
                    }

                    _productService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.OK, listProduct.Count);
                }

                return response;
            });
        }
    }
}

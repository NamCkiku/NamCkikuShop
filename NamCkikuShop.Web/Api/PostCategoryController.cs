using NamCkikuShop.Entities.Models;
using NamCkikuShop.Service;
using NamCkikuShop.Web.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NamCkikuShop.Web.Api
{
    [RoutePrefix("api/postcategory")]
    [Authorize]
    public class PostCategoryController : ApiControllerBase
    {
        IPostCategoryService _postCategoryService;
        public PostCategoryController(IErrorService errorService, IPostCategoryService postCategoryService) : base(errorService)
        {
            this._postCategoryService = postCategoryService;

        }
        //[Route("add")]
        //public HttpResponseMessage Post(HttpRequestMessage request, PostCategoryViewModel postCategoryVm)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        HttpResponseMessage response = null;
        //        if (ModelState.IsValid)
        //        {
        //            request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //        }
        //        else
        //        {
        //            PostCategory newPostCategory = new PostCategory();
        //            newPostCategory.UpdatePostCategory(postCategoryVm);

        //            var category = _postCategoryService.Add(newPostCategory);
        //            _postCategoryService.Save();

        //            response = request.CreateResponse(HttpStatusCode.Created, category);

        //        }
        //        return response;
        //    });
        }
    }
}
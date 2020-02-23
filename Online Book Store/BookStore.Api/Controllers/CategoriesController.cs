using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookStore.Models;
using BookStore.Validation;
using BookStore.Services;
using FluentValidation;

namespace BookStore.Api.Controllers
{
    public class CategoriesController : ApiController
    {
        private readonly ICategoryService service;

        public CategoriesController(ICategoryService service)
        {
            this.service = service;
        }

        // GET: api/categories/5
        public IHttpActionResult Get(string category)
        {
            var categ = service.SelectByCategory(category);

            if (categ == null)
            {
                return NotFound();
            }
            return Ok(categ);
        }

        // POST: api/categories
        public HttpResponseMessage Post(Category category)
        {
            Category_Validation validator = new Category_Validation();
            var result = validator.Validate(category);

            if (!result.IsValid) return Request.CreateResponse(HttpStatusCode.BadRequest);

            if (service.AddACategory(category))
                return Request.CreateResponse(HttpStatusCode.Created);
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }
}

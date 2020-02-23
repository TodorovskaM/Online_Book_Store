using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using BookStore.Models;
using BookStore.Services;
using BookStore.Validation;
using System.Net.Http;
using System.Web.Http;
using FluentValidation;

namespace BookStore.Api.Controllers
{
    public class CustomersController : ApiController
    {
        private readonly ICustomersService service;

        public CustomersController(ICustomersService service)
        {
            this.service = service;
        }


        // GET: api/customers/5
        public IHttpActionResult Get(int id)
        {
            var student = this.service.GetCustomer(id);

            if (student == null)
            {
                return NotFound();
            }
            return base.Ok(student);
        }

        // POST: api/customers
        public HttpResponseMessage Post(Customers customer)
        {
            Customers_Validation validator = new Customers_Validation();
            var result = validator.Validate(customer);

            if (!result.IsValid) return Request.CreateResponse(HttpStatusCode.BadRequest);

            if (service.AddACustomer(customer))
                return Request.CreateResponse(HttpStatusCode.Created);
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        // PUT: api/customers/7
        public IHttpActionResult Put(int id, Customers customer)
        {
            Customers_Validation validator = new Customers_Validation();

            var result = validator.Validate(customer);

            if (!result.IsValid) return BadRequest();

            try
            {
                if (service.UpdateCustomerInfo(customer))
                {
                    return Ok();
                }

                return InternalServerError();
            }
            catch (ApplicationException)
            {
                return NotFound();
            }
        }

        // DELETE: api/customers/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                if (service.DeleteCustomer(id))
                    return Request.CreateResponse(HttpStatusCode.NoContent);
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (ApplicationException ex)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden, ex.Message);
            }
        }

    }
}

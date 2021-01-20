﻿using PS_APM_WebAPI_266.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Cors;
using System.Web.Http.Filters;
using System.Web.Http.OData;

// 01/19/2021 04:04 pm - SSN - [20210119-1601] - [001] - M03-04 - Building the Web API Controller

namespace PS_APM_WebAPI_266.Controllers
{


    // https://forums.asp.net/t/1926835.aspx?Access+Control+Allow+Origin
    public class CustomEnableCORSAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {

            if (actionExecutedContext.Response != null)
                actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:53772");


            base.OnActionExecuted(actionExecutedContext);
        }
    }

    // 01/20/2021 06:03 am - SSN - [20210120-0517] - [002] - M04-03 - Enabling CORS in a Web API service

    // [EnableCors("http://localhost:53772", "*", "*")]

    [CustomEnableCORS]
    public class ProductsController : ApiController
    {
        // GET: api/Products
        //  [SwitchableAuthorization]

        // 01/20/2021 04:09 pm - SSN - [20210120-1601] - [001] - M06-02 Enabling OData queries in a Web API service
        //public IEnumerable<Product> Get()
        [EnableQuery]
        public IQueryable<Product> Get()
        {
            var productRepository = new ProductRepository();
            return productRepository.Retrieve().AsQueryable();
        }


        // 01/20/2021 10:05 am - SSN - [20210120-0928] - [002] - M05-02 - Defining query strings

        public IEnumerable<Product> Get(string search, string targetField)
        {
            var productRepository = new ProductRepository();

            var results = productRepository.Retrieve();

            if (targetField == "name")
            {
                results = results.Where(r => r.ProductName.ToUpper().Contains(search.ToUpper())).ToList();
            }
            else
            {
                results = results.Where(r => r.ProductCode.ToUpper().Contains(search.ToUpper())).ToList();
            }

            return results;

        }



        // GET: api/Products/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Products
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}

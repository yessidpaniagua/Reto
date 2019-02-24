

using Capgemini.WebApi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Capgemini.WebApi.Controllers
{
    public class ValuesController : ApiController
    {


        Entity.mybankEntities2 context = new Entity.mybankEntities2();

        ////GET api/values
        public IEnumerable<customer> Get()
        {
            var lista = context.customer.ToList();

            return lista;
            //return new string[] { "value1", "value2" };
        }




        //public string[] Get()
        //{

        //    return new string[] { "value1", "value2" };
        //}


        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

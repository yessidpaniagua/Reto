using Capgemini.WebApi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Capgemini.WebApi.Repository;
using System.Runtime;
using Capgemini.WebApi.ViewModels;

namespace Capgemini.WebApi.Controllers
{
    public class TransationsController : ApiController
    {
        private mybankEntities2 db = new mybankEntities2();
        private AcountsRepository ar = new AcountsRepository();

        public IHttpActionResult PostTransaccion(int Tipo, decimal Monto, int Canal, string ProductNumber)
        {           

            bool result=ar.RegisterTransaccion(Tipo, Monto, Canal, ProductNumber);

            return Ok(result);


        }

        public IHttpActionResult GetLastTransaccions(int ClientId, string ProductNumber)
        {
           

          

            var T = ar.GetLastTransactions(ClientId, ProductNumber);

            return Ok(T);
        }
    }
}

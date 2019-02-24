using Capgemini.WebApi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Capgemini.WebApi.Controllers
{
    public class SaldoController : ApiController
    {
        private mybankEntities2 db = new mybankEntities2();

       
        public IHttpActionResult Getsaldo(int id,int productId)
        {
            decimal total = 0;

            var saldo =(from s in  db.customer join sa in db.customer_product on s.id equals sa.customer_id where sa.customer_id==id && sa.product_id==productId select sa).ToList() ;
            if (saldo == null)
            {
                return NotFound();
            }
            foreach(customer_product item in saldo)
            {
                total += item.balance;
            }

            return Ok(total);
        }
    }
}

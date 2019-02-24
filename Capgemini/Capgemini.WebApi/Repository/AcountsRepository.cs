using Capgemini.WebApi.Entity;
using Capgemini.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capgemini.WebApi.Repository
{
    public class AcountsRepository
    {
        private mybankEntities2 db = new mybankEntities2();

        public bool RegisterTransaccion(  int Tipo, decimal Monto, int Canal, string ProductNumber)
        {
            transaction t = new transaction();

            int? intCustomerProductID = 0;
            int factor = 0;


            factor = db.transaction_type.Where(x => x.id == Tipo).FirstOrDefault().factor;

            intCustomerProductID=(int?)db.customer_product.Where(x => x.product_number == ProductNumber).FirstOrDefault().id;

            if (intCustomerProductID == null)
                //Si no hay cuentas retorno false
                return false;

            t.channel_id = Canal;
            t.amount = Monto;            
            t.date = DateTime.Now;
            t.status = "APPROVED";
            t.customer_product_id = (int)intCustomerProductID;
            t.transaction_number = 1010;
            t.type = Tipo;

            db.transaction.Add(t);
            db.SaveChanges();

            

            return UpdateAccount(factor, ProductNumber, Monto); 
        }
        public List<TransaccionClientViewModel> GetLastTransactions(int ClientId, string ProductNumber)
        {

            List<TransaccionClientViewModel> T = new List<TransaccionClientViewModel>();

            int CantTrans = int.Parse(System.Configuration.ConfigurationManager.AppSettings["MaxTransactionsAcountState"]);

            var lista = (from tr in db.transaction join cp in db.customer_product on tr.customer_product_id equals cp.id select new { tr, cp }).Take(CantTrans);

            TransaccionClientViewModel tran;

            foreach(var item in lista)
            {
                tran = new TransaccionClientViewModel();

                tran.ProductNumber = item.cp.product_number;
                tran.TranDate = item.tr.date;
                tran.Ammount = item.tr.amount;
                tran.Status = item.tr.status;

                T.Add(tran);

                tran = null;
        
            }

            return (T.ToList());
        }
        private bool UpdateAccount(int Factor,string ProductNumber,decimal Monto)
        {

            customer_product cp = new customer_product();

            cp= db.customer_product.Where(x => x.product_number == ProductNumber).FirstOrDefault();

            if (cp ==null)
            {
                return false;
            }
            cp.balance = cp.balance + (Factor * Monto);

            db.Entry(cp).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return true;
        }
    }
}
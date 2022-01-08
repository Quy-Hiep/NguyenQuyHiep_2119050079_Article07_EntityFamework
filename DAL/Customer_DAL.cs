using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class Customer_DAL : DBConnection
    {
        public List<Customer_DTO> ReadCustomer()
        {
            return Customers.ToList();
        }
        public void DeleteCustomer(Customer_DTO cus)
        {
            var deletedCustomer = this.Customers.Where(c => c.CustomerId == cus.CustomerId).FirstOrDefault();
            this.Customers.Remove(deletedCustomer);
            this.SaveChanges();


            //this.Customers.Remove(cus);
            //this.SaveChanges();
        }
        public void NewCustomer(Customer_DTO cus)
        {
            var area = this.Areas.Where(m => m.AreaName == cus.Area.AreaName).FirstOrDefault();
            cus.AreaId = area.AreaId;
            var data = new Customer_DTO
            {
                CustomerId = cus.CustomerId,
                CustomerName = cus.CustomerName,
                AreaId = cus.AreaId
            };

            this.Customers.Add(data);
            this.SaveChanges();

            //this.Customers.Add(cus);
            //this.SaveChanges();
        }
        public void EditCustomer(Customer_DTO cus)
        {

            var editCustomer = this.Customers.Where(c => c.CustomerId == cus.CustomerId).FirstOrDefault();
            
            var area = this.Areas.Where(m => m.AreaName == cus.Area.AreaName).FirstOrDefault();
            cus.AreaId = area.AreaId;
            var data = new Customer_DTO
            {
                CustomerId = cus.CustomerId,
                CustomerName = cus.CustomerName,
                AreaId = cus.AreaId
            };
            this.Entry(editCustomer).CurrentValues.SetValues(data);
            this.SaveChanges();
            


            //this.Entry(cus).State = EntityState.Modified;
            //this.SaveChanges();
        }
    }
}

using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            this.Customers.Remove(cus);
            this.SaveChanges();
        }
        public void NewCustomer(Customer_DTO cus)
        {
            this.Customers.Add(cus);
            this.SaveChanges();
        }
        public void EditCustomer(Customer_DTO cus)
        {
            this.Entry(cus).State = EntityState.Modified;
            this.SaveChanges();
        }
    }
}

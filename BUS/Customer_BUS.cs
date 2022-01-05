using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class Customer_BUS
    {
        Customer_DAL dal = new Customer_DAL();
        public List<Customer_DTO> ReadCustomer()
        {
            List<Customer_DTO> lstCus = dal.ReadCustomer();
            return lstCus;
        }
        public void NewCustomer(Customer_DTO cus)
        {
            dal.NewCustomer(cus);
        }
        public void DeleteCustomer(Customer_DTO cus)
        {
            dal.DeleteCustomer(cus);
        }
        public void EditCustomer(Customer_DTO cus)
        {
            dal.EditCustomer(cus);
        }
    }
}

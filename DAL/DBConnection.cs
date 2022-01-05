using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DTO;
namespace DAL
{
    public class DBConnection: DbContext
    {
        public DBConnection() : base("name = SaleDB")
        {

        }
        public DbSet<Customer_DTO> Customers { get; set; }
        public DbSet<Area_DTO> Areas { get; set; }

    }
}

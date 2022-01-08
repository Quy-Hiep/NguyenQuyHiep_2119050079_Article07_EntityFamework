using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Customer_DTO
    {
        [Key,Column(TypeName="varchar"),MaxLength(50)]
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string AreaId { get; set; }

        public virtual Area_DTO Area { get; set; }

    }
}

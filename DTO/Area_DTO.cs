using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Area_DTO
    {
        [Key,Column(TypeName="varchar"),MaxLength(50)]
        public string AreaId { get; set; }
        public string AreaName { get; set; }
        public virtual List<Customer_DTO> Customers { get; set; }
    }
}

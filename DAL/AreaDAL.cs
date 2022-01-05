using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AreaDAL:DBConnection
    {
        public List<Area_DTO> ReadArea()
        {
            return Areas.ToList();
        }
        public void DeleteArea(Area_DTO area)
        {
            this.Areas.Remove(area);
            this.SaveChanges();
        }
        public void NewArea(Area_DTO area)
        {
            this.Areas.Add(area);
            this.SaveChanges();
        }
        public void EditArea(Area_DTO area)
        {
            this.Entry(area).State = EntityState.Modified;
            this.SaveChanges();
        }
    }
}

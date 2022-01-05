using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BUS
{
    public class Area_BUS
    {
        Area_DAL dal = new Area_DAL();
        public List<Area_DTO> ReadAreaList()
        {
            List<Area_DTO> lstArea = dal.ReadArea();
            return lstArea;
        }
        public void NewArea(Area_DTO area)
        {
            dal.NewArea(area);
        }
        public void DeleteArea(Area_DTO area)
        {
            dal.DeleteArea(area);
        }
        public void EditArea(Area_DTO area)
        {
            dal.EditArea(area);
        }
    }
}

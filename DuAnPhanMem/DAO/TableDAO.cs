using DuAnPhanMem.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnPhanMem.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance 
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; } 
            private set => TableDAO.instance = value; 
        }
        public TableDAO() { }

        public List<TableDTO> LayDanhSachBan()
        {
            List<TableDTO> tableList = new List<TableDTO>();
            DataTable data = DataProvider.Instance.ExcuteQuery("sp_LaySoBan");

            foreach (DataRow item in data.Rows)
            {
                TableDTO dbtable = new TableDTO(item);
                tableList.Add(dbtable);
            }
            return tableList;
        }
        
    }
}

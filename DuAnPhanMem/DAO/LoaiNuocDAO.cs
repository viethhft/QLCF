using DuAnPhanMem.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnPhanMem.DTO
{
    public class LoaiNuocDAO
    {
        private static LoaiNuocDAO instance;

        public static LoaiNuocDAO Instance 
        {
            get { if (instance == null) instance = new LoaiNuocDAO(); return LoaiNuocDAO.instance; } 
            private set => LoaiNuocDAO.instance = value; 
        }

        public LoaiNuocDAO() { }
        public List<LoaiNuocDTO> LayDanhSachNuoc()
        {
            List<LoaiNuocDTO> listNuoc = new List<LoaiNuocDTO>();
            DataTable data = DataProvider.Instance.ExcuteQuery("sp_LayLoaiNuoc");

            foreach (DataRow item in data.Rows)
            {
                LoaiNuocDTO loaiNuocList = new LoaiNuocDTO(item);
                listNuoc.Add(loaiNuocList);
            }
            return listNuoc;
        }
        public void InsertLoai(string tennuoc)
        {
            string query = "exec sp_SetLoaiNuoc @tennuoc";
            DataProvider.Instance.ExcuteQuery(query, new object[] {tennuoc});
        }
    }
}

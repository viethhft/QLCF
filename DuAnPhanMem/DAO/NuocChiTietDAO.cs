using DuAnPhanMem.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnPhanMem.DAO
{
    public class NuocChiTietDAO
    {
        private static NuocChiTietDAO instance;

        public static NuocChiTietDAO Instance 
        {
            get { if (instance == null) instance = new NuocChiTietDAO(); return NuocChiTietDAO.instance; } 
            private set => NuocChiTietDAO.instance = value; 
        }

        public NuocChiTietDAO() { }

        public List<NuocChiTietDTO> DanhSachNuocChiTiet(int id)
        {
            List<NuocChiTietDTO> lstNuocChiTiet = new List<NuocChiTietDTO>();
            string query = "select * from TenNuocChiTiet where IdLoaiNuoc = " + id;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                NuocChiTietDTO dataNuocCT = new NuocChiTietDTO(item);
                lstNuocChiTiet.Add(dataNuocCT);
            }

            return lstNuocChiTiet;
        }
        public List<NuocChiTietDTO> DanhSachNuoc()
        {
            List<NuocChiTietDTO> lstNuocChiTiet = new List<NuocChiTietDTO>();
            string query = "select * from TenNuocChiTiet";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                NuocChiTietDTO dataNuocCT = new NuocChiTietDTO(item);
                lstNuocChiTiet.Add(dataNuocCT);
            }

            return lstNuocChiTiet;
        }
        public void InsertNuocChiTiet(string tennuoc,int idnuoc,int gia)
        {
            string query = "exec sp_SetNuocChiTiet @tennuoc , @idnuoc , @gia";
            DataProvider.Instance.ExcuteQuery(query, new object[] { tennuoc, idnuoc, gia });
        }
    }
}

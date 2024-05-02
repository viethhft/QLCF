using DuAnPhanMem.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnPhanMem.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance 
        {
            get { if (instance == null) instance = new BillInfoDAO(); return BillInfoDAO.instance; }
            private set => BillInfoDAO.instance = value; 
        }

        public BillInfoDAO()
        {

        }
        public List<BillInfoDTO> GetBillInfo(int id)
        {
            List<BillInfoDTO> billinfo = new List<BillInfoDTO>();

            string query = "select * from HoaDonChiTiet where IdHoaDon = " + id;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                BillInfoDTO bill = new BillInfoDTO(item);
                billinfo.Add(bill);
            }

            return billinfo;
        }

        public void InsertBillInfo(int idBill, int idNuoc, int soLuong)
        {
            DataProvider.Instance.ExcuteNonQuery("exec sp_InsertBillInfo @idBill , @idNuoc , @soluong", new object[] {idBill, idNuoc, soLuong});
        }
    }
}

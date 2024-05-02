using DuAnPhanMem.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnPhanMem.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set => BillDAO.instance = value;
        }
        public BillDAO() { }

        public int GetBillIdByTableIdUnCheckout(int id)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("select * from HoaDon where IdBan = " + id + " and TrangThai = 0");
            if (data.Rows.Count > 0)
            {
                BillDTO bill = new BillDTO(data.Rows[0]);
                return bill.Id;
            }
            return -1;
        }
        public void CheckOut(int id, string totalPrice)
        {
            string query = "update HoaDon set ThoiGianRa = getdate() , TrangThai = 1 , TongTien = " + totalPrice + " where Id = " + id;
            DataProvider.Instance.ExcuteNonQuery(query);
        }
        public void InsertBill(int id)
        {
            DataProvider.Instance.ExcuteNonQuery("exec sp_InsertBill @idBan", new object[] { id });
        }
        public int GetMaxIdBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExcuteScalar("select max(Id) from HoaDon");
            }
            catch
            {
                return 1;
            }
        }
        public DataTable GetBill()
        {
            string query = "select b.SoBan [Số bàn], hd.TongTien [Tổng số tiền], ThoiGianVao [Thời gian vào], ThoiGianRa [Thời gian ra] from HoaDon hd join Ban b on hd.IdBan = b.Id";
            return DataProvider.Instance.ExcuteQuery(query);
        }
        public DataTable GetListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            return DataProvider.Instance.ExcuteQuery("exec sp_ListBill @checkIn , @checkOut", new object[] { checkIn, checkOut });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnPhanMem.DTO
{
    public class MenuDTO
    {
        private string foodName;
        private int soLuong;
        private float gia;
        private float thanhtien;
        public string FoodName { get => foodName; set => foodName = value; }
        public float Gia { get => gia; set => gia = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public float Thanhtien { get => thanhtien; set => thanhtien = value; }

        public MenuDTO(string foodname, int soluong, float gia, float thanhtien = 0)
        {
            this.FoodName = foodname;
            this.SoLuong = soluong;
            this.Gia = gia;
            this.Thanhtien = thanhtien;
        }
        public MenuDTO(DataRow row)
        {
            this.FoodName = row["TenChiTiet"].ToString();
            this.SoLuong = (int)row["Soluong"];
            this.Gia = (float)Convert.ToDouble(row["gia"].ToString());
            this.Thanhtien = (float)Convert.ToDouble(row["totalPrice"].ToString());
        }
    }
}

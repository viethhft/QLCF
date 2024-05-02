using DuAnPhanMem.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnPhanMem.DTO
{
    public class TableDTO
    {
        private int id;
        private string soBan;
        private string trangThai;

        public int Id { get => id; set => id = value; }
        public string SoBan { get => soBan; set => soBan = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }

        public static int TableWidth = 100;
        public static int TableHeight = 100;
        public TableDTO(int id, string soban, string trangthai)
        {
            this.Id = id;
            this.SoBan = soban;
            this.TrangThai = trangthai;
        }
        public TableDTO(DataRow row)
        {
            this.id = (int)row["Id"];
            this.soBan = row["SoBan"].ToString();
            this.trangThai = row["TrangThai"].ToString();
        }
        
    }
}

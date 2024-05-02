using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnPhanMem.DTO
{
    public class NuocChiTietDTO
    {
        private int id;
        private string tenChiTiet;
        private int idLoaiNuoc;
        private float gia;

        public int Id { get => id; set => id = value; }
        public string TenChiTiet { get => tenChiTiet; set => tenChiTiet = value; }
        public int IdLoaiNuoc { get => idLoaiNuoc; set => idLoaiNuoc = value; }
        public float Gia { get => gia; set => gia = value; }

        public NuocChiTietDTO(int id, string tenchitiet, int idloainuoc, float gia)
        {
            this.Id = id;
            this.TenChiTiet = tenchitiet;
            this.IdLoaiNuoc = idloainuoc;
            this.Gia = gia;
        }

        public NuocChiTietDTO(DataRow row)
        {
            this.Id = (int)row["IdChiTiet"];
            this.TenChiTiet = row["TenChiTiet"].ToString();
            this.IdLoaiNuoc = (int)row["IdLoaiNuoc"];
            this.Gia = (float)Convert.ToDouble(row["Gia"].ToString());
        }
    }
}

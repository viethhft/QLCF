using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnPhanMem.DTO
{
    public class LoaiNuocDTO
    {
        private int id;
        private string tenLoaiNuoc;
        public LoaiNuocDTO() { }

        public int Id { get => id; set => id = value; }
        public string TenLoaiNuoc { get => tenLoaiNuoc; set => tenLoaiNuoc = value; }

        public LoaiNuocDTO(int id, string tenloainuoc)
        {
            this.Id = id;
            this.TenLoaiNuoc = tenloainuoc;
        }

        public LoaiNuocDTO(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.TenLoaiNuoc = row["TenLoaiNuoc"].ToString();
        }
    }
}

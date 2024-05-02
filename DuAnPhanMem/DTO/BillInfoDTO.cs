using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnPhanMem.DTO
{
    public class BillInfoDTO
    {
        int id;
        int idBill;
        int idNuoc;
        int soLuong;

        public int Id { get => id; set => id = value; }
        public int IdBill { get => idBill; set => idBill = value; }
        public int IdNuoc { get => idNuoc; set => idNuoc = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }

        public BillInfoDTO(int id, int idbill, int idnuoc, int soluong)
        {
            this.Id = id;
            this.IdBill = idbill;
            this.IdNuoc = idnuoc;
            this.SoLuong = soluong;
        }
        public BillInfoDTO(DataRow row)
        {
            this.Id = (int)row["id"];
            this.IdBill = (int)row["idbill"];
            this.IdNuoc = (int)row["idnuoc"];
            this.SoLuong = (int)row["soluong"];
        }
    }
}

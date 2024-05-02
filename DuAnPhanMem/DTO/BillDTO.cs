using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnPhanMem.DTO
{
    public class BillDTO
    {
        int id;
        DateTime? dateCheckIn;
        DateTime? dateCheckOut;
        int trangThai;

        public int Id { get => id; set => id = value; }
        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public int TrangThai { get => trangThai; set => trangThai = value; }

        public BillDTO(int id, DateTime? datecheckin, DateTime? datecheckout, int trangthai)
        {
            this.Id = id;
            this.DateCheckIn = datecheckin;
            this.DateCheckOut = datecheckout;
            this.TrangThai = trangthai;
        }
        public BillDTO(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.DateCheckIn = (DateTime?)row["ThoiGianVao"];
            var checkTimeOut = row["ThoiGianRa"];
            if(checkTimeOut.ToString() != "")
                this.DateCheckOut = (DateTime?)checkTimeOut;
            this.TrangThai = (int)row["TrangThai"];
        }
    }
}

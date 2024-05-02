using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DuAnPhanMem.DTO;
using Menu = System.Windows.Forms.Menu;

namespace DuAnPhanMem.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO(); return MenuDAO.instance; }
            private set => MenuDAO.instance = value;
        }
        public MenuDAO()
        {

        }

        public List<MenuDTO> GetListMenuByTable(int id)
        {
            List<MenuDTO> lstMenu = new List<MenuDTO>();
            
            string query = "select tnct.TenChiTiet, hdct.SoLuong, tnct.Gia, tnct.Gia*hdct.SoLuong [totalPrice] from HoaDon hd join HoaDonChiTiet hdct on hd.Id = hdct.IdHoaDon join TenNuocChiTiet tnct on hdct.IdNuoc = tnct.IdChiTiet where hd.TrangThai = 0 and hd.IdBan = " + id;

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                MenuDTO listMenu = new MenuDTO(item);
                lstMenu.Add(listMenu);
            }

            return lstMenu;
        }
    }
}

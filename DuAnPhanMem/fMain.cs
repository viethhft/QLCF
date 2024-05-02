using DuAnPhanMem.DAO;
using DuAnPhanMem.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuAnPhanMem
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
            HienThiBan();
            HienThiLoaiNuoc();
        }

        private void HienThiBan()
        {
            flpnShowBan.Controls.Clear();
            List<TableDTO> listTable = TableDAO.Instance.LayDanhSachBan();
            
            foreach (TableDTO item in listTable)
            {
                Button btn = new Button() { Width = TableDTO.TableWidth, Height = TableDTO.TableHeight };
                btn.Text = item.SoBan + Environment.NewLine + item.TrangThai;
                btn.Click += Btn_Click;
                btn.Tag = item;

                

                if (item.TrangThai == "Trống") 
                    btn.BackColor = Color.SkyBlue;
                else
                    btn.BackColor = Color.Yellow;

                flpnShowBan.Controls.Add(btn);
            }
        }
        public void ShowBill(int id)
        {
            listView1.Items.Clear();
            List<MenuDTO> billinfo = MenuDAO.Instance.GetListMenuByTable(id);

            float totalPrice = 0;
            foreach (MenuDTO item in billinfo)
            {
                ListViewItem lvi = new ListViewItem(item.FoodName.ToString());
                lvi.SubItems.Add(item.SoLuong.ToString());
                lvi.SubItems.Add(item.Gia.ToString());
                lvi.SubItems.Add(item.Thanhtien.ToString());
                totalPrice += item.Thanhtien;

                listView1.Items.Add(lvi);
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            tbTongTien.Text = totalPrice.ToString("c",culture);

        }
        private void Btn_Click(object sender, EventArgs e)
        {
            int idTable = ((sender as Button).Tag as TableDTO).Id;
            listView1.Tag = (sender as Button).Tag;
           
            ShowBill(idTable);
        }

        private void HienThiLoaiNuoc()
        {
            List<LoaiNuocDTO> lstLoaiNuoc = LoaiNuocDAO.Instance.LayDanhSachNuoc();

            cbType.DataSource = lstLoaiNuoc;
            cbType.DisplayMember = "TenLoaiNuoc";
        }

        private void HienThiNuocChiTiet(int id)
        {
            List<NuocChiTietDTO> lstNuocCT = NuocChiTietDAO.Instance.DanhSachNuocChiTiet(id);

            cbTypInfo.DataSource = lstNuocCT;
            cbTypInfo.DisplayMember = "TenChiTiet";
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;
            LoaiNuocDTO selected = cb.SelectedItem as LoaiNuocDTO;
            id = selected.Id;

            HienThiNuocChiTiet(id);
        }

        private void btThemMon_Click(object sender, EventArgs e)
        {
            TableDTO table = listView1.Tag as TableDTO;

            int idBill = BillDAO.Instance.GetBillIdByTableIdUnCheckout(table.Id);
            int idFood = (cbTypInfo.SelectedItem as NuocChiTietDTO).Id;
            int soLuong = (int)number.Value;

            if(idBill == -1)
            {
                BillDAO.Instance.InsertBill(table.Id);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIdBill(),idFood,soLuong);
            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, idFood, soLuong);
            }

            ShowBill(table.Id);

            HienThiBan();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TableDTO table = listView1.Tag as TableDTO;
            int idBill = BillDAO.Instance.GetBillIdByTableIdUnCheckout(table.Id);
            string totalPrice = tbTongTien.Text.Split(',')[0];
            
            if (idBill != -1)
            {
                if (MessageBox.Show("Bạn chắc chắn muốn thanh toán hóa đơn ở bàn " + table.SoBan, "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill,totalPrice);
                    ShowBill(table.Id);
                    HienThiBan();
                } 
            }
        }

        private void fMain_Load(object sender, EventArgs e)
        {

        }
    }
}

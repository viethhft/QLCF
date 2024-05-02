using DuAnPhanMem.DAO;
using DuAnPhanMem.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuAnPhanMem
{
    public partial class fAdmin : Form
    {
        public fAdmin()
        {
            InitializeComponent();
            LoadAccount();
            LoadBill();
            loadDrink();
        }

        void LoadAccount()
        {
            AccountDAO acc = new AccountDAO();
            dgvAcc.DataSource = acc.GetListAccount();
            dgvAcc1.DataSource = acc.GetListAccount();
            dtgShowDel.DataSource = acc.GetListAccount();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = tbInUser.Text;
            string hienthi = tbInName.Text;
            string pass = tbInPass.Text;

            try
            {
                AccountDAO.Instance.InsertAccount(user, hienthi, pass);
                LoadAccount();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("Tên đăng nhập bị trùng", "Thông báo");
                }
            }
            finally
            {
                MessageBox.Show("Thêm thành công");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tbInUser.Clear();
            tbInPass.Clear();
            tbInName.Clear();
        }


        private void dgvAcc1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvAcc1.CurrentRow.Index;
            tbShowTK.Text = dgvAcc1.Rows[i].Cells[0].Value.ToString();
            tbShowName.Text = dgvAcc1.Rows[i].Cells[1].Value.ToString();
            tbShowPass.Text = dgvAcc1.Rows[i].Cells[2].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                AccountDAO.Instance.UpdateAccount(tbShowTK.Text, tbShowPass.Text, tbShowName.Text);
                MessageBox.Show("Sửa thành công", "Thông báo");
                LoadAccount();
            }
            catch
            {
                MessageBox.Show("Sửa dữ liệu thất bại!!!", "Thông báo");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa tài khoản này?", "Thông báo!!!", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                AccountDAO.Instance.DelAccount(tbdelUser.Text, tbdelName.Text);
                MessageBox.Show("Xóa thành công");
                LoadAccount();
            }
        }

        private void dtgShowDel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dtgShowDel.CurrentRow.Index;
            tbdelUser.Text = dtgShowDel.Rows[i].Cells[0].Value.ToString();
            tbdelName.Text = dtgShowDel.Rows[i].Cells[1].Value.ToString();
            tbdelPass.Text = dtgShowDel.Rows[i].Cells[2].Value.ToString();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            label16.BackColor = Color.YellowGreen;
        }

        void LoadBill()
        {
            dtvShowBill.DataSource = BillDAO.Instance.GetBill();
        }
        void LoadBillByDate(DateTime checkIn, DateTime checkOut)
        {
            dtvShowBill.DataSource = BillDAO.Instance.GetListBillByDate(checkIn, checkOut);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LoadBillByDate(dtFrom.Value,dateTimePicker2.Value);
        }
        void loadDrink()
        {
            LoaiNuocDAO loaiNuocDAO = new LoaiNuocDAO();
            dgvListDrink.DataSource = loaiNuocDAO.LayDanhSachNuoc();
            dgvListDrink.Columns[0].HeaderText = "ID";
            dgvListDrink.Columns[1].HeaderText = "Tên loại nước";
            List<NuocChiTietDTO> lstNuocCT = NuocChiTietDAO.Instance.DanhSachNuoc();
            dgvListDrinkDetail.DataSource = lstNuocCT;
            dgvListDrinkDetail.Columns[0].HeaderText = "ID chi tiết";
            dgvListDrinkDetail.Columns[1].HeaderText = "Tên chi tiết";
            dgvListDrinkDetail.Columns[2].HeaderText = "ID loại nước";
            dgvListDrinkDetail.Columns[3].HeaderText = "Giá";
            cbNameDrink.DataSource = loaiNuocDAO.LayDanhSachNuoc();
            cbNameDrink.DisplayMember = "TenLoaiNuoc";
        }
        private void fAdmin_Load(object sender, EventArgs e)
        {

        }

        private void addNewDrink_Click(object sender, EventArgs e)
        {
            string tennuoc = txtNewName.Text;
            string test = $"select * from LoaiNuoc where TenLoaiNuoc like N'{tennuoc}'";
            
            if (DataProvider.Instance.ExcuteQuery(test).Rows.Count == 0)
            {
                LoaiNuocDAO.Instance.InsertLoai(tennuoc);
                loadDrink();
                MessageBox.Show("Thêm thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Tên nước đã có trong danh sách","Thông báo");
            }
        }

        private void addNewDrinkDetail_Click(object sender, EventArgs e)
        {
            string tenchitiet = txtNewNameDetail.Text;
            int idnuoc = 0;

            for (int i = 0; i < dgvListDrink.Rows.Count; i++)
            {
                if (dgvListDrink.Rows[i].Cells[1].Value.ToString()==cbNameDrink.Text)
                {
                    idnuoc = Convert.ToInt32(dgvListDrink.Rows[i].Cells[0].Value);
                }
            }
            int price = Convert.ToInt32(PriceDrinkDetail.Value);
            try
            {
                NuocChiTietDAO.Instance.InsertNuocChiTiet(tenchitiet, idnuoc, price);
                MessageBox.Show($"Thêm món {tenchitiet} vào {cbNameDrink.Text} thành công");
                loadDrink();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}

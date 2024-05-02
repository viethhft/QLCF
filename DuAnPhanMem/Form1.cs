using DuAnPhanMem.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuAnPhanMem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            IconLoad();
        }
        public void IconLoad()
        {
            Icon ic = new Icon("caphe.ico");
            this.Icon = ic;
        }
        //public void LoadAnh()
        //{
        //    Image img = new Image();
        //}
        private void btLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            if (Login(username, password))
            {
                if (username != "admin")
                {
                    fMain f = new fMain();
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
                else
                {
                    fAdmin fm = new fAdmin();
                    this.Hide();
                    fm.ShowDialog();
                    this.Show();
                }
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!!", "Lỗi");
            }
        }
        
        public bool Login(string username, string password)
        {
            return AccountDAO.Instance.Login(username, password);
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đóng ứng dụng?", "Thông báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}

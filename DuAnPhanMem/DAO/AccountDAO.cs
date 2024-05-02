using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuAnPhanMem.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance 
        {
            get { if (instance == null) instance = new AccountDAO(); return AccountDAO.instance; } 
            private set => AccountDAO.instance = value; 
        }

        public AccountDAO() { }

        public bool Login(string username, string password)
        {
            string query = "sp_CheckLogin @username , @matkhau";
            DataTable result =  DataProvider.Instance.ExcuteQuery(query, new object[] {username,password});
            return result.Rows.Count > 0;
        }
        public DataTable GetListAccount()
        {
            string query = "select TenTaiKhoan [Tên tài khoản], TenHienThi [Tên hiển thị], MatKhau [Mật khẩu] from TaiKhoan";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            return data;
        }
        public void InsertAccount(string username, string tenhienthi, string pass)
        {
            string query = "exec sp_InsertAccount @username , @tenhienthi , @password";
            DataProvider.Instance.ExcuteQuery(query, new object[] {username,tenhienthi,pass});
        }
        public void UpdateAccount(string user, string pass, string name)
        {
            string query = "exec sp_UpdateAccount @user , @pass , @tenhienthi";
            DataProvider.Instance.ExcuteQuery(query, new object[] {user,pass,name});
        }
        public void DelAccount(string user, string name)
        {
            string query = "exec sp_DelAccount @user , @tenhienthi";
            DataProvider.Instance.ExcuteNonQuery(query,new object[] {user,name});
        }
    }
}

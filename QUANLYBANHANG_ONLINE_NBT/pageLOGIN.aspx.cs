using System;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYBANHANG_ONLINE_NBT
{
    public partial class pageLOGIN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String tenDangNhap = txtUserName.Text.Trim();
            String matKhau = txtPassWord.Text.Trim();

            if (String.IsNullOrEmpty(tenDangNhap) || String.IsNullOrEmpty(matKhau))
            {
                lblLoi.Text = "Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.";
                return;
            }

            XULYDULIEU xuly = new XULYDULIEU();
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@TENDANGNHAP", tenDangNhap);
            pr[1] = new SqlParameter("@MATKHAU", matKhau);

            DataTable tb = xuly.getTable("psgetTableLOGIN", pr);

            if (tb != null && tb.Rows.Count > 0)
            {
                DataRow row = tb.Rows[0];
                Session["TENDANGNHAP"] = row["TENDANGNHAP"].ToString();
                Session["HOTEN"] = row["HOTEN"].ToString();
                Session["QUYEN"] = row["QUYEN"].ToString();

                if (row["QUYEN"].ToString() == "True" || row["QUYEN"].ToString() == "1")
                {
                    Response.Redirect("~/ADMIN/GUI/TRANGCHU_ADMIN.aspx");
                }
                else
                {
                    Response.Redirect("~/DANHSACHSANPHAM.aspx");
                }
            }
            else
            {
                lblLoi.Text = "Sai tên đăng nhập hoặc mật khẩu.";
            }
        }
    }
}

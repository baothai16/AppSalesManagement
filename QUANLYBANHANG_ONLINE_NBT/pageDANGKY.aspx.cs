using System;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYBANHANG_ONLINE_NBT
{
    public partial class pageDANGKY : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDangKy_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            String tenDangNhap = txtTENDANGNHAP.Text.Trim();
            XULYDULIEU xuly = new XULYDULIEU();

            // Kiểm tra trùng tên đăng nhập
            SqlParameter[] prCheck = new SqlParameter[1];
            prCheck[0] = new SqlParameter("@TENDANGNHAP", tenDangNhap);
            DataTable tbCheck = xuly.getTable("psKiemTraTonTaiTaiKhoan", prCheck);

            if (tbCheck != null && tbCheck.Rows.Count > 0)
            {
                lblThongBao.ForeColor = System.Drawing.Color.Red;
                lblThongBao.Text = "Tên đăng nhập đã tồn tại, vui lòng chọn tên khác.";
                return;
            }

            SqlParameter[] pr = new SqlParameter[6];
            pr[0] = new SqlParameter("@TENDANGNHAP", tenDangNhap);
            pr[1] = new SqlParameter("@MATKHAU", txtMATKHAU.Text.Trim());
            pr[2] = new SqlParameter("@HOTEN", txtHOTEN.Text.Trim());
            pr[3] = new SqlParameter("@EMAIL", txtEMAIL.Text.Trim());
            pr[4] = new SqlParameter("@DIENTHOAI", txtDIENTHOAI.Text.Trim());
            pr[5] = new SqlParameter("@DIACHI", txtDIACHI.Text.Trim());

            int k = xuly.ExeCute("psInsertRecordTAIKHOAN", pr);

            if (k > 0)
            {
                lblThongBao.ForeColor = System.Drawing.Color.Green;
                lblThongBao.Text = "Đăng ký thành công! Đang chuyển đến trang đăng nhập...";
                Response.Redirect("pageLOGIN.aspx");
            }
            else
            {
                lblThongBao.ForeColor = System.Drawing.Color.Red;
                lblThongBao.Text = "Đăng ký thất bại, vui lòng thử lại.";
            }
        }
    }
}

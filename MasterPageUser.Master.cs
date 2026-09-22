using System;
using System.Data.SqlClient;

namespace QUANLYBANHANG_ONLINE_NBT
{
    public partial class MasterPageUser : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDanhMuc();
            }

            LoadTrangThaiDangNhap();
            LoadGioHang();
        }

        private void LoadDanhMuc()
        {
            XULYDULIEU xuly = new XULYDULIEU();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@MADANHMUC", DBNull.Value);

            this.rptDANHMUC.DataSource = xuly.getTable("psGetTableDANHMUC", pr);
            this.rptDANHMUC.DataBind();
        }

        private void LoadTrangThaiDangNhap()
        {
            if (Session["TENDANGNHAP"] != null)
            {
                phChuaDangNhap.Visible = false;
                phDaDangNhap.Visible = true;
                litHoTen.Text = Session["HOTEN"] != null ? Session["HOTEN"].ToString() : Session["TENDANGNHAP"].ToString();
            }
            else
            {
                phChuaDangNhap.Visible = true;
                phDaDangNhap.Visible = false;
            }
        }

        private void LoadGioHang()
        {
            if (Session["CART"] != null)
            {
                CART cart = (CART)Session["CART"];
                litSoLuongGioHang.Text = cart.TotalItems().ToString();
                litTongTienGioHang.Text = cart.TotalBill().ToString("0.##");
            }
            else
            {
                litSoLuongGioHang.Text = "0";
                litTongTienGioHang.Text = "0";
            }
        }

        protected void btnTimKiem_Click(object sender, EventArgs e)
        {
            String tukhoa = txtTuKhoa.Text.Trim();
            Response.Redirect("DANHSACHSANPHAM.aspx?tukhoa=" + Server.UrlEncode(tukhoa));
        }
    }
}

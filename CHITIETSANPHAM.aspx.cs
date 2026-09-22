using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace QUANLYBANHANG_ONLINE_NBT
{
    public partial class CHITIETSANPHAM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadChiTietSanPham();
            }
        }

        private void LoadChiTietSanPham()
        {
            String maSanPham = Request.QueryString["MASANPHAM"];
            if (String.IsNullOrEmpty(maSanPham))
            {
                Response.Redirect("DANHSACHSANPHAM.aspx");
                return;
            }

            XULYDULIEU xuly = new XULYDULIEU();
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@MASANPHAM", Convert.ToInt32(maSanPham));

            this.rptCHITIET.DataSource = xuly.getTable("psGetTableSANPHAM", pr);
            this.rptCHITIET.DataBind();
        }

        protected void btnThemGioHang_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;

            HiddenField hdfMASANPHAM = (HiddenField)item.FindControl("hdfMASANPHAM");
            HiddenField hdfTENSANPHAM = (HiddenField)item.FindControl("hdfTENSANPHAM");
            HiddenField hdfHINHANH = (HiddenField)item.FindControl("hdfHINHANH");
            HiddenField hdfDONGIA = (HiddenField)item.FindControl("hdfDONGIA");
            TextBox txtSOLUONGMUA = (TextBox)item.FindControl("txtSOLUONGMUA");

            int soLuong;
            if (!int.TryParse(txtSOLUONGMUA.Text, out soLuong) || soLuong <= 0)
                soLuong = 1;

            CART cart = (Session["CART"] != null) ? (CART)Session["CART"] : new CART();
            cart.AddCart(
                hdfMASANPHAM.Value,
                hdfTENSANPHAM.Value,
                hdfHINHANH.Value,
                soLuong,
                Convert.ToDouble(hdfDONGIA.Value)
            );
            Session["CART"] = cart;

            lblThongBao.Text = "Đã thêm sản phẩm \"" + hdfTENSANPHAM.Value + "\" vào giỏ hàng.";

            LoadChiTietSanPham();
        }
    }
}

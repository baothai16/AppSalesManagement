using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;

namespace QUANLYBANHANG_ONLINE_NBT
{
    public partial class pageGIOHANG : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["TENDANGNHAP"] != null)
                {
                    txtHOTENNGUOINHAN.Text = Session["HOTEN"] != null ? Session["HOTEN"].ToString() : "";
                }
                LoadGioHang();
            }
        }

        private void LoadGioHang()
        {
            if (Session["CART"] != null)
            {
                CART cart = (CART)Session["CART"];
                this.grvCART.DataSource = cart.LISTCARTS.Values.ToList();
                this.grvCART.DataBind();
                litTongCong.Text = cart.TotalBill().ToString("0.##");
            }
            else
            {
                this.grvCART.DataSource = null;
                this.grvCART.DataBind();
                litTongCong.Text = "0";
            }
        }

        protected void grvCART_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "XoaSanPham")
            {
                String maSanPham = e.CommandArgument.ToString();
                if (Session["CART"] != null)
                {
                    CART cart = (CART)Session["CART"];
                    cart.RemoveCart(maSanPham);
                    Session["CART"] = cart;
                }
                LoadGioHang();
            }
        }

        protected void btnXoaGioHang_Click(object sender, EventArgs e)
        {
            if (Session["CART"] != null)
            {
                CART cart = (CART)Session["CART"];
                cart.ClearCart();
                Session["CART"] = cart;
            }
            LoadGioHang();
        }

        protected void btnDatHang_Click(object sender, EventArgs e)
        {
            if (Session["CART"] == null || ((CART)Session["CART"]).LISTCARTS.Count == 0)
            {
                lblThongBao.ForeColor = System.Drawing.Color.Red;
                lblThongBao.Text = "Giỏ hàng của bạn đang trống.";
                return;
            }

            if (String.IsNullOrWhiteSpace(txtHOTENNGUOINHAN.Text) ||
                String.IsNullOrWhiteSpace(txtDIACHINHAN.Text) ||
                String.IsNullOrWhiteSpace(txtDIENTHOAINHAN.Text))
            {
                lblThongBao.ForeColor = System.Drawing.Color.Red;
                lblThongBao.Text = "Vui lòng nhập đầy đủ thông tin nhận hàng.";
                return;
            }

            CART cart = (CART)Session["CART"];
            XULYDULIEU xuly = new XULYDULIEU();

            // 1) Tạo đơn hàng (DONHANG)
            SqlParameter[] prDonHang = new SqlParameter[5];
            prDonHang[0] = new SqlParameter("@TENDANGNHAP",
                Session["TENDANGNHAP"] != null ? (object)Session["TENDANGNHAP"].ToString() : DBNull.Value);
            prDonHang[1] = new SqlParameter("@HOTENNGUOINHAN", txtHOTENNGUOINHAN.Text.Trim());
            prDonHang[2] = new SqlParameter("@DIACHINHAN", txtDIACHINHAN.Text.Trim());
            prDonHang[3] = new SqlParameter("@DIENTHOAINHAN", txtDIENTHOAINHAN.Text.Trim());
            prDonHang[4] = new SqlParameter("@TONGTIEN", cart.TotalBill());

            DataTable tbKetQua = xuly.getTable("psInsertRecordDONHANG", prDonHang);
            if (tbKetQua == null || tbKetQua.Rows.Count == 0)
            {
                lblThongBao.ForeColor = System.Drawing.Color.Red;
                lblThongBao.Text = "Đặt hàng thất bại, vui lòng thử lại.";
                return;
            }

            int maDonHang = Convert.ToInt32(tbKetQua.Rows[0]["MADONHANG"]);

            // 2) Tạo chi tiết đơn hàng (CTDONHANG) cho từng sản phẩm trong giỏ
            foreach (ITEM item in cart.LISTCARTS.Values)
            {
                SqlParameter[] prCT = new SqlParameter[5];
                prCT[0] = new SqlParameter("@MADONHANG", maDonHang);
                prCT[1] = new SqlParameter("@MASANPHAM", Convert.ToInt32(item.MASANPHAM));
                prCT[2] = new SqlParameter("@TENSANPHAM", item.TENSANPHAM);
                prCT[3] = new SqlParameter("@SOLUONG", item.SOLUONG);
                prCT[4] = new SqlParameter("@DONGIA", item.DONGIA);
                xuly.ExeCute("psInsertRecordCTDONHANG", prCT);
            }

            // 3) Xóa giỏ hàng sau khi đặt hàng thành công
            cart.ClearCart();
            Session["CART"] = cart;
            LoadGioHang();

            lblThongBao.ForeColor = System.Drawing.Color.Green;
            lblThongBao.Text = "Đặt hàng thành công! Mã đơn hàng của bạn là #" + maDonHang + ".";
        }
    }
}

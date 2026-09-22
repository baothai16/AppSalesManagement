using System;
using System.Web.UI.WebControls;
using QUANLYBANHANG_ONLINE_NBT.ADMIN.BUSINESSLOGIC;

namespace QUANLYBANHANG_ONLINE_NBT.ADMIN.GUI
{
    public partial class QUANLYDONHANG_GUI : System.Web.UI.Page
    {
        QUANLYDONHANG_BUSINESSLOGIC businesslogic;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TENDANGNHAP"] == null || Session["QUYEN"] == null ||
                (Session["QUYEN"].ToString() != "True" && Session["QUYEN"].ToString() != "1"))
            {
                Response.Redirect("~/pageLOGIN.aspx");
                return;
            }

            businesslogic = new QUANLYDONHANG_BUSINESSLOGIC(this);

            if (!IsPostBack)
            {
                businesslogic.SetValueGridViewDonHang();
            }
        }

        protected void grvDONHANG_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int maDonHang = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "XemChiTiet")
            {
                businesslogic.SetValueGridViewChiTiet(maDonHang);
            }
            else if (e.CommandName == "CapNhatDaXuLy")
            {
                businesslogic.CapNhatTrangThai(maDonHang, "Đã xử lý");
                lblThongBao.Text = "Đã cập nhật trạng thái đơn hàng #" + maDonHang + ".";
                businesslogic.SetValueGridViewDonHang();
            }
        }
    }
}

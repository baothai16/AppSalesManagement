using System;
using System.Web.UI.WebControls;
using QUANLYBANHANG_ONLINE_NBT.ADMIN.BUSINESSLOGIC;

namespace QUANLYBANHANG_ONLINE_NBT.ADMIN.GUI
{
    public partial class QUANLYSANPHAM_GUI : System.Web.UI.Page
    {
        QUANLYSANPHAM_BUSINESSLOGIC businesslogic;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TENDANGNHAP"] == null || Session["QUYEN"] == null ||
                (Session["QUYEN"].ToString() != "True" && Session["QUYEN"].ToString() != "1"))
            {
                Response.Redirect("~/pageLOGIN.aspx");
                return;
            }

            businesslogic = new QUANLYSANPHAM_BUSINESSLOGIC(this);

            if (!IsPostBack)
            {
                businesslogic.SetValueDropdownlistDanhMuc();
                businesslogic.SetValueGridViewSanPham();
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            int k = businesslogic.InsertRecordSanPham();
            lblThongBao.ForeColor = k > 0 ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            lblThongBao.Text = k > 0 ? "Thêm sản phẩm thành công." : "Thêm sản phẩm thất bại.";

            businesslogic.SetValueDropdownlistDanhMuc();
            businesslogic.SetValueGridViewSanPham();
            businesslogic.LamMoiForm();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMASANPHAM.Text))
            {
                lblThongBao.ForeColor = System.Drawing.Color.Red;
                lblThongBao.Text = "Vui lòng chọn sản phẩm cần cập nhật (bấm Sửa trong danh sách).";
                return;
            }

            int k = businesslogic.UpdateRecordSanPham();
            lblThongBao.ForeColor = k > 0 ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            lblThongBao.Text = k > 0 ? "Cập nhật sản phẩm thành công." : "Cập nhật sản phẩm thất bại.";

            businesslogic.SetValueDropdownlistDanhMuc();
            businesslogic.SetValueGridViewSanPham();
            businesslogic.LamMoiForm();
        }

        protected void btnMakeNew_Click(object sender, EventArgs e)
        {
            businesslogic.LamMoiForm();
            lblThongBao.Text = "";
        }

        protected void grvSANPHAM_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int maSanPham = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "SuaSanPham")
            {
                businesslogic.NapDuLieuLenForm(maSanPham);
                lblThongBao.Text = "";
            }
            else if (e.CommandName == "XoaSanPham")
            {
                int k = businesslogic.DeleteRecordSanPham(maSanPham);
                lblThongBao.ForeColor = k > 0 ? System.Drawing.Color.Green : System.Drawing.Color.Red;
                lblThongBao.Text = k > 0 ? "Xóa sản phẩm thành công." : "Xóa sản phẩm thất bại (có thể sản phẩm đã có trong đơn hàng).";
                businesslogic.SetValueGridViewSanPham();
                businesslogic.LamMoiForm();
            }
        }
    }
}

using System;
using System.Web.UI.WebControls;
using QUANLYBANHANG_ONLINE_NBT.ADMIN.BUSINESSLOGIC;

namespace QUANLYBANHANG_ONLINE_NBT.ADMIN.GUI
{
    public partial class QUANLYDANHMUC_GUI : System.Web.UI.Page
    {
        QUANLYDANHMUC_BUSINESSLOGIC businesslogic;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TENDANGNHAP"] == null || Session["QUYEN"] == null ||
                (Session["QUYEN"].ToString() != "True" && Session["QUYEN"].ToString() != "1"))
            {
                Response.Redirect("~/pageLOGIN.aspx");
                return;
            }

            businesslogic = new QUANLYDANHMUC_BUSINESSLOGIC(this);

            if (!IsPostBack)
            {
                businesslogic.SetValueGridViewDanhMuc();
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            int k = businesslogic.InsertRecordDanhMuc();
            lblThongBao.ForeColor = k > 0 ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            lblThongBao.Text = k > 0 ? "Thêm danh mục thành công." : "Thêm danh mục thất bại.";

            businesslogic.SetValueGridViewDanhMuc();
            businesslogic.LamMoiForm();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMADANHMUC.Text))
            {
                lblThongBao.ForeColor = System.Drawing.Color.Red;
                lblThongBao.Text = "Vui lòng chọn danh mục cần cập nhật (bấm Sửa trong danh sách).";
                return;
            }

            int k = businesslogic.UpdateRecordDanhMuc();
            lblThongBao.ForeColor = k > 0 ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            lblThongBao.Text = k > 0 ? "Cập nhật danh mục thành công." : "Cập nhật danh mục thất bại.";

            businesslogic.SetValueGridViewDanhMuc();
            businesslogic.LamMoiForm();
        }

        protected void btnMakeNew_Click(object sender, EventArgs e)
        {
            businesslogic.LamMoiForm();
            lblThongBao.Text = "";
        }

        protected void grvDANHMUC_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int maDanhMuc = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "SuaDanhMuc")
            {
                businesslogic.NapDuLieuLenForm(maDanhMuc);
                lblThongBao.Text = "";
            }
            else if (e.CommandName == "XoaDanhMuc")
            {
                int k = 0;
                try
                {
                    k = businesslogic.DeleteRecordDanhMuc(maDanhMuc);
                }
                catch (Exception) { k = 0; }

                lblThongBao.ForeColor = k > 0 ? System.Drawing.Color.Green : System.Drawing.Color.Red;
                lblThongBao.Text = k > 0 ? "Xóa danh mục thành công." : "Xóa thất bại (danh mục đang có sản phẩm sử dụng).";
                businesslogic.SetValueGridViewDanhMuc();
                businesslogic.LamMoiForm();
            }
        }
    }
}

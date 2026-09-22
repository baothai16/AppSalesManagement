using System;
using System.Data.SqlClient;

namespace QUANLYBANHANG_ONLINE_NBT.ADMIN.GUI
{
    public partial class TRANGCHU_ADMIN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TENDANGNHAP"] == null || Session["QUYEN"] == null ||
                (Session["QUYEN"].ToString() != "True" && Session["QUYEN"].ToString() != "1"))
            {
                Response.Redirect("~/pageLOGIN.aspx");
                return;
            }

            litHoTen.Text = Session["HOTEN"] != null ? Session["HOTEN"].ToString() : Session["TENDANGNHAP"].ToString();

            if (!IsPostBack)
            {
                XULYDULIEU xuly = new XULYDULIEU();

                SqlParameter[] prSP = new SqlParameter[1];
                prSP[0] = new SqlParameter("@MASANPHAM", DBNull.Value);
                litSoSanPham.Text = xuly.getTable("psGetTableSANPHAM", prSP).Rows.Count.ToString();

                SqlParameter[] prDM = new SqlParameter[1];
                prDM[0] = new SqlParameter("@MADANHMUC", DBNull.Value);
                litSoDanhMuc.Text = xuly.getTable("psGetTableDANHMUC", prDM).Rows.Count.ToString();

                SqlParameter[] prDH = new SqlParameter[1];
                prDH[0] = new SqlParameter("@MADONHANG", DBNull.Value);
                litSoDonHang.Text = xuly.getTable("psGetTableDONHANG", prDH).Rows.Count.ToString();
            }
        }
    }
}

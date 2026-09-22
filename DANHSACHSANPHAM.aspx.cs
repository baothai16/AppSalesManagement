using System;
using System.Data.SqlClient;

namespace QUANLYBANHANG_ONLINE_NBT
{
    public partial class DANHSACHSANPHAM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            XULYDULIEU xuly = new XULYDULIEU();
            this.DataList1.RepeatColumns = 3;

            String maDanhMuc = Request.QueryString["MADANHMUC"];
            String tuKhoa = Request.QueryString["tukhoa"];

            if (!String.IsNullOrEmpty(tuKhoa))
            {
                SqlParameter[] pr = new SqlParameter[1];
                pr[0] = new SqlParameter("@TUKHOA", tuKhoa);
                this.DataList1.DataSource = xuly.getTable("psTimKiemSanPham", pr);
            }
            else if (!String.IsNullOrEmpty(maDanhMuc))
            {
                SqlParameter[] pr = new SqlParameter[1];
                pr[0] = new SqlParameter("@MADANHMUC", Convert.ToInt32(maDanhMuc));
                this.DataList1.DataSource = xuly.getTable("psGetTableSanPhamTheoDanhMuc", pr);
            }
            else
            {
                SqlParameter[] pr = new SqlParameter[1];
                pr[0] = new SqlParameter("@MASANPHAM", DBNull.Value);
                this.DataList1.DataSource = xuly.getTable("psGetTableSANPHAM", pr);
            }

            this.DataList1.DataBind();
        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

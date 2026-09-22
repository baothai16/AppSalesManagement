using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using QUANLYBANHANG_ONLINE_NBT.ADMIN.PROCESSDATA;

namespace QUANLYBANHANG_ONLINE_NBT.ADMIN.BUSINESSLOGIC
{
    public class QUANLYDONHANG_BUSINESSLOGIC
    {
        QUANLYDONHANG_PROCESSDATA processdata;
        Page pageDONHANG;

        public QUANLYDONHANG_BUSINESSLOGIC(Page page)
        {
            pageDONHANG = page;
            processdata = new QUANLYDONHANG_PROCESSDATA();
        }

        public void SetValueGridViewDonHang()
        {
            GridView grv = (GridView)pageDONHANG.FindControl("grvDONHANG");
            grv.DataSource = processdata.getTableDonHang();
            grv.DataBind();
        }

        public void SetValueGridViewChiTiet(int maDonHang)
        {
            GridView grv = (GridView)pageDONHANG.FindControl("grvCHITIETDONHANG");
            grv.DataSource = processdata.getChiTietDonHang(maDonHang);
            grv.DataBind();

            Label lbl = (Label)pageDONHANG.FindControl("lblMaDonHangDangXem");
            lbl.Text = maDonHang.ToString();
        }

        public int CapNhatTrangThai(int maDonHang, String trangThai)
        {
            return processdata.CapNhatTrangThai(maDonHang, trangThai);
        }
    }
}

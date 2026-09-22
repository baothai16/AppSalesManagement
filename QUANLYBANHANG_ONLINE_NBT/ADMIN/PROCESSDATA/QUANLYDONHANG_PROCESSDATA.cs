using System;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYBANHANG_ONLINE_NBT.ADMIN.PROCESSDATA
{
    public class QUANLYDONHANG_PROCESSDATA
    {
        XULYDULIEU xulydulieu;

        public QUANLYDONHANG_PROCESSDATA()
        {
            xulydulieu = new XULYDULIEU();
        }

        public DataTable getTableDonHang()
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@MADONHANG", DBNull.Value);
            return xulydulieu.getTable("psGetTableDONHANG", pr);
        }

        public DataTable getChiTietDonHang(int maDonHang)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@MADONHANG", maDonHang);
            return xulydulieu.getTable("psGetTableCTDONHANG", pr);
        }

        public int CapNhatTrangThai(int maDonHang, String trangThai)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@MADONHANG", maDonHang);
            pr[1] = new SqlParameter("@TRANGTHAI", trangThai);
            return xulydulieu.ExeCute("psUpdateTrangThaiDONHANG", pr);
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYBANHANG_ONLINE_NBT.ADMIN.PROCESSDATA
{
    public class QUANLYDANHMUC_PROCESSDATA
    {
        XULYDULIEU xulydulieu;

        public QUANLYDANHMUC_PROCESSDATA()
        {
            xulydulieu = new XULYDULIEU();
        }

        public DataTable getTableDanhMuc()
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@MADANHMUC", DBNull.Value);
            return xulydulieu.getTable("psGetTableDANHMUC", pr);
        }

        public DataTable getRecordDanhMuc(int maDanhMuc)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@MADANHMUC", maDanhMuc);
            return xulydulieu.getTable("psGetTableDANHMUC", pr);
        }

        public int InsertRecord(String tenDanhMuc, String moTa)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("@TENDANHMUC", tenDanhMuc);
            pr[1] = new SqlParameter("@MOTA", (object)moTa ?? DBNull.Value);
            return xulydulieu.ExeCute("psInsertRecordDANHMUC", pr);
        }

        public int UpdateRecord(int maDanhMuc, String tenDanhMuc, String moTa)
        {
            SqlParameter[] pr = new SqlParameter[3];
            pr[0] = new SqlParameter("@MADANHMUC", maDanhMuc);
            pr[1] = new SqlParameter("@TENDANHMUC", tenDanhMuc);
            pr[2] = new SqlParameter("@MOTA", (object)moTa ?? DBNull.Value);
            return xulydulieu.ExeCute("psUpdateRecordDANHMUC", pr);
        }

        public int DeleteRecord(int maDanhMuc)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@MADANHMUC", maDanhMuc);
            return xulydulieu.ExeCute("psDeleteRecordDANHMUC", pr);
        }
    }
}

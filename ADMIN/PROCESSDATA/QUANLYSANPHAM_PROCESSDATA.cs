using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace QUANLYBANHANG_ONLINE_NBT.ADMIN.PROCESSDATA
{
    public class QUANLYSANPHAM_PROCESSDATA
    {
        XULYDULIEU xulydulieu;

        public QUANLYSANPHAM_PROCESSDATA()
        {
            xulydulieu = new XULYDULIEU();
        }

        public DataTable getTableDanhmuc()
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@MADANHMUC", DBNull.Value);
            return xulydulieu.getTable("psGetTableDANHMUC", pr);
        }

        public DataTable getTableSanPham()
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@MASANPHAM", DBNull.Value);
            return xulydulieu.getTable("psGetTableSANPHAM", pr);
        }

        public DataTable getRecordSanPham(int maSanPham)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@MASANPHAM", maSanPham);
            return xulydulieu.getTable("psGetTableSANPHAM", pr);
        }

        public int InsertRecord(Dictionary<String, Object> list)
        {
            SqlParameter[] pr = new SqlParameter[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                SqlParameter param;
                if (list.ElementAt(i).Value != null)
                    param = new SqlParameter(list.ElementAt(i).Key, list.ElementAt(i).Value);
                else
                    param = new SqlParameter(list.ElementAt(i).Key, DBNull.Value);

                pr[i] = param;
            }

            int k = xulydulieu.ExeCute("psInsertRecordSANPHAM", pr);
            return k;
        }

        public int UpdateRecord(Dictionary<String, Object> list)
        {
            SqlParameter[] pr = new SqlParameter[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                SqlParameter param;
                if (list.ElementAt(i).Value != null)
                    param = new SqlParameter(list.ElementAt(i).Key, list.ElementAt(i).Value);
                else
                    param = new SqlParameter(list.ElementAt(i).Key, DBNull.Value);

                pr[i] = param;
            }

            int k = xulydulieu.ExeCute("psUpdateRecordSANPHAM", pr);
            return k;
        }

        public int DeleteRecord(int maSanPham)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("@MASANPHAM", maSanPham);

            int k = xulydulieu.ExeCute("psDeleteRecordSANPHAM", pr);
            return k;
        }
    }
}

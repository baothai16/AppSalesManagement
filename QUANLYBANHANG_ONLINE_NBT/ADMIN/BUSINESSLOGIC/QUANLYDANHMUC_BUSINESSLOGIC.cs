using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using QUANLYBANHANG_ONLINE_NBT.ADMIN.PROCESSDATA;

namespace QUANLYBANHANG_ONLINE_NBT.ADMIN.BUSINESSLOGIC
{
    public class QUANLYDANHMUC_BUSINESSLOGIC
    {
        QUANLYDANHMUC_PROCESSDATA processdata;
        Page pageDANHMUC;

        public QUANLYDANHMUC_BUSINESSLOGIC(Page page)
        {
            pageDANHMUC = page;
            processdata = new QUANLYDANHMUC_PROCESSDATA();
        }

        public void SetValueGridViewDanhMuc()
        {
            GridView grv = (GridView)pageDANHMUC.FindControl("grvDANHMUC");
            grv.DataSource = processdata.getTableDanhMuc();
            grv.DataBind();
        }

        public void NapDuLieuLenForm(int maDanhMuc)
        {
            DataTable tb = processdata.getRecordDanhMuc(maDanhMuc);
            if (tb == null || tb.Rows.Count == 0) return;
            DataRow row = tb.Rows[0];

            ((TextBox)pageDANHMUC.FindControl("txtMADANHMUC")).Text = row["MADANHMUC"].ToString();
            ((TextBox)pageDANHMUC.FindControl("txtTENDANHMUC")).Text = row["TENDANHMUC"].ToString();
            ((TextBox)pageDANHMUC.FindControl("txtMOTA")).Text = row["MOTA"] == DBNull.Value ? "" : row["MOTA"].ToString();
        }

        public void LamMoiForm()
        {
            ((TextBox)pageDANHMUC.FindControl("txtMADANHMUC")).Text = "";
            ((TextBox)pageDANHMUC.FindControl("txtTENDANHMUC")).Text = "";
            ((TextBox)pageDANHMUC.FindControl("txtMOTA")).Text = "";
        }

        public int InsertRecordDanhMuc()
        {
            String tenDanhMuc = ((TextBox)pageDANHMUC.FindControl("txtTENDANHMUC")).Text;
            String moTa = ((TextBox)pageDANHMUC.FindControl("txtMOTA")).Text;
            return processdata.InsertRecord(tenDanhMuc, moTa);
        }

        public int UpdateRecordDanhMuc()
        {
            int maDanhMuc = Convert.ToInt32(((TextBox)pageDANHMUC.FindControl("txtMADANHMUC")).Text);
            String tenDanhMuc = ((TextBox)pageDANHMUC.FindControl("txtTENDANHMUC")).Text;
            String moTa = ((TextBox)pageDANHMUC.FindControl("txtMOTA")).Text;
            return processdata.UpdateRecord(maDanhMuc, tenDanhMuc, moTa);
        }

        public int DeleteRecordDanhMuc(int maDanhMuc)
        {
            return processdata.DeleteRecord(maDanhMuc);
        }
    }
}

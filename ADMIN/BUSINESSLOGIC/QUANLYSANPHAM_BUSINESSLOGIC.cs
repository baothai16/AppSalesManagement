using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Data;
using QUANLYBANHANG_ONLINE_NBT.ADMIN.PROCESSDATA;

namespace QUANLYBANHANG_ONLINE_NBT.ADMIN.BUSINESSLOGIC
{
    public class QUANLYSANPHAM_BUSINESSLOGIC
    {
        QUANLYSANPHAM_PROCESSDATA processdata;
        Page pageSANPHAM;

        public QUANLYSANPHAM_BUSINESSLOGIC(Page page)
        {
            pageSANPHAM = page;
            processdata = new QUANLYSANPHAM_PROCESSDATA();
        }

        public void SetValueDropdownlistDanhMuc()
        {
            DropDownList drp = (DropDownList)pageSANPHAM.FindControl("drpDANHMUC");
            drp.DataSource = processdata.getTableDanhmuc();
            drp.DataTextField = "TENDANHMUC";
            drp.DataValueField = "MADANHMUC";
            drp.DataBind();
        }

        public void SetValueGridViewSanPham()
        {
            GridView grv = (GridView)pageSANPHAM.FindControl("grvSANPHAM");
            grv.DataSource = processdata.getTableSanPham();
            grv.DataBind();
        }

        public String UploadAnh()
        {
            FileUpload fileupload = (FileUpload)pageSANPHAM.FindControl("FileANHSANPHAM");
            String fileName = null;
            if (fileupload.HasFile)
            {
                fileName = System.IO.Path.GetFileName(fileupload.FileName);
                String path = pageSANPHAM.Server.MapPath("~/images/");
                fileupload.PostedFile.SaveAs(path + fileName);
            }
            return fileName;
        }

        public void NapDuLieuLenForm(int maSanPham)
        {
            DataTable tb = processdata.getRecordSanPham(maSanPham);
            if (tb == null || tb.Rows.Count == 0) return;

            DataRow row = tb.Rows[0];

            ((TextBox)pageSANPHAM.FindControl("txtMASANPHAM")).Text = row["MASANPHAM"].ToString();
            ((TextBox)pageSANPHAM.FindControl("txtTENSANPHAM")).Text = row["TENSANPHAM"].ToString();
            ((TextBox)pageSANPHAM.FindControl("txtDONGIA")).Text = row["DONGIA"].ToString();
            ((TextBox)pageSANPHAM.FindControl("txtSOLUONG")).Text = row["SOLUONG"].ToString();
            ((TextBox)pageSANPHAM.FindControl("txtMOTA")).Text = row["MOTA"] == DBNull.Value ? "" : row["MOTA"].ToString();

            DropDownList drp = (DropDownList)pageSANPHAM.FindControl("drpDANHMUC");
            if (row["MADANHMUC"] != DBNull.Value)
            {
                ListItem item = drp.Items.FindByValue(row["MADANHMUC"].ToString());
                if (item != null) drp.SelectedValue = row["MADANHMUC"].ToString();
            }

            Literal lit = (Literal)pageSANPHAM.FindControl("litHINHANHHIENTAI");
            lit.Text = row["HINHANH"] == DBNull.Value ? "" : row["HINHANH"].ToString();
        }

        public void LamMoiForm()
        {
            ((TextBox)pageSANPHAM.FindControl("txtMASANPHAM")).Text = "";
            ((TextBox)pageSANPHAM.FindControl("txtTENSANPHAM")).Text = "";
            ((TextBox)pageSANPHAM.FindControl("txtDONGIA")).Text = "";
            ((TextBox)pageSANPHAM.FindControl("txtSOLUONG")).Text = "";
            ((TextBox)pageSANPHAM.FindControl("txtMOTA")).Text = "";
            ((Literal)pageSANPHAM.FindControl("litHINHANHHIENTAI")).Text = "";
        }

        public int InsertRecordSanPham()
        {
            int k = 0;
            try
            {
                String file = UploadAnh();
                object madanhmuc = ((DropDownList)pageSANPHAM.FindControl("drpDANHMUC")).SelectedValue;
                object tensanpham = ((TextBox)pageSANPHAM.FindControl("txtTENSANPHAM")).Text;
                object mota = ((TextBox)pageSANPHAM.FindControl("txtMOTA")).Text;
                object soluong = ((TextBox)pageSANPHAM.FindControl("txtSOLUONG")).Text;
                object dongia = ((TextBox)pageSANPHAM.FindControl("txtDONGIA")).Text;

                Dictionary<String, Object> list = new Dictionary<string, object>();
                list.Add("@TENSANPHAM", tensanpham);
                list.Add("@DONGIA", dongia);
                list.Add("@SOLUONG", soluong);
                list.Add("@HINHANH", file);
                list.Add("@MOTA", mota);
                list.Add("@MADANHMUC", madanhmuc);

                k = processdata.InsertRecord(list);
            }
            catch (Exception) { }
            return k;
        }

        public int UpdateRecordSanPham()
        {
            int k = 0;
            try
            {
                String file = UploadAnh();
                object masanpham = Convert.ToInt32(((TextBox)pageSANPHAM.FindControl("txtMASANPHAM")).Text);
                object madanhmuc = ((DropDownList)pageSANPHAM.FindControl("drpDANHMUC")).SelectedValue;
                object tensanpham = ((TextBox)pageSANPHAM.FindControl("txtTENSANPHAM")).Text;
                object mota = ((TextBox)pageSANPHAM.FindControl("txtMOTA")).Text;
                object soluong = ((TextBox)pageSANPHAM.FindControl("txtSOLUONG")).Text;
                object dongia = ((TextBox)pageSANPHAM.FindControl("txtDONGIA")).Text;

                // Nếu không chọn ảnh mới, giữ nguyên ảnh cũ (proc sẽ ISNULL lại nếu @HINHANH NULL)
                Dictionary<String, Object> list = new Dictionary<string, object>();
                list.Add("@MASANPHAM", masanpham);
                list.Add("@TENSANPHAM", tensanpham);
                list.Add("@DONGIA", dongia);
                list.Add("@SOLUONG", soluong);
                list.Add("@HINHANH", file);
                list.Add("@MOTA", mota);
                list.Add("@MADANHMUC", madanhmuc);

                k = processdata.UpdateRecord(list);
            }
            catch (Exception) { }
            return k;
        }

        public int DeleteRecordSanPham(int maSanPham)
        {
            return processdata.DeleteRecord(maSanPham);
        }
    }
}

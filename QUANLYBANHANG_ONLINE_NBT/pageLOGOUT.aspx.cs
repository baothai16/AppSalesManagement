using System;

namespace QUANLYBANHANG_ONLINE_NBT
{
    public partial class pageLOGOUT : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/DANHSACHSANPHAM.aspx");
        }
    }
}

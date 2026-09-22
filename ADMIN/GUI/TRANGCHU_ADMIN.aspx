<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TRANGCHU_ADMIN.aspx.cs" Inherits="QUANLYBANHANG_ONLINE_NBT.ADMIN.GUI.TRANGCHU_ADMIN" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Trang quản trị</title>
    <link rel="stylesheet" type="text/css" href="../../css/admin.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="admin-topbar">
            <div class="brand">⚙ Trang quản trị - electronix</div>
            <div>
                <a href="TRANGCHU_ADMIN.aspx">Dashboard</a>
                <a href="QUANLYDANHMUC_GUI.aspx">Danh mục</a>
                <a href="QUANLYSANPHAM_GUI.aspx">Sản phẩm</a>
                <a href="QUANLYDONHANG_GUI.aspx">Đơn hàng</a>
                <a href="../../DANHSACHSANPHAM.aspx">Xem website</a>
                <a href="../../pageLOGOUT.aspx">Đăng xuất</a>
            </div>
        </div>

        <div class="admin-container">
            <h2>Xin chào, <asp:Literal ID="litHoTen" runat="server" />!</h2>
            <p>Đây là trang quản trị hệ thống Quản Lý Bán Hàng Trực Tuyến.</p>

            <div class="admin-dashboard-cards">
                <a class="admin-card" href="QUANLYSANPHAM_GUI.aspx">
                    <span class="num"><asp:Literal ID="litSoSanPham" runat="server" Text="0" /></span>
                    Sản phẩm
                </a>
                <a class="admin-card" href="QUANLYDANHMUC_GUI.aspx">
                    <span class="num"><asp:Literal ID="litSoDanhMuc" runat="server" Text="0" /></span>
                    Danh mục
                </a>
                <a class="admin-card" href="QUANLYDONHANG_GUI.aspx">
                    <span class="num"><asp:Literal ID="litSoDonHang" runat="server" Text="0" /></span>
                    Đơn hàng
                </a>
            </div>
        </div>
    </form>
</body>
</html>

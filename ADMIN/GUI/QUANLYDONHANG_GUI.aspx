<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QUANLYDONHANG_GUI.aspx.cs" Inherits="QUANLYBANHANG_ONLINE_NBT.ADMIN.GUI.QUANLYDONHANG_GUI" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Quản lý đơn hàng</title>
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
            <h2>Danh sách đơn hàng</h2>
            <asp:GridView ID="grvDONHANG" runat="server" AutoGenerateColumns="false" CssClass="admin-grid" Width="100%"
                OnRowCommand="grvDONHANG_RowCommand" DataKeyNames="MADONHANG">
                <Columns>
                    <asp:BoundField DataField="MADONHANG" HeaderText="Mã ĐH" />
                    <asp:BoundField DataField="TENDANGNHAP" HeaderText="Tài khoản" />
                    <asp:BoundField DataField="HOTENNGUOINHAN" HeaderText="Người nhận" />
                    <asp:BoundField DataField="DIACHINHAN" HeaderText="Địa chỉ" />
                    <asp:BoundField DataField="DIENTHOAINHAN" HeaderText="Điện thoại" />
                    <asp:BoundField DataField="NGAYDAT" HeaderText="Ngày đặt" DataFormatString="{0:dd/MM/yyyy HH:mm}" />
                    <asp:BoundField DataField="TONGTIEN" HeaderText="Tổng tiền" DataFormatString="{0:0.##}$" />
                    <asp:BoundField DataField="TRANGTHAI" HeaderText="Trạng thái" />
                    <asp:TemplateField HeaderText="Thao tác">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkXem" runat="server" CommandName="XemChiTiet" CommandArgument='<%# Eval("MADONHANG") %>'>Xem chi tiết</asp:LinkButton>
                            &nbsp;|&nbsp;
                            <asp:LinkButton ID="lnkDaXuLy" runat="server" CommandName="CapNhatDaXuLy" CommandArgument='<%# Eval("MADONHANG") %>'>Đánh dấu đã xử lý</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <h2>Chi tiết đơn hàng #<asp:Label ID="lblMaDonHangDangXem" runat="server" Text="" /></h2>
            <asp:GridView ID="grvCHITIETDONHANG" runat="server" AutoGenerateColumns="false" CssClass="admin-grid" Width="100%">
                <Columns>
                    <asp:BoundField DataField="MASANPHAM" HeaderText="Mã SP" />
                    <asp:BoundField DataField="TENSANPHAM" HeaderText="Tên sản phẩm" />
                    <asp:BoundField DataField="SOLUONG" HeaderText="Số lượng" />
                    <asp:BoundField DataField="DONGIA" HeaderText="Đơn giá" DataFormatString="{0:0.##}$" />
                </Columns>
            </asp:GridView>

            <asp:Label ID="lblThongBao" runat="server" Font-Bold="true" ForeColor="Green"></asp:Label>
        </div>
    </form>
</body>
</html>

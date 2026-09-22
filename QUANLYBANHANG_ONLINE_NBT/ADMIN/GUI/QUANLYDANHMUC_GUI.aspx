<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QUANLYDANHMUC_GUI.aspx.cs" Inherits="QUANLYBANHANG_ONLINE_NBT.ADMIN.GUI.QUANLYDANHMUC_GUI" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Quản lý danh mục</title>
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
            <h2>Quản lý danh mục sản phẩm</h2>

            <table class="admin-form-table">
                <tr>
                    <td>Mã danh mục</td>
                    <td><asp:TextBox ID="txtMADANHMUC" runat="server" ReadOnly="true" Width="80px"></asp:TextBox> (tự sinh khi thêm mới)</td>
                </tr>
                <tr>
                    <td>Tên danh mục</td>
                    <td><asp:TextBox ID="txtTENDANHMUC" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Mô tả</td>
                    <td><asp:TextBox ID="txtMOTA" runat="server" TextMode="MultiLine" Rows="3"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnMakeNew" runat="server" Text="Làm mới / Thêm mới" CssClass="admin-btn" OnClick="btnMakeNew_Click" CausesValidation="false" />
                        <asp:Button ID="btnInsert" runat="server" Text="Lưu (Thêm)" CssClass="admin-btn" OnClick="btnInsert_Click" />
                        <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật" CssClass="admin-btn" OnClick="btnUpdate_Click" />
                        <asp:Label ID="lblThongBao" runat="server" Font-Bold="true" ForeColor="Green"></asp:Label>
                    </td>
                </tr>
            </table>

            <h2>Danh sách danh mục</h2>
            <asp:GridView ID="grvDANHMUC" runat="server" AutoGenerateColumns="false" CssClass="admin-grid" Width="100%"
                OnRowCommand="grvDANHMUC_RowCommand" DataKeyNames="MADANHMUC">
                <Columns>
                    <asp:BoundField DataField="MADANHMUC" HeaderText="Mã DM" />
                    <asp:BoundField DataField="TENDANHMUC" HeaderText="Tên danh mục" />
                    <asp:BoundField DataField="MOTA" HeaderText="Mô tả" />
                    <asp:TemplateField HeaderText="Thao tác">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkSua" runat="server" CommandName="SuaDanhMuc" CommandArgument='<%# Eval("MADANHMUC") %>'>Sửa</asp:LinkButton>
                            &nbsp;|&nbsp;
                            <asp:LinkButton ID="lnkXoa" runat="server" CommandName="XoaDanhMuc" CommandArgument='<%# Eval("MADANHMUC") %>' OnClientClick="return confirm('Bạn chắc chắn muốn xóa danh mục này?');">Xóa</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QUANLYSANPHAM_GUI.aspx.cs" Inherits="QUANLYBANHANG_ONLINE_NBT.ADMIN.GUI.QUANLYSANPHAM_GUI" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Quản lý sản phẩm</title>
    <link rel="stylesheet" type="text/css" href="../../css/admin.css" />
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
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
            <h2>Quản lý sản phẩm</h2>

            <table class="admin-form-table">
                <tr>
                    <td>Mã sản phẩm</td>
                    <td><asp:TextBox ID="txtMASANPHAM" runat="server" ReadOnly="true" Width="80px"></asp:TextBox> (tự sinh khi thêm mới)</td>
                </tr>
                <tr>
                    <td>Tên sản phẩm</td>
                    <td><asp:TextBox ID="txtTENSANPHAM" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Danh mục</td>
                    <td><asp:DropDownList ID="drpDANHMUC" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>Đơn giá</td>
                    <td><asp:TextBox ID="txtDONGIA" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Số lượng</td>
                    <td><asp:TextBox ID="txtSOLUONG" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Mô tả</td>
                    <td><asp:TextBox ID="txtMOTA" runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Hình ảnh</td>
                    <td>
                        <asp:FileUpload ID="FileANHSANPHAM" runat="server" /><br />
                        Ảnh hiện tại: <asp:Literal ID="litHINHANHHIENTAI" runat="server" />
                    </td>
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

            <h2>Danh sách sản phẩm</h2>
            <asp:GridView ID="grvSANPHAM" runat="server" AutoGenerateColumns="false" CssClass="admin-grid" Width="100%"
                OnRowCommand="grvSANPHAM_RowCommand" DataKeyNames="MASANPHAM">
                <Columns>
                    <asp:BoundField DataField="MASANPHAM" HeaderText="Mã SP" />
                    <asp:BoundField DataField="TENSANPHAM" HeaderText="Tên sản phẩm" />
                    <asp:BoundField DataField="DONGIA" HeaderText="Đơn giá" DataFormatString="{0:0.##}$" />
                    <asp:BoundField DataField="SOLUONG" HeaderText="Số lượng" />
                    <asp:TemplateField HeaderText="Hình ảnh">
                        <ItemTemplate>
                            <img src='<%# "../../images/" + Eval("HINHANH") %>' width="50" height="50" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Thao tác">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkSua" runat="server" CommandName="SuaSanPham" CommandArgument='<%# Eval("MASANPHAM") %>'>Sửa</asp:LinkButton>
                            &nbsp;|&nbsp;
                            <asp:LinkButton ID="lnkXoa" runat="server" CommandName="XoaSanPham" CommandArgument='<%# Eval("MASANPHAM") %>' OnClientClick="return confirm('Bạn chắc chắn muốn xóa sản phẩm này?');">Xóa</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>

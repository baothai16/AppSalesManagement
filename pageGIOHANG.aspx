<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageUser.Master" AutoEventWireup="true" CodeBehind="pageGIOHANG.aspx.cs" Inherits="QUANLYBANHANG_ONLINE_NBT.pageGIOHANG" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="center_title_bar">Giỏ hàng của bạn</div>

    <asp:GridView ID="grvCART" runat="server" AutoGenerateColumns="false" Width="100%"
        ShowFooter="true" EmptyDataText="Giỏ hàng trống." CssClass="cart-table"
        OnRowCommand="grvCART_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="Hình ảnh">
                <ItemTemplate>
                    <img src='images/<%# Eval("HINHANH") %>' width="60" height="60" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="TENSANPHAM" HeaderText="Tên sản phẩm" />
            <asp:BoundField DataField="DONGIA" HeaderText="Đơn giá" DataFormatString="{0:0.##}$" />
            <asp:BoundField DataField="SOLUONG" HeaderText="Số lượng" />
            <asp:BoundField DataField="THANHTIEN" HeaderText="Thành tiền" DataFormatString="{0:0.##}$" />
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkXoa" runat="server" CommandName="XoaSanPham" CommandArgument='<%# Eval("MASANPHAM") %>' OnClientClick="return confirm('Xóa sản phẩm này khỏi giỏ hàng?');">Xóa</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <div style="text-align:right; margin-top:10px; font-weight:bold;">
        Tổng cộng: <asp:Literal ID="litTongCong" runat="server" Text="0" />$
    </div>

    <div class="title_box" style="margin-top:20px;">Thông tin nhận hàng</div>
    <table style="width:100%;">
        <tr>
            <td style="width:150px;">Họ tên người nhận</td>
            <td><asp:TextBox ID="txtHOTENNGUOINHAN" runat="server" Width="300px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Địa chỉ nhận hàng</td>
            <td><asp:TextBox ID="txtDIACHINHAN" runat="server" Width="300px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Điện thoại</td>
            <td><asp:TextBox ID="txtDIENTHOAINHAN" runat="server" Width="300px"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnDatHang" runat="server" Text="Đặt hàng" OnClick="btnDatHang_Click" CssClass="details" />
                <asp:Button ID="btnXoaGioHang" runat="server" Text="Xóa toàn bộ giỏ hàng" OnClick="btnXoaGioHang_Click" CssClass="details" CausesValidation="false" />
            </td>
        </tr>
    </table>

    <asp:Label ID="lblThongBao" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
</asp:Content>

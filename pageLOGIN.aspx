<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageUser.Master" AutoEventWireup="true" CodeBehind="pageLOGIN.aspx.cs" Inherits="QUANLYBANHANG_ONLINE_NBT.pageLOGIN" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="center_title_bar">Đăng nhập</div>
    <div class="form_box">
        <table>
            <tr>
                <td class="form_label">Tên đăng nhập</td>
                <td><asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="form_label">Mật khẩu</td>
                <td><asp:TextBox ID="txtPassWord" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" class="form_action">
                    <asp:Button ID="btnLogin" runat="server" Text="Đăng Nhập" OnClick="btnLogin_Click" />
                    <asp:Label ID="lblLoi" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">Chưa có tài khoản? <a href="pageDANGKY.aspx">Đăng ký ngay</a></td>
            </tr>
        </table>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageUser.Master" AutoEventWireup="true" CodeBehind="pageDANGKY.aspx.cs" Inherits="QUANLYBANHANG_ONLINE_NBT.pageDANGKY" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="center_title_bar">Đăng ký tài khoản</div>
    <div class="form_box">
        <table>
            <tr>
                <td class="form_label">Tên đăng nhập</td>
                <td>
                    <asp:TextBox ID="txtTENDANGNHAP" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTDN" runat="server" ControlToValidate="txtTENDANGNHAP" ErrorMessage="Bắt buộc nhập" ForeColor="Red" />
                </td>
            </tr>
            <tr>
                <td class="form_label">Mật khẩu</td>
                <td>
                    <asp:TextBox ID="txtMATKHAU" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvMK" runat="server" ControlToValidate="txtMATKHAU" ErrorMessage="Bắt buộc nhập" ForeColor="Red" />
                </td>
            </tr>
            <tr>
                <td class="form_label">Nhập lại mật khẩu</td>
                <td>
                    <asp:TextBox ID="txtNHAPLAIMATKHAU" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:CompareValidator ID="cvMK" runat="server" ControlToValidate="txtNHAPLAIMATKHAU" ControlToCompare="txtMATKHAU" ErrorMessage="Mật khẩu không khớp" ForeColor="Red" />
                </td>
            </tr>
            <tr>
                <td class="form_label">Họ tên</td>
                <td><asp:TextBox ID="txtHOTEN" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="form_label">Email</td>
                <td><asp:TextBox ID="txtEMAIL" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="form_label">Điện thoại</td>
                <td><asp:TextBox ID="txtDIENTHOAI" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="form_label">Địa chỉ</td>
                <td><asp:TextBox ID="txtDIACHI" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" class="form_action">
                    <asp:Button ID="btnDangKy" runat="server" Text="Đăng Ký" OnClick="btnDangKy_Click"/>
                    <asp:Label ID="lblThongBao" runat="server" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">Đã có tài khoản? <a href="pageLOGIN.aspx">Đăng nhập</a></td>
            </tr>
        </table>
    </div>
</asp:Content>

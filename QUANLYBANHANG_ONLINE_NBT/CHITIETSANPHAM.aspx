<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageUser.Master" AutoEventWireup="true" CodeBehind="CHITIETSANPHAM.aspx.cs" Inherits="QUANLYBANHANG_ONLINE_NBT.CHITIETSANPHAM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="center_title_bar">Chi tiết sản phẩm</div>
    <asp:Repeater ID="rptCHITIET" runat="server">
        <ItemTemplate>
            <div class="prod_box" style="width:96%;">
                <div class="top_prod_box"></div>
                <div class="center_prod_box" style="display:flex;gap:20px;">
                    <div class="product_img">
                        <img src='images/<%# Eval("HINHANH") %>' alt="" border="0" width="220px" height="220px" />
                    </div>
                    <div style="flex:1;">
                        <div class="product_title" style="font-size:18px;"><%# Eval("TENSANPHAM") %></div>
                        <div class="prod_price"><span class="price"><%# Eval("DONGIA") %>$</span></div>
                        <p><b>Số lượng còn lại:</b> <%# Eval("SOLUONG") %></p>
                        <p><b>Mô tả:</b><br /><%# Eval("MOTA") %></p>

                        <asp:HiddenField ID="hdfMASANPHAM" runat="server" Value='<%# Eval("MASANPHAM") %>' />
                        <asp:HiddenField ID="hdfTENSANPHAM" runat="server" Value='<%# Eval("TENSANPHAM") %>' />
                        <asp:HiddenField ID="hdfHINHANH" runat="server" Value='<%# Eval("HINHANH") %>' />
                        <asp:HiddenField ID="hdfDONGIA" runat="server" Value='<%# Eval("DONGIA") %>' />

                        Số lượng:
                        <asp:TextBox ID="txtSOLUONGMUA" runat="server" Text="1" Width="50px"></asp:TextBox>
                        <asp:Button ID="btnThemGioHang" runat="server" Text="Thêm vào giỏ hàng" OnClick="btnThemGioHang_Click" CssClass="details" />
                    </div>
                </div>
                <div class="bottom_prod_box"></div>
            </div>
        </ItemTemplate>
    </asp:Repeater>

    <asp:Label ID="lblThongBao" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>

    <div style="margin-top:10px;">
        <a href="DANHSACHSANPHAM.aspx">&laquo; Quay lại danh sách sản phẩm</a>
    </div>
</asp:Content>

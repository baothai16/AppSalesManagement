<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageUser.Master" AutoEventWireup="true" CodeBehind="DANHSACHSANPHAM.aspx.cs" Inherits="QUANLYBANHANG_ONLINE_NBT.DANHSACHSANPHAM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="DataList1" runat="server" OnSelectedIndexChanged="DataList1_SelectedIndexChanged" Width="562px">
        <ItemTemplate>
            <div class="prod_box">
                <div class="top_prod_box"></div>
                <div class="center_prod_box">
                    <div class="product_title"><a href="chitietsanpham.aspx?MASANPHAM=<%# Eval("MASANPHAM") %>"><%# Eval("TENSANPHAM") %></a></div>
                    <div class="product_img">
                        <a href="chitietsanpham.aspx?MASANPHAM=<%# Eval("MASANPHAM") %>">
                            <img src="images/<%# Eval("HINHANH") %>" alt="" border="0" width="100px" height="100px" />
                        </a>
                    </div>
                    <div class="prod_price"><span class="price"><%# Eval("DONGIA") %>$</span></div>
                </div>
                <div class="bottom_prod_box"></div>
                <div class="prod_details_tab">
                    <a href="chitietsanpham.aspx?MASANPHAM=<%# Eval("MASANPHAM") %>" class="prod_details">details</a>
                </div>
            </div>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
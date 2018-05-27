<%@ Page Title="" Language="C#" MasterPageFile="~/SubAdminMaster.Master" AutoEventWireup="true" CodeBehind="SubAdminHome.aspx.cs" Inherits="Diocese.SubAdminHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div style="margin-top:10px;"><b> WELCOME <asp:Label ID="LBLsubadminname" runat="server" Text="Label" ></asp:Label></b></div>
     <a style="margin-left:90%;"><b><asp:Button ID="logout" runat="server" Text="LOGOUT"  OnClick="logout_Click" style="background-color:antiquewhite;border:groove" /></b></a>

    </asp:Content>

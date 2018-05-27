<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminMaster.Master" AutoEventWireup="true" CodeBehind="Superadminhome.aspx.cs" Inherits="Diocese.Superadminhome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- Page Content -->
        <div id="page-wrapper">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header"> WELCOME <asp:Label ID="Lblname" runat="server" Text="Label"></asp:Label></h1>
                         <a style="margin-left:90%;"><b><asp:Button ID="logout" runat="server" Text="LOGOUT"  OnClick="logout_Click" style="background-color:antiquewhite;border:groove" /></b></a>

                    </div>
                    <!-- /.col-lg-12 -->
                </div>
                <!-- /.row -->
            </div>
            <!-- /.container-fluid -->
        </div>
        <!-- /#page-wrapper -->
</asp:Content>

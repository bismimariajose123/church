<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdminMaster.Master" AutoEventWireup="true" CodeBehind="ViewSubAdmin.aspx.cs" Inherits="Diocese.ViewSubAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     
      <!-- Page Content -->
        <div id="page-wrapper">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header"> WELCOME <asp:Label ID="Lblname" runat="server" Text="Label"></asp:Label></h1>
                    </div>
                    <!-- /.col-lg-12 -->
                </div>
                <!-- /.row -->
                             Search by Column <div style="width:20%">
                              <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                <br />
                     Select Entries:
                         <div class="dropdown">
                             <asp:DropDownList ID="DropDownList1" runat="server"  CssClass="btn btn-primary dropdown-toggle" data-toggle="dropdown"> 
                       <asp:ListItem Selected="True" Text="--Select--" Value="--Select--"></asp:ListItem>
                          <asp:ListItem Text="10" Value="10"></asp:ListItem>
                          <asp:ListItem Text="25" Value="20"></asp:ListItem>
                        <asp:ListItem Text="50" Value="10"></asp:ListItem>
                          <asp:ListItem Text="100" Value="20"></asp:ListItem>
                        <asp:ListItem Text="All" Value="All"></asp:ListItem>
                       </asp:DropDownList>
                        </div>
                  
                            <!-- /input-group -->
               
                    <asp:gridview runat="server" CellPadding="3" ForeColor="Black" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Width="248px">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:gridview>
                </div>
            </div>
            <!-- /.container-fluid -->
        
        <!-- /#page-wrapper -->
</asp:Content>

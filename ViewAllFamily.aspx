﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SubAdminMaster.Master" AutoEventWireup="true" CodeBehind="ViewAllFamily.aspx.cs" Inherits="Diocese.ViewAllFamily" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div style="margin-left:10%;margin-top:10px">

  <%-- -------- search & user info start--%>
    
        <label style="color:white">Search by Column </label> <div style="width:20%">
                                 <table>
                                     <tr>
                                         <th><asp:TextBox ID="TBsearch" runat="server" CssClass="form-control search">

                                   </asp:TextBox></th>
                                         <th>
                                       <asp:ImageButton ID="Imgbtnsearch" runat="server" OnClick="Imgbtnsearch_Click"
                                           ImageUrl="~/images/search.png" Width="20px"/></th>
                                     </tr>
                                  
                                 </table>
                             
                              </div>
        
                      <br />
      
                    <label style="color:white"> Select Entries:</label>
                         <div class="dropdown">
                             <asp:DropDownList ID="DDLPagesize" runat="server" 
                          OnSelectedIndexChanged="DDLPagesize_SelectedIndexChanged" AutoPostBack="true"> 
                       <asp:ListItem Selected="True" Text="--Select--" Value="--"></asp:ListItem>
                          <asp:ListItem Text="2" Value="2"></asp:ListItem>
                          <asp:ListItem Text="10" Value="10"></asp:ListItem>
                          <asp:ListItem Text="25" Value="20"></asp:ListItem>
                        <asp:ListItem Text="50" Value="10"></asp:ListItem>
                          <asp:ListItem Text="100" Value="20"></asp:ListItem>
                        <asp:ListItem Text="All" Value="All"></asp:ListItem>
                       </asp:DropDownList>
                        </div>


       <div style="margin-top:30px">

       <asp:GridView runat="server" iD="GVFamilyDetails"
        AutoGenerateColumns="False" 
        DataKeyNames="Family_ID" BackColor="White" BorderColor="#3366CC" BorderStyle="None" 
        BorderWidth="1px" CellPadding="4" width="900px" AutoGenerateDeleteButton="True" 
          onrowdeleting="GVFamilyDetails_RowDeleting"    
         AllowPaging="true" OnPageIndexChanging="GVFamilyDetails_PageIndexChanging">
            <Columns>
            
             <asp:TemplateField HeaderText="Family Name" SortExpression="FamilyName">
                 <ItemTemplate>
                    <asp:Label ID="LBLFamilyName" runat="server" Text='<%# Bind("FamilyName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:BoundField DataField="HeadName" HeaderText="Head Name" SortExpression="HeadName" />

            <asp:TemplateField HeaderText="Ward Name" SortExpression="Ward_id" >
                <ItemTemplate>
                     <asp:Label ID="LBLWardName" runat="server" Text='<%# Bind("WardName") %>'></asp:Label>              
                </ItemTemplate>
            </asp:TemplateField>
             <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
            <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
            <asp:BoundField DataField="FamilyNo" HeaderText="FamilyNo" SortExpression="FamilyNo" />
            <asp:BoundField DataField="Contact_No" HeaderText="Contact_No" SortExpression="Contact_No" />
           
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
       </asp:GridView>
            </div>
            </div>
   

    </asp:Content>

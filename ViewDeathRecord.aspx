<%@ Page Title="" Language="C#" MasterPageFile="~/SubAdminMaster.Master" AutoEventWireup="true" CodeBehind="ViewDeathRecord.aspx.cs" Inherits="Diocese.ViewDeathRecord" %>
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
    <asp:GridView ID="GVDeathTable" runat="server" AutoGenerateColumns="False" BackColor="White" 
        
        AllowPaging="True" OnPageIndexChanging="GVDeathTable_PageIndexChanging" OnRowDataBound="GVDeathTable_RowDataBound"
               
        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="Death_ID" 
        Width="578px" GridLines="Vertical"  >
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
             <asp:TemplateField HeaderText="FamilyName" SortExpression="FamilyName">
               
                <ItemTemplate>
                    <asp:Label ID="LBLFamilyName" runat="server" Text='<%# Bind("FamilyName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
          
            <asp:TemplateField HeaderText="OfficialName" SortExpression="OfficialName">
               
                <ItemTemplate>
                    <asp:Label ID="LBLOfficialName" runat="server" Text='<%# Bind("OfficialName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DO_Death" SortExpression="DO_Death">
                
                <ItemTemplate>
                    <asp:Label ID="LBLDO_Death" runat="server" Text='<%# Bind("DO_Death") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Do_Funeral" SortExpression="Do_Funeral">
                
                <ItemTemplate>
                    <asp:Label ID="LBLDo_Funeral" runat="server" Text='<%# Bind("Do_Funeral") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="FuneralTime" SortExpression="FuneralTime">
                
                <ItemTemplate>
                    <asp:Label ID="LBLFuneralTime" runat="server" Text='<%# Bind("FuneralTime") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
         
        </Columns>
        
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
        
    </asp:GridView>
           
            </div>
            </div>
   



</asp:Content>

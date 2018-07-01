<%@ Page Title="" Language="C#" MasterPageFile="~/SubAdminMaster.Master" AutoEventWireup="true" CodeBehind="SubAdminHallRequest.aspx.cs" Inherits="Diocese.SubAdminHallRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div style="margin-top:5px">
                       <table>
                        <tr>
                         <th style="padding-right:100px">
                        <b style="color:cadetblue"> Select Event </b>
                         </th>
                         <th  style="padding-right:70px"> <b style="color:cadetblue"> Request Date</b> </th> 
                        
                         
                       <tr>
                           <th><asp:DropDownList ID="DDlEventName" Width="150px" Height="45px" runat="server" AppendDataBoundItems="True" style="font-family:'Times New Roman', Times, serif;font-size:10px" >
                        <asp:ListItem Value="0" Text="--select--" ></asp:ListItem>
                         </asp:DropDownList></th>
                       <th> <input type="date" class="form-control1 ng-invalid ng-invalid-required" id="orddate" ng-model="model.date" onchange="date_dis()">
                      <asp:hiddenfield ID="Dobhidden" runat="server"></asp:hiddenfield>
                       </th>
                        <th><asp:Button  ID="BtnSearch" runat="server"  Text="Search" OnClick="BtnSearch_Click"/></th>
                          
                           </tr>
                                   
                    </table>
                    </div>        
                    Select Entries:
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
    

    <asp:GridView ID="GVHall" AutoGenerateColumns="False" runat="server" DataKeyNames="HallRequestId"  AutoGenerateEditButton="True"
        onrowcancelingedit="GVHall_RowCancelingEdit"   width="1000px"
        onrowediting="GVHall_RowEditing" onrowupdating="GVHall_RowUpdating" AllowPaging="true" 
        OnPageIndexChanging="GVHall_PageIndexChanging"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowDataBound="GVHall_RowDataBound" >
       
        <Columns>
            
            <asp:TemplateField HeaderText="UserType" SortExpression="UserType">
               
                <ItemTemplate>
                    <asp:Label ID="Lblusertype" runat="server" Text='<%# Bind("UserType") %>' Visible="false"></asp:Label>
                     <asp:Label ID="Lbluser" runat="server"></asp:Label>

                </ItemTemplate>
            </asp:TemplateField>
           
            <asp:TemplateField HeaderText="EventName" SortExpression="EventName">
               
                <ItemTemplate>
                    <asp:Label ID="LblEventname" runat="server" Text='<%# Bind("EventName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Hall Name" SortExpression="HallName">
               
                <ItemTemplate>
                    <asp:Label ID="LblHall" runat="server" Text='<%# Bind("HallName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Official Name" SortExpression="OfficialName">
               
                <ItemTemplate>
                    <asp:Label ID="LblOfficialName" runat="server" Text='<%# Bind("OfficialName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="RequestDate" SortExpression="RequestDate">
                <ItemTemplate>
                    <asp:Label ID="LblRequestDate" runat="server" Text='<%# Bind("RequestDate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Amount Paid" SortExpression="Amount Paid">
                <ItemTemplate>
                    <asp:Label ID="LblAmountPaid" runat="server" Text='<%# Bind("IsPaid") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Status" SortExpression="Status">
               <EditItemTemplate>
                                      <asp:DropDownList ID="DropDownListStatus" runat="server" Height="27px" Width="177px" AppendDataBoundItems="true">
                                          <asp:ListItem Value="0">----Select----</asp:ListItem>
                                          <asp:ListItem Value="1">Request</asp:ListItem>
                                          <asp:ListItem Value="2">Approved</asp:ListItem>
                                          <asp:ListItem Value="3">Rejected</asp:ListItem>
                                      </asp:DropDownList>
                                  </EditItemTemplate>

                <ItemTemplate>
                    <asp:Label ID="LblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="Description">
                <EditItemTemplate>
                    <asp:TextBox runat="server" ID="TBDescription" Text='<%# Bind("Description") %>'> </asp:TextBox>
                    </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="LblDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>


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
     <script type="text/javascript">

        function date_dis()
        {
            var textbox = document.getElementById('orddate');
            document.getElementById('<%=Dobhidden.ClientID%>').value = textbox.value;
            alert(textbox.value);

         }

        
          
         </script>
   </asp:Content>

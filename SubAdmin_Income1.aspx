<%@ Page Title="" Language="C#" MasterPageFile="~/SubAdminMaster.Master" AutoEventWireup="true" CodeBehind="SubAdmin_Income1.aspx.cs" Inherits="Diocese.SubAdmin_Income1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- Page Content -->
      <div style="margin-top:10px;"><b> WELCOME <asp:Label ID="LBLsubadminname" runat="server" Text="Label" ></asp:Label></b></div>
 <br /><br />
        <div id="page-wrapper">
            <div class="container-fluid">
                <div class="row">
                    
                    <!-- /.col-lg-12 -->
                </div>
                <!-- /.row -->
                             <b>Search by Column Names Like </b><b style="color:aquamarine">Family Name or Official Name</b>
               
                <div style="width:20%">
                                 <table>
                                     <tr style="padding-right:10px">
                                         <th><asp:TextBox ID="TBsearch" runat="server" CssClass="form-control">

                                   </asp:TextBox>
                                             
                                         </th>

                                         <th>
                                       <asp:ImageButton ID="Imgbtnsearch" runat="server" OnClick="Imgbtnsearch_Click" 
                                           ImageUrl="~/images/search.png" Width="20px"/></th>
                                     </tr>
                                     
                       
                                     </table>
                            
                 </div>
                <br />
                <br />
                 
                <div style="margin-top:5px">
                  <table>
                        <tr>
                         <th style="padding-right:70px">
                        <b style="color:cadetblue"> Select Event </b>
                         </th>
                         <th  style="padding-right:70px"> <b style="color:cadetblue"> Search by Date: From </b> </th> 
                         <th> &nbsp;  &nbsp;<b style="color:cadetblue">To</b></th>
                         
                       <tr>
                           <th style="padding-right:3px"><asp:DropDownList ID="DDleventid" Width="160px"  runat="server" AppendDataBoundItems="True" >
                                 <asp:ListItem Value="0">--select--</asp:ListItem>
                                </asp:DropDownList>
                               
         
                           </th>
                       <th> 
                           <input type="date" class="form-control1 ng-invalid ng-invalid-required" id="orddate" ng-model="model.date" onchange="date_dis()">
                            <asp:hiddenfield ID="Dobhidden" runat="server"></asp:hiddenfield>
                       </th>
                       <th style="padding-right:70px">  &nbsp;  &nbsp;
                           <input type="date" class="form-control1 ng-invalid ng-invalid-required" id="orddate1" ng-model="model.date" onchange="date_dis1()">
                       <asp:hiddenfield ID="Dobhidden1" runat="server"></asp:hiddenfield></th>
                     
                          
                           <th style="padding-right:5px">
                               <asp:Button ID="BTN_Search" runat="server" Text="Search" OnClick="BTN_Search_Click" />  <%--//original--%>
                           </th>
                           <th><asp:Button  ID="BtnConvertPdf" runat="server"  Text="Generate Report" OnClick="BtnConvertPdf_Click"/></th>
                           </tr>
                                   
                    </table>
                    </div>
                  
                <br />
                    
                       

                    <asp:Gridview runat="server" ID="GVIncomeTable" CellPadding="3" ForeColor="Black" GridLines="Vertical" BackColor="White" 
                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Width="900px"  AutoGenerateColumns="False" 
                         DataKeyNames="DonationId"    OnRowDataBound="GVIncomeTable_RowDataBound"
                      AllowPaging="True"  Visible="false" Height="291px">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <Columns>
                                 
                            <asp:BoundField HeaderText="Family Name" SortExpression="Family Name" DataField="FamilyName">
                                
                              <%-- <ItemTemplate>
                                    <asp:Label ID="LblFamilyName" runat="server" Text='<%# Bind("FamilyName") %>'></asp:Label>
                                    <asp:Label ID="LblToParishid" runat="server" Text='<%# Bind("ToParishid") %>' Visible="false"></asp:Label>
                             <asp:Label ID="Label9" runat="server" Text='<%# Bind("Memberid") %>' Visible="false"></asp:Label>
                               <asp:Label ID="LblDonationId" runat="server" Text='<%# Bind("DonationId") %>' Visible="false"></asp:Label>
                              <asp:Label ID="LblIsParishMember" runat="server" Text='<%# Bind("IsParishMember") %>' Visible="false"></asp:Label>
                               
                                </ItemTemplate>--%>
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Parish Name" SortExpression="Persons_ParishName" DataField="Persons_ParishName">
                              <%--  
                                <ItemTemplate>
                                    <asp:Label ID="LblPersons_ParishName" runat="server" Text='<%# Bind("Persons_ParishName") %>'></asp:Label>
                                </ItemTemplate>--%>
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Official Name" SortExpression="OfficialName" DataField="OfficialName">
                               
                               <%-- <ItemTemplate>
                                    <asp:Label ID="LblOfficialName" runat="server" Text='<%# Bind("OfficialName") %>'></asp:Label>
                                </ItemTemplate>--%>
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Contact No" SortExpression="ContactNo" DataField="ContactNo">
                               
                               <%-- <ItemTemplate>
                                    <asp:Label ID="LblContactNo" runat="server" Text='<%# Bind("ContactNo") %>'></asp:Label>
                                </ItemTemplate>--%>
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Diocese" SortExpression="Diocese" DataField="Diocese">
                               
                               <%-- <ItemTemplate>
                                    <asp:Label ID="LblDiocese" runat="server" Text='<%# Bind("Diocese") %>'></asp:Label>
                                </ItemTemplate>--%>
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Event    " SortExpression="EventName" DataField="EventName">
                               
                                <%--<ItemTemplate>
                                    <asp:Label ID="LblEventName" runat="server" Text='<%# Bind("EventName") %>'></asp:Label>
                                </ItemTemplate>--%>
                            </asp:BoundField>
                            
                            <asp:BoundField HeaderText="Amount" SortExpression="Amount" DataField="Amount">
                               
                               <%-- <ItemTemplate>
                                    <asp:Label ID="LblAmount" runat="server" Text='<%# Bind("Amount") %>'></asp:Label>
                                </ItemTemplate>--%>
                            </asp:BoundField>
                            <asp:TemplateField  HeaderText="Date Received" SortExpression="AmountReceivedDate">
                                 <ItemTemplate>
                                    <asp:Label ID="LblAmountReceivedDate" runat="server" Text='<%# Bind("AmountReceivedDate") %>'></asp:Label>
                                </ItemTemplate>

                            </asp:TemplateField>
    
                            
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:Gridview>
                          <div style="margin-left:467px;margin-bottom:10px"> <b style="color:chocolate">
                        <asp:Label ID="LblTotalAmt" runat="server" Visible="false" Text="Total amount=">

                   </asp:Label>  </b><b style="color:aquamarine"> <asp:Label ID="LblTotalIncome" runat="server"  Visible="false"></asp:Label></b>
           </div>
                     <!-- /.container-fluid -->
        
        <!-- /#page-wrapper -->

                <div style="margin-top:10px">
                    <b style="color:aqua"><asp:Label ID="EventNameSundaycollection" runat="server" Text="Sunday Collection" Visible="false"></asp:Label> </b>
                <asp:GridView ID="GVSundayCollection" runat="server" AutoGenerateColumns="False" Visible="false" OnRowDataBound="GVSundayCollection_RowDataBound" DataKeyNames="Collection_SundayId" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="264px" >
                    <Columns>
                         <asp:BoundField HeaderText="Amount" SortExpression="Amount" DataField="Amount">
                             <%--<ItemTemplate>
                                <asp:Label ID="LBLAmount" runat="server" Text='<%# Bind("Amount") %>'></asp:Label>
                            </ItemTemplate>--%>
                        </asp:BoundField>
                        <asp:TemplateField>
                              <ItemTemplate>
                                <asp:Label ID="LBLDate" runat="server" Text='<%# Bind("SundayCollectionDate") %>'></asp:Label>
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

                      <div style="margin-left:70px;margin-bottom:10px"> <b style="color:chocolate"> <asp:Label runat="server" id="LabelTotal" Text="Total amount=" Visible="false"></asp:Label> </b><b style="color:aquamarine"> <asp:Label ID="LblSunday" runat="server"  Visible="false"></asp:Label></b>
           </div>
                    </div>

                  
                    </div>
               
            </div>
     <script type="text/javascript">

        function date_dis()
        {
            var textbox = document.getElementById('orddate');
            document.getElementById('<%=Dobhidden.ClientID%>').value = textbox.value;
            alert(textbox.value);

         }

         function date_dis1() {
            
            var textbox1 = document.getElementById('orddate1');
            document.getElementById('<%=Dobhidden1.ClientID%>').value = textbox1.value;
            alert(textbox1.value);

        }
          
         </script>

</asp:Content>

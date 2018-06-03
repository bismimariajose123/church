<%@ Page Title="" Language="C#" MasterPageFile="~/SubAdminMaster.Master" AutoEventWireup="true" CodeBehind="SubAdminExpense.aspx.cs" Inherits="Diocese.SubAdminExpense" %>
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

               <div class="reg-w3">  <%--FORM--%>
                  <div class="w3layouts-main">
	              <h2>ADD EXPENSE</h2>
	           	<div>
                  <label for="uname"><b>Money Taken From</b></label>
                   <%-- input in loginform.css--%>
			     
              <asp:DropDownList ID="DDlExpReason" runat="server" CssClass="input" AppendDataBoundItems="true">
                  <asp:ListItem Value="0">--select--</asp:ListItem>
              </asp:DropDownList>


				 <div class="clearfix"></div>
                       <label for="uname"><b>Amount</b></label>
                  
                  <asp:TextBox ID="TBExpAmount" runat="server" CssClass="input"></asp:TextBox>
            
				  <div class="clearfix"></div>
                        <label for="uname"><b>Reason</b></label>
                  
                  <asp:TextBox ID="TBReason" runat="server" CssClass="input"></asp:TextBox>
            
				  <div class="clearfix"></div>
			     <%--buttonregform in subadmin/style.css--%>
                 <asp:Button ID="BtnAddExpense" runat="server" Text="ADD"  CssClass="buttonregform" OnClick="BtnAddExpense_Click"/>
	     	     </div>		
             </div>
            </div>   
                <%--/FORM--%>


                            
                
            
                
                <div style="margin-top:5px">
                  <table>
                        <tr>
                         <th style="padding-right:70px">
                        <b style="color:cadetblue"> Select Event </b>
                         </th>
                         <th  style="padding-right:70px"> <b style="color:cadetblue"> Search by Date: From </b> </th> 
                         <th> &nbsp;  &nbsp;<b style="color:cadetblue">To</b></th>
                         
                       <tr>
                           <th ><asp:DropDownList ID="DDlExpenseEvent" Width="130px" Height="28px"  runat="server" AppendDataBoundItems="True" >
                        <asp:ListItem Value="0">--select--</asp:ListItem>
                         </asp:DropDownList></th>
                       <th> <input type="date" class="form-control1 ng-invalid ng-invalid-required" id="orddate" ng-model="model.date" onchange="date_dis()">
                      <asp:hiddenfield ID="Dobhidden" runat="server"></asp:hiddenfield>
                       </th>
                       <th style="padding-right:70px">  &nbsp;  &nbsp; <input type="date" class="form-control1 ng-invalid ng-invalid-required" id="orddate1" ng-model="model.date" onchange="date_dis1()">
                       <asp:hiddenfield ID="Dobhidden1" runat="server"></asp:hiddenfield></th>
                     <th><asp:Button  ID="BtnSearch" runat="server"  Text="Search"/></th>
                           </tr>
                                   
                    </table>
                    </div>
                
               
                
                <br />
                   
              <div style="margin-top:15px">
                  
                   <b style="color:cadetblue">Select Entries:</b> 
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
                      
                     </div>    <!-- /input-group -->
                     

                    <asp:gridview runat="server" ID="GVIncomeTable" CellPadding="3" ForeColor="Black" GridLines="Vertical" BackColor="White" 
                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Width="356px" AutoGenerateColumns="False"
                         DataKeyNames="ExpenseId"   
                      AllowPaging="True" OnPageIndexChanging="GVIncomeTable_PageIndexChanging">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                                                       
                               
                        <Columns>
                             <asp:TemplateField HeaderText="Amount" SortExpression="Expense_Amount">
                               
                                <ItemTemplate>
                                    <asp:Label ID="LblAmount" runat="server" Text='<%# Bind("Expense_Amount") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Date" SortExpression="Exp_date">
                               
                                <ItemTemplate>
                                    <asp:Label ID="LblDateExpense" runat="server" Text='<%# Bind("Exp_date") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Event Name" SortExpression="EventName">
                               
                                <ItemTemplate>
                                    <asp:Label ID="LblEventName" runat="server" Text='<%# Bind("EventName") %>'></asp:Label>
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
                    </asp:gridview>
                          
                       <asp:SqlDataSource ID="ExpenseDB" runat="server" ConnectionString="<%$ ConnectionStrings:MyConnection %>" SelectCommand="SELECT * FROM [ExpenseTable]"></asp:SqlDataSource>
                          
                       <b> Total amount= </b><b style="color:aquamarine"> <asp:Label ID="LblTotalIncome" runat="server" ></asp:Label></b>
            <!-- /.container-fluid -->
        
        <!-- /#page-wrapper -->
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

<%@ Page Title="" Language="C#" MasterPageFile="~/SimpleFormsMaster.Master" AutoEventWireup="true" CodeBehind="ViewFamilyMembers.aspx.cs" Inherits="Diocese.ViewFamilyMembers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:LinkButton ID="LnkbtnHome" runat="server" OnClick="LnkbtnHome_Click">Back to Home</asp:LinkButton>
    <br />
    <%-- Search by Column <div style="width:20%">
                                 <table>
                                     <tr>
                                         <th>   <th>
                                       <asp:ImageButton ID="Imgbtnsearch" runat="server" OnClick="Imgbtnsearch_Click" ImageUrl="~/images/search.png" Width="20px"/></th>
                                     
                                         <th>
                                             <label for="psw"><b>Image</b></label>
                                         </th>
                                         </tr>
                                     <tr>
                                         <th>
                                          <asp:FileUpload ID="FileUploadimg" runat="server" />
                                         </th></tr>
                                                                       
            
                                 </table>
                              
                              </div>--%>
    
    <div>
        <table>
            <tr>
                <th> Search by Official Name</th>
                <th><asp:TextBox ID="TBsearch" runat="server" CssClass="form-control" ></asp:TextBox></th>
           
                <th><asp:ImageButton ID="Imgbtnsearch" runat="server" OnClick="Imgbtnsearch_Click" ImageUrl="~/images/search.png" Width="20px"/></th>
            </tr>
            <tr>             
            <th><label for="psw"><b>upload Image</b></label></th> 
                <th> <asp:FileUpload ID="FileUploadimg" runat="server" /></th>
                <th style="padding-top:20px"><asp:DropDownList runat="server" ID="DDLMemberName" AppendDataBoundItems="true" style="Width:200px;Height:45px;font-size:9px">
                    <asp:ListItem Value="0" Text="--select member name---"></asp:ListItem>
                  
                    </asp:DropDownList></th><th style="padding-left:10px"><asp:Button id="BtnUpdateimage" runat="server" Text="UPDATE" OnClick="BtnUpdateimage_Click"/></th>
            </tr>

        </table>
    </div>

     <table>
     <asp:Panel ID="PanelImage" runat="server">
            <asp:ListView ID="ListView1" runat="server" OnItemDataBound="ListView1_ItemDataBound" DataKeyNames="Member_ID">
                <ItemTemplate>
                   
                        <tr>
                            <th>
                               <asp:ImageButton ID="Member_Image" runat="server"  CssClass="image"  ImageUrl='<%# Bind("ImagePath") %>'   /> 
                            </th>

                        
                        <th>
                            <ul style="list-style:none">
                                <li>
                                    Official Name: <asp:Label ID="LBlName" runat="server" Text='<%# Bind("OfficialName") %>'></asp:Label>
                                </li>
                                <li>Baptism Name:(<asp:Label ID="LBLBapname" runat="server" Text='<%# Bind("BaptismName") %>'></asp:Label>)</li>
                          <li>
                               Family Name:<asp:Label ID="LBLFamilyName" runat="server" Text='<%# Bind("NativeFamilyName") %>'></asp:Label>
                         
                          </li>
                                  <li>
                               Date of Birth:<asp:Label ID="LblDob" runat="server" Text='<%# Bind("DOB") %>'></asp:Label>
                         
                          </li>
                                <li>
                                 Parish Name:<asp:Label ID="LBLNativeParish" runat="server" Text='<%# Bind("NativeParishName") %>'></asp:Label>
                                </li>
                                
                                    <asp:HiddenField ID="LBLBap" runat="server" value= '<%#Eval("BaptismId") %>'></asp:HiddenField>
                                    <asp:HiddenField ID="LBLMar" runat="server" value='<%#Eval("Marriageid") %>'></asp:HiddenField>
                                    <asp:HiddenField ID="LBLMatSts" runat="server" value='<%#Eval("MarriesStatus") %>'></asp:HiddenField>
                                    <asp:HiddenField ID="LBLRegsts" runat="server" value='<%#Eval("RegisteredStatus") %>'></asp:HiddenField>
                                  
                                
                              
                              <li>
                                    <asp:LinkButton ID="LnkBap" runat="server" Visible="false"  CommandArgument='<%#Eval("Member_ID")%>' CommandName="Baptism" >Baptism Form</asp:LinkButton>
                                    <asp:Label ID="LBLmemberid" runat="server" value= '<%#Eval("Member_ID") %>' Visible="false"></asp:Label>
                                </li>
                                <li><asp:LinkButton ID="LnkMarriage" runat="server" Visible="false"  CommandArgument='<%#Eval("Member_ID")%>' CommandName="Marriage" OnCommand="LnkMarriage_Command">Marriage Form</asp:LinkButton></li>
                              
                            
                                 
                             
                            </ul>
                           
                           
                            
                        </th>
                       
                   </tr>
                     </ItemTemplate>
                
                
               
            </asp:ListView>
            
        </asp:Panel>
         </table>
</asp:Content>

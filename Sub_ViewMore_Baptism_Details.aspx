<%@ Page Title="" Language="C#" MasterPageFile="~/SimpleFormsMaster.Master" AutoEventWireup="true" CodeBehind="Sub_ViewMore_Baptism_Details.aspx.cs" Inherits="Diocese.Sub_ViewMoreDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Button  Text="Back To Previous" ID="Previous" OnClick="Previous_Click" runat="server"/>

     <table>
     <asp:Panel ID="PanelImage" runat="server">
            <asp:ListView ID="ListView1" runat="server" OnItemDataBound="ListView1_ItemDataBound"  DataKeyNames="Memberid">
                <ItemTemplate>
                   
                        <tr>
                           
                        <th>
                            <ul style="list-style:none">
                                <li>
                                    Official Name: <asp:Label ID="LBlName" runat="server" Text='<%# Bind("OfficialName") %>'></asp:Label>
                                </li>
                                <li>Baptism Name:(<asp:Label ID="LBLBapname" runat="server" Text='<%# Bind("BaptismName") %>'></asp:Label>)</li>
                          <li>
                               Family Name:<asp:Label ID="LBLFamilyName" runat="server" Text='<%# Bind("FamilyName") %>'></asp:Label>
                         
                          </li>
                                <li>
                                Native Parish :<asp:Label ID="LBLNativeParish" runat="server" Text='<%# Bind("PersonParishName") %>'></asp:Label>
                                </li>
                                <li>
                               Father's Name:<asp:Label ID="LBLFathername" runat="server" Text='<%# Bind("FatherName") %>'></asp:Label>

                                </li>
                                
                                  <li>
                                  Mother's Name:<asp:Label ID="LBLMothername" runat="server" Text='<%# Bind("MotherName") %>'></asp:Label>

                                </li>
                                  <li>
                                      Celebrant Name:<asp:Label ID="LBLCelebrant" runat="server" Text='<%# Bind("Celebrant") %>'></asp:Label>

                                </li>
                                  
                                
                              
                              <li id="GF" runat="server" Visible="false">
                                   GodFather's Proof:<asp:LinkButton ID="LnkbtnGFproof" runat="server"></asp:LinkButton><br />
                               <iframe id="GFProof" runat="server" width="640" height="360" src='<%# Eval("GFProof") %>' scrolling="auto" ></iframe>
          
                                </li>
                                <li id="GM" runat="server" Visible="false">
                                    GodMother's Proof: <asp:LinkButton ID="LnkbtnGMproof" runat="server" ></asp:LinkButton><br />
                                      <iframe id="Iframe1" runat="server" width="640" height="360" src='<%# Eval("GMProof") %>' scrolling="auto" ></iframe>
          
                                </li>
                             
                            <li id="F" runat="server" Visible="false">
                                 Father's Proof:<asp:LinkButton ID="LnkbtnFproof" runat="server"></asp:LinkButton><br />
                               <iframe id="Iframe2" runat="server" width="640" height="360" src='<%# Eval("FProof") %>' scrolling="auto" ></iframe>
          
                            </li>
                            <li id="M" runat="server" Visible="false">
                                Mother's Proof:<asp:LinkButton ID="LnkbtnMproof" runat="server" ></asp:LinkButton><br />
                             <iframe id="Iframe3" runat="server" width="640" height="360" src='<%# Eval("MProof") %>' scrolling="auto" ></iframe>
          
                            </li>
                            <li id="ur" runat="server" Visible="false">
                                 Self Proof:<asp:LinkButton ID="Lnkbtnurproof" runat="server" ></asp:LinkButton><br />
                                    <iframe id="Iframe4" runat="server" width="640" height="360" src='<%# Eval("UrBapProof") %>' scrolling="auto"></iframe>
          
                            </li>
                            
                            </ul>
                            
                        </th>
                       
                   </tr>
                                   
                     </ItemTemplate>
                
                
               
            </asp:ListView>
            
        </asp:Panel>
         </table>


</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/SimpleFormsMaster.Master" AutoEventWireup="true" CodeBehind="PriestGalary.aspx.cs" Inherits="Diocese.PriestGalary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    

        <asp:Panel ID="PanelImage" runat="server">
            <asp:ListView ID="ListView1" runat="server">
                <ItemTemplate>
                   <asp:ImageButton ID="Gal_Image" runat="server"  CssClass="image" CommandArgument='<%#Eval("Parish_Priest_ID")%>' CommandName="Priest" ImageUrl='<%# Bind("Parish_Priest_Image") %>'  OnCommand="Gal_Image_Command" />
                    
                </ItemTemplate>
                
                
            </asp:ListView>
            
        </asp:Panel>
        
 
</asp:Content>

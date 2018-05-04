<%@ Page Title="" Language="C#" MasterPageFile="~/SimpleFormsMaster.Master" AutoEventWireup="true" CodeBehind="Selected_priest_details.aspx.cs" Inherits="Diocese.Selected_priest_details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="myModal" runat="server" >
     

     <asp:ListView ID="ListView2" runat="server">

     <ItemTemplate>
     <table>
         <tr>
             <th>
                 
             <asp:Image ID="Image1" runat="server"  ImageUrl='<%#Eval("Parish_Priest_Image")%>' width="300px" Height="300px"/></th>
         </tr>

         <tr>
             <th>
                    <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label></th><th>
                 <asp:Label ID="LBLPriestName" runat="server" Text='<%#Eval("Parish_Priest_Name")%>'></asp:Label></th>
         </tr>
         <tr>
             <th>
                    <asp:Label ID="Label3" runat="server" Text="Designation"></asp:Label></th><th>
                 <asp:Label ID="LBLDesignation" runat="server" Text='<%#Eval("Designation")%>'></asp:Label>
             </th>
         </tr>
         
         <tr>
             <th>
                    <asp:Label ID="Label4" runat="server" Text="Current Parish Name"></asp:Label></th><th>
                 <asp:Label ID="LBLCurrent_parish" runat="server" Text='<%#Eval("Parish_Name")%>'></asp:Label>
             </th>
         </tr>
         <tr>
             <th>
                    <asp:Label ID="Label5" runat="server" Text="Ordination"></asp:Label></th><th>
                 <asp:Label ID="LBLDOOrdination" runat="server" Text='<%#Eval("OrdinationDate")%>'></asp:Label>
             </th>
         </tr>
         <tr>
             <th>
                    <asp:Label ID="Label6" runat="server" Text="Native church"></asp:Label></th><th>
                 <asp:Label ID="LBLNativeParish" runat="server" Text='<%#Eval("Native_Place")%>'></asp:Label>
             </th>
         </tr>
         <tr>
             <th>
                    <asp:Label ID="Label7" runat="server" Text="Contact"></asp:Label></th><th>
                 <asp:Label ID="LBLContact" runat="server" Text='<%#Eval("Phone_No")%>'></asp:Label>
             </th>
         </tr>
     </table>
         </ItemTemplate>
    </asp:ListView>
        
     </div>
</asp:Content>

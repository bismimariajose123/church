<%@ Page Title="" Language="C#" MasterPageFile="~/SubAdminMaster.Master" AutoEventWireup="true" CodeBehind="SubAdminNotification.aspx.cs" Inherits="Diocese.SubAdminNotification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       Search by Column 
                 <div class="input-group custom-search-form" style="width:20%">
                             
                      <asp:TextBox ID="TBSearch" runat="server" CssClass="form-control" placeholder="Search..."></asp:TextBox>
                            
                                 <span class="input-group-btn">
                                    <button class="btn btn-default" type="button">
                                       <i class="fa fa-search"></i>
                                    </button>
                                </span>
                            </div>
    <asp:gridview runat="server"></asp:gridview>

</asp:Content>

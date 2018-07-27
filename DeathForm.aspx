<%@ Page Title="" Language="C#" MasterPageFile="~/SimpleFormsMaster.Master" AutoEventWireup="true" CodeBehind="DeathForm.aspx.cs" Inherits="Diocese.DeathForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:LinkButton ID="LnkbtnHome" runat="server" OnClick="LnkbtnHome_Click">Back to Home</asp:LinkButton>
    <br />
   
     <!--grid-->
 	<div class="validation-system">
 		
 		<div class="validation-form">
 	<!---->
            

           <div class="vali-form">
            <div class="col-md-6 form-group1">

                <label class="control-label">Ward Name </label>
              <asp:DropDownList ID="DDlWardName" runat="server" style="width:100%;display: inline-block; border: 1px solid #ccc;box-sizing: border-box;margin-top:7px;height:45px;font-size:9px;" AppendDataBoundItems="True"  OnSelectedIndexChanged="DDlWardName_SelectedIndexChanged" AutoPostBack = "true">
                        <asp:ListItem Value="0" Text="--select--" ></asp:ListItem>
                         </asp:DropDownList>
     
            </div>
           <div class="col-md-6 form-group1 form-last">
               <label class="control-label">Family Name</label>
                <br />
               <asp:DropDownList ID="DDlFamilyName" runat="server" style="width:100%;display: inline-block; border: 1px solid #ccc;box-sizing: border-box;margin-top:7px;height:45px;font-size:9px;" AppendDataBoundItems="True" OnSelectedIndexChanged="DDlFamilyName_SelectedIndexChanged" AutoPostBack = "true" >
                        <asp:ListItem Value="0" Text="--select--" ></asp:ListItem>
                         </asp:DropDownList>
          
          </div>

            <div class="clearfix"> </div>
            </div>

             <div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Date of Death</label>
                <input type="date" id="dateofdeath" class="form-control1 ng-invalid ng-invalid-required"  required="" onchange="deathdate()">
                <asp:hiddenfield ID="Dodeathhidden" runat="server"></asp:hiddenfield>
                </div>
           <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Death Person's Official Name</label>
                <asp:DropDownList ID="DDLOfficialName" runat="server" style="width:100%;display: inline-block; border: 1px solid #ccc;box-sizing: border-box;margin-top:7px;height:45px;font-size:9px;" AppendDataBoundItems="True" >
                        <asp:ListItem Value="0" Text="--select--" ></asp:ListItem>
                         </asp:DropDownList>
     
            </div> 
            <div class="clearfix"> </div>
            </div>

              <div class="vali-form">
            <div class="col-md-6 form-group1">
                <label class="control-label">Funeral Time</label>
               <asp:textbox ID="TBFuneralTime" runat="server"  placeholder="hh: pm/am" ></asp:textbox>
               </div>
            <div class="col-md-6 form-group1 form-last">
                <label class="control-label">Funeral Date</label>
                  <input type="date" id="dateoffuneral" class="form-control1 ng-invalid ng-invalid-required" required="" onchange="funeraldate()">
                <asp:hiddenfield ID="Hiddenfield1" runat="server"></asp:hiddenfield>
                 </div>
            <div class="clearfix"> </div>
            </div>
          
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Gender</label>
              <asp:dropdownlist ID="DDLGender" runat="server"  required="" style="width:100%;display: inline-block; border: 1px solid #ccc;box-sizing: border-box;margin-top:7px;height:45px;font-size:9px;" placeholder="--select--">
              <asp:ListItem Text="select" Value="0"></asp:ListItem>
                  <asp:ListItem Text="Male" Value="1"></asp:ListItem>
               <asp:ListItem Text="Female" Value="2"></asp:ListItem>
               
              </asp:dropdownlist>
                
            </div>
                
            <div class="clearfix"> </div>
          
             
             <div class="vali-form">
              <div class="col-md-12 form-group">
              <asp:Button ID="Btndeath" runat="server" Text="Submit"  CssClass="btn btn-primary" OnClick="Btndeath_Click"/>
              <button type="reset" class="btn btn-default">Reset</button>
            </div>
          <div class="clearfix"> </div>
   </div>

   
 	<!---->
 </div>
      </div>
             
    <script>

        function deathdate() {
           
            var textbox = document.getElementById('dateofdeath');
            document.getElementById('<%=Dodeathhidden.ClientID%>').value = textbox.value;
            alert(textbox.value);

        }

        function funeraldate() {
            alert('hii');
            var textbox1 = document.getElementById('dateoffuneral');
            document.getElementById('<%=Hiddenfield1.ClientID%>').value = textbox1.value;
            alert(textbox1.value);
        }
    </script>
</asp:Content>

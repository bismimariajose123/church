<%@ Page Title="" Language="C#" MasterPageFile="~/SimpleFormsMaster.Master" AutoEventWireup="true" CodeBehind="BaptismForm.aspx.cs" Inherits="Diocese.BaptismForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
     <asp:LinkButton ID="LnkbtnHome" runat="server" OnClick="LnkbtnHome_Click">Back to Home</asp:LinkButton>
    <br />
    <!--grid-->
 	<div class="validation-system">
 		
 		<div class="validation-form">
 	<!---->

               <label>
                    <asp:checkbox runat="server" ID="Checkbox1" ng-model="model.winner" required="" class="ng-invalid ng-invalid-required" 
                        onclick="Newborn()" ></asp:checkbox>
                 Non-Member ?<label style="margin-left:30px;color:cadetblue">tick if yes</label>
                </label>
             <div class="vali-form">
            <div class="col-md-6 form-group1">
 
              <div class="checkbox1">
                <label>
                    <asp:checkbox runat="server" ID="newborn" ng-model="model.winner" required="" class="ng-invalid ng-invalid-required" 
                        onclick="Newborn()" ></asp:checkbox>
                  New Born?<label style="margin-left:30px;color:cadetblue">tick if yes</label>
                </label>
                 
              </div>
                </div>
                 <div class="col-md-6 form-group1 form-last">
                <div class="checkbox1">
                <label>
                    <asp:checkbox runat="server" ID="marriedstatus" ng-model="model.winner" required="" class="ng-invalid ng-invalid-required" 
                        onclick="Newborn()"></asp:checkbox>
                  Married<label style="margin-left:30px;color:cadetblue">tick if yes</label>
                </label>
              </div>
                </div>
                  <div class="clearfix"> </div>
                 </div>

              <div class="vali-form">
            <div class="col-md-6 form-group1">

                <div class="checkbox1">
                <label>
                    <asp:checkbox runat="server" ID="parishmember" ng-model="model.winner" required="" class="ng-invalid ng-invalid-required" 
                        onclick="Newborn()"></asp:checkbox>
                   Are your Parents member of this Parish?<label style="margin-left:30px;color:cadetblue">tick if yes</label>
                </label>
              </div>
                
               </div>
            <div id="BaptismTime" style="display:none">
                 <label class="control-label" id="lblbaptime" >Time of Baptism</label>
                <asp:textbox ID="TBBapTime" runat="server"  placeholder="Time of Baptism(hh,pm/am)"></asp:textbox>
         </div>
                   <div class="clearfix"> </div>
                 </div>
            

         	<div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Family Name</label>
                <asp:textbox ID="TBFamilyName" runat="server" required="" placeholder="Family Name"></asp:textbox>
            </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Parish Name</label>
               <asp:textbox ID="TBParishName" runat="server" required="" placeholder="Native Parish Name"></asp:textbox>
            </div>
            <div class="clearfix"> </div>
            </div>

             <div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Official Name</label>
                <asp:textbox ID="TBOfficialName" runat="server" required="" placeholder="Person receiving Baptism Official Name"></asp:textbox>
            </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Baptism Name</label>
               <asp:textbox ID="TBBaptismName" runat="server" required="" placeholder="Person receiving Baptism Baptism Name"></asp:textbox>
          </div>
            <div class="clearfix"> </div>
            </div>

              <div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Date of Baptism</label>
                <input type="date" class="form-control1 ng-invalid ng-invalid-required" id="orddate" ng-model="model.date" required="" onchange="date_dis()">
                <asp:hiddenfield ID="Dobhidden" runat="server"></asp:hiddenfield>
              
                </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Gender</label>
              <asp:dropdownlist ID="DDLGender" runat="server"  required="" style="width:100%;display: inline-block; border: 1px solid #ccc;box-sizing: border-box;margin-top:7px;height:45px;font-size:9px" placeholder="--select--">
              <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
              
                  <asp:ListItem Text="Male" Value="1"></asp:ListItem>
               <asp:ListItem Text="Female" Value="2"></asp:ListItem>
               
              </asp:dropdownlist>
                </div>

            <div class="clearfix"> </div>
            </div>

               <div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Place of Baptism</label>
                 <asp:textbox ID="TBBapPlace" runat="server"  placeholder="City or town " required=""></asp:textbox>
          

            </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label"> Baptism Parish</label>
               <asp:textbox ID="TBBapParish" runat="server"  placeholder="Name of parish receiving baptism " required=""></asp:textbox>
          </div>
            <div class="clearfix"> </div>
            </div>

            <div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Father's Name</label>
                <asp:textbox ID="TBFatherName" runat="server" required="" placeholder="Official Name"></asp:textbox>
            </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Mother's Name</label>
               <asp:textbox ID="TBMotherName" runat="server" required="" placeholder="Official Name"></asp:textbox>
          </div>
            <div class="clearfix"> </div>
            </div>

               <div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Father's Baptism Name</label>
                <asp:textbox ID="TBFatherBapName" runat="server"  placeholder="Baptism Name" required=""></asp:textbox>
            </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Mother's Baptism Name</label>
               <asp:textbox ID="TBMotherBapName" runat="server"  placeholder="Baptism Name" required=""></asp:textbox>
          </div>
            <div class="clearfix"> </div>
            </div>
             <div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Godfather's Name</label>
                <asp:textbox ID="TBGodfatherName" runat="server" required="" placeholder="Official Name"></asp:textbox>
            </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Godmother's Name</label>
               <asp:textbox ID="TBGodmotherName" runat="server" required="" placeholder="Official Name"></asp:textbox>
          </div>
            <div class="clearfix"> </div>
            </div>

              <div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Parish Priest's Name</label>
                <asp:textbox ID="TBParishPriestName" runat="server" required="" placeholder="Official Name"></asp:textbox>
            </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Blessed By</label>
               <asp:textbox ID="TBCelebrantName" runat="server" required="" placeholder="Celebrant's Name"></asp:textbox>
        </div>
            <div class="clearfix"> </div>
            </div>

            

            <div class="vali-form" id="divFC" style="display:none">
            <div class="col-md-6 form-group1">
               <label class="control-label">Father's BaptismCertificate or any proof of christianity</label>
                <asp:fileupload runat="server" ID="FileuploadFatherCertificate" ></asp:fileupload>
                </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Mother's BaptismCertificate any proof of christianity</label>
                <asp:fileupload runat="server" ID="FileuploadMotherCertificate" ></asp:fileupload>
                </div>
            <div class="clearfix"> </div>
            </div>

               <div class="vali-form" id="divUR" style="display:none">
            <div class="col-md-6 form-group1">
               <label class="control-label">Your baptism Certificate copy</label>
                <asp:fileupload runat="server" ID="Fileuploadurcertificate" ></asp:fileupload>
                </div>
           
            <div class="clearfix"> </div>
            </div>


             <div class="vali-form" id="divGFC" style="display:none">
            <div class="col-md-6 form-group1">
               <label class="control-label">GodFather's BaptismCertificate</label>
                <asp:fileupload runat="server" ID="FileuploadGF" ></asp:fileupload>
                </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">GodMother's BaptismCertificate</label>
                <asp:fileupload runat="server" ID="FileuploadGM" ></asp:fileupload>
                </div>
            <div class="clearfix"> </div>
            </div> 
           
             <div class="vali-form">
              <div class="col-md-12 form-group">
              <asp:Button ID="Btn_insertBaptism_details" runat="server" Text="Submit"  CssClass="btn btn-primary" OnClick="Btn_insertBaptism_details_Click" />
                
                <button type="reset" class="btn btn-default">Reset</button>
            </div>
          <div class="clearfix"> </div>
   
      </div>
   
 	<!---->
 </div>

</div>


    <script type="text/javascript">

        function date_dis()
        {
            var textbox = document.getElementById('orddate');
            if (document.getElementById('<%= newborn.ClientID  %>').checked)
            {  //newborn
                
                var CurrentDate = new Date();
                var currdate=CurrentDate.toLocaleDateString();
                
                var givendate = new Date(textbox.value)
                var bapdate=givendate.toLocaleDateString();
                
                if (bapdate <= currdate)
                {
                   
                    alert("invalid date");
                }

                else
                {
                    
                    document.getElementById('<%=Dobhidden.ClientID%>').value = textbox.value;
                }
            }
            else 
            {
                document.getElementById('<%=Dobhidden.ClientID%>').value = textbox.value;
                alert("not new born");
            }
            
        }
        function Newborn()
        {
            if ((document.getElementById('<%= marriedstatus.ClientID  %>').checked) && (document.getElementById('<%= newborn.ClientID  %>').checked)) {
                alert("incorrect selection");
            }
            else if ((document.getElementById('<%= newborn.ClientID  %>').checked) && (document.getElementById('<%= parishmember.ClientID  %>').checked) && (document.getElementById('<%= marriedstatus.ClientID  %>').checked)==false) {  //newborn & parents parish member
                var divFC = document.getElementById("divFC");
                var divGFC = document.getElementById("divGFC");
                var divUR = document.getElementById("divUR");
                var BaptismTime = document.getElementById("BaptismTime");
              
                divFC.style.display = "none"
                divGFC.style.display = "block";
                divUR.style.display = "none";
                BaptismTime.style.display = "block";

                

            }
            else if ((document.getElementById('<%= newborn.ClientID  %>').checked) && (document.getElementById('<%= parishmember.ClientID  %>').checked) == false && (document.getElementById('<%=Checkbox1.ClientID%>').checked) == false) { //newborn & parents not parish member
                var divFC = document.getElementById("divFC");
                var divGFC = document.getElementById("divGFC");
                var divUR = document.getElementById("divUR");
                var BaptismTime = document.getElementById("BaptismTime");
                BaptismTime.style.display = "block";

                divFC.style.display = "block"
                divGFC.style.display = "block";
                divUR.style.display = "none";
            }
            else if ((document.getElementById('<%= marriedstatus.ClientID  %>').checked) && (document.getElementById('<%= parishmember.ClientID  %>').checked) && (document.getElementById('<%=Checkbox1.ClientID%>').checked) == false) { //married & parents parish member
                var divFC = document.getElementById("divFC");
                var divGFC = document.getElementById("divGFC");
                var divUR = document.getElementById("divUR");
                var BaptismTime = document.getElementById("BaptismTime");
                BaptismTime.style.display = "none";


                divFC.style.display = "none"
                divGFC.style.display = "none";
                divUR.style.display = "block";
            }

            else if ((document.getElementById('<%= marriedstatus.ClientID  %>').checked) && (document.getElementById('<%= parishmember.ClientID  %>').checked) == false && (document.getElementById('<%=Checkbox1.ClientID%>').checked) == false) { //married & parents not  parish member
                var divFC = document.getElementById("divFC");
                var divGFC = document.getElementById("divGFC");
                var divUR = document.getElementById("divUR");
                var BaptismTime = document.getElementById("BaptismTime");
                BaptismTime.style.display = "none";

                divFC.style.display = "none"
                divGFC.style.display = "none";
                divUR.style.display = "block";
            }
            else if ((document.getElementById('<%= marriedstatus.ClientID  %>').checked) == false && (document.getElementById('<%=  newborn.ClientID  %>').checked) == false && (document.getElementById('<%=Checkbox1.ClientID%>').checked) == false && (document.getElementById('<%= parishmember.ClientID  %>').checked)){
                var divFC = document.getElementById("divFC");              //not married & not new born but parents is parish member
                var divGFC = document.getElementById("divGFC");
                var divUR = document.getElementById("divUR");
                var BaptismTime = document.getElementById("BaptismTime");
                BaptismTime.style.display = "none";

                divFC.style.display = "none"
                divGFC.style.display = "none";
                divUR.style.display = "block";
            }
            else if ((document.getElementById('<%= marriedstatus.ClientID  %>').checked) == false && (document.getElementById('<%=  newborn.ClientID  %>').checked) == false && (document.getElementById('<%= parishmember.ClientID  %>').checked) == false && (document.getElementById('<%=Checkbox1.ClientID%>').checked) == false) {
                var divFC = document.getElementById("divFC");              //not married & not new born but parents not is parish member
                var divGFC = document.getElementById("divGFC");
                var divUR = document.getElementById("divUR");
                var BaptismTime = document.getElementById("BaptismTime");
                BaptismTime.style.display = "none";

                divFC.style.display = "none"
                divGFC.style.display = "none";
                divUR.style.display = "block";
            }
            else if ((document.getElementById('<%= marriedstatus.ClientID  %>').checked) == true && (document.getElementById('<%=  newborn.ClientID  %>').checked) == false && (document.getElementById('<%= parishmember.ClientID  %>').checked) == false && (document.getElementById('<%=Checkbox1.ClientID%>').checked)==true) {
                alert('hiii');
                var divFC = document.getElementById("divFC");              //not married & not new born but parents not is parish member
                var divGFC = document.getElementById("divGFC");
                var divUR = document.getElementById("divUR");
                var BaptismTime = document.getElementById("BaptismTime");
                BaptismTime.style.display = "block";

                divFC.style.display = "block"
                divGFC.style.display = "block";
                divUR.style.display = "none";
            }
        }
        
        



</script>
</asp:Content>


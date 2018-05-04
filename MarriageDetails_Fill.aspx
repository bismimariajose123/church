<%@ Page Title="" Language="C#" MasterPageFile="~/SimpleFormsMaster.Master" AutoEventWireup="true" CodeBehind="MarriageDetails_Fill.aspx.cs" Inherits="Diocese.MarriageDetails_Fill" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!--grid-->
 	<div class="validation-system">
 		
 		<div class="validation-form">
 	<!---->
             <div class="vali-form">
            <div class="col-md-6 form-group1">
 
             <div class="checkbox1">
                <label>
                    <asp:checkbox runat="server" ID="parishmember" ng-model="model.winner" required="" class="ng-invalid ng-invalid-required" onclick="ShowHideDiv()" 
                        ></asp:checkbox>
                   Are your Parents member of this Parish?<label style="margin-left:30px;color:cadetblue">tick if yes</label>
                </label>
              </div>
                </div>
                 <div class="col-md-6 form-group1 form-last">
                <div class="checkbox1">
                <label>
                    <asp:checkbox runat="server" ID="marriedstatus" ng-model="model.winner" required="" class="ng-invalid ng-invalid-required" 
                        onclick="Married()" ></asp:checkbox>
                  Married<label style="margin-left:30px;color:cadetblue">tick if yes</label>
                </label>
              </div>
                </div>
                  <div class="clearfix"> </div>
                 </div>

              
         	<div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">BRIDEGROOM</label>
                  </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">BRIDE</label>
                  </div>
           
            </div>
             
         	<div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Family Name</label>
                <asp:textbox ID="TBFamilyNameG" runat="server" required="" placeholder="Family Name"></asp:textbox>
            </div>
            <div class="col-md-6 form-group1 form-last">
          <label class="control-label">Family Name</label>
                <asp:textbox ID="TBFamilyNameB" runat="server" required="" placeholder="Family Name"></asp:textbox>
            
                </div>
            <div class="clearfix"> </div>
            </div>

             <div class="vali-form">
            <div class="col-md-6 form-group1">
                  <label class="control-label">Parish Name</label>
               <asp:textbox ID="TBParishNameG" runat="server" required="" placeholder="Parish Name"></asp:textbox>
            </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Parish Name</label>
               <asp:textbox ID="TBParishNameB" runat="server" required="" placeholder="Parish Name"></asp:textbox>
            </div>
            <div class="clearfix"> </div>
            </div>

           <div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Diocese</label>
                <asp:textbox ID="TBDioceseG" runat="server" required="" placeholder="Diocese"></asp:textbox>
            </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Diocese</label>
               <asp:textbox ID="TBDioceseB" runat="server" required="" placeholder="Diocese"></asp:textbox>
          </div>
            <div class="clearfix"> </div>
            </div>
             <div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Official Name</label>
                <asp:textbox ID="TBOfficialNameG" runat="server" required="" placeholder="Groom's Official Name"></asp:textbox>
              </div>
            <div class="col-md-6 form-group1 form-last">
               <label class="control-label">Official Name</label>
                <asp:textbox ID="TBOfficialNameB" runat="server" required="" placeholder="Bride's Official Name"></asp:textbox>
            </div>
            <div class="clearfix"> </div>
            </div>

             <div class="vali-form">
            <div class="col-md-6 form-group1">
             <label class="control-label">Baptism Name</label>
               <asp:textbox ID="TBBaptismNameG" runat="server" required="" placeholder="Groom's Baptism Name"></asp:textbox>
          </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Baptism Name</label>
               <asp:textbox ID="TBBaptismNameB" runat="server" required="" placeholder="Bride's Baptism Name"></asp:textbox>
          </div>
            <div class="clearfix"> </div>
            </div>
              <div class="vali-form">
            <div class="col-md-6 form-group1">
                 <label class="control-label">Date of Baptism</label>
                <input type="date" id="dateG" class="form-control1 ng-invalid ng-invalid-required" ng-model="model.date" required="">
                <asp:hiddenfield ID="DobaphiddenG" runat="server"></asp:hiddenfield>
                 </div>
            <div class="col-md-6 form-group1 form-last">
                 <label class="control-label">Date of Baptism</label>
                <input type="date"id="dateB" class="form-control1 ng-invalid ng-invalid-required" ng-model="model.date" required="">
                <asp:hiddenfield ID="DobaphiddenB" runat="server"></asp:hiddenfield>
                </div>
            <div class="clearfix"> </div>
            </div>

              <div class="vali-form">
            <div class="col-md-6 form-group1">
                 <label class="control-label">Date of Birth</label>
                <input type="date" id="datebirthG" class="form-control1 ng-invalid ng-invalid-required" ng-model="model.date" required="">
                <asp:hiddenfield ID="dobirthhidG" runat="server"></asp:hiddenfield>
                 </div>
            <div class="col-md-6 form-group1 form-last">
                 <label class="control-label">Date of Birth</label>
                <input type="date"id="datebirthB" class="form-control1 ng-invalid ng-invalid-required" ng-model="model.date" required="">
                <asp:hiddenfield ID="dobirthhidB" runat="server"></asp:hiddenfield>
                </div>
            <div class="clearfix"> </div>
            </div>

              <div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Father's Name</label>
                <asp:textbox ID="TBFatherNameG" runat="server" required="" placeholder="Groom's Father's Official Name"></asp:textbox>
            </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Father's Name</label>
                <asp:textbox ID="TBFatherNameB" runat="server" required="" placeholder="Bride's Father's Official Name"></asp:textbox>
           
            </div>
            <div class="clearfix"> </div>
            </div>
              <div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Mother's Name</label>
               <asp:textbox ID="TBMotherNameG" runat="server" required="" placeholder="Groom's Mother's Official Name"></asp:textbox>
           </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Mother's Name</label>
               <asp:textbox ID="TBMotherNameB" runat="server" required="" placeholder="Bride's Mother's Official Name"></asp:textbox>
          </div>
            <div class="clearfix"> </div>
            </div>

               <div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Father's Baptism Name</label>
                <asp:textbox ID="TBFatherBapNameG" runat="server"  placeholder="Groom's Father's Baptism Name"></asp:textbox>
            </div>
            <div class="col-md-6 form-group1 form-last">
             <label class="control-label">Father's Baptism Name</label>
                <asp:textbox ID="TBFatherBapNameB" runat="server"  placeholder="Bride's Father's Baptism Name"></asp:textbox>
           </div>
            <div class="clearfix"> </div>
            </div >
             <div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Mother's Baptism Name</label>
                <asp:textbox ID="TBMotherBapNameG" runat="server"  placeholder=" Groom's Mother's Baptism Name"></asp:textbox>
            </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Mother's Baptism Name</label>
               <asp:textbox ID="TBMotherBapNameB" runat="server"  placeholder="Bride's Mother's Baptism Name"></asp:textbox>
          </div>
            <div class="clearfix"> </div>
            </div>


              <div class="vali-form" id="divpremarriageCF">
            <div class="col-md-6 form-group1">
               <label class="control-label">Premarriage Certificate</label>
                <asp:fileupload runat="server" ID="FileUpPreMarrCF" required=""></asp:fileupload>
                </div>
                   <div class="col-md-6 form-group1 form-last">
                 <label class="control-label">Date of Betrothal</label>
                <input type="date" id="datebetrothalG" class="form-control1 ng-invalid ng-invalid-required" ng-model="model.date" required="">
                <asp:hiddenfield ID="HidfieldBetrothal" runat="server"></asp:hiddenfield>
             </div>
             <div class="clearfix"> </div>
            </div>
              
              <div class="vali-form">
            <div class="col-md-6 form-group-sm">
                <label class="control-label">Bann 1</label>
                <input type="date"id="dateBann1" class="form-control1 ng-invalid ng-invalid-required" ng-model="model.date" required="">
                <asp:hiddenfield ID="HiddenfieldBann1" runat="server"></asp:hiddenfield>
                
            </div>
                  <div class="col-md-6 form-group-sm">
                     <label class="control-label">Bann 2</label>
                <input type="date"id="dateBann2" class="form-control1 ng-invalid ng-invalid-required" ng-model="model.date" required="">
                <asp:hiddenfield ID="HiddenfieldBann2" runat="server"></asp:hiddenfield>
           
            </div>
            <div class="col-md-6 form-group-sm">
                <label class="control-label">Bann 3</label>
                <input type="date"id="dateBann3" class="form-control1 ng-invalid ng-invalid-required" ng-model="model.date" required="">
                <asp:hiddenfield ID="HiddenfieldBann3" runat="server"></asp:hiddenfield>
               </div>
            <div class="clearfix"> </div>
            </div>
             
               <div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Betrothal Parish</label>
                <asp:textbox ID="TBBetrothalParish" runat="server"  placeholder="Betrothal Parish"></asp:textbox>
           </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Betrothal Blessed By</label>
               <asp:textbox ID="TBBlessedBy" runat="server"  placeholder="Celebrant's name"></asp:textbox>
          </div>
            <div class="clearfix"> </div>
            </div>

           
             <div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Betrothal Witness1 Name</label>
                <asp:textbox ID="TBBethWitness1Name" runat="server" required="" placeholder="Witness1 Name"></asp:textbox>
            </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Betrothal Witness2 Name</label>
               <asp:textbox ID="TBBethWitness2Name" runat="server" required="" placeholder="Witness2 Name"></asp:textbox>
          </div>
            <div class="clearfix"> </div>
            </div>

              <div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Parish of Marriage</label>
                <asp:textbox ID="TBParishOfMarriage" runat="server" required="" placeholder="Parish Name"></asp:textbox>
            </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Marriage Blessed By</label>
               <asp:textbox ID="TBMarriageCelebrantName" runat="server" required="" placeholder="Celebrant's Name"></asp:textbox>
        </div>
            <div class="clearfix"> </div>
            </div>
              <div class="vali-form">
            <div class="col-md-6 form-group1">
              <label class="control-label">Marriage Witness1 Name</label>
                <asp:textbox ID="TBMarriageWit1" runat="server" required="" placeholder="Witness1 Name"></asp:textbox>
            </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Marriage Witness2 Name</label>
               <asp:textbox ID="TBMarriageWit2" runat="server" required="" placeholder="Witness2 Name"></asp:textbox>
          </div>
            <div class="clearfix"> </div>
            </div>
              <div class="vali-form" id="divFC">
            <div class="col-md-6 form-group1">
            
             <label class="control-label">Date of Marriage</label>
                <input type="date" id="datemarriage" class="form-control1 ng-invalid ng-invalid-required" ng-model="model.date" required="">
                <asp:hiddenfield ID="Hiddenfieldmarriagedate" runat="server"></asp:hiddenfield>
             </div><div class="clearfix"> </div></div>

            <div class="vali-form" id="divFC">
            <div class="col-md-6 form-group1">
               <label class="control-label"> Bride's Baptism Certificate or any proof of christianity</label>
                <asp:fileupload runat="server" ID="FileuploadBrideCertificate" required=""></asp:fileupload>
                </div>
            <div class="col-md-6 form-group1 form-last">
              <label class="control-label">Groom's Baptism Certificate any proof of christianity</label>
                <asp:fileupload runat="server" ID="FileuploadGroomCertificate" required=""></asp:fileupload>
                </div>
            <div class="clearfix"> </div>
            </div>
  <div class="vali-form">
              <div class="col-md-12 form-group">
              
              <asp:Button ID="Btnsubmit" runat="server" Text="Submit"  CssClass="btn btn-primary"/>
              <button type="reset" class="btn btn-default">Reset</button>
            </div>
          <div class="clearfix"> </div>
   </div>

   
 	<!---->
 </div>

</div>
    

</asp:Content>

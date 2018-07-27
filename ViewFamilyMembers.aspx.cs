using Diocese.Project_Code.People;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diocese
{
    public partial class ViewFamilyMembers : System.Web.UI.Page
    {
        MemberBO objMemberRegisterBO = new MemberBO();
        MemberBLL objMemberRegisterBLL = new MemberBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            
                Load_Image();
            if(!IsPostBack)
            {
                Load_DDLMemberNames();
            }
                

            
            ListView1.ItemCommand += new EventHandler<ListViewCommandEventArgs>(ListView1_ItemCommand);
       
        }


        void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string memberid = (String)e.CommandArgument;
            Session["ParishMember_id"] = memberid;
            Session["Usertype_normal_bap_req"] = 3;
            Response.Redirect("BaptismForm.aspx");
        }
        public void Load_DDLMemberNames()
        {

            objMemberRegisterBO.Parishid = Convert.ToInt32(Session["parishid"].ToString());
            objMemberRegisterBO.Familyid = Convert.ToInt32(Session["family_id"].ToString());

            DataTable dt = objMemberRegisterBLL.Load_DDLMemberNames(objMemberRegisterBO);
            DDLMemberName.DataSource=dt;
            DDLMemberName.DataTextField = "OfficialName";
            DDLMemberName.DataValueField = "Member_ID";
            DDLMemberName.DataBind();
        }
        public void Load_Image()  //load member details in listview
        {
            objMemberRegisterBO.Parishid = Convert.ToInt32(Session["parishid"].ToString());
            objMemberRegisterBO.Familyid = Convert.ToInt32(Session["family_id"].ToString());

            DataTable dt = new DataTable();
            dt = objMemberRegisterBLL.Get_Member_Details(objMemberRegisterBO);
            if (dt.Rows.Count > 0)
            {
                Session["dt"] = dt;
                ListView1.DataSource = dt;
                ListView1.DataBind();
                PanelImage.Controls.Add(ListView1);

            }
            else
            {
                Response.Write("<script>alert('None Registered');</script>");
               // Response.Redirect("AddMemberDetail.aspx");
            }
           
            
        }


     

        protected void Imgbtnsearch_Click(object sender, ImageClickEventArgs e)
        {
            string searchstr = string.Empty;
            searchstr = TBsearch.Text;
           
            int familyid= Convert.ToInt32(Session["family_id"].ToString());
            int parishid= Convert.ToInt32(Session["parishid"].ToString());
            DataTable dt = new DataTable();
            if (searchstr == "")
            {
                Load_Image();
            }
            else { 
            dt = objMemberRegisterBLL.Get_Search_MemberDetails(searchstr,objMemberRegisterBO, familyid, parishid);
            if (dt.Rows.Count > 0)
            {
                ListView1.DataSource = dt;
                ListView1.DataBind();
                PanelImage.Controls.Add(ListView1);

            }
            else
            {
                Response.Write("<script>alert('search not found');</script>");
            }
        }
        }

        protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                DataRowView drv = (DataRowView)dataItem.DataItem;
                HiddenField bap = (HiddenField)e.Item.FindControl("LBLBap");
                HiddenField mar = (HiddenField)e.Item.FindControl("LBLMar");
                HiddenField marsts = (HiddenField)e.Item.FindControl("LBLMatSts");
                HiddenField regsts = (HiddenField)e.Item.FindControl("LBLRegsts");
                LinkButton lnkbap = (LinkButton)e.Item.FindControl("LnkBap");
                LinkButton lnkmar = (LinkButton)e.Item.FindControl("LnkMarriage");
                

                bap.Value = drv["BaptismId"].ToString();  //if baptism form details filled
                mar.Value= drv["Marriageid"].ToString();   //if marriage details filled
                marsts.Value=drv["MarriesStatus"].ToString();   //if married membertable marriage status =1
                regsts.Value= drv["RegisteredStatus"].ToString();  //if both marriage and bap registered reg status =1
                int bapid = Convert.ToInt32(bap.Value.ToString());
                int marid = Convert.ToInt32(mar.Value.ToString());
                int marstus = Convert.ToInt32(marsts.Value.ToString());
                int regst = Convert.ToInt32(regsts.Value.ToString());
                if (regst != 0)
                {
                    lnkbap.Visible = false;
                    lnkmar.Visible = false;
                }
                //else if (bapid == 0 && marstus == 0)//newborn
                //{
                //    lnkbap.Visible = true;
                //}
                else if (bapid == 0 && marid == 0 && marstus != 0)//married bt not registered B & M
                {
                    lnkbap.Visible = true;
                    lnkmar.Visible = true;
                }
                else if (marstus != 0 && bapid != 0 && marid == 0) //married bt not registered M
                {
                    lnkmar.Visible = true;
                }
                else if (marstus == 0 && bapid == 0 && marid == 0) // single bt not new born  ,baptism not registered, married not registered
                {
                    lnkbap.Visible = true;
                    lnkmar.Visible = true;
                }
                else if (marstus == 0 && bapid != 0 && marid == 0) //  new born ,baptism  registered, married not registered
                {
                    lnkbap.Visible = false;
                    lnkmar.Visible = true;
                }
            }
        }

        //protected void LnkBap_Command(object sender, CommandEventArgs e)
        //{
        //    if (e.CommandName == "Baptism")
        //    {
            
        //       int memberid = Convert.ToInt32(e.CommandArgument.ToString());
        //        Session["ParishMember_id"] = memberid;
        //        Session["Usertype_normal_bap_req"] = 3;
        //        Response.Redirect("BaptismForm.aspx");
        //    }
        //}

        protected void LnkMarriage_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Marriage")
            {
                Session["Usertype_normal_marr_req"] = 3;
                int memberid = Convert.ToInt32(e.CommandArgument.ToString());
                Session["ParishMember_id"] = memberid;
                Response.Redirect("MarriageDetails_Fill.aspx");
            }
        }

        protected void LnkbtnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberHome.aspx");
        }

        protected void BtnUpdateimage_Click(object sender, EventArgs e)
        {
            string fileName = string.Empty;
            if (FileUploadimg.HasFile)
            {

                fileName = FileUploadimg.FileName; //gets full path name in filename
                fileName = "~/Project_Code/People/PeopleImage/" + fileName;
                FileUploadimg.SaveAs(Server.MapPath(fileName));
            }
           
            int memberid = Convert.ToInt32(DDLMemberName.SelectedValue);
            objMemberRegisterBO.Imagepath = fileName;
            objMemberRegisterBO.Memberid = memberid;
            objMemberRegisterBO.Parishid = Convert.ToInt32(Session["parishid"].ToString());
            objMemberRegisterBO.Familyid = Convert.ToInt32(Session["family_id"].ToString());
           
            int result = objMemberRegisterBLL.Update_MemberImage(objMemberRegisterBO);
            if(result==1)
            {
                Load_Image();
            }

        }

        //protected void LnkBap_Click(object sender, EventArgs e)
        //{
        //    LinkButton lnkmemberid = (sender as LinkButton);
        //    Label LBLmemberid = (sender as Label);
        //   // int idd = Convert.ToInt32(LBLmemberid.Text);
        //    int id = Convert.ToInt32(lnkmemberid.CommandArgument);
        //    Session["ParishMember_id"] = id;
        //    Session["Usertype_normal_bap_req"] = 3;
        //    Response.Redirect("BaptismForm.aspx");
        //}

        //protected void Member_Image_Click(object sender, ImageClickEventArgs e)
        //{
        //    ImageButton imgbtn = (sender as ImageButton);

        //    //Get the Command Name.
        //   // string commandName = btnSelect.CommandName;

        //    //Get the Command Argument.
        //    string commandArgument = imgbtn.CommandArgument;
        //    TBsearch.Text = commandArgument;

        //}
    }
    }

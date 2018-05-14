﻿using Diocese.Project_Code.People;
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
            objMemberRegisterBO.Parishid = Convert.ToInt32(Session["parishid"].ToString());
            objMemberRegisterBO.Familyid = Convert.ToInt32(Session["family_id"].ToString());

          
            Load_Image();
         
        
        }

       
        public void Load_Image()
        {
            
            DataTable dt = new DataTable();
            dt = objMemberRegisterBLL.Get_Member_Details(objMemberRegisterBO);
            if (dt.Rows.Count > 0)
            {
                ListView1.DataSource = dt;
                ListView1.DataBind();
                PanelImage.Controls.Add(ListView1);

            }
            else
            {
                Response.Write("<script>alert('None Registered');</script>");
            }
           
            
        }


        protected void Member_Image_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Member")
            {
                string id = e.CommandArgument.ToString();

                int priest_id = Convert.ToInt32(id);
               
            }
        }

        protected void Imgbtnsearch_Click(object sender, ImageClickEventArgs e)
        {
            string searchstr = string.Empty;
            searchstr = TBsearch.Text;
            DataTable dt = new DataTable();
            dt = objMemberRegisterBLL.Get_Search_MemberDetails(searchstr,objMemberRegisterBO);
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
                

                bap.Value = drv["BaptismId"].ToString();
                mar.Value= drv["Marriageid"].ToString();
                marsts.Value=drv["MarriesStatus"].ToString();
                regsts.Value= drv["RegisteredStatus"].ToString();
                int bapid = Convert.ToInt32(bap.Value.ToString());
                int marid = Convert.ToInt32(mar.Value.ToString());
                int marstus = Convert.ToInt32(marsts.Value.ToString());
                int regst = Convert.ToInt32(regsts.Value.ToString());
                if (regst != 0)
                {
                    lnkbap.Visible = false;
                    lnkmar.Visible = false;
                }
                else if (bapid == 0 && marstus == 0)//newborn
                {
                    lnkbap.Visible = true;
                }
                else if (bapid == 0 && marid == 0 && marstus != 0)//married bt not registered B & M
                {
                    lnkbap.Visible = true;
                    lnkmar.Visible = true;
                }
                else if (marstus != 0 && bapid != 0 && marid == 0) //married bt not registered M
                {
                    lnkmar.Visible = true;
                }
                
            }
        }

        protected void LnkBap_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Baptism")
            {
            
            int memberid = Convert.ToInt32(e.CommandArgument.ToString());
                Session["memberid"] = memberid;
                Response.Redirect("BaptismForm.aspx");
            }
        }

        protected void LnkMarriage_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Marriage")
            {

                int memberid = Convert.ToInt32(e.CommandArgument.ToString());
                Session["memberid"] = memberid;
                Response.Redirect("MarriageDetails_Fill.aspx");
            }
        }

       
    }
    }

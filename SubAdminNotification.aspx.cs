using Diocese.Project_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;

using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

namespace Diocese
{
    public partial class SubAdminNotification : System.Web.UI.Page
    {
        RequestBO objRequestBO = new RequestBO();
        RequestBLL objRequestBLL = new RequestBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

            objRequestBO.Parishid1 = Convert.ToInt32(Session["parishid"]);
            if (!Page.IsPostBack)
            {
                Load_data();

            }

        }
        public void Load_data()
        {
            Session["Dt"] = objRequestBLL.GetNotificationDetails(objRequestBO);
            GVSubAdminNotification.DataSource = Session["Dt"];
            GVSubAdminNotification.DataBind();
        }

        protected void GVSubAdminNotification_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVSubAdminNotification.EditIndex = -1;
            Load_data();
        }

        protected void GVSubAdminNotification_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            int id = Convert.ToInt16(GVSubAdminNotification.DataKeys[e.RowIndex].Values["Memberid"].ToString());
            result = objRequestBLL.Delete_Request(id);
            Load_data();
        }

        protected void GVSubAdminNotification_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVSubAdminNotification.EditIndex = e.NewEditIndex;
            Load_data();
        }

        protected void GVSubAdminNotification_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int result = 0;
            TextBox TBDescription = GVSubAdminNotification.Rows[e.RowIndex].FindControl("TBDescription") as TextBox;
            DropDownList Status = GVSubAdminNotification.Rows[e.RowIndex].FindControl("DropDownList1") as DropDownList;
            Label LBLIsParishMember = GVSubAdminNotification.Rows[e.RowIndex].FindControl("LBLIsParishMember") as Label;
            objRequestBO.RequestStatus_Description1 = TBDescription.Text;
            objRequestBO.RequestStatus = Convert.ToInt32(Status.SelectedValue);
            objRequestBO.IsParishMember = Convert.ToInt32(LBLIsParishMember.Text);  //set is parish member
            int id = Convert.ToInt16(GVSubAdminNotification.DataKeys[e.RowIndex].Values["Memberid"].ToString());
            result = objRequestBLL.UpdateRequest(objRequestBO, id);
            GVSubAdminNotification.EditIndex = -1;
            Load_data();
        }

        protected void GVSubAdminNotification_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVSubAdminNotification.PageIndex = e.NewPageIndex;
            this.Load_data();
        }

        protected void DDLPagesize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((DDLPagesize.SelectedValue != "--") && (DDLPagesize.SelectedValue != "All"))
            {
                GVSubAdminNotification.PageSize = Convert.ToInt32(DDLPagesize.SelectedValue);
                DataTable dt = (DataTable)Session["Dt"];
                GVSubAdminNotification.DataSource = dt;
                GVSubAdminNotification.DataBind();
            }
            else if ((DDLPagesize.SelectedValue != "--") && (DDLPagesize.SelectedValue == "All"))
            {
                GVSubAdminNotification.AllowPaging = false;
                DataTable dt = (DataTable)Session["Dt"];
                GVSubAdminNotification.DataSource = dt;
                GVSubAdminNotification.DataBind();
            }
            else
            {
                GVSubAdminNotification.AllowPaging = false;
                Load_data();
            }
        }

        protected void Imgbtnsearch_Click(object sender, ImageClickEventArgs e)
        {
            string searchstr = string.Empty;
            searchstr = TBsearch.Text;
            objRequestBO.Parishid1 = Convert.ToInt32(Session["parishid"].ToString());
            if(searchstr=="")
            {
                Load_data();
            }
            else
            {

          
            DataTable dt = objRequestBLL.Get_Search_FamilyDetails(objRequestBO, searchstr);

            if (dt.Rows.Count > 0)
            {
                GVSubAdminNotification.DataSource = dt;
                GVSubAdminNotification.DataBind();
            }
            else
            {
                Response.Write("<script>alert('search not found');</script>");

            }
        }

        }

        protected void GVSubAdminNotification_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label RequestStatus = (Label)e.Row.FindControl("LBLRequestStatus");
                Label LblRequestStatusLabel = (Label)e.Row.FindControl("LblRequestStatusLabel");
                
                Button Addtbn = (Button)e.Row.FindControl("Addtbn");
                Label Event_Name = (Label)e.Row.FindControl("LBLEvent_Name");
                Button Download = (Button)e.Row.FindControl("Download");
                Label LBLIsParishMember = (Label)e.Row.FindControl("LBLIsParishMember"); //nobr for is parishmember
                Label isparishmemberName = (Label)e.Row.FindControl("isparishmemberName");//expand nob to terms in label for ismember
                if (RequestStatus == null && Addtbn.Text != null && Event_Name.Text != null && LBLIsParishMember.Text !=null)
                {
                    return;
                }

                else if (RequestStatus.Text == "1" && Event_Name.Text == "Baptism")
                {
                    if (LBLIsParishMember.Text =="1") 
                    {
                        isparishmemberName.Text = "Member";
                        isparishmemberName.Visible = true;
                        LBLIsParishMember.Visible = false;
                    }
                    else
                    {
                        isparishmemberName.Text = "Non Member";
                        isparishmemberName.Visible = true;
                        LBLIsParishMember.Visible = false;
                    }
                    LblRequestStatusLabel.Visible = true;
                    LblRequestStatusLabel.Text = "Approved";
                        Addtbn.Visible = true;

                }
               
                else if(RequestStatus.Text == "4" && Event_Name.Text == "Baptism")
                {
                    if (LBLIsParishMember.Text == "1")
                    {
                        isparishmemberName.Text = "Member";
                        isparishmemberName.Visible = true;
                        LBLIsParishMember.Visible = false;
                    }
                    else
                    {
                        isparishmemberName.Text = "Non Member";
                        isparishmemberName.Visible = true;
                        LBLIsParishMember.Visible = false;
                    }
                    LblRequestStatusLabel.Visible = true;
                    LblRequestStatusLabel.Text = "Added";
                    Addtbn.Visible = true;
                    Addtbn.Text = "Added";
                    Download.Visible = true;
                }
                else if(RequestStatus.Text == "2")
                {
                    LblRequestStatusLabel.Visible = true;
                    LblRequestStatusLabel.Text = "Rejected";
                }
                else
                {
                    if (LBLIsParishMember.Text == "1")
                    {
                        isparishmemberName.Text = "Member";
                        isparishmemberName.Visible = true;
                        LBLIsParishMember.Visible = false;
                    }
                    else
                    {
                        isparishmemberName.Text = "Non Member";
                        isparishmemberName.Visible = true;
                        LBLIsParishMember.Visible = false;
                    }
                    Addtbn.Visible = false;
                }

            }
        }

        protected void GVSubAdminNotification_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int memberid = 0;
           
            if (e.CommandName == "Add")
            {

                GridViewRow gv = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Label Event_Name = (Label)gv.FindControl("LBLEvent_Name");
                Button Addtbn = (Button)gv.FindControl("Addtbn");
                Button Download = (Button)gv.FindControl("Download");
                Label LBLIsParishMember = (Label)gv.FindControl("LBLIsParishMember");
                memberid = Convert.ToInt32(e.CommandArgument);
                if (LBLIsParishMember.Text == "1")  //Member
                {
                    int isparishmember = Convert.ToInt32(LBLIsParishMember.Text);
                    if (Event_Name.Text == "Baptism")
                    {
                        int result = objRequestBLL.DownloadBaptismForm(memberid,isparishmember);//update baptism id in member table an bap status =1 in baptable
                        if (result == 1)
                        {
                            Download.Visible = true;

                        }

                    }
                    if (Event_Name.Text == "Betrothal")
                    {
                        // int result = objRequestBLL.DownloadBaptismForm(memberid);
                    }
                }
 
                else if(LBLIsParishMember.Text == "0")  //Non member
                {
                    int isparishmember = Convert.ToInt32(LBLIsParishMember.Text);
                    if (Event_Name.Text == "Baptism")
                    {
                        int result = objRequestBLL.DownloadBaptismForm(memberid,isparishmember);//update baptism id in member table an bap status =1 in baptable
                        if (result == 1)
                        {
                            Download.Visible = true;

                        }

                    }
                    if (Event_Name.Text == "Betrothal")
                    {
                        // int result = objRequestBLL.DownloadBaptismForm(memberid);
                    }

                }
            }

            if (e.CommandName == "Details")   //view more details
            {
                GridViewRow gv = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                memberid = Convert.ToInt32(e.CommandArgument.ToString());
                Label Event_Name = (Label)gv.FindControl("LBLEvent_Name");
                Button Addtbn = (Button)gv.FindControl("Addtbn");
                Button Download = (Button)gv.FindControl("Download");
                Label LBLIsParishMember = (Label)gv.FindControl("LBLIsParishMember");

                if(LBLIsParishMember.Text=="1") //if parish member true
                {
                    Session["isparishmember"] = 1; //use in view_more_bap_details.aspx
                    if(Event_Name.Text== "Baptism")                                      //BAPTISM
                    {
                        Session["SubAdmin_viewDetails_memberid"] = memberid;  //assign member id of parish member
                    }
                    Response.Redirect("Sub_ViewMore_Baptism_Details.aspx");
                }
                else if(LBLIsParishMember.Text == "0")
                {
                    Session["isparishmember"] = 0; //use in view_more_bap_details.aspx
                    if (Event_Name.Text == "Baptism")                                    //BAPTISM
                    {
                        Session["SubAdmin_viewDetails_memberid"] = memberid; //assign nonmemberid
                    }
                    Response.Redirect("Sub_ViewMore_Baptism_Details.aspx");
                }
            }
        }
        protected void Download_Click(object sender, EventArgs e)//get memberid and isparishmember and requestid
        {
            String parishname = Session["Parishname"].ToString();
            Button lnk = sender as Button;
            GridViewRow gvr = lnk.NamingContainer as GridViewRow;
            Label LBLIsParishMember = gvr.FindControl("LBLIsParishMember") as Label;
            Label LBLRequestid = gvr.FindControl("LBLRequestid") as Label;
            Label LBLOfficialName = gvr.FindControl("LBLOfficialName") as Label;
            int memberid = Convert.ToInt32(((Button)sender).CommandArgument);
            Downloadfun(memberid,Convert.ToInt32(LBLIsParishMember.Text), Convert.ToInt32(LBLRequestid.Text), LBLOfficialName.Text, parishname);
        }
        public void Downloadfun(int memid,int isparishmember,int requsetid,string name,string parishname)
        {

            DataTable dt = objRequestBLL.GeneratePdfBaptism(memid,isparishmember,requsetid);
            DataRow drow = dt.Rows[0];
            if(dt.Rows.Count>0)
            {
                Document doc = new Document(PageSize.A4, 60, 50, 60, 50);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream("D:/Certificates/BaptismCertificate"+name+".pdf", FileMode.Create));
                doc.Open();
                iTextSharp.text.Image pic = iTextSharp.text.Image.GetInstance("D:/3 tierfare/Diocese/Project_Code/People/PeopleImage/frontimage.png");
                pic.Alignment = Element.ALIGN_CENTER;
                pic.ScaleToFit(100f, 100f);
                doc.Add(pic);

                Paragraph p_space_image = new Paragraph();
                Chunk img_space = new Chunk(Chunk.NEWLINE);
                p_space_image.Add(img_space);
                p_space_image.SpacingAfter = 20;

                Chunk c1 = new Chunk("This is to certify that ", FontFactory.GetFont("Times New Roman"));
                c1.Font.Color = new iTextSharp.text.BaseColor(0, 0, 0);
                c1.Font.SetStyle(0);
                c1.Font.Size = 12;
                Chunk c2 = new Chunk(drow["BaptismName"].ToString(), FontFactory.GetFont("Times New Roman"));
                c2.Font.Size = 14;
                Chunk c3 = new Chunk(" was Baptised at ", FontFactory.GetFont("Times New Roman"));
                c3.Font.Size = 12;
                Chunk c4 = new Chunk(" "+parishname, FontFactory.GetFont("Times New Roman"));
                c4.Font.Color = new iTextSharp.text.BaseColor(0, 0, 0);
                c4.Font.SetStyle(0);
                c4.Font.Size = 14;
                Chunk c5 = new Chunk(" on ", FontFactory.GetFont("Times New Roman"));
                c5.Font.Color = new iTextSharp.text.BaseColor(0, 0, 0);
                c5.Font.SetStyle(0);
                c5.Font.Size = 12;

               
                Chunk c7 = new Chunk(drow["DoBaptism"].ToString(), FontFactory.GetFont("Times New Roman"));
                c7.Font.Color = new iTextSharp.text.BaseColor(0, 0, 0);
                c7.Font.SetStyle(0);
                c7.Font.Size = 14;

                Chunk c8 = new Chunk(" by ", FontFactory.GetFont("Times New Roman"));
                c8.Font.Color = new iTextSharp.text.BaseColor(0, 0, 0);
                c8.Font.SetStyle(0);
                c8.Font.Size = 12;

                Chunk c9 = new Chunk(drow["Celebrant"].ToString(), FontFactory.GetFont("Times New Roman"));
                c9.Font.Color = new iTextSharp.text.BaseColor(0, 0, 0);
                c9.Font.SetStyle(0);
                c9.Font.Size = 14;

               

                Chunk c11 = new Chunk("Signed By :  "+ drow["Vicar"].ToString());
               
                Chunk c12 = new Chunk("Godfather :  "+ drow["GFName"].ToString());
               
                Chunk c13 = new Chunk("GodMother :  "+ drow["GMName"].ToString());


                Phrase phnew1 = new Phrase();
                phnew1.Add(c1);
                phnew1.Add(c2);
                phnew1.Add(c3);
                phnew1.Add(c4);
                phnew1.Add(c5);
              
                Phrase phnew2 = new Phrase();
                phnew2.Add(c7);
                phnew2.Add(c8);
                phnew2.Add(c9);
               

               
                Phrase p2 = new Phrase();
                p2.Add(c11);
                Phrase p3 = new Phrase();
                p3.Add(c12);

                Phrase p4 = new Phrase();
                p4.Add(c13);
               

                Paragraph pnew1= new Paragraph();
                pnew1.Add(phnew1);
                pnew1.Alignment = Element.ALIGN_JUSTIFIED;

                Paragraph pnew2 = new Paragraph();
                pnew2.Add(phnew2);
                pnew2.Alignment = Element.ALIGN_JUSTIFIED;
                pnew2.SpacingBefore = 10;
               

                Paragraph para2 = new Paragraph();
                para2.Add(p2);
                para2.Alignment = Element.ALIGN_JUSTIFIED;
                para2.SpacingBefore = 10;

                Paragraph para3 = new Paragraph();
                para3.Add(p3);
                para3.Alignment = Element.ALIGN_JUSTIFIED;
                para3.SpacingBefore = 10;

                Paragraph para4 = new Paragraph();
                para4.Add(p4);
                para4.Alignment = Element.ALIGN_JUSTIFIED;
                para4.SpacingBefore = 10;


                doc.Add(p_space_image);
                doc.Add(pnew1);
                doc.Add(pnew2);
                doc.Add(para3);
                doc.Add(para4);
                doc.Add(para2);
               
                doc.Close();
                Response.Write("<script>alert('successfull downloaded');</script>");

            }
        }

       
    }
}
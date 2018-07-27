using Diocese.Project_Code;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diocese
{
    public partial class CommunionViewForm : System.Web.UI.Page
    {
        CommunionBLL objCommunionBLL = new CommunionBLL();
        CommunionBO objCommunionBO = new CommunionBO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               Load_data();
            }
        }

        public void Load_data()
        {
            int parishid = Convert.ToInt32(Session["parishid"].ToString());
            DataTable dt = new DataTable();
            dt = objCommunionBLL.Load_data(parishid);
           
           int countMale = objCommunionBLL.count_of_Male(parishid);
           int countFeMale = objCommunionBLL.count_of_Female(parishid);
            if (countMale > 0 || countFeMale>0)
            {
                LBL_NumberOfMF.Text = "<b>Count of     Male : " + countMale + " Female : " + countFeMale + "<b>";
                LBL_NumberOfMF.Visible = true;
               
            }
            else
            {
                LBL_NumberOfMF.Visible = false;
            }
            if (dt.Rows.Count > 0)
            {
                Session["Dt"] = dt;
                GVCommuniondetails.DataSource = Session["Dt"];
                GVCommuniondetails.DataBind();
            }
            else
            {
                Response.Write("<script>alert(' not data found');</script>");

            }

        }
        protected void GVCommuniondetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            int id = Convert.ToInt16(GVCommuniondetails.DataKeys[e.RowIndex].Values["Communion_ID"].ToString());
            result = objCommunionBLL.Delete_CommunionDetails(id);
            Load_data();
        }
        protected void Imgbtnsearch_Click(object sender, ImageClickEventArgs e)
        {
            String dateofcommunion = hid_docommunion.Value;
            DateTime oDate = DateTime.Parse(dateofcommunion);
            objCommunionBO.DO_communion1 = oDate;
            objCommunionBO.Parish_id1 = Convert.ToInt32(Session["parishid"].ToString());
            DataTable dt = objCommunionBLL.Get_SearchCommunionDetails(objCommunionBO);
            int parishid = Convert.ToInt32(Session["parishid"].ToString());
            TBPriestname.Text = objCommunionBLL.getPriestname(parishid);
            if (dt.Rows.Count > 0)
            {
                GVCommuniondetails.DataSource = dt;
                GVCommuniondetails.DataBind();
            }
            else
            {
                Response.Write("<script>alert('search not found');</script>");

            }
        }

        protected void GVCommuniondetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label LBLDOFCommunion = (Label)e.Row.FindControl("LBLDOFCommunion");
                if (LBLDOFCommunion == null)
                {
                    return;
                }
                else
                {
                    String doc = LBLDOFCommunion.Text;
                    DateTime oDate = DateTime.Parse(doc);
                    LBLDOFCommunion.Text = oDate.ToString("dd/MM/yyyy");
                   // doc = doc.Substring(0, 10);
                    
                }

            }
        }

        protected void LnkbtnHome_Click(object sender, EventArgs e)
        {
            int usertype = Convert.ToInt32(Session["usertype"].ToString());
            if (usertype == 6)
            {
                Response.Redirect("SundaySchool.aspx");
            }
        }

        protected void LNK_dnldCertificate_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow gvr = lnk.NamingContainer as GridViewRow;
            Label LBLOfficialName = gvr.FindControl("LBLOfficialName") as Label;
            Label LBLBaptismName = gvr.FindControl("LBLBaptismName") as Label;
            String priestname= TBPriestname.Text;
            Label LBLDOFCommunion = gvr.FindControl("LBLDOFCommunion") as Label;
            String parishname = Session["Parishname"].ToString();
            Label LBLFamilyName = gvr.FindControl("LBLFamilyName") as Label;
           
            Downloadfun(LBLOfficialName.Text, LBLFamilyName.Text, LBLBaptismName.Text, LBLDOFCommunion.Text, parishname, priestname);

        }

        private void Downloadfun(string officialname, string familyname, string baptismname, string docommunion, string parishname, string priestname)
        {
           
           
                Document doc = new Document(PageSize.A4, 50, 40, 50, 40);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream("D:/Certificates/Communion" + officialname + " "+ familyname + ".pdf", FileMode.Create));
                doc.Open();
                iTextSharp.text.Image pic = iTextSharp.text.Image.GetInstance("D:/3 tierfare/Diocese/Project_Code/People/PeopleImage/stjosephslogo.jpg");
                pic.Alignment = Element.ALIGN_CENTER;
                pic.ScaleToFit(100f, 100f);
                doc.Add(pic);

                Paragraph p_space_image = new Paragraph();
                Chunk img_space = new Chunk(Chunk.NEWLINE);
                p_space_image.Add(img_space);
                p_space_image.SpacingAfter = 30;

                Chunk c1 = new Chunk("CERTIFICATE OF  ", FontFactory.GetFont(Font.FontFamily.TIMES_ROMAN.ToString()));
            //  c1.Font.Color = new iTextSharp.text.BaseColor(0, 0, 0);
              
               // c1.Font.SetStyle(0);
                c1.Font.Size = 28;
            

                Chunk c2 = new Chunk("FIRST HOLY COMMUNION", FontFactory.GetFont(Font.FontFamily.TIMES_ROMAN.ToString()));
                c2.Font.Size = 23;


                Chunk c3 = new Chunk(officialname + "("+ baptismname + ") received the Holy Eucharist for the first time", FontFactory.GetFont(Font.FontFamily.TIMES_ROMAN.ToString(),Font.ITALIC, BaseColor.BLACK));
                c3.Font.Size = 14;
           

              Chunk c4 = new Chunk("on " + docommunion, FontFactory.GetFont(Font.FontFamily.TIMES_ROMAN.ToString(), Font.ITALIC, BaseColor.BLACK));
              c4.Font.Color = new iTextSharp.text.BaseColor(0, 0, 0);
              c4.Font.SetStyle(0);
              c4.Font.Size = 14;
            Chunk c5 = new Chunk(" at " + parishname, FontFactory.GetFont(Font.FontFamily.TIMES_ROMAN.ToString(), Font.ITALIC, BaseColor.BLACK));
            c5.Font.Color = new iTextSharp.text.BaseColor(0, 0, 0);
            c5.Font.SetStyle(0);
            c5.Font.Size = 12;


            Chunk c6 = new Chunk("Blessed By " + priestname, FontFactory.GetFont(Font.FontFamily.TIMES_ROMAN.ToString(), Font.ITALIC, BaseColor.BLACK));
            c6.Font.Color = new iTextSharp.text.BaseColor(0, 0, 0);
            c6.Font.SetStyle(0);
            c6.Font.Size = 14;


            Phrase phnew1 = new Phrase();
                phnew1.Add(c1);

                Phrase phnew2 = new Phrase();
                phnew2.Add(c2);

                Phrase phnew3 = new Phrase();
                phnew3.Add(c3);
           
               Phrase phnew4= new Phrase();
               phnew4.Add(c4);

            Phrase phnew5 = new Phrase();
            phnew5.Add(c5);
            Phrase phnew6 = new Phrase();
            phnew6.Add(c6);

            Paragraph pnew1 = new Paragraph();
               pnew1.Add(phnew1);
               pnew1.Alignment = Element.ALIGN_CENTER;
             
               Paragraph pnew2 = new Paragraph();
               pnew2.Add(phnew2);
               pnew2.Alignment = Element.ALIGN_CENTER;
               pnew2.SpacingBefore = 10;

            

            Paragraph pnew3 = new Paragraph();
            pnew3.Add(phnew3);
            pnew3.Alignment = Element.ALIGN_JUSTIFIED;
           
            Paragraph pnew4 = new Paragraph();
            pnew4.Add(phnew4);
            pnew4.Alignment = Element.ALIGN_CENTER;

            Paragraph pnew5 = new Paragraph();
            pnew5.Add(phnew5);
            pnew5.Alignment = Element.ALIGN_CENTER;
            Paragraph pnew6 = new Paragraph();
            pnew6.Add(phnew6);
            pnew6.Alignment = Element.ALIGN_CENTER;

            Paragraph p7 = new Paragraph(new Phrase(new Chunk("Signed by")));
            p7.Alignment = Element.ALIGN_CENTER;
            doc.Add(p_space_image);
            doc.Add(pnew1);
            doc.Add(Chunk.NEWLINE);
            doc.Add(pnew2);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(pnew3);
            doc.Add(Chunk.NEWLINE);
            doc.Add(pnew4);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(pnew5);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(pnew6);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(p7);
            doc.Close();
            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment;filename=Report.pdf");
            Response.Write(doc);
            Response.Flush();
            Response.End();
         //   Response.Write("<script>alert('successfull downloaded');</script>");
            }
    }
}

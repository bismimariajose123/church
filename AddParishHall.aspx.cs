using Diocese.Project_Code.SubAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diocese
{
    public partial class AddParishHall : System.Web.UI.Page
    {

        Parish_HallBO objParish_HallBO = new Parish_HallBO();
        Parish_HallBLL objParish_HallBLL = new Parish_HallBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            objParish_HallBO.parishid = Convert.ToInt32(Session["parishid"].ToString());

            if (!IsPostBack)
            {
                Load_HallNo();
            }
        }
         public void Load_HallNo()
          {
            objParish_HallBO=objParish_HallBLL.GetHallNo(objParish_HallBO);
            TBHallNO.Text = objParish_HallBO.hallno.ToString();
          }

        protected void BtnaddHall_Click(object sender, EventArgs e)
        {
            objParish_HallBO.Hallname = TBHallName.Text;
            objParish_HallBO.People_count = Convert.ToInt32(TBNobr_People.Text);
            objParish_HallBO.BookesStatus = 0;
            objParish_HallBO.rate = TBRate.Text;
            objParish_HallBO.hallno = Convert.ToInt32(TBHallNO.Text);
            int result=objParish_HallBLL.AddHall(objParish_HallBO);
            Response.Redirect("AddParishHall.aspx");
        }
    }
}
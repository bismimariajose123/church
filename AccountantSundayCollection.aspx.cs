using Diocese.Project_Code.Accountant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diocese
{
    public partial class AccountantSundayCollection : System.Web.UI.Page
    {
        AccountantBO objAccountantBO = new AccountantBO();
        AccountantBLL objAccountantBLL = new AccountantBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

           if( Session["parishid"].ToString()==null)
            {
                Response.Redirect("Logout.aspx");
            }
            else
            {
                objAccountantBO.Parishid1 = Convert.ToInt32(Session["parishid"].ToString());
            }
        }

        protected void BtnSundayCollection_Click(object sender, EventArgs e)  //ADD SUNDAY COLLECTION TO COLLECTION_SUNDAY_TABLE
        {
            try {
                objAccountantBO.Amount1 = Convert.ToInt64(TBAmount.Text.ToString());
                string h =Dobhidden.Value;
              

                DateTime dt = DateTime.Parse(h); 
                objAccountantBO.SundayCollectionDate1 = dt;
                objAccountantBO.SC_BalanceAmount1 = objAccountantBO.Amount1;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            int result = objAccountantBLL.AddSundayCollection(objAccountantBO);
            Response.Redirect("AccountantSundayCollection.aspx");
        }
    }
}
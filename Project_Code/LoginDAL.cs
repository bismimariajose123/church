using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code
{
    public class LoginDAL
    {
         string ConnectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
       
        public DataTable CheckLogin(LoginBO objLoginBO)
        {
               
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            DataTable dt = new DataTable();
           
            SqlDataReader dr,dr2;
            string query = string.Empty;
            //= "select * from Sup_ParishTable where Username='"+objLoginBO.username+ "'and Password='"+objLoginBO.Pwd+ "' and Parish_ID='"+objLoginBO.Parishid+"'";
            if (objLoginBO.User_type == 1)
            {

            }
            else if (objLoginBO.User_type == 2)
            {
                //subadmin
                query = "select * from Sup_ParishTable where Username='" + objLoginBO.username + "'and Password='" + objLoginBO.Pwd + "' and Parish_ID=" + objLoginBO.Parishid + "";
                string query_Priestname = "select Parish_Priest_Name from Sup_PriestTable where Current_Parish_id=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlCommand cmd_priestname = new SqlCommand(query_Priestname, con);
                cmd_priestname.Parameters.AddWithValue("@id",Convert.ToInt32(objLoginBO.Parishid));
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();

                    dt.Columns.Add("username", typeof(string));
                    dt.Columns.Add("password", typeof(string));
                    dt.Columns.Add("Parishid",typeof(Int32));
                    dt.Rows.Add(dr["Username"].ToString(), dr["Password"].ToString(), Convert.ToInt32(dr["Parish_ID"].ToString()));
                    int i = dt.Rows.Count;
                    dr.Close();
                    dr2 = cmd_priestname.ExecuteReader();
                    if(dr2.HasRows)
                    {
                        dr2.Read();
                        objLoginBO.Personname = dr2["Parish_Priest_Name"].ToString();
                        
                    }
                    dr2.Close();
                }
            }
            else if (objLoginBO.User_type == 3)
            {
                ////member
                //query = "select * from Sup_ParishTable where Username='" + objLoginBO.username + "'and Password='" + objLoginBO.Pwd + "' and Parish_ID=" + objLoginBO.Parishid + "";

                //SqlCommand cmd = new SqlCommand(query, con);
                // dr = cmd.ExecuteReader();

            }
            
            return dt;
        }
    }
}
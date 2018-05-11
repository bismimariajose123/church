using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code
{
    public class LoginDAL2
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public int CheckLogin(LoginBO objLoginBO)
        {
            int result = 0;
            if(objLoginBO.User_type==1)
            {
                result=1;
            }
            else if(objLoginBO.User_type == 2)
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                try {
                    string query = "select count(*) from Sup_ParishTable where Username='"+ objLoginBO.username +"'and Password='"+ objLoginBO.Pwd + "' and Parish_ID="+objLoginBO.Parishid;
                    SqlCommand cmd = new SqlCommand(query, con);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if(count==1)
                    {
                       
                        string query2= "select Parish_Priest_Name from Sup_PriestTable where Current_Parish_id="+objLoginBO.Parishid;
                        SqlCommand cmd_priestname = new SqlCommand(query2,con);
                        SqlDataReader dr = cmd_priestname.ExecuteReader();
                        if(dr.HasRows)
                        {
                            dr.Read();
                            result = 1;
                            objLoginBO.Personname = dr["Parish_Priest_Name"].ToString();
                        }
                        
                        else
                        {
                            result = 0;
                        }
                        dr.Close();
                    }
                    else
                    {
                        result = 0;
                    }
                }

                catch (Exception e)
                {
                    throw e;
                }

            }
            else if (objLoginBO.User_type == 3)
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("select count(*) from Sub_Create_FamilyLoginTable where Username=@Username and Password=@Password and Parish_id=@Parish_ID", con);
                    cmd.Parameters.AddWithValue("@Username", objLoginBO.username);
                    cmd.Parameters.AddWithValue("@Password", objLoginBO.Pwd);
                    cmd.Parameters.AddWithValue("@Parish_ID", objLoginBO.Parishid);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 1)
                    {

                        string query2 = "select family_id,HeadName from Sub_Create_FamilyLoginTable where Username='"+ objLoginBO.username+"' and Password='"+objLoginBO.Pwd+"' and Parish_id="+objLoginBO.Parishid;
                        SqlCommand cmd_Headname = new SqlCommand(query2, con);
                       
                        SqlDataReader dr = cmd_Headname.ExecuteReader();
                        if (dr.HasRows)
                        {
                            dr.Read();
                            result = 1;
                            objLoginBO.Personname = dr["HeadName"].ToString();
                            objLoginBO.Familyid = Convert.ToInt32(dr["family_id"].ToString());
                        }
                        else
                        {
                            result = 0;
                        }
                        dr.Close();
                    }
                    else
                    {
                        result = 0;
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
            else if (objLoginBO.User_type == 4)
            {

            }
            else
            {
                result = 0;
            }


            return result;
        }
    }
}
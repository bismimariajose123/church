using Diocese.Project_Code.SubAdmin;
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
            if(objLoginBO.User_type==1)  //superAdmin
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                
                    string query = "select count(*) from SuperAdminLoginTable where Username='" + objLoginBO.username + "' and Password='" + objLoginBO.Pwd + "' and IsActive=1";
                    SqlCommand cmd = new SqlCommand(query, con);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 1)
                    {
                    return result = 1;
                    }
                else
                {
                    return result = 0;
                }
                        
            }
            else if(objLoginBO.User_type == 2)   //subadmin
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
            else if (objLoginBO.User_type == 3)  //Member
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
            else if (objLoginBO.User_type == 4) //non parish member or guest
            {

                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("select count(*) from NonMemberLoginTable where Uname=@Username and Pwd=@Password and To_Parishid=@Parish_ID", con);
                    cmd.Parameters.AddWithValue("@Username", objLoginBO.username);
                    cmd.Parameters.AddWithValue("@Password", objLoginBO.Pwd);
                    cmd.Parameters.AddWithValue("@Parish_ID", objLoginBO.Parishid);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 1)
                    {

                        string query2 = "select NonMember_id,OfficialName from NonMemberLoginTable where Uname='" + objLoginBO.username + "' and Pwd='" + objLoginBO.Pwd + "' and To_Parishid=" + objLoginBO.Parishid;
                        SqlCommand cmd_Headname = new SqlCommand(query2, con);

                        SqlDataReader dr = cmd_Headname.ExecuteReader();
                        if (dr.HasRows)
                        {
                            dr.Read();
                            result = 1;
                            objLoginBO.Personname = dr["OfficialName"].ToString();
                            objLoginBO.Familyid = Convert.ToInt32(dr["NonMember_id"].ToString());
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
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            else if(objLoginBO.User_type == 5) //accountant
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                try
                {
                    string query = "select count(*) from ResponsibilityTable where uname='" + objLoginBO.username + "'and pwd='" + objLoginBO.Pwd + "' and Parishid=" + objLoginBO.Parishid;
                    SqlCommand cmd = new SqlCommand(query, con);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 1)
                    {

                        string query2 = "select Responsibilityd,DutyName from ResponsibilityTable where uname='" + objLoginBO.username + "'and pwd='" + objLoginBO.Pwd + "' and Parishid=" + objLoginBO.Parishid;
                        SqlCommand cmd_Headname = new SqlCommand(query2, con);

                        SqlDataReader dr = cmd_Headname.ExecuteReader();
                        if (dr.HasRows)
                        {
                           
                            dr.Read();
                            result = 1;

                            objLoginBO.Familyid = Convert.ToInt32(dr["Responsibilityd"].ToString());    //here familyid as  Responsibilityd id
                            objLoginBO.Personname =dr["DutyName"].ToString(); //here personname as dutyname
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
            else
            {
                result = 0;
            }


            return result;
        }
    }
}
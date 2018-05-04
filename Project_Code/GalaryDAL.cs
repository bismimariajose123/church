using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code
{
    public class GalaryDAL
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public DataTable Get_Priest_Images()
        {

            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Sup_PriestTable", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Get_Clicked_Priest_Detail(int priestid)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select pt.Parish_Id,pt.Priest_Id,p.Parish_Name,pp.Parish_Priest_Name,pp.Designation,pp.Native_Place,pp.OrdinationDate,pp.Phone_No,pp.Parish_Priest_Image from Sup_Priest_TransferTable pt,Sup_ParishTable p,Sup_PriestTable pp where pt.Priest_Id=pp.Parish_Priest_ID and pt.Parish_Id=p.Parish_ID and pt.Priest_Id="+priestid, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        
    }
}
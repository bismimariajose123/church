using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.SubAdmin
{
    public class Parish_HallDAL
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        public Parish_HallBO GetHallNo(Parish_HallBO objParish_HallBO)
        {
            int result = 0;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmdcheck = new SqlCommand("select * from Sub_ParishHallTable where ParishId=" + objParish_HallBO.parishid, con);
            SqlDataReader dr1 = cmdcheck.ExecuteReader();
            if (dr1.HasRows)
            {
                dr1.Read();
                result = 1;
            }

            dr1.Close();

            if (result == 1)
            {
                SqlCommand cmdSelect = new SqlCommand("select max(HallNo) from Sub_ParishHallTable where ParishId=" + objParish_HallBO.parishid, con);
                int hallno = Convert.ToInt32(cmdSelect.ExecuteScalar());
                objParish_HallBO.hallno = hallno + 1;
            }
            else
            {
                objParish_HallBO.hallno = 1;
            }

            return objParish_HallBO;

        }

       public int UpdateParishHall(Parish_HallBO objParish_HallBO, int id)
        {
            int result;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("update Sub_ParishHallTable set HallName=@HallName,No_of_people=@No_of_people,Rate=@Rate where Hall_ID=@id", con);
            cmd.Parameters.AddWithValue("@HallName", objParish_HallBO.Hallname);
            cmd.Parameters.AddWithValue("@No_of_people", objParish_HallBO.People_count);
            cmd.Parameters.AddWithValue("@Rate", objParish_HallBO.rate);

            cmd.Parameters.AddWithValue("@id", id);
            result = cmd.ExecuteNonQuery();
            return result;
        }

        public int Delete_ParishHall(int id)
        {
            int result;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Sub_ParishHallTable where Hall_ID=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public DataTable GetParishHallDetails(Parish_HallBO objParish_HallBO)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Sub_ParishHallTable where ParishId=@id", con);
            cmd.Parameters.AddWithValue("@id", objParish_HallBO.parishid);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public int AddHall(Parish_HallBO objParish_HallBO)
        {
            int result;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Sub_ParishHallTable values(@HallName,@ParishId,@HallNo,@No_of_people,@Booked_status,@Rate)", con);

            try
            {
                cmd.Parameters.AddWithValue("@HallName", objParish_HallBO.Hallname);
                cmd.Parameters.AddWithValue("@ParishId", objParish_HallBO.parishid);
                cmd.Parameters.AddWithValue("@HallNo", objParish_HallBO.hallno);
                cmd.Parameters.AddWithValue("@No_of_people", objParish_HallBO.People_count);
                cmd.Parameters.AddWithValue("@Booked_status", objParish_HallBO.BookesStatus);
                cmd.Parameters.AddWithValue("@Rate", objParish_HallBO.rate);
                result = cmd.ExecuteNonQuery();

            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
            return result;
        }
    }
}
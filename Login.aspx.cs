using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.Security;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();
        Session.Clear();       
    }

    protected void ps_TextChanged(object sender, EventArgs e)
    {

    }

    protected void pass_TextChanged(object sender, EventArgs e)
    {

    }

    protected void sin_Click(object sender, EventArgs e)
    {
        if (ps.Text !="" && pass.Text !="")
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conf"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from admin where PsNo='" + ps.Text.ToString() + "'AND password='" + pass.Text.ToString() + "'", con);
            SqlCommand cmd1 = new SqlCommand("select * from Master left join employee on Master.AsNo=employee.PsNo WHERE Master.AsNo='" + ps.Text.ToString() + "' and employee.password='" + pass.Text.ToString() + "'", con);
            SqlCommand cmd2 = new SqlCommand("select * from employee where PsNo='" + ps.Text.ToString() + "'AND password='" + pass.Text.ToString() + "'", con);

            cmd.Parameters.AddWithValue("@PsNo", ps.Text.ToString());
            cmd.Parameters.AddWithValue("@password", pass.Text.ToString());
            SqlDataReader reader = cmd.ExecuteReader();



            if (reader.Read())
            {
                
                    Session["PsNo"] = Convert.ToInt32(reader["PsNo"].ToString());
                    Session["Name"] = reader["Name"].ToString();
                    Session["email"] = reader["email"].ToString();
                    Response.Redirect("Admin.aspx");
                    Session["Role"] = "Admin";
                    con.Close();
             
               
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('PsNo. or Password Incorrect');", true);
                Response.ClearHeaders();
                Response.AddHeader("Cache-Control", "no-cache, no-store, max-age=0, must-revalidate");
                Response.AddHeader("Pragma", "no-cache");
            }
            reader.Close();
            reader = cmd1.ExecuteReader();

            if (reader.Read())
            {
                // Response.Redirect("test1.aspx?val=" + count);

                Session["PsNo"] = Convert.ToInt32(reader["AsNo"].ToString());
                Session["Name"] = reader["Name"].ToString();
                Session["email"] = reader["email"].ToString();
                Response.Redirect("useradmin.aspx");
                Session["Role"] = "UserAdmin";
                con.Close();
               

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('PsNo. or Password Incorrect');", true);
                Response.ClearHeaders();
                Response.AddHeader("Cache-Control", "no-cache, no-store, max-age=0, must-revalidate");
                Response.AddHeader("Pragma", "no-cache");  
            }
            reader.Close();
            reader = cmd2.ExecuteReader();

            if (reader.Read())
            {
                // Response.Redirect("test1.aspx?val=" + count);
               
                    Session["PsNo"] = Convert.ToInt32(reader["PsNo"].ToString());
                    Session["Name"] = reader["Name"].ToString();
                    Session["email"] = reader["email"].ToString();
                    Response.Redirect("Default3.aspx");
                    Session["Role"] = "User";
                    con.Close();
     
                
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('PsNo. or Password Incorrect');", true);
                Response.ClearHeaders();
                Response.AddHeader("Cache-Control", "no-cache, no-store, max-age=0, must-revalidate");
                Response.AddHeader("Pragma", "no-cache");
            }         

        }
        
        else 
           {

            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('PsNo. or Password Is Missing!');", true);

           }

    } 
}


 /*
           SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conf"].ConnectionString);
           con.Open();
           SqlCommand cmd = new SqlCommand("Select * from employee where PsNo = @PsNo and password = @password", con);
           cmd.Parameters.AddWithValue("@PsNo", ps.Text.ToString());
           cmd.Parameters.AddWithValue("@password", pass.Text.ToString());
           SqlDataReader reader = cmd.ExecuteReader();
           Session["PsNo"] = Convert.ToInt32(reader["PsNo"].ToString());
           Session["Name"] = reader["Name"].ToString();
           Session["email"] = reader["email"].ToString(); 






        //main admin
        string admin = "select * from admin where PsNo='" + ps.Text.ToString() + "' password='" + pass.Text.ToString() + "'";
        SqlDataAdapter ma = new SqlDataAdapter(admin, con);
        DataTable DTT1 = new DataTable();
        ma.Fill(DTT1);

        //secondary admin
        string useradmin = "select * from Master WHERE AsNo= '" + ps.Text.ToString() + "'";
        SqlDataAdapter ua = new SqlDataAdapter(useradmin, con);
        DataTable DTT2 = new DataTable();
        ua.Fill(DTT2);

        //employee
        string employee = "select * from employee where PsNo='" + ps.Text.ToString() + "' password='" + pass.Text.ToString() + "'";
        SqlDataAdapter em = new SqlDataAdapter(employee, con);
        DataTable DTT3 = new DataTable();
        ua.Fill(DTT3);

        if (DTT1.Rows.Count > 0)
        {
            Session["PsNo"] = Convert.ToInt32(reader["PsNo"].ToString());
            Session["Name"] = reader["Name"].ToString();
            Session["email"] = reader["email"].ToString();
            reader.Close();
            cmd.Dispose();



            Response.Redirect("Admin.aspx");
            con.Close();
        }
        else
        {
            if (DTT2.Rows.Count > 0)
            {
                Session["PsNo"] = Convert.ToInt32(reader["PsNo"].ToString());
                Session["Name"] = reader["Name"].ToString();
                Session["email"] = reader["email"].ToString();
                reader.Close();
                cmd.Dispose();



                Response.Redirect("Admin.aspx");
                con.Close();
            }

            else
            {
                Session["PsNo"] = Convert.ToInt32(reader["PsNo"].ToString());
                Session["Name"] = reader["Name"].ToString();
                Session["email"] = reader["email"].ToString();
                reader.Close();
                cmd.Dispose();


                Response.Redirect("Default3.aspx");
                con.Close();
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('PsNo. or Password Incorrect');", true);


            }

        }

    } */


/*

        if (reader.Read())
        {
            if (ps.Text == "0" && pass.Text == "admin")
            {
                Response.Redirect("Admin.aspx");
            }
            else
            {
                SqlConnection kkr = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234;pooling=false");
                kkr.Open();
                string query = "select * from Master WHERE AsNo= '" + ps.Text.ToString() + "'";
                SqlDataAdapter SDA = new SqlDataAdapter(query, kkr);
                DataTable DTT = new DataTable();
                SDA.Fill(DTT);



                if (DTT.Rows.Count > 0)
                {
                    Session["PsNo"] = Convert.ToInt32(reader["PsNo"].ToString());
                    Session["Name"] = reader["Name"].ToString();
                    Session["email"] = reader["email"].ToString();
                    reader.Close();
                    cmd.Dispose();



                    Response.Redirect("Admin.aspx");
                    con.Close();
                }



                else
                {
                    Session["PsNo"] = Convert.ToInt32(reader["PsNo"].ToString());
                    Session["Name"] = reader["Name"].ToString();
                    Session["email"] = reader["email"].ToString();
                    reader.Close();
                    cmd.Dispose();


                    Response.Redirect("Default3.aspx");
                    con.Close();
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('PsNo. or Password Incorrect');", true);

                }
            }

        }


    }


}

    */













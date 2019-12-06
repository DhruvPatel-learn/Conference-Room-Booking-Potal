using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        mybookings();

        if (Session["PsNo"] == null)
        { Response.Redirect("Login.aspx"); }
        else
        {
            String PsNo = Convert.ToString((int)Session["PsNo"]);
            String Name = Session["Name"].ToString();
            String email = Session["email"].ToString();
            txtno.Text = PsNo;
            TextBox4.Text = Name;
            TextBox5.Text = email;


        }

        if (txtno.Text != "")
        {
            SqlConnection SQLConn = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234");
            SQLConn.Open();
            string query = "select * from source where Name='" + TextBox4.Text + "'";
            SqlDataAdapter SDA = new SqlDataAdapter(query, SQLConn);
            DataTable DTT = new DataTable();
            SDA.Fill(DTT);
            GridView1.DataSource = DTT;
            GridView1.DataBind();

            SQLConn.Close();
            mybookings();

        }






    }



    public void mybookings()
    {

        SqlConnection pro = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234");
        pro.Open();
        string qwest = "select * from source where Name='" + TextBox4.Text + "'";
        SqlDataAdapter Sata = new SqlDataAdapter(qwest, pro);
        DataTable det = new DataTable();
        Sata.Fill(det);
        GridView1.DataSource = det;
        GridView1.DataBind();
        pro.Close();

        /*   if (GridView1.Rows.Count > 0)
           {

           }
           else
           {
               ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert(' No Bookings requested');", true);
           } */

    }




    protected void Unnamed_Click(object sender, EventArgs e)
    {
        SqlConnection pro = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234;pooling=false");
        pro.Open();

        string qwest = "select * from source WHERE Status='Approved' and PsNo='" + txtno.Text + "' and  date ='" + DateTime.Today.ToString("dd/MM/yyyy").Replace('-', '/') + "'";
        SqlDataAdapter sp = new SqlDataAdapter(qwest, pro);
        DataTable det = new DataTable();
        sp.Fill(det);
        if (det.Rows.Count > 0)
        {
            Response.Redirect("Checkin_out.aspx");
            pro.Close();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", "alert('No Conference Room Is Booked For Today!');", true);

        }








    }

    protected void Unnamed_Click1(object sender, EventArgs e)
    {

        //redirect to index page
        Session.Abandon();
        Session["PsNo"] = null;
        Session["Name"] = null;
        Session["email"] = null;
        Session["password"] = null;
        Response.Redirect("Login.aspx");

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection SQLConn = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234");
        SQLConn.Open();
        string query = "select * from source where Name='" + TextBox4.Text + "'";
        SqlDataAdapter SDA = new SqlDataAdapter(query, SQLConn);
        DataTable DTT = new DataTable();
   
        SDA.Fill(DTT);

      
        SQLConn.Close();
    }

    protected void GridView1_RowDeleting1(object sender, GridViewDeleteEventArgs e)
    {
        SqlConnection SQLConn = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234");
        SQLConn.Open();

          string query = "Delete from Source WHERE eid='"+ GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
          SqlDataAdapter SDA = new SqlDataAdapter(query, SQLConn);
          DataTable DTT = new DataTable();
          SDA.Fill(DTT);

          GridView1.DataSource = DTT;

          GridView1.DataBind();

        mybookings();


    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        mybookings();
    }









    protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {

           e.Row.Cells[10].Visible = false;
            e.Row.Cells[11].Visible = false;

            e.Row.Cells[1].Visible = false; }


         //   for (int colIndex = 1; colIndex < e.Row.Cells.Count; colIndex++)
            //{

                /* if (e.Row.RowType == DataControlRowType.Header)
                 {
                     e.Row.Cells[1].Visible = false;
                 }
                 if (e.Row.RowType == DataControlRowType.DataRow)
                 {
                     e.Row.Cells[1].Visible = false;
                 }*/
    }





    protected void Unnamed_Click2(object sender, EventArgs e)
    {
        Response.Redirect("Default3.aspx");
    }
}

















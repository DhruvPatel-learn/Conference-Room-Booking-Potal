using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Net;

public partial class Checkin_out : System.Web.UI.Page
{



    protected void Page_Load(object sender, EventArgs e)
    {





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
            // txtno.Text = "postback";

        }

        if (!IsPostBack)
        {
            mybookings();
        }

        if (txtno.Text != "")
        {
            /* SqlConnection SQLConn = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234;pooling=false");
             SQLConn.Open();
             string query = "select * from source WHERE Status=' Approved' and PsNo='" + txtno.Text + "'";

             SqlDataAdapter SDA = new SqlDataAdapter(query, SQLConn);
             DataTable DTT = new DataTable();
             SDA.Fill(DTT);
             GridView1.DataSource = DTT;
             GridView1.DataBind();

             SQLConn.Close();*/
            //  mybookings();

        }

    }

    public void mybookings()
    {

        SqlConnection pro = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234;pooling=false");
        pro.Open();

        string qwest = "select * from source WHERE Status='Approved' and PsNo='" + txtno.Text + "' and  date ='" + DateTime.Today.ToString("dd/MM/yyyy").Replace('-', '/') + "'";
        SqlDataAdapter sp = new SqlDataAdapter(qwest, pro);
        DataTable det = new DataTable();
        sp.Fill(det);
        if (det.Rows.Count > 0)
        {
            GridView1.DataSource = det;
            GridView1.DataBind();

            pro.Close();
        }
        else
        {
            Check_In.Visible = false;
            Check_Out.Visible = false;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('You've Not Made Any Reservstions!');", true);
        }
    }




    protected void Unnamed_Click(object sender, EventArgs e)
    {
        //redirect to index page
        Session.Abandon();
        Session["PsNo"] = null;
        Session["Name"] = null;
        Session["email"] = null;
        Session["password"] = null;
        Response.Redirect("Login.aspx");
    }

    protected void Unnamed_Click1(object sender, EventArgs e)
    {
        Response.Redirect("My Bookings.aspx");
    }

    protected void rid_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default3.aspx");
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {

            //  e.Row.Cells[10].Visible = false;
            // e.Row.Cells[0].Visible = false;
            //  e.Row.Cells[9].Visible = false;
            // e.Row.Cells[11].Visible = false;
            //
            // e.Row.Cells[1].Visible = false;
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;

    }


    protected void Check_In_Click(object sender, EventArgs e)
    {


        DateTime checkin_time, user_defined_checkin_time;
        checkin_time = System.DateTime.Now;

        int counter = 0;

        foreach (GridViewRow gvrow in GridView1.Rows)
        {
            CheckBox chk = (CheckBox)gvrow.FindControl("CheckBox1");

            if (chk.Checked)
            {
                counter++;

            }
            // else { ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert(' "+gvrow.Cells[1].Text+"');", true); }
        }

        if (counter > 1)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert(' select only one');", true);
        }
        else if (counter < 1)
        {
            //   ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert(' Please select one request!');", true);

        }
        else if (counter == 1)
        {
            foreach (GridViewRow gvrow in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("CheckBox1");

                if (chk.Checked && gvrow.Cells[9].Text.ToString().Equals("&nbsp;"))

                {


                    user_defined_checkin_time = DateTime.ParseExact(gvrow.Cells[6].Text.ToString(), "HH:mm:ss", null);
                    TimeSpan ts = checkin_time.Subtract(user_defined_checkin_time);

                    if (Math.Abs(ts.TotalMinutes) < 15)

                    {



                        SqlConnection SQLConn = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234;pooling=false");
                        SQLConn.Open();
                        string query = "update SOURCE set uc='" + DateTime.Now.ToShortTimeString() + "' WHERE eid='" + Convert.ToInt32(gvrow.Cells[1].Text) + "'";
                        SqlCommand SDA = new SqlCommand(query, SQLConn);
                        SDA.ExecuteNonQuery();
                        SDA.Dispose();
                        mybookings();
                        // ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('You Have Successfully Checked-In Your Booked Conferrence Room!');", true);
                        // Page.ClientScript.RegisterStartupScript(this.GetType(), "Call", "checkInJs(); ", true);

                        SQLConn.Close();

                        SqlConnection proe = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234;pooling=false");
                        proe.Open();
                        string url = "select url from IOT where ConfRoom ='" + gvrow.Cells[5].Text.ToString() + "'";
                        SqlDataAdapter spi = new SqlDataAdapter(url, proe);
                        DataTable det = new DataTable();
                        spi.Fill(det);

                        if (det.Rows.Count > 0)
                        {

                            url = det.Rows[0]["url"].ToString();
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Call", " checkInJs('" + url + "')", true);
                            proe.Close();
                        }


                    }
                    else
                    {


                        SqlConnection bjp = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234;pooling=false");
                        bjp.Open();
                        string query = "update SOURCE set Status='Booking Canceled ' WHERE eid='" + Convert.ToInt32(gvrow.Cells[1].Text) + "'";
                        SqlCommand SDA = new SqlCommand(query, bjp);
                        SDA.ExecuteNonQuery();
                        SDA.Dispose();
                        mybookings();

                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('Your Booking Has Been Canceled!');", true);
                    }


                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('You Already checked In !');", true);

                }





            }

        }

    }

    protected void Check_Out_Click(object sender, EventArgs e)
    {
        DateTime checkout_time, user_defined_checkout_time;
        checkout_time = System.DateTime.Now;

        int counter = 0;

        foreach (GridViewRow gvrow in GridView1.Rows)
        {
            CheckBox chk = (CheckBox)gvrow.FindControl("CheckBox1");

            if (chk.Checked)
            {
                counter++;

            }

        }

        if (counter > 1)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert(' select only one');", true);
        }
        else if (counter < 1)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert(' Please select one request!');", true);

        }
        else if (counter == 1)
        {
            foreach (GridViewRow gvrow in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("CheckBox1");

                if (chk.Checked && gvrow.Cells[10].Text.ToString().Equals("&nbsp;"))

                {

                    user_defined_checkout_time = DateTime.ParseExact(gvrow.Cells[7].Text.ToString(), "HH:mm:ss", null);
                    TimeSpan ts = checkout_time.Subtract(user_defined_checkout_time);

                    if (Math.Abs(ts.TotalMinutes) <= 15 && gvrow.Cells[10].Text.ToString().Equals("&nbsp;"))

                    {

                        SqlConnection SQLConn = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234;pooling=false");
                        SQLConn.Open();
                        string query = "update SOURCE set uo='" + DateTime.Now.ToShortTimeString() + "' WHERE eid='" + Convert.ToInt32(gvrow.Cells[1].Text) + "'";
                        SqlCommand SDA = new SqlCommand(query, SQLConn);
                        SDA.ExecuteNonQuery();
                        SDA.Dispose();
                        mybookings();
                        SQLConn.Close();

                        SqlConnection co = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234;pooling=false");
                        co.Open();
                        string urlo = "select urlo from IOT where ConfRoom ='" + gvrow.Cells[5].Text.ToString() + "'";
                        SqlDataAdapter spi = new SqlDataAdapter(urlo, co);
                        DataTable dot = new DataTable();
                        spi.Fill(dot);

                        if (dot.Rows.Count > 0)
                        {

                            urlo = dot.Rows[0]["urlo"].ToString();
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Call", " checkOutJs('" + urlo + "')", true);
                            co.Close();
                            // GridView1.Visible = false;
                            //Check_In.Visible = false;
                            //Check_Out.Visible = false;

                        }




                        else
                        {


                            SqlConnection SQLCont = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234;pooling=false");
                            SQLCont.Open();
                            string neeew = "update SOURCE set uo='Check-Out Early/Delayed:'+'" + DateTime.Now.ToShortTimeString() + "' WHERE eid='" + Convert.ToInt32(gvrow.Cells[1].Text) + "'";
                            SqlCommand SD = new SqlCommand(neeew, SQLCont);
                            SD.ExecuteNonQuery();
                            SD.Dispose();
                            mybookings();


                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('You've Checked - Out Late/Early!');", true);
                        }


                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('You Already checked Out!');", true);
                        GridView1.Visible = false;
                        Check_In.Visible = false;
                        Check_Out.Visible = false;
                    }





                }

            }
        }



    }


}
   
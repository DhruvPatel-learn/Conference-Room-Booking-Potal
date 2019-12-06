using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Default3 : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
      
            ShowData();
     
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

            TextBox1.Attributes.Add("readonly", "readonly");
            Calendar1.StartDate = DateTime.Today;
            Calendar1.EndDate = DateTime.Today.AddDays(15);

        }



        if (!IsPostBack)


        {

            if (Session["PsNo"] == null)

            {

                Response.Redirect("Login.aspx");
                TextBox1.Attributes.Add("readonly", "readonly");
                Calendar1.StartDate = DateTime.Today;
                Calendar1.EndDate = DateTime.Today.AddDays(15);
            }
        }


        if (!IsPostBack)
        {

            string CS = System.Configuration.ConfigurationManager.ConnectionStrings["conf"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select ConfRoom from Master where RoomSt='Available'", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                DropDownList1.DataTextField = "ConfRoom";
                DropDownList1.DataValueField = "ConfRoom";
                DropDownList1.DataSource = rdr;
                DropDownList1.DataBind();
            }

            DropDownList1.Items[0].Attributes.Add("disabled", "disabled");

        }




    }


    public void ShowData()
    {

        SqlConnection pro = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234;pooling=false");
        pro.Open();
        string qwest = "select * from source where Date='" + TextBox1.Text + "' and Confroom='" + DropDownList1.SelectedItem.ToString() + "' and Status='Approved'";
        SqlDataAdapter Sata = new SqlDataAdapter(qwest, pro);
        DataTable det = new DataTable();
        Sata.Fill(det);
        GridView1.DataSource = det;
        GridView1.DataBind();
        pro.Close();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (txtno.Text != "")
        {
           
            SqlConnection SQLConn = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234;pooling=false");
            SQLConn.Open();
            string query = "select * from source where Date='" + TextBox1.Text + "' and Confroom='" + DropDownList1.SelectedItem.ToString() +  "'";
            SqlDataAdapter SDA = new SqlDataAdapter(query, SQLConn);
            DataTable DTT = new DataTable();
            SDA.Fill(DTT);
            GridView1.DataSource = DTT;
            GridView1.DataBind();



            //    TextBox1.Text = GridView1.Rows.Count.ToString();
            if (DTT.Rows.Count > 0)
            {
                //Response.Redirect("test1.aspx?val=" + "done");
                GridView1.DataSource = DTT;
                GridView1.DataBind();
      
                    
   
            }

        }

        if (DropDownList1.SelectedItem.ToString() == "Select confRoom")
        {

          
            id2.Visible = false;
            id1.Visible = true;
            id3.Visible = false;
            id4.Visible = false;
        }

        else if (DropDownList1.SelectedItem.ToString().Trim() == "G1 confRoom")
        {

            id2.Visible = false;
            id1.Visible = true;
            id3.Visible = false;
            id4.Visible = false;

        }
        else if (DropDownList1.SelectedItem.ToString() == "G2 confRoom")
        {
            id4.Visible = false;
            id2.Visible = true;
            id3.Visible = false;
            id1.Visible = false;
        }
        else if (DropDownList1.SelectedItem.ToString() == "G3 confRoom")
        {
            id4.Visible = false;
            id2.Visible = false;
            id3.Visible = true;
            id1.Visible = false;
        }
        else if (DropDownList1.SelectedItem.ToString() == "G4 confRoom")
        {
            id3.Visible = false;
            id2.Visible = false;
            id4.Visible = true;
            id1.Visible = false;
        }



    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        this.TextBox1.Text = this.Calendar1.SelectedDate.ToString();
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        this.Calendar1.Visible = true;
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e) 
{ }
    protected void Button3_Click(object sender, EventArgs e)
    {
        this.Calendar1.Visible = true;
    }
    protected void txtno_TextChanged(object sender, EventArgs e)
    {


        if (IsPostBack)

        {
            SqlConnection SQLConn = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234;pooling=false");


            SqlCommand sql = new SqlCommand("select * from employee where PsNo=@psno", SQLConn);
            sql.Parameters.AddWithValue("@psno", txtno.Text);
            SqlDataAdapter sda = new SqlDataAdapter(sql);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                TextBox4.Text = dt.Rows[0]["Name"].ToString();
                TextBox5.Text = dt.Rows[0]["Email"].ToString();
            }

        }
    }
    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection SQLConn = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234;pooling=false");
        SQLConn.Open();
        string query = "select * from source where Date='" + TextBox1.Text + "' and Confroom='" + DropDownList1.SelectedItem.ToString() + "' ";
        SqlDataAdapter SDA = new SqlDataAdapter(query, SQLConn);
        DataTable DTT = new DataTable();

        SDA.Fill(DTT);


        SQLConn.Close();





    }
    protected void sid_Click(object sender, EventArgs e)
    {

    }
    protected void rid_Click(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedItem.ToString() != DropDownList1.Items[0].ToString() && DropDownList1.SelectedItem.ToString() != "")
        {
            if (TextBox1.Text != "" && TextBox2.Text.ToString() !="" && TextBox3.Text.ToString() != "")

            {
                DateTime x, y;
                x = Convert.ToDateTime(TextBox2.Text);
                y = Convert.ToDateTime(TextBox3.Text);

                int k = DateTime.Compare(x, y);

                if (k < 0)
                {

                    if (GridView1.Rows.Count > 0)
                    {
                        foreach (GridViewRow gr in GridView1.Rows)
                        {
                            string cell_1_Value = gr.Cells[6].Text;
                            string cell_2_Value = gr.Cells[7].Text;
                            // TextBox2.Text = cell_1_Value;
                            //  TextBox3.Text = cell_2_Value;

                            // DateTime t3, t4;

                            DateTime t3 = Convert.ToDateTime(gr.Cells[6].Text.ToString());
                            DateTime t4 = Convert.ToDateTime(gr.Cells[7].Text.ToString());


                            //   TextBox2.Text =x.ToString();
                            //   TextBox3.Text = y.ToString();

                            int c1 = DateTime.Compare(x, t3);
                            int c2 = DateTime.Compare(x, t4);
                            int c3 = DateTime.Compare(y, t3);
                            int c4 = DateTime.Compare(y, t4);

                            // TextBox1.Text = "1";

                            if ((c1 < 0 || c2 > 0) && (c3 < 0 || c4 > 0))
                            {
                                //TextBox1.Text = "2";

                                SqlConnection SQLConn = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234;pooling=false");
                                SQLConn.Open();
                                string query = "INSERT INTO SOURCE(PsNo, Name, Email, Date, Confroom, Checkin,Checkout,Status) VALUES ('" + txtno.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox1.Text + "','" + DropDownList1.SelectedItem.ToString() + "','" + TextBox2.Text + "','" + TextBox3.Text + "','Pending With Approver' )";
                                SqlCommand SDA = new SqlCommand(query, SQLConn);
                                SDA.ExecuteNonQuery();



                                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Your Request Is Successfully Submitted');", true);


                            }
                            else

                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Please Request Another Slot');", true);
                            }



                        }
                    }


                    else
                    {
                        SqlConnection SQLConn = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234;pooling=false");
                        SQLConn.Open();
                        string query = "INSERT INTO SOURCE(PsNo, Name, Email, Date, Confroom, Checkin,Checkout,Status) VALUES ('" + txtno.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox1.Text + "','" + DropDownList1.SelectedItem.ToString() + "','" + TextBox2.Text + "','" + TextBox3.Text + "','Pending With Approver')";
                        SqlCommand SDA = new SqlCommand(query, SQLConn);
                        SDA.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Your Request Is Successfully Submitted');", true);
                    }

                }
                else

                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Select Proper Check-Out Time in 24 Hours Format i.e. 13:00:00');", true);
                }


            }

            else

            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Please Select Check-In/ Check-Out Time!');", true);
            }




        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Please Select Correct Booking Request Parameters');", true);
        }
       







    }
    protected void Unnamed_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Login.aspx");
    }
    protected void Unnamed_Click1(object sender, EventArgs e)
    {     
        Response.Redirect("My Bookings.aspx");
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[9].Visible = false;
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        ShowData();
    }
}

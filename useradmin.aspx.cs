using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class useradmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            approvgrid();
        }
       
        if (Session["PsNo"] == null)
        { Response.Redirect("Login.aspx"); }
        else
        {
            String PsNo = Convert.ToString((int)Session["PsNo"]);
            String Name = Session["Name"].ToString();
            String email = Session["email"].ToString();
            psno.Text = PsNo;
            TextBox4.Text = Name;
            TextBox5.Text = email;
           

}
        
}

    protected void Home_Click(object sender, EventArgs e)
    {
        txtComment.Visible = false;
        txtComment.Text = string.Empty;
        Response.Redirect("Default3.aspx");
    }

    protected void Logout_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }

   

    protected void Reject_Reject_Click(object sender, EventArgs e)
    {
        int count = 0;
        foreach (GridViewRow row in GridView1.Rows)
        {
            if ((row.FindControl("CheckBox1") as System.Web.UI.WebControls.CheckBox).Checked)
            {
                count++;
            }


        }


        if (count > 1)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert(' select only one');", true);
        }
        else if (count < 1)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert(' Please select one request!');", true);

        }
        else if (count == 1)
        {
            Label1.Visible = true;
            submit.Visible = true;
            txtComment.Visible = true;
        }






    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        GridView1.PageIndex = e.NewSelectedIndex;
        approvgrid();
    }

    protected void submit_Click(object sender, EventArgs e)
    {

   
            int count = 0;
            foreach (GridViewRow row in GridView1.Rows)
            {
                if ((row.FindControl("CheckBox1") as System.Web.UI.WebControls.CheckBox).Checked)
                {
                    count++;
                }
            }
          
            if (count == 1)
            {


            {
                foreach (GridViewRow gvrow in GridView1.Rows)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("CheckBox1");

                    if (chk.Checked)

                    {
                        if (txtComment.Text != "")
                        {
                            if (submit.Text != "")
                            {

                                SqlConnection zzz = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234;pooling=false");
                                zzz.Open();
                                string query = "update SOURCE set Status= 'Rejected:' +'" + txtComment.Text.ToString() + "' WHERE eid='" + Convert.ToInt32(gvrow.Cells[1].Text) + "'";
                                SqlCommand SDA = new SqlCommand(query, zzz);
                                SDA.ExecuteNonQuery();



                                SDA.Dispose();

                                approvgrid();
                                Label1.Visible = false;
                                submit.Visible = false;
                                txtComment.Visible = false;
                                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('Request Rejected!');", true);
                                zzz.Close();




                            }
                        }
                        else { ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert(' Please State Valid Reason!');", true); }


                    }
                    else { ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert(' Please Select Request To Proceed!');", true); }

                }
            }
        }
    }

    protected void psno_TextChanged(object sender, EventArgs e)
    {  }

    public void approvgrid()
    {

        SqlConnection xlr = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234;pooling=false");
        xlr.Open();
        string cmd1 = "select * from source right join Master on source.confroom=Master.ConfRoom WHERE source.Status='Pending With Approver' and Master.AsNo='" + Session["PsNo"].ToString() + "'";
        SqlDataAdapter cio = new SqlDataAdapter(cmd1, xlr);
        DataTable det = new DataTable();
        cio.Fill(det);
        if (det.Rows.Count == 0)
        {
            Approve_Request.Visible = false;
            Reject_Reject.Visible = false;
            GridView1.Visible = false;

            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert(' No Conferrence Room Booking Request Is Pending!');", true);
        }
        else
        {
            Approve_Request.Visible = true;
            Reject_Reject.Visible = true;

            GridView1.DataSource = det;
            GridView1.DataBind();
            GridView1.Visible = true;

            xlr.Close();
        }
    }


    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        approvgrid();
    }

    protected void Approve_Request_Click(object sender, EventArgs e)
    {
        int count = 0;
        foreach (GridViewRow row in GridView1.Rows)
        {
            if ((row.FindControl("CheckBox1") as System.Web.UI.WebControls.CheckBox).Checked)
            {
                count++;
            }


        }


        if (count > 1)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert(' Please One Request At A Time! ');", true);
        }

        if (count < 1)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert(' Please Select Request To Proceed!');", true);
        }

        if (count == 1)
        {
            foreach (GridViewRow gvrow in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("CheckBox1");

                if (chk.Checked)

                {


                    SqlConnection SQLConn = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234;pooling=false");
                    SQLConn.Open();
                    string query = "update SOURCE set Status='Approved ' WHERE eid='" + Convert.ToInt32(gvrow.Cells[1].Text) + "'";
                    SqlCommand SDA = new SqlCommand(query, SQLConn);
                    SDA.ExecuteNonQuery();
                    SDA.Dispose();
                    approvgrid();

                    Label1.Visible = false;
                    submit.Visible = false;
                    txtComment.Visible = false;
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('Request Approved!');", true);
                    SQLConn.Close();
                    
                }
                else
                {
                    // Response.Redirect("test1.aspx?val=" + "'" + gvrow.Cells[1].Text + "/");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('Please Select The Request!');", true);
                }
            }
        }

    }
}

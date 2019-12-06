using System;

using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;



public partial class _Default : System.Web.UI.Page
{
   
        protected void Page_Load(object sender, EventArgs e)
    {
 
        SqlConnection SQLConn = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234;pooling=false;pooling=false");

        bindgrid();
        
        if (Session["PsNo"] == null )
        {
           // Response.Redirect("test1.aspx?val=" + "done");
            Response.Redirect("Login.aspx");
        }
        else 
        {
            String PsNo = Convert.ToString((int)Session["PsNo"]);
            txtno.Text = PsNo;
          if (txtno.Text != "")
            {
                SqlCommand sql = new SqlCommand("select * from admin where PsNo='" + txtno.Text + "'", SQLConn);
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
       if (txtno.Text != "")
            {
                SqlCommand sql = new SqlCommand("select * from employee where PsNo='" + txtno.Text + "'", SQLConn);
                sql.Parameters.AddWithValue("@psno", txtno.Text);
                SqlDataAdapter sld = new SqlDataAdapter(sql);
                DataTable dt1 = new DataTable();
                sld.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    TextBox4.Text = dt1.Rows[0]["Name"].ToString();
                    TextBox5.Text = dt1.Rows[0]["Email"].ToString();
                }
            }


            DDLRM1.Items[0].Attributes.Add("disabled", "disabled");
            DropDownList2.Items[0].Attributes.Add("disabled", "disabled");
            DropDownList3.Items[0].Attributes.Add("disabled", "disabled");
            DropDownList4.Items[0].Attributes.Add("disabled", "disabled");
            DropDownList6.Items[0].Attributes.Add("disabled", "disabled");
            DropDownList7.Items[0].Attributes.Add("disabled", "disabled");
            DropDownList8.Items[0].Attributes.Add("disabled", "disabled");
            DropDownList9.Items[0].Attributes.Add("disabled", "disabled");

        }
        /*
                if (!Page.IsPostBack)
                {
                    SqlConnection con = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234;pooling=false");
                    SqlCommand cmd = new SqlCommand("select * from Master", con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    DropDownList1.DataSource = dt;
                    DropDownList1.DataBind();

                }
                */

        if (!IsPostBack)
        {

            string CS = System.Configuration.ConfigurationManager.ConnectionStrings["conf"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select DISTINCT(Block) from Master", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                DropDownList2.DataTextField = "Block";
                DropDownList2.DataValueField = "Block";
                DropDownList2.DataSource = rdr;
                DropDownList2.DataBind();

                con.Close();
            }

            string QW = System.Configuration.ConfigurationManager.ConnectionStrings["conf"].ConnectionString;
            using (SqlConnection con = new SqlConnection(QW))
            {
                SqlCommand cmd = new SqlCommand("Select DISTINCT(Floor) from Master", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                DropDownList3.DataTextField = "Floor";
                DropDownList3.DataValueField = "Floor";
                DropDownList3.DataSource = rdr;
                DropDownList3.DataBind();
                con.Close();
            }

            string WE = System.Configuration.ConfigurationManager.ConnectionStrings["conf"].ConnectionString;
            using (SqlConnection con = new SqlConnection(WE))
            {
                SqlCommand cmd = new SqlCommand("Select DISTINCT(RoomSt) from Master", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                DropDownList4.DataTextField = "RoomSt";
                DropDownList4.DataValueField = "RoomSt";
                DropDownList4.DataSource = rdr;
                DropDownList4.DataBind();

                con.Close();
            }

            string ER = System.Configuration.ConfigurationManager.ConnectionStrings["conf"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ER))
            {
                SqlCommand cmd = new SqlCommand("Select DISTINCT(Nos) from Master", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                DropDownList5.DataTextField = "Nos";
                DropDownList5.DataValueField = "Nos";
                DropDownList5.DataSource = rdr;
                DropDownList5.DataBind();
                con.Close();
            }

            string RT = System.Configuration.ConfigurationManager.ConnectionStrings["conf"].ConnectionString;
            using (SqlConnection con = new SqlConnection(RT))
            {
                SqlCommand cmd = new SqlCommand("Select DISTINCT(WebEx) from Master", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                DropDownList6.DataTextField = "WebEx";
                DropDownList6.DataValueField = "WebEx";
                DropDownList6.DataSource = rdr;
                DropDownList6.DataBind();
                con.Close();
            }

            string TY = System.Configuration.ConfigurationManager.ConnectionStrings["conf"].ConnectionString;
            using (SqlConnection con = new SqlConnection(TY))
            {
                SqlCommand cmd = new SqlCommand("Select DISTINCT(Sparkboard) from Master", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                DropDownList7.DataTextField = "Sparkboard";
                DropDownList7.DataValueField = "Sparkboard";
                DropDownList7.DataSource = rdr;
                DropDownList7.DataBind();
                con.Close();
            }

            string YU = System.Configuration.ConfigurationManager.ConnectionStrings["conf"].ConnectionString;
            using (SqlConnection con = new SqlConnection(YU))
            {
                SqlCommand cmd = new SqlCommand("Select DISTINCT(Desktop) from Master", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                DropDownList8.DataTextField = "Desktop";
                DropDownList8.DataValueField = "Desktop";
                DropDownList8.DataSource = rdr;
                DropDownList8.DataBind();
                con.Close();
            }

            string UI = System.Configuration.ConfigurationManager.ConnectionStrings["conf"].ConnectionString;
            using (SqlConnection con = new SqlConnection(UI))
            {
                SqlCommand cmd = new SqlCommand("Select DISTINCT(Projector) from Master", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                DropDownList9.DataTextField = "Projector";
                DropDownList9.DataValueField = "Projector";
                DropDownList9.DataSource = rdr;
                DropDownList9.DataBind();
                con.Close();
            }


        }

    }


   
    DataTable DTT;
    public void systemadmin()
    {
        SqlConnection sas = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234;pooling=false");
        sas.Open();
        string query = "select * from Master ";
        SqlDataAdapter ADS = new SqlDataAdapter(query, sas);
        DTT = new DataTable();
        ADS.Fill(DTT);

        GridView5.DataSource = DTT;
        GridView5.DataBind();
        GridView5.Visible = true;
        GridView4.Visible = false;

        GridView3.Visible = true;
       // GridView2.Visible = false;
        rmit.Visible = false;
        rit.Visible = false;
        reqm.Visible = true;
        sas.Close();



    }
    public void approvgrid()
    {

        SqlConnection pro = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234;pooling=false");
        pro.Open();
        string qwest = "select * from source where Status = 'Pending With Approver' ";
        SqlDataAdapter Sata = new SqlDataAdapter(qwest, pro);
        DataTable det = new DataTable();
        Sata.Fill(det);

        GridView4.DataSource = det;
        GridView4.DataBind();
        GridView4.Visible = true;
        rit.Visible = true;

        GridView3.Visible = false;
        GridView5.Visible = false;
        rmit.Visible = false;
        reqm.Visible = false;
        pro.Close();

    }
    public void bindgrid()
    {
        SqlConnection pep = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234;pooling=false");
        pep.Open();
        string query = "select * from Master ";
        SqlDataAdapter SDA = new SqlDataAdapter(query, pep);
        DataTable DTT = new DataTable();
        SDA.Fill(DTT);

        GridView3.DataSource = DTT;

        GridView3.DataBind();
        pep.Close();
        //  ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('ok');", true);
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


    protected void rid_Click(object sender, EventArgs e)
    {

        

        SqlConnection roma = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234;pooling=false");
        roma.Open();
        string query = "select * from Master ";
        SqlDataAdapter SDA = new SqlDataAdapter(query, roma);
        DataTable DTT = new DataTable();
        SDA.Fill(DTT);

        GridView3.DataSource = DTT;
        GridView3.DataBind();
        GridView3.Visible = true;
        rmit.Visible = true;


        Label1.Visible = false;
        submit.Visible = false;
        txtComment.Visible = false;
        GridView5.Visible = false;
        GridView4.Visible = false;
        rit.Visible = false;
        reqm.Visible = false;
        roma.Close();
    }

    protected void rit_Click(object sender, EventArgs e)
    {

        SqlConnection noo = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234;pooling=false");
        noo.Open();
        string kfc = "select * from admin where PsNo='" + txtno.Text + "'";
        SqlDataAdapter sp = new SqlDataAdapter(kfc, noo);
        DataTable dt = new DataTable();
        sp.Fill(dt);
        if (dt.Rows.Count > 0)
        {

            SqlConnection riit = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234;pooling=false");
            riit.Open();
            string query = "select * from SOURCE where Status='Pending With Approver' ";
            SqlDataAdapter SfA = new SqlDataAdapter(query, riit);
            DataTable DTT = new DataTable();
            SfA.Fill(DTT);
            if (DTT.Rows.Count > 0)

            {

                GridView4.DataSource = DTT;
                GridView4.DataBind();
                GridView4.Visible = true;
                rit.Visible = true;
                approvgrid();
                TBRME.Visible = false;
                TextBox3.Visible = false;
                TextBox6.Visible = false;
                Button6.Visible = false;
                Button7.Visible = false;

                rmit.Visible = false;
                reqm.Visible = false;
                GridView3.Visible = false;
                GridView5.Visible = false;
                riit.Close();

            }
            else
            {
                GridView4.Visible = false;
                rit.Visible = false;
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert(' No Conferrence Room Booking Request Is Pending!');", true);

            }
        }
    }

    protected void Unnamed_Click1(object sender, EventArgs e)
    {
        SqlConnection oyo = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234;pooling=false");
        oyo.Open();
        string kf = "select * from admin where PsNo='" + txtno.Text + "'";
        SqlDataAdapter sp = new SqlDataAdapter(kf, oyo);
        DataTable det = new DataTable();
        sp.Fill(det);
        if (det.Rows.Count > 0)
        {
            SqlConnection app = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234;pooling=false");
            app.Open();
            string query = "select * from Master ";
            SqlDataAdapter SDA = new SqlDataAdapter(query, app);
            DataTable DTT = new DataTable();
            SDA.Fill(DTT);

            GridView5.DataSource = DTT;
            GridView5.DataBind();
            GridView5.Visible = true;
            reqm.Visible = true;

            Label1.Visible = false;
            submit.Visible = false;
            txtComment.Visible = false;
            GridView4.Visible = false;
            GridView3.Visible = false;
            rmit.Visible = false;
            rit.Visible = false;

            app.Close();
        }
        oyo.Close();
    }
    protected void Unnamed_Click(object sender, EventArgs e)
    {

        Response.Redirect("Login.aspx");
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {


    }

    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void DropDownList7_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void DropDownList8_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void DropDownList9_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        if (DropDownList2.SelectedItem.ToString() != DropDownList2.Items[0].ToString() &&
            DropDownList3.SelectedItem.ToString() != DropDownList3.Items[0].ToString() &&
            DropDownList4.SelectedItem.ToString() != DropDownList4.Items[0].ToString() &&
            DropDownList6.SelectedItem.ToString() != DropDownList6.Items[0].ToString() &&
            DropDownList7.SelectedItem.ToString() != DropDownList7.Items[0].ToString() &&
            DropDownList8.SelectedItem.ToString() != DropDownList8.Items[0].ToString() &&
            DropDownList9.SelectedItem.ToString() != DropDownList9.Items[0].ToString() 
            )


        {
            if (TextBox2.Text != "")           
                {
                    string up = TextBox2.Text;
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conf"].ConnectionString);
                    con.Open();
                    string query = "update Master set Block='" + DropDownList2.SelectedItem.Value.ToString() + "',Floor='" + DropDownList3.SelectedItem.Value.ToString() + "',RoomSt='" + DropDownList4.SelectedValue + "', Nos='" + TextBox7.Text.ToString() + "',Projector='" + DropDownList9.SelectedItem.Value.ToString() + "', Sparkboard='" + DropDownList7.SelectedItem.Value.ToString() + "',Desktop='" + DropDownList8.SelectedItem.Value.ToString() +"',WebEx='"+DropDownList6.SelectedItem.Value.ToString()+ "' where ConfRoom = '" + TextBox2.Text.ToString() + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    con.Close();

                string update1 = up+" is updated successfully!";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", "alert('" +update1+ "');", true);

            }


      else {

                string warn = "Please select conference room to proceed!";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", "alert('" + warn + "');", true);



            }



        }


        else {

            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", "alert('Please Select Conference Room To Proceed!');", true);

        }

    }

    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        TextBox5.Text = "okkk";

    }

    protected void GridView2_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

    }


    protected void Button2_Click(object sender, EventArgs e)
    {


    }

    protected void DropDownList10_SelectedIndexChanged(object sender, EventArgs e)
    {

        /*  TextBox4.Text = "ok";
          SqlConnection SQLConn = new SqlConnection("Conf");
          SQLConn.Open();
          string query = "select * from Master where ConfRoom=" + DropDownList10.SelectedItem.ToString() + "'";
          SqlDataAdapter SDA = new SqlDataAdapter(query, SQLConn);
          DataTable DTT = new DataTable();
          SDA.Fill(DTT);

          TextBox4.Text = DTT.Rows.Count.ToString();

          GridView1.DataSource = DTT;
          GridView1.DataBind();*/

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

        SqlConnection SQLConn = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234;pooling=false");
        SQLConn.Open();
        string query = "select * from Master where ConfRoom ='" + TextBox2.Text + "'";
        SqlDataAdapter SDA = new SqlDataAdapter(query, SQLConn);
        DataTable DTT = new DataTable();
        SDA.Fill(DTT);
        DropDownList2.SelectedValue = DTT.Rows[0]["Block"].ToString();
        DropDownList3.SelectedValue = DTT.Rows[0]["Floor"].ToString();
        DropDownList4.SelectedValue = DTT.Rows[0]["RoomSt"].ToString();
        TextBox7.Text = DTT.Rows[0]["Nos"].ToString();
        DropDownList6.SelectedValue = DTT.Rows[0]["WebEx"].ToString();
        DropDownList7.SelectedValue = DTT.Rows[0]["Sparkboard"].ToString();
        DropDownList8.SelectedValue = DTT.Rows[0]["Desktop"].ToString();
        DropDownList9.SelectedValue = DTT.Rows[0]["Projector"].ToString();
        SQLConn.Close();

    }

    protected void DropDownList10_SelectedIndexChanged1(object sender, EventArgs e)
    {
        TextBox5.Text = "okk";
    }

    protected void Button3_Click1(object sender, EventArgs e)
    {

        if (DropDownList2.SelectedItem.ToString() != DropDownList2.Items[0].ToString() &&
            DropDownList3.SelectedItem.ToString() != DropDownList3.Items[0].ToString() &&
            DropDownList4.SelectedItem.ToString() != DropDownList4.Items[0].ToString() &&
            DropDownList6.SelectedItem.ToString() != DropDownList6.Items[0].ToString() &&
            DropDownList7.SelectedItem.ToString() != DropDownList7.Items[0].ToString() &&
            DropDownList8.SelectedItem.ToString() != DropDownList8.Items[0].ToString() &&
            DropDownList9.SelectedItem.ToString() != DropDownList9.Items[0].ToString() &&
            TextBox2.Text != ""
            )
        {
            
                // TextBox2.Text = "ok";

                SqlConnection oy = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234;pooling=false");
                oy.Open();
                string kof = "select * from Master where ConfRoom ='" + TextBox2.Text + "'";
                SqlDataAdapter sp = new SqlDataAdapter(kof, oy);
                DataTable det = new DataTable();
                sp.Fill(det);
                if (det.Rows.Count == 0)
                {
                string inst = TextBox2.Text;
                    SqlConnection SQLConn = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234;pooling=false");
                    SQLConn.Open();
                    string query = "INSERT INTO Master(ConfRoom , Block, Floor, RoomSt, Nos, WebEx, Sparkboard, Desktop, Projector) VALUES ('" + TextBox2.Text + "','" + DropDownList2.SelectedItem.Value + "','" + DropDownList3.SelectedItem.Value + "','" + DropDownList4.SelectedItem.Value + "','" + TextBox7.Text + "','" + DropDownList6.SelectedItem.Value + "','" + DropDownList7.SelectedItem.Value + "','" + DropDownList8.SelectedItem.Value + "','" + DropDownList9.SelectedItem.Value + "')";
                    SqlCommand SDA = new SqlCommand(query, SQLConn);
                    SDA.ExecuteNonQuery();
                    bindgrid();                    
                    SQLConn.Close();

                string ins = inst + " Is Added Successfully!";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", "alert('" + ins + "');", true);

            }

            else
                {
                    oy.Close();
                string o0 = TextBox2.Text;
                string ex = o0 + " Already Exist!";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", "alert('" + ex + "');", true);


            }
        }

            else

        {
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", "alert('Please Enter Parametrs To Proceed!');", true);
        }


    }






    protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
    {

        GridViewRow gr = GridView3.SelectedRow;
        TextBox2.Text = gr.Cells[2].Text;
        DropDownList2.SelectedValue = gr.Cells[3].Text;
        DropDownList3.SelectedValue = gr.Cells[4].Text;
        DropDownList4.SelectedValue = gr.Cells[5].Text;
        TextBox7.Text = gr.Cells[6].Text;
        DropDownList6.SelectedValue = gr.Cells[7].Text;
        DropDownList7.SelectedValue = gr.Cells[8].Text;
        DropDownList8.SelectedValue = gr.Cells[9].Text;
        DropDownList9.SelectedValue = gr.Cells[10].Text;

    }

    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView3.PageIndex = e.NewPageIndex;
        bindgrid();
    }


    protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button4_Click1(object sender, EventArgs e)
    {
        foreach (GridViewRow gvrow in GridView4.Rows)
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

    protected void Button5_Click(object sender, EventArgs e)
    {
        int counter = 0;
        foreach (GridViewRow gvrow in GridView4.Rows)
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
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert(' Please select one request!');", true);

        }
        else if (counter == 1)
        {
            txtComment.Text = string.Empty;
            Label1.Visible = true;
            submit.Visible = true;
            txtComment.Visible = true;
            txtComment.Text = string.Empty;

        }







    }

    protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView4.PageIndex = e.NewPageIndex;
        approvgrid();
    }



    protected void submit_Click(object sender, EventArgs e)
    {

        {
            foreach (GridViewRow gvrow in GridView4.Rows)
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
    protected void Button6_Click(object sender, EventArgs e)
    {

        if (TextBox3.Text != "")

        {
            string user_adminname = TextBox6.Text;
            string alloted_room = TBRMC.Text;
            SqlConnection kkr = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234;pooling=false");
            kkr.Open();
            string query = "update Master set AsNo= '" + TextBox3.Text.ToString() + "' WHERE ConfRoom='" + TBRMC.Text.ToString() + " '";
            SqlCommand SDA = new SqlCommand(query, kkr);
            SDA.ExecuteNonQuery();
            string message = user_adminname + " is assign as user-admin for " + alloted_room;


            systemadmin();
            SDA.Dispose();
            kkr.Close();
            TBRME.Visible = false;
            TextBox3.Visible = false;
            TextBox6.Visible = false;
            Button7.Visible = false;
            Button6.Visible = false;
            TextBox3.Text = string.Empty;
            TextBox6.Text = string.Empty;
            TBRME.Text = string.Empty;
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", "alert('" + message + "');", true);
        }

        else
        {

            string ok = "Please enter Ps.No to proceed";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", "alert('" + ok + "');", true);



        }

    }

    protected void Button7_Click(object sender, EventArgs e)
    {

        if (TextBox3.Text != "")

        {
            string resign = TextBox6.Text;
            string room = TBRMC.Text;
            SqlConnection kkr = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234;pooling=false");
            kkr.Open();
            string query = "update Master set AsNo= '0 ' WHERE ConfRoom='" + TBRMC.Text.ToString() + " '";
            SqlCommand SDA = new SqlCommand(query, kkr);
            SDA.ExecuteNonQuery();

            string mes = resign + " is voluntarily removed as user-admin for " + room;
            systemadmin();
            SDA.Dispose();
            kkr.Close();
            DDLRM1.SelectedIndex = DDLRM1.Items.IndexOf(DDLRM1.Items.FindByValue("2"));

            TextBox3.Visible = false;
            TextBox6.Visible = false;
            TBRME.Visible = false;
            Button6.Visible = false;
            Button7.Visible = false;

            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", "alert('" + mes + "');", true);

        }
        else
        {
            
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", "alert('No user-admin found!');", true);


        }
    }

    protected void GridView5_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView5.PageIndex = e.NewPageIndex;
        systemadmin();
    }

    protected void GridView5_SelectedIndexChanged(object sender, EventArgs e)
    {

        GridViewRow gr = GridView5.SelectedRow;
        TBRMC.Text = gr.Cells[2].Text;
        DDLRM2.Text = gr.Cells[3].Text;
        DDLRM3.Text = gr.Cells[4].Text;



        if (gr.Cells[5].Text.ToString() != "0")
        {
            //  TBRMC.Text = "if";&nbsp;
            //Response.Redirect("test1.aspx?val=" +"'"+ gr.Cells[5].Text.ToString() + "/");
            DDLRM1.SelectedIndex = DDLRM1.Items.IndexOf(DDLRM1.Items.FindByValue("1"));
            TextBox3.Text = gr.Cells[5].Text;

            SqlConnection emp = new SqlConnection(ConfigurationManager.ConnectionStrings["conf"].ConnectionString);
            emp.Open();
            SqlCommand sql = new SqlCommand("select * from employee where PsNo=@psno", emp);
            sql.Parameters.AddWithValue("@psno", TextBox3.Text);
            SqlDataAdapter empl = new SqlDataAdapter(sql);
            DataTable dt = new DataTable();
            empl.Fill(dt);
            TextBox6.Text = dt.Rows[0]["Name"].ToString();
            TBRME.Text = dt.Rows[0]["email"].ToString();
            emp.Close();



            TBRME.Visible = true;
            TextBox3.Visible = true;
            TextBox6.Visible = true;
            Button6.Visible = true;
            Button7.Visible = true;

        }
        else
        {

            // TBRMC.Text = "else";
            // Response.Redirect("test1.aspx?val=" + "'" + gr.Cells[5].Text.ToString() + "/else");
            DDLRM1.SelectedIndex = DDLRM1.Items.IndexOf(DDLRM1.Items.FindByValue("2"));
            TBRME.Visible = false;
            TextBox3.Visible = false;
            TextBox6.Visible = false;
            Button7.Visible = false;
            Button6.Visible = false;
        }
        }
    


    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {

                if (DDLRM1.SelectedIndex == 1)
        {
            SqlConnection uyi = new SqlConnection(ConfigurationManager.ConnectionStrings["conf"].ConnectionString);
            uyi.Open();
            SqlCommand sql = new SqlCommand("select * from employee where PsNo=@psno", uyi);
            sql.Parameters.AddWithValue("@psno", TextBox3.Text);
            SqlDataAdapter sda = new SqlDataAdapter(sql);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            TBRME.Text = dt.Rows[0]["email"].ToString();
            TextBox6.Text = dt.Rows[0]["Name"].ToString();
            uyi.Close();
            TBRME.Visible = true;
            TextBox6.Visible = true;
        }
        else if (DDLRM1.SelectedIndex == 2)
        {
            TBRME.Visible = false;
            TextBox3.Visible = false;
            TextBox6.Visible = false;
            Button6.Visible = false;
            Button7.Visible = false;

        }

    }

    protected void DDLRM1_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (TBRMC.Text != "")
        {
            if (DDLRM1.SelectedIndex == 1)
            {
                TBRME.Visible = true;
                TextBox3.Visible = true;
                TextBox6.Visible = true;
                Button6.Visible = true;
                Button7.Visible = true;
                TextBox3.Text = string.Empty;
                TextBox6.Text = string.Empty;
                TBRME.Text = string.Empty;

            }

            else if (DDLRM1.SelectedIndex == 2)
            {
                TBRME.Visible = false;
                TextBox3.Visible = false;
                TextBox6.Visible = false;
                Button7.Visible = false;
                Button6.Visible = false;
            }

        }
    }

    protected void TBRMC_TextChanged(object sender, EventArgs e)
    {

    }

    protected void GridView5_RowDataBound(object sender, GridViewRowEventArgs e)
    {


    }

    protected void txtno_TextChanged1(object sender, EventArgs e)
    {





    }

    protected void TextBox7_TextChanged(object sender, EventArgs e)
    {

    }

  

    protected void TextBox2_TextChanged1(object sender, EventArgs e)
    {
        SqlConnection con1 = new SqlConnection("Data Source=FTP\\SQLEXPRESS;Initial Catalog=DhruvTest;User ID=sa;Password=pass$1234;pooling=false");
        con1.Open();
        string exi = "select * from Master where ConfRoom='" + TextBox2.Text.ToString() + "'";
        SqlDataAdapter Sata = new SqlDataAdapter(exi, con1);
        DataTable det = new DataTable();
        Sata.Fill(det);
        if (det.Rows.Count == 0)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('Room Does Not Exists !');", true);

            con1.Close();
        }
        else
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('Room Does Already Exists Select From Below !');", true);

        }
    }
}
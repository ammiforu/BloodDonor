using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class user : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=AMMIFORU;Initial Catalog=BloodDonor;Persist Security Info=True;User ID=sa;Password=ammi");
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Requst_Click(object sender, EventArgs e)
    {
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into RequestTbl values('" + FullName.Text + "','" + Group.Text + "','" + Email.Text + "');", con);
            cmd.ExecuteNonQuery();
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('RequestSuccess');", true);
            FullName.Text = "";
            Group.Text = "";
            Email.Text = "";
            FullName.Focus();
            con.Close();

        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('RequestFail becuase of "+ex.ToString()+"');", true);
            throw;
        }
        con.Close();

    }

    protected void logout_Click(object sender, EventArgs e)
    {
        Response.Redirect("Index.aspx");
    }
}
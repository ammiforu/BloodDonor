using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class Admin : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=AMMIFORU;Initial Catalog=BloodDonor;Persist Security Info=True;User ID=sa;Password=ammi");

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Search_Click(object sender, EventArgs e)
    {
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select lastname,bloodgroup,email,dateofbirth,role from RegisterTbl where firstname='" + UserName.Text + "' ", con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    LastName.Text = reader.GetString(0);
                    BloodGroup.Text = reader.GetString(1);
                    Email.Text = reader.GetString(2);
                    Dob.Text = reader.GetString(3);
                    role.Text = reader.GetString(4);
                }
            }

            con.Close();
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('UserNotFound');", true);

            throw;
        }
    }

    protected void Delete_Click(object sender, EventArgs e)
    {
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from RegisterTbl where firstname='" + UserName.Text + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('delete success');", true);
            Response.Redirect("Admin.aspx");


        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('delete fail');", true);
            Response.Redirect("Admin.aspx");


            throw;
        }
    }

    protected void update_Click(object sender, EventArgs e)
    {
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update RegisterTbl set LastName='" + LastName.Text + "' ,BloodGroup='" + BloodGroup.Text + "',Email='" + Email.Text + "',DateOfBirth='" + Dob.Text + "',role='" + role.Text + "' where FirstName='" + UserName.Text + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('update success');", true);
            Response.Redirect("Admin.aspx");


        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('update fail');", true);
            Response.Redirect("Admin.aspx");

            throw;
        }
    }

    protected void logout_Click(object sender, EventArgs e)
    {
        Response.Redirect("Index.aspx");
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class Index : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=AMMIFORU;Initial Catalog=BloodDonor;Persist Security Info=True;User ID=sa;Password=ammi");
    int depth=2;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LoginBtn_Click(object sender, EventArgs e)
    {
        con.Open();
        String EncPass = Encryption(LogInPass.Text, depth);
        SqlCommand cmd = new SqlCommand("select encpass from RegisterTbl where FirstName='"+LogInUserName.Text+"'", con);
        string LoginPass= cmd.ExecuteScalar().ToString();
        SqlCommand Rolecmd=new SqlCommand("select role from RegisterTbl where FirstName='" + LogInUserName.Text + "'", con);
        string rol = Rolecmd.ExecuteScalar().ToString();
        if (LoginPass.Equals(EncPass))
        {
            if (rol.Equals("admin"))
                Response.Redirect("Admin.aspx");
            else
                Response.Redirect("user.aspx");

        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('wrong password')", true);
            Response.Redirect("Index.aspx");
        }

        con.Close();

    }
    String Encryption(String plainText, int depth)
    {
        int r = depth, len = plainText.Length;
        int c = len / depth;
        char[,] mat = new char[r, c];
        int k = 0;
        String cipherText = "";
        for (int i = 0; i < c; i++)
        {
            for (int j = 0; j < r; j++)
            {
                if (k != len)
                    mat[j, i] = plainText[k++];
                else
                    mat[j, i] = 'X';
            }
        }
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                cipherText += mat[i, j];
            }
        }
        return cipherText;
    }
    String Decryption(String cipherText, int depth)
    {
        int r = depth, len = cipherText.Length;
        int c = len / depth;
        char[,] mat = new char[r, c];
        int k = 0;

        String plainText = "";


        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                mat[i, j] = cipherText[k++];
            }
        }
        for (int i = 0; i < c; i++)
        {
            for (int j = 0; j < r; j++)
            {
                plainText += mat[j, i];
            }
        }

        return plainText;
    }





    protected void SubmitBtn_Click(object sender, EventArgs e)
    {

        // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('hai');", true);

        string value = "";
        if (Mradio.Checked == true)
            value = Mradio.Text;
        else
            value = Feradio.Text;
        String EncPass=Encryption(password.Text, depth);
        if (value != "")
        {
            if (password.Text == password_confirmation.Text)
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into RegisterTbl values('" + Fntxt.Text + "','" + Lntxt.Text + "','" + Bgtxt.Text + "','" + email.Text + "','" + EncPass + "','" + DobTxt.Text + "','" + value + "','user')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Registration Successfull')", true);

                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Registration Fail')", true);

                    throw;
                }

            }
            else
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Password not Match')", true);
        }
        con.Close();

    }
}
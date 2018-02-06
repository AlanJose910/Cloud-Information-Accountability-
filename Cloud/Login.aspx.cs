using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    cpdpclass obj = new cpdpclass();
    protected void Page_Load(object sender, EventArgs e)
    { 

    }
    protected void btn_signin_Click(object sender, EventArgs e)
    {
        string sql_login = "SELECT * FROM Login WHERE uname='" + txt_uname.Text + "' and pwd='" + txt_pwd.Text + "'";
        obj.ReadData(sql_login);
        if (obj.dr.Read())
        {
            Session["Uname"] = txt_uname.Text;
            int utype = Convert.ToInt32(obj.dr.GetValue(2));
            obj.dr.Close();
            if (utype == 1)
            {
                Response.Redirect("~/Admin/Home.aspx");
            }
            else if (utype == 2)
            {
                Response.Redirect("~/Tpa/Home.aspx");
            }
            else
            {
                Response.Redirect("~/User/UserHome.aspx");
            }
        }
        else
        {
            Response.Write(obj.msgbox("invalid user"));
        }
    }
}
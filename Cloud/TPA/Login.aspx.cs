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

        string sql_login = "SELECT * FROM TpaLogin WHERE name='" + txt_uname.Text + "' and pwd='" + txt_pwd.Text + "'";
        obj.ReadData(sql_login);
        if (obj.dr.Read())
        {
            Session["Uname"] = txt_uname.Text;
            Session["cloud"] = obj.dr.GetValue(2).ToString();
            Response.Redirect("~/tpa/Tpacloudhome.aspx");
        }
        else
        {
            obj.dr.Close();
            Response.Write(obj.msgbox("invalid user"));
        }
    }
}
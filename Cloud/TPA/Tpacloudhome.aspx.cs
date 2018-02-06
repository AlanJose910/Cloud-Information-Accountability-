using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Tpa_Tpacloudhome : System.Web.UI.Page
{
    cpdpclass obj = new cpdpclass();
    public static string Cloud;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Cloud = (String)Session["cloud"];
            if (Cloud == "1")
            {
                string SQL = "select COUNT(*) from Filearchieve where fverify=0 and securityOption=1 or securityOption=2 or securityOption=3";
                obj.ReadData(SQL);
                if (obj.dr.Read())
                {
                    lbtn_count.Text = "You Have " + obj.dr.GetValue(0).ToString() + " Files to be Verified";
                }
                obj.dr.Close();
            }
            else if (Cloud == "2"|| Cloud == "3")
            {
                string SQL = "select COUNT(*) from Filearchieve where fverify=0 and securityOption=2 or securityOption=3";
                obj.ReadData(SQL);
                if (obj.dr.Read())
                {
                    lbtn_count.Text = "You Have " + obj.dr.GetValue(0).ToString() + " Files to be Verified";
                }
                obj.dr.Close();
            }
            else
            {
                lbtn_count.Text = "You Have " + obj.dr.GetValue(0).ToString() + " Files to be Verified";
            }
        }
    }
    protected void lbtn_count_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Tpa/Allfiles.aspx");
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_UserHome : System.Web.UI.Page
{
    cpdpclass obj = new cpdpclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string SELECT_SQL = "select Ownername,Mobile,Email,Date,Photo from UserRegistration where OwnerID='" + (String)Session["Uname"] + "'";
            obj.ReadData(SELECT_SQL);
            if (obj.dr.Read())
            {
                lbl_name.Text = obj.dr.GetValue(0).ToString();
                lbl_mobile.Text = obj.dr.GetValue(1).ToString();
                lbl_email.Text = obj.dr.GetValue(2).ToString();
                lbl_date.Text = obj.dr.GetValue(3).ToString();
                Image1.ImageUrl = "~/Photo/" + obj.dr.GetValue(4).ToString();
            }
            obj.dr.Close();
        }
    }
}
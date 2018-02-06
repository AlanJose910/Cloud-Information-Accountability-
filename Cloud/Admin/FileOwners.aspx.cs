using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_FileOwners : System.Web.UI.Page
{
    cpdpclass obj = new cpdpclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            OwnerDetails();
        }
    }

    protected void OwnerDetails()
    {
        string SELECT_SQL = "select *,'~/Photo/'+ Photo as im from UserRegistration";
        obj.FillGrid(SELECT_SQL, GridView1);
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        OwnerDetails();
    }
}
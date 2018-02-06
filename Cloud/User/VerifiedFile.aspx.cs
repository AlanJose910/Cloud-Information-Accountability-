using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_FileUpdate : System.Web.UI.Page
{
    Cloud obj = new Cloud();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }
    }
    protected void Bind()
    {
        string SQL_SecurityOpt = "select * from Filearchieve where fowner='" + (String)Session["Uname"] + "' and fverify=1 order by Fid desc";
        obj.fillgrid(SQL_SecurityOpt, GridView1);
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "1")
        {
            Response.Redirect("~/User/VerifiedFileDetails.aspx?Fid=" + e.CommandArgument);
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        Bind();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
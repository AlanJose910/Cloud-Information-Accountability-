using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_AlfilesCloud1 : System.Web.UI.Page
{
    cpdpclass obj = new cpdpclass();
    public static DataTable dt_temp = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dt_temp.Columns.Clear();
            dt_temp.Columns.Add("fowner");
            dt_temp.Columns.Add("fsubject");
            dt_temp.Columns.Add("fsizeinkb");
            dt_temp.Columns.Add("fdatetime");
            dt_temp.Columns.Add("status");
            dt_temp.Columns.Add("fsecurity");
            AllFileDetails();
        }
    }

    protected void AllFileDetails()
    {
        string SELECT_SQL = "select UserRegistration.Ownername,Filearchieve.fsubject,Filearchieve.fsizeinkb, " +
                          " Filearchieve.fdatetime,Filearchieve.fverify,Filearchieve.securityOption from " +
                          " UserRegistration,Filearchieve where UserRegistration.OwnerID=Filearchieve.fowner ";
        obj.ReadData(SELECT_SQL);
        while (obj.dr.Read())
        {
            DataRow drw = dt_temp.NewRow();
            drw[0] = obj.dr.GetValue(0).ToString();
            drw[1] = obj.dr.GetValue(1).ToString();
            drw[2] = obj.dr.GetValue(2).ToString();
            drw[3] = obj.dr.GetValue(3).ToString();
            string Status = obj.dr.GetValue(4).ToString();
            if (Status == "0")
            {
                drw[4] = "Not Verified";
            }
            else
            {
                drw[4] = "Verified";
            }
            string FSecurity = obj.dr.GetValue(5).ToString();
            if (FSecurity == "1")
            {
                drw[5] = "Low";
            }
            else if (FSecurity == "2")
            {
                drw[5] = "Medium";
            }
            else if (FSecurity == "3")
            {
                drw[5] = "High";
            }
            dt_temp.Rows.Add(drw);
        }
        obj.dr.Close();
        GridView1.DataSource = dt_temp;
        GridView1.DataBind();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        AllFileDetails();
    }
}
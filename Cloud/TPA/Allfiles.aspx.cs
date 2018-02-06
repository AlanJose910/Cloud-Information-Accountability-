using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Tpa_Tpacloudhome : System.Web.UI.Page
{
    cpdpclass obj = new cpdpclass();
    public static string Fid, Fid_High;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Grid_Bind();
        }
    }
    protected void Grid_Bind()
    {
        string SQL;
        if ((String)Session["cloud"] == "1")
        {
            SQL = "SELECT Filearchieve.*,FileIndex.*,UserRegistration.Ownername  FROM Filearchieve,FileIndex,UserRegistration WHERE Filearchieve.Fid=FileIndex.Fileid AND " +
                   " FileIndex.Serverid=1 AND Filearchieve.fverify=0 and UserRegistration.OwnerID=Filearchieve.fowner order by Filearchieve.fid desc";
            
            string SQL_Tpahigh = "select fid from FVerifyHigh where tpa='" + (String)Session["cloud"] + "'";
            obj.ReadData(SQL_Tpahigh);
            if (obj.dr.Read())
            {
                Fid_High = obj.dr.GetValue(0).ToString();
            }
            string SQL_Tpa = "select Fid from Fverify_Temp where tpa='" + (String)Session["cloud"] + "'";
            obj.ReadData(SQL_Tpa);
            if (obj.dr.Read())
            {
                Fid = obj.dr.GetValue(0).ToString();
                obj.dr.Close();
            }
            if (Fid != null && Fid_High != null)
            {
                string SQL_1 = "SELECT Filearchieve.*,FileIndex.*,UserRegistration.Ownername FROM Filearchieve,FileIndex,UserRegistration WHERE Filearchieve.Fid=FileIndex.Fileid AND " +
                                " FileIndex.Serverid=1 and UserRegistration.OwnerID=Filearchieve.fowner  AND Filearchieve.fverify=0 and  Filearchieve.Fid not in (" + Fid + ") and Filearchieve.Fid not in (" + Fid_High + ") order by Filearchieve.fid desc";
                obj.FillGrid(SQL_1, GridView1);
            }
            else if (Fid == null && Fid_High != null)
            {
                string SQL_1 = "SELECT Filearchieve.*,FileIndex.*,UserRegistration.Ownername FROM Filearchieve,FileIndex,UserRegistration WHERE Filearchieve.Fid=FileIndex.Fileid AND " +
                                    " FileIndex.Serverid=1 and UserRegistration.OwnerID=Filearchieve.fowner  AND Filearchieve.fverify=0 and Filearchieve.Fid not in (" + Fid_High + ") order by Filearchieve.fid desc";
                obj.FillGrid(SQL_1, GridView1);
            }
            else if (Fid != null && Fid_High == null)
            {
                string SQL_1 = "SELECT Filearchieve.*,FileIndex.*,UserRegistration.Ownername FROM Filearchieve,FileIndex,UserRegistration WHERE Filearchieve.Fid=FileIndex.Fileid AND " +
                                    " FileIndex.Serverid=1 and UserRegistration.OwnerID=Filearchieve.fowner  AND Filearchieve.fverify=0 and  Filearchieve.Fid not in (" + Fid + ") order by Filearchieve.fid desc";
                obj.FillGrid(SQL_1, GridView1);
            }
            else
            {
                SQL = "SELECT Filearchieve.*,FileIndex.*,UserRegistration.Ownername FROM Filearchieve,FileIndex,UserRegistration " +
                      " WHERE Filearchieve.Fid=FileIndex.Fileid AND FileIndex.Serverid=1 AND Filearchieve.fverify=0 and " +
                      " UserRegistration.OwnerID=Filearchieve.fowner  order by Filearchieve.fid desc";
                obj.FillGrid(SQL, GridView1);
            }
            //cloud1 files selection
        }
        else if (Session["cloud"].ToString() == "2")
        {
            string SQL_Tpa = "select Fid from Fverify_Temp where tpa='" + (String)Session["cloud"] + "'";
            obj.ReadData(SQL_Tpa);
            if (obj.dr.Read())
            {
                Fid = obj.dr.GetValue(0).ToString();
                obj.dr.Close();
                string SQL_1 = "SELECT Filearchieve.*,FileIndex.*,UserRegistration.Ownername FROM Filearchieve,FileIndex,UserRegistration WHERE Filearchieve.Fid=FileIndex.Fileid AND " +
                                " FileIndex.Serverid=2 and UserRegistration.OwnerID=Filearchieve.fowner AND Filearchieve.fverify=0 and Filearchieve.Fid not in (" + Fid + ") order by Filearchieve.fid desc";
                obj.FillGrid(SQL_1, GridView1);
            }
            else
            {
                obj.dr.Close();
                SQL = "SELECT Filearchieve.*,FileIndex.*,UserRegistration.Ownername FROM Filearchieve,FileIndex,UserRegistration WHERE "+
                      " Filearchieve.Fid=FileIndex.Fileid and UserRegistration.OwnerID=Filearchieve.fowner AND FileIndex.Serverid=2 AND Filearchieve.fverify=0 order by Filearchieve.fid desc";
                obj.FillGrid(SQL, GridView1);
            }

            //cloud2 files selection
        }
        else
        {
            string SQL_Tpa = "select Fid from Fverify_Temp where tpa='" + (String)Session["cloud"] + "'";
            obj.ReadData(SQL_Tpa);
            if (obj.dr.Read())
            {
                Fid = obj.dr.GetValue(0).ToString();
                obj.dr.Close();
                string SQL_1 = "SELECT Filearchieve.*,FileIndex.*,UserRegistration.Ownername  FROM Filearchieve,FileIndex,UserRegistration WHERE Filearchieve.Fid=FileIndex.Fileid AND " +
                                " FileIndex.Serverid=2 and UserRegistration.OwnerID=Filearchieve.fowner AND Filearchieve.fverify=0 and Filearchieve.Fid not in (" + Fid + ") order by Filearchieve.fid desc";
                obj.FillGrid(SQL_1, GridView1);
            }
            else
            {
                obj.dr.Close();
                SQL = "SELECT Filearchieve.*,FileIndex.*,UserRegistration.Ownername FROM Filearchieve,FileIndex,UserRegistration WHERE "+
                      " Filearchieve.Fid=FileIndex.Fileid and UserRegistration.OwnerID=Filearchieve.fowner AND FileIndex.Serverid=2 AND Filearchieve.fverify=0 order by Filearchieve.fid desc";
                obj.FillGrid(SQL, GridView1);
            }
            //cloud3 files selection
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "1")
        {
            Response.Redirect("Verification.aspx?Fid=" + e.CommandArgument); 
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        Grid_Bind();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
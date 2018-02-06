using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

public partial class Admin_AlfilesCloud1 : System.Web.UI.Page
{
    cpdpclass obj = new cpdpclass();
    MultiCloud mobj = new MultiCloud();
    public static DataTable dt_temp = new DataTable();
    public static string Fid_C2;
    public static ArrayList ArrLst_C2 = new ArrayList();
    public static ArrayList ArrLst_CPDP = new ArrayList();
    public static int CountC2 = 0, CountCPDP = 0, C2 = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dt_temp.Columns.Clear();
            dt_temp.Columns.Add("fowner");
            dt_temp.Columns.Add("fsubject");
            dt_temp.Columns.Add("fsizeinkb");
            dt_temp.Columns.Add("fdatetime");
            dt_temp.Columns.Add("fsecurity");
            AllFileDetails();
        }
    }

    protected void AllFileDetails()
    {
        string SQL_FidC2 = "select fid from Filearchieve2";
        mobj.ReadData_Cloud2(SQL_FidC2);
        while (mobj.dr2.Read())
        {
            ArrLst_C2.Add(mobj.dr2.GetValue(0).ToString());
            CountC2++;
        }
        mobj.dr2.Close();

        string SQL_FidCPDP = "select fid from Filearchieve where fverify=1";
        obj.ReadData(SQL_FidCPDP);
        while (obj.dr.Read())
        {
            ArrLst_CPDP.Add(obj.dr.GetValue(0).ToString());
            CountCPDP++;
        }
        obj.dr.Close();


        for (int j = 0; j < CountC2; j++)
        {
            string SELECT_SQL = "select UserRegistration.Ownername,Filearchieve.fsubject,Filearchieve.fsizeinkb, " +
                         " Filearchieve.fdatetime,Filearchieve.fverify,Filearchieve.securityOption from " +
                         " UserRegistration,Filearchieve where UserRegistration.OwnerID=Filearchieve.fowner and Filearchieve.Fid=" + ArrLst_C2[j].ToString();
            obj.ReadData(SELECT_SQL);
            while (obj.dr.Read())
            {
                DataRow drw = dt_temp.NewRow();
                drw[0] = obj.dr.GetValue(0).ToString();
                drw[1] = obj.dr.GetValue(1).ToString();
                drw[2] = obj.dr.GetValue(2).ToString();
                drw[3] = obj.dr.GetValue(3).ToString();
                string FSecurity = obj.dr.GetValue(5).ToString();
                if (FSecurity == "1")
                {
                    drw[4] = "Low";
                }
                else if (FSecurity == "2")
                {
                    drw[4] = "Medium";
                }
                else if (FSecurity == "3")
                {
                    drw[4] = "High";
                }
                dt_temp.Rows.Add(drw);
            }
            obj.dr.Close();
        }
        GridView1.DataSource = dt_temp;
        GridView1.DataBind();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        AllFileDetails();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for cpdpclass
/// </summary>
public class cpdpclass
{
    public SqlConnection con = new SqlConnection();
    public SqlCommand cmd;
    public SqlDataReader dr; 
    public SqlDataAdapter ada = new SqlDataAdapter();
    public DataTable dt = new DataTable();
    public void DBConnection()
    {
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cloudconnectionstring"].ConnectionString;
        con.Open();
    }
    public void ReadData(string sql)
    {
        DBConnection();
        cmd = new SqlCommand(sql, con);
        dr = cmd.ExecuteReader();
    }
    public void PutData(string sql)
    {
        DBConnection();
        cmd = new SqlCommand(sql, con);
        cmd.ExecuteNonQuery();
    }
    public int GetId(string pk, string table)
    {
        DBConnection();
        string sql = "SELECT ISNULL(MAX(" + pk + ")+1,1000) FROM " + table;
        cmd = new SqlCommand(sql, con);
        int id = Convert.ToInt32(cmd.ExecuteScalar());
        return id;

    }
    public string msgbox(string msg)
    {
        string message = "<script language='javascript'>alert('"+msg+"')</script>";
        return message;
    }
    public void DataAdapter(string sql)
    {
        DBConnection();
        cmd = new SqlCommand(sql, con);
        ada.SelectCommand = cmd;
        ada.Fill(dt);

    }
    public int serverid(string sql)
    {
        DBConnection();
        int sid;
        cmd = new SqlCommand(sql, con);
        sid = Convert.ToInt32(cmd.ExecuteScalar());
        return sid;

    }

    public void FillGrid(string SQL, GridView GView)
    {
        dt.Rows.Clear();
        DataAdapter(SQL);
        if (dt.Rows.Count > 0)
        {
            GView.DataSource = dt;
            GView.DataBind();
        }
    }
}
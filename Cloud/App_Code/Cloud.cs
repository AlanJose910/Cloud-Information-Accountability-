using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.UI.WebControls;
/// <summary>
/// Summary description for Cloud
/// </summary>
public class Cloud
{
    public SqlConnection con = new SqlConnection();
    public SqlCommand cmd;
    public SqlDataAdapter ada = new SqlDataAdapter();
    public DataTable dt = new DataTable();
    public SqlDataReader dr;
    public void dbconnection()
    {

        if (con.State == ConnectionState.Open)
        {
            con.Close();

        }
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cloudconnectionstring"].ConnectionString;
        con.Open();
      }
    public void readdata(string sql)
    {
        dbconnection();
        cmd = new SqlCommand(sql, con);
        dr = cmd.ExecuteReader();
    }
    public void putdata(string sql)
    {
        dbconnection();
        cmd = new SqlCommand(sql, con);
        cmd.ExecuteNonQuery();
    }
    public void adapter(string sql)
    {
        dbconnection();
        dt.Rows.Clear();
        cmd = new SqlCommand(sql, con);
        ada.SelectCommand = cmd;
        ada.Fill(dt);
    }
    public void fillgrid(string sql, GridView grd)
    {
        adapter(sql);
        if (dt.Rows.Count > 0)
        {
            grd.DataSource = dt;
                grd.DataBind();
        }
    }
    public void filldropdownlist(string text, string value, string table, DropDownList ddllst, string condition)
    {
        if (condition == "")
        {
            string sql = "select " + text + "," + value + " from " + table;
            adapter(sql);
            if (dt.Rows.Count > 0)
            {
                ddllst.DataSource = dt;
                ddllst.DataTextField = text;
                ddllst.DataValueField = value;
                ddllst.DataBind();
            }
            ddllst.Items.Insert(0, "--SELECT--");
        }
        else
        {

            string sql = "select " + text + "," + value + " from " + table + " WHERE " + condition;
            adapter(sql);
            if (dt.Rows.Count > 0)
            {
                ddllst.DataSource = dt;
                ddllst.DataTextField = text;
                ddllst.DataValueField = value;
                ddllst.DataBind();
            }
            ddllst.Items.Insert(0, "--SELECT--");
        }
    }
    public string msgbox(string msg)
    {
        string Message = "<script language='javascript'>alert('" + msg + "')</script>";
        return Message;
    }


}
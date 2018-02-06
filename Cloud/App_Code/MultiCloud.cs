using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;


public class MultiCloud
{
    public SqlConnection con1 = new SqlConnection();
    public SqlConnection con2 = new SqlConnection();
    public SqlConnection con3 = new SqlConnection();
    public SqlCommand cmd1;
    public SqlCommand cmd2;
    public SqlCommand cmd3;
    public SqlDataReader dr1;
    public SqlDataReader dr2;
    public SqlDataReader dr3;
    //public SqlDataAdapter ada = new SqlDataAdapter();
    //public DataTable dt = new DataTable();
    //public DataSet ds = new DataSet();
    
    protected void DBConnection_Cloud1()
    {
        if (con1.State == ConnectionState.Open)
        {
            con1.Close();
        }
        con1.ConnectionString = ConfigurationManager.AppSettings["Cloud1ConnectionString"];
        con1.Open();
    }
    protected void DBConnection_Cloud2()
    {
        if (con2.State == ConnectionState.Open)
        {
            con2.Close();
        }
        con2.ConnectionString = ConfigurationManager.AppSettings["Cloud2ConnectionString"];
        con2.Open();
    }
    protected void DBConnection_Cloud3()
    {
        if (con3.State == ConnectionState.Open)
        {
            con3.Close();
        }
        con3.ConnectionString = ConfigurationManager.AppSettings["Cloud3ConnectionString"];
        con3.Open();
    }


    public void ReadData_Cloud1(string sql)
    {
        DBConnection_Cloud1();
        cmd1 = new SqlCommand(sql, con1);
        dr1 = cmd1.ExecuteReader();
    }

    public void ReadData_Cloud2(string sql)
    {
        DBConnection_Cloud2();
        cmd2 = new SqlCommand(sql, con2);
        dr2 = cmd2.ExecuteReader();
    }

    public void ReadData_Cloud3(string sql)
    {
        DBConnection_Cloud3();
        cmd3 = new SqlCommand(sql, con3);
        dr3 = cmd3.ExecuteReader();
    }

    public void PutData_Cloud1(string sql)
    {
        DBConnection_Cloud1();
        cmd1 = new SqlCommand(sql, con1);
        cmd1.ExecuteNonQuery();
    }

    public void PutData_Cloud2(string sql)
    {
        DBConnection_Cloud2();
        cmd2 = new SqlCommand(sql, con2);
        cmd2.ExecuteNonQuery();
    }

    public void PutData_Cloud3(string sql)
    {
        DBConnection_Cloud3();
        cmd3 = new SqlCommand(sql, con3);
        cmd3.ExecuteNonQuery();
    }
    
    public string msgbox(string msg)
    {
        string message = "<script language='javascript'>alert('" + msg + "')</script>";
        return message;
    }
    //public void DataAdapter(string sql)
    //{
    //    DBConnection();
    //    cmd = new SqlCommand(sql, con);
    //    ada.SelectCommand = cmd;
    //    ada.Fill(dt);

    //}
    //public int serverid(string sql)
    //{
    //    DBConnection();
    //    int sid;
    //    cmd = new SqlCommand(sql, con);
    //    sid = Convert.ToInt32(cmd.ExecuteScalar());
    //    return sid;

    //}

    //public void FillGrid(string SQL, GridView GView)
    //{
    //    dt.Rows.Clear();
    //    DataAdapter(SQL);
    //    if (dt.Rows.Count > 0)
    //    {
    //        GView.DataSource = dt;
    //        GView.DataBind();
    //    }
    //}
    //public void DataSet(string sql, string table)
    //{
    //    DBConnection();
    //    cmd = new SqlCommand(sql, con);

    //    ada.Fill(ds);
    //    con.Close();
    //}
    //public void delete_sql(string sql)
    //{
    //    DBConnection();
    //    cmd = new SqlCommand(sql, con);
    //    cmd.ExecuteNonQuery();
    //    con.Close();
    //}
}
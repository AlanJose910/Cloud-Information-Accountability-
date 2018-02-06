using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_CreateDeleteTPA : System.Web.UI.Page
{
    cpdpclass obj = new cpdpclass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            obj.FillGrid("SELECT * FROM TpaLogin WHERE Cloud=" +  Session["cloud"], GridView1);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int cloud = Convert.ToInt32(Session["cloud"].ToString());
        string sql = "SELECT * FROM TpaLogin WHERE name='" + txt_name.Text + "'";
        obj.ReadData(sql);
        if (obj.dr.Read())
        {
            obj.dr.Close();
            Response.Write(obj.msgbox("User name already exist"));
        }
        else
        {
            obj.dr.Close();
            string insert_sql = "INSERT INTO TpaLogin VALUES('" + txt_name.Text + "','" + txt_pwd.Text + "',"+cloud+")";
            obj.PutData(insert_sql);
            Response.Write(obj.msgbox("Creation Successful"));
        }
    }
    protected void rbtn_create_CheckedChanged(object sender, EventArgs e)
    {
        Panel1.Visible = true;

    }
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        Panel2.Visible = true;
    }
}
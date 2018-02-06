using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Reristration : System.Web.UI.Page
{
    cpdpclass obj = new cpdpclass();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string Fname = "", Ext = "";
            Fname = FileUpload1.FileName;
            Ext = Path.GetExtension(Fname);
            if (Ext == ".jpeg" || Ext == ".jpg" || Ext == ".gif" || Ext == ".png" || Ext == ".bmp" || Ext == ".tiff")
            {
                string sql = "SELECT * FROM UserRegistration WHERE OwnerID='" + txt_userid.Text + "'";
                obj.ReadData(sql);
                if (obj.dr.Read())
                {
                    obj.dr.Close();
                    Response.Write(obj.msgbox("User name already exist"));
                }
                else
                {
                    obj.dr.Close();
                    FileUpload1.SaveAs(Server.MapPath("") + "//Photo//" + Fname);
                    string date = System.DateTime.Now.Year + "-" + System.DateTime.Now.Month + "-" + System.DateTime.Now.Day;
                    string insert_sql = "INSERT INTO UserRegistration VALUES('" + txt_userid.Text + "','" + txt_pwd.Text + "','" + txt_name.Text + "','" + rbl_gender.SelectedItem.Text + "'," + txt_age.Text + ",'" + txt_mobile.Text + "','" + txt_email.Text + "','" + date + "','" + Fname + "')";
                    obj.PutData(insert_sql);
                    obj.PutData("insert into login values('" + txt_userid.Text + "','" + txt_pwd.Text + "',3)");
                    txt_name.Text = "";
                    txt_userid.Text = "";
                    txt_pwd.Text = "";
                    txt_mobile.Text = "";
                    txt_email.Text = "";
                    txt_age.Text = "";
                    txt_confirmpwd.Text = "";
                    Response.Write(obj.msgbox("Registration Successful"));
                }
            }
            else
            {
                Response.Write(obj.msgbox("Invalid Image...!"));
            }
        }
        else
        {
            Response.Write(obj.msgbox("Pleasse Upload Your Photo...!"));
        }
    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        txt_name.Text = "";
        txt_userid.Text = "";
        txt_pwd.Text = "";
        txt_mobile.Text = "";
        txt_email.Text = "";
        txt_age.Text = "";
        txt_confirmpwd.Text = "";        
    }
}
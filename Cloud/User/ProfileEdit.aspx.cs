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
    public static string Oid;
    protected void Page_Load(object sender, EventArgs e)
    {
        OwnerDetails();
    }

    protected void OwnerDetails()
    {
        string SELECT_SQL = "select * from UserRegistration where OwnerID='" + (String)Session["Uname"] + "'";
        obj.ReadData(SELECT_SQL);
        if (obj.dr.Read())
        {
            Oid = obj.dr.GetValue(0).ToString();
            txt_userid.Text = obj.dr.GetValue(1).ToString();
            txt_name.Text = obj.dr.GetValue(3).ToString();
            txt_age.Text = obj.dr.GetValue(5).ToString();
            txt_mobile.Text = obj.dr.GetValue(6).ToString();
            txt_email.Text = obj.dr.GetValue(7).ToString();
        }
        obj.dr.Close();
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
                    int oid = obj.GetId("Oid", "UserRegistration");
                    string update_sql = "update UserRegistration set OwnerID='" + txt_userid.Text + "',Ownerpwd='" + txt_pwd.Text + "',Ownername='" + txt_name.Text + "', " +
                                        " Gender='" + rbl_gender.SelectedItem.Text + "',Age=" + txt_age.Text + ",Mobile='" + txt_mobile.Text + "',Email='" + txt_email.Text + "',Photo='" + Fname + "' where Oid=" + Oid;
                    obj.PutData(update_sql);
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
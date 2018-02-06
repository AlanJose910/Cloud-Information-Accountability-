using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_userfileupload : System.Web.UI.Page
{
    Cloud c = new Cloud();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Random rd = new Random();
            int i = rd.Next(1, 20);
            c.readdata("select filekey from KeyGenerate where Kid=" + i);
            if (c.dr.Read())
            {
                lblkey.Text = c.dr["filekey"].ToString();
            }
        }
    }
    public string HMEncryprion(byte[] fbyte)
    {
        string EncrStr = Source.CryptorEngine.Encrypt(fbyte, true, lblkey.Text);
        string HMEncrStr = Source.CryptorEngine.homomarphicEncrypt(EncrStr, true, lblkey.Text);
        return HMEncrStr;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string fname = FileUpload1.FileName;
            string fext = System.IO.Path.GetExtension(fname);
            string fsize = FileUpload1.PostedFile.ContentLength.ToString();
            string securityoption = RadioButtonList1.SelectedItem.Value;
            string uploadeddate = System.DateTime.Now.Month + "/" + System.DateTime.Now.Day + "/" + System.DateTime.Now.Year;
            byte[] fbyte = new byte[FileUpload1.PostedFile.ContentLength];
            FileUpload1.PostedFile.InputStream.Read(fbyte, 0, FileUpload1.PostedFile.ContentLength);
            string Fmetadata = HMEncryprion(fbyte);
            Session["fname"] = fname;
            Session["key"] = lblkey.Text;
            Session["fext"] = fext;
            Session["fsize"] = fsize;
            Session["securityoption"] = securityoption;
            Session["uploadeddate"] = uploadeddate;
            Session["fbyte"] = fbyte;
            Session["Fmetadata"] = Fmetadata;
            Response.Redirect("~/User/Fileblock.aspx");
        }
        else
        {
            Response.Write(c.msgbox("Please Select a File"));
        }

    }
}
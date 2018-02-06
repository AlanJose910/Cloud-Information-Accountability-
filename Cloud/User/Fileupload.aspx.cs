using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class User_Fileupload : System.Web.UI.Page
{
    Cloud obj = new Cloud();
    public static byte[] File_Byte;
    public static string filebyte, filename, hmencryptedstring, file_name, file_byte, file_ext, file_size, date, file_mdata, hmdencryptedstring;
    public static float fsize;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lbl_uid.Text = Session["uname"].ToString();
            Random rnd = new Random();
            Session["key"] = (int)rnd.Next(1, 20);
            string str = "SELECT * FROM KeyGenerate where kid='" + Session["key"].ToString() + "'";
            obj.readdata(str);
            if (obj.dr.Read())
            {
                txt_filekey.Text = obj.dr.GetValue(1).ToString();
                obj.dr.Close();
            }
        }

    }

    protected string HmEncription(byte[] fb, string Key)
    {
        string ecrstr = Source.CryptorEngine.Encrypt(fb, true, Key);
        string hmecrstr = Source.CryptorEngine.homomarphicEncrypt(ecrstr, true, Key);
        Session["hmencryptedstring"] = hmencryptedstring;
        return hmecrstr;
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {

        if (flup_user.HasFile)
        {
            byte[] filebt = new byte[flup_user.PostedFile.InputStream.Length];
            flup_user.PostedFile.InputStream.Read(filebt, 0, filebt.Length);
            Session["filebt"] = filebt;
            string fname = flup_user.FileName;
            Session["fname"] = fname;
            string ext = Path.GetExtension(fname);
            string fsize = flup_user.FileContent.Length.ToString();
            Session["fsize"] = fsize;
            string fkey = txt_filekey.Text;
            Session["FKey"] = fkey;
            Session["ext"] = ext;
            string hmencryptedstring = HmEncription(filebt, txt_filekey.Text);
            Session["encryptstring"] = hmencryptedstring;
            Session["upload_option"] = RadioButtonList1.SelectedValue;
            Response.Redirect("~/User/FileBlock.aspx");
        }
        else
        {
            Response.Write(obj.msgbox("Please upload a file"));
        }
    }
}
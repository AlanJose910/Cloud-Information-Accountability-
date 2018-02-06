using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class User_FileBlock : System.Web.UI.Page
{
    Cloud obj = new Cloud();
    public static string s1, s2, s3,s;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lbl_filename.Text = Session["fname"].ToString();
            lbl_filesize.Text = Session["fsize"].ToString();
            s = Session["encryptstring"].ToString();
            split();
            txt_block1.Text = s1;
            txt_block2.Text = s2;
            txt_block3.Text = s3;
        }
    }
    protected void split()
    {
        int l;
        int x = Convert.ToInt32(Session["fsize"]);
        int length = x;
        int div = length / 3;
        s1 = s.Substring(0, div);
        s2 = s.Substring(div,s1.Length);
        l = s1.Length + s2.Length;
        s3 = s.Substring(l,length-l);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int SecurityOption = Convert.ToInt32(Session["upload_option"].ToString());
        byte[] FileByte = (byte[])Session["filebt"];
        string FB=Convert.ToString(FileByte);
        string Extension = Path.GetExtension(lbl_filename.Text);
        int FSz = Convert.ToInt32(lbl_filesize.Text);
        float FSzinKB = FSz / 1024;
        string FileSize = Convert.ToString(FSzinKB);
        string Date = System.DateTime.Now.ToShortDateString();
        string FileOwner = Session["Uname"].ToString();
        string FileEncrKey = Session["FKey"].ToString();
        string MetaData = Session["encryptstring"].ToString();
        string INSERT_SQL = "INSERT INTO Filearchieve VALUES('" + lbl_filename.Text + "'," + FB.Length + ",'" + Extension + "','" + lbl_filesize.Text + "','" + Date + "','" + FileOwner + "'," + FileEncrKey + ",'" + MetaData + "',0,0," + SecurityOption + ")";
        obj.putdata(INSERT_SQL);

        string SQLID = "SELECT MAX(Fid) FROM Filearchieve";
        int FileID = 0;
        obj.readdata(SQLID);
        if (obj.dr.Read())
        {
            FileID = Convert.ToInt32(obj.dr.GetValue(0).ToString());
        }
        obj.dr.Close();


        string SysDate = System.DateTime.Now.Year + "/" + System.DateTime.Now.Month + "/" + System.DateTime.Now.Day;
        if (SecurityOption == 1)
        {
            string Cloud_Insert1 = "INSERT INTO FileIndex VALUES(" + FileID + ",1)";
            obj.putdata(Cloud_Insert1);
        }
        else if (SecurityOption == 2)
        {
            string Cloud_Insert1 = "INSERT INTO FileIndex VALUES(" + FileID + ",1)";
            obj.putdata(Cloud_Insert1);
            string Cloud_Insert2 = "INSERT INTO FileIndex VALUES(" + FileID + ",2)";
            obj.putdata(Cloud_Insert2);
            string Cloud_Insert3 = "INSERT INTO FileIndex VALUES(" + FileID + ",3)";
            obj.putdata(Cloud_Insert3);
        }
        else
        {
            string Cloud_Insert1 = "INSERT INTO FileIndex VALUES(" + FileID + ",1)";
            obj.putdata(Cloud_Insert1);
            string Cloud_Insert2 = "INSERT INTO FileIndex VALUES(" + FileID + ",2)";
            obj.putdata(Cloud_Insert2);
            string Cloud_Insert3 = "INSERT INTO FileIndex VALUES(" + FileID + ",3)";
            obj.putdata(Cloud_Insert3);
        }
        Response.Write(obj.msgbox("File Uploaded Successfully......Plz wait for the Verification"));
        Response.Redirect("home.aspx");
    }
}
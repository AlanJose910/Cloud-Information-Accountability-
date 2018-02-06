﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Mail;
using System.Web.Services.Protocols;
using System.Web.Services;
using System.Net;

public partial class Tpa_verification : System.Web.UI.Page
{
    MultiCloud mobj = new MultiCloud();
    cpdpclass obj = new cpdpclass();
    //Cryptography cg = new Cryptography();
    public static string EncrStr, hmdecryptedstring, FSize, FileOwner, FileExt, FSubject, FilePath, FExt, FDateTime, Cloud;
    string Fid;
    string s1, s2, s3, s;
    string securityOption;
    public static int Flag, Flag_Split, DFLAG = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        Fid = Request.QueryString["Fid"].ToString();
        if (!IsPostBack)
        {
            Cloud = (String)Session["cloud"];
            FileDetails();
            Image_Photo.Visible = false;
        }
        //lbl_filename.Text = Session["fname"].ToString();
    }
    protected void FileDetails()
    {
        string SQL = "SELECT * FROM Filearchieve WHERE Fid=" + Fid;
        obj.ReadData(SQL);
        if (obj.dr.Read())
        {
            lbl_filename.Text = obj.dr.GetValue(1).ToString();
            FileExt = obj.dr.GetValue(3).ToString();
            lbl_filesize.Text = obj.dr.GetValue(4).ToString();
            FileOwner = obj.dr.GetValue(6).ToString();
            lbl_keyRequest.Text = obj.dr.GetValue(7).ToString();
            FSize = obj.dr.GetValue(4).ToString();
            EncrStr = obj.dr.GetValue(8).ToString();
            securityOption = obj.dr.GetValue(11).ToString();


        }
        obj.dr.Close();
        if (securityOption == "1")
        {
            txt_block1.Text =EncrStr;
            Flag = 1;
        }
        if (securityOption == "2")
        {
            split(EncrStr);
            txt_block1.Text = s1;
            txt_block2.Text = s2;
            txt_block3.Text = s3;
            Flag = 2;
        }
        if (securityOption == "3")
        {
            txt_block1.Text = EncrStr;
            txt_block2.Text = EncrStr;
            txt_block3.Text = EncrStr;
            Flag = 3;
        }
        obj.cmd.Dispose();
        obj.con.Close();
    }

    protected void split(string s)
    {
        int x = Convert.ToInt32(FSize);
        int length = s.Length;
        int div = length / 3;
        s1 = s.Substring(0, div);
        s2 = s.Substring(div, div);
        s3 = s.Substring(div + div, length - (div + div));
    }

    protected void btn_decrypt_Click(object sender, EventArgs e)
    {

        if (lbl_keyRequest.Text == txt_Key.Text)
        {
            DFLAG = 1;
            if (Flag == 1)
            {
                if (FileExt == ".jpeg" || FileExt == ".jpg" || FileExt == ".png" || FileExt == ".gif" || FileExt == ".bmp")
                {
                    txt_block1.Visible = false;
                    txt_block2.Visible = false;
                    txt_block3.Visible = false;
                    Image_Photo.Visible = true;
                    string datatext_pre1 = Source.CryptorEngine.homomarphicDecrypt(EncrStr, true, lbl_keyRequest.Text);
                    string datatext1 = Source.CryptorEngine.Decrypt(datatext_pre1, true, lbl_keyRequest.Text);
                    Image_Photo.ImageUrl = "~/" + datatext1;

                }
                else
                {
                    string datatext_pre1 = Source.CryptorEngine.homomarphicDecrypt(EncrStr, true, lbl_keyRequest.Text);
                    string datatext1 = Source.CryptorEngine.Decrypt(datatext_pre1, true, lbl_keyRequest.Text);
                    txt_block1.Text = datatext1;
                    txt_block3.Visible = false;
                    txt_block2.Visible = false;
                    Image_Photo.Visible = false;
                }
            }
            else if (Flag == 2)
            {
                string datatext_pre22 = Source.CryptorEngine.homomarphicDecrypt(EncrStr, true, lbl_keyRequest.Text);
                string datatext22 = Source.CryptorEngine.Decrypt(datatext_pre22, true, lbl_keyRequest.Text);
                string Content = datatext22;

                split(Content);

                if (Cloud == "1")
                {
                    txt_block1.Text = "";
                    txt_block1.Text = s1;
                    txt_block2.Visible = false;
                    txt_block3.Visible = false;
                    txt_block1.Visible = true;
                }
                else if (Cloud == "2")
                {
                    txt_block2.Text = "";
                    txt_block2.Text = s2;
                    txt_block1.Visible = false;
                    txt_block3.Visible = false;
                    txt_block2.Visible = true;
                }
                else if (Cloud == "3")
                {
                    txt_block3.Text = "";
                    txt_block3.Text = s3;
                    txt_block1.Visible = false;
                    txt_block2.Visible = false;
                    txt_block3.Visible = true;
                }
            }
            else if (Flag == 3)
            {
                if (Cloud == "1")
                {
                    string datatext_pre21 = Source.CryptorEngine.homomarphicDecrypt(txt_block1.Text, true, lbl_keyRequest.Text);
                    string datatext21 = Source.CryptorEngine.Decrypt(datatext_pre21, true, lbl_keyRequest.Text);
                    txt_block1.Text = datatext21;

                    txt_block1.Visible = true;
                    txt_block2.Visible = false;
                    txt_block3.Visible = false;
                }
                else if (Cloud == "2")
                {
                    string datatext_pre22 = Source.CryptorEngine.homomarphicDecrypt(txt_block2.Text, true, lbl_keyRequest.Text);
                    string datatext22 = Source.CryptorEngine.Decrypt(datatext_pre22, true, lbl_keyRequest.Text);
                    txt_block2.Text = datatext22;

                    txt_block1.Visible = false;
                    txt_block2.Visible = true;
                    txt_block3.Visible = false;
                }
                else
                {
                    string datatext_pre23 = Source.CryptorEngine.homomarphicDecrypt(txt_block3.Text, true, lbl_keyRequest.Text);
                    string datatext23 = Source.CryptorEngine.Decrypt(datatext_pre23, true, lbl_keyRequest.Text);
                    txt_block3.Text = datatext23;

                    txt_block1.Visible = false;
                    txt_block2.Visible = false;
                    txt_block3.Visible = true;
                }
            }
        }
        else
        {
            Response.Write(obj.msgbox("Invalid Key....Cannot Proceed..!"));
        }
    }
    protected string HmDecription(string EncrStr, string Key)
    {
        string decrstr = Source.CryptorEngine.Decrypt(EncrStr, true, Key);
        string hmdecrstr = Source.CryptorEngine.homomarphicDecrypt(decrstr, true, Key);
        Session[" hmdecryptedstring"] = hmdecrstr;
        return hmdecrstr;
    }

    protected void btn_upload_Click(object sender, EventArgs e)
    {
        if (Flag == 1)
        {
            if (Session["cloud"].ToString() == "1")
            {
                string SQL_Update = "update Filearchieve set fmetadata='NULL',fverify=1 where Fid=" + Fid;
                obj.PutData(SQL_Update);

                string SQL_Insert = "INSERT INTO Filearchieve1 VALUES(" + Fid + ",'" + EncrStr + "')";
                mobj.PutData_Cloud1(SQL_Insert);

                string Msg = "Your File with File Name " + lbl_filename.Text + " is Verified and it is ready to Download";
                SendMessageToMobile(Msg);
            }
            Response.Write(obj.msgbox("File Verified to cloud"));
            Response.Redirect("home.aspx");
        }
        else if (Flag == 2)
        {
            if (Session["cloud"].ToString() == "1")
            {
                string SQL_Temp = "insert into Fverify_Temp values(" + Fid + ",1,'" + Session["cloud"].ToString() + "')";
                obj.PutData(SQL_Temp);
            }
            else if (Session["cloud"].ToString() == "2")
            {
                string SQL_Temp = "insert into Fverify_Temp values(" + Fid + ",2,'" + Session["cloud"].ToString() + "')";
                obj.PutData(SQL_Temp);
            }
            else if (Session["cloud"].ToString() == "3")
            {
                string SQL_Temp = "insert into Fverify_Temp values(" + Fid + ",3,'" + Session["cloud"].ToString() + "')";
                obj.PutData(SQL_Temp);
            }
            string Count = "";
            string SQL_Count = "select COUNT(*) from fverify_temp where fid=" + Fid;
            obj.ReadData(SQL_Count);
            if (obj.dr.Read())
            {
                Count = obj.dr.GetValue(0).ToString();
            }
            obj.dr.Close();
            if (Count == "3")
            {
                string SQL_Update = "update Filearchieve set fmetadata='NULL',fverify=1 where Fid=" + Fid;
                obj.PutData(SQL_Update);

                split(EncrStr);

                string SQL_Insert1 = "INSERT INTO Filearchieve1 VALUES(" + Fid + ",'" + s1 + "')";
                mobj.PutData_Cloud1(SQL_Insert1);

                string SQL_Insert2 = "INSERT INTO Filearchieve2 VALUES(" + Fid + ",'" + s2 + "')";
                mobj.PutData_Cloud2(SQL_Insert2);

                string SQL_Insert3 = "INSERT INTO Filearchieve3 VALUES(" + Fid + ",'" + s3 + "')";
                mobj.PutData_Cloud3(SQL_Insert3);

                string SQL_Delete_Temp = "delete from Fverify_Temp where Fid=" + Fid;
                obj.PutData(SQL_Delete_Temp);

                string Msg = "Your File with File Name " + lbl_filename.Text + " is Verified and it is ready to Download";
                SendMessageToMobile(Msg);
            }
            Response.Write(obj.msgbox("File Verified to cloud"));
        }
        else if (Flag == 3)
        {
            if ((String)Session["cloud"] == "1")
            {
                string SQL_Temp1 = "insert into FVerifyHigh values(" + Fid + ",1," + (String)Session["cloud"] + ")";
                obj.PutData(SQL_Temp1);
            }
            if ((String)Session["cloud"] == "2")
            {
                string SQL_Temp2 = "insert into FVerifyHigh values(" + Fid + ",2," + (String)Session["cloud"] + ")";
                obj.PutData(SQL_Temp2);
            }
            if (Session["cloud"].ToString() == "3")
            {
                string SQL_Update = "update Filearchieve set fmetadata='NULL',fverify=1 where Fid=" + Fid;
                obj.PutData(SQL_Update);

                string SQL_Insert1 = "INSERT INTO Filearchieve1 VALUES(" + Fid + ",'" + EncrStr + "')";
                mobj.PutData_Cloud1(SQL_Insert1);

                string SQL_Insert2 = "INSERT INTO Filearchieve2 VALUES(" + Fid + ",'" + EncrStr + "')";
                mobj.PutData_Cloud2(SQL_Insert2);

                string SQL_Insert3 = "INSERT INTO Filearchieve3 VALUES(" + Fid + ",'" + EncrStr + "')";
                mobj.PutData_Cloud3(SQL_Insert3);

                string SQL_Delete = "delete from FVerifyHigh where fid=" + Fid;
                obj.PutData(SQL_Delete);

                string Msg = "Your File with File Name " + lbl_filename.Text + " is Verified and it is ready to Download";
                SendMessageToMobile(Msg);
            }
            Response.Write(obj.msgbox("File Verified to cloud"));
            Server.Transfer("Allfiles.aspx");
        }
    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        string SQL_Update = "update Filearchieve set fverify=2 where Fid=" + Fid;
        obj.PutData(SQL_Update);
        string Msg="Your File with File Name "+lbl_filename.Text+" is Deleted because it is Invalid";
        SendMessageToMobile(Msg);
        Response.Write(obj.msgbox("File Deleted"));
    }

    protected void SendMessageToMobile(string Message)
    {
        try
        {
            string Uname = "", Mobile = "";
            obj.ReadData("select fowner from Filearchieve where Fid=" + Fid);
            if (obj.dr.Read())
            {
                Uname = obj.dr.GetValue(0).ToString();
            }
            obj.dr.Close();
            obj.ReadData("select Mobile from UserRegistration where OwnerID='" + Uname + "'");
            if (obj.dr.Read())
            {
                Mobile = obj.dr.GetValue(0).ToString();
            }
            obj.dr.Close();

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://ubaid.tk/sms/sms.aspx?uid=" +

            "&msg=" + Message + "&phone=" + Mobile + "&provider=way2sms");

            HttpWebResponse myResp = (HttpWebResponse)req.GetResponse();

            System.IO.
StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());

            string responseString = respStreamReader.ReadToEnd();

            respStreamReader.Close();

            myResp.Close();

            Response.Write(obj.msgbox("Message Sent Successfully"));

        }
        catch (WebException ex)
        {
            Response.Write(obj.msgbox(Convert.ToString(ex)));
        }

    }


}
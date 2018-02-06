using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_VerifiedFileDetails : System.Web.UI.Page
{
    MultiCloud mobj = new MultiCloud();
    Cloud obj = new Cloud();
    public static int Cloud;
    public static string SecurityOpt, Fid, MetaData1, MetaData2, MetaData2_1, MetaData2_2, MetaData2_3, MetaData3;
    protected void Page_Load(object sender, EventArgs e)
    {
        Fid = Request.QueryString["Fid"].ToString();
        FileDetails();
    }
    protected void FileDetails()
    {
        string SQL_SecurityOpt = "select securityOption from Filearchieve where Fid=" + Fid;
        obj.readdata(SQL_SecurityOpt);
        if (obj.dr.Read())
        {
            SecurityOpt = obj.dr.GetValue(0).ToString();
        }
        obj.dr.Close();
        if (SecurityOpt != "")
        {
            if (SecurityOpt == "1")
            {
                string SQL_Temp = "select * from Filearchieve where Fid=" + Fid;
                obj.readdata(SQL_Temp);
                if (obj.dr.Read())
                {
                    lbl_Fname.Text = obj.dr.GetValue(1).ToString();
                    lbl_Fext.Text = obj.dr.GetValue(3).ToString();
                    lbl_Fsize.Text = obj.dr.GetValue(4).ToString() + " KB";
                    lbl_Fdate.Text = obj.dr.GetValue(5).ToString();
                    lbl_Fowner.Text = obj.dr.GetValue(6).ToString();
                    lbl_Fckey.Text = obj.dr.GetValue(7).ToString();
                    lbl_Fsecurityopt.Text = "Minimum";
                }
                obj.dr.Close();

                string SQL_Mdata = "select fmetadata from Filearchieve1 where Fid=" + Fid;
                mobj.ReadData_Cloud1(SQL_Mdata);
                if (mobj.dr1.Read())
                {
                    MetaData1 = mobj.dr1.GetValue(0).ToString();
                }
                mobj.dr1.Close();
            }
            else if (SecurityOpt == "2")
            {
                string SQL_Temp = "select * from Filearchieve where Fid=" + Fid;
                obj.readdata(SQL_Temp);
                if (obj.dr.Read())
                {
                    lbl_Fname.Text = obj.dr.GetValue(1).ToString();
                    lbl_Fext.Text = obj.dr.GetValue(3).ToString();
                    lbl_Fsize.Text = obj.dr.GetValue(4).ToString() + " KB";
                    lbl_Fdate.Text = obj.dr.GetValue(5).ToString();
                    lbl_Fowner.Text = obj.dr.GetValue(6).ToString();
                    lbl_Fckey.Text = obj.dr.GetValue(7).ToString();
                    lbl_Fsecurityopt.Text = "Medium";
                }
                obj.dr.Close();

                string SQL_Mdata1 = "select fmetadata from Filearchieve1 where Fid=" + Fid;
                mobj.ReadData_Cloud1(SQL_Mdata1);
                if (mobj.dr1.Read())
                {
                    MetaData2_1 = mobj.dr1.GetValue(0).ToString();
                }
                mobj.dr1.Close();

                string SQL_Mdata2 = "select fmetadata from Filearchieve2 where Fid=" + Fid;
                mobj.ReadData_Cloud2(SQL_Mdata2);
                if (mobj.dr2.Read())
                {
                    MetaData2_2 = mobj.dr2.GetValue(0).ToString();
                }
                mobj.dr2.Close();

                string SQL_Mdata3 = "select fmetadata from Filearchieve3 where Fid=" + Fid;
                mobj.ReadData_Cloud3(SQL_Mdata3);
                if (mobj.dr3.Read())
                {
                    MetaData2_3 = mobj.dr3.GetValue(0).ToString();
                }
                mobj.dr3.Close();

                MetaData2 = MetaData2_1 + MetaData2_2 + MetaData2_3;
            }
            else if (SecurityOpt == "3")
            {
                string SQL_Temp = "select * from Filearchieve where Fid=" + Fid;
                obj.readdata(SQL_Temp);
                if (obj.dr.Read())
                {
                    lbl_Fname.Text = obj.dr.GetValue(1).ToString();
                    lbl_Fext.Text = obj.dr.GetValue(3).ToString();
                    lbl_Fsize.Text = obj.dr.GetValue(4).ToString() + " KB";
                    lbl_Fdate.Text = obj.dr.GetValue(5).ToString();
                    lbl_Fowner.Text = obj.dr.GetValue(6).ToString();
                    lbl_Fckey.Text = obj.dr.GetValue(7).ToString();
                    lbl_Fsecurityopt.Text = "High";
                }
                obj.dr.Close();

                Random rnd = new Random();
                Cloud = (int)rnd.Next(1, 3);
                if (Cloud == 1)
                {
                    string SQL_Mdata = "select fmetadata from Filearchieve1 where Fid=" + Fid;
                    mobj.ReadData_Cloud1(SQL_Mdata);
                    if (mobj.dr1.Read())
                    {
                        MetaData1 = mobj.dr1.GetValue(0).ToString();
                    }
                    mobj.dr1.Close();
                }
                else if (Cloud == 2)
                {
                    string SQL_Mdata = "select fmetadata from Filearchieve2 where Fid=" + Fid;
                    mobj.ReadData_Cloud2(SQL_Mdata);
                    if (mobj.dr2.Read())
                    {
                        MetaData2 = mobj.dr2.GetValue(0).ToString();
                    }
                    mobj.dr2.Close();
                }
                else if (Cloud == 3)
                {
                    string SQL_Mdata = "select fmetadata from Filearchieve3 where Fid=" + Fid;
                    mobj.ReadData_Cloud3(SQL_Mdata);
                    if (mobj.dr3.Read())
                    {
                        MetaData3 = mobj.dr3.GetValue(0).ToString();
                    }
                    mobj.dr3.Close();
                }
            }
        }
    }

    protected void Download(string MDATA)
    {
        string FDownload = "";
        string SQL_FDwnld = "select ISNULL(max(fdownload)+1,1) from Filearchieve where Fid=" + Fid;
        obj.readdata(SQL_FDwnld);
        if (obj.dr.Read())
        {
            FDownload = obj.dr.GetValue(0).ToString();
        }
        obj.dr.Close();
        string SQL_Update = "update Filearchieve set fdownload=" + FDownload + " where Fid=" + Fid;
        obj.putdata(SQL_Update);

        string ext = lbl_Fext.Text;
        string EncryptedString = MDATA;
        string CryptoGraphicKey = lbl_Fckey.Text;
        string Datatext_Pre = Source.CryptorEngine.homomarphicDecrypt(EncryptedString, true, CryptoGraphicKey);
        string Datatext = Source.CryptorEngine.Decrypt(Datatext_Pre, true, CryptoGraphicKey);
        Response.Buffer = true;
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = lbl_Fext.Text;
        Response.AddHeader("content-disposition", "attachment;filename=" + lbl_Fname.Text);
        Response.Write(Datatext);
        Response.End();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (SecurityOpt != "")
        {
            if (SecurityOpt == "1")
            {
                Download(MetaData1);
            }
            else if (SecurityOpt == "2")
            {
                Download(MetaData2);
            }
            else if (SecurityOpt == "3")
            {
                if (Cloud == 1)
                {
                    Download(MetaData1);
                }
                else if (Cloud == 2)
                {
                    Download(MetaData2);
                }
                else if (Cloud == 3)
                {
                    Download(MetaData3);
                }
            }           
        }
    }
}
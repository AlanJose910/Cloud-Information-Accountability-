using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_FileUpdate : System.Web.UI.Page
{
    MultiCloud mobj = new MultiCloud();
    cpdpclass obj = new cpdpclass();
    public static int sq, Cloud;
    string sqldel1, sqldel2;
    public static string fext, fsubject, fencryptkey, securityOption, Fid, MetaData1, MetaData2, MetaData2_1, MetaData2_2, MetaData2_3, MetaData3;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }
    }

    protected void Bind()
    {
        string sql = "select * from Filearchieve where fowner='" + Session["Uname"].ToString() + "' and fverify=1";
        obj.ReadData(sql);
        if (obj.dr.Read())
        {
            obj.FillGrid(sql, GridView1);
        }
        obj.dr.Close();
    }

    protected void Download(string MDATA)
    {
        string FDownload = "";
        string SQL_FDwnld = "select ISNULL(max(fdownload)+1,1) from Filearchieve where Fid=" + Fid;
        obj.ReadData(SQL_FDwnld);
        if (obj.dr.Read())
        {
            FDownload = obj.dr.GetValue(0).ToString();
        }
        obj.dr.Close();
        string SQL_Update = "update Filearchieve set fdownload=" + FDownload + " where Fid=" + Fid;
        obj.PutData(SQL_Update);

        string ext = fext;
        if (ext == ".jpeg" || ext == ".jpg" || ext == ".gif" || ext == ".bmp" || ext == ".png" || ext == ".doc" || ext == "docx" || ext == ".xml" || ext == ".pdf")
        {
            string ImgPath = "~/user/temporary/" + fsubject;
            Response.Clear();
            Response.ContentType = "";
            Response.AddHeader("content-disposition", "attachment;filename=" + ImgPath);
            Response.WriteFile(ImgPath);
            Response.End();
        }
        else
        {
            string EncryptedString = MDATA;
            string CryptoGraphicKey = fencryptkey;
            string Datatext_Pre = Source.CryptorEngine.homomarphicDecrypt(EncryptedString, true, CryptoGraphicKey);
            string Datatext = Source.CryptorEngine.Decrypt(Datatext_Pre, true, CryptoGraphicKey);
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = fext;
            Response.AddHeader("content-disposition", "attachment;filename=" + fsubject);
            Response.Write(Datatext);
            Response.End();
        }
    }

    protected void FileDetails()
    {
        if (securityOption != "")
        {
            if (securityOption == "1")
            {
                string SQL_Mdata = "select fmetadata from Filearchieve1 where Fid=" + Fid;
                mobj.ReadData_Cloud1(SQL_Mdata);
                if (mobj.dr1.Read())
                {
                    MetaData1 = mobj.dr1.GetValue(0).ToString();
                }
                mobj.dr1.Close();
            }
            else if (securityOption == "2")
            {
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
            else if (securityOption == "3")
            {               
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

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "1")
        {
            Fid = e.CommandArgument.ToString();
            string sql = "select fext,fsubject,fencryptkey,securityOption from Filearchieve where Fid=" + e.CommandArgument + "";
            obj.ReadData(sql);
            if (obj.dr.Read())
            {
                fext = obj.dr.GetValue(0).ToString();
                fsubject = obj.dr.GetValue(1).ToString();
                fencryptkey = obj.dr.GetValue(2).ToString();
                securityOption = obj.dr.GetValue(3).ToString();
            }
            obj.dr.Close();
            FileDetails();
            if (securityOption != "")
            {
                if (securityOption == "1")
                {
                    Download(MetaData1);
                }
                else if (securityOption == "2")
                {
                    Download(MetaData2);
                }
                else if (securityOption == "3")
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
        else if (e.CommandName == "2")
        {

            string sql = "select securityOption from Filearchieve where Fid=" + e.CommandArgument + "";
            obj.ReadData(sql);
            if (obj.dr.Read())
            {
                sq = Convert.ToInt32(obj.dr.GetValue(0).ToString());
            }
            obj.dr.Close();

            if (sq == 1)
            {
                string SQL_Del_File = "delete from Filearchieve where Fid=" + e.CommandArgument + "";
                obj.PutData(SQL_Del_File);

                string SQL_Del_File_C1 = "delete from Filearchieve1 where Fid=" + e.CommandArgument + "";
                mobj.PutData_Cloud1(SQL_Del_File_C1);
                Response.Write(obj.msgbox("Deletion Successful"));
                Server.Transfer("Fileupdate.aspx");
            }
            else if (sq == 2 || sq == 3)
            {
                string SQL_Del_File = "delete from Filearchieve where Fid=" + e.CommandArgument + "";
                obj.PutData(SQL_Del_File);

                string SQL_Del_File_C1 = "delete from Filearchieve1 where Fid=" + e.CommandArgument + "";
                mobj.PutData_Cloud1(SQL_Del_File_C1);

                string SQL_Del_File_C2 = "delete from Filearchieve2 where Fid=" + e.CommandArgument + "";
                mobj.PutData_Cloud2(SQL_Del_File_C2);

                string SQL_Del_File_C3 = "delete from Filearchieve3 where Fid=" + e.CommandArgument + "";
                mobj.PutData_Cloud3(SQL_Del_File_C3);
               
                Response.Write(obj.msgbox("Deletion Successful"));
                Server.Transfer("Fileupdate.aspx");
            }
        }
    }
}
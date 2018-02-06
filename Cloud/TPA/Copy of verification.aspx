<%@ Page Title="" Language="C#" MasterPageFile="~/Tpa/Clouds.master" AutoEventWireup="true" CodeFile="Copy of verification.aspx.cs" Inherits="Tpa_verification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="650">
        <tr>
            <td class="heading" colspan="3">
                file block</td>
        </tr>
        <tr>
            <td width="100">
                &nbsp;</td>
            <td width="150">
                &nbsp;</td>
            <td width="380">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                File Name</td>
            <td>
                <asp:Label ID="lbl_filename" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                File Size</td>
            <td>
                <asp:Label ID="lbl_filesize" runat="server"></asp:Label>
            &nbsp;KB</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                File Block1</td>
            <td>
                <asp:TextBox ID="txt_block1" runat="server" CssClass="textbox" Height="52px" 
                    TextMode="MultiLine" Width="310px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                File Block2</td>
            <td>
                <asp:TextBox ID="txt_block2" runat="server" CssClass="textbox" Height="52px" 
                    TextMode="MultiLine" Width="310px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                File Block3</td>
            <td>
                <asp:TextBox ID="txt_block3" runat="server" CssClass="textbox" Height="52px" 
                    TextMode="MultiLine" Width="310px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Label ID="lbl_keyRequest" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_Key" runat="server"></asp:TextBox>
                &nbsp;<asp:Button ID="btn_decrypt" runat="server" onclick="btn_decrypt_Click" 
                    Text="Decrypt" CssClass="myButton" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="title" 
                    NavigateUrl="~/User/Fileupload.aspx">Back</asp:HyperLink>
            </td>
            <td>
                <asp:Button ID="btn_upload" runat="server" Text="Upload" 
                    onclick="btn_upload_Click" CssClass="myButton"  />
            &nbsp;<asp:Button ID="btn_cancel" runat="server" Text="delete" 
                    onclick="btn_cancel_Click" CssClass="myButton"  />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <asp:Image ID="Image_Photo" runat="server" 
        style="top: 80px; left: 70px; position: absolute; height: 243px; width: 277px" />
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="FileBlock.aspx.cs" Inherits="User_FileBlock" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

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
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
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
                File Block1</td>
            <td>
                <asp:TextBox ID="txt_block1" runat="server" CssClass="textbox" Height="52px" 
                    TextMode="MultiLine" Width="310px" ReadOnly="True"></asp:TextBox>
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
                    TextMode="MultiLine" Width="310px" ReadOnly="True"></asp:TextBox>
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
                    TextMode="MultiLine" Width="310px" ReadOnly="True"></asp:TextBox>
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
                <asp:Button ID="Button1" runat="server" Text="Upload" 
                    onclick="Button1_Click" CssClass="myButton"  />
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
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Visitor.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="650">
        <tr>
            <td class="heading" colspan="3">
                sign in</td>
        </tr>
        <tr>
            <td width="10">
                &nbsp;</td>
            <td width="630">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
            <td width="10">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <table width="630">
                    <tr>
                        <td width="370" valign="top">
                <table width="370">
                    <tr>
                        <td>
                            User Name</td>
                        <td>
                <asp:TextBox ID="txt_uname" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:TextBoxWatermarkExtender ID="txt_uname_TextBoxWatermarkExtender" 
                    runat="server" Enabled="True" TargetControlID="txt_uname" 
                    WatermarkCssClass="w" WatermarkText="Enter username">
                </cc1:TextBoxWatermarkExtender>
                        </td>
                    </tr>
                    <tr>
                        <td width="150">
                            Password</td>
                        <td width="220">
                <asp:TextBox ID="txt_pwd" runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox>
                <cc1:TextBoxWatermarkExtender ID="txt_pwd_TextBoxWatermarkExtender" 
                    runat="server" Enabled="True" TargetControlID="txt_pwd" 
                    WatermarkCssClass="w" WatermarkText="Enter your password">
                </cc1:TextBoxWatermarkExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                <asp:Button ID="btn_signin" runat="server" 
                    onclick="btn_signin_Click" Text="SignIn" CssClass="myButton" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                           </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            If you are not a Registered User <a href="Registration.aspx" 
                                style="font-weight: bold; color: #0076AE">Register Here</a></td>
                    </tr>
                </table>
                        </td>
                        <td valign="top" width="300">
                             <asp:Image ID="Image3" runat="server" ImageUrl="~/img/login_icon6.png" /></td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;</td>
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


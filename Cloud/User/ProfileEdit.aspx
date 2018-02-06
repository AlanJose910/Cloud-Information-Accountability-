<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="ProfileEdit.aspx.cs" Inherits="Reristration" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="650" 
    style="background-image: url('img/logout-icon6.png'); background-repeat: no-repeat; background-position: right center">
        <tr>
            <td class="heading" colspan="3">
                profile details</td>
        </tr>
        <tr>
            <td width="50">
                &nbsp;</td>
            <td width="150">
                &nbsp;</td>
            <td width="430">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                Name</td>
            <td>
            <asp:TextBox ID="txt_name" runat="server" CssClass="textbox"></asp:TextBox>
            <cc1:TextBoxWatermarkExtender ID="txt_name_TextBoxWatermarkExtender" 
                runat="server" Enabled="True" TargetControlID="txt_name" 
                WatermarkCssClass="watermark" WatermarkText="Enter your name">
            </cc1:TextBoxWatermarkExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="*" ControlToValidate="txt_name"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                User Name</td>
            <td>
            <asp:TextBox ID="txt_userid" runat="server" CssClass="textbox"></asp:TextBox>
            <cc1:TextBoxWatermarkExtender ID="txt_userid_TextBoxWatermarkExtender" 
                runat="server" Enabled="True" TargetControlID="txt_userid" 
                WatermarkCssClass="watermark" WatermarkText="Enter userid">
            </cc1:TextBoxWatermarkExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="*" ControlToValidate="txt_userid"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                Password</td>
            <td>
            <asp:TextBox ID="txt_pwd" runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox>
            <cc1:TextBoxWatermarkExtender ID="txt_pwd_TextBoxWatermarkExtender" 
                runat="server" Enabled="True" TargetControlID="txt_pwd" 
                WatermarkCssClass="watermark" WatermarkText="1234567891234">
            </cc1:TextBoxWatermarkExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ErrorMessage="*" ControlToValidate="txt_pwd"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                Confirm Password</td>
            <td>
            <asp:TextBox ID="txt_confirmpwd" runat="server" CssClass="textbox" 
                    TextMode="Password"></asp:TextBox>
            <cc1:TextBoxWatermarkExtender ID="txt_confirmpwd_TextBoxWatermarkExtender" 
                runat="server" Enabled="True" TargetControlID="txt_confirmpwd" 
                WatermarkCssClass="watermark" WatermarkText="1234567891234">
            </cc1:TextBoxWatermarkExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ErrorMessage="*" ControlToValidate="txt_confirmpwd"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                Mobile</td>
            <td>
            <asp:TextBox ID="txt_mobile" runat="server" CssClass="textbox"></asp:TextBox>
            <cc1:TextBoxWatermarkExtender ID="txt_mobile_TextBoxWatermarkExtender" 
                runat="server" Enabled="True" TargetControlID="txt_mobile" 
                WatermarkCssClass="watermark" WatermarkText="Enter mobile number">
            </cc1:TextBoxWatermarkExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ErrorMessage="*" ControlToValidate="txt_mobile"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                Email ID</td>
            <td>
            <asp:TextBox ID="txt_email" runat="server" CssClass="textbox"></asp:TextBox>
            <cc1:TextBoxWatermarkExtender ID="txt_email_TextBoxWatermarkExtender" 
                runat="server" Enabled="True" TargetControlID="txt_email" 
                WatermarkCssClass="watermark" WatermarkText="Enter e_mail">
            </cc1:TextBoxWatermarkExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ErrorMessage="*" ControlToValidate="txt_email"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txt_email" ErrorMessage="Not a valid mail" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                Age</td>
            <td>
            <asp:TextBox ID="txt_age" runat="server" CssClass="textbox"></asp:TextBox>
            <cc1:TextBoxWatermarkExtender ID="txt_age_TextBoxWatermarkExtender" 
                runat="server" Enabled="True" TargetControlID="txt_age" 
                WatermarkCssClass="watermark" WatermarkText="Enter age">
            </cc1:TextBoxWatermarkExtender>
                </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                Gender</td>
            <td>
                <asp:RadioButtonList ID="rbl_gender" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True">Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                Photo</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
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
                &nbsp;</td>
            <td>
                <asp:Button ID="btn_submit" runat="server" CssClass="myButton" 
                    onclick="btn_submit_Click" Text="update" />
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


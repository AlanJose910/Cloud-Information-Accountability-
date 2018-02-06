<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="UserHome.aspx.cs" Inherits="User_UserHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
    <table width="650">
        <tr>
            <td class="heading" colspan="3">
                welcome </td>
        </tr>
        <tr>
            <td width="10">
                &nbsp;</td>
            <td width="630">
                &nbsp;</td>
            <td width="10">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
  
                <table width="630">
                    <tr>
                        <td width="100">
                            &nbsp;</td>
                        <td width="130">
                            Name</td>
                        <td width="150">
                            <asp:Label ID="lbl_name" runat="server"></asp:Label>
                        </td>
                        <td rowspan="7" valign="top" width="250">
                            <asp:Image ID="Image1" runat="server" Height="160px" Width="125px" />
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
                            Mobile</td>
                        <td>
                            <asp:Label ID="lbl_mobile" runat="server"></asp:Label>
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
                            Email</td>
                        <td>
                            <asp:Label ID="lbl_email" runat="server"></asp:Label>
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
                            Date of Registration</td>
                        <td>
                            <asp:Label ID="lbl_date" runat="server"></asp:Label>
                        </td>
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


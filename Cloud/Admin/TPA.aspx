<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="TPA.aspx.cs" Inherits="Admin_TPA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="650">
    <tr>
        <td class="heading" colspan="3">
            create TPA for</td>
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
            <table align="center" width="630">
                <tr>
                    <td align="center" width="210">
            <asp:Button ID="Cloud1" runat="server" Text="Cloud1" onclick="Cloud1_Click" 
                            CssClass="myButton" />
                    </td>
                    <td align="center" width="210">
            <asp:Button ID="cloud2" runat="server" Text="Cloud2" onclick="cloud2_Click" 
                            CssClass="myButton" />
                    </td>
                    <td align="center" width="210">
            <asp:Button ID="cloud3" runat="server" Text="Cloud3" onclick="cloud3_Click" 
                            CssClass="myButton" />
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


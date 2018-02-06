<%@ Page Title="" Language="C#" MasterPageFile="~/Tpa/Clouds.master" AutoEventWireup="true" CodeFile="Tpacloudhome.aspx.cs" Inherits="Tpa_Tpacloudhome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="650" height="300px"
        
        style="background-image: url('../img/cloud-files.jpg'); background-repeat: no-repeat; background-position: center top">
        <tr>
            <td class="heading" colspan="3">
                welcome</td>
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
            <td align="center">
  
                <asp:LinkButton ID="lbtn_count" runat="server" onclick="lbtn_count_Click" 
                    Font-Bold="True" ForeColor="#CC0000"></asp:LinkButton>
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


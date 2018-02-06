<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="CreateDeleteTPA.aspx.cs" Inherits="Admin_CreateDeleteTPA" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="650">
        <tr>
            <td class="heading" colspan="3">
                create / delete TPA</td>
        </tr>
        <tr>
            <td width="50">
                &nbsp;</td>
            <td width="150">
                &nbsp;</td>
            <td width="430">
                <asp:ScriptManager ID="ScriptManager2" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td width="50">
                &nbsp;</td>
            <td width="150">
                &nbsp;</td>
            <td width="430">
                <asp:RadioButton ID="rbtn_create" runat="server" AutoPostBack="True" 
                    GroupName="1" oncheckedchanged="rbtn_create_CheckedChanged" Text="Create" 
                    CssClass="style1" />
                <asp:RadioButton ID="RadioButton2" runat="server" AutoPostBack="True" 
                    GroupName="1" Text="Delete" 
                    oncheckedchanged="RadioButton2_CheckedChanged" />
            </td>
        </tr>
        <tr>
            <td width="50">
                &nbsp;</td>
            <td width="150" colspan="2">
                <asp:Panel ID="Panel1" runat="server">
                    <table width="580">
                        <tr>
                            <td   colspan="2" 
                                style="font-size: x-large; font-style: italic; color: #CC3300;">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td width="150"  >
                                Name</td>
                            <td width="430" >
                                <asp:TextBox ID="txt_name" runat="server" CssClass="textbox"></asp:TextBox>
                                <cc1:TextBoxWatermarkExtender ID="txt_name_TextBoxWatermarkExtender" 
                                    runat="server" Enabled="True" TargetControlID="txt_name" 
                                    WatermarkCssClass="w" WatermarkText="Enter name">
                                </cc1:TextBoxWatermarkExtender>
                            </td>
                        </tr>
                        <tr>
                            <td  >
                                Password</td>
                            <td  >
                                <asp:TextBox ID="txt_pwd" runat="server" 
                TextMode="Password" CssClass="textbox"></asp:TextBox>
                                <cc1:TextBoxWatermarkExtender ID="txt_pwd_TextBoxWatermarkExtender" 
                runat="server" Enabled="True" TargetControlID="txt_pwd" WatermarkCssClass="w" 
                                    WatermarkText="Enter your password">
                                </cc1:TextBoxWatermarkExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Confirm Password</td>
                            <td>
                                <asp:TextBox ID="txt_cpwd" runat="server" CssClass="textbox" 
                                    TextMode="Password"></asp:TextBox>
                                <cc1:TextBoxWatermarkExtender ID="txt_cpwd_TextBoxWatermarkExtender" 
                                    runat="server" Enabled="True" TargetControlID="txt_cpwd" 
                                    WatermarkCssClass="w" WatermarkText="Enter your password">
                                </cc1:TextBoxWatermarkExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td  >
                                </td>
                            <td  >
                                &nbsp;&nbsp;
                                <asp:Button ID="Button2" runat="server" CssClass="myButton" 
                                    onclick="Button1_Click" Text="create" />
                                &nbsp;
                                <asp:Button ID="dtn_cancel" runat="server" onclick="Button1_Click" 
                                    Text="Cancel" CssClass="myButton" />
                            </td>
                        </tr>
                        <tr>
                            <td >
                                &nbsp;</td>
                            <td >
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td width="50">
                &nbsp;</td>
            <td width="150" colspan="2">
                <asp:Panel ID="Panel2" runat="server">
                    <table width="580" >
                        <tr>
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="GridView1" runat="server" BackColor="White" 
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                                    Width="500px">
                                    <Columns>
                                        <asp:BoundField DataField="name" HeaderText="Tpa Name" />
                                        <asp:CommandField HeaderText="Operation" ShowDeleteButton="True" />
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
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
                        </tr>
                    </table>
                </asp:Panel>
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


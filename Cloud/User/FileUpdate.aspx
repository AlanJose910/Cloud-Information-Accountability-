<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="FileUpdate.aspx.cs" Inherits="User_FileUpdate" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="650">
        <tr>
            <td class="heading" colspan="3">
                files update</td>
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
            <td class="text">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="3" onrowcommand="GridView1_RowCommand" Width="630px">
                    <Columns>
                        <asp:BoundField DataField="fsubject" HeaderText="File Name" />
                        <asp:BoundField DataField="fdatetime" HeaderText="Date" />
                        <asp:BoundField DataField="fencryptkey" HeaderText="File Key" />
                        <asp:BoundField DataField="fsizeinkb" HeaderText="File size(KB)" />
                        <asp:BoundField DataField="fdownload" HeaderText="Download Count" />
                        <asp:TemplateField>
                            <ItemTemplate>
                            <asp:LinkButton ID="Lbtn1" runat="server" CommandArgument='<%# Bind("Fid") %>' 
                                    CommandName="1" Text="Download" />
                                
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                 <asp:LinkButton ID="Lbtn2" runat="server" CommandArgument='<%# Bind("Fid") %>' 
                                    CommandName="2" Text="Delete" />
                            </ItemTemplate>
                        </asp:TemplateField>
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
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>


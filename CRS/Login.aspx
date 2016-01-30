<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/NoSideNavigation.Master"
    CodeBehind="Login.aspx.vb" Inherits="CRS.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-top: 100px; margin-bottom: 20px;" align="center">
        <asp:Label ID="lbl_CRS_Login_Title" runat="server" Text="Please Login" Font-Size="Medium"
            Font-Bold="true" /><br />
        <div style="margin-top: 20px;">
            <table width="100%">
                <tr>
                    <td align="right" width="50%">
                        <asp:Label ID="lbl_CRS_Login_Name" runat="server" Text="Email Address :"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txt_CRS_Login_Name" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="50%">
                        <asp:Label ID="lbl_CRS_Login_Password" runat="server" Text="Password :"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txt_CRS_Login_Password" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td align="left">
                        <asp:Button ID="btn_CRS_Login" runat="server" Text="Login" Width="86px" OnClick="btn_CRS_Login_Click" />
                    </td>
                </tr>
            </table>
            <br />
            <asp:Label ID="lbl_CRS_Status" runat="server" Text="Status" Visible="false" Font-Italic="true"
                ForeColor="#FF0000" />
        </div>
    </div>
</asp:Content>

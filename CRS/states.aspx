<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/CRS.Master" CodeBehind="states.aspx.vb" Inherits="CRS.states" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" HorizontalAlign="Center" runat="server" >
                
    <table cellpadding="0" cellspacing="0"><tr><td align="right">
        
    <asp:Button ID="btnSave" runat="server" Text="Save Changes" Visible="True"/>            
    <asp:Table runat="server" BorderStyle="Solid" BorderWidth="2" CellPadding="5" ID="tblStatesOfAdmission" Visible="True">
        <asp:TableRow HorizontalAlign="Center" VerticalAlign="Bottom">
            <asp:TableCell></asp:TableCell>
            <asp:TableCell Width="50">1</asp:TableCell>
            <asp:TableCell Width="50">2</asp:TableCell>
            <asp:TableCell Width="50">3</asp:TableCell>
            <asp:TableCell Width="50">4</asp:TableCell>
            <asp:TableCell Width="50">5</asp:TableCell>
            <asp:TableCell Width="50">6</asp:TableCell>
            <asp:TableCell Width="50">7</asp:TableCell>
            <asp:TableCell Width="50">8</asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    </td></tr></table>
    <br />
        
    
    <asp:Label ID="lblSaveComplete" runat="server" 
                    Text="Thank you for making changes to the State of Admission." Visible="False"></asp:Label>
    </asp:Panel>
</asp:Content>


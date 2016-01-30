<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/CRS.Master" CodeBehind="types-of-cases.aspx.vb" Inherits="CRS.types_of_cases" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" HorizontalAlign="Center" runat="server" >
                
    <div style="table-layout:fixed">
    <table style="table-layout:fixed" cellpadding="0" cellspacing="0"><tr><td align="right">
    <asp:Button ID="btnSave" runat="server" Text="Save Changes" Visible="True"/>            
    <asp:Table runat="server" style="table-layout:fixed" BorderStyle="Solid" BorderWidth="2" CellPadding="5" ID="tblTypesOfCases" Visible="True">
         <asp:TableRow VerticalAlign="Bottom">
            <asp:TableCell HorizontalAlign="left" Width="25"></asp:TableCell>
            <asp:TableCell CssClass="Type_Of_Cases__ID_Header"></asp:TableCell>
            <asp:TableCell CssClass="Type_Of_Cases__Type_Of_Case"></asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell RowSpan="2">Is Marketing Fee<br />Acceptable?</asp:TableCell>
            <asp:TableCell RowSpan="2">Sliding Scale<br />or Flat Fee</asp:TableCell>
            <asp:TableCell CssClass="Type_Of_Cases__Sliding_Scale_Header" ColumnSpan="7">
             ____________________________Sliding Scale Amount____________________________<br /></asp:TableCell>
            <asp:TableCell></asp:TableCell>
                        <asp:TableCell></asp:TableCell> 
             
       
            <asp:TableCell></asp:TableCell>
            <asp:TableCell></asp:TableCell>
             <asp:TableCell></asp:TableCell>
          </asp:TableRow>

        <asp:TableRow VerticalAlign="Bottom">
            <asp:TableCell></asp:TableCell>
            <asp:TableCell>ID</asp:TableCell>
            <asp:TableCell>Type of Case</asp:TableCell>
            <asp:TableCell>Ref Fee Percentage</asp:TableCell>
            <asp:TableCell>Percentage Acceptable?</asp:TableCell>
             
             <asp:TableCell>Flat Fee<br />Amount</asp:TableCell>
             <asp:TableCell>Level 1<br />Amount</asp:TableCell>
             <asp:TableCell>Level 2<br />Amount</asp:TableCell>
             <asp:TableCell>Level 3<br />Amount</asp:TableCell>
             <asp:TableCell>Level 4<br />Amount</asp:TableCell>
             <asp:TableCell>Level 5<br />Amount</asp:TableCell>
             <asp:TableCell>Level 6<br />Amount</asp:TableCell>
             <asp:TableCell>Level 7<br />Amount</asp:TableCell>
             <asp:TableCell>Comments</asp:TableCell>
          </asp:TableRow>
       
    </asp:Table>
    </td></tr>
    
    </table>
    </div>
    <br />
   
  
    <asp:Label ID="lblSaveComplete" runat="server" 
                    Text="Thank you for making changes to the Types of Cases." Visible="False"></asp:Label>
    </asp:Panel>
</asp:Content>

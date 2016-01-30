<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/NoSideNavigation.Master" CodeBehind="Default.aspx.vb" Inherits="CRS._Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<br /><div align="center">
        <asp:Label ID="lblPageTitle" runat="server" CssClass="H3_Page_Title" >Welcome to Case Reporting System!</asp:Label>
  </div>
    <br />

<div class="Navigation_Top"; style="text-align:left">

<a href="../employees.aspx?PageTitle=Employees" title="_" target="_self">Employees</a><br />
<a href="../states.aspx?PageTitle=States of Admission" title="_" target="_self">States</a><br />
<a href="../cities.aspx?PageTitle=Cities" title="_" target="_self">Cities</a><br />
<a href="../employee-referral-groups.aspx?PageTitle=Employee Referral Groups" title="_" target="_self">Employee Referral Groups</a><br />
<a href="../referral-contact-lists.aspx?PageTitle=Referral Contact Lists" title="_" target="_self">Referral Contact Lists</a><br />
<a href="../types-of-cases.aspx?PageTitle=Types of Cases" title="_" target="_self">Types of Cases</a><br /><br />

<a href="../referral-feedback.aspx?PageTitle=Referral Feedback" title="_" target="_self">Referral Feedback</a><br />
<a href="../case-status-reporting.aspx?PageTitle=Case Status Reporting" title="_" target="_self">Case Status Reporting</a><br /><br />
<a href="../logout.aspx" title="_" target="_self">Log Out</a>
</div>
</div>









</asp:Content>


<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/CRS.Master" CodeBehind="reporting.aspx.vb" Inherits="CRS.reporting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script language="javascript" type="text/javascript">
    function SetCursorToTextEnd(textControlID) {
        var text = document.getElementById(textControlID);
        if (text != null && text.innerHTML.length > 0) {
            if (document.selection) {
                var range = document.selection.createRange();
                range.moveStart('character', text.innerHTML.length);
                range.collapse();
                range.select();
            }
            else if (window.getSelection) {

                var range = window.getSelection().getRangeAt(0);
                range.setStart(range.startContainer, text.innerHTML.length);
                range.setEnd(range.startContainer, text.innerHTML.length);


            }
        }
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scrManager" runat="server" />
    
    <% 'Header %>
    <div style="font-family:Trebuchet MS, Helvetica, Arial, sans-serif; width:100%; margin:0px;">

        <asp:UpdatePanel ID="pnlUpdate" runat="server">
            <ContentTemplate>
                <table width="100%" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        <br />&nbsp
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <%  %>
                            <table>
                                <tr>
                                    <td>
                                        <div style="width:100%; text-align:center;" align="center">
                                            <asp:Panel runat="server" id="pnl_Welcome" Visible="false">
                                                <div style="font-size:large; font-weight:normal; height: 60px; width:100%; text-align:center; vertical-align:middle;">
                                                    Welcome - currently there are no cases available for evaluation.
                                                </div>
                                            </asp:Panel>


                                            <asp:Panel runat="server" id="pnl_Referral_Feedback" Visible="false">
                                                <div style="font-size:large; font-weight:normal; height: 60px; width:100%; text-align:center; vertical-align:middle;">
                                                    <asp:Label ID="lblReferralFeedbackFirm" runat="server" ><%'=Clients_Case_Reporting.Clients_Case_Reporting_Law_Firm_Full_Name%></asp:Label><br />
                                                    <asp:Label ID="lblReferralFeedbackAttorney" runat="server" ><%'=Clients_Case_Reporting.Clients_Case_Reporting_Attorney_Full_Name%></asp:Label><br />
                                                    <br />
                                                    <br />
                                                    <table>
                                                        <tr align="center">
                                                            <td align="center" valign="top">
                                                                <asp:Label ID="lblCase" runat="server" Text="Case Information:"></asp:Label>
                                                                <asp:Label ID="lblCaseInformation" runat="server" Text=""></asp:Label>
                                                                <br />
                                                                <br />
                                                                We &nbsp
                                                                <asp:RadioButton ID="rdoAre" runat="server" GroupName="rdosInterested" Checked="true" />are &nbsp
                                                                <asp:RadioButton ID="rdoAreNot" runat="server" GroupName="rdosInterested" />are 
                                                                not&nbsp; interested in this case.
                                                            </td>
                                                        </tr>
                                                        <tr align="center">
                                                            <td align="center" valign="top">
                                                                &nbsp
                                                            </td>
                                                        </tr>
                                                        <tr align="center">
                                                            <td align="center" valign="top">
                                                                Reason:
                                                                <asp:TextBox ID="txtReason" runat="server" Width="461px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr align="center">
                                                            <td align="center" valign="top">
                                                                &nbsp
                                                            </td>
                                                        </tr>
                                                        <tr align="center">
                                                            <td align="center" valign="top">
                                                                <asp:Button ID="btnReferralFeedbackWellTakeThisCase" runat="server" Text="Well Take This Case" />
                                                                &nbsp&nbsp&nbsp
                                                                <asp:Button ID="btnReferralFeedbackGiveThisCaseToSomeoneElse" runat="server" Text="Give This Case To Someone Else" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </asp:Panel>

                                            <asp:Panel runat="server" id="pnl_Case_Reporting" Visible="false">
                                                <div style="font-size:large; font-weight:normal; height: 60px; width:100%; text-align:center; vertical-align:middle;">
                                                    <asp:Label ID="lblCaseReportingFirm" runat="server" ><%'=Clients_Case_Reporting.Clients_Case_Reporting_Law_Firm_Full_Name%></asp:Label><br />
                                                    <asp:Label ID="lblCaseReportingAttorney" runat="server" ><%'=Clients_Case_Reporting.Clients_Case_Reporting_Attorney_Full_Name%></asp:Label><br />
                                                    <asp:Label ID="lblCaseReportingClientName" runat="server" ><%'=Clients_Case_Reporting.Clients_Case_Reporting_Client_Full_Name%></asp:Label><br />
                                                    <asp:Label ID="lblCaseReportingClientID" runat="server" ><%'=Clients_Case_Reporting.Clients_Case_Reporting_Client_ID_Formatted%></asp:Label><br />
                                                    <asp:Label ID="lblCaseReportingMainCategory" runat="server" >Main Category:&nbsp<%'=Clients_Case_Reporting.Clients_Referral_History_Law_Firms_Main_Category_Proposed%></asp:Label>                                                    <br />
                                                    <asp:Label ID="lblCaseReportingTypeOfCase" runat="server" >Type Of Case:&nbsp<%'=Clients_Case_Reporting.Clients_Referral_History_Law_Firms_Type_of_Case_Proposed%></asp:Label>                                                    <br />
                                                    <asp:Label ID="lblCaseReportingComments" runat="server" >Comments:&nbsp<%'=Clients_Case_Reporting.Clients_Referral_History_Law_Firms_Message_Attorneys_at_Law_Firm%></asp:Label>                                                    <br />
                                                    <br />
                                                    <br />
                                                    <table>
                                                        <tr align="center">
                                                            <td align="center" valign="top">
                                                                Please provide us with updated information for this case.
                                                            </td>
                                                        </tr>
                                                        <tr align="center">
                                                            <td align="center" valign="top">
                                                                &nbsp
                                                            </td>
                                                        </tr>
                                                        <tr align="center">
                                                            <td align="center" valign="top">
                                                                <table>
                                                                    <tr align="center">
                                                                        <td align="center" valign="top">
                                                                            Comments:
                                                                        </td>
                                                                        <td align="center" valign="top">
                                                                            <asp:TextBox ID="txtCaseReportingComments" runat="server" Width="700px" Height="300px" 
                                                                                TextMode="MultiLine"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr align="center">
                                                            <td align="center" valign="top">
                                                                &nbsp
                                                            </td>
                                                        </tr>
                                                        <tr align="center">
                                                            <td align="center" valign="top">
                                                                <asp:Button ID="btnCaseReportingComments" runat="server" Text="Add Comment" />
                                                                <br />
                                                                <br />
                                                                <asp:Label ID="lblCaseReportingCommentsSaved" runat="server" Text="Comments Save!" Visible="false"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </asp:Panel>

                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
              </ContentTemplate>
          </asp:UpdatePanel>
    </div>
</asp:Content>

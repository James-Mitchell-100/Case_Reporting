Imports System.Drawing
Imports CRS_BLL
Imports CRS_Common
Public Class types_of_cases
    Inherits System.Web.UI.Page

#Region "Properties"
    ''' <summary>
    ''' Clients Case Reporting object - maintained in Session state
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Property Clients_Case_Reporting() As CaseReporting_Clients_Case_Reporting
        Get
            If Object.ReferenceEquals(Session(Common.ssn_Clients_Case_Reporting), Nothing) Then
                Dim temp_Clients_Case_Reporting As New CaseReporting_Clients_Case_Reporting
                Return temp_Clients_Case_Reporting
            Else
                Return CType(Session(Common.ssn_Clients_Case_Reporting), CaseReporting_Clients_Case_Reporting)
            End If
        End Get
        Set(ByVal value As CaseReporting_Clients_Case_Reporting)
            Session(Common.ssn_Clients_Case_Reporting) = value
        End Set
    End Property

    ''' <summary>
    ''' Logged In - maintained in Session state
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Property Logged_In() As String
        Get
            Return Session(Common.ssn_Logged_In).ToString()
        End Get
        Set(ByVal value As String)
            Session(Common.ssn_Logged_In) = value
        End Set
    End Property

    ''' <summary>
    ''' Attorney ID - maintained in Session state
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Property AttorneyID() As String
        Get
            Return Session(Common.ssn_AttorneyID).ToString()
        End Get
        Set(ByVal value As String)
            Session(Common.ssn_AttorneyID) = value
        End Set
    End Property

    ''' <summary>
    ''' Law Firm ID - maintained in Session state
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Property LawFirmID() As String
        Get
            Return Session(Common.ssn_LawFirmID).ToString()
        End Get
        Set(ByVal value As String)
            Session(Common.ssn_LawFirmID) = value
        End Set
    End Property

    '''' <summary>
    '''' State ID - maintained in Session state
    '''' </summary>
    '''' <value></value>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Protected Property StateID() As String
    '    Get
    '        Return Session(Common.ssn_StateID).ToString()
    '    End Get
    '    Set(ByVal value As String)
    '        Session(Common.ssn_StateID) = value
    '    End Set
    'End Property

#End Region

#Region "Events"
    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Try
            Dim str_Previous_Category As String
            str_Previous_Category = ""

            'Get TypeOfCase information
            Dim oTypesOfCasesAndMarketingFees As New CaseReporting_Type_Of_Case_And_Marketing_Fees
            oTypesOfCasesAndMarketingFees.GetCaseReportingType_Of_Case_And_Marketing_Fees(LawFirmID)


            If oTypesOfCasesAndMarketingFees.CaseReporting_Type_Of_Case_And_Marketing_Fees.Count > 0 Then

                For Each TypeOfCase As CaseReporting_Type_Of_Case_And_Marketing_Fee In oTypesOfCasesAndMarketingFees.CaseReporting_Type_Of_Case_And_Marketing_Fees
                    'if new Category add a blank row with Category in leftmost cell
                    If TypeOfCase.ToC_ID_Formatted <> "" Then
                        If TypeOfCase.ToC_Main_Category <> str_Previous_Category Then
                            Call RenderBlankRow()
                            Call RenderTable(True, TypeOfCase.ToC_Main_Category, "", "", "", "", "", "", "", "", "", "", "", "", "", "")
                        End If
                        Call RenderTable(False, TypeOfCase.ToC_Main_Category, TypeOfCase.ToC_ID_Formatted, TypeOfCase.ToC_Type_of_Case, TypeOfCase.ToC_LF_IMF_Flat_Fee_or_Sliding_Scale, TypeOfCase.ToC_LF_IMF_Flat_Fee_Amount, TypeOfCase.ToC_LF_IMF_Sliding_Scale_Amount_Level_01, TypeOfCase.ToC_LF_IMF_Sliding_Scale_Amount_Level_02, TypeOfCase.ToC_LF_IMF_Sliding_Scale_Amount_Level_03, TypeOfCase.ToC_LF_IMF_Sliding_Scale_Amount_Level_04, TypeOfCase.ToC_LF_IMF_Sliding_Scale_Amount_Level_05, TypeOfCase.ToC_LF_IMF_Sliding_Scale_Amount_Level_06, TypeOfCase.ToC_LF_IMF_Sliding_Scale_Amount_Level_07, TypeOfCase.ToC_LF_RF_Referral_Fee_Percentage, TypeOfCase.ToC_LF_IMF_Is_Fee_Acceptable, TypeOfCase.ToC_Comments)
                    End If
                    str_Previous_Category = TypeOfCase.ToC_Main_Category
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RenderTable(ByVal Category_Only_Row As Boolean, ByVal Main_Category As String, ByVal Formatted_ID As String, ByVal Type_of_Case As String, ByVal Flat_Fee_or_Sliding_Scale As String, ByVal Marketing_Fee_Flat_Fee_Amount As String, ByVal Marketing_Sliding_Scale_Amount_Level_1 As String, ByVal Marketing_Sliding_Scale_Amount_Level_2 As String, ByVal Marketing_Sliding_Scale_Amount_Level_3 As String, ByVal Marketing_Sliding_Scale_Amount_Level_4 As String, ByVal Marketing_Sliding_Scale_Amount_Level_5 As String, ByVal Marketing_Sliding_Scale_Amount_Level_6 As String, ByVal Marketing_Sliding_Scale_Amount_Level_7 As String, ByVal Referral_Fee_Percentage As String, ByVal Is_Fee_Acceptable As String, ByVal Comments As String)
        Dim tr_Type_of_Case As New TableRow
        Dim tc_Formatted_ID As New TableCell
        Dim tc_Type_Of_Case As New TableCell

        Dim tc_Main_Category As New TableCell
        Dim tc_Referral_Fee_Percentage As New TableCell
        Dim tc_Referral_Fee_Percentage_Acceptable As New TableCell
        Dim tc_Is_Fee_Acceptable As New TableCell

        Dim tc_Flat_Fee_or_Sliding_Scale As New TableCell
        Dim tc_Marketing_Fee_Flat_Fee_Amount As New TableCell
        Dim tc_Marketing_Sliding_Scale_Amount_Level_1 As New TableCell
        Dim tc_Marketing_Sliding_Scale_Amount_Level_2 As New TableCell
        Dim tc_Marketing_Sliding_Scale_Amount_Level_3 As New TableCell
        Dim tc_Marketing_Sliding_Scale_Amount_Level_4 As New TableCell
        Dim tc_Marketing_Sliding_Scale_Amount_Level_5 As New TableCell
        Dim tc_Marketing_Sliding_Scale_Amount_Level_6 As New TableCell
        Dim tc_Marketing_Sliding_Scale_Amount_Level_7 As New TableCell

        Dim tc_Comments As New TableCell

        If Category_Only_Row = True Then
            tc_Main_Category.Text = Main_Category
            tc_Main_Category.ColumnSpan = 16
        Else
            tc_Main_Category.Text = ""
        End If

        'catch blanks and convert to 0's
        If Marketing_Fee_Flat_Fee_Amount = "" Then Marketing_Fee_Flat_Fee_Amount = "0"
        If Marketing_Sliding_Scale_Amount_Level_1 = "" Then Marketing_Sliding_Scale_Amount_Level_1 = "0"
        If Marketing_Sliding_Scale_Amount_Level_2 = "" Then Marketing_Sliding_Scale_Amount_Level_2 = "0"
        If Marketing_Sliding_Scale_Amount_Level_3 = "" Then Marketing_Sliding_Scale_Amount_Level_3 = "0"
        If Marketing_Sliding_Scale_Amount_Level_4 = "" Then Marketing_Sliding_Scale_Amount_Level_4 = "0"
        If Marketing_Sliding_Scale_Amount_Level_5 = "" Then Marketing_Sliding_Scale_Amount_Level_5 = "0"
        If Marketing_Sliding_Scale_Amount_Level_6 = "" Then Marketing_Sliding_Scale_Amount_Level_6 = "0"
        If Marketing_Sliding_Scale_Amount_Level_7 = "" Then Marketing_Sliding_Scale_Amount_Level_7 = "0"

        tc_Formatted_ID.Text = Formatted_ID
        tc_Type_Of_Case.Text = Type_of_Case
        tc_Flat_Fee_or_Sliding_Scale.Text = Flat_Fee_or_Sliding_Scale
        'tc_Marketing_Fee_Flat_Fee_Amount.Text = Marketing_Fee_Flat_Fee_Amount
        tc_Marketing_Fee_Flat_Fee_Amount.Text = FormatNumber(CInt(Marketing_Fee_Flat_Fee_Amount), 0, TriState.False, TriState.False, TriState.True)
        tc_Marketing_Sliding_Scale_Amount_Level_1.Text = FormatNumber(CInt(Marketing_Sliding_Scale_Amount_Level_1), 0, TriState.False, TriState.False, TriState.True)
        tc_Marketing_Sliding_Scale_Amount_Level_2.Text = FormatNumber(CInt(Marketing_Sliding_Scale_Amount_Level_2), 0, TriState.False, TriState.False, TriState.True)
        tc_Marketing_Sliding_Scale_Amount_Level_3.Text = FormatNumber(CInt(Marketing_Sliding_Scale_Amount_Level_3), 0, TriState.False, TriState.False, TriState.True)
        tc_Marketing_Sliding_Scale_Amount_Level_4.Text = FormatNumber(CInt(Marketing_Sliding_Scale_Amount_Level_4), 0, TriState.False, TriState.False, TriState.True)
        tc_Marketing_Sliding_Scale_Amount_Level_5.Text = FormatNumber(CInt(Marketing_Sliding_Scale_Amount_Level_5), 0, TriState.False, TriState.False, TriState.True)
        tc_Marketing_Sliding_Scale_Amount_Level_6.Text = FormatNumber(CInt(Marketing_Sliding_Scale_Amount_Level_6), 0, TriState.False, TriState.False, TriState.True)
        tc_Marketing_Sliding_Scale_Amount_Level_7.Text = FormatNumber(CInt(Marketing_Sliding_Scale_Amount_Level_7), 0, TriState.False, TriState.False, TriState.True)

        tc_Referral_Fee_Percentage.Text = Referral_Fee_Percentage
        tc_Is_Fee_Acceptable.Text = Is_Fee_Acceptable
        tc_Comments.Text = Comments

        tc_Main_Category.Attributes.Add("class", "Type_Of_Cases__Categories")
        tc_Formatted_ID.Attributes.Add("class", "Type_Of_Cases__ID")
        tc_Type_Of_Case.Attributes.Add("class", "Type_Of_Cases__Type_Of_Case")
        tc_Marketing_Fee_Flat_Fee_Amount.Attributes.Add("class", "Type_Of_Cases__Flat_Fee_Amounts")
        tc_Marketing_Sliding_Scale_Amount_Level_1.Attributes.Add("class", "Type_Of_Cases__Marketing_Sliding_Scale_Amounts")
        tc_Marketing_Sliding_Scale_Amount_Level_2.Attributes.Add("class", "Type_Of_Cases__Marketing_Sliding_Scale_Amounts")
        tc_Marketing_Sliding_Scale_Amount_Level_3.Attributes.Add("class", "Type_Of_Cases__Marketing_Sliding_Scale_Amounts")
        tc_Marketing_Sliding_Scale_Amount_Level_4.Attributes.Add("class", "Type_Of_Cases__Marketing_Sliding_Scale_Amounts")
        tc_Marketing_Sliding_Scale_Amount_Level_5.Attributes.Add("class", "Type_Of_Cases__Marketing_Sliding_Scale_Amounts")
        tc_Marketing_Sliding_Scale_Amount_Level_6.Attributes.Add("class", "Type_Of_Cases__Marketing_Sliding_Scale_Amounts")
        tc_Marketing_Sliding_Scale_Amount_Level_7.Attributes.Add("class", "Type_Of_Cases__Marketing_Sliding_Scale_Amounts")
        tc_Referral_Fee_Percentage.Attributes.Add("class", "Type_Of_Cases__Referal_Fee_Percentage")

        tr_Type_of_Case.Cells.Add(tc_Main_Category)
        If Category_Only_Row = False Then
            tr_Type_of_Case.Cells.Add(tc_Formatted_ID)
            tr_Type_of_Case.Cells.Add(tc_Type_Of_Case)

            Dim rdo_Referral_Fee_Percentage_Acceptable_Yes As New RadioButton
            Dim rdo_Referral_Fee_Percentage_Acceptable_No As New RadioButton
            rdo_Referral_Fee_Percentage_Acceptable_Yes.ID = Formatted_ID & "Yes"
            rdo_Referral_Fee_Percentage_Acceptable_No.ID = Formatted_ID & "No"
            rdo_Referral_Fee_Percentage_Acceptable_Yes.GroupName = "Referral_Fee_Percentage_Acceptable_Yes_" & Formatted_ID.ToString
            rdo_Referral_Fee_Percentage_Acceptable_No.GroupName = "Referral_Fee_Percentage_Acceptable_No_" & Formatted_ID.ToString
            rdo_Referral_Fee_Percentage_Acceptable_Yes.Checked = True
            rdo_Referral_Fee_Percentage_Acceptable_Yes.Text = "Yes"
            rdo_Referral_Fee_Percentage_Acceptable_No.Text = "No"

            Dim rdo_Is_Marketing_Fee_Acceptable_Yes As New RadioButton
            Dim rdo_Is_Marketing_Fee_Acceptable_No As New RadioButton
            rdo_Is_Marketing_Fee_Acceptable_Yes.ID = Formatted_ID & "Yes"
            rdo_Is_Marketing_Fee_Acceptable_No.ID = Formatted_ID & "No"
            rdo_Is_Marketing_Fee_Acceptable_Yes.GroupName = Formatted_ID.ToString
            rdo_Is_Marketing_Fee_Acceptable_No.GroupName = Formatted_ID.ToString
            rdo_Is_Marketing_Fee_Acceptable_Yes.Checked = True
            rdo_Is_Marketing_Fee_Acceptable_Yes.Text = "Yes"
            rdo_Is_Marketing_Fee_Acceptable_No.Text = "No"

            'Dim chk_Is_Fee_Acceptable As New CheckBox
            'chk_Is_Fee_Acceptable.Checked = False

            tc_Referral_Fee_Percentage_Acceptable.Controls.Add(rdo_Referral_Fee_Percentage_Acceptable_Yes)
            tc_Referral_Fee_Percentage_Acceptable.Controls.Add(rdo_Referral_Fee_Percentage_Acceptable_No)

            tc_Is_Fee_Acceptable.Controls.Add(rdo_Is_Marketing_Fee_Acceptable_Yes)
            tc_Is_Fee_Acceptable.Controls.Add(rdo_Is_Marketing_Fee_Acceptable_No)


            tr_Type_of_Case.Cells.Add(tc_Referral_Fee_Percentage)
            tr_Type_of_Case.Cells.Add(tc_Referral_Fee_Percentage_Acceptable)
            tr_Type_of_Case.Cells.Add(tc_Is_Fee_Acceptable)
            tr_Type_of_Case.Cells.Add(tc_Flat_Fee_or_Sliding_Scale)
            tr_Type_of_Case.Cells.Add(tc_Marketing_Fee_Flat_Fee_Amount)
            tr_Type_of_Case.Cells.Add(tc_Marketing_Sliding_Scale_Amount_Level_1)
            tr_Type_of_Case.Cells.Add(tc_Marketing_Sliding_Scale_Amount_Level_2)
            tr_Type_of_Case.Cells.Add(tc_Marketing_Sliding_Scale_Amount_Level_3)
            tr_Type_of_Case.Cells.Add(tc_Marketing_Sliding_Scale_Amount_Level_4)
            tr_Type_of_Case.Cells.Add(tc_Marketing_Sliding_Scale_Amount_Level_5)
            tr_Type_of_Case.Cells.Add(tc_Marketing_Sliding_Scale_Amount_Level_6)
            tr_Type_of_Case.Cells.Add(tc_Marketing_Sliding_Scale_Amount_Level_7)

            Dim txt_Comments As New TextBox
            ' txt_Comments.Rows = 3
            ' txt_Comments.TextMode = TextBoxMode.MultiLine
            tc_Comments.Controls.Add(txt_Comments)
            tr_Type_of_Case.Cells.Add(tc_Comments)
        End If


        ' Set Row Attributes
        tr_Type_of_Case.VerticalAlign = VerticalAlign.Bottom
        tr_Type_of_Case.HorizontalAlign = HorizontalAlign.Center

        ' Add Row
        If tblTypesOfCases.Rows.Count Mod 2 = 1 Then
            tr_Type_of_Case.BackColor = Color.FromArgb(234, 234, 234)
        Else
            tr_Type_of_Case.BackColor = Color.White
        End If

        tblTypesOfCases.Rows.Add(tr_Type_of_Case)
    End Sub
    Private Sub RenderBlankRow()
        Dim tr_Type_of_Case As New TableRow
        Dim tc_Formatted_ID As New TableCell
        Dim tc_Type_Of_Case As New TableCell

        Dim tc_Main_Category As New TableCell

        Dim tc_Flat_Fee_or_Sliding_Scale As New TableCell
        Dim tc_Marketing_Fee_Flat_Fee_Amount As New TableCell
        Dim tc_Marketing_Sliding_Scale_Amount_Level_1 As New TableCell
        Dim tc_Marketing_Sliding_Scale_Amount_Level_2 As New TableCell
        Dim tc_Marketing_Sliding_Scale_Amount_Level_3 As New TableCell
        Dim tc_Marketing_Sliding_Scale_Amount_Level_4 As New TableCell
        Dim tc_Marketing_Sliding_Scale_Amount_Level_5 As New TableCell
        Dim tc_Marketing_Sliding_Scale_Amount_Level_6 As New TableCell
        Dim tc_Marketing_Sliding_Scale_Amount_Level_7 As New TableCell

        Dim tc_Referral_Fee_Percentage As New TableCell
        Dim tc_Is_Fee_Acceptable As New TableCell
        Dim tc_Comments As New TableCell

        tc_Main_Category.ColumnSpan = 16
        tc_Main_Category.Attributes.Add("class", "Blank_Colored_Line")

        tr_Type_of_Case.Cells.Add(tc_Main_Category)

        ' Set Row Attributes
        tr_Type_of_Case.VerticalAlign = VerticalAlign.Bottom
        tr_Type_of_Case.HorizontalAlign = HorizontalAlign.Center

        ' Add Row
        tblTypesOfCases.Rows.Add(tr_Type_of_Case)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                '*****
                'login handled in master page
                '*****
                ''Check to see if we are logged in or not
                'If Logged_In <> "Yes" Then
                ' 'Login
                ' Response.Redirect("login.aspx?rep=" & Trim(Request.QueryString("rep")) & "&cid=" & Trim(Request.QueryString("cid")) & "&lfid=" & Trim(Request.QueryString("lfid") & " &aid=" & Trim(Request.QueryString("aid")) & "&crhlf=" & Trim(Request.QueryString("crhlf"))))
                'End If

            Else

                'Only reason for a postback is the Save button was clicked - display message say thank you saving
                tblTypesOfCases.Visible = False
                btnSave.Visible = False
                lblSaveComplete.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Call SaveChanges()
    End Sub

    Private Sub Cities_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Call SaveChanges()
    End Sub
    Private Sub SaveChanges()
        Try
            'Save Law Firm Cities inforamtion
            '   Dim oLawFirmCities As New CaseReporting_LawFirm_Cities
            Dim oTypesOfCases As New CaseReporting_Type_Of_Case_And_Marketing_Fees

            'Save any changes
            For Each row As TableRow In tblTypesOfCases.Rows
                For Each cell As TableCell In row.Cells
                    For Each cont As Control In cell.Controls
                        oTypesOfCases.SaveCaseReportingTypesOfCases(LawFirmID)
                    Next
                Next
            Next
        Catch ex As Exception

        End Try
    End Sub
#End Region

End Class
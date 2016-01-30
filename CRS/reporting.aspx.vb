Imports System.Drawing
Imports CRS_BLL
Imports CRS_Common

Public Class reporting
    Inherits System.Web.UI.Page


#Region "Members"
    ''' <summary>
    ''' Used to select the panel to be visible
    ''' </summary>
    ''' <remarks></remarks>
    Private Enum PanelState
        Login
        Welcome
        Report
    End Enum
#End Region

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

#End Region

#Region "Event Handlers"
    ''' <summary>
    ''' Page load handler
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '**********************************************************************************************************************
        ' Old Way
        '**********************************************************************************************************************

        ' ''http://www.casereporting.com/reporting.aspx?rep=rf&cid=100000001&lfid=100077171&aid=100008084&crhlf=100002851

        ''If Not IsPostBack Then

        ''    'Check to see if we are logged in or not
        ''    If Logged_In <> "Yes" Then
        ''        'Loggin
        ''        Response.Redirect("login.aspx?rep=" & Trim(Request.QueryString("rep")) & "&cid=" & Trim(Request.QueryString("cid")) & "&lfid=" & Trim(Request.QueryString("lfid") & " &aid=" & Trim(Request.QueryString("aid")) & "&crhlf=" & Trim(Request.QueryString("crhlf"))))
        ''    Else
        ''        Select Case Request.QueryString("rep")
        ''            Case "rf"
        ''                ' Get the information
        ''                If Clients_Case_Reporting.Clients_Case_Reporting_ID <= 0 Then
        ''                    'No data available - just display welcome message
        ''                    pnl_Referral_Feedback.Visible = False
        ''                    pnl_Welcome.Visible = True
        ''                Else
        ''                    'Display the case data
        ''                    pnl_Welcome.Visible = False
        ''                    pnl_Referral_Feedback.Visible = True
        ''                End If

        ''                'Hide Case Reporting
        ''                pnl_Case_Reporting.Visible = False

        ''                'Show case information
        ''                lblCaseInformation.Text = ""

        ''                'Get client information
        ''                Dim oClient As New CaseReporting_Client
        ''                oClient.GetCaseReportingClient(Clients_Case_Reporting.Clients_Case_Reporting_Client_ID.ToString())

        ''                'Get intake questions and answers information
        ''                Dim oClient_Intake_Questions_And_Responses As New CaseReporting_Client_Intake_Questions_And_Responses
        ''                oClient_Intake_Questions_And_Responses.GetCaseReportingClientIntakeQuestionsAndAnswers(Clients_Case_Reporting.Clients_Case_Reporting_Client_ID.ToString())

        ''                'Get attorney information
        ''                Dim oAttorney As New CaseReporting_Attorney
        ''                oAttorney.GetCaseReportingAttorney(Clients_Case_Reporting.Clients_Case_Reporting_Attorney_ID.ToString())

        ''                'Get preamble inforamtion
        ''                Dim oPreambles As New CaseReporting_Preambles
        ''                oPreambles.GetCaseReportingPreambles(Clients_Case_Reporting.Clients_Case_Reporting_Law_Firm_ID.ToString())

        ''                'Get type of case and marketing fees inforamtion
        ''                Dim oType_Of_Case_And_Marketing_Fees As New CaseReporting_Type_Of_Case_And_Marketing_Fees
        ''                oType_Of_Case_And_Marketing_Fees.GetCaseReportingType_Of_Case_And_Marketing_Fees(Clients_Case_Reporting.Clients_Case_Reporting_Law_Firm_ID.ToString())

        ''                '
        ''                '   Build Body of message
        ''                '
        ''                Dim strBody As String
        ''                Dim strSpaces As String
        ''                strSpaces = "&nbsp;&nbsp;&nbsp;"
        ''                strBody = "<br><br>"

        ''                '
        ''                ' Preamble
        ''                '
        ''                If oPreambles.Preambles.Count > 0 Then
        ''                    For Each preamble As CaseReporting_Preamble In oPreambles.Preambles
        ''                        strBody = strBody & _
        ''                            "Pursuant to that certain " & _
        ''                            preamble.Preamble_Agreement & _
        ''                            " dated " & _
        ''                            preamble.Preamble_Date & _
        ''                            " between " & _
        ''                            preamble.Preamble_Referral_Law_Firm_Full_Name & _
        ''                            " (" & Chr(34) & preamble.Preamble_Referral_Law_Firm_Acronym & Chr(34) & ")" & _
        ''                            " and " & _
        ''                            preamble.Preamble_Law_Firm_Full_Name & _
        ''                            preamble.Preamble_Law_Firm_Modifications_of_Agreeement & _
        ''                            ", " & _
        ''                            preamble.Preamble_Referral_Law_Firm_Acronym & " " & _
        ''                            " is most pleased to forward " & _
        ''                            oClient.Clients_Full_Name & _
        ''                            " to you as a prospective client.<br>"
        ''                        strBody = strBody & "<br><br>"
        ''                    Next
        ''                Else
        ''                    strBody = strBody & _
        ''                            "Frisbee & Merchant, LLC is most pleased to forward " & _
        ''                            oClient.Clients_Full_Name & _
        ''                            " to you as a prospective client.<br>"
        ''                End If
        ''                strBody = strBody & "<br><br>"

        ''                '
        ''                '   Prospective Client
        ''                '
        ''                If Len(oClient.Clients_Full_Name) <> 0 Or Len(oClient.Clients_Salutation) <> 0 Or _
        ''                    Len(oClient.Clients_ToC_Type_of_Case) <> 0 Or Len(oClient.Clients_ID_Formatted) <> 0 Or _
        ''                    Len(oClient.Clients_Date_Time_Created) <> 0 Then
        ''                    strBody = strBody & "<b><u>Prospective Client</u></b><br>"
        ''                    If Len(oClient.Clients_Full_Name) <> 0 Then strBody = strBody & strSpaces & "Name: " & oClient.Clients_Full_Name & "<br>"
        ''                    If Len(oClient.Clients_Salutation) <> 0 Then strBody = strBody & strSpaces & "Salutation: " & oClient.Clients_Salutation & "<br>"
        ''                    If Len(oClient.Clients_ToC_Type_of_Case) <> 0 Then strBody = strBody & strSpaces & "Type of Case: " & oClient.Clients_ToC_Type_of_Case & "<br>"
        ''                    If Len(oClient.Clients_ID_Formatted) <> 0 Then strBody = strBody & strSpaces & "Client ID: " & oClient.Clients_ID_Formatted & "<br>"
        ''                    If Len(oClient.Clients_Date_Time_Created) <> 0 Then strBody = strBody & strSpaces & "Date of Contact: " & Replace(oClient.Clients_Date_Time_Created.ToString(), "#", "") & "<br>"
        ''                    strBody = strBody & "<br><br>"
        ''                End If

        ''                '
        ''                '   Telephone Numbers
        ''                '
        ''                If Len(oClient.Clients_Time_Zone) <> 0 Or Len(oClient.Clients_Telephone_Number_Best_Time_To_Call) <> 0 Or _
        ''                    Len(oClient.Clients_Telephone_Number) <> 0 Or Len(oClient.Clients_Telephone_Number_Mobile) <> 0 Or _
        ''                    Len(oClient.Clients_Telephone_Number_Home) <> 0 Or Len(oClient.Clients_Telephone_Number_Work) <> 0 Or _
        ''                    Len(oClient.Clients_Telephone_Number_Fax) <> 0 Then
        ''                    strBody = strBody & "<b><u>Telephone Numbers</u></b><br>"
        ''                    If Len(oClient.Clients_Time_Zone) <> 0 Then strBody = strBody & strSpaces & "Time Zone: " & oClient.Clients_Time_Zone & "<br>"
        ''                    If Len(oClient.Clients_Telephone_Number_Best_Time_To_Call) <> 0 Then strBody = strBody & strSpaces & "Best Time to Call: " & oClient.Clients_Telephone_Number_Best_Time_To_Call & "<br>"
        ''                    If Len(oClient.Clients_Telephone_Number) <> 0 Then strBody = strBody & strSpaces & "Telephone Number: " & oClient.Clients_Telephone_Number & "<br>"
        ''                    If Len(oClient.Clients_Telephone_Number_Mobile) <> 0 Then strBody = strBody & strSpaces & "Mobile: " & oClient.Clients_Telephone_Number_Mobile & "<br>"
        ''                    If Len(oClient.Clients_Telephone_Number_Home) <> 0 Then strBody = strBody & strSpaces & "Home: " & oClient.Clients_Telephone_Number_Home & "<br>"
        ''                    If Len(oClient.Clients_Telephone_Number_Work) <> 0 Then strBody = strBody & strSpaces & "Work: " & oClient.Clients_Telephone_Number_Work
        ''                    If Len(oClient.Clients_Telephone_Number_Work_Ext) <> 0 Then
        ''                        strBody = strBody & " ext." & oClient.Clients_Telephone_Number_Work_Ext & "<br>"
        ''                    Else
        ''                        strBody = strBody & "<br>"
        ''                    End If
        ''                    If Len(oClient.Clients_Telephone_Number_Fax) <> 0 Then strBody = strBody & strSpaces & "Fax: " & oClient.Clients_Telephone_Number_Fax & "<br>"
        ''                    strBody = strBody & "<br><br>"
        ''                End If

        ''                '
        ''                '   E-mail Address
        ''                '
        ''                If Len(oClient.Clients_Email_Address) <> 0 Or Len(oClient.Clients_Email_Addresses_Other) <> 0 Then
        ''                    strBody = strBody & "<b><u>E-mail Address</u></b><br>"
        ''                    If Len(oClient.Clients_Email_Address) <> 0 Then strBody = strBody & strSpaces & "E-mail Address: " & oClient.Clients_Email_Address & "<br>"
        ''                    If Len(oClient.Clients_Email_Addresses_Other) <> 0 Then strBody = strBody & strSpaces & "Other e-mail addresses: " & oClient.Clients_Email_Addresses_Other & "<br>"
        ''                    strBody = strBody & "<br><br>"
        ''                End If

        ''                '
        ''                '   Location
        ''                '
        ''                If Len(oClient.Clients_State) <> 0 Or Len(oClient.Clients_County) <> 0 Or _
        ''                    Len(oClient.Clients_City) <> 0 Or Len(oClient.Clients_Telephone_Number_Mobile) <> 0 Or _
        ''                    Len(oClient.Clients_Address) <> 0 Then
        ''                    strBody = strBody & "<b><u>Location</u></b><br>"
        ''                    If Len(oClient.Clients_State) <> 0 Then strBody = strBody & strSpaces & "State: " & oClient.Clients_State & "<br>"
        ''                    If Len(oClient.Clients_County) <> 0 Then strBody = strBody & strSpaces & "County: " & oClient.Clients_County & "<br>"
        ''                    If Len(oClient.Clients_City) <> 0 Then strBody = strBody & strSpaces & "City: " & oClient.Clients_City & "<br>"
        ''                    If Len(oClient.Clients_Zip_Code) <> 0 Then strBody = strBody & strSpaces & "Zip Code: " & oClient.Clients_Zip_Code & "<br>"
        ''                    If Len(oClient.Clients_Address) <> 0 Then strBody = strBody & strSpaces & "Address: " & oClient.Clients_Address & "<br>"
        ''                    strBody = strBody & "<br><br>"
        ''                End If

        ''                '
        ''                '   Personal Background
        ''                '
        ''                If Len(oClient.Clients_Sex) <> 0 Or Len(oClient.Clients_Social_Security_Number) <> 0 Or _
        ''                    Len(oClient.Clients_Date_of_Birth) <> 0 Or Len(oClient.Clients_Education) <> 0 Then
        ''                    strBody = strBody & "<b><u>Personal Background</u></b><br>"
        ''                    If Len(oClient.Clients_Sex) <> 0 Then strBody = strBody & strSpaces & "Sex: " & oClient.Clients_Sex & "<br>"
        ''                    If Len(oClient.Clients_Social_Security_Number) <> 0 Then strBody = strBody & strSpaces & "Social Security Number: " & Format(oClient.Clients_Social_Security_Number, "000-000-000") & "<br>"
        ''                    If Len(oClient.Clients_Date_of_Birth) <> 0 Then strBody = strBody & strSpaces & "Date of Birth: " & Replace(oClient.Clients_Date_of_Birth.ToString().ToString(), "#", "") & "<br>"
        ''                    If Len(oClient.Clients_Education) <> 0 Then strBody = strBody & strSpaces & "Education: " & oClient.Clients_Education & "<br>"
        ''                    strBody = strBody & "<br><br>"
        ''                End If

        ''                '
        ''                '   Type Of Case and Marketing Fees
        ''                '
        ''                'If Len(oType_Of_Case_And_Marketing_Fees.Main_Category.ToString()) <> 0 Or Len(oType_Of_Case_And_Marketing_Fees.ID.ToString()) <> 0 Or _
        ''                '    Len(oType_Of_Case_And_Marketing_Fees.Type_Of_Case.ToString()) <> 0 Or Len(oType_Of_Case_And_Marketing_Fees.Flat_Fee_or_Sliding_Scale.ToString()) <> 0 Or _
        ''                '    Len(oType_Of_Case_And_Marketing_Fees.Level_Of_Damages.ToString()) <> 0 Or Len(oType_Of_Case_And_Marketing_Fees.Marketing_Fee_Flat_Fee_Amount.ToString()) <> 0 Or _
        ''                '    Len(oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_1.ToString()) <> 0 Or Len(oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_2.ToString()) <> 0 Or _
        ''                '    Len(oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_3.ToString()) <> 0 Or Len(oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_4.ToString()) <> 0 Or _
        ''                '    Len(oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_5.ToString()) <> 0 Or Len(oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_6.ToString()) <> 0 Or _
        ''                '    Len(oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_7.ToString()) Then
        ''                '    strBody = strBody & "<b><u>Type of Case and Marketing Fee</u></b><br>"
        ''                '    If Len(oType_Of_Case_And_Marketing_Fees.Main_Category) <> 0 Then strBody = strBody & strSpaces & "Type of Case - Main Category: " & oType_Of_Case_And_Marketing_Fees.Main_Category & "<br>"
        ''                '    If Len(oType_Of_Case_And_Marketing_Fees.ID) <> 0 Then strBody = strBody & strSpaces & "Type of Case ID: " & oType_Of_Case_And_Marketing_Fees.ID & "<br>"
        ''                '    If Len(oType_Of_Case_And_Marketing_Fees.Type_Of_Case) <> 0 Then strBody = strBody & strSpaces & "Type of Case: " & oType_Of_Case_And_Marketing_Fees.Type_Of_Case & "<br>"
        ''                '    If Len(oType_Of_Case_And_Marketing_Fees.Flat_Fee_or_Sliding_Scale) <> 0 Then strBody = strBody & strSpaces & "Flat Fee or Sliding Scale: " & oType_Of_Case_And_Marketing_Fees.Flat_Fee_or_Sliding_Scale & "<br>"
        ''                '    If Len(oType_Of_Case_And_Marketing_Fees.Level_Of_Damages) <> 0 Then strBody = strBody & strSpaces & "Level of Damages: " & oType_Of_Case_And_Marketing_Fees.Level_Of_Damages & "<br>"
        ''                '    If Len(oType_Of_Case_And_Marketing_Fees.Marketing_Fee_Flat_Fee_Amount) <> 0 Then strBody = strBody & strSpaces & "Marketing Fee: " & oType_Of_Case_And_Marketing_Fees.Marketing_Fee_Flat_Fee_Amount & "<br>"
        ''                '    If Len(oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_1) <> 0 Then strBody = strBody & strSpaces & oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_1 & "<br>"
        ''                '    If Len(oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_2) <> 0 Then strBody = strBody & strSpaces & oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_2 & "<br>"
        ''                '    If Len(oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_3) <> 0 Then strBody = strBody & strSpaces & oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_3 & "<br>"
        ''                '    If Len(oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_4) <> 0 Then strBody = strBody & strSpaces & oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_4 & "<br>"
        ''                '    If Len(oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_5) <> 0 Then strBody = strBody & strSpaces & oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_5 & "<br>"
        ''                '    If Len(oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_6) <> 0 Then strBody = strBody & strSpaces & oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_6 & "<br>"
        ''                '    If Len(oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_7) <> 0 Then strBody = strBody & strSpaces & oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_7 & "<br>"
        ''                '    strBody = strBody & "<br><br>"
        ''                'End If

        ''                '
        ''                '   Comments
        ''                '
        ''                If Len(oClient.Clients_Initial_Message_from_Client) <> 0 Or Len(oClient.Clients_Comments_Overall) <> 0 Or _
        ''                    Len(oClient.Clients_Contact_History) <> 0 Or Len(oClient.Clients_Description_of_the_Case) <> 0 Or _
        ''                    Len(oClient.Clients_Case_Writeup) <> 0 Or Len(oClient.Clients_Case_Writeup_Disguised) <> 0 Then
        ''                    strBody = strBody & "<b><u>Comments</u></b><br>"
        ''                    If Len(oClient.Clients_Initial_Message_from_Client) <> 0 Then strBody = strBody & strSpaces & "Initial Message From Client: " & oClient.Clients_Initial_Message_from_Client & "<br><br>"
        ''                    If Len(oClient.Clients_Comments_Overall) <> 0 Then strBody = strBody & strSpaces & "Overall Comments: " & oClient.Clients_Comments_Overall & "<br><br>"
        ''                    If Len(oClient.Clients_Contact_History) <> 0 Then strBody = strBody & strSpaces & "Chronological History: " & oClient.Clients_Contact_History & "<br><br>"
        ''                    If Len(oClient.Clients_Description_of_the_Case) <> 0 Then strBody = strBody & strSpaces & "Description of the Case: " & oClient.Clients_Description_of_the_Case & "<br><br>"
        ''                    If Len(oClient.Clients_Case_Writeup) <> 0 Then strBody = strBody & strSpaces & "Case Write-up: " & oClient.Clients_Case_Writeup & "<br><br>"
        ''                    If Len(oClient.Clients_Case_Writeup_Disguised) <> 0 Then strBody = strBody & strSpaces & "Case Write-up: " & oClient.Clients_Case_Writeup_Disguised & "<br>"
        ''                    strBody = strBody & "<br><br>"
        ''                End If

        ''                '
        ''                '   Case Evaluation
        ''                '
        ''                If Len(oClient.Clients_Case_Evaluation_Liability) <> 0 Or Len(oClient.Clients_Case_Evaluation_Causation) <> 0 Or _
        ''                    Len(oClient.Clients_Case_Evaluation_Potential_Defendants) <> 0 Or Len(oClient.Clients_Case_Evaluation_Insurance_Policies) <> 0 Or _
        ''                    Len(oClient.Clients_Case_Evaluation_Counterclaims) <> 0 Then
        ''                    strBody = strBody & "<b><u>Case Evaluation</u></b><br>"
        ''                    If Len(oClient.Clients_Case_Evaluation_Liability) <> 0 Then strBody = strBody & strSpaces & "Liability: " & oClient.Clients_Case_Evaluation_Liability & "<br><br>"
        ''                    If Len(oClient.Clients_Case_Evaluation_Causation) <> 0 Then strBody = strBody & strSpaces & "Causation: " & oClient.Clients_Case_Evaluation_Causation & "<br><br>"
        ''                    If Len(oClient.Clients_Case_Evaluation_Potential_Defendants) <> 0 Then strBody = strBody & strSpaces & "Potential Defendants: " & oClient.Clients_Case_Evaluation_Potential_Defendants & "<br><br>"
        ''                    If Len(oClient.Clients_Case_Evaluation_Insurance_Policies) <> 0 Then strBody = strBody & strSpaces & "Insurance Policies: " & oClient.Clients_Case_Evaluation_Insurance_Policies & "<br><br>"
        ''                    If Len(oClient.Clients_Case_Evaluation_Counterclaims) <> 0 Then strBody = strBody & strSpaces & "Counterclaims: " & oClient.Clients_Case_Evaluation_Counterclaims & "<br>"
        ''                    strBody = strBody & "<br><br>"
        ''                End If

        ''                '
        ''                '   Damages
        ''                '
        ''                If Len(oClient.Clients_Case_Evaluation_Damages_Bodily_Injury_Text) <> 0 Or Len(oClient.Clients_Case_Evaluation_Damages_Other_Personal_Injury_Text) <> 0 Or _
        ''                    Len(oClient.Clients_Case_Evaluation_Damages_Medical_Expenses_Text) <> 0 Or Len(oClient.Clients_Case_Evaluation_Damages_Other_OoP_Expenses_Text) <> 0 Or _
        ''                    Len(oClient.Clients_Case_Evaluation_Damages_Lost_Wages_Text) <> 0 Or Len(oClient.Clients_Case_Evaluation_Damages_Lost_Income_Text) <> 0 Or _
        ''                    Len(oClient.Clients_Case_Evaluation_Damages_Pain_and_Suffering_Text) <> 0 Or Len(oClient.Clients_Case_Evaluation_Damages_Emotional_Damages_Text) <> 0 Or _
        ''                    Len(oClient.Clients_Case_Evaluation_Damages_Loss_of_Consortium_Text) <> 0 Or Len(oClient.Clients_Case_Evaluation_Damages_Loss_of_Companionship_Text) <> 0 Or _
        ''                    Len(oClient.Clients_Case_Evaluation_Damages_Miscellaneous_and_Other_Text) <> 0 Or Len(oClient.Clients_Case_Evaluation_Damages_Punitive_Damages_Text) <> 0 Or _
        ''                    Len(oClient.Clients_Case_Evaluation_Damages_Total_Text) <> 0 Then
        ''                    strBody = strBody & "<b><u>Damages</u></b><br>"
        ''                    If Len(oClient.Clients_Case_Evaluation_Damages_Bodily_Injury_Text) <> 0 Then strBody = strBody & strSpaces & "Bodily Injury: " & oClient.Clients_Case_Evaluation_Damages_Bodily_Injury_Text & " -- " & Format(oClient.Clients_Case_Evaluation_Damages_Bodily_Injury_Amount, "$#,##0") & "<br><br>"
        ''                    If Len(oClient.Clients_Case_Evaluation_Damages_Other_Personal_Injury_Text) <> 0 Then strBody = strBody & strSpaces & "Other Personal Injury: " & oClient.Clients_Case_Evaluation_Damages_Other_Personal_Injury_Text & " -- " & Format(oClient.Clients_Case_Evaluation_Damages_Other_Personal_Injury_Amount, "$#,##0") & "<br><br>"
        ''                    If Len(oClient.Clients_Case_Evaluation_Damages_Medical_Expenses_Text) <> 0 Then strBody = strBody & strSpaces & "Medical Expenses: " & oClient.Clients_Case_Evaluation_Damages_Medical_Expenses_Text & " -- " & Format(oClient.Clients_Case_Evaluation_Damages_Medical_Expenses_Amount, "$#,##0") & "<br><br>"
        ''                    If Len(oClient.Clients_Case_Evaluation_Damages_Other_OoP_Expenses_Text) <> 0 Then strBody = strBody & strSpaces & "Other Out-of-Pocket Expenses: " & oClient.Clients_Case_Evaluation_Damages_Other_OoP_Expenses_Text & " -- " & Format(oClient.Clients_Case_Evaluation_Damages_Other_OoP_Expenses_Amount, "$#,##0") & "<br><br>"
        ''                    If Len(oClient.Clients_Case_Evaluation_Damages_Lost_Wages_Text) <> 0 Then strBody = strBody & strSpaces & "Lost Wages: " & oClient.Clients_Case_Evaluation_Damages_Lost_Wages_Text & " -- " & Format(oClient.Clients_Case_Evaluation_Damages_Lost_Wages_Amount, "$#,##0") & "<br><br>"
        ''                    If Len(oClient.Clients_Case_Evaluation_Damages_Lost_Income_Text) <> 0 Then strBody = strBody & strSpaces & "Lost Income: " & oClient.Clients_Case_Evaluation_Damages_Lost_Income_Text & " -- " & Format(oClient.Clients_Case_Evaluation_Damages_Lost_Income_Amount, "$#,##0") & "<br><br>"
        ''                    If Len(oClient.Clients_Case_Evaluation_Damages_Pain_and_Suffering_Text) <> 0 Then strBody = strBody & strSpaces & "Pain and Suffering: " & oClient.Clients_Case_Evaluation_Damages_Pain_and_Suffering_Text & " -- " & Format(oClient.Clients_Case_Evaluation_Damages_Pain_and_Suffering_Amount, "$#,##0") & "<br><br>"
        ''                    If Len(oClient.Clients_Case_Evaluation_Damages_Emotional_Damages_Text) <> 0 Then strBody = strBody & strSpaces & "Emotional Damages: " & oClient.Clients_Case_Evaluation_Damages_Emotional_Damages_Text & " -- " & Format(oClient.Clients_Case_Evaluation_Damages_Emotional_Damages_Amount, "$#,##0") & "<br><br>"
        ''                    If Len(oClient.Clients_Case_Evaluation_Damages_Loss_of_Consortium_Text) <> 0 Then strBody = strBody & strSpaces & "Loss of Consortium: " & oClient.Clients_Case_Evaluation_Damages_Loss_of_Consortium_Text & " -- " & Format(oClient.Clients_Case_Evaluation_Damages_Loss_of_Consortium_Amount, "$#,##0") & "<br><br>"
        ''                    If Len(oClient.Clients_Case_Evaluation_Damages_Loss_of_Companionship_Text) <> 0 Then strBody = strBody & strSpaces & "Loss of Companionship: " & oClient.Clients_Case_Evaluation_Damages_Loss_of_Companionship_Text & " -- " & Format(oClient.Clients_Case_Evaluation_Damages_Loss_of_Companionship_Amount, "$#,##0") & "<br><br>"
        ''                    If Len(oClient.Clients_Case_Evaluation_Damages_Miscellaneous_and_Other_Text) <> 0 Then strBody = strBody & strSpaces & "Miscellaneous: " & oClient.Clients_Case_Evaluation_Damages_Miscellaneous_and_Other_Text & " -- " & Format(oClient.Clients_Case_Evaluation_Damages_Miscellaneous_and_Other_Amount, "$#,##0") & "<br><br>"
        ''                    If Len(oClient.Clients_Case_Evaluation_Damages_Punitive_Damages_Text) <> 0 Then strBody = strBody & strSpaces & "Punitive Damages: " & oClient.Clients_Case_Evaluation_Damages_Punitive_Damages_Text & " -- " & Format(oClient.Clients_Case_Evaluation_Damages_Punitive_Damages_Amount, "$#,##0") & "<br><br>"
        ''                    If Len(oClient.Clients_Case_Evaluation_Damages_Total_Text) <> 0 Then strBody = strBody & strSpaces & "Total Damages: " & oClient.Clients_Case_Evaluation_Damages_Total_Text & " -- " & Format(oClient.Clients_Case_Evaluation_Damages_Total_Amount, "$#,##0") & "<br><br>"
        ''                End If


        ''                '
        ''                '   Intake Questions and Responses
        ''                '
        ''                Dim int_Question_Number As Integer = 1
        ''                Dim int_Sub_Question_Letter As Integer = 97

        ''                If oClient_Intake_Questions_And_Responses.Client_Intake_Questions_And_Responses.Count > 0 Then
        ''                    strBody = strBody & "<b><u>Intake Questions and Responses</u></b><br>"
        ''                    For Each clientintakequestionsandresponses As CaseReporting_Client_Intake_Question_And_Response In oClient_Intake_Questions_And_Responses.Client_Intake_Questions_And_Responses
        ''                        'Check to see if this is a explanation - if so put "Explanantion :" before
        ''                        If clientintakequestionsandresponses.Clients_IQA_IQR_Question_Number = 0 Then
        ''                            If clientintakequestionsandresponses.Clients_IQA_IQR_Level_I_or_II_Question = "Level II" Then
        ''                                If Len(clientintakequestionsandresponses.Clients_IQA_IQR_Intake_Question) <> 0 Then
        ''                                    strBody = strBody & strSpaces & strSpaces & strSpaces & strSpaces & strSpaces & "(" & Chr(int_Sub_Question_Letter) & ") " & _
        ''                                              clientintakequestionsandresponses.Clients_IQA_IQR_Intake_Question
        ''                                End If
        ''                                If Len(clientintakequestionsandresponses.Clients_IQA_IQR_Response_to_Intake_Question) <> 0 Then
        ''                                    strBody = strBody & " -- " & clientintakequestionsandresponses.Clients_IQA_IQR_Response_to_Intake_Question
        ''                                End If
        ''                                'Increment sub question number
        ''                                int_Sub_Question_Letter = int_Sub_Question_Letter + 1
        ''                            Else
        ''                                If Len(clientintakequestionsandresponses.Clients_IQA_IQR_Intake_Question) <> 0 Then
        ''                                    strBody = strBody & strSpaces & strSpaces & clientintakequestionsandresponses.Clients_IQA_IQR_Intake_Question
        ''                                End If
        ''                                If Len(clientintakequestionsandresponses.Clients_IQA_IQR_Response_to_Intake_Question) <> 0 Then
        ''                                    strBody = strBody & " -- " & clientintakequestionsandresponses.Clients_IQA_IQR_Response_to_Intake_Question
        ''                                End If
        ''                            End If
        ''                        Else
        ''                            If Len(clientintakequestionsandresponses.Clients_IQA_IQR_Intake_Question) <> 0 Then
        ''                                strBody = strBody & "<br>" & strSpaces & int_Question_Number & ". " & clientintakequestionsandresponses.Clients_IQA_IQR_Intake_Question
        ''                            End If
        ''                            If Len(clientintakequestionsandresponses.Clients_IQA_IQR_Response_to_Intake_Question) <> 0 Then
        ''                                strBody = strBody & " -- " & clientintakequestionsandresponses.Clients_IQA_IQR_Response_to_Intake_Question
        ''                            End If
        ''                            'Increment quetion number
        ''                            int_Question_Number = int_Question_Number + 1
        ''                            'Reset back to lower case 'a'
        ''                            int_Sub_Question_Letter = 97
        ''                        End If
        ''                        strBody = strBody & "<br><br>"
        ''                    Next
        ''                End If

        ''                'Set the case information
        ''                lblCaseInformation.Text = strBody


        ''            Case "cr"
        ''                ' Get the information
        ''                If Clients_Case_Reporting.Clients_Case_Reporting_ID <= 0 Then
        ''                    'No data available - just display welcome message
        ''                    pnl_Case_Reporting.Visible = False
        ''                    pnl_Welcome.Visible = True
        ''                Else
        ''                    'Display the case data
        ''                    pnl_Welcome.Visible = False
        ''                    pnl_Case_Reporting.Visible = True
        ''                End If
        ''                'Hide Referral Feedback
        ''                pnl_Referral_Feedback.Visible = False

        ''                'txtCaseReportingComments.Text = Format(Now, "MMMM dd, yyyy") & " -- . -- " & _
        ''                '    Clients_Case_Reporting.Clients_Case_Reporting_Attorney_Full_Name & "  " & _
        ''                '    Clients_Case_Reporting.Clients_Case_Reporting_Attorney_ID & vbCrLf & vbCrLf & _
        ''                ' Clients_Case_Reporting.Clients_Case_Reporting_Law_Firm_Comments

        ''                'Set focus to the comments
        ''                txtCaseReportingComments.Focus()
        ''        End Select
        ''    End If
        ''End If





        '**********************************************************************************************************************
        ' New Way
        '**********************************************************************************************************************

        'http://www.casereporting.com/reporting.aspx?rep=rf&cid=100000001&lfid=100077171&lftoken=100000001&aid=100008084&atttoken=100000001&crhlf=100002851

        'http://www.casereporting.com/login.aspx?rep=rf&cid=100037873&lfid=100098789&lftoken=139873456&aid=100037879&atttoken=387398738&crhlf=100987387.

        If Not IsPostBack Then

            'Check to see if we are logged in or not
            If Logged_In <> "Yes" Then
                'Loggin
                Response.Redirect("login.aspx?rep=" & Trim(Request.QueryString("rep")) & "&cid=" & Trim(Request.QueryString("cid")) & "&lfid=" & Trim(Request.QueryString("lfid") & " &aid=" & Trim(Request.QueryString("aid")) & "&crhlf=" & Trim(Request.QueryString("crhlf"))))
            Else
                Select Case Request.QueryString("rep")
                    Case "rf"
                        ' Get the information
                        If Clients_Case_Reporting.Clients_Case_Reporting_ID <= 0 Then
                            'No data available - just display welcome message
                            pnl_Referral_Feedback.Visible = False
                            pnl_Welcome.Visible = True
                        Else
                            'Display the case data
                            pnl_Welcome.Visible = False
                            pnl_Referral_Feedback.Visible = True
                        End If

                        'Hide Case Reporting
                        pnl_Case_Reporting.Visible = False

                        'Show case information
                        lblCaseInformation.Text = ""

                        'Get client information
                        Dim oClient As New CaseReporting_Client
                        oClient.GetCaseReportingClient(Clients_Case_Reporting.Clients_Case_Reporting_Client_ID.ToString())

                        'Get intake questions and answers information
                        Dim oClient_Intake_Questions_And_Responses As New CaseReporting_Client_Intake_Questions_And_Responses
                        oClient_Intake_Questions_And_Responses.GetCaseReportingClientIntakeQuestionsAndAnswers(Clients_Case_Reporting.Clients_Case_Reporting_Client_ID.ToString())

                        'Get attorney information
                        Dim oAttorney As New CaseReporting_Attorney
                        oAttorney.GetCaseReportingAttorney(Clients_Case_Reporting.Clients_Case_Reporting_Attorney_ID.ToString())

                        'Get preamble inforamtion
                        Dim oPreambles As New CaseReporting_Preambles
                        oPreambles.GetCaseReportingPreambles(Clients_Case_Reporting.Clients_Case_Reporting_Law_Firm_ID.ToString())

                        'Get type of case and marketing fees inforamtion
                        Dim oType_Of_Case_And_Marketing_Fees As New CaseReporting_Type_Of_Case_And_Marketing_Fees
                        oType_Of_Case_And_Marketing_Fees.GetCaseReportingType_Of_Case_And_Marketing_Fees(Clients_Case_Reporting.Clients_Case_Reporting_Law_Firm_ID.ToString())

                        '
                        '   Build Body of message
                        '
                        Dim strBody As String
                        Dim strSpaces As String
                        strSpaces = "&nbsp;&nbsp;&nbsp;"
                        strBody = "<br><br>"

                        '
                        ' Preamble
                        '
                        If oPreambles.Preambles.Count > 0 Then
                            For Each preamble As CaseReporting_Preamble In oPreambles.Preambles
                                strBody = strBody & _
                                    "Pursuant to that certain " & _
                                    preamble.Preamble_Agreement & _
                                    " dated " & _
                                    preamble.Preamble_Date & _
                                    " between " & _
                                    preamble.Preamble_Referral_Law_Firm_Full_Name & _
                                    " (" & Chr(34) & preamble.Preamble_Referral_Law_Firm_Acronym & Chr(34) & ")" & _
                                    " and " & _
                                    preamble.Preamble_Law_Firm_Full_Name & _
                                    preamble.Preamble_Law_Firm_Modifications_of_Agreeement & _
                                    ", " & _
                                    preamble.Preamble_Referral_Law_Firm_Acronym & " " & _
                                    " is most pleased to forward " & _
                                    oClient.Clients_Full_Name & _
                                    " to you as a prospective client.<br>"
                                strBody = strBody & "<br><br>"
                            Next
                        Else
                            strBody = strBody & _
                                    "Frisbee & Merchant, LLC is most pleased to forward " & _
                                    oClient.Clients_Full_Name & _
                                    " to you as a prospective client.<br>"
                        End If
                        strBody = strBody & "<br><br>"

                        '
                        '   Prospective Client
                        '
                        If Len(oClient.Clients_Full_Name) <> 0 Or Len(oClient.Clients_Salutation) <> 0 Or _
                            Len(oClient.Clients_ToC_Type_of_Case) <> 0 Or Len(oClient.Clients_ID_Formatted) <> 0 Or _
                            Len(oClient.Clients_Date_Time_Created) <> 0 Then
                            strBody = strBody & "<b><u>Prospective Client</u></b><br>"
                            If Len(oClient.Clients_Full_Name) <> 0 Then strBody = strBody & strSpaces & "Name: " & oClient.Clients_Full_Name & "<br>"
                            If Len(oClient.Clients_Salutation) <> 0 Then strBody = strBody & strSpaces & "Salutation: " & oClient.Clients_Salutation & "<br>"
                            If Len(oClient.Clients_ToC_Type_of_Case) <> 0 Then strBody = strBody & strSpaces & "Type of Case: " & oClient.Clients_ToC_Type_of_Case & "<br>"
                            If Len(oClient.Clients_ID_Formatted) <> 0 Then strBody = strBody & strSpaces & "Client ID: " & oClient.Clients_ID_Formatted & "<br>"
                            If Len(oClient.Clients_Date_Time_Created) <> 0 Then strBody = strBody & strSpaces & "Date of Contact: " & Replace(oClient.Clients_Date_Time_Created.ToString(), "#", "") & "<br>"
                            strBody = strBody & "<br><br>"
                        End If

                        '
                        '   Telephone Numbers
                        '
                        If Len(oClient.Clients_Time_Zone) <> 0 Or Len(oClient.Clients_Telephone_Number_Best_Time_To_Call) <> 0 Or _
                            Len(oClient.Clients_Telephone_Number) <> 0 Or Len(oClient.Clients_Telephone_Number_Mobile) <> 0 Or _
                            Len(oClient.Clients_Telephone_Number_Home) <> 0 Or Len(oClient.Clients_Telephone_Number_Work) <> 0 Or _
                            Len(oClient.Clients_Telephone_Number_Fax) <> 0 Then
                            strBody = strBody & "<b><u>Telephone Numbers</u></b><br>"
                            If Len(oClient.Clients_Time_Zone) <> 0 Then strBody = strBody & strSpaces & "Time Zone: " & oClient.Clients_Time_Zone & "<br>"
                            If Len(oClient.Clients_Telephone_Number_Best_Time_To_Call) <> 0 Then strBody = strBody & strSpaces & "Best Time to Call: " & oClient.Clients_Telephone_Number_Best_Time_To_Call & "<br>"
                            If Len(oClient.Clients_Telephone_Number) <> 0 Then strBody = strBody & strSpaces & "Telephone Number: " & oClient.Clients_Telephone_Number & "<br>"
                            If Len(oClient.Clients_Telephone_Number_Mobile) <> 0 Then strBody = strBody & strSpaces & "Mobile: " & oClient.Clients_Telephone_Number_Mobile & "<br>"
                            If Len(oClient.Clients_Telephone_Number_Home) <> 0 Then strBody = strBody & strSpaces & "Home: " & oClient.Clients_Telephone_Number_Home & "<br>"
                            If Len(oClient.Clients_Telephone_Number_Work) <> 0 Then strBody = strBody & strSpaces & "Work: " & oClient.Clients_Telephone_Number_Work
                            If Len(oClient.Clients_Telephone_Number_Work_Ext) <> 0 Then
                                strBody = strBody & " ext." & oClient.Clients_Telephone_Number_Work_Ext & "<br>"
                            Else
                                strBody = strBody & "<br>"
                            End If
                            If Len(oClient.Clients_Telephone_Number_Fax) <> 0 Then strBody = strBody & strSpaces & "Fax: " & oClient.Clients_Telephone_Number_Fax & "<br>"
                            strBody = strBody & "<br><br>"
                        End If

                        '
                        '   E-mail Address
                        '
                        If Len(oClient.Clients_Email_Address) <> 0 Or Len(oClient.Clients_Email_Addresses_Other) <> 0 Then
                            strBody = strBody & "<b><u>E-mail Address</u></b><br>"
                            If Len(oClient.Clients_Email_Address) <> 0 Then strBody = strBody & strSpaces & "E-mail Address: " & oClient.Clients_Email_Address & "<br>"
                            If Len(oClient.Clients_Email_Addresses_Other) <> 0 Then strBody = strBody & strSpaces & "Other e-mail addresses: " & oClient.Clients_Email_Addresses_Other & "<br>"
                            strBody = strBody & "<br><br>"
                        End If

                        '
                        '   Location
                        '
                        If Len(oClient.Clients_State) <> 0 Or Len(oClient.Clients_County) <> 0 Or _
                            Len(oClient.Clients_City) <> 0 Or Len(oClient.Clients_Telephone_Number_Mobile) <> 0 Or _
                            Len(oClient.Clients_Address) <> 0 Then
                            strBody = strBody & "<b><u>Location</u></b><br>"
                            If Len(oClient.Clients_State) <> 0 Then strBody = strBody & strSpaces & "State: " & oClient.Clients_State & "<br>"
                            If Len(oClient.Clients_County) <> 0 Then strBody = strBody & strSpaces & "County: " & oClient.Clients_County & "<br>"
                            If Len(oClient.Clients_City) <> 0 Then strBody = strBody & strSpaces & "City: " & oClient.Clients_City & "<br>"
                            If Len(oClient.Clients_Zip_Code) <> 0 Then strBody = strBody & strSpaces & "Zip Code: " & oClient.Clients_Zip_Code & "<br>"
                            If Len(oClient.Clients_Address) <> 0 Then strBody = strBody & strSpaces & "Address: " & oClient.Clients_Address & "<br>"
                            strBody = strBody & "<br><br>"
                        End If

                        '
                        '   Personal Background
                        '
                        If Len(oClient.Clients_Sex) <> 0 Or Len(oClient.Clients_Social_Security_Number) <> 0 Or _
                            Len(oClient.Clients_Date_of_Birth) <> 0 Or Len(oClient.Clients_Education) <> 0 Then
                            strBody = strBody & "<b><u>Personal Background</u></b><br>"
                            If Len(oClient.Clients_Sex) <> 0 Then strBody = strBody & strSpaces & "Sex: " & oClient.Clients_Sex & "<br>"
                            If Len(oClient.Clients_Social_Security_Number) <> 0 Then strBody = strBody & strSpaces & "Social Security Number: " & Format(oClient.Clients_Social_Security_Number, "000-000-000") & "<br>"
                            If Len(oClient.Clients_Date_of_Birth) <> 0 Then strBody = strBody & strSpaces & "Date of Birth: " & Replace(oClient.Clients_Date_of_Birth.ToString().ToString(), "#", "") & "<br>"
                            If Len(oClient.Clients_Education) <> 0 Then strBody = strBody & strSpaces & "Education: " & oClient.Clients_Education & "<br>"
                            strBody = strBody & "<br><br>"
                        End If

                        '
                        '   Type Of Case and Marketing Fees
                        '
                        'If Len(oType_Of_Case_And_Marketing_Fees.Main_Category.ToString()) <> 0 Or Len(oType_Of_Case_And_Marketing_Fees.ID.ToString()) <> 0 Or _
                        '    Len(oType_Of_Case_And_Marketing_Fees.Type_Of_Case.ToString()) <> 0 Or Len(oType_Of_Case_And_Marketing_Fees.Flat_Fee_or_Sliding_Scale.ToString()) <> 0 Or _
                        '    Len(oType_Of_Case_And_Marketing_Fees.Level_Of_Damages.ToString()) <> 0 Or Len(oType_Of_Case_And_Marketing_Fees.Marketing_Fee_Flat_Fee_Amount.ToString()) <> 0 Or _
                        '    Len(oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_1.ToString()) <> 0 Or Len(oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_2.ToString()) <> 0 Or _
                        '    Len(oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_3.ToString()) <> 0 Or Len(oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_4.ToString()) <> 0 Or _
                        '    Len(oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_5.ToString()) <> 0 Or Len(oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_6.ToString()) <> 0 Or _
                        '    Len(oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_7.ToString()) Then
                        '    strBody = strBody & "<b><u>Type of Case and Marketing Fee</u></b><br>"
                        '    If Len(oType_Of_Case_And_Marketing_Fees.Main_Category) <> 0 Then strBody = strBody & strSpaces & "Type of Case - Main Category: " & oType_Of_Case_And_Marketing_Fees.Main_Category & "<br>"
                        '    If Len(oType_Of_Case_And_Marketing_Fees.ID) <> 0 Then strBody = strBody & strSpaces & "Type of Case ID: " & oType_Of_Case_And_Marketing_Fees.ID & "<br>"
                        '    If Len(oType_Of_Case_And_Marketing_Fees.Type_Of_Case) <> 0 Then strBody = strBody & strSpaces & "Type of Case: " & oType_Of_Case_And_Marketing_Fees.Type_Of_Case & "<br>"
                        '    If Len(oType_Of_Case_And_Marketing_Fees.Flat_Fee_or_Sliding_Scale) <> 0 Then strBody = strBody & strSpaces & "Flat Fee or Sliding Scale: " & oType_Of_Case_And_Marketing_Fees.Flat_Fee_or_Sliding_Scale & "<br>"
                        '    If Len(oType_Of_Case_And_Marketing_Fees.Level_Of_Damages) <> 0 Then strBody = strBody & strSpaces & "Level of Damages: " & oType_Of_Case_And_Marketing_Fees.Level_Of_Damages & "<br>"
                        '    If Len(oType_Of_Case_And_Marketing_Fees.Marketing_Fee_Flat_Fee_Amount) <> 0 Then strBody = strBody & strSpaces & "Marketing Fee: " & oType_Of_Case_And_Marketing_Fees.Marketing_Fee_Flat_Fee_Amount & "<br>"
                        '    If Len(oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_1) <> 0 Then strBody = strBody & strSpaces & oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_1 & "<br>"
                        '    If Len(oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_2) <> 0 Then strBody = strBody & strSpaces & oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_2 & "<br>"
                        '    If Len(oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_3) <> 0 Then strBody = strBody & strSpaces & oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_3 & "<br>"
                        '    If Len(oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_4) <> 0 Then strBody = strBody & strSpaces & oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_4 & "<br>"
                        '    If Len(oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_5) <> 0 Then strBody = strBody & strSpaces & oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_5 & "<br>"
                        '    If Len(oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_6) <> 0 Then strBody = strBody & strSpaces & oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_6 & "<br>"
                        '    If Len(oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_7) <> 0 Then strBody = strBody & strSpaces & oType_Of_Case_And_Marketing_Fees.Marketing_Sliding_Scale_Amount_Level_7 & "<br>"
                        '    strBody = strBody & "<br><br>"
                        'End If

                        '
                        '   Comments
                        '
                        If Len(oClient.Clients_Initial_Message_from_Client) <> 0 Or Len(oClient.Clients_Comments_Overall) <> 0 Or _
                            Len(oClient.Clients_Contact_History) <> 0 Or Len(oClient.Clients_Description_of_the_Case) <> 0 Or _
                            Len(oClient.Clients_Case_Writeup) <> 0 Or Len(oClient.Clients_Case_Writeup_Disguised) <> 0 Then
                            strBody = strBody & "<b><u>Comments</u></b><br>"
                            If Len(oClient.Clients_Initial_Message_from_Client) <> 0 Then strBody = strBody & strSpaces & "Initial Message From Client: " & oClient.Clients_Initial_Message_from_Client & "<br><br>"
                            If Len(oClient.Clients_Comments_Overall) <> 0 Then strBody = strBody & strSpaces & "Overall Comments: " & oClient.Clients_Comments_Overall & "<br><br>"
                            If Len(oClient.Clients_Contact_History) <> 0 Then strBody = strBody & strSpaces & "Chronological History: " & oClient.Clients_Contact_History & "<br><br>"
                            If Len(oClient.Clients_Description_of_the_Case) <> 0 Then strBody = strBody & strSpaces & "Description of the Case: " & oClient.Clients_Description_of_the_Case & "<br><br>"
                            If Len(oClient.Clients_Case_Writeup) <> 0 Then strBody = strBody & strSpaces & "Case Write-up: " & oClient.Clients_Case_Writeup & "<br><br>"
                            If Len(oClient.Clients_Case_Writeup_Disguised) <> 0 Then strBody = strBody & strSpaces & "Case Write-up: " & oClient.Clients_Case_Writeup_Disguised & "<br>"
                            strBody = strBody & "<br><br>"
                        End If

                        '
                        '   Case Evaluation
                        '
                        If Len(oClient.Clients_Case_Evaluation_Liability) <> 0 Or Len(oClient.Clients_Case_Evaluation_Causation) <> 0 Or _
                            Len(oClient.Clients_Case_Evaluation_Potential_Defendants) <> 0 Or Len(oClient.Clients_Case_Evaluation_Insurance_Policies) <> 0 Or _
                            Len(oClient.Clients_Case_Evaluation_Counterclaims) <> 0 Then
                            strBody = strBody & "<b><u>Case Evaluation</u></b><br>"
                            If Len(oClient.Clients_Case_Evaluation_Liability) <> 0 Then strBody = strBody & strSpaces & "Liability: " & oClient.Clients_Case_Evaluation_Liability & "<br><br>"
                            If Len(oClient.Clients_Case_Evaluation_Causation) <> 0 Then strBody = strBody & strSpaces & "Causation: " & oClient.Clients_Case_Evaluation_Causation & "<br><br>"
                            If Len(oClient.Clients_Case_Evaluation_Potential_Defendants) <> 0 Then strBody = strBody & strSpaces & "Potential Defendants: " & oClient.Clients_Case_Evaluation_Potential_Defendants & "<br><br>"
                            If Len(oClient.Clients_Case_Evaluation_Insurance_Policies) <> 0 Then strBody = strBody & strSpaces & "Insurance Policies: " & oClient.Clients_Case_Evaluation_Insurance_Policies & "<br><br>"
                            If Len(oClient.Clients_Case_Evaluation_Counterclaims) <> 0 Then strBody = strBody & strSpaces & "Counterclaims: " & oClient.Clients_Case_Evaluation_Counterclaims & "<br>"
                            strBody = strBody & "<br><br>"
                        End If

                        '
                        '   Damages
                        '
                        If Len(oClient.Clients_Case_Evaluation_Damages_Bodily_Injury_Text) <> 0 Or Len(oClient.Clients_Case_Evaluation_Damages_Other_Personal_Injury_Text) <> 0 Or _
                            Len(oClient.Clients_Case_Evaluation_Damages_Medical_Expenses_Text) <> 0 Or Len(oClient.Clients_Case_Evaluation_Damages_Other_OoP_Expenses_Text) <> 0 Or _
                            Len(oClient.Clients_Case_Evaluation_Damages_Lost_Wages_Text) <> 0 Or Len(oClient.Clients_Case_Evaluation_Damages_Lost_Income_Text) <> 0 Or _
                            Len(oClient.Clients_Case_Evaluation_Damages_Pain_and_Suffering_Text) <> 0 Or Len(oClient.Clients_Case_Evaluation_Damages_Emotional_Damages_Text) <> 0 Or _
                            Len(oClient.Clients_Case_Evaluation_Damages_Loss_of_Consortium_Text) <> 0 Or Len(oClient.Clients_Case_Evaluation_Damages_Loss_of_Companionship_Text) <> 0 Or _
                            Len(oClient.Clients_Case_Evaluation_Damages_Miscellaneous_and_Other_Text) <> 0 Or Len(oClient.Clients_Case_Evaluation_Damages_Punitive_Damages_Text) <> 0 Or _
                            Len(oClient.Clients_Case_Evaluation_Damages_Total_Text) <> 0 Then
                            strBody = strBody & "<b><u>Damages</u></b><br>"
                            If Len(oClient.Clients_Case_Evaluation_Damages_Bodily_Injury_Text) <> 0 Then strBody = strBody & strSpaces & "Bodily Injury: " & oClient.Clients_Case_Evaluation_Damages_Bodily_Injury_Text & " -- " & Format(oClient.Clients_Case_Evaluation_Damages_Bodily_Injury_Amount, "$#,##0") & "<br><br>"
                            If Len(oClient.Clients_Case_Evaluation_Damages_Other_Personal_Injury_Text) <> 0 Then strBody = strBody & strSpaces & "Other Personal Injury: " & oClient.Clients_Case_Evaluation_Damages_Other_Personal_Injury_Text & " -- " & Format(oClient.Clients_Case_Evaluation_Damages_Other_Personal_Injury_Amount, "$#,##0") & "<br><br>"
                            If Len(oClient.Clients_Case_Evaluation_Damages_Medical_Expenses_Text) <> 0 Then strBody = strBody & strSpaces & "Medical Expenses: " & oClient.Clients_Case_Evaluation_Damages_Medical_Expenses_Text & " -- " & Format(oClient.Clients_Case_Evaluation_Damages_Medical_Expenses_Amount, "$#,##0") & "<br><br>"
                            If Len(oClient.Clients_Case_Evaluation_Damages_Other_OoP_Expenses_Text) <> 0 Then strBody = strBody & strSpaces & "Other Out-of-Pocket Expenses: " & oClient.Clients_Case_Evaluation_Damages_Other_OoP_Expenses_Text & " -- " & Format(oClient.Clients_Case_Evaluation_Damages_Other_OoP_Expenses_Amount, "$#,##0") & "<br><br>"
                            If Len(oClient.Clients_Case_Evaluation_Damages_Lost_Wages_Text) <> 0 Then strBody = strBody & strSpaces & "Lost Wages: " & oClient.Clients_Case_Evaluation_Damages_Lost_Wages_Text & " -- " & Format(oClient.Clients_Case_Evaluation_Damages_Lost_Wages_Amount, "$#,##0") & "<br><br>"
                            If Len(oClient.Clients_Case_Evaluation_Damages_Lost_Income_Text) <> 0 Then strBody = strBody & strSpaces & "Lost Income: " & oClient.Clients_Case_Evaluation_Damages_Lost_Income_Text & " -- " & Format(oClient.Clients_Case_Evaluation_Damages_Lost_Income_Amount, "$#,##0") & "<br><br>"
                            If Len(oClient.Clients_Case_Evaluation_Damages_Pain_and_Suffering_Text) <> 0 Then strBody = strBody & strSpaces & "Pain and Suffering: " & oClient.Clients_Case_Evaluation_Damages_Pain_and_Suffering_Text & " -- " & Format(oClient.Clients_Case_Evaluation_Damages_Pain_and_Suffering_Amount, "$#,##0") & "<br><br>"
                            If Len(oClient.Clients_Case_Evaluation_Damages_Emotional_Damages_Text) <> 0 Then strBody = strBody & strSpaces & "Emotional Damages: " & oClient.Clients_Case_Evaluation_Damages_Emotional_Damages_Text & " -- " & Format(oClient.Clients_Case_Evaluation_Damages_Emotional_Damages_Amount, "$#,##0") & "<br><br>"
                            If Len(oClient.Clients_Case_Evaluation_Damages_Loss_of_Consortium_Text) <> 0 Then strBody = strBody & strSpaces & "Loss of Consortium: " & oClient.Clients_Case_Evaluation_Damages_Loss_of_Consortium_Text & " -- " & Format(oClient.Clients_Case_Evaluation_Damages_Loss_of_Consortium_Amount, "$#,##0") & "<br><br>"
                            If Len(oClient.Clients_Case_Evaluation_Damages_Loss_of_Companionship_Text) <> 0 Then strBody = strBody & strSpaces & "Loss of Companionship: " & oClient.Clients_Case_Evaluation_Damages_Loss_of_Companionship_Text & " -- " & Format(oClient.Clients_Case_Evaluation_Damages_Loss_of_Companionship_Amount, "$#,##0") & "<br><br>"
                            If Len(oClient.Clients_Case_Evaluation_Damages_Miscellaneous_and_Other_Text) <> 0 Then strBody = strBody & strSpaces & "Miscellaneous: " & oClient.Clients_Case_Evaluation_Damages_Miscellaneous_and_Other_Text & " -- " & Format(oClient.Clients_Case_Evaluation_Damages_Miscellaneous_and_Other_Amount, "$#,##0") & "<br><br>"
                            If Len(oClient.Clients_Case_Evaluation_Damages_Punitive_Damages_Text) <> 0 Then strBody = strBody & strSpaces & "Punitive Damages: " & oClient.Clients_Case_Evaluation_Damages_Punitive_Damages_Text & " -- " & Format(oClient.Clients_Case_Evaluation_Damages_Punitive_Damages_Amount, "$#,##0") & "<br><br>"
                            If Len(oClient.Clients_Case_Evaluation_Damages_Total_Text) <> 0 Then strBody = strBody & strSpaces & "Total Damages: " & oClient.Clients_Case_Evaluation_Damages_Total_Text & " -- " & Format(oClient.Clients_Case_Evaluation_Damages_Total_Amount, "$#,##0") & "<br><br>"
                        End If


                        '
                        '   Intake Questions and Responses
                        '
                        Dim int_Question_Number As Integer = 1
                        Dim int_Sub_Question_Letter As Integer = 97

                        If oClient_Intake_Questions_And_Responses.Client_Intake_Questions_And_Responses.Count > 0 Then
                            strBody = strBody & "<b><u>Intake Questions and Responses</u></b><br>"
                            For Each clientintakequestionsandresponses As CaseReporting_Client_Intake_Question_And_Response In oClient_Intake_Questions_And_Responses.Client_Intake_Questions_And_Responses
                                'Check to see if this is a explanation - if so put "Explanantion :" before
                                If clientintakequestionsandresponses.Clients_IQA_IQR_Question_Number = 0 Then
                                    If clientintakequestionsandresponses.Clients_IQA_IQR_Level_I_or_II_Question = "Level II" Then
                                        If Len(clientintakequestionsandresponses.Clients_IQA_IQR_Intake_Question) <> 0 Then
                                            strBody = strBody & strSpaces & strSpaces & strSpaces & strSpaces & strSpaces & "(" & Chr(int_Sub_Question_Letter) & ") " & _
                                                      clientintakequestionsandresponses.Clients_IQA_IQR_Intake_Question
                                        End If
                                        If Len(clientintakequestionsandresponses.Clients_IQA_IQR_Response_to_Intake_Question) <> 0 Then
                                            strBody = strBody & " -- " & clientintakequestionsandresponses.Clients_IQA_IQR_Response_to_Intake_Question
                                        End If
                                        'Increment sub question number
                                        int_Sub_Question_Letter = int_Sub_Question_Letter + 1
                                    Else
                                        If Len(clientintakequestionsandresponses.Clients_IQA_IQR_Intake_Question) <> 0 Then
                                            strBody = strBody & strSpaces & strSpaces & clientintakequestionsandresponses.Clients_IQA_IQR_Intake_Question
                                        End If
                                        If Len(clientintakequestionsandresponses.Clients_IQA_IQR_Response_to_Intake_Question) <> 0 Then
                                            strBody = strBody & " -- " & clientintakequestionsandresponses.Clients_IQA_IQR_Response_to_Intake_Question
                                        End If
                                    End If
                                Else
                                    If Len(clientintakequestionsandresponses.Clients_IQA_IQR_Intake_Question) <> 0 Then
                                        strBody = strBody & "<br>" & strSpaces & int_Question_Number & ". " & clientintakequestionsandresponses.Clients_IQA_IQR_Intake_Question
                                    End If
                                    If Len(clientintakequestionsandresponses.Clients_IQA_IQR_Response_to_Intake_Question) <> 0 Then
                                        strBody = strBody & " -- " & clientintakequestionsandresponses.Clients_IQA_IQR_Response_to_Intake_Question
                                    End If
                                    'Increment quetion number
                                    int_Question_Number = int_Question_Number + 1
                                    'Reset back to lower case 'a'
                                    int_Sub_Question_Letter = 97
                                End If
                                strBody = strBody & "<br><br>"
                            Next
                        End If

                        'Set the case information
                        lblCaseInformation.Text = strBody


                    Case "cr"
                        ' Get the information
                        If Clients_Case_Reporting.Clients_Case_Reporting_ID <= 0 Then
                            'No data available - just display welcome message
                            pnl_Case_Reporting.Visible = False
                            pnl_Welcome.Visible = True
                        Else
                            'Display the case data
                            pnl_Welcome.Visible = False
                            pnl_Case_Reporting.Visible = True
                        End If
                        'Hide Referral Feedback
                        pnl_Referral_Feedback.Visible = False

                        'txtCaseReportingComments.Text = Format(Now, "MMMM dd, yyyy") & " -- . -- " & _
                        '    Clients_Case_Reporting.Clients_Case_Reporting_Attorney_Full_Name & "  " & _
                        '    Clients_Case_Reporting.Clients_Case_Reporting_Attorney_ID & vbCrLf & vbCrLf & _
                        ' Clients_Case_Reporting.Clients_Case_Reporting_Law_Firm_Comments

                        'Set focus to the comments
                        txtCaseReportingComments.Focus()
                End Select
            End If
        End If


    End Sub

    Private Sub btnCaseReportingComments_Click(sender As Object, e As System.EventArgs) Handles btnCaseReportingComments.Click
        Try
            'Add to comments
            Clients_Case_Reporting.Clients_Case_Reporting_Law_Firm_Comments = Format(Now, "MMMM dd, yyyy") & " -- " & txtCaseReportingComments.Text & " -- " & _
                            Clients_Case_Reporting.Clients_Case_Reporting_Attorney_Full_Name & "  " & _
                            Clients_Case_Reporting.Clients_Case_Reporting_Attorney_ID & vbCrLf & vbCrLf & _
                            Clients_Case_Reporting.Clients_Case_Reporting_Law_Firm_Comments


            'Replace CRLF with space
            Clients_Case_Reporting.Clients_Case_Reporting_Law_Firm_Comments = Replace(Clients_Case_Reporting.Clients_Case_Reporting_Law_Firm_Comments, vbCrLf, " ")

            'Save
            Clients_Case_Reporting.SaveClientCaseReportingComments(Clients_Case_Reporting.Clients_Case_Reporting_ID.ToString(), Clients_Case_Reporting.Clients_Case_Reporting_Law_Firm_Comments)

            'Show "Saved" comment
            lblCaseReportingCommentsSaved.Visible = True
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnReferralFeedbackGiveThisCaseToSomeoneElse_Click(sender As Object, e As System.EventArgs) Handles btnReferralFeedbackGiveThisCaseToSomeoneElse.Click

    End Sub

    Private Sub btnReferralFeedbackWellTakeThisCase_Click(sender As Object, e As System.EventArgs) Handles btnReferralFeedbackWellTakeThisCase.Click

    End Sub

#End Region

End Class
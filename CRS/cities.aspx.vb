Imports System.Drawing
Imports CRS_BLL
Imports CRS_Common

Public Class cities
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

    ''' <summary>
    ''' State ID - maintained in Session state
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Property StateID() As String
        Get
            Return Session(Common.ssn_StateID).ToString()
        End Get
        Set(ByVal value As String)
            Session(Common.ssn_StateID) = value
        End Set
    End Property

#End Region

#Region "Events"
    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Try
            Dim str_Previous_State As String
            str_Previous_State = ""

            'Get City inforamtion
            Dim oCities As New CaseReporting_Cities
            oCities.GetCaseReportingCities("")

            If oCities.Cities.Count > 0 Then
                For Each City As CaseReporting_City In oCities.Cities
                    Dim trCity As New TableRow

                    If City.Cities_State_City <> "" Then
                        'if new state add a blank row with state in leftmost cell

                        If City.Cities_State <> str_Previous_State Then
                            'blank row
                            Call RenderBlankRow()
                            Call RenderTable(True, City.Cities_ID, City.Cities_State, City.Cities_State)
                        Else
                            'filled row
                            Call RenderTable(False, City.Cities_ID, City.Cities_City, City.Cities_State)
                        End If
                        str_Previous_State = City.Cities_State
                    End If

                Next
            End If
        Catch ex As Exception

        End Try

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
                tblPreferredCities.Visible = False
                btnSave.Visible = False
                lblSaveComplete.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RenderTable(ByVal StateOnlyRow As Boolean, ByVal Cities_ID As Long, ByVal City As String, ByVal State As String)
        Dim trCity As New TableRow
        Dim tcState As New TableCell
        Dim tcCity As New TableCell
        Dim tcStatus1 As New TableCell
        Dim tcStatus2 As New TableCell
        Dim tcStatus3 As New TableCell
        Dim tcStatus4 As New TableCell
        Dim tcStatus5 As New TableCell
        Dim tcStatus6 As New TableCell
        Dim tcStatus7 As New TableCell
        Dim tcStatus8 As New TableCell

        tcCity.Text = City

        If StateOnlyRow = True Then
            tcState.Text = State
            tcState.ColumnSpan = 10
            tcState.Attributes.Add("class", "Cities__State")
            trCity.Cells.Add(tcState)
        Else
            tcState.Text = ""
            tcCity.Attributes.Add("class", "Cities__City")
           
            'Get Law Firm Cities information
            Dim oLawFirmCities As New CaseReporting_LawFirm_Cities
            oLawFirmCities.GetCaseReportingLawFirmCities(LawFirmID, Cities_ID)

            ' Status 1
            Dim rdoStatus1 As New RadioButton
            '   Set the ID
            rdoStatus1.ID = Cities_ID & "-1"
            '   Set the GroupName
            rdoStatus1.GroupName = Cities_ID.ToString()
            '   Set the Checked Value
            rdoStatus1.Checked = False
            '   Loop through all of the Law Firm City to see if we have a value
            For Each lawfirmCity As CaseReporting_LawFirm_City In oLawFirmCities.LawFirm_Cities
                If lawfirmCity.LawFirm_City_Their_Preference_for_This_City = 1 Then
                    '   Set the Checked Value
                    rdoStatus1.Checked = True
                    Exit For
                End If
            Next
            tcStatus1.Controls.Add(rdoStatus1)

            ' Status 2
            Dim rdoStatus2 As New RadioButton
            '   Set the ID
            rdoStatus2.ID = Cities_ID & "-2"
            '   Set the GroupName
            rdoStatus2.GroupName = Cities_ID.ToString()
            '   Set the Checked Value
            rdoStatus2.Checked = False
            '   Loop through all of the Law Firm City to see if we have a value
            For Each lawfirmCity As CaseReporting_LawFirm_City In oLawFirmCities.LawFirm_Cities
                If lawfirmCity.LawFirm_City_Their_Preference_for_This_City = 2 Then
                    '   Set the Checked Value
                    rdoStatus2.Checked = True
                    Exit For
                End If
            Next
            tcStatus2.Controls.Add(rdoStatus2)

            ' Status 3
            Dim rdoStatus3 As New RadioButton
            '   Set the ID
            rdoStatus3.ID = Cities_ID & "-3"
            '   Set the GroupName
            rdoStatus3.GroupName = Cities_ID.ToString()
            '   Set the Checked Value
            rdoStatus3.Checked = False
            '   Loop through all of the Law Firm City to see if we have a value
            For Each lawfirmCity As CaseReporting_LawFirm_City In oLawFirmCities.LawFirm_Cities
                If lawfirmCity.LawFirm_City_Their_Preference_for_This_City = 3 Then
                    '   Set the Checked Value
                    rdoStatus3.Checked = True
                    Exit For
                End If
            Next
            tcStatus3.Controls.Add(rdoStatus3)

            ' Status 4
            Dim rdoStatus4 As New RadioButton
            '   Set the ID
            rdoStatus4.ID = Cities_ID & "-4"
            '   Set the GroupName
            rdoStatus4.GroupName = Cities_ID.ToString()
            '   Set the Checked Value
            rdoStatus4.Checked = False
            '   Loop through all of the Law Firm City to see if we have a value
            For Each lawfirmCity As CaseReporting_LawFirm_City In oLawFirmCities.LawFirm_Cities
                If lawfirmCity.LawFirm_City_Their_Preference_for_This_City = 4 Then
                    '   Set the Checked Value
                    rdoStatus4.Checked = True
                    Exit For
                End If
            Next
            tcStatus4.Controls.Add(rdoStatus4)

            ' Status 5
            Dim rdoStatus5 As New RadioButton
            '   Set the ID
            rdoStatus5.ID = Cities_ID & "-5"
            '   Set the GroupName
            rdoStatus5.GroupName = Cities_ID.ToString()
            '   Set the Checked Value
            rdoStatus5.Checked = False
            '   Loop through all of the Law Firm City to see if we have a value
            For Each lawfirmCity As CaseReporting_LawFirm_City In oLawFirmCities.LawFirm_Cities
                If lawfirmCity.LawFirm_City_Their_Preference_for_This_City = 5 Then
                    '   Set the Checked Value
                    rdoStatus5.Checked = True
                    Exit For
                End If
            Next
            tcStatus5.Controls.Add(rdoStatus5)

            ' Status 6
            Dim rdoStatus6 As New RadioButton
            '   Set the ID
            rdoStatus6.ID = Cities_ID & "-6"
            '   Set the GroupName
            rdoStatus6.GroupName = Cities_ID.ToString()
            '   Set the Checked Value
            rdoStatus6.Checked = False
            '   Loop through all of the Law Firm City to see if we have a value
            For Each lawfirmCity As CaseReporting_LawFirm_City In oLawFirmCities.LawFirm_Cities
                If lawfirmCity.LawFirm_City_Their_Preference_for_This_City = 6 Then
                    '   Set the Checked Value
                    rdoStatus6.Checked = True
                    Exit For
                End If
            Next
            tcStatus6.Controls.Add(rdoStatus6)

            ' Status 7
            Dim rdoStatus7 As New RadioButton
            '   Set the ID
            rdoStatus7.ID = Cities_ID & "-7"
            '   Set the GroupName
            rdoStatus7.GroupName = Cities_ID.ToString()
            '   Set the Checked Value
            rdoStatus7.Checked = False
            '   Loop through all of the Law Firm City to see if we have a value
            For Each lawfirmCity As CaseReporting_LawFirm_City In oLawFirmCities.LawFirm_Cities
                If lawfirmCity.LawFirm_City_Their_Preference_for_This_City = 7 Then
                    '   Set the Checked Value
                    rdoStatus7.Checked = True
                    Exit For
                End If
            Next
            tcStatus7.Controls.Add(rdoStatus7)

            ' Status 8
            Dim rdoStatus8 As New RadioButton
            '   Set the ID
            rdoStatus8.ID = Cities_ID & "-8"
            '   Set the GroupName
            rdoStatus8.GroupName = Cities_ID.ToString()
            '   Set the Checked Value
            rdoStatus8.Checked = False
            '   Loop through all of the Law Firm City to see if we have a value
            For Each lawfirmCity As CaseReporting_LawFirm_City In oLawFirmCities.LawFirm_Cities
                If lawfirmCity.LawFirm_City_Their_Preference_for_This_City = 8 Then
                    '   Set the Checked Value
                    rdoStatus8.Checked = True
                    Exit For
                End If
            Next
            tcStatus8.Controls.Add(rdoStatus8)

            ' Add Cells
            trCity.Cells.Add(tcState)
            trCity.Cells.Add(tcCity)
            trCity.Cells.Add(tcStatus1)
            trCity.Cells.Add(tcStatus2)
            trCity.Cells.Add(tcStatus3)
            trCity.Cells.Add(tcStatus4)
            trCity.Cells.Add(tcStatus5)
            trCity.Cells.Add(tcStatus6)
            trCity.Cells.Add(tcStatus7)
            trCity.Cells.Add(tcStatus8)
        End If

        ' Set Row Attributes
        trCity.VerticalAlign = VerticalAlign.Bottom
        trCity.HorizontalAlign = HorizontalAlign.Center

        ' Add Row
        If tblPreferredCities.Rows.Count Mod 2 = 1 Then
            trCity.BackColor = Color.FromArgb(234, 234, 234)
        Else
            trCity.BackColor = Color.White
        End If
        tblPreferredCities.Rows.Add(trCity)

    End Sub
    Private Sub RenderBlankRow()
        Dim trCity As New TableRow
        Dim tcState As New TableCell

        tcState.ColumnSpan = 10

        trCity.Attributes.Add("class", "Blank_Colored_Line")

        trCity.Cells.Add(tcState)
        ' Set Row Attributes
        trCity.VerticalAlign = VerticalAlign.Bottom
        trCity.HorizontalAlign = HorizontalAlign.Center

        ' Add Row
        tblPreferredCities.Rows.Add(trCity)
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Call SaveChanges()
    End Sub

    Private Sub Cities_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Call SaveChanges()
    End Sub
#End Region


#Region "Private"
    Private Sub SaveChanges()
        Try
            'Save Law Firm Cities inforamtion
            Dim oLawFirmCities As New CaseReporting_LawFirm_Cities

            'Save any changes
            For Each row As TableRow In tblPreferredCities.Rows
                For Each cell As TableCell In row.Cells
                    For Each cont As Control In cell.Controls
                        If TypeOf (cont) Is RadioButton Then
                            If DirectCast(cont, RadioButton).Checked = True Then
                                'Get the ID
                                Dim sID As String = DirectCast(cont, RadioButton).ID
                                sID = Mid(sID, InStr(sID, "-") + 1)
                                oLawFirmCities.SaveCaseReportingLawFirmCity(LawFirmID, CLng(DirectCast(cont, RadioButton).GroupName), CLng(sID))
                            End If
                        End If
                    Next
                Next
            Next
        Catch ex As Exception

        End Try
    End Sub
#End Region

End Class
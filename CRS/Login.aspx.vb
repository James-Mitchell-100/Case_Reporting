Imports CRS_BLL
Imports CRS_Common

Public Class Login
    Inherits System.Web.UI.Page

#Region "Properties"
    ''' <summary>
    ''' Referring Attorney object - maintained in Session state
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Property Referring_Attorney() As CRS_Referring_Attorney
        Get
            If Object.ReferenceEquals(Session(Common.ssn_Referring_Attorney), Nothing) Then
                Dim temp_CRS_Referring_Attorney As New CRS_Referring_Attorney()
                Return temp_CRS_Referring_Attorney
            Else
                Return CType(Session(Common.ssn_Referring_Attorney), CRS_Referring_Attorney)
            End If
        End Get
        Set(ByVal value As CRS_Referring_Attorney)
            Session(Common.ssn_Referring_Attorney) = value
        End Set
    End Property

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
    ''' Client object - maintained in Session state
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Property Client() As CaseReporting_Client
        Get
            If Object.ReferenceEquals(Session(Common.ssn_Client), Nothing) Then
                Dim temp_Client As New CaseReporting_Client
                Return temp_Client
            Else
                Return CType(Session(Common.ssn_Client), CaseReporting_Client)
            End If
        End Get
        Set(ByVal value As CaseReporting_Client)
            Session(Common.ssn_Client) = value
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

    Protected Property Attorney_Name() As String
        Get
            Return Session(Common.ssn_Attorney).ToString()
        End Get
        Set(ByVal value As String)
            Session(Common.ssn_Attorney) = value
        End Set
    End Property
    Protected Property Law_Firm_Name() As String
        Get
            Return Session(Common.ssn_LawFirmName).ToString()
        End Get
        Set(ByVal value As String)
            Session(Common.ssn_LawFirmName) = value
        End Set
    End Property
#End Region


#Region "Events"
    ''' <summary>
    ''' Handles the form load event event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Clients_Case_Reporting.Clients_Case_Reporting_ID > 0 Then
            Response.Redirect("default.aspx?rep=" & Trim(Request.QueryString("rep")) & "&cid=" & Trim(Request.QueryString("cid")) & "&lfid=" & Trim(Request.QueryString("lfid")) & " &aid=" & Trim(Request.QueryString("aid")) & "&crhlf=" & Trim(Request.QueryString("crhlf")))
        End If
    End Sub

    ''' <summary>
    ''' Handles the login click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btn_CRS_Login_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_CRS_Login.Click

        'CPH 2011-12017 - Code From SVN
        '' Create the Referring Attorney object and attempt to login
        'Dim data_referring_attorney = New CRS_Referring_Attorney
        'data_referring_attorney.Login(txt_CRS_Login_Name.Text.ToString(), txt_CRS_Login_Password.Text.ToString())

        'If data_referring_attorney.Referring_Attorney_ID = 0 Then

        '    'Login failed so display the message
        '    lbl_CRS_Status.Text = "The creditials were not verified, please try again."
        '    lbl_CRS_Status.Visible = True

        'Else
        '    'Login successful so save the Referring_Attorney object and display the welcome panel
        '    Referring_Attorney = data_referring_attorney
        '    Response.Redirect("default.aspx")
        'End If

        ' Create the clients case reporting object and attempt to login
        Dim data_clients_case_reporting = New CaseReporting_Clients_Case_Reporting()
        data_clients_case_reporting.Login(txt_CRS_Login_Name.Text.ToString(), txt_CRS_Login_Password.Text.ToString())

        'Store the Attorney ID and Law Firm ID in the Session
        AttorneyID = data_clients_case_reporting.AttorneyID
        LawFirmID = data_clients_case_reporting.LawFirmID
        Attorney_Name = data_clients_case_reporting.Attorney_Full_Name
        Law_Firm_Name = data_clients_case_reporting.Law_Firm_Full_Name
        If AttorneyID = "" Then
            'Login failed so display the message
            lbl_CRS_Status.Text = "The credentials were not verified, please try again."
            lbl_CRS_Status.Visible = True
            'Not logged in yet
            Logged_In = "No"
        Else
            'Login successful 
            Logged_In = "Yes"
            data_clients_case_reporting.GetClientCaseReporting(Trim(Request.QueryString("rep")), Trim(Request.QueryString("cid")), LawFirmID.ToString(), AttorneyID.ToString(), Trim(Request.QueryString("crhlf")))
            'Put into the Session 
            Clients_Case_Reporting = data_clients_case_reporting
            Response.Redirect("default.aspx?rep=" & Trim(Request.QueryString("rep")) & "&cid=" & Trim(Request.QueryString("cid")) & "&lfid=" & LawFirmID.ToString() & " &aid=" & AttorneyID.ToString() & "&crhlf=" & Trim(Request.QueryString("crhlf")))
        End If


    End Sub
#End Region

End Class
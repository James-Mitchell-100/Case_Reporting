Imports CRS_BLL
Imports CRS_Common
Public Class CRS
    Inherits System.Web.UI.MasterPage
#Region "Properties"
    Protected Property Logged_In() As String
        Get
            Return Session(Common.ssn_Logged_In).ToString()
        End Get
        Set(ByVal value As String)
            Session(Common.ssn_Logged_In) = value
        End Set
    End Property

    
    Protected Property AttorneyID() As String
        Get
            Return Session(Common.ssn_AttorneyID).ToString()
        End Get
        Set(ByVal value As String)
            Session(Common.ssn_AttorneyID) = value
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

    Protected Property LawFirmID() As String
        Get
            Return Session(Common.ssn_LawFirmID).ToString()
        End Get
        Set(ByVal value As String)
            Session(Common.ssn_LawFirmID) = value
        End Set
    End Property
#End Region

#Region "Events"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Check to see if we are logged in or not
        Try
            If Logged_In <> "Yes" Then
                'Login
                Response.Redirect("login.aspx?rep=" & Trim(Request.QueryString("rep")) & "&cid=" & Trim(Request.QueryString("cid")) & "&lfid=" & Trim(Request.QueryString("lfid") & " &aid=" & Trim(Request.QueryString("aid")) & "&crhlf=" & Trim(Request.QueryString("crhlf"))))
            Else
                lblPageTitle.Text = Request.QueryString("PageTitle")
                lbl_Attorneys_Full_Name.Text = Attorney_Name
                lbl_Law_Firms_Full_Name.Text = Law_Firm_Name
            End If
        Catch ex As Exception
            'Login
            Response.Redirect("login.aspx?rep=" & Trim(Request.QueryString("rep")) & "&cid=" & Trim(Request.QueryString("cid")) & "&lfid=" & Trim(Request.QueryString("lfid") & " &aid=" & Trim(Request.QueryString("aid")) & "&crhlf=" & Trim(Request.QueryString("crhlf"))))
        End Try
    End Sub
#End Region
End Class
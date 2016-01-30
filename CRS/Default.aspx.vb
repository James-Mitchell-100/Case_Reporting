Imports System.Drawing
Imports CRS_BLL
Imports CRS_Common
Public Class _Default
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
            If Object.ReferenceEquals(Session(Common.ssn_Logged_In), Nothing) Then
                Session(Common.ssn_Logged_In) = ""
                Return Session(Common.ssn_Logged_In).ToString()
            Else
                Return Session(Common.ssn_Logged_In).ToString()
            End If

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

#Region "Event Handlers"
    ''' <summary>
    ''' Page load handler
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            If Logged_In <> "Yes" Then
                'Loggin
                Response.Redirect("login.aspx?rep=" & Trim(Request.QueryString("rep")) & "&cid=" & Trim(Request.QueryString("cid")) & "&lfid=" & Trim(Request.QueryString("lfid") & " &aid=" & Trim(Request.QueryString("aid")) & "&crhlf=" & Trim(Request.QueryString("crhlf"))))
            End If
        Catch ex As Exception
            Response.Redirect("login.aspx?rep=" & Trim(Request.QueryString("rep")) & "&cid=" & Trim(Request.QueryString("cid")) & "&lfid=" & Trim(Request.QueryString("lfid") & " &aid=" & Trim(Request.QueryString("aid")) & "&crhlf=" & Trim(Request.QueryString("crhlf"))))
        End Try

    End Sub

#End Region
End Class
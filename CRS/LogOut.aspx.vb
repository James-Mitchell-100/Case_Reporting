Imports CRS_BLL
Imports CRS_Common

Public Class LogOut
    Inherits System.Web.UI.Page
#Region "Properties"

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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Logged_In = "No"

        'remove session data
        Session(Common.ssn_AttorneyID) = ""
        Session(Common.ssn_Attorney) = ""
        Session(Common.ssn_LawFirmName) = ""
        
        Response.Redirect("Default.aspx")
    End Sub

End Class
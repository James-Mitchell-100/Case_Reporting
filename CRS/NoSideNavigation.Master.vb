Imports CRS_BLL
Imports CRS_Common
Public Class NoSideNavigation
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            lbl_Attorneys_Full_Name.Text = Attorney_Name
        Catch ex As Exception
            'will throw an exception if have not yet logged in
        End Try
        Try
            lbl_Law_Firms_Full_Name.Text = Law_Firm_Name
        Catch ex As Exception
            'will throw an exception if have not yet logged in
        End Try
    End Sub

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

End Class
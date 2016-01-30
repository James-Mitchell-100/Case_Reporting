Imports CRS_BLL
Imports CRS_Common

Public Class Site1
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lbl_Attorneys_Full_Name.Text = Attorney_Name
        lbl_Law_Firms_Full_Name.Text = Law_Firm_Name
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
End Class
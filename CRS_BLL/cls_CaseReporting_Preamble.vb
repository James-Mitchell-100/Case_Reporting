Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
'Imports CaseReporting_DLL
Imports CRS_DLL

Public Class CaseReporting_Preamble

#Region "Properties"

    Public Property Preamble_Agreement As String
    Public Property Preamble_Date As String
    Public Property Preamble_Referral_Law_Firm_Full_Name As String
    Public Property Preamble_Referral_Law_Firm_Acronym As String
    Public Property Preamble_Law_Firm_Full_Name As String
    Public Property Preamble_Law_Firm_Modifications_of_Agreeement As String

#End Region

#Region "Public Methods"
    'Public Sub GetCaseReportingPreamble(ByVal str_Law_Firm_ID As String)

    '    'Create the data access object and receiving data table
    '    Dim data_preamble As New Preamble_Data
    '    Dim ds_Preamble As New DataSet
    '    Dim dt_Preamble As New DataTable

    '    'Load the dataset
    '    ds_Preamble = data_preamble.Get_Preamble_Info(str_Law_Firm_ID)

    '    'Verify we got something back - only valid of 1 row is returned
    '    If ds_Preamble.Tables(0).Rows.Count = 1 Then

    '        ' Hydrate the attorney object
    '        Dim row As DataRow = ds_Preamble.Tables(0).Rows(0)

    '        If row("LF_RFA_Title_of_Agreement").ToString() <> "" Then Preamble_Agreement = row("LF_RFA_Title_of_Agreement").ToString()
    '        If row("LF_RFA_RFA_Signed_Date_Text_Format").ToString() <> "" Then Preamble_Date = row("LF_RFA_RFA_Signed_Date_Text_Format").ToString()
    '        If row("Ref_LF_Full_Name").ToString() <> "" Then Preamble_Referral_Law_Firm_Full_Name = row("Ref_LF_Full_Name")
    '        If row("Ref_LF_Acronym").ToString() <> "" Then Preamble_Referral_Law_Firm_Acronym = row("Ref_LF_Acronym")
    '        If row("LF_RFA_Law_Firm_Full_Name").ToString() <> "" Then Preamble_Law_Firm_Full_Name = row("LF_RFA_Law_Firm_Full_Name")
    '        If row("LF_RFA_Modifications_of_Agreeement").ToString() <> "" Then Preamble_Law_Firm_Modifications_of_Agreeement = row("LF_RFA_Modifications_of_Agreeement")

    '    End If
    'End Sub

#End Region
End Class


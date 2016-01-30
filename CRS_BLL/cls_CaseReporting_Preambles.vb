Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
'Imports CaseReporting_DLL
Imports CRS_DLL

Public Class CaseReporting_Preambles

#Region "Properties"

    Public Property Preambles As Collection

#End Region

#Region "Public Methods"
    Public Sub GetCaseReportingPreambles(ByVal str_Law_Firm_ID As String)

        'Create the data access object and receiving data table
        Dim data_preamble As New Preamble_Data
        Dim ds_Preamble As New DataSet
        Dim dt_Preamble As New DataTable

        'Re-Initialize the collection
        Preambles = New Collection

        'Load the dataset
        ds_Preamble = data_preamble.Get_Preamble_Info(str_Law_Firm_ID)

        'Verify we got something back - only valid of 1 row is returned
        If ds_Preamble.Tables(0).Rows.Count = 1 Then

            For Each row As DataRow In ds_Preamble.Tables(0).Rows
                Dim oPreamble As New CaseReporting_Preamble

                With oPreamble
                    If row("LF_RFA_Title_of_Agreement").ToString() <> "" Then .Preamble_Agreement = row("LF_RFA_Title_of_Agreement").ToString()
                    If row("LF_RFA_RFA_Signed_Date_Text_Format").ToString() <> "" Then .Preamble_Date = row("LF_RFA_RFA_Signed_Date_Text_Format").ToString()
                    If row("Ref_LF_Full_Name").ToString() <> "" Then .Preamble_Referral_Law_Firm_Full_Name = row("Ref_LF_Full_Name").ToString()
                    If row("Ref_LF_Acronym").ToString() <> "" Then .Preamble_Referral_Law_Firm_Acronym = row("Ref_LF_Acronym").ToString()
                    If row("LF_RFA_Law_Firm_Full_Name").ToString() <> "" Then .Preamble_Law_Firm_Full_Name = row("LF_RFA_Law_Firm_Full_Name").ToString()
                    If row("LF_RFA_Modifications_of_Agreeement").ToString() <> "" Then .Preamble_Law_Firm_Modifications_of_Agreeement = row("LF_RFA_Modifications_of_Agreeement").ToString()
                End With

                Preambles.Add(oPreamble)

            Next

        End If
    End Sub

#End Region
End Class


Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
'Imports CaseReporting_DLL
Imports CRS_DLL

Public Class CaseReporting_Attorney_Email_Address

#Region "Properties"

    Public Property Attorneys_Email_Address_ID As Long
    Public Property Attorneys_Email_Address_Attorney_ID As Long
    Public Property Attorneys_Email_Address_Email_or_Txt_Address As String
    Public Property Attorneys_Email_Address_Email_Primary_Alternative_Other As String
    Public Property Attorneys_Email_Address_Email_Address As String
    Public Property Attorneys_Email_Address_Date_Time_Created As Date

#End Region

#Region "Public Methods"
    Public Sub GetCaseReportingAttorneyEmailAddresses(ByVal str_Attorney_ID As String)

        'Create the data access object and receiving data table
        Dim data_attorney_email_address As New Attorney_Email_Address_Data
        Dim ds_Attorney_Email_Address As New DataSet
        Dim dt_Attorney_Email_Address As New DataTable

        'Load the dataset
        ds_Attorney_Email_Address = data_attorney_email_address.Get_Attorney_Email_Address_Info(str_Attorney_ID)

        'Verify we got something back - only valid of 1 row is returned
        If ds_Attorney_Email_Address.Tables(0).Rows.Count = 1 Then

            ' Hydrate the attorney object
            Dim row As DataRow = ds_Attorney_Email_Address.Tables(0).Rows(0)

            Attorneys_Email_Address_ID = Convert.ToInt32(row("Attorneys_EMA_ID"))

            If row("Attorneys_EMA_Attorney_ID").ToString() <> "" Then Attorneys_Email_Address_Attorney_ID = Convert.ToInt32(row("Attorneys_EMA_Attorney_ID"))
            If row("Attorneys_EMA_Email_or_Txt_Address").ToString() <> "" Then Attorneys_Email_Address_Email_or_Txt_Address = row("Attorneys_EMA_Email_or_Txt_Address").ToString()
            If row("Attorneys_EMA_Email_Primary_Alternative_Other").ToString() <> "" Then Attorneys_Email_Address_Email_Primary_Alternative_Other = row("Attorneys_EMA_Email_Primary_Alternative_Other").ToString()
            If row("Attorneys_EMA_Email_Address").ToString() <> "" Then Attorneys_Email_Address_Email_Address = row("Attorneys_EMA_Email_Address").ToString
            If row("Attorneys_EMA_Date_Time_Created").ToString() <> "" Then Attorneys_Email_Address_Date_Time_Created = CDate(row("Attorneys_EMA_Date_Time_Created"))

        End If
    End Sub

#End Region
End Class


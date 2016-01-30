Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
'Imports CaseReporting_DLL
Imports CRS_DLL

Public Class CRM_Contact
    Public Sub UpdateContactViaEmail(ByVal str_Contact_ID As String, ByVal str_Contact_Via_Email As String)

        'Create the data access object and receiving data table
        Dim data_contact As New Contact_Data
        Dim ds_Contact As New DataSet
        Dim dt_Contact As New DataTable

        'Load the dataset
        ds_Contact = data_contact.Update_Contact_Via_Email_info(str_Contact_ID, str_Contact_Via_Email)

    End Sub

End Class

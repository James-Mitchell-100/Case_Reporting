Imports System.Collections.Generic

Public Class Contact_Data

    Inherits Sql_Base

    ''' <summary>
    ''' Update contact information based upon the contact id
    ''' </summary>
    ''' <param name="str_Contact_ID"></param>
    ''' <param name="str_Contact_Via_Email"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Update_Contact_Via_Email_info(ByVal str_Contact_ID As String, ByVal str_Contact_Via_Email As String) As DataSet
        ' Define the target datatable
        Dim ds_Client As New DataSet
        Dim int_Return As Integer = 0

        Try
            'Attempt to load the datatable
            ds_Client = GetDataSet("usp_CRM_Contacts_Contact_Via_Email_Update", "@Recruiter_ID", str_Contact_ID, "@ContactViaEmail", str_Contact_Via_Email)

        Catch ex As Exception
            Throw ex
        End Try

        Return ds_Client
    End Function

End Class

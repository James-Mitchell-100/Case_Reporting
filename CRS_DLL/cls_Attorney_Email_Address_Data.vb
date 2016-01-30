Imports System.Collections.Generic

Public Class Attorney_Email_Address_Data

    Inherits Sql_Base

    ''' <summary>
    ''' Retrieves attorney email address case reporting information based upon the attorney id
    ''' </summary>
    ''' <param name="str_Attorney_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_Attorney_Email_Address_Info(ByVal str_Attorney_ID As String) As DataSet
        ' Define the target datatable
        Dim ds_Attorney_Email_Address As New DataSet
        Dim int_Return As Integer = 0

        Try
            'Attempt to load the datatable
            ds_Attorney_Email_Address = GetDataSet("CaseReporting_Attorney_Email_Address_Info", "@AttorneyID", str_Attorney_ID)

        Catch ex As Exception
            Throw ex
        End Try

        Return ds_Attorney_Email_Address
    End Function

End Class


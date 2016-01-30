Imports System.Collections.Generic

Public Class Attorney_Data

    Inherits Sql_Base

    ''' <summary>
    ''' Retrieves attorney case reporting information based upon the attorney id
    ''' </summary>
    ''' <param name="str_Attorney_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_Attorney_Info(ByVal str_Attorney_ID As String) As DataSet
        ' Define the target datatable
        Dim ds_Attorney As New DataSet
        Dim int_Return As Integer = 0

        Try
            'Attempt to load the datatable
            ds_Attorney = GetDataSet("CaseReporting_Attorney_Info", "@AttorneyID", str_Attorney_ID)

        Catch ex As Exception
            Throw ex
        End Try

        Return ds_Attorney
    End Function

End Class


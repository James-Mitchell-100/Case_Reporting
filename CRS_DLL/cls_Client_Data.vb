Imports System.Collections.Generic

Public Class Client_Data

    Inherits Sql_Base

    ''' <summary>
    ''' Retrieves client case reporting information based upon the client id
    ''' </summary>
    ''' <param name="str_Client_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_Client_Info(ByVal str_Client_ID As String) As DataSet
        ' Define the target datatable
        Dim ds_Client As New DataSet
        Dim int_Return As Integer = 0

        Try
            'Attempt to load the datatable
            ds_Client = GetDataSet("CaseReporting_Client_Info", "@ClientID", str_Client_ID)

        Catch ex As Exception
            Throw ex
        End Try

        Return ds_Client
    End Function

End Class


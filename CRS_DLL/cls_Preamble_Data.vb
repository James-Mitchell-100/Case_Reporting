Imports System.Collections.Generic

Public Class Preamble_Data

    Inherits Sql_Base

    ''' <summary>
    ''' Retrieves preamble reporting information based upon the law firm id
    ''' </summary>
    ''' <param name="str_Law_Firm_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_Preamble_Info(ByVal str_Law_Firm_ID As String) As DataSet
        ' Define the target datatable
        Dim ds_Preamble As New DataSet
        Dim int_Return As Integer = 0

        Try
            'Attempt to load the datatable
            ds_Preamble = GetDataSet("CaseReporting_Preamble_Info", "@LawFirmID", str_Law_Firm_ID)

        Catch ex As Exception
            Throw ex
        End Try

        Return ds_Preamble
    End Function

End Class


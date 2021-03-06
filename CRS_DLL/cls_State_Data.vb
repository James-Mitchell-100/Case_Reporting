﻿Imports System.Collections.Generic

Public Class State_Data

    Inherits Sql_Base

    ''' <summary>
    ''' Retrieves State case reporting information based upon the state id
    ''' </summary>
    ''' <param name="str_State_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_State_Info(ByVal str_State_ID As String) As DataSet
        ' Define the target datatable
        Dim ds_State As New DataSet
        Dim int_Return As Integer = 0

        Try
            'Attempt to load the datatable
            ds_State = GetDataSet("CaseReporting_State_Info", "@StateID", str_State_ID)

        Catch ex As Exception
            Throw ex
        End Try

        Return ds_State
    End Function

End Class

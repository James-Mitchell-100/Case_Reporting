Imports System.Collections.Generic
Public Class City_Data

    Inherits Sql_Base

    ''' <summary>
    ''' Retrieves State case reporting information based upon the state id
    ''' </summary>
    ''' <param name="str_State_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_City_Info(ByVal str_City_ID As String) As DataSet
        ' Define the target datatable
        Dim ds_City As New DataSet
        Dim int_Return As Integer = 0

        Try
            'Attempt to load the datatable
            ds_City = GetDataSet("CaseReporting_City_Info", "@CityID", str_City_ID)

        Catch ex As Exception
            Throw ex
        End Try

        Return ds_City
    End Function
End Class

Imports System.Collections.Generic

''' <summary>
''' Class used to manage employee SQL data
''' </summary>
''' <remarks></remarks>

Public Class Employee_Data
    Inherits Sql_Base

    ''' <summary>
    ''' Retrieves employee information based upon the employee's email and password
    ''' </summary>
    ''' <param name="str_Login_Name"></param>
    ''' <param name="str_Login_Password"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_Employee_Info(ByVal str_Login_Name As String, ByVal str_Login_Password As String) As DataSet
        ' Define the target datatable
        Dim dt_Employee As New DataSet

        Try
            'Attempt to load the datatable
            dt_Employee = GetDataSet("CaseReporting_Employee_Login", "@LoginName", LCase(str_Login_Name), "@LoginPassword", LCase(str_Login_Password))
        Catch ex As Exception
            Throw ex
        End Try

        Return dt_Employee
    End Function
End Class


''' <summary>
''' Class used to manage Referring Attorney SQL data
''' </summary>
''' <remarks></remarks>
Public Class Referring_Attorney_Data
    Inherits Sql_Base

    ''' <summary>
    ''' Retrieves referring attorney information based upon the attorney information's full name and password
    ''' </summary>
    ''' <param name="str_Login_Name"></param>
    ''' <param name="str_Login_Password"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_Referring_Attorney_Info(ByVal str_Login_Name As String, ByVal str_Login_Password As String) As DataSet
        ' Define the target datatable
        Dim dt_Referring_Attorney As New DataSet

        Try
            'Attempt to load the datatable
            dt_Referring_Attorney = GetDataSet("usp_CRS_Referring_Attorney_Login", "@LoginName", LCase(str_Login_Name), "@LoginPassword", LCase(str_Login_Password))
        Catch ex As Exception
            Throw ex
        End Try

        Return dt_Referring_Attorney
    End Function

End Class

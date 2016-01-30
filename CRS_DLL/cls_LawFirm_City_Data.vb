Imports System.Collections.Generic

Public Class LawFirm_City_Data

    Inherits Sql_Base

    ''' <summary>
    ''' Retrieves Law Firm City case reporting information based upon the lawfirm id
    ''' </summary>
    ''' <param name="str_LawFirm_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function Get_LawFirm_City_Info(ByVal str_LawFirm_ID As String) As DataSet
        ' Define the target datatable
        Dim ds_LawFirm_City As New DataSet
        Dim int_Return As Integer = 0

        Try
            'Attempt to load the datatable
            ds_LawFirm_City = GetDataSet("CaseReporting_LawFirm_City_Info", "@LawFirmID", str_LawFirm_ID)

        Catch ex As Exception
            Throw ex
        End Try

        Return ds_LawFirm_City
    End Function

    ''' <summary>
    ''' Retrieves Law Firm City case reporting information based upon the lawfirm id and City id
    ''' </summary>
    ''' <param name="str_LawFirm_ID"></param>
    ''' <param name="lng_City_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function Get_LawFirm_City_Info(ByVal str_LawFirm_ID As String, ByVal lng_City_ID As Long) As DataSet
        ' Define the target datatable
        Dim ds_LawFirm_City As New DataSet
        Dim int_Return As Integer = 0

        Try
            'Attempt to load the datatable
            ds_LawFirm_City = GetDataSet("CaseReporting_LawFirm_City_Info", "@LawFirmID", str_LawFirm_ID, "@CityID", lng_City_ID)

        Catch ex As Exception
            Throw ex
        End Try

        Return ds_LawFirm_City
    End Function

    ''' <summary>
    ''' Saves Law Firm City case reporting information based upon the lawfirm id and City id
    ''' </summary>
    ''' <param name="str_LawFirm_ID"></param>
    ''' <param name="lng_City_ID"></param>
    ''' <param name="lng_Preferrence"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Save_LawFirm_City_Info(ByVal str_LawFirm_ID As String, ByVal lng_City_ID As Long, ByVal lng_Preferrence As Long) As DataSet
        ' Define the target datatable
        Dim ds_LawFirm_City As New DataSet
        Dim int_Return As Integer = 0

        Try
            'Attempt to load the datatable
            ds_LawFirm_City = GetDataSet("CaseReporting_Law_Firm_City_Save", "@LawFirmID", str_LawFirm_ID, "@CityID", lng_City_ID, "@Preference", lng_Preferrence)

        Catch ex As Exception
            Throw ex
        End Try

        Return ds_LawFirm_City
    End Function

End Class


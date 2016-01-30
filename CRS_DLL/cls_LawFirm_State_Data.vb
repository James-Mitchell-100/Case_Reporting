Imports System.Collections.Generic

Public Class LawFirm_State_Data
    Inherits Sql_Base

    ''' <summary>
    ''' Retrieves Law Firm State case reporting information based upon the lawfirm id
    ''' </summary>
    ''' <param name="str_LawFirm_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function Get_LawFirm_State_Info(ByVal str_LawFirm_ID As String) As DataSet
        ' Define the target datatable
        Dim ds_LawFirm_State As New DataSet
        Dim int_Return As Integer = 0

        Try
            'Attempt to load the datatable
            ds_LawFirm_State = GetDataSet("CaseReporting_LawFirm_State_Info", "@LawFirmID", str_LawFirm_ID)

        Catch ex As Exception
            Throw ex
        End Try

        Return ds_LawFirm_State
    End Function

    ''' <summary>
    ''' Retrieves Law Firm State case reporting information based upon the lawfirm id and state id
    ''' </summary>
    ''' <param name="str_LawFirm_ID"></param>
    ''' <param name="lng_State_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function Get_LawFirm_State_Info(ByVal str_LawFirm_ID As String, ByVal lng_State_ID As Long) As DataSet
        ' Define the target datatable
        Dim ds_LawFirm_State As New DataSet
        Dim int_Return As Integer = 0

        Try
            'Attempt to load the datatable
            ds_LawFirm_State = GetDataSet("CaseReporting_LawFirm_State_Info", "@LawFirmID", str_LawFirm_ID, "@StateID", lng_State_ID)

        Catch ex As Exception
            Throw ex
        End Try

        Return ds_LawFirm_State
    End Function

    ''' <summary>
    ''' Saves Law Firm State case reporting information based upon the lawfirm id and state id
    ''' </summary>
    ''' <param name="str_LawFirm_ID"></param>
    ''' <param name="lng_State_ID"></param>
    ''' <param name="lng_Admission"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Save_LawFirm_State_Info(ByVal str_LawFirm_ID As String, ByVal lng_State_ID As Long, ByVal lng_Admission As Long) As DataSet
        ' Define the target datatable
        Dim ds_LawFirm_State As New DataSet
        Dim int_Return As Integer = 0

        Try
            'Attempt to load the datatable
            ds_LawFirm_State = GetDataSet("CaseReporting_Law_Firm_State_Save", "@LawFirmID", str_LawFirm_ID, "@StateID", lng_State_ID, "@Admission", lng_Admission)

        Catch ex As Exception
            Throw ex
        End Try

        Return ds_LawFirm_State
    End Function

End Class

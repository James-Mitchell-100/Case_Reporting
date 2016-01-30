Imports System.Collections.Generic

Public Class Type_Of_Case_And_Marketing_Fees_Data

    Inherits Sql_Base

    ''' <summary>
    ''' Retrieves type of case and marketing fees case reporting information based upon the attorney id
    ''' </summary>
    ''' <param name="str_Law_Firm_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_Type_Of_Case_And_Marketing_Fees_Info(ByVal str_Law_Firm_ID As String) As DataSet
        ' Define the target datatable
        Dim ds_Type_Of_Case_And_Marketing_Fees As New DataSet
        Dim int_Return As Integer = 0

        Try
            'Attempt to load the datatable
            ds_Type_Of_Case_And_Marketing_Fees = GetDataSet("CaseReporting_Type_Of_Case_And_Marketing_Fees_Info", "@LawFirmID", str_Law_Firm_ID)

        Catch ex As Exception
            Throw ex
        End Try

        Return ds_Type_Of_Case_And_Marketing_Fees
    End Function

    ''' <summary>
    ''' Saves Types of Cases case reporting information based upon the lawfirm id
    ''' </summary>
    ''' <param name="str_LawFirm_ID"></param>
    ''' <param name="lng_City_ID"></param>
    ''' <param name="lng_Preferrence"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Save_Types_Of_Cases_Info(ByVal str_LawFirm_ID As String, ByVal Do_You_Have_Intake_Script As String, ByVal Comments As String) As DataSet
        ' Define the target datatable
        Dim ds_Types_Of_Cases As New DataSet
        Dim int_Return As Integer = 0

        Try
            'Attempt to load the datatable
            ds_Types_Of_Cases = GetDataSet("CaseReporting_Type_Of_Case_And_Marketing_Fees_Save", "@LawFirmID", str_LawFirm_ID, "@Do_You_Have_Intake_Script", Comments, "@Comments")

        Catch ex As Exception
            Throw ex
        End Try

        Return ds_Types_Of_Cases
    End Function
End Class


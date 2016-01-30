Imports System.Collections.Generic

Public Class Clients_Case_Reporting_Data
    Inherits Sql_Base

    ''' <summary>
    ''' Login 
    ''' </summary>
    ''' <param name="str_Login_Name"></param>
    ''' <param name="str_Login_Password"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Login(ByVal str_Login_Name As String, ByVal str_Login_Password As String) As DataSet
        ' Define the target datatable
        Dim dt_Login As New DataSet
        Dim int_Return As Integer = 0

        Try
            'Attempt to load the datatable
            dt_Login = GetDataSet("CaseReporting_Login", "@LoginName", str_Login_Name, "@LoginPassword", str_Login_Password)
            'If dt_Login.Tables(0).Rows.Count = 1 Then
            '    Dim row As DataRow = dt_Login.Tables(0).Rows(0)
            '    int_Return = Convert.ToInt32(row("Attorney_ID"))
            'End If
        Catch ex As Exception
            Throw ex
        End Try

        Return dt_Login
    End Function

    ''' <summary>
    ''' Retrieves client case reporting information based upon the reporting, client id, law firm id, attorney id, client referral history law firm id
    ''' </summary>
    ''' <param name="str_Reporting"></param>
    ''' <param name="str_Client_ID"></param>
    ''' <param name="str_Law_Firm_ID"></param>
    ''' <param name="str_Attorney_ID"></param>
    ''' <param name="str_Client_Referral_History_Law_Firm_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_Client_Case_Reporting_Info(ByVal str_Reporting As String, ByVal str_Client_ID As String, ByVal str_Law_Firm_ID As String, ByVal str_Attorney_ID As String, ByVal str_Client_Referral_History_Law_Firm_ID As String) As DataSet
        ' Define the target datatable
        Dim ds_Client_Case_Reporting As New DataSet
        Dim int_Return As Integer = 0

        Try
            'Attempt to load the datatable
            ds_Client_Case_Reporting = GetDataSet("CaseReporting_Client_Case_Reporting", "@Reporting", str_Reporting, "@ClientID", str_Client_ID, "@LawFirmID", str_Law_Firm_ID, "@AttorneyID", str_Attorney_ID, "@ClientReferralHistoryLawFirmID", str_Client_Referral_History_Law_Firm_ID)

        Catch ex As Exception
            Throw ex
        End Try

        Return ds_Client_Case_Reporting
    End Function

    ''' <summary>
    ''' Saves client case reporting comments based upon the reporting ID
    ''' </summary>
    ''' <param name="str_Reporting_ID"></param>
    ''' <param name="str_Comments"></param>
    ''' <remarks></remarks>
    Public Sub Save_Client_Case_Reporting_Comments(ByVal str_Reporting_ID As String, ByVal str_Comments As String)
        Try
            'Attempt to load the datatable
            Execute_Non_Query("CaseReporting_Client_Case_Reporting_Comments_Save", "@ReportingID", str_Reporting_ID, "@Comments", str_Comments)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
End Class

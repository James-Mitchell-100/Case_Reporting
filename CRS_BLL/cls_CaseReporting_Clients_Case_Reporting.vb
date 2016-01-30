Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CRS_DLL

Public Class CaseReporting_Clients_Case_Reporting
#Region "Properties"
    Public Property Clients_Case_Reporting_ID As Integer
    Public Property Clients_Case_Reporting_ID_Formatted() As String
    Public Property Clients_Case_Reporting_Client_ID() As Integer
    Public Property Clients_Case_Reporting_Client_ID_Formatted() As String
    Public Property Clients_Case_Reporting_Client_Full_Name As String
    Public Property Clients_Case_Reporting_Client_Sort_Name() As String
    Public Property Clients_Case_Reporting_Law_Firm_ID() As Integer
    Public Property Clients_Case_Reporting_Law_Firm_ID_Formatted() As String
    Public Property Clients_Case_Reporting_Law_Firm_Full_Name As String
    Public Property Clients_Case_Reporting_Law_Firm_Sort_Name() As String
    Public Property Clients_Case_Reporting_Attorney_ID() As Integer
    Public Property Clients_Case_Reporting_Attorney_ID_Formatted() As String
    Public Property Clients_Case_Reporting_Attorney_Full_Name As String
    Public Property Clients_Case_Reporting_Attorney_Sort_Name() As String
    Public Property Clients_Case_Reporting_QY_Year() As Integer
    Public Property Clients_Case_Reporting_QY_Quarter() As Integer
    Public Property Clients_Case_Reporting_Status_of_the_Case() As String
    Public Property Clients_Case_Reporting_Law_Firm_Comments() As String
    Public Property Clients_Case_Reporting_Our_Comments() As String
    Public Property Clients_Case_Reporting_Date_Time_Record_Created() As String
    Public Property Clients_Referral_History_Law_Firms_Message_Attorneys_at_Law_Firm() As String
    Public Property Clients_Referral_History_Law_Firms_Main_Category_Proposed() As String
    Public Property Clients_Referral_History_Law_Firms_Type_of_Case_Proposed() As String
    Public Property AttorneyID() As String = ""
    Public Property LawFirmID() As String = ""
    Public Property Attorney_Full_Name() As String = ""
    Public Property Law_Firm_Full_Name() As String = ""
#End Region

#Region "Public Methods"
    Public Sub Login(ByVal str_Login_Name As String, ByVal str_Login_Password As String)

        'Create the data access object and receiving data table
        Dim data_client_case_reporting As New Clients_Case_Reporting_Data
        Dim ds_Login As New DataSet
        Dim dt_Login As New DataTable


        'Load the dataset
        ds_Login = data_client_case_reporting.Login(str_Login_Name, str_Login_Password)

        If ds_Login.Tables(0).Rows.Count = 1 Then
            Dim row As DataRow = ds_Login.Tables(0).Rows(0)
            AttorneyID = row("Attorney_ID").ToString()
            LawFirmID = row("Firm_ID").ToString()
            Attorney_Full_Name = row("Attorney_Full_Name").ToString
            Law_Firm_Full_Name = row("Firm_Full_Name").ToString
        End If

    End Sub

    Public Sub GetClientCaseReporting(ByVal str_Reporting As String, ByVal str_Client_ID As String, ByVal str_Law_Firm_ID As String, ByVal str_Attorney_ID As String, ByVal str_Client_Referral_History_Law_Firm_ID As String)

        'Create the data access object and receiving data table
        Dim data_client_case_reporting As New Clients_Case_Reporting_Data
        Dim ds_Client_Case_Reporting As New DataSet
        Dim dt_Client_Case_Reporting As New DataTable

        'Load the dataset
        ds_Client_Case_Reporting = data_client_case_reporting.Get_Client_Case_Reporting_Info(str_Reporting, str_Client_ID, str_Law_Firm_ID, str_Attorney_ID, str_Client_Referral_History_Law_Firm_ID)

        'Verify we got something back - only valid of 1 row is returned
        If ds_Client_Case_Reporting.Tables(0).Rows.Count = 1 Then

            ' Hydrate the client object
            Dim row As DataRow = ds_Client_Case_Reporting.Tables(0).Rows(0)
            Clients_Case_Reporting_ID = Convert.ToInt32(row("CCR_ID"))
            Clients_Case_Reporting_ID_Formatted = row("CCR_ID_Formatted").ToString()
            Clients_Case_Reporting_Client_ID = Convert.ToInt32(row("CCR_Client_ID"))
            Clients_Case_Reporting_Client_ID_Formatted = row("CCR_Client_ID_Formatted").ToString()
            Clients_Case_Reporting_Client_Full_Name = row("CCR_Client_Full_Name").ToString()
            Clients_Case_Reporting_Client_Sort_Name = row("CCR_Client_Sort_Name").ToString()
            Clients_Case_Reporting_Law_Firm_ID = Convert.ToInt32(row("CCR_Law_Firm_ID"))
            Clients_Case_Reporting_Law_Firm_ID_Formatted = row("CCR_Law_Firm_ID_Formatted").ToString()
            Clients_Case_Reporting_Law_Firm_Full_Name = row("CCR_Law_Firm_Full_Name").ToString()
            Clients_Case_Reporting_Law_Firm_Sort_Name = row("CCR_Law_Firm_Sort_Name").ToString()
            Clients_Case_Reporting_Attorney_ID = Convert.ToInt32(row("CCR_Attorney_ID"))
            Clients_Case_Reporting_Attorney_ID_Formatted = row("CCR_Attorney_ID_Formatted").ToString()
            Clients_Case_Reporting_Attorney_Full_Name = row("CCR_Attorney_Full_Name").ToString()
            Clients_Case_Reporting_Attorney_Sort_Name = row("CCR_Attorney_Sort_Name").ToString()
            Clients_Case_Reporting_QY_Year = Convert.ToInt32(row("CCR_QY_Year"))
            Clients_Case_Reporting_QY_Quarter = Convert.ToInt32(row("CCR_QY_Quarter"))
            Clients_Case_Reporting_Status_of_the_Case = row("CCR_CRS_Status_of_the_Case").ToString()
            Clients_Case_Reporting_Law_Firm_Comments = row("CCR_CRS_Law_Firm_Comments").ToString()
            Clients_Case_Reporting_Our_Comments = row("CCR_CRS_Our_Comments").ToString()
            Clients_Case_Reporting_Date_Time_Record_Created = row("CCR_Date_Time_Record_Created").ToString()

            Clients_Referral_History_Law_Firms_Message_Attorneys_at_Law_Firm = row("CRF_LF_Message_Attorneys_at_Law_Firm").ToString()
            Clients_Referral_History_Law_Firms_Main_Category_Proposed = row("CRH_LF_ToC_MC_Main_Category_Proposed").ToString()
            Clients_Referral_History_Law_Firms_Type_of_Case_Proposed = row("CRH_LF_ToC_Type_of_Case_Proposed").ToString()

        End If
    End Sub

    Public Sub SaveClientCaseReportingComments(ByVal str_Reporting_ID As String, ByVal str_Comments As String)

        'Create the data access object and receiving data table
        Dim data_client_case_reporting As New Clients_Case_Reporting_Data

        'Save the dataset
        data_client_case_reporting.Save_Client_Case_Reporting_Comments(str_Reporting_ID, str_Comments)

    End Sub

#End Region
End Class

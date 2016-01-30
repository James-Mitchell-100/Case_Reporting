﻿Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
'Imports CaseReporting_DLL
Imports CRS_DLL

Public Class CaseReporting_Client_Intake_Question_And_Response

#Region "Properties"

    Public Property Clients_IQA_ID As Long
    Public Property Clients_IQA_ID_Formatted As String
    Public Property Clients_IQA_Client_ID As Long
    Public Property Clients_IQA_Client_ID_Formatted As String
    Public Property Clients_IQA_Client_Full_Name As String
    Public Property Clients_IQA_Client_Sort_Name As String
    Public Property Clients_IQA_ToC_MC_ID As Long
    Public Property Clients_IQA_ToC_MC_ID_Formatted As String
    Public Property Clients_IQA_ToC_MC_Main_Category As String
    Public Property Clients_IQA_ToC_MC_Main_Category_Sort_Name As String
    Public Property Clients_IQA_ToC_ID As Long
    Public Property Clients_IQA_ToC_ID_Formatted As String
    Public Property Clients_IQA_ToC_Type_of_Case As String
    Public Property Clients_IQA_Type_of_Case_Sort_Name As String
    Public Property Clients_IQA_ToC_Comments As String
    Public Property Clients_IQA_IQR_Level_I_or_II_Question As String
    Public Property Clients_IQA_IQR_Sort_Order As String
    Public Property Clients_IQA_IQR_Question_Number As Integer
    Public Property Clients_IQA_IQR_Intake_Question As String
    Public Property Clients_IQA_IQR_Response_to_Intake_Question As String
    Public Property Clients_IQA_Misc_Date_Time_Created As Date

#End Region

#Region "Public Methods"
    'Public Sub GetCaseReportingClientIntakeQuestionAndAnswer(ByVal str_Client_ID As String)

    '    'Create the data access object and receiving data table
    '    Dim data_client_intake_question_and_answer As New Client_Intake_Question_And_Answer_Data
    '    Dim ds_Client_Intake_Question_And_Answer As New DataSet
    '    Dim dt_Client_Intake_Question_And_Answer As New DataTable

    '    'Load the dataset
    '    ds_Client_Intake_Question_And_Answer = data_client_intake_question_and_answer.Get_Client_Intake_Question_And_Answer_Info(str_Client_ID)

    '    'Verify we got something back - only valid of 1 row is returned
    '    If ds_Client_Intake_Question_And_Answer.Tables(0).Rows.Count = 1 Then

    '        ' Hydrate the attorney object
    '        Dim row As DataRow = ds_Client_Intake_Question_And_Answer.Tables(0).Rows(0)

    '        Clients_IQA_ID = Convert.ToInt32(row("Clients_IQA_ID"))

    '        If row("Clients_IQA_ID_Formatted").ToString() <> "" Then Clients_IQA_ID_Formatted = row("Clients_IQA_ID_Formatted").ToString()

    '        If row("Clients_IQA_Client_ID").ToString() <> "" Then Clients_IQA_Client_ID = Convert.ToInt32(row("Clients_IQA_Client_ID"))
    '        If row("Clients_IQA_Client_ID_Formatted").ToString() <> "" Then Clients_IQA_Client_ID_Formatted = row("Clients_IQA_Client_ID_Formatted").ToString()
    '        If row("Clients_IQA_Client_Full_Name").ToString() <> "" Then Clients_IQA_Client_Full_Name = row("Clients_IQA_Client_Full_Name").ToString()
    '        If row("Clients_IQA_Client_Sort_Name").ToString() <> "" Then Clients_IQA_Client_Sort_Name = row("Clients_IQA_Client_Sort_Name").ToString()

    '        If row("Clients_IQA_ToC_MC_ID").ToString() <> "" Then Clients_IQA_ToC_MC_ID = Convert.ToInt32(row("Clients_IQA_ToC_MC_ID"))
    '        If row("Clients_IQA_ToC_MC_ID_Formatted").ToString() <> "" Then Clients_IQA_ToC_MC_ID_Formatted = row("Clients_IQA_ToC_MC_ID_Formatted").ToString()
    '        If row("Clients_IQA_ToC_MC_Main_Category").ToString() <> "" Then Clients_IQA_ToC_MC_Main_Category = row("Clients_IQA_ToC_MC_Main_Category").ToString()
    '        If row("Clients_IQA_ToC_MC_Main_Category_Sort_Name").ToString() <> "" Then Clients_IQA_ToC_MC_Main_Category_Sort_Name = row("Clients_IQA_ToC_MC_Main_Category_Sort_Name").ToString()

    '        If row("Clients_IQA_ToC_ID").ToString() <> "" Then Clients_IQA_ToC_ID = Convert.ToInt32(row("Clients_IQA_ToC_ID"))
    '        If row("Clients_IQA_ToC_ID_Formatted").ToString() <> "" Then Clients_IQA_ToC_ID_Formatted = row("Clients_IQA_ToC_ID_Formatted").ToString()
    '        If row("Clients_IQA_ToC_Type_of_Case").ToString() <> "" Then Clients_IQA_ToC_Type_of_Case = row("Clients_IQA_ToC_Type_of_Case").ToString()
    '        If row("Clients_IQA_Type_of_Case_Sort_Name").ToString() <> "" Then Clients_IQA_Type_of_Case_Sort_Name = row("Clients_IQA_Type_of_Case_Sort_Name").ToString()
    '        If row("Clients_IQA_ToC_Comments").ToString() <> "" Then Clients_IQA_ToC_Comments = row("Clients_IQA_ToC_Comments").ToString()

    '        If row("Clients_IQA_IQR_Level_I_or_II_Question").ToString() <> "" Then Clients_IQA_IQR_Level_I_or_II_Question = row("Clients_IQA_IQR_Level_I_or_II_Question").ToString()
    '        If row("Clients_IQA_IQR_Sort_Order").ToString() <> "" Then Clients_IQA_IQR_Sort_Order = row("Clients_IQA_IQR_Sort_Order").ToString()

    '        If row("Clients_IQA_IQR_Question_Number").ToString() <> "" Then Clients_IQA_IQR_Question_Number = Convert.ToInt32(row("Clients_IQA_IQR_Question_Number"))

    '        If row("Clients_IQA_IQR_Intake_Question").ToString() <> "" Then Clients_IQA_IQR_Intake_Question = Convert.ToInt32(row("Clients_IQA_IQR_Intake_Question"))

    '        If row("Clients_IQA_IQR_Response_to_Intake_Question").ToString() <> "" Then Clients_IQA_IQR_Response_to_Intake_Question = row("Clients_IQA_IQR_Response_to_Intake_Question").ToString()

    '        If row("Clients_IQA_Misc_Date_Time_Created").ToString() <> "" Then Clients_IQA_Misc_Date_Time_Created = row("Clients_IQA_Misc_Date_Time_Created").ToString()

    '    End If
    'End Sub

#End Region
End Class


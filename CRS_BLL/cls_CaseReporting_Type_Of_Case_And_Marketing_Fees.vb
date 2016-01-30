Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
'Imports CaseReporting_DLL
Imports CRS_DLL
Public Class CaseReporting_Type_Of_Case_And_Marketing_Fees

#Region "Properties"

    'Public Property Main_Category As String
    ''Public Property ID As String
    'Public Property Type_Of_Case As String
    'Public Property Flat_Fee_or_Sliding_Scale As String
    'Public Property Level_Of_Damages As String
    'Public Property Marketing_Fee_Flat_Fee_Amount As String
    'Public Property Marketing_Sliding_Scale_Amount_Level_1 As String
    'Public Property Marketing_Sliding_Scale_Amount_Level_2 As String
    'Public Property Marketing_Sliding_Scale_Amount_Level_3 As String
    'Public Property Marketing_Sliding_Scale_Amount_Level_4 As String
    'Public Property Marketing_Sliding_Scale_Amount_Level_5 As String
    'Public Property Marketing_Sliding_Scale_Amount_Level_6 As String
    'Public Property Marketing_Sliding_Scale_Amount_Level_7 As String

    Public Property CaseReporting_Type_Of_Case_And_Marketing_Fees As Collection

#End Region

#Region "Public Methods"
    Public Sub GetCaseReportingType_Of_Case_And_Marketing_Fees(ByVal str_Law_Firm_ID As String)

        'Create the data access object and receiving data table
        Dim data_type_of_case_and_marketing_fees As New Type_Of_Case_And_Marketing_Fees_Data
        Dim ds_Type_Of_Case_And_Marketing_Fees As New DataSet
        Dim dt_Type_Of_Case_And_Marketing_Fees As New DataTable

        'Re-Initialize the collection
        CaseReporting_Type_Of_Case_And_Marketing_Fees = New Collection

        'Load the dataset
        ds_Type_Of_Case_And_Marketing_Fees = data_type_of_case_and_marketing_fees.Get_Type_Of_Case_And_Marketing_Fees_Info(str_Law_Firm_ID)

        'Verify we got something back - only valid of 1 row is returned
        If ds_Type_Of_Case_And_Marketing_Fees.Tables(0).Rows.Count > 1 Then

            '' Hydrate the attorney object
            'Dim row As DataRow = ds_Type_Of_Case_And_Marketing_Fees.Tables(0).Rows(0)

            For Each row As DataRow In ds_Type_Of_Case_And_Marketing_Fees.Tables(0).Rows
                Dim oType_Of_Case As New CaseReporting_Type_Of_Case_And_Marketing_Fee

                With oType_Of_Case
                    If row("ToC_Main_Category").ToString() <> "" Then .ToC_Main_Category = row("ToC_Main_Category").ToString()
                    If row("ToC_ID_Formatted").ToString() <> "" Then .ToC_ID_Formatted = row("ToC_ID_Formatted").ToString()
                    If row("ToC_Type_of_Case").ToString() <> "" Then .ToC_Type_of_Case = row("ToC_Type_of_Case").ToString()
                    If row("ToC_LF_IMF_Flat_Fee_or_Sliding_Scale").ToString() <> "" Then .ToC_LF_IMF_Flat_Fee_or_Sliding_Scale = row("ToC_LF_IMF_Flat_Fee_or_Sliding_Scale").ToString()
                    If row("ToC_LF_IMF_Flat_Fee_Amount").ToString() <> "" Then .ToC_LF_IMF_Flat_Fee_Amount = row("ToC_LF_IMF_Flat_Fee_Amount").ToString()
                    If row("ToC_LF_IMF_Sliding_Scale_Amount_Level_01").ToString() <> "" Then .ToC_LF_IMF_Sliding_Scale_Amount_Level_01 = row("ToC_LF_IMF_Sliding_Scale_Amount_Level_01").ToString()
                    If row("ToC_LF_IMF_Sliding_Scale_Amount_Level_02").ToString() <> "" Then .ToC_LF_IMF_Sliding_Scale_Amount_Level_02 = row("ToC_LF_IMF_Sliding_Scale_Amount_Level_02").ToString()
                    If row("ToC_LF_IMF_Sliding_Scale_Amount_Level_03").ToString() <> "" Then .ToC_LF_IMF_Sliding_Scale_Amount_Level_03 = row("ToC_LF_IMF_Sliding_Scale_Amount_Level_03").ToString()
                    If row("ToC_LF_IMF_Sliding_Scale_Amount_Level_04").ToString() <> "" Then .ToC_LF_IMF_Sliding_Scale_Amount_Level_04 = row("ToC_LF_IMF_Sliding_Scale_Amount_Level_04").ToString()
                    If row("ToC_LF_IMF_Sliding_Scale_Amount_Level_05").ToString() <> "" Then .ToC_LF_IMF_Sliding_Scale_Amount_Level_05 = row("ToC_LF_IMF_Sliding_Scale_Amount_Level_05").ToString()
                    If row("ToC_LF_IMF_Sliding_Scale_Amount_Level_06").ToString() <> "" Then .ToC_LF_IMF_Sliding_Scale_Amount_Level_06 = row("ToC_LF_IMF_Sliding_Scale_Amount_Level_06").ToString()
                    If row("ToC_LF_IMF_Sliding_Scale_Amount_Level_07").ToString() <> "" Then .ToC_LF_IMF_Sliding_Scale_Amount_Level_07 = row("ToC_LF_IMF_Sliding_Scale_Amount_Level_07").ToString()

                    If row("ToC_LF_RF_Referral_Fee_Percentage").ToString() <> "" Then .ToC_LF_RF_Referral_Fee_Percentage = row("ToC_LF_RF_Referral_Fee_Percentage").ToString()
                    If row("ToC_LF_IMF_Is_Fee_Acceptable").ToString() <> "" Then .ToC_LF_IMF_Is_Fee_Acceptable = row("ToC_LF_IMF_Is_Fee_Acceptable").ToString()
                    If row("ToC_LF_IMF_Sliding_Scale_Amount_Level_07").ToString() <> "" Then .ToC_LF_IMF_Sliding_Scale_Amount_Level_07 = row("ToC_LF_IMF_Sliding_Scale_Amount_Level_07").ToString()


                End With

                CaseReporting_Type_Of_Case_And_Marketing_Fees.Add(oType_Of_Case)
            Next
        End If
    End Sub

    Public Sub SaveCaseReportingTypesOfCases(ByVal str_LawFirm_ID As String)

        'Create the data access object and receiving data table
        Dim data_Types_Of_Cases As New Type_Of_Case_And_Marketing_Fees_Data

        'Save
        'data_Types_Of_Cases.Save_Types_Of_Cases_Info(str_LawFirm_ID)
    End Sub

#End Region
End Class


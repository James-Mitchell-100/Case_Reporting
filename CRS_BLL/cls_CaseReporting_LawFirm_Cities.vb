Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CRS_DLL

Public Class CaseReporting_LawFirm_Cities

#Region "Properties"

    Public Property LawFirm_Cities As Collection

#End Region

#Region "Public Methods"
    Public Sub GetCaseReportingLawFirmCities(ByVal str_LawFirm_ID As String, Optional ByVal lng_City_ID As Long = -1)

        'Create the data access object and receiving data table
        Dim data_lawfirm_Citys As New LawFirm_City_Data
        Dim ds_data_lawfirm_City As New DataSet
        Dim dt_data_lawfirm_City As New DataTable

        'Re-Initialize the collection
        LawFirm_Cities = New Collection

        'Load the dataset
        If lng_City_ID = -1 Then
            ds_data_lawfirm_City = data_lawfirm_Citys.Get_LawFirm_City_Info(str_LawFirm_ID)
        Else
            ds_data_lawfirm_City = data_lawfirm_Citys.Get_LawFirm_City_Info(str_LawFirm_ID, lng_City_ID)
        End If

        'Verify we got something back 
        If ds_data_lawfirm_City.Tables(0).Rows.Count > 0 Then

            For Each row As DataRow In ds_data_lawfirm_City.Tables(0).Rows
                Dim oLawFirm_City As New CaseReporting_LawFirm_City

                With oLawFirm_City
                    .LawFirm_City_ID = Convert.ToInt32(row("LFC_ID"))
                    If row("LFC_ID_Formatted").ToString() <> "" Then .LawFirm_City_ID_Formatted = row("LFC_ID_Formatted").ToString()

                    .LawFirm_City_Law_Firm_ID = Convert.ToInt32(row("LFC_Law_Firms_ID"))
                    If row("LFC_Law_Firms_ID_Formatted").ToString() <> "" Then .LawFirm_City_Law_Firm_ID_Formatted = row("LFC_Law_Firms_ID_Formatted").ToString()

                    If row("LFC_Law_Firms_Full_Name").ToString() <> "" Then .LawFirm_City_Law_Firm_Full_Name = row("LFC_Law_Firms_Full_Name").ToString()
                    If row("LFC_Law_Firms_Sort_Name").ToString() <> "" Then .LawFirm_City_Law_Firm_Sort_Name = row("LFC_Law_Firms_Sort_Name").ToString()

                    If row("LFC_City_ID").ToString() <> "" Then .LawFirm_City_City_ID = Convert.ToInt32(row("LFC_City_ID"))
                    If row("LFC_City_ID_Formatted").ToString() <> "" Then .LawFirm_City_City_ID_Formatted = row("LFC_City_ID_Formatted").ToString()

                    If row("LFC_City").ToString() <> "" Then .LawFirm_City_City = row("LFC_City").ToString()

                    If row("LFC_Their_Preference_for_This_City").ToString() <> "" Then .LawFirm_City_Their_Preference_for_This_City = Convert.ToInt32(row("LFC_Their_Preference_for_This_City"))
                    If row("LFC_Our_Preference_Level_LF_for_This_City").ToString() <> "" Then .LawFirm_City_Our_Preference_Level_LF_for_This_City = row("LFC_Our_Preference_Level_LF_for_This_City").ToString()
                End With

                LawFirm_Cities.Add(oLawFirm_City)
            Next

        End If
    End Sub

    Public Sub SaveCaseReportingLawFirmCity(ByVal str_LawFirm_ID As String, ByVal lng_City_ID As Long, ByVal lng_Preference As Long)

        'Create the data access object and receiving data table
        Dim data_lawfirm_Citys As New LawFirm_City_Data

        'Save
        data_lawfirm_Citys.Save_LawFirm_City_Info(str_LawFirm_ID, lng_City_ID, lng_Preference)
    End Sub

#End Region

End Class

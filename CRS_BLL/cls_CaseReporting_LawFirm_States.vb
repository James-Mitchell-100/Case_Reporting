Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CRS_DLL

Public Class CaseReporting_LawFirm_States
#Region "Properties"

    Public Property LawFirm_States As Collection

#End Region

#Region "Public Methods"
    Public Sub GetCaseReportingLawFirmStates(ByVal str_LawFirm_ID As String, Optional ByVal lng_State_ID As Long = -1)

        'Create the data access object and receiving data table
        Dim data_lawfirm_states As New LawFirm_State_Data
        Dim ds_data_lawfirm_state As New DataSet
        Dim dt_data_lawfirm_state As New DataTable

        'Re-Initialize the collection
        LawFirm_States = New Collection

        'Load the dataset
        If lng_State_ID = -1 Then
            ds_data_lawfirm_state = data_lawfirm_states.Get_LawFirm_State_Info(str_LawFirm_ID)
        Else
            ds_data_lawfirm_state = data_lawfirm_states.Get_LawFirm_State_Info(str_LawFirm_ID, lng_State_ID)
        End If

        'Verify we got something back 
        If ds_data_lawfirm_state.Tables(0).Rows.Count > 0 Then

            For Each row As DataRow In ds_data_lawfirm_state.Tables(0).Rows
                Dim oLawFirm_State As New CaseReporting_LawFirm_State

                With oLawFirm_State
                    .LawFirm_State_ID = Convert.ToInt32(row("LF_SoA_ID"))
                    If row("LF_SoA_ID_Formatted").ToString() <> "" Then .LawFirm_State_ID_Formatted = row("LF_SoA_ID_Formatted").ToString()

                    .LawFirm_State_Law_Firm_ID = Convert.ToInt32(row("LF_SoA_Law_Firm_ID"))
                    If row("LF_SoA_Law_Firm_ID_Formatted").ToString() <> "" Then .LawFirm_State_Law_Firm_ID_Formatted = row("LF_SoA_Law_Firm_ID_Formatted").ToString()

                    If row("LF_SoA_Law_Firm_Full_Name").ToString() <> "" Then .LawFirm_State_Law_Firm_Full_Name = row("LF_SoA_Law_Firm_Full_Name").ToString()
                    If row("LF_SoA_Law_Firm_Sort_Name").ToString() <> "" Then .LawFirm_State_Law_Firm_Sort_Name = row("LF_SoA_Law_Firm_Sort_Name").ToString()

                    If row("LF_SoA_State_ID").ToString() <> "" Then .LawFirm_State_State_ID = Convert.ToInt32(row("LF_SoA_State_ID"))
                    If row("LF_SoA_State_ID_Formatted").ToString() <> "" Then .LawFirm_State_State_ID_Formatted = row("LF_SoA_State_ID_Formatted").ToString()

                    If row("LF_SoA_State").ToString() <> "" Then .LawFirm_State_State = row("LF_SoA_State").ToString()

                    If row("LF_SoA_Admission_Number").ToString() <> "" Then .LawFirm_State_Admission_Number = Convert.ToInt32(row("LF_SoA_Admission_Number"))
                    If row("LF_SoA_Admission").ToString() <> "" Then .LawFirm_State_Admission = row("LF_SoA_Admission").ToString()
                    If row("LF_SoA_Comments").ToString() <> "" Then .LawFirm_State_Comments = row("LF_SoA_Comments").ToString()
                End With

                LawFirm_States.Add(oLawFirm_State)
            Next

        End If
    End Sub

    Public Sub SaveCaseReportingLawFirmState(ByVal str_LawFirm_ID As String, ByVal lng_State_ID As Long, ByVal lng_Admission As Long)

        'Create the data access object and receiving data table
        Dim data_lawfirm_states As New LawFirm_State_Data

        'Save
        data_lawfirm_states.Save_LawFirm_State_Info(str_LawFirm_ID, lng_State_ID, lng_Admission)
    End Sub

#End Region

End Class

Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CRS_DLL

Public Class CaseReporting_States
#Region "Properties"

    Public Property States As Collection

#End Region

#Region "Public Methods"
    Public Sub GetCaseReportingStates(ByVal str_State_ID As String)

        'Create the data access object and receiving data table
        Dim data_states As New State_Data
        Dim ds_data_state As New DataSet
        Dim dt_data_state As New DataTable

        'Re-Initialize the collection
        States = New Collection

        'Load the dataset
        ds_data_state = data_states.Get_State_Info(str_State_ID)

        'Verify we got something back 
        If ds_data_state.Tables(0).Rows.Count > 0 Then

            For Each row As DataRow In ds_data_state.Tables(0).Rows
                Dim oState As New CaseReporting_State

                With oState
                    If row("States_State").ToString() <> "" Then
                        .States_ID = Convert.ToInt32(row("States_ID"))
                        If row("States_ID_Formatted").ToString() <> "" Then .States_ID_Formatted = row("States_ID_Formatted").ToString()
                        If row("States_Country").ToString() <> "" Then .States_Country = row("States_Country").ToString()
                        If row("States_Sort_Name").ToString() <> "" Then .States_Sort_Name = row("States_Sort_Name").ToString()
                        If row("States_State").ToString() <> "" Then .States_State = row("States_State").ToString()
                        If row("States_Comments").ToString() <> "" Then .States_Comments = row("States_Comments").ToString()
                    End If
                End With

                States.Add(oState)
            Next

        End If
    End Sub

#End Region

End Class

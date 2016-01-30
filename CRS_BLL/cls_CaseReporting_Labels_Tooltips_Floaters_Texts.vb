Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CRS_DLL

Public Class CaseReporting_Labels_Tooltips_Floaters_Texts

#Region "Properties"

    Public Property Labels_Tooltips_Floaters_Texts As Collection

#End Region

#Region "Public Methods"
    Public Sub GetCaseReportingLabelsTooltipsFloatersTexts(Optional ByVal str_Web_Page As String = "")

        'Create the data access object and receiving data table
        Dim data_Labels_Tooltips_Floaters_Texts As New Labels_Tooltips_Floaters_Text_Data
        Dim ds_data_Labels_Tooltips_Floaters_Text As New DataSet
        Dim dt_data_Labels_Tooltips_Floaters_Text As New DataTable

        'Re-Initialize the collection
        Labels_Tooltips_Floaters_Texts = New Collection

        'Load the dataset
        ds_data_Labels_Tooltips_Floaters_Text = data_Labels_Tooltips_Floaters_Texts.Get_Labels_Tooltips_Floaters_Text_Info(str_Web_Page)

        'Verify we got something back 
        If ds_data_Labels_Tooltips_Floaters_Text.Tables(0).Rows.Count > 0 Then

            For Each row As DataRow In ds_data_Labels_Tooltips_Floaters_Text.Tables(0).Rows
                Dim oLabels_Tooltips_Floaters_Text As New CaseReporting_Labels_Tooltips_Floaters_Text

                With oLabels_Tooltips_Floaters_Text
                    .Labels_Tooltips_Floaters_Text_ID = Convert.ToInt32(row("LTFT_ID"))
                    If row("LTFT_ID_Formatted").ToString() <> "" Then .Labels_Tooltips_Floaters_Text_ID_Formatted = row("LTFT_ID_Formatted").ToString()
                    If row("LTFT_Status").ToString() <> "" Then .Labels_Tooltips_Floaters_Text_Status = row("LTFT_Status").ToString()
                    If row("LTFT_Web_Page").ToString() <> "" Then .Labels_Tooltips_Floaters_Text_Web_Page = row("LTFT_Web_Page").ToString()
                    If row("LTFT_Label_Tooltip_Floater").ToString() <> "" Then .Labels_Tooltips_Floaters_Text_Label_Tooltip_Floater = row("LTFT_Label_Tooltip_Floater").ToString()
                    .Labels_Tooltips_Floaters_Text_Floater_Number = Convert.ToInt32(row("LTFT_Floater_Number"))
                    If row("LTFT_Sort_Order").ToString() <> "" Then .Labels_Tooltips_Floaters_Text_Sort_Order = row("LTFT_Sort_Order").ToString()
                    If row("LTFT_Text").ToString() <> "" Then .Labels_Tooltips_Floaters_Text_Text = row("LTFT_Text").ToString()
                    If row("LTFT_Comments_Overall").ToString() <> "" Then .Labels_Tooltips_Floaters_Text_Comments_Overall = row("LTFT_Comments_Overall").ToString()
                    If row("LTFT_Date_Time_Record_Created").ToString() <> "" Then .Labels_Tooltips_Floaters_Text_Date_Time_Created = row("LTFT_Date_Time_Record_Created").ToString()
                End With

                Labels_Tooltips_Floaters_Texts.Add(oLabels_Tooltips_Floaters_Text)
            Next

        End If
    End Sub

#End Region

End Class

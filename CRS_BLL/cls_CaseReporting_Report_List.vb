Imports System.Collections.Generic
'Imports CaseReporting_DLL
Imports CRS_DLL
Imports CaseReporting_Common

''' <summary>
''' Class to support retrieving report lists
''' </summary>
''' <remarks></remarks>
Public Class CaseReporting_Report_List

#Region "Members"
    Private dct_Standard_Reports As Dictionary(Of Integer, String)
    Private dct_Custom_Reports As Dictionary(Of Integer, String)
#End Region

#Region "Public Methods"
    ''' <summary>
    ''' Returns a dictionary containing a list of standard reports by ID
    ''' </summary>
    ''' <param name="int_Firm_ID">Firm ID to filter custom reports on</param>
    ''' <returns>Dictionary (ID, Name) of standard reports</returns>
    ''' <remarks></remarks>
    Public Function Get_Standard_Reports(ByVal int_Firm_ID As Integer) As Dictionary(Of Integer, String)
        If Object.ReferenceEquals(dct_Standard_Reports, Nothing) Then
            GetReportLists(int_Firm_ID)
        End If
        Return dct_Standard_Reports
    End Function

    ''' <summary>
    ''' Returns a dictionary containing a list of custom reports by ID
    ''' </summary>
    ''' <param name="int_Firm_ID">Firm ID to filter custom reports on</param>
    ''' <returns>Dictionary (ID, Name) of standard reports</returns>
    ''' <remarks></remarks>
    Public Function Get_Custom_Reports(ByVal int_Firm_ID As Integer) As Dictionary(Of Integer, String)
        If Object.ReferenceEquals(dct_Custom_Reports, Nothing) Then
            GetReportLists(int_Firm_ID)
        End If
        Return dct_Custom_Reports
    End Function
#End Region

#Region "Private Methods"
    ''' <summary>
    ''' Retrieves the lists of reports to be stored in local dictionaries
    ''' </summary>
    ''' <param name="int_Firm_ID">Firm ID to filter custom reports on</param>
    ''' <remarks></remarks>
    Private Sub GetReportLists(ByVal int_Firm_ID As Integer)
        'Dim report_data As New Report_Data
        'Dim ds_Reports As DataSet
        'ds_Reports = report_data.Report_List(int_Firm_ID)
        'dct_Standard_Reports = BuildReportList(ds_Reports.Tables(0))
        'dct_Custom_Reports = BuildReportList(ds_Reports.Tables(1))
    End Sub

    ''' <summary>
    ''' Builds a dictionary based upon the data table provided
    ''' </summary>
    ''' <param name="dt_Table">Datatable containing the list of reports</param>
    ''' <returns>Dictionary (ID, Name) of reports based upon the contents of the datatable</returns>
    ''' <remarks></remarks>
    Private Function BuildReportList(ByRef dt_Table As DataTable) As Dictionary(Of Integer, String)
        Dim dct_Reports = New Dictionary(Of Integer, String)
        For Each row As DataRow In dt_Table.Rows
            Dim int_Report_ID As Integer = CInt(row("RPM_ID"))
            If Not dct_Reports.ContainsKey(int_Report_ID) Then
                dct_Reports.Add(int_Report_ID, row("RPM_Report_Profile_Name").ToString())
            End If
        Next
        Return dct_Reports
    End Function
#End Region

End Class

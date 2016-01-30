Imports CaseReporting_Common

Public Class Report_Data
    Inherits Sql_Base

#Region "Public Methods"

    ''' <summary>
    ''' Returns a dataset containing 2 tables reports, the first standard and the second custom
    ''' </summary>
    ''' <param name="int_Company_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Report_List(ByVal int_Company_ID As Integer) As DataSet
        Dim ds_Results As New DataSet
        ds_Results = GetDataSet("CaseReporting_Report_List", "@company_ID", int_Company_ID)
        Return ds_Results
    End Function

    ''' <summary>
    ''' Returns the report layout info
    ''' </summary>
    ''' <param name="int_Report_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Report_Layout_Load(ByVal int_Report_ID As Integer, ByVal int_Company_ID As Integer) As DataSet
        Dim ds_Results As New DataSet
        ds_Results = GetDataSet("CaseReporting_Report_Layout", "@report_ID", int_Report_ID, "@company_ID", int_Company_ID)
        Return ds_Results
    End Function

    ''' <summary>
    ''' Returns the individual report data
    ''' </summary>
    ''' <param name="str_Query"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Report_Load(ByVal str_Query As String) As DataTable
        Dim dt_Results As New DataTable
        dt_Results = GetDataTable(str_Query)
        Return dt_Results
    End Function

#End Region

End Class

Imports System.Text
'Imports CaseReporting_DLL
Imports CRS_DLL
Imports CaseReporting_Common

''' <summary>
''' Class to define the report layout object
''' </summary>
''' <remarks></remarks>
Public Class CaseReporting_Report_Layout

#Region "Members"
    Private int_Report_ID As Integer = 0
    Private str_Report_ID_Formatted As String = String.Empty
    Private str_Report_Profile_Name As String = String.Empty
    Private str_Report_Profile_Sort_Name As String = String.Empty
    Private int_CSS_Number_Clients_Displayed_per_Web_Page As Integer = 0
    Private str_CSS_Font_Family As String = String.Empty
    Private str_Type_of_Report As String = String.Empty
    Private int_Report_Profile_Master_ID As Integer
    Private str_Report_Profile_Master_ID_Formatted As String = String.Empty
    Private str_Report_Profile_Master_Name As String = String.Empty
    Private str_Report_Profile_Master_Name_Sort As String = String.Empty
    Private dct_Selection_Criteria_Specification As Dictionary(Of String, String)
    Private str_Sort_Order_Specification As String = String.Empty
    Private data_Columns As List(Of CaseReporting_Report_Column)
    Private data_Lines As List(Of CaseReporting_Report_Line)
    'Private data_Report As Report_Data
    Private dct_Report_Column_Headers As Dictionary(Of Integer, String)
    Private str_CSS_Separation_Columns_Column_Width As String = String.Empty
#End Region

#Region "Properties"
    Public ReadOnly Property Report_ID() As Integer
        Get
            Return int_Report_ID
        End Get
    End Property
    Public ReadOnly Property Report_ID_Formatted() As String
        Get
            Return str_Report_ID_Formatted
        End Get
    End Property
    Public ReadOnly Property Report_Profile_Name() As String
        Get
            Return str_Report_Profile_Name
        End Get
    End Property
    Public ReadOnly Property Report_Profile_Sort_Name() As String
        Get
            Return str_Report_Profile_Sort_Name
        End Get
    End Property
    Public ReadOnly Property CSS_Number_Clients_Displayed_per_Web_Page() As Integer
        Get
            Return int_CSS_Number_Clients_Displayed_per_Web_Page
        End Get
    End Property
    Public ReadOnly Property CSS_Font_Family() As String
        Get
            Return str_CSS_Font_Family
        End Get
    End Property
    Public ReadOnly Property Type_of_Report() As String
        Get
            Return str_Type_of_Report
        End Get
    End Property
    Public ReadOnly Property Report_Profile_Master_ID() As Integer
        Get
            Return int_Report_Profile_Master_ID
        End Get
    End Property
    Public ReadOnly Property Report_Profile_Master_ID_Formatted() As String
        Get
            Return str_Report_Profile_Master_ID_Formatted
        End Get
    End Property
    Public ReadOnly Property Report_Profile_Master_Name() As String
        Get
            Return str_Report_Profile_Master_Name
        End Get
    End Property
    Public ReadOnly Property Report_Profile_Master_Name_Sort() As String
        Get
            Return str_Report_Profile_Master_Name_Sort
        End Get
    End Property
    Public ReadOnly Property Selection_Criteria_Specification() As Dictionary(Of String, String)
        Get
            Return dct_Selection_Criteria_Specification
        End Get
    End Property
    Public ReadOnly Property Sort_Order_Specification() As String
        Get
            Return str_Sort_Order_Specification
        End Get
    End Property
    Public ReadOnly Property Report_Layout_Columns() As List(Of CaseReporting_Report_Column)
        Get
            Return data_Columns
        End Get
    End Property
    Public ReadOnly Property Report_Layout_Lines() As List(Of CaseReporting_Report_Line)
        Get
            Return data_Lines
        End Get
    End Property
    Public ReadOnly Property Report_Column_Headers() As Dictionary(Of Integer, String)
        Get
            Return dct_Report_Column_Headers
        End Get
    End Property
    Public ReadOnly Property CSS_Separation_Columns_Column_Width() As String
        Get
            Return str_CSS_Separation_Columns_Column_Width
        End Get
    End Property
    'Private ReadOnly Property Report() As Report_Data
    '    Get
    '        If Object.ReferenceEquals(data_Report, Nothing) Then
    '            data_Report = New Report_Data
    '        End If
    '        Return data_Report
    '    End Get
    'End Property
    ''' <summary>
    ''' Defines the type of row
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum RowType
        First
        Content
        Last
    End Enum
#End Region

#Region "Public Methods"
    ''' <summary>
    ''' Loads the report data from the database
    ''' </summary>
    ''' <param name="int_Report_ID"></param>
    ''' <remarks></remarks>
    'Public Sub Load(ByVal int_Report_ID As Integer, ByVal int_Firm_ID As Integer)
    '    Dim ds_Report As DataSet = Report.Report_Layout_Load(int_Report_ID, int_Firm_ID)

    '    'Build the CSS info
    '    Dim dt_Report_Table As DataTable = ds_Report.Tables(0)
    '    Dim dr_Row As DataRow = dt_Report_Table.Rows(0)
    '    str_Report_ID_Formatted = dr_Row("Report_ID_Formatted").ToString()
    '    str_Report_Profile_Name = dr_Row("Report_Profile_Name")
    '    str_Report_Profile_Sort_Name = dr_Row("Report_Profile_Sort_Name")
    '    int_CSS_Number_Clients_Displayed_per_Web_Page = dr_Row("CSS_Number_Clients_Displayed_per_Web_Page")
    '    str_CSS_Font_Family = dr_Row("CSS_Font_Family")
    '    str_Type_of_Report = dr_Row("Type_of_Report")
    '    str_CSS_Separation_Columns_Column_Width = dr_Row("CSS_Separation_Columns_Column_Width")

    '    'Build the filter criteria
    '    dt_Report_Table = ds_Report.Tables(1)
    '    dct_Selection_Criteria_Specification = New Dictionary(Of String, String)
    '    For Each row As DataRow In dt_Report_Table.Rows
    '        Dim parts As String()
    '        'Dim strCriteria As String
    '        parts = row("Selection_Criteria_Specification").ToString.Split("-")

    '        'If "All" then we don't need to add this filter
    '        If Trim(parts(parts.Length - 1)) <> "All" Then
    '            'Breakout the type (i.e. Domains, Dates, etc.) and the list
    '            'dct_Selection_Criteria_Specification.Add(parts(0).ToLower(), parts(2).ToLower())
    '            'Dim objOps As New mod_ARS_CriteriaBuilder
    '            'strCriteria = objOps.GetCriteria(parts(2).ToLower.Trim)
    '            'If Not String.IsNullOrEmpty(strCriteria) Then
    '            'parts(2) = strCriteria
    '            'End If
    '            dct_Selection_Criteria_Specification.Add(parts(0).ToLower.Trim, parts(2).ToLower.Trim)
    '        End If
    '    Next

    '    'Build the sort order
    '    dt_Report_Table = ds_Report.Tables(2)
    '    dr_Row = dt_Report_Table.Rows(0)
    '    str_Sort_Order_Specification = dr_Row("Sort_Order_Specification")

    '    'Build the column list for this report
    '    dt_Report_Table = ds_Report.Tables(3)
    '    data_Columns = New List(Of CaseReporting_Report_Column)
    '    For Each row As DataRow In dt_Report_Table.Rows
    '        data_Columns.Add(New CaseReporting_Report_Column(row))
    '    Next

    '    'Build the line list for this report
    '    dt_Report_Table = ds_Report.Tables(4)
    '    data_Lines = New List(Of CaseReporting_Report_Line)
    '    For Each row As DataRow In dt_Report_Table.Rows
    '        data_Lines.Add(New CaseReporting_Report_Line(row))
    '    Next

    '    'Collect each of the column headers for this report
    '    Dim int_Max_Lines As Integer = 0
    '    Dim int_Current_Column As Integer = 0
    '    Dim int_Current_Line As Integer = 0

    '    Dim dct_Report_Column_Header_Builder = New Dictionary(Of Integer, Dictionary(Of Integer, String))
    '    For Each column In data_Columns

    '        'Determine the source of the column header
    '        Dim str_Header = column.Columns_Column_Heading
    '        If str_Header = "Use Default" Then
    '            If column.Column_Heading = String.Empty Then
    '                str_Header = column.Column_Column_Name.Replace("_", " ")
    '            Else
    '                str_Header = column.Column_Heading
    '            End If
    '        End If

    '        If str_Header = "N/A" Then
    '            str_Header = String.Empty
    '        End If

    '        If str_Header <> String.Empty Then
    '            'Get the adjusted column and line numbers
    '            int_Current_Column = column.Column_Position_Number
    '            int_Current_Line = column.Column_Line_Number - 1

    '            'Set the max line count
    '            int_Max_Lines = Math.Max(int_Max_Lines, column.Column_Line_Number)

    '            'Do we have this column number yet?
    '            If Not dct_Report_Column_Header_Builder.ContainsKey(int_Current_Column) Then
    '                'No - Create a new entry for this column
    '                dct_Report_Column_Header_Builder.Add(int_Current_Column, New Dictionary(Of Integer, String))
    '            End If

    '            'Do we have this line number yet?
    '            If Not dct_Report_Column_Header_Builder(int_Current_Column).ContainsKey(int_Current_Line) Then
    '                'No - create a new entry
    '                dct_Report_Column_Header_Builder(int_Current_Column).Add(int_Current_Line, str_Header)
    '            End If
    '        End If
    '    Next

    '    'Consolidate each of the headers for each column into a single header
    '    dct_Report_Column_Headers = New Dictionary(Of Integer, String)
    '    For Each int_Column As Integer In dct_Report_Column_Header_Builder.Keys

    '        'Get the lines in this columns headers
    '        Dim dct_Header_Lines = dct_Report_Column_Header_Builder(int_Column)

    '        'Start a string builder
    '        Dim sb As New StringBuilder()

    '        'Add the lines in the header to the string builder
    '        For int_Line As Integer = 0 To int_Max_Lines - 1

    '            'Does this line have defined headers?
    '            If dct_Header_Lines.ContainsKey(int_Line) Then
    '                sb.Append(dct_Header_Lines(int_Line))
    '                sb.Append("<br />")
    '            End If
    '        Next

    '        'Add the column header to the list
    '        dct_Report_Column_Headers.Add(int_Column, sb.ToString.Substring(0, sb.Length - 6))
    '    Next
    'End Sub
#End Region

End Class



Imports System.Text
'Imports CaseReporting_DLL
Imports CRS_DLL

''' <summary>
''' Class used to build a report from the data contained in the CaseReporting_Report object
''' </summary>
''' <remarks></remarks>
Public Class CaseReporting_Report_Builder

#Region "Members"
    Private _report_Layout As CaseReporting_Report_Layout
#End Region

#Region "Properties"
    Public ReadOnly Property Report_Layout() As CaseReporting_Report_Layout
        Get
            Return _report_Layout
        End Get
    End Property
#End Region

#Region "Construction"
    Public Sub New(ByVal int_Report_ID As Integer, ByVal int_Firm_ID As Integer)
        '_report_Layout = New CaseReporting_Report_Layout
        '_report_Layout.Load(int_Report_ID, int_Firm_ID)
    End Sub
#End Region

#Region "Public Methods"

    'Public Function Get_Report(ByRef attorney As CaseReporting_Attorney) As DataTable
    '    Return Get_Report(attorney, 0, 0)
    'End Function

    ''' <summary>
    ''' Retrieves the report data
    ''' </summary>
    ''' <param name="attorney">Current CaseReporting_Attorney</param>
    ''' <param name="int_Rows_Per_Page">Number of rows to return</param>
    ''' <param name="int_Page">Current page number</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Public Function Get_Report(ByRef attorney As CaseReporting_Attorney, ByVal int_Rows_Per_Page As Integer, ByVal int_Page As Integer) As DataTable
    '    ' See if we're using paging
    '    Dim bln_Use_Paging As Boolean = int_Rows_Per_Page > 0 And int_Page > 0

    '    ' Build the SELECT statement
    '    Dim str_Query As New StringBuilder
    '    If bln_Use_Paging Then
    '        str_Query.AppendLine("WITH Clients AS (SELECT")
    '    Else
    '        str_Query.AppendLine("SELECT")
    '    End If

    '    'Setup to get sort order
    '    Dim str_Sort_Orders() As String = _report_Layout.Sort_Order_Specification.Split(" ")
    '    Dim str_Column_Header = str_Sort_Orders(0)
    '    Dim str_Sort_Order As String = String.Empty

    '    'Add column names to the statement
    '    Dim str_Concatenator As String = String.Empty
    '    For Each data_column As CaseReporting_Report_Column In _report_Layout.Report_Layout_Columns
    '        str_Query.AppendLine(String.Format("{0}{1}.{2}", str_Concatenator, data_column.Column_Table_Name, data_column.Column_Column_Name))
    '        str_Concatenator = ","
    '        If data_column.Columns_Column_Heading = str_Column_Header Or data_column.Column_Heading = str_Column_Header Then
    '            Dim str_Sort_Direction As String = String.Empty
    '            If str_Sort_Orders(str_Sort_Orders.Length - 1) = "Descending" Then
    '                str_Sort_Direction = "DESC"
    '            End If
    '            str_Sort_Order = String.Format("ORDER BY {0} {1}", data_column.Column_Name_Within_the_Table, str_Sort_Direction)
    '        End If
    '    Next

    '    If bln_Use_Paging Then str_Query.AppendLine(String.Format(", ROW_NUMBER() OVER ({0}) AS ROW_NUMBER", str_Sort_Order))

    '    'Add tables - build FROM/JOIN from what tables are in the columns
    '    str_Query.AppendLine("FROM Attorneys_and_Clients.dbo.Clients")

    '    'Build the WHERE clause
    '    str_Query.AppendLine("WHERE 1=1")
    '    'str_Query.AppendLine(ApplyDomainFilter(attorney.attorney_firm.Domains))

    '    'Call proposed re-factored general filter
    '    str_Query.AppendLine(ApplyFilter("Clients_Date_Time_Created", "dates"))
    '    str_Query.AppendLine(ApplyFilter("Clients_Spam_Reviewed_YN", "initial review"))
    '    str_Query.AppendLine(ApplyFilter("Clients_Source_of_Lead", "source of lead"))
    '    str_Query.AppendLine(ApplyFilter("Clients_Status", "case status"))
    '    str_Query.AppendLine(ApplyFilter("Clients_Priority_Number_Overall_Manager", "priority number"))
    '    str_Query.AppendLine(ApplyFilter("Clients_Case_Evaluation_Damages_Estimated_Value_Amount", "case value"))

    '    'Create a dictionary of pointers to map the incoming data in the table into the outgoing table for the grid
    '    Dim dct_Data_Pointers As New Dictionary(Of Integer, Integer())

    '    'Define our limits and pointer
    '    Dim int_Rows_Per_Record As Integer = 0
    '    Dim int_Columns_Per_Record As Integer = 0

    '    'Find out how many lines and columns per record we're building
    '    For i As Integer = 0 To Report_Layout.Report_Layout_Columns.Count - 1

    '        'Get the column definition
    '        Dim column_Definition As CaseReporting_Report_Column = Report_Layout.Report_Layout_Columns(i)

    '        'Get the maximum number of rows per record
    '        int_Rows_Per_Record = Math.Max(int_Rows_Per_Record, column_Definition.Column_Line_Number)

    '        'Get the maximum number of columns per record - check to see if this column requires a header
    '        int_Columns_Per_Record = Math.Max(int_Columns_Per_Record, column_Definition.Column_Position_Number)

    '        'Map the incoming column to the outgoing line and column number (insure 0 based index)
    '        Dim coordinates(2) As Integer
    '        coordinates(0) = column_Definition.Column_Line_Number - 1
    '        coordinates(1) = column_Definition.Column_Position_Number - 1
    '        dct_Data_Pointers.Add(i, coordinates)
    '    Next

    '    'Define the report data table to be returned to the grid
    '    Dim dt_Report As New DataTable

    '    dt_Report.Columns.Add(New DataColumn("LineType"))
    '    For i As Integer = 1 To int_Columns_Per_Record
    '        'Since we have multiple data elements per column all columns are forced to be data type of string
    '        dt_Report.Columns.Add(New DataColumn(String.Format("Col{0}", i)))
    '    Next

    '    'Add the rest of the paging logic to the query
    '    If bln_Use_Paging Then
    '        str_Query.AppendFormat(") SELECT * FROM Clients WHERE ROW_NUMBER BETWEEN {0} AND {1}", ((int_Page - 1) * int_Rows_Per_Page) + 1, int_Page * int_Rows_Per_Page)
    '    Else
    '        str_Query.AppendLine(str_Sort_Order)
    '    End If

    '    'Retrieve the report data
    '    Dim dt_Report_Raw As New DataTable()
    '    Dim data_Reports As New Report_Data
    '    dt_Report_Raw = data_Reports.Report_Load(str_Query.ToString())

    '    'Save the actual column count
    '    Dim int_Columns_Count = dt_Report_Raw.Columns.Count - 1

    '    'Make a pointer into the resulting data table
    '    Dim int_Line_Offset As Integer = 0

    '    'Now put the data into the table
    '    For Each data_Row As DataRow In dt_Report_Raw.Rows

    '        'Create the number of rows we need to hold this record and set the row type flag
    '        For i As Integer = 1 To int_Rows_Per_Record
    '            Dim row = dt_Report.NewRow()

    '            ' Set the row type
    '            'CPH 2010-02-09 - I need which row it is to check and branch on in the UI - so I just set it to the i variable
    '            'If i = 1 Then
    '            'row(0) = ARS_Report_Layout.RowType.First
    '            'ElseIf i = int_Rows_Per_Record Then
    '            'row(0) = ARS_Report_Layout.RowType.Last
    '            'Else
    '            'row(0) = ARS_Report_Layout.RowType.Content
    '            'End If
    '            row(0) = i
    '            dt_Report.Rows.Add(row)
    '        Next

    '        'Set the outgoing data table
    '        Dim bln_Delete_Row As Boolean = False
    '        'CPH 2010-02-10 - The 0 column was not being populated (Full_Name)
    '        'CPH 2010-02-11 - For i As Integer = 0 To int_Columns_Count - 1 (WHY DO I NEED -1 to make the report work only on Get_Report(..., 20, 3) 
    '        'For i As Integer = 1 To int_Columns_Count
    '        For i As Integer = 0 To int_Columns_Count - 1
    '            Dim line As Integer = dct_Data_Pointers(i)(0) + int_Line_Offset
    '            Dim column As Integer = dct_Data_Pointers(i)(1) + 1
    '            Dim obj_Row_Data As Object = data_Row(i)

    '            Dim sb_Cell As New StringBuilder
    '            If (Object.ReferenceEquals(obj_Row_Data, DBNull.Value) OrElse obj_Row_Data.ToString() = String.Empty) And _
    '                Report_Layout.Report_Layout_Columns(i).DO_Ignore_If_Blank Then
    '                bln_Delete_Row = True
    '                Exit For

    '            ElseIf Not Object.ReferenceEquals(obj_Row_Data, DBNull.Value) Then
    '                Select Case Report_Layout.Report_Layout_Columns(i).Formatting
    '                    Case "Date -- mmmm d, yyyy"
    '                        Dim dt_data As DateTime = obj_Row_Data
    '                        sb_Cell.Append(String.Format("{0} {1} {2}", dt_data.ToLongDateString.Split(" ")(1), dt_data.ToLongDateString.Split(" ")(2), dt_data.Year.ToString))
    '                    Case "Currency"
    '                        'CPH 2010-03-04 TODO - This cause a type conversion error - string to integer
    '                        'sb_Cell.Append(obj_Row_Data.ToString("C"))
    '                    Case Else
    '                        sb_Cell.Append(obj_Row_Data.ToString())
    '                End Select

    '                If Report_Layout.Report_Layout_Columns(i).Label_Prefix <> "N/A" Then
    '                    sb_Cell.Insert(0, Report_Layout.Report_Layout_Columns(i).Label_Prefix & " ")
    '                End If

    '                dt_Report.Rows(line)(column) = sb_Cell.ToString()
    '            End If
    '        Next

    '        If bln_Delete_Row Then
    '            dt_Report.Rows(dt_Report.Rows.Count - 1).Delete()
    '            'CPH 2010-02-09 - I need which row it is to check and branch on in the UI - I maybe wrong by commenting this line out but I am looking for 1-4
    '            'dt_Report.Rows(dt_Report.Rows.Count - 1)(0) = ARS_Report_Layout.RowType.Last
    '        End If

    '        int_Line_Offset = dt_Report.Rows.Count
    '    Next

    '    'Return the resulting data table
    '    Return dt_Report
    'End Function

#End Region

#Region "Private Methods"

    '
    'Proposed re-factored general filter method
    '
    Private Function ApplyFilter(ByVal strDBField As String, ByVal strKey As String) As String
        Const OPEN_IN As String = " IN ("
        Const CLOSE_IN As String = ")"

        Dim sb_filter As New StringBuilder
        sb_filter.Append(" AND " & strDBField)  ' & " IN (")
        'Save the initial length to see if we actually did anything
        Dim int_Initial_Length = sb_filter.Length
        Dim strSelectionCriteria As String = String.Empty
        Dim bNumeric As Boolean = False

        '
        'Handle varying DataTypes
        '
        Dim intDataType As Integer
        Dim objOps As New CaseReporting_CriteriaBuilder

        If Report_Layout.Selection_Criteria_Specification.ContainsKey(strKey) Then

            strSelectionCriteria = Report_Layout.Selection_Criteria_Specification(strKey)
            intDataType = objOps.GetCriteria(strSelectionCriteria)
            Select Case intDataType
                Case 0
                    'Setup the first part of the IN clause string before getting in the FOR EACH
                    sb_filter.Append(OPEN_IN)
                    int_Initial_Length = sb_filter.Length
                Case 1
                    'nothing needed it's a number
            End Select

            For Each FilterItem As String In strSelectionCriteria.Split(CChar(","))
                'If we already have an entry then enter the comma delimiter
                If sb_filter.Length > int_Initial_Length Then
                    sb_filter.Append(",")
                End If
                'Else
                Select Case intDataType
                    Case 0
                        sb_filter.Append(String.Format("'{0}'", FilterItem))
                    Case 1
                        'Nothing it's a number with an operator
                        Dim strNumeric() As String
                        strNumeric = objOps.GetNonStringValue(FilterItem)

                        sb_filter.Append(" " & strNumeric(0) & " " & strNumeric(1))
                    Case 3
                        Dim strDate As String
                        strDate = objOps.GetDateBetweenRangeValue(FilterItem)

                        sb_filter.Append(strDate)

                End Select
                'End If

            Next
        End If

        If sb_filter.Length = int_Initial_Length Then
            Return String.Empty
        Else
            Select Case intDataType
                Case 0
                    sb_filter.Append(CLOSE_IN)
                Case 1

            End Select

        End If

        Return sb_filter.ToString()
    End Function

#End Region

End Class

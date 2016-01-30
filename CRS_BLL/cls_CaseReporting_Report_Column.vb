''' <summary>
''' Class to define a report column definition object
''' </summary>
''' <remarks></remarks>
Public Class CaseReporting_Report_Column

#Region "Members"
    Private int_Column_ID As Integer
    Private str_Column_ID_Formatted As String = String.Empty
    Private str_Column_Column_Name As String = String.Empty
    Private str_Column_Hyperlinked_to_Level_II As String = String.Empty
    Private bln_DO_Display_Column_Header As Boolean
    Private bln_DO_Span_Multiple_Columns As Boolean
    Private bln_DO_Ignore_If_Blank As Boolean
    Private int_Column_Line_Number As Integer
    Private int_Column_Position_Number As Integer
    Private str_Columns_Column_Heading As String = String.Empty
    Private int_Column_Column_Heading As String = String.Empty
    Private str_Columns_Column_Width As String = String.Empty
    Private str_Column_Font_Style As String = String.Empty
    Private str_Column_Font_Weight As String = String.Empty
    Private str_Column_Font_Size As String = String.Empty
    Private str_Column_Font_Color As String = String.Empty
    Private str_Column_Text_Decoration As String = String.Empty
    Private str_TCM_ID_Formatted As String = String.Empty
    Private str_Sort_Number As String = String.Empty
    Private str_Column_Name As String = String.Empty
    Private str_Data_Type As String = String.Empty
    Private str_Column_Description As String = String.Empty
    Private str_Database_Name As String = String.Empty
    Private str_Column_Table_Name As String = String.Empty
    Private str_Column_Name_Within_the_Table As String = String.Empty
    Private str_Column_Heading As String = String.Empty
    Private str_Label_Prefix As String = String.Empty
    Private str_Column_Width As String = String.Empty
    Private int_Rows As Integer
    Private str_Text_Alignment As String = String.Empty
    Private str_Formatting As String = String.Empty
    Private str_TCM_Suppress_if_Zero As String = String.Empty
#End Region

#Region "Properties"
    Public ReadOnly Property Column_ID() As Integer
        Get
            Return int_Column_ID
        End Get
    End Property
    Public ReadOnly Property Column_ID_Formatted() As String
        Get
            Return str_Column_ID_Formatted
        End Get
    End Property
    Public ReadOnly Property Column_Column_Name() As String
        Get
            Return str_Column_Column_Name
        End Get
    End Property
    Public ReadOnly Property Column_Hyperlinked_to_Level_II() As String
        Get
            Return str_Column_Hyperlinked_to_Level_II
        End Get
    End Property
    Public ReadOnly Property Column_Column_Width() As String
        Get
            Return str_Columns_Column_Width
        End Get
    End Property

    Public ReadOnly Property DO_Display_Column_Header() As Boolean
        Get
            Return bln_DO_Display_Column_Header
        End Get
    End Property
    Public ReadOnly Property DO_Span_Multiple_Columns() As Boolean
        Get
            Return bln_DO_Span_Multiple_Columns
        End Get
    End Property
    Public ReadOnly Property DO_Ignore_If_Blank() As Boolean
        Get
            Return bln_DO_Ignore_If_Blank
        End Get
    End Property
    Public ReadOnly Property Column_Line_Number() As Integer
        Get
            Return int_Column_Line_Number
        End Get
    End Property
    Public ReadOnly Property Column_Position_Number() As Integer
        Get
            Return int_Column_Position_Number
        End Get
    End Property
    Public ReadOnly Property Columns_Column_Heading() As String
        Get
            Return str_Columns_Column_Heading
        End Get
    End Property
    Public ReadOnly Property Column_Text_Decoration() As String
        Get
            Return str_Column_Text_Decoration
        End Get
    End Property
    Public ReadOnly Property Column_Font_Style() As String
        Get
            Return str_Column_Font_Style
        End Get
    End Property
    Public ReadOnly Property Column_Font_Weight() As String
        Get
            Return str_Column_Font_Weight
        End Get
    End Property
    Public ReadOnly Property Column_Font_Size() As String
        Get
            Return str_Column_Font_Size
        End Get
    End Property
    Public ReadOnly Property Column_Font_Color() As String
        Get
            Return str_Column_Font_Color
        End Get
    End Property
    Public ReadOnly Property TCM_ID_Formatted() As String
        Get
            Return str_TCM_ID_Formatted
        End Get
    End Property
    Public ReadOnly Property Sort_Number() As String
        Get
            Return str_Sort_Number
        End Get
    End Property
    Public ReadOnly Property Column_Name() As String
        Get
            Return str_Column_Name
        End Get
    End Property
    Public ReadOnly Property Data_Type() As String
        Get
            Return str_Data_Type
        End Get
    End Property
    Public ReadOnly Property Column_Description() As String
        Get
            Return str_Column_Description
        End Get
    End Property
    Public ReadOnly Property Database_Name() As String
        Get
            Return str_Database_Name
        End Get
    End Property
    Public ReadOnly Property Column_Table_Name() As String
        Get
            Return str_Column_Table_Name
        End Get
    End Property
    Public ReadOnly Property Column_Name_Within_the_Table() As String
        Get
            Return str_Column_Name_Within_the_Table
        End Get
    End Property
    Public ReadOnly Property Column_Heading() As String
        Get
            Return str_Column_Heading
        End Get
    End Property
    Public ReadOnly Property Label_Prefix() As String
        Get
            Return str_Label_Prefix
        End Get
    End Property
    Public ReadOnly Property Column_Width() As String
        Get
            Return str_Column_Width
        End Get
    End Property
    Public ReadOnly Property Rows() As Integer
        Get
            Return int_Rows
        End Get
    End Property
    Public ReadOnly Property Text_Alignment() As String
        Get
            Return str_Text_Alignment
        End Get
    End Property
    Public ReadOnly Property Formatting() As String
        Get
            Return str_Formatting
        End Get
    End Property
    Public ReadOnly Property TCM_Suppress_if_Zero() As String
        Get
            Return str_TCM_Suppress_if_Zero
        End Get
    End Property
#End Region

#Region "Construction"
    Public Sub New(ByRef dr_Row As DataRow)
        int_Column_ID = CInt(dr_Row("Column_ID").ToString())
        str_Column_ID_Formatted = dr_Row("Column_ID_Formatted").ToString
        str_Column_Column_Name = dr_Row("Column_Column_Name").ToString
        str_Column_Hyperlinked_to_Level_II = dr_Row("Column_Hyperlinked_to_Level_II").ToString

        If dr_Row("DO_Display_Column_Header").ToString.ToLower = "yes" Then
            bln_DO_Display_Column_Header = True
        Else
            bln_DO_Display_Column_Header = False
        End If

        If dr_Row("DO_Span_Multiple_Columns").ToString.ToLower = "yes" Then
            bln_DO_Span_Multiple_Columns = True
        Else
            bln_DO_Span_Multiple_Columns = False
        End If

        If dr_Row("DO_Ignore_If_Blank").ToString.ToLower = "yes" Then
            bln_DO_Ignore_If_Blank = True
        Else
            bln_DO_Ignore_If_Blank = False
        End If

        int_Column_Line_Number = CInt(dr_Row("Column_Line_Number").ToString)
        int_Column_Position_Number = CInt(dr_Row("Column_Position_Number").ToString)
        str_Columns_Column_Heading = dr_Row("Columns_Column_Heading").ToString
        str_Columns_Column_Width = dr_Row("Columns_Column_Width").ToString
        str_Column_Font_Style = dr_Row("Column_Font_Style").ToString
        str_Column_Font_Weight = dr_Row("Column_Font_Weight").ToString
        str_Column_Font_Size = dr_Row("Column_Font_Size").ToString
        str_Column_Font_Color = dr_Row("Column_Font_Color").ToString
        str_Column_Text_Decoration = dr_Row("Column_Text_Decoration").ToString
        str_TCM_ID_Formatted = dr_Row("TCM_ID_Formatted").ToString
        str_Sort_Number = dr_Row("TCM_Sort_Number").ToString
        str_Column_Name = dr_Row("TCM_Column_Name").ToString
        str_Data_Type = dr_Row("TCM_Data_Type").ToString
        str_Column_Description = dr_Row("TCM_Column_Description").ToString
        str_Database_Name = dr_Row("TCM_Database_Name").ToString
        str_Column_Table_Name = dr_Row("TCM_Table_Name").ToString
        str_Column_Name_Within_the_Table = dr_Row("TCM_Column_Name_Within_the_Table").ToString
        str_Column_Heading = dr_Row("TCM_Column_Heading").ToString
        str_Label_Prefix = dr_Row("TCM_Label_Prefix").ToString
        str_Column_Width = dr_Row("TCM_Column_Width").ToString
        int_Rows = CInt(dr_Row("TCM_Rows").ToString)
        str_Text_Alignment = dr_Row("TCM_Text_Alignment").ToString
        str_Formatting = dr_Row("TCM_Formatting").ToString
        str_TCM_Suppress_if_Zero = dr_Row("TCM_Suppress_if_Zero").ToString
    End Sub
#End Region

End Class
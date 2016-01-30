Public Class CaseReporting_Report_Line

#Region "Members"
    Private str_RPD_L1_Lines_Set_ID_Formatted As String = String.Empty
    Private int_RPD_L1_Lines_Line_Number As Integer
    Private str_RPD_L1_One_Field_Spans_Multiple_Columns As String = String.Empty
    Private str_RPD_L1_Lines_Column_Heading_is_Underlined_YN As String = String.Empty
    Private str_RPD_L1_Lines_Margin_Top As String = String.Empty
    Private str_RPD_L1_Lines_Margin_Bottom As String = String.Empty
    Private str_RPD_L1_Lines_Margin_Left As String = String.Empty
    Private str_RPD_L1_Lines_Line_Height As String = String.Empty
#End Region

#Region "Properties"
    Public ReadOnly Property Lines_Set_ID_Formatted() As String
        Get
            Return str_RPD_L1_Lines_Set_ID_Formatted
        End Get
    End Property
    Public ReadOnly Property Lines_Line_Number() As Integer
        Get
            Return int_RPD_L1_Lines_Line_Number
        End Get
    End Property
    Public ReadOnly Property One_Field_Spans_Multiple_Columns() As String
        Get
            Return str_RPD_L1_One_Field_Spans_Multiple_Columns
        End Get
    End Property
    Public ReadOnly Property Lines_Column_Heading_is_Underlined_YN() As String
        Get
            Return str_RPD_L1_Lines_Column_Heading_is_Underlined_YN
        End Get
    End Property
    Public ReadOnly Property Lines_Margin_Top() As String
        Get
            Return str_RPD_L1_Lines_Margin_Top
        End Get
    End Property
    Public ReadOnly Property Lines_Margin_Bottom() As String
        Get
            Return str_RPD_L1_Lines_Margin_Bottom
        End Get
    End Property
    Public ReadOnly Property Lines_Margin_Left() As String
        Get
            Return str_RPD_L1_Lines_Margin_Left
        End Get
    End Property
    Public ReadOnly Property Lines_Line_Height() As String
        Get
            Return str_RPD_L1_Lines_Line_Height
        End Get
    End Property
#End Region

#Region "Construction"
    Public Sub New(ByRef dr_Data As DataRow)
        str_RPD_L1_Lines_Set_ID_Formatted = dr_Data("RPD_L1_Lines_Set_ID_Formatted").ToString
        int_RPD_L1_Lines_Line_Number = CInt(dr_Data("RPD_L1_Lines_Line_Number").ToString)
        str_RPD_L1_One_Field_Spans_Multiple_Columns = dr_Data("RPD_L1_One_Field_Spans_Multiple_Columns").ToString
        str_RPD_L1_Lines_Column_Heading_is_Underlined_YN = dr_Data("RPD_L1_Lines_Column_Heading_is_Underlined_YN").ToString
        str_RPD_L1_Lines_Margin_Top = dr_Data("RPD_L1_Lines_Margin_Top").ToString
        str_RPD_L1_Lines_Margin_Bottom = dr_Data("RPD_L1_Lines_Margin_Bottom").ToString
        str_RPD_L1_Lines_Margin_Left = dr_Data("RPD_L1_Lines_Margin_Left").ToString
        str_RPD_L1_Lines_Line_Height = dr_Data("RPD_L1_Lines_Line_Height").ToString
    End Sub
#End Region
End Class

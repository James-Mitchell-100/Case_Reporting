''' <summary>
''' Class to define a report definition object
''' </summary>
''' <remarks></remarks>
Public Class CaseReporting_Report_Definition

#Region "Members"
    Private int_Report_Definition_ID As Integer
    Private str_Report_Definition As String
#End Region

#Region "Properties"
    Public ReadOnly Property Report_Definition_ID() As Integer
        Get
            Return int_Report_Definition_ID
        End Get
    End Property
    Public ReadOnly Property Report_Definition() As String
        Get
            Return str_Report_Definition
        End Get
    End Property
#End Region

#Region "Construction"
    Public Sub New(ByRef dr_Row As DataRow)
        int_Report_Definition_ID = CInt(dr_Row("Report_Profile_Definition_ID").ToString)
        str_Report_Definition = dr_Row("Selection_Criteria_Specification").ToString
    End Sub
#End Region

End Class
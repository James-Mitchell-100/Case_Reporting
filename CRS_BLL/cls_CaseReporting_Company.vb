''' <summary>
''' Defines the company entity
''' </summary>
''' <remarks></remarks>
Public Class CaseReporting_Company

#Region "Members"
    Private str_Company_ID As Integer = 0
    Private str_Company_ID_Formatted As String = String.Empty
    Private str_Company_Full_Name As String = String.Empty
    Private str_Company_Sort_Name As String = String.Empty
#End Region

#Region "Properties"
    Public Property Company_ID() As Integer
        Get
            Return str_Company_ID
        End Get
        Set(ByVal value As Integer)
            str_Company_ID = value
        End Set
    End Property
    Public Property Company_ID_Formatted() As String
        Get
            Return str_Company_ID_Formatted
        End Get
        Set(ByVal value As String)
            str_Company_ID_Formatted = value
        End Set
    End Property
    Public Property Company_Full_Name() As String
        Get
            Return str_Company_Full_Name
        End Get
        Set(ByVal value As String)
            str_Company_Full_Name = value
        End Set
    End Property
    Public Property Company_Sort_Name() As String
        Get
            Return str_Company_Sort_Name
        End Get
        Set(ByVal value As String)
            str_Company_Sort_Name = value
        End Set
    End Property
#End Region
End Class

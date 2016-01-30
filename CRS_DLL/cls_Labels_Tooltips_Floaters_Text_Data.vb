Imports System.Collections.Generic

Public Class Labels_Tooltips_Floaters_Text_Data

    Inherits Sql_Base

    ''' <summary>
    ''' Retrieves Get_Labels_Tooltips_Floaters_Text information based upon the Web Page
    ''' </summary>
    ''' <param name="str_Web_Page"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_Labels_Tooltips_Floaters_Text_Info(ByVal str_Web_Page As String) As DataSet
        ' Define the target datatable
        Dim ds_Labels_Tooltips_Floaters_Text As New DataSet
        Dim int_Return As Integer = 0

        Try
            'Attempt to load the datatable
            ds_Labels_Tooltips_Floaters_Text = GetDataSet("CaseReporting_Labels_Tooltips_Floaters_Text_Info", "@WebPage", str_Web_Page)

        Catch ex As Exception
            Throw ex
        End Try

        Return ds_Labels_Tooltips_Floaters_Text
    End Function

End Class

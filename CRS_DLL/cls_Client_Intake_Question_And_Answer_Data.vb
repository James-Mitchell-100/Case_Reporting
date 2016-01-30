Imports System.Collections.Generic

Public Class Client_Intake_Question_And_Answer_Data

    Inherits Sql_Base

    ''' <summary>
    ''' Retrieves Client Intake Question And Answer email address case reporting information based upon the client id
    ''' </summary>
    ''' <param name="str_Client_ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_Client_Intake_Question_And_Answer_Info(ByVal str_Client_ID As String) As DataSet
        ' Define the target datatable
        Dim ds_Client_Intake_Question_And_Answer As New DataSet
        Dim int_Return As Integer = 0

        Try
            'Attempt to load the datatable
            ds_Client_Intake_Question_And_Answer = GetDataSet("CaseReporting_Client_Intake_Question_And_Answer_Info", "@ClientID", str_Client_ID)

        Catch ex As Exception
            Throw ex
        End Try

        Return ds_Client_Intake_Question_And_Answer
    End Function

End Class


Imports System.Data
Imports System.Data.SqlClient

' This class is designed to concentrate all SQL access into a single data layer so none of the upper tiers
' have to be aware of SQL itself.  All of the objects returned are either System.Data or object classes

Public MustInherit Class Sql_Base

#Region "Public Functions"
    ''' <summary>
    ''' Returns a dataset based upon the stored procedure name and the parameter list provided
    ''' </summary>
    ''' <param name="str_Sproc_Name"></param>
    ''' <param name="object_Params">A paired list of parameters, each containing the name of the parameter and the parameter value</param>
    ''' <returns>The resulting dataset - no results will return an empty dataset</returns>
    ''' <remarks></remarks>
    Public Function GetDataSet(ByVal str_Sproc_Name As String, ByVal ParamArray object_Params() As Object) As DataSet
        ' Create our result table
        Dim result_Set As New DataSet
        Using Sql_Connection = Get_SQL_Connection()
            Try
                ' Create the SQL command and type it
                Dim Sql_Command As SqlCommand = Get_SQL_Command(str_Sproc_Name, Sql_Connection, object_Params)

                ' Create the data adapter and fill it
                Dim sql_Adapter As New SqlDataAdapter(Sql_Command)
                sql_Adapter.Fill(result_Set)

            Catch ex As Exception
                Handle_Exception(ex)

            Finally
                If Sql_Connection.State = ConnectionState.Open Then Sql_Connection.Close()
            End Try
        End Using

        Return result_Set
    End Function

    ''' <summary>
    ''' Returns a data table based upon the stored procedure name and the parameter list provided
    ''' </summary>
    ''' <param name="str_Sproc_Name"></param>
    ''' <param name="object_Params">A paired list of parameters, each containing the name of the parameter and the parameter value</param>
    ''' <returns>The resulting data table - no results will return an empty data table</returns>
    ''' <remarks></remarks>
    Public Function GetDataTable(ByVal str_Sproc_Name As String, ByVal ParamArray object_Params() As Object) As DataTable
        ' Create our result table
        Dim result_Table As New DataTable()
        Using Sql_Connection = Get_SQL_Connection()
            Try
                ' Create the SQL command and type it
                Dim Sql_Command As SqlCommand = Get_SQL_Command(str_Sproc_Name, Sql_Connection, object_Params)

                ' Create the data adapter and fill it
                Dim sql_Adapter As New SqlDataAdapter(Sql_Command)
                sql_Adapter.Fill(result_Table)

            Catch ex As Exception
                Handle_Exception(ex)

            Finally
                If Sql_Connection.State = ConnectionState.Open Then Sql_Connection.Close()
            End Try
        End Using

        Return result_Table
    End Function

    ''' <summary>
    ''' Returns a data table based upon a query string
    ''' </summary>
    ''' <param name="str_Query"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDataTable(ByVal str_Query As String) As DataTable
        ' Create our result table
        Dim result_Table As New DataTable()
        Using Sql_Connection = Get_SQL_Connection()
            Try
                ' Create the SQL command and type it
                Dim Sql_Command As New SqlCommand(str_Query, Sql_Connection)
                Sql_Command.CommandType = CommandType.Text

                ' Create the data adapter and fill it
                Dim sql_Adapter As New SqlDataAdapter(Sql_Command)
                sql_Adapter.Fill(result_Table)

            Catch ex As Exception
                Handle_Exception(ex)

            Finally
                If Sql_Connection.State = ConnectionState.Open Then Sql_Connection.Close()
            End Try
        End Using

        Return result_Table
    End Function

    ''' <summary>
    ''' Returns a single object based upon the stored procedure name and the parameter list provided
    ''' </summary>
    ''' <param name="str_Sproc_Name"></param>
    ''' <param name="object_Params">A paired list of parameters, each containing the name of the parameter and the parameter value</param>
    ''' <returns>The resulting object - no results will return the object as nothing</returns>
    ''' <remarks></remarks>
    Public Function Execute_Scalar(ByVal str_Sproc_Name As String, ByVal ParamArray object_Params() As Object) As Object
        ' Create the return object
        Dim return_Object As Object = Nothing
        Using Sql_Connection = Get_SQL_Connection()
            Try
                ' Create the SQL command and type it
                Dim Sql_Command As SqlCommand = Get_SQL_Command(str_Sproc_Name, Sql_Connection, object_Params)

                ' Get the data
                return_Object = Sql_Command.ExecuteScalar()

            Catch ex As Exception
                Handle_Exception(ex)

            Finally
                If Sql_Connection.State = ConnectionState.Open Then Sql_Connection.Close()
            End Try
        End Using

        Return return_Object
    End Function

    ''' <summary>
    ''' Executes a SQL non-query (such as an INSERT or UPDATE)
    ''' </summary>
    ''' <param name="str_Sproc_Name"></param>
    ''' <param name="object_Params">A paired list of parameters, each containing the name of the parameter and the parameter value</param>
    ''' <remarks></remarks>
    Public Sub Execute_Non_Query(ByVal str_Sproc_Name As String, ByVal ParamArray object_Params() As Object)
        Using Sql_Connection = Get_SQL_Connection()
            Try
                ' Create the SQL command and type it
                Dim Sql_Command As SqlCommand = Get_SQL_Command(str_Sproc_Name, Sql_Connection, object_Params)

                ' Execute
                Sql_Command.ExecuteNonQuery()

            Catch ex As Exception
                Handle_Exception(ex)

            Finally
                If Sql_Connection.State = ConnectionState.Open Then Sql_Connection.Close()
            End Try
        End Using
    End Sub
#End Region

#Region "Private Methods"
    ''' <summary>
    ''' Establishes and opens a SQL connection
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Get_SQL_Connection() As SqlConnection
        '*********************
        '*********************
        'uncomment for go-live
        'Dim Sql_Connection As New SqlConnection(My.Settings.DBCONNECT_DEFAULT.ToString)
        'comment when going live
        Dim Sql_Connection As New SqlConnection(My.Settings.DBConnect_Test.ToString)
        '*********************
        '*********************
        Try
            Sql_Connection.Open()
        Catch ex As Exception
            Handle_Exception(ex)
        End Try
        Return Sql_Connection
    End Function

    Private Function Get_SQL_Command(ByVal str_Sproc_Name As String, ByRef Sql_Connection As SqlConnection, ByVal ParamArray object_Params() As Object) As SqlCommand
        ' Create the SQL command and type it
        Dim Sql_Command As New SqlCommand(str_Sproc_Name, Sql_Connection)
        Sql_Command.CommandType = CommandType.StoredProcedure

        ' Insure we have an even number of parameters
        If (object_Params.Length Mod 2 <> 0) Then
            Throw New Exception(String.Format("Incorrect number of parameters passed: {0}", object_Params.Length))
        End If

        ' Build the parameter list
        For i = 0 To object_Params.Length - 1 Step 2
            Sql_Command.Parameters.AddWithValue(object_Params(i).ToString, object_Params(i + 1))
        Next
        Return Sql_Command
    End Function

    ''' <summary>
    ''' For debug purposes only, we use this as the exception handler until we determine a better way to do it
    ''' </summary>
    ''' <param name="ex">Exception that was thrown</param>
    ''' <remarks></remarks>
    Private Sub Handle_Exception(ByVal ex As Exception)
        System.Diagnostics.Debug.Assert(False, ex.Message, ex.StackTrace)
    End Sub
#End Region

End Class

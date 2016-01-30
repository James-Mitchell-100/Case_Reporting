Imports System.Linq
Imports System.Text

Public Class CaseReporting_CriteriaBuilder

    Public Enum ARS_DataTypes

        ARS_STRING = 0
        ARS_NUMBER = 1
        ARS_DATE_COMPARISON = 2
        ARS_DATE_BETWEEN = 3
        ARS_BETWEEN_NOW = 4
    End Enum

    Private _arrOperators() As String = {"=", ">", ">=", "<", "<=", "from", "last"}

    Public Sub New()

        InitializeCollections()
    End Sub

    Private Sub InitializeCollections()
        '_arrOperators.Add("=")
        '_arrOperators.Add("<")
        '_arrOperators.Add("<=")
        '_arrOperators.Add(">")
        '_arrOperators.Add(">=")

    End Sub

    'Public Function ContainsNumeric()

    'End Function

    Public Function GetCriteria(ByVal strInputCriteria As String) As Integer

        '
        'ToDo: come back to this and implement with LINQ - for now use the
        'less glamorous For each

        ''Dim Op As IEnumerable(Of String)
        ''Op = From p In _arrOperators _
        ''     Where strInputCriteria.Contains(p) _
        ''     Select p

        ''Return Op
        Try
            'Dim strTemp() As String
            Dim strCriteria As String = String.Empty
            Dim intDataType As Integer = 0
            For Each op In _arrOperators

                If strInputCriteria.Contains(op.ToString) Then
                    'strTemp = strInputCriteria.Split(op)

                    intDataType = GetDataType(strInputCriteria, op)
                    Exit For
                End If
            Next

            Return intDataType

        Catch ex As Exception
            MsgBox("Problem in GetCriteria")
        End Try
    End Function

    Private Function GetDataType(ByVal strCriteria As String, ByVal op As String) As Integer

        'Dim strTemp As New StringBuilder
        Dim strTemp() As String

        Try

            Select Case op.ToString

                Case "from"
                    If op.ToString.Contains("now") Then
                        Return ARS_DataTypes.ARS_BETWEEN_NOW
                    Else
                        Return ARS_DataTypes.ARS_DATE_BETWEEN
                    End If
                Case "from"
                    Return ARS_DataTypes.ARS_DATE_BETWEEN
                Case "last"
                    Return ARS_DataTypes.ARS_DATE_COMPARISON
                Case Else

                    strTemp = strCriteria.Split(CChar(op))
                    If IsNumeric(strTemp(1)) Then
                        Return ARS_DataTypes.ARS_NUMBER
                    Else
                        Return ARS_DataTypes.ARS_STRING
                    End If

            End Select

        Catch ex As Exception
            MsgBox("There was a problem extracting the DataType", MsgBoxStyle.Exclamation, "mod_ARS_CriteriaBuilder:GetDataType()")
            Return -1
        End Try

    End Function

    Public Function GetNonStringValue(ByVal strInputCriteria As String) As String()
        Dim strTemp() As String = Nothing

        For Each op In _arrOperators

            If strInputCriteria.Contains(op.ToString) Then
                strTemp = strInputCriteria.Split(CChar(op))
                Exit For
            End If
        Next
        Return strTemp
    End Function

    Public Function GetDateBetweenRangeValue(ByVal strInputCriteria As String) As String

        Dim strDateChunk As New StringBuilder, strParts() As String, strSwap As String = ""
        Dim sbDate As New StringBuilder
        Dim intSegmentCounter As Integer = 0

        Try

            sbDate.Append(" BETWEEN ")

            'strInputCriteria.Replace("from", "")
            'strInputCriteria.Replace("to", "")
            strParts = strInputCriteria.Split(CChar(" "))

            For Each DateSegment In strParts

                If IsNumeric(DateSegment) Then

                    If DateSegment.Length = 4 Then          'this is the year segment numeric + 4 digits
                        If strDateChunk.Length = 4 Then     'double check that we've already got the month and day
                            strSwap = strDateChunk.ToString
                            strDateChunk.Remove(0, 4)
                            strDateChunk.Append(DateSegment)
                            strDateChunk.Append(strSwap)
                            intSegmentCounter += 1
                        End If

                    Else
                        strDateChunk.Append(DateSegment)    'we're still building the month and day
                        intSegmentCounter += 1
                    End If
                ElseIf DateSegment.Contains("now") Then
                    'Dim iYr As Integer, iMo As Integer, iDay As Integer
                    'iYr = DateAndTime.DatePart(DateInterval.Year, Now)
                    'iMo = DateAndTime.DatePart(DateInterval.Month, Now)
                    'iDay = DateAndTime.DatePart(DateInterval.Day, Now)
                    'strDateChunk.Append(String.Format("'{0}'", CStr(iYr) & CStr(iMo) & CStr(iDay)))
                    strDateChunk.Append(" current_timestamp ")
                    sbDate.Append(strDateChunk)
                    Exit For
                End If

                If intSegmentCounter = 3 Then
                    sbDate.Append(String.Format("'{0}'", strDateChunk))

                    If Not sbDate.ToString.Contains("AND") Then
                        sbDate.Append(" AND ")
                    End If
                    intSegmentCounter = 0
                    strDateChunk.Remove(0, strDateChunk.Length)
                End If

            Next
            Return sbDate.ToString
        Catch ex As Exception
            MsgBox("There was a problem with DateCriteria", MsgBoxStyle.Critical, "mod_ARS_CriteriaBuilder:GetDateRangeValue")
            Return ""
        End Try

    End Function


End Class

Public Class CriteriaOperator

    Private _InputOperator As String
    Private _DataType As String

    Public Property InputOperator() As String
        Get
            Return _InputOperator
        End Get
        Set(ByVal value As String)
            _InputOperator = value
        End Set

    End Property

    Public Property DataType() As String

        Get
            Return _DataType
        End Get
        Set(ByVal value As String)
            _DataType = value
        End Set

    End Property

End Class

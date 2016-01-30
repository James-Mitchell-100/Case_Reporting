Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CRS_DLL
Public Class CaseReporting_Cities

#Region "Properties"

    Public Property Cities As Collection

#End Region


#Region "Public Methods"
    Public Sub GetCaseReportingCities(ByVal str_City_ID As String)

        'Create the data access object and receiving data table
        Dim data_cities As New City_Data
        Dim ds_data_city As New DataSet
        Dim dt_data_city As New DataTable

        'Re-Initialize the collection
        Cities = New Collection

        ''Load the dataset
        ds_data_city = data_cities.Get_City_Info(str_City_ID)

        'Verify we got something back 
        If ds_data_city.Tables(0).Rows.Count > 0 Then

            For Each row As DataRow In ds_data_city.Tables(0).Rows
                Dim oCity As New CaseReporting_City

                With oCity
                    If row("Cities_City").ToString() <> "" Then
                        .Cities_ID = Convert.ToInt32(row("Cities_ID"))
                        If row("Cities_ID_Formatted").ToString() <> "" Then .Cities_ID_Formatted = row("Cities_ID_Formatted").ToString()
                        If row("Cities_Sort_Order").ToString() <> "" Then .Cities_Sort_Order = row("Cities_Sort_Order").ToString
                        If row("Cities_State").ToString() <> "" Then .Cities_State = row("Cities_State").ToString()
                        If row("Cities_State_City").ToString() <> "" Then .Cities_State_City = row("Cities_State_City").ToString()
                        If row("Cities_State_Code").ToString() <> "" Then .Cities_State_Code = row("Cities_State_Code").ToString()

                        If row("Cities_City").ToString() <> "" Then .Cities_City = row("Cities_City").ToString()
                        If row("Cities_Country").ToString() <> "" Then .Cities_State_Code = row("Cities_Country").ToString()
                    End If
                End With

                Cities.Add(oCity)
            Next

        End If
    End Sub

#End Region
End Class

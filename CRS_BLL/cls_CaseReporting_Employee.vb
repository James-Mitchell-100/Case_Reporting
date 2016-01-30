Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
'Imports CaseReporting_DLL
Imports CRS_DLL

''' <summary>
''' Class to define the Employee object
''' </summary>
''' <remarks></remarks>
Public Class CaseReporting_Employee

#Region "Members"
    Private str_Employee_ID As Integer = 0
    Private str_Employee_ID_Formatted As String = String.Empty
    Private str_Employee_Full_Name As String = String.Empty
    Private str_Employee_Sort_Name As String = String.Empty
    Private str_Employee_Saluation As String = String.Empty
    Private casereporting_Employee_Company As CaseReporting_Company = Nothing
    Private str_Employee_Logins_Allowed As String = String.Empty
    Private str_Employee_Password As String = String.Empty
#End Region

#Region "Properties"
    Public Property Employee_ID() As Integer
        Get
            Return str_Employee_ID
        End Get
        Set(ByVal value As Integer)
            str_Employee_ID = value
        End Set
    End Property
    Public Property Employee_ID_Formatted() As String
        Get
            Return str_Employee_ID_Formatted
        End Get
        Set(ByVal value As String)
            str_Employee_ID_Formatted = value
        End Set
    End Property
    Public Property Employee_Full_Name() As String
        Get
            Return str_Employee_Full_Name
        End Get
        Set(ByVal value As String)
            str_Employee_Full_Name = value
        End Set
    End Property
    Public Property Employee_Sort_Name() As String
        Get
            Return str_Employee_Sort_Name
        End Get
        Set(ByVal value As String)
            str_Employee_Sort_Name = value
        End Set
    End Property
    Public Property Employee_Saluation() As String
        Get
            Return str_Employee_Saluation
        End Get
        Set(ByVal value As String)
            str_Employee_Saluation = value
        End Set
    End Property
    Public Property Employee_Company() As CaseReporting_Company
        Get
            Return casereporting_Employee_Company
        End Get
        Set(ByVal value As CaseReporting_Company)
            casereporting_Employee_Company = value
        End Set
    End Property
    Public Property Employee_Logins_Allowed() As String
        Get
            Return str_Employee_Logins_Allowed
        End Get
        Set(ByVal value As String)
            str_Employee_Logins_Allowed = value
        End Set
    End Property
    Public Property Employee_Password() As String
        Get
            Return str_Employee_Password
        End Get
        Set(ByVal value As String)
            str_Employee_Password = value
        End Set
    End Property
#End Region

#Region "Public Methods"
    ''' <summary>
    ''' This method attempts to retrieve the employee information based upon the user supplied values
    ''' </summary>
    ''' <param name="str_Login_Name">User supplied email address</param>
    ''' <param name="str_Login_Password">User supplied password</param>
    ''' <remarks>
    ''' This method attempts to retrieve a data table containing the employee information from the DLL.  If successful, the DLL will
    ''' return a data table containing the requested information.  If the attempt fails, the DLL will return an empty data table which
    ''' is interpreted as a login failure
    ''' </remarks>
    Public Sub Login(ByVal str_Login_Name As String, ByVal str_Login_Password As String)

        'Create the data access object and receiving data table
        Dim data_employee As New Employee_Data()
        Dim ds_Employee As New DataSet

        'Load the dataset
        ds_Employee = data_employee.Get_Employee_Info(str_Login_Name, str_Login_Password)

        'Verify we got something back - only valid of 1 row is returned
        If ds_Employee.Tables(0).Rows.Count = 1 Then

            ' Hydrate the employee object
            Dim row As DataRow = ds_Employee.Tables(0).Rows(0)
            Employee_ID = Convert.ToInt32(row("Employee_ID"))
            Employee_ID_Formatted = row("Employee_ID_Formatted").ToString()
            Employee_Full_Name = row("Employee_Full_Name").ToString()
            Employee_Sort_Name = row("Employee_Sort_Name").ToString()
            Employee_Saluation = row("Employee_Saluation").ToString()
            Employee_Company = New casereporting_Company()
            Employee_Company.Company_ID = Convert.ToInt32(row("Company_ID"))
            Employee_Company.Company_ID_Formatted = row("Company_ID_Formatted").ToString()
            Employee_Company.Company_Full_Name = row("Company_Full_Name").ToString()
            Employee_Company.Company_Sort_Name = row("Company_Sort_Name").ToString()

        End If
    End Sub
#End Region
End Class

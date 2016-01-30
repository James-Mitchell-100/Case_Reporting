Imports CRS_DLL

''' <summary>
''' Class to define the Referring Attorney object
''' </summary>
''' <remarks></remarks>
Public Class CRS_Referring_Attorney

#Region "Members"
    Private str_Referring_Attorney_ID As Integer = 0
    Private str_Referring_Attorney_ID_Formatted As String = String.Empty
    Private str_Referring_Attorney_Full_Name As String = String.Empty
    Private str_Referring_Attorney_Sort_Name As String = String.Empty
    Private str_Referring_Attorney_Saluation As String = String.Empty
#End Region

#Region "Properties"
    Public Property Referring_Attorney_ID() As Integer
        Get
            Return str_Referring_Attorney_ID
        End Get
        Set(ByVal value As Integer)
            str_Referring_Attorney_ID = value
        End Set
    End Property
    Public Property Referring_Attorney_ID_Formatted() As String
        Get
            Return str_Referring_Attorney_ID_Formatted
        End Get
        Set(ByVal value As String)
            str_Referring_Attorney_ID_Formatted = value
        End Set
    End Property
    Public Property Referring_Attorney_Full_Name() As String
        Get
            Return str_Referring_Attorney_Full_Name
        End Get
        Set(ByVal value As String)
            str_Referring_Attorney_Full_Name = value
        End Set
    End Property
    Public Property Referring_Attorney_Sort_Name() As String
        Get
            Return str_Referring_Attorney_Sort_Name
        End Get
        Set(ByVal value As String)
            str_Referring_Attorney_Sort_Name = value
        End Set
    End Property
    Public Property Referring_Attorney_Saluation() As String
        Get
            Return str_Referring_Attorney_Saluation
        End Get
        Set(ByVal value As String)
            str_Referring_Attorney_Saluation = value
        End Set
    End Property
#End Region


#Region "Public Methods"
    ''' <summary>
    ''' This method attempts to retrieve the referring attorney information based upon the user supplied values
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
        Dim data_Referring_Attorney As New Referring_Attorney_Data()
        Dim ds_Referring_Attorney As New DataSet

        'Load the dataset
        ds_Referring_Attorney = data_Referring_Attorney.Get_Referring_Attorney_Info(str_Login_Name, str_Login_Password)

        'Verify we got something back - only valid of 1 row is returned
        If ds_Referring_Attorney.Tables(0).Rows.Count = 1 Then

            ' Hydrate the Referring Attorney object
            Dim row As DataRow = ds_Referring_Attorney.Tables(0).Rows(0)
            Referring_Attorney_ID = Convert.ToInt32(row("Ref_Att_ID"))
            Referring_Attorney_ID_Formatted = row("Ref_Att_ID_Formatted").ToString()
            Referring_Attorney_Full_Name = row("Ref_Att_Full_Name").ToString()
            Referring_Attorney_Sort_Name = row("Ref_Att_Sort_Name").ToString()
            Referring_Attorney_Saluation = row("Ref_Att_Salutation").ToString()

        End If

    End Sub

#End Region


End Class

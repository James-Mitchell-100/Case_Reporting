''' <summary>
''' This class is used for properties and objects shared across all projects
''' </summary>
''' <remarks></remarks>
Public Class Common

    ''' <summary>
    ''' Defines the different types of reports
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum Report_Type
        Standard
        Custom
    End Enum

#Region "Constants"
    Public Const ssn_Type_Of_Case As String = "Type_Of_Case"
    Public Const ssn_Attorney As String = "Attorney"
    Public Const ssn_Attorney_Email_Address As String = "Attorney_Email_Address"
    Public Const ssn_Standard_Reports As String = "Standard_Reports"
    Public Const ssn_Custom_Reports As String = "Custom_Reports"
    Public Const ssn_Current_Page As String = "Current_Page"
    Public Const ssn_Clients_Case_Reporting As String = "Clients_Case_Reporting"
    Public Const ssn_Client As String = "Clients"
    Public Const ssn_Logged_In As String = "Logged_In"
    Public Const ssn_Client_Intake_Question_And_Answer As String = "Client_Intake_Question_And_Answer"
    Public Const ssn_Client_Scripted_Question_And_Response As String = "Client_Scripted_Question_And_Response"
    Public Const ssn_Preamble As String = "Preamble"
    Public Const ssn_Preambles As String = "Preambles"
    Public Const ssn_Type_Of_Case_And_Marketing_Fee As String = "Type_Of_Case_And_Marketing_Fee"
    Public Const ssn_AttorneyID As String = "AttorneyID"
    Public Const ssn_LawFirmID As String = "LawFirmID"
    Public Const ssn_Referring_Attorney = "Referring_Attorney"
    Public Const ssn_LawFirmName = "Law_Firm_Name"
    Public Const ssn_StateID As String = "StateID"
#End Region

End Class

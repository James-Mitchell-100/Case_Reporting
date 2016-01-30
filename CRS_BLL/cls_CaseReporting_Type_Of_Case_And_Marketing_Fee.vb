Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CRS_DLL
Public Class CaseReporting_Type_Of_Case_And_Marketing_Fee
#Region "Properties"

    Public Property ToC_ID As Long
    Public Property ToC_Main_Category As String
    Public Property ToC_ID_Formatted As String
    Public Property ToC_Type_of_Case As String
    Public Property ToC_LF_IMF_Flat_Fee_or_Sliding_Scale As String
    Public Property Level_of_Damages As String
    Public Property ToC_LF_IMF_Flat_Fee_Amount As String
    Public Property ToC_LF_IMF_Sliding_Scale_Amount_Level_01 As String
    Public Property ToC_LF_IMF_Sliding_Scale_Amount_Level_02 As String
    Public Property ToC_LF_IMF_Sliding_Scale_Amount_Level_03 As String
    Public Property ToC_LF_IMF_Sliding_Scale_Amount_Level_04 As String
    Public Property ToC_LF_IMF_Sliding_Scale_Amount_Level_05 As String
    Public Property ToC_LF_IMF_Sliding_Scale_Amount_Level_06 As String
    Public Property ToC_LF_IMF_Sliding_Scale_Amount_Level_07 As String

    Public Property ToC_LF_RF_Referral_Fee_Percentage As String
    Public Property ToC_LF_IMF_Is_Fee_Acceptable As String
    Public Property ToC_Comments As String

#End Region
End Class

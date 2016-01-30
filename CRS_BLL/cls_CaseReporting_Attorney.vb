Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
'Imports CaseReporting_DLL
Imports CRS_DLL

Public Class CaseReporting_Attorney

#Region "Properties"

    Public Property Attorneys_ID As Long
    Public Property Attorneys_ID_Formatted As String
    Public Property Attorneys_Status As String
    Public Property Attorneys_In_the_Future_Date As Date
    Public Property Attorneys_Our_Overall_Ranking As Long
    Public Property Attorneys_Contact_Number As Long
    Public Property Attorneys_Referral_Level As Long
    Public Property Attorneys_Also_a_Referring_Attorney As String
    Public Property Attorneys_Description As String
    Public Property Attorneys_Law_Firm_ID As Long
    Public Property Attorneys_Law_Firm_ID_Formatted As String
    Public Property Attorneys_Law_Firm_Full_Name As String
    Public Property Attorneys_Law_Firm_Sort_Name As String
    Public Property Attorneys_Law_Firm_Zip_Code As String
    Public Property Attorneys_Law_Firm_Telephone_Number As String
    Public Property Attorneys_Law_Firm_Cities_ID As Long
    Public Property Attorneys_Date_of_Last_Contact As Date
    Public Property Attorneys_Followup_Required As String
    Public Property Attorneys_Followup_Date As Date
    Public Property Attorneys_Followup_Comments As String
    Public Property Attorneys_Law_Firms_Contact_Priority As Long
    Public Property Attorneys_Project_Contact_Code As Long
    Public Property Attorneys_Lead_Referring_Attorney As String
    Public Property Attorneys_Call_Him_for_Referrals As String
    Public Property Attorneys_Send_Leads_To_This_Attorney_Via_Email As String
    Public Property Attorneys_Send_Leads_To_This_Attorney_Via_Txt As String
    Public Property Attorneys_Send_Leads_via_Txt_Short_Medium_Long As String
    Public Property Attorneys_Full_Name As String
    Public Property Attorneys_Sort_Name As String
    Public Property Attorneys_Salutation As String
    Public Property Attorneys_Title As String
    Public Property Attorneys_Address As String
    Public Property Attorneys_City As String
    Public Property Attorneys_MSA_Code As String
    Public Property Attorneys_County_FIPS As String
    Public Property Attorneys_County As String
    Public Property Attorneys_State As String
    Public Property Attorneys_Zip_Code As String
    Public Property Attorneys_State_Two_Character_USPS_Code As String
    Public Property Attorneys_Country As String
    Public Property Attorneys_Time_Zone As String
    Public Property Attorneys_Telephone_Number As String
    Public Property Attorneys_Fax_Telephone_Number As String
    Public Property Attorneys_Assistant_NRR_Full_Name As String
    Public Property Attorneys_Assistant_NRR_Telephone_Number As String
    Public Property Attorneys_Assistant_NRR_Email_Address As String
    Public Property Attorneys_Assistant_NRR_Comments As String
    Public Property Attorneys_WSB_Law_Firm_Biography_URL As String
    Public Property Attorneys_WSB_LinkedIn_URL As String
    Public Property Attorneys_WSB_Facebook_URL As String
    Public Property Attorneys_WSB_Other_Websites As String
    Public Property Attorneys_WSB_Biography As String
    Public Property Attorneys_Email_Address As String
    Public Property Attorneys_Email_Addresses_Other As String
    Public Property Attorneys_Email_Reminder_YN As String
    Public Property Attorneys_Email_Reminder As String
    Public Property Attorneys_Comments_Overall As String
    Public Property Attorneys_Comments_Overall_Private As String
    Public Property Attorneys_Types_of_Cases_He_Is_Most_Interested_In As String
    Public Property Attorneys_Contact_History As String
    Public Property Attorneys_Mailing_List_Send_Articles As String
    Public Property Attorneys_Logins_Allowed As String
    Public Property Attorneys_Password As String
    Public Property Attorneys_Date_Time_Created As Date

#End Region

#Region "Public Methods"
    Public Sub GetCaseReportingAttorney(ByVal str_Attorney_ID As String)

        'Create the data access object and receiving data table
        Dim data_attorney As New Attorney_Data
        Dim ds_Attorney As New DataSet
        Dim dt_Attorney As New DataTable

        'Load the dataset
        ds_Attorney = data_attorney.Get_Attorney_Info(str_Attorney_ID)

        'Verify we got something back - only valid of 1 row is returned
        If ds_Attorney.Tables(0).Rows.Count = 1 Then

            ' Hydrate the attorney object
            Dim row As DataRow = ds_Attorney.Tables(0).Rows(0)

            Attorneys_ID = Convert.ToInt32(row("Attorneys_ID"))

            If row("Attorneys_ID_Formatted").ToString() <> "" Then Attorneys_ID_Formatted = row("Attorneys_ID_Formatted").ToString()
            If row("Attorneys_Status").ToString() <> "" Then Attorneys_Status = row("Attorneys_Status").ToString()
            If row("Attorneys_In_the_Future_Date").ToString() <> "" Then Attorneys_In_the_Future_Date = CDate(row("Attorneys_In_the_Future_Date").ToString())
            If row("Attorneys_Our_Overall_Ranking").ToString() <> "" Then Attorneys_Our_Overall_Ranking = Convert.ToInt32(row("Attorneys_Our_Overall_Ranking"))
            If row("Attorneys_Contact_Number").ToString() <> "" Then Attorneys_Contact_Number = Convert.ToInt32(row("Attorneys_Contact_Number"))
            If row("Attorneys_Referral_Level").ToString() <> "" Then Attorneys_Referral_Level = Convert.ToInt32(row("Attorneys_Referral_Level"))
            If row("Attorneys_Also_a_Referring_Attorney").ToString() <> "" Then Attorneys_Also_a_Referring_Attorney = row("Attorneys_Also_a_Referring_Attorney").ToString()
            If row("Attorneys_Description").ToString() <> "" Then Attorneys_Description = row("Attorneys_Description").ToString()
            If row("Attorneys_Law_Firm_ID").ToString() <> "" Then Attorneys_Law_Firm_ID = Convert.ToInt32(row("Attorneys_Law_Firm_ID"))
            If row("Attorneys_Law_Firm_ID_Formatted").ToString() <> "" Then Attorneys_Law_Firm_ID_Formatted = row("Attorneys_Law_Firm_ID_Formatted").ToString
            If row("Attorneys_Law_Firm_Full_Name").ToString() <> "" Then Attorneys_Law_Firm_Full_Name = row("Attorneys_Law_Firm_Full_Name").ToString
            If row("Attorneys_Law_Firm_Sort_Name").ToString() <> "" Then Attorneys_Law_Firm_Sort_Name = row("Attorneys_Law_Firm_Sort_Name").ToString
            If row("Attorneys_Law_Firm_Zip_Code").ToString() <> "" Then Attorneys_Law_Firm_Zip_Code = row("Attorneys_Law_Firm_Zip_Code").ToString
            If row("Attorneys_Law_Firm_Telephone_Number").ToString() <> "" Then Attorneys_Law_Firm_Telephone_Number = row("Attorneys_Law_Firm_Telephone_Number").ToString
            If row("Attorneys_Law_Firm_Cities_ID").ToString() <> "" Then Attorneys_Law_Firm_Cities_ID = Convert.ToInt32(row("Attorneys_Law_Firm_Cities_ID"))
            If row("Attorneys_Date_of_Last_Contact").ToString() <> "" Then Attorneys_Date_of_Last_Contact = CDate(row("Attorneys_Date_of_Last_Contact"))
            If row("Attorneys_Followup_Required").ToString() <> "" Then Attorneys_Followup_Required = row("Attorneys_Followup_Required").ToString
            If row("Attorneys_Followup_Date").ToString() <> "" Then Attorneys_Followup_Date = CDate(row("Attorneys_Followup_Date"))
            If row("Attorneys_Followup_Comments").ToString() <> "" Then Attorneys_Followup_Comments = row("Attorneys_Followup_Comments").ToString
            If row("Attorneys_Law_Firms_Contact_Priority").ToString() <> "" Then Attorneys_Law_Firms_Contact_Priority = Convert.ToInt32(row("Attorneys_Law_Firms_Contact_Priority"))
            If row("Attorneys_Project_Contact_Code").ToString() <> "" Then Attorneys_Project_Contact_Code = Convert.ToInt32(row("Attorneys_Project_Contact_Code"))
            If row("Attorneys_Lead_Referring_Attorney").ToString() <> "" Then Attorneys_Lead_Referring_Attorney = row("Attorneys_Lead_Referring_Attorney").ToString
            If row("Attorneys_Call_Him_for_Referrals").ToString() <> "" Then Attorneys_Call_Him_for_Referrals = row("Attorneys_Call_Him_for_Referrals").ToString
            If row("Attorneys_Send_Leads_To_This_Attorney_Via_Email").ToString() <> "" Then Attorneys_Send_Leads_To_This_Attorney_Via_Email = row("Attorneys_Send_Leads_To_This_Attorney_Via_Email").ToString
            If row("Attorneys_Send_Leads_To_This_Attorney_Via_Txt").ToString() <> "" Then Attorneys_Send_Leads_To_This_Attorney_Via_Txt = row("Attorneys_Send_Leads_To_This_Attorney_Via_Txt").ToString
            If row("Attorneys_Send_Leads_via_Txt_Short_Medium_Long").ToString() <> "" Then Attorneys_Send_Leads_via_Txt_Short_Medium_Long = row("Attorneys_Send_Leads_via_Txt_Short_Medium_Long").ToString
            If row("Attorneys_Full_Name").ToString() <> "" Then Attorneys_Full_Name = row("Attorneys_Full_Name").ToString
            If row("Attorneys_Sort_Name").ToString() <> "" Then Attorneys_Sort_Name = row("Attorneys_Sort_Name").ToString
            If row("Attorneys_Salutation").ToString() <> "" Then Attorneys_Salutation = row("Attorneys_Salutation").ToString
            If row("Attorneys_Title").ToString() <> "" Then Attorneys_Title = row("Attorneys_Title").ToString
            If row("Attorneys_Address").ToString() <> "" Then Attorneys_Address = row("Attorneys_Address").ToString
            If row("Attorneys_City").ToString() <> "" Then Attorneys_City = row("Attorneys_City").ToString
            If row("Attorneys_MSA_Code").ToString() <> "" Then Attorneys_MSA_Code = row("Attorneys_MSA_Code").ToString
            If row("Attorneys_County_FIPS").ToString() <> "" Then Attorneys_County_FIPS = row("Attorneys_County_FIPS").ToString
            If row("Attorneys_County").ToString() <> "" Then Attorneys_County = row("Attorneys_County").ToString
            If row("Attorneys_State").ToString() <> "" Then Attorneys_State = row("Attorneys_State").ToString
            If row("Attorneys_Zip_Code").ToString() <> "" Then Attorneys_Zip_Code = row("Attorneys_Zip_Code").ToString
            If row("Attorneys_State_Two_Character_USPS_Code").ToString() <> "" Then Attorneys_State_Two_Character_USPS_Code = row("Attorneys_State_Two_Character_USPS_Code").ToString
            If row("Attorneys_Country").ToString() <> "" Then Attorneys_Country = row("Attorneys_Country").ToString
            If row("Attorneys_Time_Zone").ToString() <> "" Then Attorneys_Time_Zone = row("Attorneys_Time_Zone").ToString
            If row("Attorneys_Telephone_Number").ToString() <> "" Then Attorneys_Telephone_Number = row("Attorneys_Telephone_Number").ToString
            If row("Attorneys_Fax_Telephone_Number").ToString() <> "" Then Attorneys_Fax_Telephone_Number = row("Attorneys_Fax_Telephone_Number").ToString
            If row("Attorneys_Assistant_NRR_Full_Name").ToString() <> "" Then Attorneys_Assistant_NRR_Full_Name = row("Attorneys_Assistant_NRR_Full_Name").ToString
            If row("Attorneys_Assistant_NRR_Telephone_Number").ToString() <> "" Then Attorneys_Assistant_NRR_Telephone_Number = row("Attorneys_Assistant_NRR_Telephone_Number").ToString
            If row("Attorneys_Assistant_NRR_Email_Address").ToString() <> "" Then Attorneys_Assistant_NRR_Email_Address = row("Attorneys_Assistant_NRR_Email_Address").ToString
            If row("Attorneys_Assistant_NRR_Comments").ToString() <> "" Then Attorneys_Assistant_NRR_Comments = row("Attorneys_Assistant_NRR_Comments").ToString
            If row("Attorneys_WSB_Law_Firm_Biography_URL").ToString() <> "" Then Attorneys_WSB_Law_Firm_Biography_URL = row("Attorneys_WSB_Law_Firm_Biography_URL").ToString
            If row("Attorneys_WSB_LinkedIn_URL").ToString() <> "" Then Attorneys_WSB_LinkedIn_URL = row("Attorneys_WSB_LinkedIn_URL").ToString
            If row("Attorneys_WSB_Facebook_URL").ToString() <> "" Then Attorneys_WSB_Facebook_URL = row("Attorneys_WSB_Facebook_URL").ToString
            If row("Attorneys_WSB_Other_Websites").ToString() <> "" Then Attorneys_WSB_Other_Websites = row("Attorneys_WSB_Other_Websites").ToString
            If row("Attorneys_WSB_Biography").ToString() <> "" Then Attorneys_WSB_Biography = row("Attorneys_WSB_Biography").ToString
            If row("Attorneys_Email_Address").ToString() <> "" Then Attorneys_Email_Address = row("Attorneys_Email_Address").ToString
            If row("Attorneys_Email_Addresses_Other").ToString() <> "" Then Attorneys_Email_Addresses_Other = row("Attorneys_Email_Addresses_Other").ToString
            If row("Attorneys_Email_Reminder_YN").ToString() <> "" Then Attorneys_Email_Reminder_YN = row("Attorneys_Email_Reminder_YN").ToString
            If row("Attorneys_Email_Reminder").ToString() <> "" Then Attorneys_Email_Reminder = row("Attorneys_Email_Reminder").ToString
            If row("Attorneys_Comments_Overall").ToString() <> "" Then Attorneys_Comments_Overall = row("Attorneys_Comments_Overall").ToString
            If row("Attorneys_Comments_Overall_Private").ToString() <> "" Then Attorneys_Comments_Overall_Private = row("Attorneys_Comments_Overall_Private").ToString
            If row("Attorneys_Types_of_Cases_He_Is_Most_Interested_In").ToString() <> "" Then Attorneys_Types_of_Cases_He_Is_Most_Interested_In = row("Attorneys_Types_of_Cases_He_Is_Most_Interested_In").ToString
            If row("Attorneys_Contact_History").ToString() <> "" Then Attorneys_Contact_History = row("Attorneys_Contact_History").ToString
            If row("Attorneys_Mailing_List_Send_Articles").ToString() <> "" Then Attorneys_Mailing_List_Send_Articles = row("Attorneys_Mailing_List_Send_Articles").ToString
            If row("Attorneys_Logins_Allowed").ToString() <> "" Then Attorneys_Logins_Allowed = row("Attorneys_Logins_Allowed").ToString
            If row("Attorneys_Password").ToString() <> "" Then Attorneys_Password = row("Attorneys_Password").ToString
            If row("Attorneys_Date_Time_Created").ToString() <> "" Then Attorneys_Date_Time_Created = CDate(row("Attorneys_Date_Time_Created"))

        End If
    End Sub

#End Region
End Class


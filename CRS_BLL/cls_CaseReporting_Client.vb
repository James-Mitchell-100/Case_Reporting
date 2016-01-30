Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
'Imports CaseReporting_DLL
Imports CRS_DLL

Public Class CaseReporting_Client

#Region "Properties"

    Public Property Clients_ID As Long
    Public Property Clients_ID_Formatted As String
    Public Property Clients_Spam_Reviewed_YN As String
    Public Property Clients_Status As String
    Public Property Clients_In_the_Future_Date As Date
    Public Property Clients_Contact_Status As String
    Public Property Clients_Referring_Paralegal_Firm_Client As Long
    Public Property Clients_Referring_Paralegal_Client As Long
    Public Property Clients_Referring_Law_Firm_Client As Long
    Public Property Clients_Referring_Attorney_Client As Long
    Public Property Clients_Referring_Paralegal_Firm_Receiving_Law_Firm As Long
    Public Property Clients_Referring_Paralegal_Receiving_Law_Firm As Long
    Public Property Clients_Referring_Law_Firm_Receiving_Law_Firm As Long
    Public Property Clients_Referring_Attorney_Receiving_Law_Firm As Long
    Public Property Clients_Priority_Number_Referring_Paralegal As Long
    Public Property Clients_Priority_Number_Manager_Referring_Paralegal As Long
    Public Property Clients_Priority_Number_Referring_Attorney As Long
    Public Property Clients_Priority_Number_Manager_Referring_Law_Firm As Long
    Public Property Clients_Priority_Number_Overall_Manager As Long
    Public Property Clients_Priority_Comments As String
    Public Property Clients_First_Name As String
    Public Property Clients_Last_Name As String
    Public Property Clients_Full_Name As String
    Public Property Clients_Sort_Name As String
    Public Property Clients_Salutation As String
    Public Property Clients_Address As String
    Public Property Clients_City As String
    Public Property Clients_County_FIPS As String
    Public Property Clients_County As String
    Public Property Clients_MSA_Code As String
    Public Property Clients_State_Two_Character_USPS_Code As String
    Public Property Clients_State As String
    Public Property Clients_Zip_Code As String
    Public Property Clients_Cities_ID As Long
    Public Property Clients_Sex As String
    Public Property Clients_Social_Security_Number As String
    Public Property Clients_Date_of_Birth As Date
    Public Property Clients_Education As String
    Public Property Clients_Time_Zone As String
    Public Property Clients_Telephone_Number As String
    Public Property Clients_Telephone_Number_Home As String
    Public Property Clients_Telephone_Number_Work As String
    Public Property Clients_Telephone_Number_Work_Ext As String
    Public Property Clients_Telephone_Number_Mobile As String
    Public Property Clients_Telephone_Number_Fax As String
    Public Property Clients_Telephone_Number_Best_Time_To_Call As String
    Public Property Clients_Email_Address As String
    Public Property Clients_Email_Addresses_Other As String
    Public Property Clients_Email_Initial_Followup_YN As String
    Public Property Clients_Email_Initial_Followup_Email_Number As Long
    Public Property Clients_Email_Initial_Email_Text As String
    Public Property Clients_Email_Reminder_YN As String
    Public Property Clients_Email_Reminder As String
    Public Property Clients_Initial_Message_from_Client As String
    Public Property Clients_File_Server_Folder_Created As String
    Public Property Clients_File_Server_Folder_Name As String
    Public Property Clients_Source_Search_Engine As String
    Public Property Clients_Source_Search_Term_Used As String
    Public Property Clients_IP_Address As String
    Public Property Clients_Web_Site As String
    Public Property Clients_Source_Web_Page_CIF_Was_Submitted_From As String
    Public Property Clients_Referring_URL As String
    Public Property Clients_Source_Traffic_Source As String
    Public Property Clients_Source_of_Lead As String
    Public Property Clients_Source_Time_Spent_on_Web_Site_Until_CIF_Submission As Long
    Public Property Clients_Strategic_Partner As Long
    Public Property Clients_800_TN_Source_is_an_800_Telephone_Number As String
    Public Property Clients_800_TN_800_Telephone_Service As Long
    Public Property Clients_800_TN_800_Telephone_Number As Long
    Public Property Clients_800_TN_Owner_of_800_Telephone_Number_1 As String
    Public Property Clients_800_TN_Owner_of_800_Telephone_Number_2 As String
    Public Property Clients_800_TN_Caller_ID As String
    Public Property Clients_800_TN_Caller_Name As String
    Public Property Clients_800_TN_Originating_Number As String
    Public Property Clients_800_TN_Originating_Place As String
    Public Property Clients_800_TN_Destination_Number As String
    Public Property Clients_800_TN_Destination_Place As String
    Public Property Clients_800_TN_Length_of_Call As Long
    Public Property Clients_800_TN_Cost_of_Call As String
    Public Property Clients_800_TN_Charge_Date As Date
    Public Property Clients_800_TN_Date_Time_of_Telephone_Call As Date
    Public Property Clients_CIF_IAB_Ad_Unit_Name As String
    Public Property Clients_CIF_Design_Name As String
    Public Property Clients_CIF_Raw_Form_Data As String
    Public Property Clients_Case_Evaluation_SQM_ID As Long
    Public Property Clients_Case_Evaluation_SQM_ID_Formatted As String
    Public Property Clients_Case_Evaluation_Liability As String
    Public Property Clients_Case_Evaluation_Causation As String
    Public Property Clients_Case_Evaluation_Potential_Defendants As String
    Public Property Clients_Case_Evaluation_Insurance_Policies As String
    Public Property Clients_Case_Evaluation_Counterclaims As String
    Public Property Clients_Case_Evaluation_Damages_Bodily_Injury_Text As String
    Public Property Clients_Case_Evaluation_Damages_Bodily_Injury_Amount As String
    Public Property Clients_Case_Evaluation_Damages_Other_Personal_Injury_Text As String
    Public Property Clients_Case_Evaluation_Damages_Other_Personal_Injury_Amount As String
    Public Property Clients_Case_Evaluation_Damages_Medical_Expenses_Text As String
    Public Property Clients_Case_Evaluation_Damages_Medical_Expenses_Amount As String
    Public Property Clients_Case_Evaluation_Damages_Other_OoP_Expenses_Text As String
    Public Property Clients_Case_Evaluation_Damages_Other_OoP_Expenses_Amount As String
    Public Property Clients_Case_Evaluation_Damages_Lost_Wages_Text As String
    Public Property Clients_Case_Evaluation_Damages_Lost_Wages_Amount As String
    Public Property Clients_Case_Evaluation_Damages_Lost_Income_Text As String
    Public Property Clients_Case_Evaluation_Damages_Lost_Income_Amount As String
    Public Property Clients_Case_Evaluation_Damages_Pain_and_Suffering_Text As String
    Public Property Clients_Case_Evaluation_Damages_Pain_and_Suffering_Amount As String
    Public Property Clients_Case_Evaluation_Damages_Emotional_Damages_Text As String
    Public Property Clients_Case_Evaluation_Damages_Emotional_Damages_Amount As String
    Public Property Clients_Case_Evaluation_Damages_Loss_of_Consortium_Text As String
    Public Property Clients_Case_Evaluation_Damages_Loss_of_Consortium_Amount As String
    Public Property Clients_Case_Evaluation_Damages_Loss_of_Companionship_Text As String
    Public Property Clients_Case_Evaluation_Damages_Loss_of_Companionship_Amount As String
    Public Property Clients_Case_Evaluation_Damages_Miscellaneous_and_Other_Text As String
    Public Property Clients_Case_Evaluation_Damages_Miscellaneous_and_Other_Amount As String
    Public Property Clients_Case_Evaluation_Damages_Punitive_Damages_Text As String
    Public Property Clients_Case_Evaluation_Damages_Punitive_Damages_Amount As String
    Public Property Clients_Case_Evaluation_Damages_Estimated_Value As String
    Public Property Clients_Case_Evaluation_Damages_Estimated_Value_Amount As String
    Public Property Clients_Case_Evaluation_Damages_Total_Text As String
    Public Property Clients_Case_Evaluation_Damages_Total_Amount As String
    Public Property Clients_ToC_MC_ID As Long
    Public Property Clients_ToC_MC_ID_Formatted As String
    Public Property Clients_ToC_MC_Main_Category As String
    Public Property Clients_ToC_MC_Sort_Name As String
    Public Property Clients_ToC_ID As Long
    Public Property Clients_ToC_ID_Formatted As String
    Public Property Clients_ToC_Type_of_Case As String
    Public Property Clients_ToC_Sort_Name As String
    Public Property Clients_Type_of_Damage As String
    Public Property Clients_Level_of_Damages As Long
    Public Property Clients_Lawsuit_Filed As String
    Public Property Clients_Lawsuit_Date_Filed As Date
    Public Property Clients_Lawsuit_Courthouse As String
    Public Property Clients_Lawsuit_Courthouse_Telephone_Number_Clerks_Office As String
    Public Property Clients_Lawsuit_Courthouse_Electronic_Access_to_Docket As String
    Public Property Clients_Lawsuit_Case_Number As String
    Public Property Clients_Lawsuit_Caption As String
    Public Property Clients_Next_Step As String
    Public Property Clients_Comments_One_Line_Summary As String
    Public Property Clients_Comments_Overall As String
    Public Property Clients_Contact_History As String
    Public Property Clients_Description_of_the_Case As String
    Public Property Clients_Case_Writeup As String
    Public Property Clients_Case_Writeup_Disguised As String
    Public Property Clients_To_Whom_Should_the_Case_be_Referred As String
    Public Property Clients_Backup_Has_Client_Record_Been_Deleted_YN As String
    Public Property Clients_Who_Deleted_the_Client_Record_ID As Long
    Public Property Clients_Who_Deleted_the_Client_Record_ID_Formatted As String
    Public Property Clients_Who_Deleted_the_Client_Record As String
    Public Property Clients_When_Was_This_Client_Record_Deleted As Date
    Public Property Clients_How_Was_This_Client_Record_Deleted As String
    Public Property Clients_Deleted_Microsoft_Access_Form_Number As String
    Public Property Clients_Date_Time_Created As Date
    Public Property Clients_Referral_History_Temp As String

#End Region

#Region "Public Methods"
    Public Sub GetCaseReportingClient(ByVal str_Client_ID As String)

        'Create the data access object and receiving data table
        Dim data_client As New Client_Data
        Dim ds_Client As New DataSet
        Dim dt_Client As New DataTable

        'Load the dataset
        ds_Client = data_client.Get_Client_Info(str_Client_ID)

        'Verify we got something back - only valid of 1 row is returned
        If ds_Client.Tables(0).Rows.Count = 1 Then

            ' Hydrate the client object
            Dim row As DataRow = ds_Client.Tables(0).Rows(0)

            Clients_ID = Convert.ToInt32(row("Clients_ID"))
            If row("Clients_ID_Formatted").ToString() <> "" Then Clients_ID_Formatted = row("Clients_ID_Formatted").ToString()
            If row("Clients_Spam_Reviewed_YN").ToString() <> "" Then Clients_Spam_Reviewed_YN = row("Clients_Spam_Reviewed_YN").ToString()
            If row("Clients_Status").ToString() <> "" Then Clients_Status = row("Clients_Status").ToString()
            If row("Clients_In_the_Future_Date").ToString() <> "" Then Clients_In_the_Future_Date = CDate(row("Clients_In_the_Future_Date").ToString())
            If row("Clients_Contact_Status").ToString() <> "" Then Clients_Contact_Status = row("Clients_Contact_Status").ToString()

            If row("Clients_Referring_Paralegal_Firm_Client").ToString() <> "" Then Clients_Referring_Paralegal_Firm_Client = Convert.ToInt32(row("Clients_Referring_Paralegal_Firm_Client"))
            If row("Clients_Referring_Paralegal_Client").ToString() <> "" Then Clients_Referring_Paralegal_Client = Convert.ToInt32(row("Clients_Referring_Paralegal_Client"))
            If row("Clients_Referring_Law_Firm_Client").ToString() <> "" Then Clients_Referring_Law_Firm_Client = Convert.ToInt32(row("Clients_Referring_Law_Firm_Client"))
            If row("Clients_Referring_Attorney_Client").ToString() <> "" Then Clients_Referring_Attorney_Client = Convert.ToInt32(row("Clients_Referring_Attorney_Client"))
            If row("Clients_Referring_Paralegal_Firm_Receiving_Law_Firm").ToString() <> "" Then Clients_Referring_Paralegal_Firm_Receiving_Law_Firm = Convert.ToInt32(row("Clients_Referring_Paralegal_Firm_Receiving_Law_Firm"))
            If row("Clients_Referring_Paralegal_Receiving_Law_Firm").ToString() <> "" Then Clients_Referring_Paralegal_Receiving_Law_Firm = Convert.ToInt32(row("Clients_Referring_Paralegal_Receiving_Law_Firm"))
            If row("Clients_Referring_Law_Firm_Receiving_Law_Firm").ToString() <> "" Then Clients_Referring_Law_Firm_Receiving_Law_Firm = Convert.ToInt32(row("Clients_Referring_Law_Firm_Receiving_Law_Firm"))
            If row("Clients_Referring_Attorney_Receiving_Law_Firm").ToString() <> "" Then Clients_Referring_Attorney_Receiving_Law_Firm = Convert.ToInt32(row("Clients_Referring_Attorney_Receiving_Law_Firm"))
            If row("Clients_Priority_Number_Referring_Paralegal").ToString() <> "" Then Clients_Priority_Number_Referring_Paralegal = Convert.ToInt32(row("Clients_Priority_Number_Referring_Paralegal"))
            If row("Clients_Priority_Number_Manager_Referring_Paralegal").ToString() <> "" Then Clients_Priority_Number_Manager_Referring_Paralegal = Convert.ToInt32(row("Clients_Priority_Number_Manager_Referring_Paralegal"))
            If row("Clients_Priority_Number_Referring_Attorney").ToString() <> "" Then Clients_Priority_Number_Referring_Attorney = Convert.ToInt32(row("Clients_Priority_Number_Referring_Attorney"))
            If row("Clients_Priority_Number_Manager_Referring_Law_Firm").ToString() <> "" Then Clients_Priority_Number_Manager_Referring_Law_Firm = Convert.ToInt32(row("Clients_Priority_Number_Manager_Referring_Law_Firm"))
            If row("Clients_Priority_Number_Overall_Manager").ToString() <> "" Then Clients_Priority_Number_Overall_Manager = Convert.ToInt32(row("Clients_Priority_Number_Overall_Manager"))

            If row("Clients_Priority_Comments").ToString() <> "" Then Clients_Priority_Comments = row("Clients_Priority_Comments").ToString()
            If row("Clients_First_Name").ToString() <> "" Then Clients_First_Name = row("Clients_First_Name").ToString()
            If row("Clients_Last_Name").ToString() <> "" Then Clients_Last_Name = row("Clients_Last_Name").ToString()
            If row("Clients_Full_Name").ToString() <> "" Then Clients_Full_Name = row("Clients_Full_Name").ToString()
            If row("Clients_Sort_Name").ToString() <> "" Then Clients_Sort_Name = row("Clients_Sort_Name").ToString()
            If row("Clients_Salutation").ToString() <> "" Then Clients_Salutation = row("Clients_Salutation").ToString()
            If row("Clients_Address").ToString() <> "" Then Clients_Address = row("Clients_Address").ToString()
            If row("Clients_City").ToString() <> "" Then Clients_City = row("Clients_City").ToString()
            If row("Clients_County_FIPS").ToString() <> "" Then Clients_County_FIPS = row("Clients_County_FIPS").ToString()
            If row("Clients_County").ToString() <> "" Then Clients_County = row("Clients_County").ToString()
            If row("Clients_MSA_Code").ToString() <> "" Then Clients_MSA_Code = row("Clients_MSA_Code").ToString()
            If row("Clients_State_Two_Character_USPS_Code").ToString() <> "" Then Clients_State_Two_Character_USPS_Code = row("Clients_State_Two_Character_USPS_Code").ToString()
            If row("Clients_State").ToString() <> "" Then Clients_State = row("Clients_State").ToString()
            If row("Clients_Zip_Code").ToString() <> "" Then Clients_Zip_Code = row("Clients_Zip_Code").ToString()

            If row("Clients_Cities_ID").ToString() <> "" Then Clients_Cities_ID = Convert.ToInt32(row("Clients_Cities_ID"))

            If row("Clients_Sex").ToString() <> "" Then Clients_Sex = row("Clients_Sex").ToString()
            If row("Clients_Social_Security_Number").ToString() <> "" Then Clients_Social_Security_Number = row("Clients_Social_Security_Number").ToString()
            If row("Clients_Date_of_Birth").ToString() <> "" Then Clients_Date_of_Birth = CDate(row("Clients_Date_of_Birth").ToString())
            If row("Clients_Education").ToString() <> "" Then Clients_Education = row("Clients_Education").ToString()
            If row("Clients_Time_Zone").ToString() <> "" Then Clients_Time_Zone = row("Clients_Time_Zone").ToString()
            If row("Clients_Telephone_Number").ToString() <> "" Then Clients_Telephone_Number = row("Clients_Telephone_Number").ToString()
            If row("Clients_Telephone_Number_Home").ToString() <> "" Then Clients_Telephone_Number_Home = row("Clients_Telephone_Number_Home").ToString()
            If row("Clients_Telephone_Number_Work").ToString() <> "" Then Clients_Telephone_Number_Work = row("Clients_Telephone_Number_Work").ToString()
            If row("Clients_Telephone_Number_Work_Ext").ToString() <> "" Then Clients_Telephone_Number_Work_Ext = row("Clients_Telephone_Number_Work_Ext").ToString()
            If row("Clients_Telephone_Number_Mobile").ToString() <> "" Then Clients_Telephone_Number_Mobile = row("Clients_Telephone_Number_Mobile").ToString()
            If row("Clients_Telephone_Number_Fax").ToString() <> "" Then Clients_Telephone_Number_Fax = row("Clients_Telephone_Number_Fax").ToString()
            If row("Clients_Telephone_Number_Best_Time_To_Call").ToString() <> "" Then Clients_Telephone_Number_Best_Time_To_Call = row("Clients_Telephone_Number_Best_Time_To_Call").ToString()
            If row("Clients_Email_Address").ToString() <> "" Then Clients_Email_Address = row("Clients_Email_Address").ToString()
            If row("Clients_Email_Addresses_Other").ToString() <> "" Then Clients_Email_Addresses_Other = row("Clients_Email_Addresses_Other").ToString()
            If row("Clients_Email_Initial_Followup_YN").ToString() <> "" Then Clients_Email_Initial_Followup_YN = row("Clients_Email_Initial_Followup_YN").ToString()

            If row("Clients_Email_Initial_Followup_Email_Number").ToString() <> "" Then Clients_Email_Initial_Followup_Email_Number = Convert.ToInt32(row("Clients_Email_Initial_Followup_Email_Number"))

            If row("Clients_Email_Initial_Followup_YN").ToString() <> "" Then Clients_Email_Initial_Email_Text = row("Clients_Email_Initial_Followup_YN").ToString()
            If row("Clients_Email_Reminder_YN").ToString() <> "" Then Clients_Email_Reminder_YN = row("Clients_Email_Reminder_YN").ToString()
            If row("Clients_Email_Reminder").ToString() <> "" Then Clients_Email_Reminder = row("Clients_Email_Reminder").ToString()
            If row("Clients_Initial_Message_from_Client").ToString() <> "" Then Clients_Initial_Message_from_Client = row("Clients_Initial_Message_from_Client").ToString()
            If row("Clients_File_Server_Folder_Created").ToString() <> "" Then Clients_File_Server_Folder_Created = row("Clients_File_Server_Folder_Created").ToString()
            If row("Clients_File_Server_Folder_Name").ToString() <> "" Then Clients_File_Server_Folder_Name = row("Clients_File_Server_Folder_Name").ToString()
            If row("Clients_Source_Search_Engine").ToString() <> "" Then Clients_Source_Search_Engine = row("Clients_Source_Search_Engine").ToString()
            If row("Clients_Source_Search_Term_Used").ToString() <> "" Then Clients_Source_Search_Term_Used = row("Clients_Source_Search_Term_Used").ToString()
            If row("Clients_IP_Address").ToString() <> "" Then Clients_IP_Address = row("Clients_IP_Address").ToString()
            If row("Clients_Web_Site").ToString() <> "" Then Clients_Web_Site = row("Clients_Web_Site").ToString()
            If row("Clients_Source_Web_Page_CIF_Was_Submitted_From").ToString() <> "" Then Clients_Source_Web_Page_CIF_Was_Submitted_From = row("Clients_Source_Web_Page_CIF_Was_Submitted_From").ToString()
            If row("Clients_Referring_URL").ToString() <> "" Then Clients_Referring_URL = row("Clients_Referring_URL").ToString()
            If row("Clients_Source_Traffic_Source").ToString() <> "" Then Clients_Source_Traffic_Source = row("Clients_Source_Traffic_Source").ToString()
            If row("Clients_Source_of_Lead").ToString() <> "" Then Clients_Source_of_Lead = row("Clients_Source_of_Lead").ToString()

            If row("Clients_Source_Time_Spent_on_Web_Site_Until_CIF_Submission").ToString() <> "" Then Clients_Source_Time_Spent_on_Web_Site_Until_CIF_Submission = Convert.ToInt32(row("Clients_Source_Time_Spent_on_Web_Site_Until_CIF_Submission"))
            If row("Clients_Strategic_Partner").ToString() <> "" Then Clients_Strategic_Partner = Convert.ToInt32(row("Clients_Strategic_Partner"))

            If row("Clients_800_TN_Source_is_an_800_Telephone_Number").ToString() <> "" Then Clients_800_TN_Source_is_an_800_Telephone_Number = row("Clients_800_TN_Source_is_an_800_Telephone_Number").ToString()

            If row("Clients_800_TN_800_Telephone_Service").ToString() <> "" Then Clients_800_TN_800_Telephone_Service = Convert.ToInt32(row("Clients_800_TN_800_Telephone_Service"))
            If row("Clients_800_TN_800_Telephone_Number").ToString() <> "" Then Clients_800_TN_800_Telephone_Number = Convert.ToInt32(row("Clients_800_TN_800_Telephone_Number"))

            If row("Clients_800_TN_Owner_of_800_Telephone_Number_1").ToString() <> "" Then Clients_800_TN_Owner_of_800_Telephone_Number_1 = row("Clients_800_TN_Owner_of_800_Telephone_Number_1").ToString()
            If row("Clients_800_TN_Owner_of_800_Telephone_Number_2").ToString() <> "" Then Clients_800_TN_Owner_of_800_Telephone_Number_2 = row("Clients_800_TN_Owner_of_800_Telephone_Number_2").ToString()
            If row("Clients_800_TN_Caller_ID").ToString() <> "" Then Clients_800_TN_Caller_ID = row("Clients_800_TN_Caller_ID").ToString()
            If row("Clients_800_TN_Caller_Name").ToString() <> "" Then Clients_800_TN_Caller_Name = row("Clients_800_TN_Caller_Name").ToString()
            If row("Clients_800_TN_Originating_Number").ToString() <> "" Then Clients_800_TN_Originating_Number = row("Clients_800_TN_Originating_Number").ToString()
            If row("Clients_800_TN_Originating_Place").ToString() <> "" Then Clients_800_TN_Originating_Place = row("Clients_800_TN_Originating_Place").ToString()
            If row("Clients_800_TN_Destination_Number").ToString() <> "" Then Clients_800_TN_Destination_Number = row("Clients_800_TN_Destination_Number").ToString()
            If row("Clients_800_TN_Destination_Place").ToString() <> "" Then Clients_800_TN_Destination_Place = row("Clients_800_TN_Destination_Place").ToString()

            If row("Clients_800_TN_Length_of_Call").ToString() <> "" Then Clients_800_TN_Length_of_Call = Convert.ToInt32(row("Clients_800_TN_Length_of_Call"))

            If row("Clients_800_TN_Cost_of_Call").ToString() <> "" Then Clients_800_TN_Cost_of_Call = row("Clients_800_TN_Cost_of_Call").ToString()
            If row("Clients_800_TN_Charge_Date").ToString() <> "" Then Clients_800_TN_Charge_Date = CDate(row("Clients_800_TN_Charge_Date"))
            If row("Clients_800_TN_Date_Time_of_Telephone_Call").ToString() <> "" Then Clients_800_TN_Date_Time_of_Telephone_Call = CDate(row("Clients_800_TN_Date_Time_of_Telephone_Call"))
            If row("Clients_CIF_IAB_Ad_Unit_Name").ToString() <> "" Then Clients_CIF_IAB_Ad_Unit_Name = row("Clients_CIF_IAB_Ad_Unit_Name").ToString()
            If row("Clients_CIF_Design_Name").ToString() <> "" Then Clients_CIF_Design_Name = row("Clients_CIF_Design_Name").ToString()
            If row("Clients_CIF_Raw_Form_Data").ToString() <> "" Then Clients_CIF_Raw_Form_Data = row("Clients_CIF_Raw_Form_Data").ToString()

            If row("Clients_Case_Evaluation_SQM_ID").ToString() <> "" Then Clients_Case_Evaluation_SQM_ID = Convert.ToInt32(row("Clients_Case_Evaluation_SQM_ID"))

            If row("Clients_Case_Evaluation_SQM_ID_Formatted").ToString() <> "" Then Clients_Case_Evaluation_SQM_ID_Formatted = row("Clients_Case_Evaluation_SQM_ID_Formatted").ToString()
            If row("Clients_Case_Evaluation_Liability").ToString() <> "" Then Clients_Case_Evaluation_Liability = row("Clients_Case_Evaluation_Liability").ToString()
            If row("Clients_Case_Evaluation_Causation").ToString() <> "" Then Clients_Case_Evaluation_Causation = row("Clients_Case_Evaluation_Causation").ToString()
            If row("Clients_Case_Evaluation_Potential_Defendants").ToString() <> "" Then Clients_Case_Evaluation_Potential_Defendants = row("Clients_Case_Evaluation_Potential_Defendants").ToString()
            If row("Clients_Case_Evaluation_Insurance_Policies").ToString() <> "" Then Clients_Case_Evaluation_Insurance_Policies = row("Clients_Case_Evaluation_Insurance_Policies").ToString()
            If row("Clients_Case_Evaluation_Counterclaims").ToString() <> "" Then Clients_Case_Evaluation_Counterclaims = row("Clients_Case_Evaluation_Counterclaims").ToString()
            If row("Clients_Case_Evaluation_Damages_Bodily_Injury_Text").ToString() <> "" Then Clients_Case_Evaluation_Damages_Bodily_Injury_Text = row("Clients_Case_Evaluation_Damages_Bodily_Injury_Text").ToString()
            If row("Clients_Case_Evaluation_Damages_Bodily_Injury_Amount").ToString() <> "" Then Clients_Case_Evaluation_Damages_Bodily_Injury_Amount = row("Clients_Case_Evaluation_Damages_Bodily_Injury_Amount").ToString()
            If row("Clients_Case_Evaluation_Damages_Other_Personal_Injury_Text").ToString() <> "" Then Clients_Case_Evaluation_Damages_Other_Personal_Injury_Text = row("Clients_Case_Evaluation_Damages_Other_Personal_Injury_Text").ToString()
            If row("Clients_Case_Evaluation_Damages_Other_Personal_Injury_Amount").ToString() <> "" Then Clients_Case_Evaluation_Damages_Other_Personal_Injury_Amount = row("Clients_Case_Evaluation_Damages_Other_Personal_Injury_Amount").ToString()
            If row("Clients_Case_Evaluation_Damages_Medical_Expenses_Text").ToString() <> "" Then Clients_Case_Evaluation_Damages_Medical_Expenses_Text = row("Clients_Case_Evaluation_Damages_Medical_Expenses_Text").ToString()
            If row("Clients_Case_Evaluation_Damages_Medical_Expenses_Amount").ToString() <> "" Then Clients_Case_Evaluation_Damages_Medical_Expenses_Amount = row("Clients_Case_Evaluation_Damages_Medical_Expenses_Amount").ToString()
            If row("Clients_Case_Evaluation_Damages_Other_OoP_Expenses_Text").ToString() <> "" Then Clients_Case_Evaluation_Damages_Other_OoP_Expenses_Text = row("Clients_Case_Evaluation_Damages_Other_OoP_Expenses_Text").ToString()
            If row("Clients_Case_Evaluation_Damages_Other_OoP_Expenses_Amount").ToString() <> "" Then Clients_Case_Evaluation_Damages_Other_OoP_Expenses_Amount = row("Clients_Case_Evaluation_Damages_Other_OoP_Expenses_Amount").ToString()
            If row("Clients_Case_Evaluation_Damages_Lost_Wages_Text").ToString() <> "" Then Clients_Case_Evaluation_Damages_Lost_Wages_Text = row("Clients_Case_Evaluation_Damages_Lost_Wages_Text").ToString()
            If row("Clients_Case_Evaluation_Damages_Lost_Wages_Amount").ToString() <> "" Then Clients_Case_Evaluation_Damages_Lost_Wages_Amount = row("Clients_Case_Evaluation_Damages_Lost_Wages_Amount").ToString()
            If row("Clients_Case_Evaluation_Damages_Lost_Income_Text").ToString() <> "" Then Clients_Case_Evaluation_Damages_Lost_Income_Text = row("Clients_Case_Evaluation_Damages_Lost_Income_Text").ToString()
            If row("Clients_Case_Evaluation_Damages_Lost_Income_Amount").ToString() <> "" Then Clients_Case_Evaluation_Damages_Lost_Income_Amount = row("Clients_Case_Evaluation_Damages_Lost_Income_Amount").ToString()
            If row("Clients_Case_Evaluation_Damages_Pain_and_Suffering_Text").ToString() <> "" Then Clients_Case_Evaluation_Damages_Pain_and_Suffering_Text = row("Clients_Case_Evaluation_Damages_Pain_and_Suffering_Text").ToString()
            If row("Clients_Case_Evaluation_Damages_Pain_and_Suffering_Amount").ToString() <> "" Then Clients_Case_Evaluation_Damages_Pain_and_Suffering_Amount = row("Clients_Case_Evaluation_Damages_Pain_and_Suffering_Amount").ToString()
            If row("Clients_Case_Evaluation_Damages_Emotional_Damages_Text").ToString() <> "" Then Clients_Case_Evaluation_Damages_Emotional_Damages_Text = row("Clients_Case_Evaluation_Damages_Emotional_Damages_Text").ToString()
            If row("Clients_Case_Evaluation_Damages_Emotional_Damages_Amount").ToString() <> "" Then Clients_Case_Evaluation_Damages_Emotional_Damages_Amount = row("Clients_Case_Evaluation_Damages_Emotional_Damages_Amount").ToString()
            If row("Clients_Case_Evaluation_Damages_Loss_of_Consortium_Text").ToString() <> "" Then Clients_Case_Evaluation_Damages_Loss_of_Consortium_Text = row("Clients_Case_Evaluation_Damages_Loss_of_Consortium_Text").ToString()
            If row("Clients_Case_Evaluation_Damages_Loss_of_Consortium_Amount").ToString() <> "" Then Clients_Case_Evaluation_Damages_Loss_of_Consortium_Amount = row("Clients_Case_Evaluation_Damages_Loss_of_Consortium_Amount").ToString()
            If row("Clients_Case_Evaluation_Damages_Loss_of_Companionship_Text").ToString() <> "" Then Clients_Case_Evaluation_Damages_Loss_of_Companionship_Text = row("Clients_Case_Evaluation_Damages_Loss_of_Companionship_Text").ToString()
            If row("Clients_Case_Evaluation_Damages_Loss_of_Companionship_Amount").ToString() <> "" Then Clients_Case_Evaluation_Damages_Loss_of_Companionship_Amount = row("Clients_Case_Evaluation_Damages_Loss_of_Companionship_Amount").ToString()
            If row("Clients_Case_Evaluation_Damages_Miscellaneous_and_Other_Text").ToString() <> "" Then Clients_Case_Evaluation_Damages_Miscellaneous_and_Other_Text = row("Clients_Case_Evaluation_Damages_Miscellaneous_and_Other_Text").ToString()
            If row("Clients_Case_Evaluation_Damages_Miscellaneous_and_Other_Amount").ToString() <> "" Then Clients_Case_Evaluation_Damages_Miscellaneous_and_Other_Amount = row("Clients_Case_Evaluation_Damages_Miscellaneous_and_Other_Amount").ToString()
            If row("Clients_Case_Evaluation_Damages_Punitive_Damages_Text").ToString() <> "" Then Clients_Case_Evaluation_Damages_Punitive_Damages_Text = row("Clients_Case_Evaluation_Damages_Punitive_Damages_Text").ToString()
            If row("Clients_Case_Evaluation_Damages_Punitive_Damages_Amount").ToString() <> "" Then Clients_Case_Evaluation_Damages_Punitive_Damages_Amount = row("Clients_Case_Evaluation_Damages_Punitive_Damages_Amount").ToString()
            If row("Clients_Case_Evaluation_Damages_Estimated_Value").ToString() <> "" Then Clients_Case_Evaluation_Damages_Estimated_Value = row("Clients_Case_Evaluation_Damages_Estimated_Value").ToString()
            If row("Clients_Case_Evaluation_Damages_Estimated_Value_Amount").ToString() <> "" Then Clients_Case_Evaluation_Damages_Estimated_Value_Amount = row("Clients_Case_Evaluation_Damages_Estimated_Value_Amount").ToString()
            If row("Clients_Case_Evaluation_Damages_Total_Text").ToString() <> "" Then Clients_Case_Evaluation_Damages_Total_Text = row("Clients_Case_Evaluation_Damages_Total_Text").ToString()
            If row("Clients_Case_Evaluation_Damages_Total_Amount").ToString() <> "" Then Clients_Case_Evaluation_Damages_Total_Amount = row("Clients_Case_Evaluation_Damages_Total_Amount").ToString()

            If row("Clients_ToC_MC_ID").ToString() <> "" Then Clients_ToC_MC_ID = Convert.ToInt32(row("Clients_ToC_MC_ID"))

            If row("Clients_ToC_MC_ID_Formatted").ToString() <> "" Then Clients_ToC_MC_ID_Formatted = row("Clients_ToC_MC_ID_Formatted").ToString()
            If row("Clients_ToC_MC_Main_Category").ToString() <> "" Then Clients_ToC_MC_Main_Category = row("Clients_ToC_MC_Main_Category").ToString()
            If row("Clients_ToC_MC_Sort_Name").ToString() <> "" Then Clients_ToC_MC_Sort_Name = row("Clients_ToC_MC_Sort_Name").ToString()

            If row("Clients_ToC_ID").ToString() <> "" Then Clients_ToC_ID = Convert.ToInt32(row("Clients_ToC_ID"))

            If row("Clients_ToC_ID_Formatted").ToString() <> "" Then Clients_ToC_ID_Formatted = row("Clients_ToC_ID_Formatted").ToString()
            If row("Clients_ToC_Type_of_Case").ToString() <> "" Then Clients_ToC_Type_of_Case = row("Clients_ToC_Type_of_Case").ToString()
            If row("Clients_ToC_Sort_Name").ToString() <> "" Then Clients_ToC_Sort_Name = row("Clients_ToC_Sort_Name").ToString()
            If row("Clients_Type_of_Damage").ToString() <> "" Then Clients_Type_of_Damage = row("Clients_Type_of_Damage").ToString()

            If row("Clients_Level_of_Damages").ToString() <> "" Then Clients_Level_of_Damages = Convert.ToInt32(row("Clients_Level_of_Damages"))

            If row("Clients_Lawsuit_Filed").ToString() <> "" Then Clients_Lawsuit_Filed = row("Clients_Lawsuit_Filed").ToString()
            If row("Clients_Lawsuit_Date_Filed").ToString() <> "" Then Clients_Lawsuit_Date_Filed = CDate(row("Clients_Lawsuit_Date_Filed"))
            If row("Clients_Lawsuit_Courthouse").ToString() <> "" Then Clients_Lawsuit_Courthouse = row("Clients_Lawsuit_Courthouse").ToString()
            If row("Clients_Lawsuit_Courthouse_Telephone_Number_Clerks_Office").ToString() <> "" Then Clients_Lawsuit_Courthouse_Telephone_Number_Clerks_Office = row("Clients_Lawsuit_Courthouse_Telephone_Number_Clerks_Office").ToString()
            If row("Clients_Lawsuit_Courthouse_Electronic_Access_to_Docket").ToString() <> "" Then Clients_Lawsuit_Courthouse_Electronic_Access_to_Docket = row("Clients_Lawsuit_Courthouse_Electronic_Access_to_Docket").ToString()
            If row("Clients_Lawsuit_Case_Number").ToString() <> "" Then Clients_Lawsuit_Case_Number = row("Clients_Lawsuit_Case_Number").ToString()
            If row("Clients_Lawsuit_Caption").ToString() <> "" Then Clients_Lawsuit_Caption = row("Clients_Lawsuit_Caption").ToString()
            If row("Clients_Next_Step").ToString() <> "" Then Clients_Next_Step = row("Clients_Next_Step").ToString()
            If row("Clients_Comments_One_Line_Summary").ToString() <> "" Then Clients_Comments_One_Line_Summary = row("Clients_Comments_One_Line_Summary").ToString()
            If row("Clients_Comments_Overall").ToString() <> "" Then Clients_Comments_Overall = row("Clients_Comments_Overall").ToString()
            If row("Clients_Contact_History").ToString() <> "" Then Clients_Contact_History = row("Clients_Contact_History").ToString()
            If row("Clients_Description_of_the_Case").ToString() <> "" Then Clients_Description_of_the_Case = row("Clients_Description_of_the_Case").ToString()
            If row("Clients_Case_Writeup").ToString() <> "" Then Clients_Case_Writeup = row("Clients_Case_Writeup").ToString()
            If row("Clients_Case_Writeup_Disguised").ToString() <> "" Then Clients_Case_Writeup_Disguised = row("Clients_Case_Writeup_Disguised").ToString()
            If row("Clients_To_Whom_Should_the_Case_be_Referred").ToString() <> "" Then Clients_To_Whom_Should_the_Case_be_Referred = row("Clients_To_Whom_Should_the_Case_be_Referred").ToString()
            If row("Clients_Backup_Has_Client_Record_Been_Deleted_YN").ToString() <> "" Then Clients_Backup_Has_Client_Record_Been_Deleted_YN = row("Clients_Backup_Has_Client_Record_Been_Deleted_YN").ToString()

            If row("Clients_Who_Deleted_the_Client_Record_ID").ToString() <> "" Then Clients_Who_Deleted_the_Client_Record_ID = Convert.ToInt32(row("Clients_Who_Deleted_the_Client_Record_ID"))

            If row("Clients_Who_Deleted_the_Client_Record_ID_Formatted").ToString() <> "" Then Clients_Who_Deleted_the_Client_Record_ID_Formatted = row("Clients_Who_Deleted_the_Client_Record_ID_Formatted").ToString()
            If row("Clients_Who_Deleted_the_Client_Record").ToString() <> "" Then Clients_Who_Deleted_the_Client_Record = row("Clients_Who_Deleted_the_Client_Record").ToString()
            If row("Clients_When_Was_This_Client_Record_Deleted").ToString() <> "" Then Clients_When_Was_This_Client_Record_Deleted = CDate(row("Clients_When_Was_This_Client_Record_Deleted"))
            If row("Clients_How_Was_This_Client_Record_Deleted").ToString() <> "" Then Clients_How_Was_This_Client_Record_Deleted = row("Clients_How_Was_This_Client_Record_Deleted").ToString()
            If row("Clients_Deleted_Microsoft_Access_Form_Number").ToString() <> "" Then Clients_Deleted_Microsoft_Access_Form_Number = row("Clients_Deleted_Microsoft_Access_Form_Number").ToString()
            If row("Clients_Date_Time_Created").ToString() <> "" Then Clients_Date_Time_Created = CDate(row("Clients_Date_Time_Created"))
            If row("Clients_Referral_History_Temp").ToString() <> "" Then Clients_Referral_History_Temp = row("Clients_Referral_History_Temp").ToString()

        End If
    End Sub

#End Region
End Class


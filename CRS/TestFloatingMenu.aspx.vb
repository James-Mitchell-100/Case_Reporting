Imports System.Drawing
Imports CRS_BLL
Imports CRS_Common

Public Class TestFloatingMenu
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                'Load Text for Floating Menu
                Dim oCaseReporting_Labels_Tooltips_Floaters_Texts As New CaseReporting_Labels_Tooltips_Floaters_Texts
                oCaseReporting_Labels_Tooltips_Floaters_Texts.GetCaseReportingLabelsTooltipsFloatersTexts("LFP_Type_of_Case")

                '
                ' Floating Text
                '
                lblFloatingMenuText.Text = ""
                If oCaseReporting_Labels_Tooltips_Floaters_Texts.Labels_Tooltips_Floaters_Texts.Count > 0 Then
                    For Each oText As CaseReporting_Labels_Tooltips_Floaters_Text In oCaseReporting_Labels_Tooltips_Floaters_Texts.Labels_Tooltips_Floaters_Texts
                        'Set the text
                        lblFloatingMenuText.Text = lblFloatingMenuText.Text & oText.Labels_Tooltips_Floaters_Text_Text
                    Next
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

End Class
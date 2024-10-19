
'Imports Microsoft.Ajax.Utilities
'Imports Microsoft.AspNet.Identity.EntityFramework
Imports ApplicationDbContext
Imports ApplicationUser
Imports App_seedling_Default
Imports System.Data
Imports System
Imports System.Collections.Generic
Imports System.Security.Claims
Imports System.Security.Principal
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data.Entity.Core.Common.EntitySql
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text
Imports System.IO


Partial Class App_seedling_Default
    Inherits System.Web.UI.Page
    Dim dtCalendar As DataTable
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If (IsPostBack) Then



        End If

        Dim Params_Calendar() As Object = {1}
        dtCalendar = Stond.GetDt(ConfigurationManager.AppSettings("ConnectionString"), "LK_Calendar_Type_Get", Params_Calendar)
        'If Functions.IsDBEmpty(dtCalendar) = False Then
        If Not (IsPostBack) Then
                ddlCalendar_Type.DataSource = dtCalendar
                ddlCalendar_Type.DataTextField = "Description"
            ddlCalendar_Type.DataValueField = "Calendar_Type_Key"
            ddlCalendar_Type.DataBind()
                ddlCalendar_Type.Items.Insert(0, New ListItem("Select a Calendar Type", "0"))
            End If
        'End If


    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As System.EventArgs) Handles btnSubmit.Click
        Page.Validate()
        If Page.IsValid Then
            Dim Params_Save() As Object = {2, 0, ddlCalendar_Type.SelectedValue, txtDate.Text, txtDescription.Text, txtLocation.Text}

            Stond.GetDt(ConfigurationManager.AppSettings("ConnectionString"), "usp_Calendar_Maint", Params_Save)
            Params_Save = Nothing

            'SqlDataSource1.Update()
        End If

    End Sub

End Class


Imports Microsoft.Ajax.Utilities

Partial Class App_seedling_Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If (IsPostBack) Then

        End If
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As System.EventArgs) Handles btnSubmit.Click
        Page.Validate()
        If Page.IsValid Then
            Dim Params_Save() As Object = {2, 0, txtItem_Name.Text, txtPurchase_Location.Text, 0, txtItem_Description.Text, txtPurchase_Price.Text, IIf(txtPurchase_Date.Text = "", System.DBNull.Value, txtPurchase_Date.Text)}

            Stond.GetDt(ConfigurationManager.AppSettings("ConnectionString"), "dbo.usp_Grocery_Maint", Params_Save)
            Params_Save = Nothing

            SqlDataSource1.Update()
        End If

    End Sub

End Class


Imports System.Data
Imports System.Globalization
Imports System.Reflection.Emit

Partial Class _Default
    Inherits Page

    Dim dtCalendar As DataTable
    Dim _hideEmptyWeek As Boolean

    'Bind data to calendar
    Protected Sub Calendar1_Prerender(ByVal sender As Object, ByVal e As EventArgs) Handles calendar1.PreRender

        If Not (dtCalendar Is Nothing) Then
            dtCalendar.Clear()
        End If

        Dim Params_Calendar() As Object = {1}
        dtCalendar = Stond.GetDt(ConfigurationManager.AppSettings("ConnectionString"), "dbo.usp_Calendar_Maint", Params_Calendar)

        dtCalendar.Dispose()
    End Sub

    'Post item on specific day from database
    Protected Sub Calendar_DayRender(ByVal sender As Object, ByVal e As DayRenderEventArgs)
        If e.Day.IsOtherMonth Then
            e.Cell.Text = String.Empty

            '' Hide first week if empty
            If e.Day.Date = e.Day.Date.AddDays(-e.Day.Date.Day + 1).AddMonths(1).AddDays(-7) Then ' If this date is a full week before next month
                _hideEmptyWeek = True
            End If

            '' Hide last week if empty
            If e.Day.Date.DayOfWeek = DayOfWeek.Sunday And e.Day.Date.Day < 7 Then ' If this is the first Sunday of next month
                _hideEmptyWeek = True
            End If

            '' Hide cell if we are in an empty week
            If _hideEmptyWeek = True Then
                e.Cell.Visible = False
            End If
        Else
            _hideEmptyWeek = False
        End If

        If e.Day.IsWeekend Then
            e.Cell.BackColor = System.Drawing.Color.Gray
        End If

        'Dim Activity_Key As String
        Dim Activity_Count As Integer

        Activity_Count = dtCalendar.Rows.Count - 1

        For l As Integer = 0 To Activity_Count
            If e.Day.Date = CDate(dtCalendar.Rows(l).Item("Date")).ToString("yyyy-MM-dd") Then

                Dim Calendar_Type As String = dtCalendar.Rows(l).Item("Calendar_Type").ToString
                Dim Description As String = dtCalendar.Rows(l).Item("Description").ToString
                Dim LK_Activity_Key As String = dtCalendar.Rows(l).Item("Calendar_Type").ToString

                '        If cbView_All.Checked = True Then
                '            cbAE.Checked = False
                '            cbEL.Checked = False
                '            cbAS.Checked = False
                '            cbCC.Checked = False
                '            cbCP.Checked = False
                '            cbDV.Checked = False
                '            cbELS.Checked = False
                '            cbHA.Checked = False
                '            cbLE.Checked = False
                '            cbPSFL.Checked = False
                '            cbSTEM.Checked = False
                '            cbSI.Checked = False
                '            cbTT.Checked = False
                '            cbWR.Checked = False
                '            e.Cell.Controls.Add(New LiteralControl("<br/>" + Activity_Name + " " + Activity_Time_Frame))
                '        End If

                '        If cbAE.Checked = True Then
                If LK_Activity_Key = 1 Then
                    e.Cell.Controls.Add(New LiteralControl("<br/>" + Description))
                End If
                '        End If

                '        If cbEL.Checked = True Then
                If LK_Activity_Key = 2 Then
                    e.Cell.Controls.Add(New LiteralControl("<br/>" + Description))
                End If
                '        End If

                '        If cbAS.Checked = True Then
                '            If LK_Activity_Key = 3 Then
                '                e.Cell.Controls.Add(New LiteralControl("<br/>" + Activity_Name + " " + Activity_Time_Frame))
                '            End If
                '        End If

                '        If cbCC.Checked = True Then
                '            If LK_Activity_Key = 4 Then
                '                e.Cell.Controls.Add(New LiteralControl("<br/>" + Activity_Name + " " + Activity_Time_Frame))
                '            End If
                '        End If

                '        If cbCP.Checked = True Then
                '            If LK_Activity_Key = 5 Then
                '                e.Cell.Controls.Add(New LiteralControl("<br/>" + Activity_Name + " " + Activity_Time_Frame))
                '            End If
                '        End If

                '        If cbDV.Checked = True Then
                '            If LK_Activity_Key = 6 Then
                '                e.Cell.Controls.Add(New LiteralControl("<br/>" + Activity_Name + " " + Activity_Time_Frame))
                '            End If
                '        End If

                '        If cbELS.Checked = True Then
                '            If LK_Activity_Key = 7 Then
                '                e.Cell.Controls.Add(New LiteralControl("<br/>" + Activity_Name + " " + Activity_Time_Frame))
                '            End If
                '        End If

                '        If cbHA.Checked = True Then
                '            If LK_Activity_Key = 8 Then
                '                e.Cell.Controls.Add(New LiteralControl("<br/>" + Activity_Name + " " + Activity_Time_Frame))
                '            End If
                '        End If

                '        If cbLE.Checked = True Then
                '            If LK_Activity_Key = 9 Then
                '                e.Cell.Controls.Add(New LiteralControl("<br/>" + Activity_Name + " " + Activity_Time_Frame))
                '            End If
                '        End If

                '        If cbPSFL.Checked = True Then
                '            If LK_Activity_Key = 10 Then
                '                e.Cell.Controls.Add(New LiteralControl("<br/>" + Activity_Name + " " + Activity_Time_Frame))
                '            End If
                '        End If

                '        If cbSTEM.Checked = True Then
                '            If LK_Activity_Key = 11 Then
                '                e.Cell.Controls.Add(New LiteralControl("<br/>" + Activity_Name + " " + Activity_Time_Frame))
                '            End If
                '        End If

                '        If cbSI.Checked = True Then
                '            If LK_Activity_Key = 12 Then
                '                e.Cell.Controls.Add(New LiteralControl("<br/>" + Activity_Name + " " + Activity_Time_Frame))
                '            End If
                '        End If

                '        If cbTT.Checked = True Then
                '            If LK_Activity_Key = 13 Then
                '                e.Cell.Controls.Add(New LiteralControl("<br/>" + Activity_Name + " " + Activity_Time_Frame))
                '            End If
                '        End If

                '        If cbWR.Checked = True Then
                '            If LK_Activity_Key = 14 Then
                '                e.Cell.Controls.Add(New LiteralControl("<br/>" + Activity_Name + " " + Activity_Time_Frame))
                '            End If
                '        End If

                Calendar_Type = dtCalendar.Rows(l).Item("Calendar_Type").ToString
                If Calendar_Type = 1 Then
                    e.Cell.BackColor = System.Drawing.Color.DarkSeaGreen
                    e.Cell.ToolTip = dtCalendar.Rows(l).Item("Description").ToString
                End If

                If Calendar_Type = 2 Then
                    e.Cell.ForeColor = System.Drawing.Color.AntiqueWhite
                    e.Cell.ToolTip = dtCalendar.Rows(l).Item("Description").ToString
                End If
                '        If Activity_Key = 3 Then
                '            e.Cell.ForeColor = System.Drawing.Color.Black
                '            e.Cell.ToolTip = dtCalendar.Rows(l).Item("Description").ToString
                '        End If
                '        If Activity_Key = 4 Then
                '            e.Cell.ForeColor = System.Drawing.Color.Black
                '            e.Cell.ToolTip = dtCalendar.Rows(l).Item("Description").ToString
                '        End If
                '        If Activity_Key = 5 Then
                '            e.Cell.ForeColor = System.Drawing.Color.Black
                '            e.Cell.ToolTip = dtCalendar.Rows(l).Item("Description").ToString
                '        End If

                '        If Activity_Key = 6 Then
                '            e.Cell.ForeColor = System.Drawing.Color.Black
                '            e.Cell.ToolTip = dtCalendar.Rows(l).Item("Description").ToString
                '        End If
                '        If Activity_Key = 7 Then
                '            e.Cell.ForeColor = System.Drawing.Color.Black
                '            e.Cell.ToolTip = dtCalendar.Rows(l).Item("Description").ToString
                '        End If
                '        If Activity_Key = 8 Then
                '            e.Cell.ForeColor = System.Drawing.Color.Black
                '            e.Cell.ToolTip = dtCalendar.Rows(l).Item("Description").ToString
                '        End If
                '        If Activity_Key = 9 Then
                '            e.Cell.ForeColor = System.Drawing.Color.Black
                '            e.Cell.ToolTip = dtCalendar.Rows(l).Item("Description").ToString
                '        End If

                '        If Activity_Key = 10 Then
                '            e.Cell.ForeColor = System.Drawing.Color.Black
                '            e.Cell.ToolTip = dtCalendar.Rows(l).Item("Description").ToString
                '        End If

                '        If Activity_Key = 11 Then
                '            e.Cell.ForeColor = System.Drawing.Color.Black
                '            e.Cell.ToolTip = dtCalendar.Rows(l).Item("Description").ToString
                '        End If

                '        If Activity_Key = 12 Then
                '            e.Cell.ForeColor = System.Drawing.Color.Black
                '            e.Cell.ToolTip = dtCalendar.Rows(l).Item("Description").ToString
                '        End If
                '        If Activity_Key = 13 Then
                '            e.Cell.ForeColor = System.Drawing.Color.Black
                '            e.Cell.ToolTip = dtCalendar.Rows(l).Item("Description").ToString
                '        End If
                '        If Activity_Key = 14 Then
                '            e.Cell.ForeColor = System.Drawing.Color.Black
                '            e.Cell.ToolTip = dtCalendar.Rows(l).Item("Description").ToString
                '        End If

                '        If Activity_Key = 14 Then
                '            e.Cell.ForeColor = System.Drawing.Color.Black
                '            e.Cell.ToolTip = dtCalendar.Rows(l).Item("Description").ToString
                '        End If
            End If
        Next

    End Sub

End Class
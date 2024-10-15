Imports System
Imports System.Data
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic

Public Class Stond

    'Returns a dataTable from Store Precedure
    Public Shared Function GetDt(ByVal cnnObjStr, ByVal strCommand, Optional ByVal aryParameters = Nothing) As DataTable
        Dim connStr As System.Data.SqlClient.SqlConnection
        connStr = New System.Data.SqlClient.SqlConnection

        connStr.ConnectionString = cnnObjStr

        Dim cmdGetDS As System.Data.SqlClient.SqlCommand
        cmdGetDS = New System.Data.SqlClient.SqlCommand

        Dim Dadapter As System.Data.SqlClient.SqlDataAdapter
        Dadapter = New System.Data.SqlClient.SqlDataAdapter

        Dim dsRet As System.Data.DataSet
        dsRet = New System.Data.DataSet
        Dim dtRet As New System.Data.DataTable

        cmdGetDS.Connection = connStr
        cmdGetDS.Connection.Open()
        cmdGetDS.CommandText = strCommand
        cmdGetDS.CommandType = CommandType.StoredProcedure
        cmdGetDS.CommandTimeout = 0

        If Not aryParameters Is Nothing AndAlso IsArray(aryParameters) Then
            System.Data.SqlClient.SqlCommandBuilder.DeriveParameters(cmdGetDS)
            Dim intParm As Int32 = 0 : Dim intLastParm As Int32 = 0 : intLastParm = UBound(aryParameters)

            If intParm + 1 >= cmdGetDS.Parameters.Count Then Throw New Exception("Error" & strCommand)

            cmdGetDS.Parameters.AddWithValue("@RETURN_VALUE", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue

            For intParm = 0 To intLastParm
                If cmdGetDS.Parameters(intParm + 1).DbType = SqlDbType.VarChar And cmdGetDS.Parameters(intParm + 1).Size = 2147483647 Then
                    cmdGetDS.Parameters(intParm + 1).Value = FixSQLBS(aryParameters(intParm))
                Else
                    cmdGetDS.Parameters(intParm + 1).Value = aryParameters(intParm)
                End If
            Next
        End If

        Dim strError_Msg As String = Nothing

        Try
            Dadapter.SelectCommand = cmdGetDS
            Dadapter.Fill(dsRet, "dtRet")
        Catch ex As Exception
            strError_Msg = ex.ToString()
        Finally
            cmdGetDS.Parameters.Clear()
            cmdGetDS.Connection.Close()
        End Try

        If Not strError_Msg = Nothing Then
            Throw New System.Exception(strError_Msg)
        End If

        Return dsRet.Tables("dtRet")

    End Function

    Shared Function FixSQLBS(ByVal strText As String) As String
        If Not IsDBNull(strText) Then
            If Len(Replace(strText, vbCrLf, "  ")) > 8000 Then
                FixSQLBS = Replace(strText, "\" & vbCrLf, "\\" & vbCrLf & vbCrLf)
            Else
                FixSQLBS = strText
            End If
        Else
            FixSQLBS = strText
        End If
    End Function


End Class

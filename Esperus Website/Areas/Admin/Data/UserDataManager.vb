Imports System.Data.SqlClient
Imports Elmah
Imports Esperus.Areas.Admin.Services

Namespace Areas.Admin.Data
    Public Class UserDataManager
        Private Const DATABASE_NAME As String = "esp_Users"

        Public Function GetAllUsers(connectionString As String, name As String) As DataTable
            Dim dataService As New DataService()

            Dim commandQuery As String = "SELECT * FROM " & DATABASE_NAME
            Dim tableData As DataSet = dataService.FillDataSet(connectionString, commandQuery, DATABASE_NAME)

            Return tableData.Tables(0)
        End Function

        Public Function GetUser(connectionString As String, name As String) As DataTable
            Dim dataService As New DataService()

            Dim commandQuery As String = "SELECT * FROM " & DATABASE_NAME & " (NOLOCK) WHERE [UserName] = '" & name & "' "
            Dim tableData As DataSet = dataService.FillDataSet(connectionString, commandQuery, DATABASE_NAME)

            Return tableData.Tables(0)
        End Function

        Public Sub SetUsername(connectionString As String, newUsername As String, currentUsername As String)
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim command As SqlCommand = connection.CreateCommand()
                Dim transaction As SqlTransaction = connection.BeginTransaction("SetUsername")

                command.Connection = connection
                command.Transaction = transaction

                Try
                    Dim commandQuery As String = "UPDATE " & DATABASE_NAME & " SET"
                    commandQuery += " [UserName] = '" & newUsername & "'"
                    commandQuery += " WHERE [UserName] = '" & currentUsername & "'"

                    command.CommandText = commandQuery

                    command.ExecuteNonQuery()
                    transaction.Commit()
                Catch exception As Exception
                    ErrorSignal.FromCurrentContext().Raise(exception)

                    Try
                        transaction.Rollback()
                    Catch rollbackException As Exception
                        ErrorSignal.FromCurrentContext().Raise(rollbackException)
                    End Try
                End Try

                connection.Close()
            End Using
        End Sub

        Public Sub SetPassword(connectionString As String, newPassword As String, currentUsername As String)
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim command As SqlCommand = connection.CreateCommand()
                Dim transaction As SqlTransaction = connection.BeginTransaction("SetPassword")

                command.Connection = connection
                command.Transaction = transaction

                Try
                    Dim commandQuery As String = "UPDATE " & DATABASE_NAME & " SET"
                    commandQuery += " [UserPassword] = '" & newPassword & "'"
                    commandQuery += " WHERE [UserName] = '" & currentUsername & "'"

                    command.CommandText = commandQuery

                    command.ExecuteNonQuery()
                    transaction.Commit()
                Catch exception As Exception
                    ErrorSignal.FromCurrentContext().Raise(exception)

                    Try
                        transaction.Rollback()
                    Catch rollbackException As Exception
                        ErrorSignal.FromCurrentContext().Raise(rollbackException)
                    End Try
                End Try

                connection.Close()
            End Using
        End Sub

        Public Sub SetLoggedIn(connectionString As String, name As String)
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim command As SqlCommand = connection.CreateCommand()
                Dim transaction As SqlTransaction = connection.BeginTransaction("SetLoggedIn")

                command.Connection = connection
                command.Transaction = transaction

                Try
                    Dim commandQuery As String = "UPDATE " & DATABASE_NAME & " SET"
                    commandQuery += " [UserLoggedIn] = '" & 1 & "'"
                    commandQuery += " WHERE [UserName] = '" & name & "'"

                    command.CommandText = commandQuery

                    command.ExecuteNonQuery()
                    transaction.Commit()
                Catch exception As Exception
                    ErrorSignal.FromCurrentContext().Raise(exception)

                    Try
                        transaction.Rollback()
                    Catch rollbackException As Exception
                        ErrorSignal.FromCurrentContext().Raise(rollbackException)
                    End Try
                End Try

                connection.Close()
            End Using
        End Sub

        Public Sub SetLoggedOut(connectionString As String, name As String)
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim command As SqlCommand = connection.CreateCommand()
                Dim transaction As SqlTransaction = connection.BeginTransaction("SetLoggedOut")

                command.Connection = connection
                command.Transaction = transaction

                Try
                    Dim commandQuery As String = "UPDATE " & DATABASE_NAME & " SET"
                    commandQuery += " [UserLoggedIn] = '" & 0 & "'"
                    commandQuery += " WHERE [UserName] = '" & name & "'"

                    command.CommandText = commandQuery

                    command.ExecuteNonQuery()
                    transaction.Commit()
                Catch exception As Exception
                    ErrorSignal.FromCurrentContext().Raise(exception)

                    Try
                        transaction.Rollback()
                    Catch rollbackException As Exception
                        ErrorSignal.FromCurrentContext().Raise(rollbackException)
                    End Try
                End Try

                connection.Close()
            End Using
        End Sub
    End Class
End Namespace

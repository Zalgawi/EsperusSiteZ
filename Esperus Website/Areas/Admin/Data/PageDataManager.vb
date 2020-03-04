Imports System.Data.SqlClient
Imports Elmah
Imports Esperus.Areas.Admin.Models
Imports Esperus.Areas.Admin.Services

Namespace Areas.Admin.Data
    Public Class PageDataManager
        Private Const DATABASE_NAME As String = "esp_Pages"

        ''' <summary>
        ''' Returns a DataSet filled with every Page in the PageContent database.
        ''' NOTE: Used primarily for populating the Editor TreeView.
        ''' </summary>
        Public Function GetAllPages(ByVal connectionString As String) As DataSet
            Dim dataService As New DataService()

            Dim commandQuery As String = "SELECT * FROM " & DATABASE_NAME
            Dim tableData As DataSet = dataService.FillDataSet(connectionString, commandQuery, DATABASE_NAME)

            Return tableData
        End Function

        ''' <summary>
        ''' Populates the PageModel object's PageName and PageBody values according to the PageKey value.
        ''' </summary>
        Public Function LoadPageData(ByVal connectionString As String, ByVal pageModel As PageModel) As Boolean
            Dim result As Boolean

            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim command As SqlCommand = connection.CreateCommand()
                Dim transaction As SqlTransaction = connection.BeginTransaction("LoadPageData")

                command.Connection = connection
                command.Transaction = transaction

                Try
                    Dim commandQuery As String = "SELECT * FROM " & DATABASE_NAME & " WHERE PageKey = " & "'" & pageModel.Key & "'"
                    command.CommandText = commandQuery

                    Dim reader As SqlDataReader = command.ExecuteReader()
                    If reader.HasRows Then
                        Do While reader.Read()
                            If Not IsDBNull(reader.Item("PageName")) Then
                                pageModel.Name = Trim$("" & reader.Item("PageName").ToString())
                            Else
                                pageModel.Name = ""
                            End If

                            If Not IsDBNull(reader.Item("DisplayOrder")) Then
                                pageModel.Order = reader.Item("DisplayOrder")
                            Else
                                pageModel.Order = Nothing
                            End If
                        Loop
                    Else
                        pageModel.Name = ""
                        pageModel.Order = Nothing
                    End If

                    transaction.Commit()
                    reader.Close()
                Catch exception As Exception
                    ErrorSignal.FromCurrentContext().Raise(exception)

                    Try
                        transaction.Rollback()
                    Catch rollbackException As Exception
                        ErrorSignal.FromCurrentContext().Raise(rollbackException)
                    End Try
                End Try

                connection.Close()
                result = True
            End Using

            Return result
        End Function

        ''' <summary>
        ''' Updates the database with the values of the PageModel object.
        ''' </summary>
        Public Function SavePageData(ByVal connectionString As String, ByVal pageModel As PageModel) As Boolean
            Dim result As Boolean

            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim command As SqlCommand = connection.CreateCommand()
                Dim transaction As SqlTransaction = connection.BeginTransaction("SavePageData")

                command.Connection = connection
                command.Transaction = transaction

                Try
                    Dim commandQuery As String = "SELECT * FROM " & DATABASE_NAME & " WHERE PageKey = '" & pageModel.Key & "'"
                    command.CommandText = commandQuery

                    Dim reader As SqlDataReader = command.ExecuteReader()
                    If reader.HasRows Then
                        If reader.Read() Then
                            reader.Close()

                            command.Dispose()
                            command.Connection.CreateCommand()

                            commandQuery = "UPDATE " & DATABASE_NAME & " SET"
                            commandQuery += " PageName = '" & pageModel.Name & "',"
                            commandQuery += " DisplayOrder = '" & pageModel.Order & "'"
                            commandQuery += " WHERE PageKey = '" & pageModel.Key & "'"

                            command.CommandText = commandQuery
                            command.ExecuteNonQuery()
                        Else
                            reader.Close()

                            command.Dispose()
                            command.Connection.CreateCommand()

                            commandQuery = "INSERT INTO " & DATABASE_NAME & " (PageKey, PageName, DisplayOrder)"
                            commandQuery += " VALUES ("
                            commandQuery += "'" & pageModel.Key & "',"
                            commandQuery += " '" & pageModel.Name & "',"
                            commandQuery += " '" & pageModel.Order & "')"

                            command.CommandText = commandQuery
                            command.ExecuteNonQuery()
                        End If
                    End If

                    transaction.Commit()
                    reader.Close()
                Catch exception As Exception
                    ErrorSignal.FromCurrentContext().Raise(exception)

                    Try
                        transaction.Rollback()
                    Catch rollbackException As Exception
                        ErrorSignal.FromCurrentContext().Raise(rollbackException)
                    End Try
                End Try

                connection.Close()
                result = True
            End Using

            Return result
        End Function
    End Class
End Namespace

Imports System.Data.SqlClient
Imports Elmah
Imports Esperus.Areas.Admin.Models
Imports Esperus.Areas.Admin.Services

Namespace Areas.Admin.Data
    Public Class ContentDataManager
        Private Const DATABASE_NAME As String = "esp_Contents"

        ''' <summary>
        ''' Returns a DataSet filled with every Content in the Content database.
        ''' NOTE: Used primarily for populating the Editor TreeView.
        ''' </summary>
        Public Function GetAllContent(ByVal connectionString As String) As DataSet
            Dim dataService As New DataService()

            Dim commandQuery As String = "SELECT * FROM " & DATABASE_NAME
            Dim tableData As DataSet = dataService.FillDataSet(connectionString, commandQuery, DATABASE_NAME)

            Return tableData
        End Function

        ''' <summary>
        ''' Returns a DataSet filled with specific Content based on a SectionKey value.
        ''' </summary>
        Public Function GetContentBySectionKey(ByVal connectionString As String, ByVal sectionModel As SectionModel)
            Dim dataService As New DataService()

            Dim commandQuery As String = "SELECT * FROM " & DATABASE_NAME & " WHERE SectionKey = " & "'" & sectionModel.Key & "' "
            Dim tableData As DataSet = dataService.FillDataSet(connectionString, commandQuery, DATABASE_NAME)

            Return tableData
        End Function

        ''' <summary>
        ''' Populates the ContentModel object's ContentName and ContentBody values according to the ContentKey value.
        ''' </summary>
        Public Function LoadContentData(ByVal connectionString As String, ByVal contentModel As ContentModel) As Boolean
            Dim result As Boolean

            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim command As SqlCommand = connection.CreateCommand()
                Dim transaction As SqlTransaction = connection.BeginTransaction("LoadContentData")

                command.Connection = connection
                command.Transaction = transaction

                Try
                    Dim commandQuery As String = "SELECT * FROM " & DATABASE_NAME & " WHERE ContentKey = " & "'" & contentModel.Key & "' "
                    command.CommandText = commandQuery

                    Dim reader As SqlDataReader = command.ExecuteReader()
                    If reader.HasRows Then
                        Do While reader.Read()
                            If Not IsDBNull(reader.Item("ContentName")) Then
                                contentModel.Name = Trim$("" & reader.Item("ContentName").ToString())
                            Else
                                contentModel.Name = ""
                            End If

                            If Not IsDBNull(reader.Item("ContentBody")) Then
                                contentModel.Body = Trim$("" & reader.Item("ContentBody").ToString())
                            Else
                                contentModel.Body = ""
                            End If

                            If Not IsDBNull(reader.Item("ContentType")) Then
                                contentModel.Type = Trim$("" & reader.Item("ContentType").ToString())
                            Else
                                contentModel.Type = ""
                            End If

                            If Not IsDBNull(reader.Item("ContentImage")) Then
                                contentModel.Image = Trim$("" & reader.Item("ContentImage").ToString())
                            Else
                                contentModel.Image = ""
                            End If

                            If Not IsDBNull(reader.Item("DisplayOrder")) Then
                                contentModel.Order = reader.Item("DisplayOrder")
                            Else
                                contentModel.Order = Nothing
                            End If
                        Loop
                    Else
                        contentModel.Name = ""
                        contentModel.Type = ""
                        contentModel.Body = ""
                        contentModel.Order = Nothing
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
        ''' Updates the database with the values of the ContentModel object.
        ''' </summary>
        Public Function SaveContentData(ByVal connectionString As String, ByVal contentModel As ContentModel) As Boolean
            Dim result As Boolean

            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim command As SqlCommand = connection.CreateCommand()
                Dim transaction As SqlTransaction = connection.BeginTransaction("SaveContentData")

                command.Connection = connection
                command.Transaction = transaction

                Try
                    Dim commandQuery As String = "SELECT * FROM " & DATABASE_NAME
                    command.CommandText = commandQuery

                    Dim reader As SqlDataReader = command.ExecuteReader()
                    If reader.HasRows Then
                        If reader.Read() Then
                            reader.Close()

                            command.Dispose()
                            command.Connection.CreateCommand()

                            commandQuery = "UPDATE " & DATABASE_NAME & " SET"
                            commandQuery += " ContentName = '" & contentModel.Name & "',"
                            commandQuery += " ContentBody = '" & contentModel.Body & "',"
                            commandQuery += " ContentImage = '" & contentModel.Image & "'"
                            commandQuery += " WHERE ContentKey = '" & contentModel.Key & "'"

                            command.CommandText = commandQuery
                            command.ExecuteNonQuery()
                        Else
                            reader.Close()

                            command.Dispose()
                            command.Connection.CreateCommand()

                            commandQuery = "INSERT INTO " & DATABASE_NAME & " (ContentKey, ContentName, ContentBody, ContentImage, SectionKey) SELECT"
                            commandQuery += " '" & contentModel.Key & "',"
                            commandQuery += " '" & contentModel.Name & "',"
                            commandQuery += " '" & contentModel.Body & "',"
                            commandQuery += " '" & contentModel.Image & "',"
                            commandQuery += " '" & contentModel.SectionKey & "'"

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

Imports System.Data.SqlClient
Imports Elmah
Imports Esperus.Areas.Admin.Models
Imports Esperus.Areas.Admin.Services

Namespace Areas.Admin.Data
    Public Class SectionDataManager
        Private Const DATABASE_NAME As String = "esp_Sections"

        ''' <summary>
        ''' Returns a DataSet filled with every Section in the PageSections database.
        ''' NOTE: Used primarily for populating the Editor TreeView.
        ''' </summary>
        Public Function GetAllSections(ByVal connectionString As String) As DataSet
            Dim dataService As New DataService()

            Dim commandQuery As String = "SELECT * FROM " & DATABASE_NAME
            Dim tableData As DataSet = dataService.FillDataSet(connectionString, commandQuery, DATABASE_NAME)

            Return tableData
        End Function

        ''' <summary>
        ''' Returns a DataSet filled with specific Sections based on a PageKey value.
        ''' </summary>
        Public Function GetSectionsByPageKey(ByVal connectionString As String, ByVal pageModel As PageModel)
            Dim dataService As New DataService()

            Dim commandQuery As String = "SELECT * FROM " & DATABASE_NAME & " WHERE PageKey = '" & pageModel.Key & "' "
            Dim tableData As DataSet = dataService.FillDataSet(connectionString, commandQuery, DATABASE_NAME)

            Return tableData
        End Function

        ''' <summary>
        ''' Populates the SectionModel object's SectionName and SectionBody values according to the SectionKey value.
        ''' </summary>
        Public Function LoadSectionData(ByVal connectionString As String, ByVal sectionModel As SectionModel) As Boolean
            Dim result As Boolean

            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim command As SqlCommand = connection.CreateCommand()
                Dim transaction As SqlTransaction = connection.BeginTransaction("LoadSectionData")

                command.Connection = connection
                command.Transaction = transaction

                Try
                    Dim commandQuery As String = "SELECT * FROM " & DATABASE_NAME & " WHERE SectionKey = " & "'" & sectionModel.Key & "'"
                    command.CommandText = commandQuery

                    Dim reader As SqlDataReader = command.ExecuteReader()
                    If reader.HasRows Then
                        Do While reader.Read()
                            If Not IsDBNull(reader.Item("SectionName")) Then
                                sectionModel.Name = Trim$("" & reader.Item("SectionName").ToString())
                            Else
                                sectionModel.Name = ""
                            End If

                            If Not IsDBNull(reader.Item("DisplayOrder")) Then
                                sectionModel.Order = reader.Item("DisplayOrder")
                            Else
                                sectionModel.Order = Nothing
                            End If
                        Loop
                    Else
                        sectionModel.Name = ""
                        sectionModel.Order = Nothing
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
        ''' Updates the database with the values of the SectionModel object.
        ''' </summary>
        Public Function SaveSectionData(ByVal connectionString As String, ByVal sectionModel As SectionModel) As Boolean
            Dim result As Boolean

            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim command As SqlCommand = connection.CreateCommand()
                Dim transaction As SqlTransaction = connection.BeginTransaction("SaveSectionData")

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
                            commandQuery += " SectionName = '" & sectionModel.Name & "', "
                            commandQuery += " DisplayOrder = '" & sectionModel.Order & "'"
                            commandQuery += " WHERE SectionKey = '" & sectionModel.Key & "'"

                            command.CommandText = commandQuery
                            command.ExecuteNonQuery()
                            transaction.Commit()
                        Else
                            reader.Close()

                            command.Dispose()
                            command.Connection.CreateCommand()

                            commandQuery = "INSERT INTO " & DATABASE_NAME & " (SectionKey, SectionName, DisplayOrder, PageKey)"
                            commandQuery += " VALUES ("
                            commandQuery += "'" & sectionModel.Key & "',"
                            commandQuery += " '" & sectionModel.Name & "',"
                            commandQuery += " '" & sectionModel.Order & "',"
                            commandQuery += " '" & sectionModel.PageKey & "')"

                            command.CommandText = commandQuery
                            command.ExecuteNonQuery()
                            transaction.Commit()
                        End If
                    End If
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

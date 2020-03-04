Imports System.Data.SqlClient
Imports Elmah
Imports Esperus.Areas.Admin.Models
Imports Esperus.Areas.Admin.Services

Namespace Areas.Admin.Data
    Public Class AssetDataManager
        Private Const DATABASE_NAME As String = "esp_Assets"

        Public Function GetAllImages(ByVal connectionString As String) As DataSet
            Dim dataService As New DataService()

            Dim commandQuery As String = "SELECT * FROM " & DATABASE_NAME
            Dim tableData As DataSet = dataService.FillDataSet(connectionString, commandQuery, DATABASE_NAME)

            Return tableData
        End Function

        Public Function DeleteExistingImage(connectionString As String, imageName As String)
            Dim result As Boolean

            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim command As SqlCommand = connection.CreateCommand()
                Dim transaction As SqlTransaction = connection.BeginTransaction("DeleteExistingImage")

                command.Connection = connection
                command.Transaction = transaction

                Try
                    Dim commandQuery As String = "DELETE FROM " & DATABASE_NAME & " WHERE [AssetName] = '" & imageName & "' "
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
                result = True
            End Using

            Return result
        End Function

        Public Function SaveNewImage(connectionString As String, assetModel As AssetModel)
            Dim result As Boolean

            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim command As SqlCommand = connection.CreateCommand()
                Dim transaction As SqlTransaction = connection.BeginTransaction("SaveNewImage")

                command.Connection = connection
                command.Transaction = transaction

                Try
                    Dim commandQuery As String = "INSERT INTO " & DATABASE_NAME & " ([AssetName], [AssetPath], [AssetType], [AssetDisplayName]) VALUES ("
                    commandQuery += " '" & assetModel.Name & "',"
                    commandQuery += " '" & assetModel.Path & "',"
                    commandQuery += " '" & assetModel.Type & "',"
                    commandQuery += " '" & assetModel.DisplayName & "')"

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
                result = True
            End Using

            Return result
        End Function
    End Class
End Namespace

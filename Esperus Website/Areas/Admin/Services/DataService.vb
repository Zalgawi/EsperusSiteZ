Imports System.Data.SqlClient
Imports Elmah

Namespace Areas.Admin.Services
    Public Class DataService

        Public Sub New()
        End Sub

        ''' <summary>
        ''' Fill and return a DataSet based on the command provided.
        ''' </summary>
        Public Function FillDataSet(ByVal connectionString As String, ByVal commandQuery As String, ByVal tableName As String) As DataSet
            Dim tableData As New DataSet()

            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim command As SqlCommand = connection.CreateCommand()
                Dim transaction As SqlTransaction = connection.BeginTransaction("FillDataSet")

                command.Connection = connection
                command.Transaction = transaction

                Try
                    command.CommandText = commandQuery

                    Dim adapter As New SqlDataAdapter(command)
                    adapter.Fill(tableData, tableName)

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

            Return tableData
        End Function
    End Class
End Namespace

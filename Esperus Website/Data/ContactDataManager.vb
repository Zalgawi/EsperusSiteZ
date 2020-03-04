Imports System.Data.SqlClient
Imports Esperus.Models

Namespace Data
    Public Class ContactDataManager
        Public Function SaveContactDetails(connectionString As String, messageModel As MessageModel)
            Dim result As New Result

            Try
                Using connection As New SqlConnection(connectionString)
                    connection.Open()

                    Dim transaction As SqlTransaction = connection.BeginTransaction("SaveContactDetails")

                    Dim compiledTelephone As String = ""

                    If Not String.IsNullOrWhiteSpace(messageModel.SenderCallingCode) Then
                        compiledTelephone = compiledTelephone & "(+" & messageModel.SenderCallingCode & ") "
                    End If

                    compiledTelephone = compiledTelephone & messageModel.SenderTelephone

                    If Not String.IsNullOrWhiteSpace(messageModel.SenderExtension) Then
                        compiledTelephone = compiledTelephone & " (ext. " & messageModel.SenderExtension & ")"
                    End If

                    Dim commandQuery As String = "INSERT INTO [esp_Contacts] (ContactName, ContactCompany, ContactAddress, ContactTelephone, ContactInterest, ContactDateAdded, ContactImported, ContactSource, ContactReferral, ContactInitialMessage)"
                    commandQuery += " VALUES ("
                    commandQuery += "'" & messageModel.SenderName & "', "
                    commandQuery += "'" & messageModel.SenderCompany & "', "
                    commandQuery += "'" & messageModel.SenderEmail & "', "
                    commandQuery += "'" & compiledTelephone & "', "
                    commandQuery += "'" & messageModel.SenderInterest & "', "
                    commandQuery += "'" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "', "
                    commandQuery += "'0', "

                    If messageModel.Type = MessageType.ContactRequest Then
                        commandQuery += "'Website (Contact)', "
                    Else
                        commandQuery += "'Website (Demo)', "
                    End If

                    commandQuery += "'" & messageModel.SenderReferer & "', "
                    commandQuery += "'" & messageModel.SenderMessage & "');"

                    Dim command As SqlCommand = connection.CreateCommand()
                    command.CommandText = commandQuery
                    command.Connection = connection
                    command.Transaction = transaction

                    command.ExecuteNonQuery()
                    transaction.Commit()

                    connection.Close()
                    result.Type = True
                End Using
            Catch exception As Exception
                result.Message = exception.ToString()
                result.Heading = "Error"
                result.Type = False
            End Try

            Return result
        End Function

        Public Function DeleteContactDetails(connectionString As String, withdrawAddress As String)
            Dim result As New Result

            Try
                Using connection As New SqlConnection(connectionString)
                    connection.Open()

                    Dim command As SqlCommand = connection.CreateCommand()
                    Dim transaction As SqlTransaction = connection.BeginTransaction("DeleteContactDetails")

                    command.Connection = connection
                    command.Transaction = transaction

                    Dim commandQuery As String = "SELECT * FROM [esp_Contacts] WHERE [ContactAddress] = '" & withdrawAddress & "'"
                    command.CommandText = commandQuery

                    Dim reader As SqlDataReader = command.ExecuteReader()
                    If reader.HasRows Then
                        reader.Close()

                        command.Dispose()
                        command.Connection.CreateCommand()

                        commandQuery = "DELETE FROM [esp_Contacts] WHERE [ContactAddress] = '" & withdrawAddress & "'"
                        command.CommandText = commandQuery
                        command.ExecuteNonQuery()
                    Else
                        result.Type = False
                        result.Message = "We couldn't find an e-mail address on-file matching this. Please try again."
                        result.Heading = "Invalid E-Mail Address"
                    End If

                    transaction.Commit()
                    reader.Close()

                    connection.Close()
                    result.Type = True
                End Using
            Catch exception As Exception
                result.Type = False
                result.Message = exception.ToString()
                result.Heading = "Error"
            End Try

            Return result
        End Function
    End Class
End Namespace

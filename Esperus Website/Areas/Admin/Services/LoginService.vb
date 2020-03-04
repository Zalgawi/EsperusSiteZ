Imports System.IO
Imports System.Security.Cryptography
Imports Elmah
Imports Esperus.Areas.Admin.Data
Imports Esperus.Areas.Admin.Models
Imports Esperus.Models

Namespace Areas.Admin.Services
    Public Class LoginService
        Private ReadOnly Key As Byte() = {&HA1, &HF1, &HA6, &HBB, &HA2, &H5A, &H37, &H6F, &H81, &H2E, &H17, &H41, &H72, &H2C, &H43, &H27}
        Private ReadOnly InitVector As Byte() = {&HE1, &HF1, &HA6, &HBB, &HA9, &H5B, &H31, &H2F, &H81, &H2E, &H17, &H4C, &HA2, &H81, &H53, &H61}

        Public Function Decrypt(ByVal value As String) As String
            Dim mCsp As SymmetricAlgorithm
            Dim ct As ICryptoTransform = Nothing
            Dim ms As MemoryStream = Nothing
            Dim cs As CryptoStream = Nothing
            Dim byt As Byte()
            Dim result As Byte()
            mCsp = New RijndaelManaged()

            Try
                mCsp.Key = Key
                mCsp.IV = InitVector
                ct = mCsp.CreateDecryptor(mCsp.Key, mCsp.IV)
                byt = Convert.FromBase64String(value)
                ms = New MemoryStream()
                cs = New CryptoStream(ms, ct, CryptoStreamMode.Write)
                cs.Write(byt, 0, byt.Length)
                cs.FlushFinalBlock()
                cs.Close()
                result = ms.ToArray()
            Catch
                result = Nothing
            Finally
                If ct IsNot Nothing Then ct.Dispose()
                If ms IsNot Nothing Then ms.Dispose()
                If cs IsNot Nothing Then cs.Dispose()
            End Try

            Return ASCIIEncoding.UTF8.GetString(result)
        End Function

        Public Function Encrypt(ByVal password As String) As String
            If String.IsNullOrEmpty(password) Then Return String.Empty
            Dim value As Byte() = Encoding.UTF8.GetBytes(password)
            Dim mCsp As SymmetricAlgorithm = New RijndaelManaged With {
            .Key = Key,
            .IV = InitVector
        }

            Using ct As ICryptoTransform = mCsp.CreateEncryptor(mCsp.Key, mCsp.IV)
                Using ms As MemoryStream = New MemoryStream()
                    Using cs As CryptoStream = New CryptoStream(ms, ct, CryptoStreamMode.Write)
                        cs.Write(value, 0, value.Length)
                        cs.FlushFinalBlock()
                        cs.Close()
                        Return Convert.ToBase64String(ms.ToArray())
                    End Using
                End Using
            End Using
        End Function

        ''' <summary>
        ''' Builds a UserModel and assigns that to the current session, thus logging in.
        ''' </summary>
        ''' <param name="currentUsername">Username (for authentication)</param>
        ''' <param name="currentPassword">Password (for authentication)</param>
        Public Function Login(connectionString As String, currentUsername As String, currentPassword As String)
            Dim result As Result

            Dim manager As New UserDataManager()
            Dim service As New LoginService()

            Try
                Using dataTable As DataTable = manager.GetUser(connectionString, currentUsername)
                    If dataTable.Rows.Count = 0 Then
                        result = New Result(False, "Invalid Credentials", "Incorrect usrname. Please try again.")
                    Else
                        Dim inputPassword = service.Encrypt(currentPassword)
                        Dim dataPassword = Convert.ToString(dataTable.Rows(0)("UserPassword"))

                        If String.Compare(inputPassword, dataPassword) = 0 Then
                            Dim dataUsername As String = Convert.ToString(dataTable.Rows(0)("UserName"))
                            manager.SetLoggedIn(connectionString, dataUsername)

                            Dim dataDisplayName As String = Convert.ToString(dataTable.Rows(0)("UserDisplayName"))

                            Dim userModel As New UserModel With {
                                .DisplayName = dataDisplayName,
                                .Username = dataUsername,
                                .Password = dataPassword,
                                .DateCreated = Convert.ToString(dataTable.Rows(0)("UserDateCreated"))
                            }

                            HttpContext.Current.Session("ActiveUser") = userModel
                            result = New Result(True, Nothing, Nothing)
                        Else
                            result = New Result(False, "Invalid Credentials", "Incorrect password. Please try again.")
                        End If
                    End If
                End Using
            Catch exception As Exception
                ErrorSignal.FromCurrentContext().Raise(exception)
                result = New Result(False, "Error", "Internal server error. Please try again later.")
            End Try

            Return result
        End Function

        Public Sub Logout(connectionString As String, userName As String)
            Dim manager As New UserDataManager()
            manager.SetLoggedOut(connectionString, userName)
            HttpContext.Current.Session("ActiveUser") = Nothing
            HttpContext.Current.Session("IsLoggedOn") = False
        End Sub

        ''' <summary>
        ''' Updates the username and password of the User Account.
        ''' </summary>
        ''' <param name="currentUsername">Current Username (for authentication)</param>
        ''' <param name="currentPassword">Current Password (for authentication)</param>
        ''' <param name="newUsername">New Username (to replace)</param>
        ''' <param name="newPassword">New Password (to replace)</param>
        Public Function UpdateAccount(connectionString As String, currentUsername As String, currentPassword As String, newUsername As String, newPassword As String)
            Dim manager As New UserDataManager()
            Dim result As Result

            Try
                Using dataTable As DataTable = manager.GetUser(connectionString, currentUsername)
                    If dataTable.Rows.Count = 0 Then
                        result = New Result(False, "Invalid Credentials", "Current username not found. Please try again.")
                    Else
                        Dim existingPassword = Convert.ToString(dataTable.Rows(0)("UserPassword"))
                        If String.Compare(currentPassword, existingPassword) = 0 Then
                            manager.SetUsername(connectionString, newUsername, currentUsername)
                            manager.SetPassword(connectionString, newPassword, currentUsername)

                            result = New Result(True, "Update Successful", "Your details have been changed successfully.")
                        Else
                            result = New Result(False, "Update Failed", "Incorrect password. Please try again.")
                        End If
                    End If
                End Using
            Catch Exception As Exception
                ErrorSignal.FromCurrentContext().Raise(Exception)
                result = New Result(False, "Server Error", "Internal server error. Please try again later.")
            End Try

            Return result
        End Function
    End Class
End Namespace

'
' NOTE: This was partially converted from the Utilities class in Esperus CLS.
'

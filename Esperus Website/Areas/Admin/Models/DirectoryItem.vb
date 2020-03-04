Imports System.IO

Namespace Models
    Public Class DirectoryItem
        Private _FullPath As String

        Public Property ID As String
        Public Property Name As String
        Public Property Size As String
        Public Property Dimentions As String
        Public Property RelativePath As String
        Public Property IsDirectory As Boolean
        Public Property DisplayName As String
        Public Property Type As DirectoryItemType

        Property FullPath As String
            Get
                Return _FullPath
            End Get
            Set
                _FullPath = Value
                Name = Path.GetFileName(Value)

                'Detect whether its a directory or file
                If (Directory.Exists(Value)) Then
                    Name = $"/{Name}"
                End If
            End Set
        End Property
    End Class

    Public Enum DirectoryItemType
        Provided = 0
        Uploaded = 1
    End Enum
End Namespace

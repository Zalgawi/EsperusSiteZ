Imports System.ComponentModel.DataAnnotations

Namespace Areas.Admin.Models
    Public Class BaseEditorModel : Implements IEditorModel
        <Display(Name:="Key")> Public Property Key As String Implements IEditorModel.Key
        <Display(Name:="Name")> Public Property Name As String Implements IEditorModel.Name
        Public Property Order As Integer Implements IEditorModel.Order
        Public Property Type As String Implements IEditorModel.Type
        <AllowHtml> Public Property Body As String Implements IEditorModel.Body
        <AllowHtml> Public Property Image As String Implements IEditorModel.Image

        Public Sub New()
        End Sub
    End Class
End Namespace

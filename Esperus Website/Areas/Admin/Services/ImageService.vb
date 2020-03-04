Imports System.Drawing
Imports System.IO
Imports Elmah
Imports Esperus.Areas.Admin.Data
Imports Esperus.Models

Namespace Areas.Admin.Services
    Public Class ImageService

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        Public Function PopulateFolders(connectionString As String)
            Dim assetDAO As New AssetDataManager()
            Dim imageSet As DataTable = assetDAO.GetAllImages(connectionString).Tables(0)

            Dim imagesPath As String = HttpContext.Current.Server.MapPath($"~/Areas/Admin/Resources/Uploads/")
            Dim imageFiles As List(Of String) = SearchImageDirectories(imagesPath)

            Dim directoryItems As New List(Of DirectoryItem)

            For Each row As DataRow In imageSet.Rows
                Dim path As String = HttpContext.Current.Server.MapPath(row("AssetPath").ToString())
                Dim image As Image = Image.FromFile(path)
                Dim dimensions As String = image.Width & " x " & image.Height

                If imageFiles.Contains(row("AssetName").ToString()) Then
                    Dim info As New FileInfo(path)
                    Dim size As Double = Math.Round((info.Length() / 1048576), 2)

                    Dim item As New DirectoryItem With {
                        .ID = row("AssetKey").ToString(),
                        .Name = row("AssetName").ToString(),
                        .FullPath = path,
                        .Size = size.ToString(),
                        .Dimentions = dimensions,
                        .DisplayName = row("AssetDisplayName").ToString(),
                        .Type = DirectoryItemType.Uploaded
                    }
                    directoryItems.Add(item)
                End If
            Next

            Dim localImagesPath As String = HttpContext.Current.Server.MapPath($"~/Content/Images/")
            Dim localImageFiles As List(Of String) = SearchLocalImageDirectories(localImagesPath)

            For Each file As String In localImageFiles
                Dim _path As String = HttpContext.Current.Server.MapPath(file)
                Dim name As String = Path.GetFileName(_path)
                Dim image As Image = Image.FromFile(_path)
                Dim dimensions As String = image.Width & " x " & image.Height

                Dim info As New FileInfo(_path)
                Dim size As Double = Math.Round((info.Length() / 1048576), 2)

                Dim item As New DirectoryItem With {
                    .ID = "",
                    .Name = name,
                    .FullPath = _path,
                    .Size = size.ToString(),
                    .Dimentions = dimensions,
                    .DisplayName = name,
                    .Type = DirectoryItemType.Provided
                }
                directoryItems.Add(item)
            Next

            Return directoryItems
        End Function

        Private Function SearchLocalImageDirectories(imagePath As String)
            Dim files As New List(Of String)

            Try
                For Each file As String In Directory.GetFiles(imagePath)
                    Dim physicalPath = Path.GetFullPath(file)
                    Dim relativePath = GetRelativePath(physicalPath)
                    files.Add(relativePath)
                Next

                For Each dir As String In Directory.GetDirectories(imagePath)
                    files.AddRange(SearchLocalImageDirectories(dir))
                Next
            Catch exception As Exception
                ErrorSignal.FromCurrentContext().Raise(exception)
            End Try

            Return files
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        Private Function SearchImageDirectories(imagePath As String)
            Dim files As New List(Of String)

            Try
                For Each file As String In Directory.GetFiles(imagePath)
                    files.Add(Path.GetFileName(file))
                Next

                For Each dir As String In Directory.GetDirectories(imagePath)
                    files.AddRange(SearchImageDirectories(dir))
                Next
            Catch exception As Exception
                ErrorSignal.FromCurrentContext().Raise(exception)
            End Try

            Return files
        End Function

        Private Function GetRelativePath(path As String) As String
            Dim relativePath As String
            relativePath = path.Substring(HttpContext.Current.Server.MapPath("~/").Length - 1)
            relativePath = relativePath.Replace("\", "/")
            Return relativePath
        End Function
    End Class
End Namespace

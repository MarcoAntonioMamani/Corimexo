Public Class ImgCategoria
    Private Sub pbImage_Click(sender As Object, e As EventArgs) Handles pbImage.Click
        Dim ruta As String = ""
        ruta = pbImage.Tag
        If (ruta.Trim <> String.Empty) Then
            Shell("rundll32.exe C:\WINDOWS\system32\shimgvw.dll,ImageView_Fullscreen " + ruta)
        End If
    End Sub
End Class

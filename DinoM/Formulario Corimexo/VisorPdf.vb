Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar.SuperGrid
Imports System.IO
Imports DevComponents.DotNetBar
Public Class VisorPdf
    Public Ruta As String
    Private Sub VisorPdf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (File.Exists(Ruta)) Then
            PdfView.LoadFile(Ruta)
            PdfView.setZoom(95)


        Else
            ToastNotification.Show(Me, "El archivo " + Ruta + ", No EXISTE!!!",
                                   My.Resources.INFORMATION, 2 * 1000,
                                   eToastGlowColor.Blue, eToastPosition.BottomLeft)
        End If
    End Sub
End Class
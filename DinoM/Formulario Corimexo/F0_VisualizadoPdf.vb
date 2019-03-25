Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar.SuperGrid
Imports System.IO
Imports DevComponents.DotNetBar
Imports MaterialSkin
Public Class F0_VisualizadoPdf
    Public Ruta As String
    Public Titulo As String
    Private Sub F0_VisualizadoPdf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim blah As New Bitmap(New Bitmap(My.Resources.printee), 20, 20)
        Dim ico As Icon = Icon.FromHandle(blah.GetHicon())
        Me.Icon = ico
        PdfView.Dock = DockStyle.Fill
        If (File.Exists(Ruta)) Then
            PdfView.LoadFile(Ruta)
            PdfView.setZoom(90)
            'PdfView.setShowToolbar(True)
            PdfView.setShowScrollbars(True)
            PdfView.Refresh()



        Else
            ToastNotification.Show(Me, "El archivo " + Ruta + ", No EXISTE!!!",
                                   My.Resources.INFORMATION, 2 * 1000,
                                   eToastGlowColor.Blue, eToastPosition.BottomLeft)
        End If



        lbtitulo.Text = Titulo
    End Sub
End Class
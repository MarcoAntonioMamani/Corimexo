Imports Janus.Windows.GridEX
Imports Logica.AccesoLogica

Imports DevComponents.DotNetBar
Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid
Imports System.Drawing
Imports DevComponents.DotNetBar.Controls
Imports System.Threading
Imports System.Drawing.Text
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Drawing.Printing
Imports System.Math
Public Class F0_ModeloAyudaImagenes

#Region "ATRIBUTOS"
    Dim RutaGlobal As String = gs_CarpetaRaiz
    Dim RutaTemporal As String = "C:\Temporal"
    Public dtBuscador As DataTable
    Public nombreVista As String
    Public posX As Integer
    Public posY As Integer
    Public seleccionado As Boolean
    Public Columna As Integer = -1
    Public filaSelect As Janus.Windows.GridEX.GridEXRow

    Public listEstrucGrilla As List(Of Modelo.Celda)
#End Region

#Region "METODOS PRIVADOS"
    Public Sub New(ByVal x As Integer, y As Integer, dt1 As DataTable, titulo As String, listEst As List(Of Modelo.Celda))
        dtBuscador = dt1
        posX = x
        posY = y
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point(posX, posY)
        GPPanelP.Text = titulo

        listEstrucGrilla = listEst

        seleccionado = False

        _PMCargarBuscador()
        'grJBuscador.Row = grJBuscador.FilterRow.RowIndex
        'grJBuscador.Col = 1
        Columna = 2
    End Sub
    Public Sub _prSeleccionar()
        If (Columna >= 0) Then
            grJBuscador.Select()
            ''  grJBuscador.Focus()
            grJBuscador.MoveTo(grJBuscador.FilterRow)
            grJBuscador.Col = Columna
        End If
    End Sub


    Private Sub _PMCargarBuscador()

        Dim anchoVentana As Integer = 0

        grJBuscador.DataSource = dtBuscador
        grJBuscador.RetrieveStructure()


        For i = 0 To dtBuscador.Columns.Count - 1
            With grJBuscador.RootTable.Columns(i)
                If listEstrucGrilla.Item(i).visible = True Then
                    .Caption = listEstrucGrilla.Item(i).titulo
                    .Width = listEstrucGrilla.Item(i).tamano
                    .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                    .CellStyle.FontSize = 9

                    Dim col As DataColumn = dtBuscador.Columns(i)
                    Dim tipo As Type = col.DataType
                    If tipo.ToString = "System.Int32" Or tipo.ToString = "System.Decimal" Then
                        .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                    End If
                    If listEstrucGrilla.Item(i).formato = String.Empty Then
                        .FormatString = listEstrucGrilla.Item(i).formato
                        .CellStyle.ImageHorizontalAlignment = Janus.Windows.GridEX.ImageHorizontalAlignment.Center
                    End If

                    anchoVentana = anchoVentana + listEstrucGrilla.Item(i).tamano
                Else
                    .Visible = False
                End If
            End With
        Next

        'Habilitar Filtradores
        With grJBuscador
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            'diseño de la grilla
            .GroupByBoxVisible = False
            .VisualStyle = VisualStyle.Office2007
        End With
        _prDibujarImagenes()

        'adaptar el tamaño de la ventana
        Me.Width = anchoVentana + 50
    End Sub

    Public Sub _prDibujarImagenes()
        Dim length As Integer = CType(grJBuscador.DataSource, DataTable).Rows.Count
        For i As Integer = 0 To length - 1 Step 1
            Dim nameImagen As String = CType(grJBuscador.DataSource, DataTable).Rows(i).Item("ygimg")
            If (nameImagen.Equals("Default.jpg")) Then
                'Dim Bin As New MemoryStream
                'Dim img As New Bitmap(My.Resources.pantalla, 150, 130)
                'img.Save(Bin, Imaging.ImageFormat.Jpeg)
                'Bin.Dispose()

                'CType(grJBuscador.DataSource, DataTable).Rows(i).Item("img") = Bin.GetBuffer
            Else
                Dim Bin As New MemoryStream
                If (File.Exists(RutaGlobal + "\Imagenes\Imagenes Categoria" + nameImagen)) Then
                    Dim img As New Bitmap(New Bitmap(RutaGlobal + "\Imagenes\Imagenes Categoria" + nameImagen), 150, 130)
                    img.Save(Bin, Imaging.ImageFormat.Jpeg)
                    CType(grJBuscador.DataSource, DataTable).Rows(i).Item("img") = Bin.GetBuffer
                    Bin.Dispose()
                Else

                    'Dim img As New Bitmap(My.Resources.pantalla, 150, 130)
                    'img.Save(Bin, Imaging.ImageFormat.Jpeg)
                    'Bin.Dispose()

                    'CType(grJBuscador.DataSource, DataTable).Rows(i).Item("img") = Bin.GetBuffer

                End If
            End If


        Next
    End Sub

    Private Sub F0_ModeloAyudaImagenes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
        If (e.KeyChar = ChrW(Keys.Escape)) Then
            e.Handled = True
            Me.Close()
        End If
    End Sub

    Private Sub grJBuscador_KeyDown(sender As Object, e As KeyEventArgs) Handles grJBuscador.KeyDown
        If e.KeyData = Keys.Escape Then
            Me.Close()
        End If

        If e.KeyData = Keys.Enter Then
            filaSelect = grJBuscador.GetRow()
            seleccionado = True
            Me.Close()
        End If
    End Sub
#End Region

End Class
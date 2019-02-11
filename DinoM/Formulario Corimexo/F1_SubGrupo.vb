
Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Imports Janus.Windows.GridEX
Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid
Imports GMap.NET.MapProviders
Imports GMap.NET
Imports GMap.NET.WindowsForms.Markers
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.ToolTips
Imports DevComponents.DotNetBar.Controls
Public Class F1_SubGrupo
#Region "Variables Locales"

    Dim RutaGlobal As String = gs_CarpetaRaiz
    Dim RutaTemporal As String = "C:\Temporal"
    Dim Modificado As Boolean = False
    Dim nameImg As String = "Default.jpg"
    Public _nameButton As String
    Public _modulo As SideNavItem
    Public _tab As SuperTabItem
    Dim CodigoCategoria As Integer = 0
    Dim CodigoGrupo As Integer = 0

#End Region
#Region "Metodos Privados"

    Private Sub _prIniciarTodo()
        'L_prAbrirConexion(gs_Ip, gs_UsuarioSql, gs_ClaveSql, gs_NombreBD)
        Me.Text = "SubGrupos"
        _prMaxLength()
        _prAsignarPermisos()
        _PMIniciarTodo()

        Dim blah As New Bitmap(New Bitmap(My.Resources.almacen), 20, 20)
        Dim ico As Icon = Icon.FromHandle(blah.GetHicon())
        Me.Icon = ico

    End Sub


    Private Function _fnCopiarImagenRutaDefinida() As String
        'copio la imagen en la carpeta del sistema

        Dim file As New OpenFileDialog()
        file.Filter = "Ficheros JPG o JPEG o PNG|*.jpg;*.jpeg;*.png" &
                      "|Ficheros GIF|*.gif" &
                      "|Ficheros BMP|*.bmp" &
                      "|Ficheros PNG|*.png" &
                      "|Ficheros TIFF|*.tif"
        If file.ShowDialog() = DialogResult.OK Then
            Dim ruta As String = file.FileName


            If file.CheckFileExists = True Then
                Dim img As New Bitmap(New Bitmap(ruta))
                Dim imgM As New Bitmap(New Bitmap(ruta))
                Dim Bin As New MemoryStream
                imgM.Save(Bin, System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim a As Object = file.GetType.ToString
                If (_fnActionNuevo()) Then

                    nameImg = "\Imagen_" + Str(Now.Hour).Trim + Str(Now.Minute).Trim + Str(Now.Second).Trim + ".jpg"
                    UsImg.SizeMode = PictureBoxSizeMode.StretchImage
                    UsImg.Image = Image.FromStream(Bin)

                    img.Save(RutaTemporal + nameImg, System.Drawing.Imaging.ImageFormat.Jpeg)
                    img.Dispose()
                Else

                    nameImg = "\Imagen_" + Str(Now.Hour).Trim + Str(Now.Minute).Trim + Str(Now.Second).Trim + ".jpg"

                    UsImg.Image = Image.FromStream(Bin)
                    img.Save(RutaTemporal + nameImg, System.Drawing.Imaging.ImageFormat.Jpeg)
                    Modificado = True
                    img.Dispose()

                End If
            End If

            Return nameImg
        End If

        Return "default.jpg"
    End Function
    Public Sub _prStyleJanus()
        GroupPanelBuscador.Style.BackColor = Color.FromArgb(13, 71, 161)
        GroupPanelBuscador.Style.BackColor2 = Color.FromArgb(13, 71, 161)
        GroupPanelBuscador.Style.TextColor = Color.White
        JGrM_Buscador.RootTable.HeaderFormatStyle.FontBold = TriState.True
    End Sub

    Public Sub _prMaxLength()
        tbNombre.MaxLength = 150
        tbdesccorta.MaxLength = 10
    End Sub


    Private Sub _prAsignarPermisos()

        Dim dtRolUsu As DataTable = L_prRolDetalleGeneral(gi_userRol, _nameButton)

        Dim show As Boolean = dtRolUsu.Rows(0).Item("ycshow")
        Dim add As Boolean = dtRolUsu.Rows(0).Item("ycadd")
        Dim modif As Boolean = dtRolUsu.Rows(0).Item("ycmod")
        Dim del As Boolean = dtRolUsu.Rows(0).Item("ycdel")

        If add = False Then
            btnNuevo.Visible = False
        End If
        If modif = False Then
            btnModificar.Visible = False
        End If
        If del = False Then
            btnEliminar.Visible = False
        End If
    End Sub
    Private Sub _prCrearCarpetaTemporal()

        If System.IO.Directory.Exists(RutaTemporal) = False Then
            System.IO.Directory.CreateDirectory(RutaTemporal)
        Else
            Try
                My.Computer.FileSystem.DeleteDirectory(RutaTemporal, FileIO.DeleteDirectoryOption.DeleteAllContents)
                My.Computer.FileSystem.CreateDirectory(RutaTemporal)
                'My.Computer.FileSystem.DeleteDirectory(RutaTemporal, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin)
                'System.IO.Directory.CreateDirectory(RutaTemporal)

            Catch ex As Exception

            End Try

        End If

    End Sub
    Private Sub _prCrearCarpetaImagenes()
        Dim rutaDestino As String = RutaGlobal + "\Imagenes\Imagenes Categoria\"

        If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes Categoria\") = False Then
            If System.IO.Directory.Exists(RutaGlobal + "\Imagenes") = False Then
                System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes")
                If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes Categoria") = False Then
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes Categoria")
                End If
            Else
                If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes Categoria") = False Then
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes Categoria")

                End If
            End If
        End If
    End Sub
    Private Sub _fnMoverImagenRuta(Folder As String, name As String)
        'copio la imagen en la carpeta del sistema
        If (Not name.Equals("Default.jpg") And File.Exists(RutaTemporal + name)) Then

            Dim img As New Bitmap(New Bitmap(RutaTemporal + name), 500, 300)

            UsImg.Image.Dispose()
            UsImg.Image = Nothing
            Try
                My.Computer.FileSystem.CopyFile(RutaTemporal + name,
     Folder + name, overwrite:=True)

            Catch ex As System.IO.IOException


            End Try



        End If
    End Sub
#End Region
#Region "METODOS SOBRECARGADOS"

    Public Overrides Sub _PMOHabilitar()



        tbNombre.ReadOnly = False
        tbdesccorta.ReadOnly = False
        _prCrearCarpetaImagenes()
        _prCrearCarpetaTemporal()
        BtAdicionar.Visible = True

        tbNombre.Focus()
        ''  SuperTabItem1.Visible =True 
    End Sub

    Public Overrides Sub _PMOInhabilitar()
        tbCodigoOriginal.ReadOnly = True
        tbNombre.ReadOnly = True
        tbdesccorta.ReadOnly = True
        tbcategoria.ReadOnly = True
        BtAdicionar.Visible = False
        tbgrupo.ReadOnly = True
        _prStyleJanus()
        JGrM_Buscador.Focus()
        ' SuperTabItem1.Visible = False
    End Sub

    Public Overrides Sub _PMOLimpiar()
        tbCodigoOriginal.Clear()
        tbNombre.Clear()
        tbdesccorta.Clear()
        tbcategoria.Clear()
        CodigoCategoria = 0
        UsImg.Image = My.Resources.pantalla
        tbgrupo.Clear()


    End Sub

    Public Overrides Sub _PMOLimpiarErrores()
        MEP.Clear()
        tbNombre.BackColor = Color.White
        tbdesccorta.BackColor = Color.White
        tbgrupo.BackColor = Color.White
        tbcategoria.BackColor = Color.White

    End Sub

    Public Overrides Function _PMOGrabarRegistro() As Boolean


        'ByRef _ygnumi As String, _ygnombre As String, _ygcodigo As String,
        '                                        _ygcategoria As Integer, _ygimg As String, _ygestado As Integer
        Dim res As Boolean = L_fnGrabarSubGrupo(tbCodigoOriginal.Text, tbNombre.Text, tbdesccorta.Text, CodigoCategoria, CodigoGrupo, nameImg, IIf(swEstado.Value = True, 1, 0))


        If res Then
            Modificado = False
            _fnMoverImagenRuta(RutaGlobal + "\Imagenes\Imagenes Categoria", nameImg)
            nameImg = "Default.jpg"

            Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
            ToastNotification.Show(Me, "Código de Grupo ".ToUpper + tbCodigoOriginal.Text + " Grabado con Exito.".ToUpper,
                                      img, 2000,
                                      eToastGlowColor.Green,
                                      eToastPosition.TopCenter
                                      )
            tbNombre.Focus()

        Else
            Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
            ToastNotification.Show(Me, "El Grupo no pudo ser insertado".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)

        End If
        Return res

    End Function

    Public Overrides Function _PMOModificarRegistro() As Boolean
        Dim res As Boolean

        Dim nameImage As String = IIf(IsDBNull(JGrM_Buscador.GetValue("ygimg")), "", JGrM_Buscador.GetValue("ygimg"))
        If (Modificado = False And nameImage <> "") Then

            res = L_fnModificarSubGrupo(tbCodigoOriginal.Text, tbNombre.Text, tbdesccorta.Text, CodigoCategoria, CodigoGrupo, nameImage, IIf(swEstado.Value = True, 1, 0))

        Else

            res = L_fnModificarSubGrupo(tbCodigoOriginal.Text, tbNombre.Text, tbdesccorta.Text, CodigoCategoria, CodigoGrupo, nameImg, IIf(swEstado.Value = True, 1, 0))

        End If
        If res Then

            If (Modificado = True) Then
                _fnMoverImagenRuta(RutaGlobal + "\Imagenes\Imagenes Categoria", nameImg)
                Modificado = False
            End If
            nameImg = "Default.jpg"

            Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
            ToastNotification.Show(Me, "Código de Grupo ".ToUpper + tbCodigoOriginal.Text + " modificado con Exito.".ToUpper,
                                      img, 2000,
                                      eToastGlowColor.Green,
                                      eToastPosition.TopCenter)

        Else
            Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
            ToastNotification.Show(Me, "El Grupo no pudo ser modificado".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)

        End If
        _PMInhabilitar()
        _PMPrimerRegistro()
        Return res
    End Function


    Public Sub _PrEliminarImage(nameimg As String)

        If (Not (_fnActionNuevo()) And (File.Exists(RutaGlobal + "\Imagenes\Imagenes Categoria" + nameimg))) Then
            UsImg.Image.Dispose()
            UsImg.Image = Nothing
            Try
                My.Computer.FileSystem.DeleteFile(RutaGlobal + "\Imagenes\Imagenes Categoria" + nameimg)
            Catch ex As Exception

            End Try


        End If
    End Sub
    Public Function _fnActionNuevo() As Boolean
        Return tbCodigoOriginal.Text = String.Empty And tbdesccorta.ReadOnly = False
    End Function

    Public Overrides Sub _PMOEliminarRegistro()

        Dim ef = New Efecto
        ef.tipo = 2
        ef.Context = "¿esta seguro de eliminar el registro?".ToUpper
        ef.Header = "mensaje principal".ToUpper
        ef.ShowDialog()
        Dim bandera As Boolean = False
        bandera = ef.band
        If (bandera = True) Then
            Dim mensajeError As String = ""
            Dim res As Boolean = L_fnEliminarSubGrupoProducto(tbCodigoOriginal.Text, mensajeError)
            If res Then
                _PrEliminarImage(JGrM_Buscador.GetValue("ygimg"))

                Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)

                ToastNotification.Show(Me, "Código de Grupo ".ToUpper + tbCodigoOriginal.Text + " eliminado con Exito.".ToUpper,
                                          img, 2000,
                                          eToastGlowColor.Green,
                                          eToastPosition.TopCenter)

                _PMFiltrar()
            Else
                Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
                ToastNotification.Show(Me, mensajeError, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            End If
        End If


    End Sub
    Public Overrides Function _PMOValidarCampos() As Boolean
        Dim _ok As Boolean = True
        MEP.Clear()

        If tbNombre.Text = String.Empty Then
            tbNombre.BackColor = Color.Red
            MEP.SetError(tbNombre, "ingrese el nombre de la  Categoria!".ToUpper)
            _ok = False
            Dim img As Bitmap = New Bitmap(My.Resources.mensaje, 50, 50)
            ToastNotification.Show(Me, "Ingrese el nombre de la categoria para efectuar la grabacion".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
        Else
            tbNombre.BackColor = Color.White
            MEP.SetError(tbNombre, "")
        End If
        If tbdesccorta.Text = String.Empty Then
            tbdesccorta.BackColor = Color.Red
            MEP.SetError(tbdesccorta, "ingrese el nombre del campo Codificacion!".ToUpper)
            _ok = False
            Dim img As Bitmap = New Bitmap(My.Resources.mensaje, 50, 50)
            ToastNotification.Show(Me, "Ingrese el nombre de la Codificacion para efectuar la grabacion".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
        Else
            tbdesccorta.BackColor = Color.White
            MEP.SetError(tbdesccorta, "")
        End If
        If CodigoCategoria <= 0 Then
            tbcategoria.BackColor = Color.Red
            MEP.SetError(tbcategoria, "Seleccione una Categoria!".ToUpper)
            _ok = False
            Dim img As Bitmap = New Bitmap(My.Resources.mensaje, 50, 50)
            ToastNotification.Show(Me, "Seleccione una categoria para efectuar la grabacion".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
        Else
            tbcategoria.BackColor = Color.White
            MEP.SetError(tbcategoria, "")
        End If
        If CodigoGrupo <= 0 Then
            tbgrupo.BackColor = Color.Red
            MEP.SetError(tbgrupo, "Seleccione una Categoria!".ToUpper)
            _ok = False
            Dim img As Bitmap = New Bitmap(My.Resources.mensaje, 50, 50)
            ToastNotification.Show(Me, "Seleccione una categoria para efectuar la grabacion".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
        Else
            tbgrupo.BackColor = Color.White
            MEP.SetError(tbgrupo, "")
        End If


        MHighlighterFocus.UpdateHighlights()
        Return _ok
    End Function

    Public Overrides Function _PMOGetTablaBuscador() As DataTable
        Dim dtBuscador As DataTable = L_fnGeneralSubGrupo()
        Return dtBuscador
    End Function

    Public Overrides Function _PMOGetListEstructuraBuscador() As List(Of Modelo.Celda)
        Dim listEstCeldas As New List(Of Modelo.Celda)
        'a.ygnumi ,a.ygnombre ,a.ygcodigo ,a.ygcategoria, libreria .ycdes3 as libreria ,a.ygimg ,a.ygestado ,a.ygfact ,a.yghact ,a.yguact

        listEstCeldas.Add(New Modelo.Celda("ygnumi", True, "Código".ToUpper, 120))
        listEstCeldas.Add(New Modelo.Celda("ygnombre", True, "nombre SubGrupo".ToUpper, 300))
        listEstCeldas.Add(New Modelo.Celda("ygcodigo", True, "Codificacion".ToUpper, 250))
        listEstCeldas.Add(New Modelo.Celda("categoria", True, "Categoria".ToUpper, 200))
        listEstCeldas.Add(New Modelo.Celda("grupo", True, "grupo".ToUpper, 200))
        listEstCeldas.Add(New Modelo.Celda("ygty0051", False))
        listEstCeldas.Add(New Modelo.Celda("ygty0052", False))
        listEstCeldas.Add(New Modelo.Celda("ygimg", False))
        listEstCeldas.Add(New Modelo.Celda("ygestado", True, "Estado".ToUpper, 150))
        listEstCeldas.Add(New Modelo.Celda("ygfact", False))
        listEstCeldas.Add(New Modelo.Celda("yghact", False))
        listEstCeldas.Add(New Modelo.Celda("yguact", False))
        Return listEstCeldas
    End Function

    Public Overrides Sub _PMOMostrarRegistro(_N As Integer)
        JGrM_Buscador.Row = _MPos
        ''a.ygnumi ,a.ygnombre ,a.ygcodigo ,a.ygcategoria, libreria .ycdes3 as libreria ,a.ygimg ,a.ygestado ,a.ygfact ,a.yghact ,a.yguact
        Dim dt As DataTable = CType(JGrM_Buscador.DataSource, DataTable)
        Try
            tbCodigoOriginal.Text = JGrM_Buscador.GetValue("ygnumi").ToString
        Catch ex As Exception
            Exit Sub
        End Try
        With JGrM_Buscador
            tbCodigoOriginal.Text = .GetValue("ygnumi").ToString
            tbNombre.Text = .GetValue("ygnombre")
            tbdesccorta.Text = .GetValue("ygcodigo")
            tbcategoria.Text = .GetValue("categoria")
            tbgrupo.Text = .GetValue("grupo")
            'cbCategoria.Value = .GetValue("ygcategoria")
            lbFecha.Text = CType(.GetValue("ygfact"), Date).ToString("dd/MM/yyyy")
            lbHora.Text = .GetValue("yghact").ToString
            lbUsuario.Text = .GetValue("yguact").ToString
            CodigoCategoria = .GetValue("ygty0051")
            CodigoCategoria = .GetValue("ygty0052")
        End With
        Dim name As String = IIf(IsDBNull(JGrM_Buscador.GetValue("ygimg")), "", JGrM_Buscador.GetValue("ygimg"))
        If name.Equals("Default.jpg") Or Not File.Exists(RutaGlobal + "\Imagenes\Imagenes Categoria" + name) Then

            Dim im As New Bitmap(My.Resources.pantalla)
            UsImg.Image = im
        Else
            If (File.Exists(RutaGlobal + "\Imagenes\Imagenes Categoria" + name)) Then
                Dim Bin As New MemoryStream
                Dim im As New Bitmap(New Bitmap(RutaGlobal + "\Imagenes\Imagenes Categoria" + name))
                im.Save(Bin, System.Drawing.Imaging.ImageFormat.Jpeg)
                UsImg.SizeMode = PictureBoxSizeMode.StretchImage
                UsImg.Image = Image.FromStream(Bin)
                Bin.Dispose()

            End If
        End If

        LblPaginacion.Text = Str(_MPos + 1) + "/" + JGrM_Buscador.RowCount.ToString

    End Sub



    Public Overrides Sub _PMOHabilitarFocus()

        'With MHighlighterFocus
        '    .SetHighlightOnFocus(tbCodigo, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(tbCodProd, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(tbStockMinimo, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(tbCodBarra, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)

        '    .SetHighlightOnFocus(tbDescPro, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(tbDescCort, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(cbgrupo1, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(cbgrupo2, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(cbgrupo3, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(cbgrupo4, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(cbUMed, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(swEstado, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(cbUniVenta, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(cbUnidMaxima, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
        '    .SetHighlightOnFocus(tbConversion, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)


        'End With
    End Sub



    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If btnGrabar.Enabled = True Then
            _PMInhabilitar()
            _PMPrimerRegistro()

        Else
            '  Public _modulo As SideNavItem
            _modulo.Select()
            _tab.Close()
        End If
    End Sub

    Private Sub BtAdicionar_Click(sender As Object, e As EventArgs) Handles BtAdicionar.Click
        _fnCopiarImagenRutaDefinida()
        btnGrabar.Focus()
    End Sub

    Private Sub tbcategoria_TextChanged(sender As Object, e As EventArgs) Handles tbcategoria.TextChanged

    End Sub

    Private Sub tbcategoria_KeyDown(sender As Object, e As KeyEventArgs) Handles tbcategoria.KeyDown
        If (tbNombre.ReadOnly = False) Then
            If e.KeyData = Keys.Control + Keys.Enter Then

                Dim dt As DataTable

                dt = L_fnListarCategoriaGrupo()  ''''Categoria
                'a.ygnumi ,a.ygnombre ,a.ygcodigo ,a.ygimg ,cast('' as image) as img

                Dim listEstCeldas As New List(Of Modelo.Celda)
                listEstCeldas.Add(New Modelo.Celda("ygnumi,", False, "ID", 50))
                listEstCeldas.Add(New Modelo.Celda("ygnombre", True, "NOMBRE", 200))
                listEstCeldas.Add(New Modelo.Celda("ygcodigo", True, "CODIFICACION", 150))
                listEstCeldas.Add(New Modelo.Celda("ygimg", False, "NOMBRE", 280))
                listEstCeldas.Add(New Modelo.Celda("img", True, "Imagen".ToUpper, 200, ""))
                Dim ef = New Efecto
                ef.tipo = 5
                ef.dt = dt
                ef.SeleclCol = 2
                ef.listEstCeldas = listEstCeldas
                ef.alto = 50
                ef.ancho = 350
                ef.Context = "Seleccione CATEGORIA".ToUpper
                ef.ShowDialog()
                Dim bandera As Boolean = False
                bandera = ef.band
                If (bandera = True) Then
                    Dim Row As Janus.Windows.GridEX.GridEXRow = ef.Row
                    Dim Bin As New MemoryStream

                    CodigoCategoria = Row.Cells("ygnumi").Value
                    tbcategoria.Text = Row.Cells("ygnombre").Value + " - " + Row.Cells("ygcodigo").Value
                    Dim nameImagen = Row.Cells("ygimg").Value


                    If (nameImagen.Equals("Default.jpg")) Then

                        ImgCategoria.Visible = False
                    Else

                        If (File.Exists(RutaGlobal + "\Imagenes\Imagenes Categoria" + nameImagen)) Then
                            ImgCategoria.Visible = True
                            ImgCategoria.pbImage.Image = Row.Cells("img").Value
                            ImgCategoria.pbImage.Tag = RutaGlobal + "\Imagenes\Imagenes Categoria" + nameImagen
                        Else
                            ImgCategoria.Visible = False

                        End If
                    End If



                End If
            End If
        End If
    End Sub

    Private Sub F1_SubGrupo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub

    Private Sub tbgrupo_KeyDown(sender As Object, e As KeyEventArgs) Handles tbgrupo.KeyDown
        If (tbNombre.ReadOnly = False) Then

            If (CodigoCategoria <= 0) Then
                Dim img As Bitmap = New Bitmap(My.Resources.mensaje, 50, 50)
                ToastNotification.Show(Me, "Seleccione una categoria para poder seleccionar grupo".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
                tbcategoria.Focus()
                Return
            End If

            If e.KeyData = Keys.Control + Keys.Enter Then

                    Dim dt As DataTable

                dt = L_fnListarGrupoPorCategoria(CodigoCategoria)  ''''Categoria
                'a.ygnumi ,a.ygnombre ,a.ygcodigo ,a.ygimg ,cast('' as image) as img

                Dim listEstCeldas As New List(Of Modelo.Celda)
                    listEstCeldas.Add(New Modelo.Celda("ygnumi,", False, "ID", 50))
                    listEstCeldas.Add(New Modelo.Celda("ygnombre", True, "NOMBRE", 200))
                    listEstCeldas.Add(New Modelo.Celda("ygcodigo", True, "CODIFICACION", 150))
                    listEstCeldas.Add(New Modelo.Celda("ygimg", False, "NOMBRE", 280))
                    listEstCeldas.Add(New Modelo.Celda("img", True, "Imagen".ToUpper, 200, ""))
                    Dim ef = New Efecto
                    ef.tipo = 5
                    ef.dt = dt
                    ef.SeleclCol = 2
                    ef.listEstCeldas = listEstCeldas
                    ef.alto = 50
                    ef.ancho = 350
                ef.Context = "Seleccione Grupo".ToUpper
                ef.ShowDialog()
                    Dim bandera As Boolean = False
                    bandera = ef.band
                    If (bandera = True) Then
                        Dim Row As Janus.Windows.GridEX.GridEXRow = ef.Row
                        Dim Bin As New MemoryStream

                    CodigoGrupo = Row.Cells("ygnumi").Value
                    tbgrupo.Text = Row.Cells("ygnombre").Value + " - " + Row.Cells("ygcodigo").Value
                    Dim nameImagen = Row.Cells("ygimg").Value


                        If (nameImagen.Equals("Default.jpg")) Then

                        ImgGrupo.Visible = False
                    Else

                            If (File.Exists(RutaGlobal + "\Imagenes\Imagenes Categoria" + nameImagen)) Then
                            ImgGrupo.Visible = True
                            ImgGrupo.pbImage.Image = Row.Cells("img").Value
                            ImgGrupo.pbImage.Tag = RutaGlobal + "\Imagenes\Imagenes Categoria" + nameImagen
                        Else
                            ImgGrupo.Visible = False

                        End If
                        End If



                    End If
                End If
            End If
    End Sub





#End Region
End Class
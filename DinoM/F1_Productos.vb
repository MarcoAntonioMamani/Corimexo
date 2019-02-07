
Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Imports Janus.Windows.GridEX
Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid
Imports DevComponents.DotNetBar.Controls

Public Class F1_Productos

#Region "Variables Locales"
    Dim RutaGlobal As String = gs_CarpetaRaiz
    Dim RutaTemporal As String = "C:\Temporal"
    Dim Modificado As Boolean = False
    Dim PosicionFinal As Integer = -1
    Dim nameImg As String = "Default.jpg"
    Public _nameButton As String
    Public _tab As SuperTabItem
    Public _modulo As SideNavItem
    Public Limpiar As Boolean = False  'Bandera para indicar si limpiar todos los datos o mantener datos ya registrados
    Public TablaImagenes As DataTable
    Dim Modificar As Boolean = False
    Dim posImg As Integer = 0

    '''Variable de Categoria
    Dim CbCategoria As Integer = 0
    Dim CodCategoria As String = ""
    Dim CbGrupo As Integer = 0
    Dim CodGrupo As String = ""
    Dim CbProducto As Integer = 0
    Dim CodProducto As String = ""
    Dim CbEstructura As Integer = 0
    Dim CodEstructura As String = ""
    Dim CbSubgrupo As Integer = 0
    Dim CodSubGrupo As String = ""
    Dim CbClase As Integer = 0
    Dim CodClase As String = ""

#End Region
#Region "Metodos Privados"
    Private Sub _prIniciarTodo()
        Me.Text = "PRODUCTOS"
        'L_prAbrirConexion(gs_Ip, gs_UsuarioSql, gs_ClaveSql, gs_NombreBD)
        _prMaxLength()
        _prAsignarPermisos()
        tbNombre.ReadOnly = True
        _PMIniciarTodo()
        Dim blah As New Bitmap(New Bitmap(My.Resources.producto), 20, 20)
        Dim ico As Icon = Icon.FromHandle(blah.GetHicon())
        Me.Icon = ico
        ButtonX2.Visible = False
        ButtonX1.Visible = True
        tbNombre.BackColor = Color.White
        tbnombre.BackColor = Color.White
    End Sub

    Public Sub _prCargarImagen()

        panelA.Controls.Clear()

        panelA.Size = panelA.Size
        Dim rutImg As String
        Dim elemImg As UCItemImg
        Dim estado As Integer
        Dim bm As Bitmap
        Dim by As Byte()
        Dim ms As MemoryStream
        pbImgProdu.Image = Nothing
        posImg = -1

        Dim i As Integer = 0
        For Each fila As DataRow In TablaImagenes.Rows
            elemImg = New UCItemImg
            rutImg = fila.Item("ieimg").ToString
            estado = fila.Item("estado")
            If (estado = 0) Then
                elemImg.pbJpg.SizeMode = PictureBoxSizeMode.StretchImage
                bm = Nothing
                by = fila.Item("img")
                ms = New MemoryStream(by)
                bm = New Bitmap(ms)
                elemImg.pbJpg.Image = bm
                pbImgProdu.SizeMode = PictureBoxSizeMode.StretchImage
                pbImgProdu.Image = bm
                elemImg.pbJpg.Tag = i
                elemImg.Dock = DockStyle.Top
                pbImgProdu.Tag = i
                AddHandler elemImg.pbJpg.MouseEnter, AddressOf pbImg_MouseEnter
                elemImg.Height = panelA.Height / 6
                panelA.Controls.Add(elemImg)
            Else
                If (estado = 1) Then
                    If (File.Exists(RutaGlobal + "\Imagenes\Imagenes ProductoDino\" + "Producto_" + tbCodigo.Text + rutImg)) Then
                        bm = New Bitmap(RutaGlobal + "\Imagenes\Imagenes ProductoDino\" + "Producto_" + tbCodigo.Text + rutImg)
                        elemImg.pbJpg.SizeMode = PictureBoxSizeMode.StretchImage
                        elemImg.pbJpg.Image = bm
                        pbImgProdu.SizeMode = PictureBoxSizeMode.StretchImage
                        pbImgProdu.Image = bm
                        elemImg.pbJpg.Tag = i
                        elemImg.Dock = DockStyle.Top
                        pbImgProdu.Tag = i
                        AddHandler elemImg.pbJpg.MouseEnter, AddressOf pbImg_MouseEnter
                        elemImg.Height = panelA.Height / 6
                        panelA.Controls.Add(elemImg)


                    End If

                End If
            End If




            i += 1
        Next
        If (tbnombre.ReadOnly = False) Then
            Dim elemImgAdd As UCItemImg = New UCItemImg

            Dim imgadd As Bitmap = New Bitmap(My.Resources.addimg)
            elemImgAdd.pbJpg.SizeMode = PictureBoxSizeMode.StretchImage
            elemImgAdd.pbJpg.Image = imgadd
            elemImgAdd.Dock = DockStyle.Top
            AddHandler elemImgAdd.pbJpg.Click, AddressOf pbJpg_MouseClick
            elemImgAdd.Height = panelA.Height / 6
            panelA.Controls.Add(elemImgAdd)
        End If
        If (tbnombre.ReadOnly = False And _fnObtenerNumeroFilasActivas() < 0) Then
            btDeleteImg.Visible = False
        Else
            If (tbnombre.ReadOnly = False) Then
                btDeleteImg.Visible = True
            End If


        End If



    End Sub
    Public Function _fnObtenerNumeroFilasActivas() As Integer
        Dim n As Integer = -1
        For i As Integer = 0 To TablaImagenes.Rows.Count - 1 Step 1
            Dim estado As Integer = TablaImagenes.Rows(i).Item("estado")
            If (estado = 0 Or estado = 1) Then
                n += 1

            End If
        Next
        Return n
    End Function
    Private Sub pbJpg_MouseClick(sender As Object, e As EventArgs)

        _fnCopiarImagenRutaDefinida()
        _prCargarImagen()

    End Sub
    Private Sub pbImgProdu_MouseClick(sender As Object, e As MouseEventArgs) Handles pbImgProdu.MouseClick
        Dim posicion As Integer = pbImgProdu.Tag
        Dim estado As Integer = TablaImagenes.Rows(posicion).Item("estado")
        If (estado = 1) Then
            Dim rutaOriginal As String = RutaGlobal + "\Imagenes\Imagenes ProductoDino\" + "Producto_" + tbCodigo.Text + TablaImagenes.Rows(posicion).Item("ieimg")
            If (File.Exists(rutaOriginal)) Then
                Shell("rundll32.exe C:\WINDOWS\system32\shimgvw.dll,ImageView_Fullscreen " + rutaOriginal)
            End If
        End If

    End Sub
    Private Sub pbImg_MouseEnter(sender As Object, e As EventArgs)
        Dim pb As PictureBox = CType(sender, PictureBox)
        pbImgProdu.Image = pb.Image
        pbImgProdu.Tag = pb.Tag

    End Sub
    Public Sub _prStyleJanus()
        GroupPanelBuscador.Style.BackColor = Color.FromArgb(13, 71, 161)
        GroupPanelBuscador.Style.BackColor2 = Color.FromArgb(13, 71, 161)
        GroupPanelBuscador.Style.TextColor = Color.White
        JGrM_Buscador.RootTable.HeaderFormatStyle.FontBold = TriState.True
    End Sub

    Public Sub _prMaxLength()

        tbnombre.MaxLength = 150

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
    Private Sub _prEliminarCarpeta(Ruta As String)

        If System.IO.Directory.Exists(Ruta) = True Then


            Try

                My.Computer.FileSystem.DeleteDirectory(Ruta, FileIO.DeleteDirectoryOption.DeleteAllContents)

            Catch ex As Exception

            End Try

        End If

    End Sub
    Private Sub _prCrearCarpetaImagenes()
        Dim rutaDestino As String = RutaGlobal + "\Imagenes\Imagenes ProductoDino\"

        If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes ProductoDino\") = False Then
            If System.IO.Directory.Exists(RutaGlobal + "\Imagenes") = False Then
                System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes")
                If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes ProductoDino") = False Then
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes ProductoDino")
                End If
            Else
                If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes ProductoDino") = False Then
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes ProductoDino")

                End If
            End If
        End If
    End Sub

    Private Sub _prCrearCarpetaImagenes(carpetaFinal As String)
        Dim rutaDestino As String = RutaGlobal + "\Imagenes\Imagenes ProductoDino\" + carpetaFinal + "\"

        If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes ProductoDino\" + carpetaFinal) = False Then
            If System.IO.Directory.Exists(RutaGlobal + "\Imagenes") = False Then
                System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes")
                If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes ProductoDino") = False Then
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes ProductoDino")
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes ProductoDino\" + carpetaFinal + "\")
                End If
            Else
                If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes ProductoDino") = False Then
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes ProductoDino")
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes ProductoDino\" + carpetaFinal + "\")
                Else
                    If System.IO.Directory.Exists(RutaGlobal + "\Imagenes\Imagenes ProductoDino\" + carpetaFinal) = False Then
                        System.IO.Directory.CreateDirectory(RutaGlobal + "\Imagenes\Imagenes ProductoDino\" + carpetaFinal + "\")
                    End If

                End If
            End If
        End If
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
            Dim nombre As String = ""

            If file.CheckFileExists = True Then
                Dim img As New Bitmap(New Bitmap(ruta))
                Dim a As Object = file.GetType.ToString

                Dim da As String = Str(Now.Day).Trim + Str(Now.Month).Trim + Str(Now.Year).Trim + Str(Now.Hour) + Str(Now.Minute) + Str(Now.Second)

                nombre = "\Imagen_" + da + ".jpg".Trim


                If (_fnActionNuevo()) Then
                    Dim mstream = New MemoryStream()

                    img.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)

                    TablaImagenes.Rows.Add(0, 0, nombre, mstream.ToArray(), 0)
                    mstream.Dispose()

                Else
                    Dim mstream = New MemoryStream()

                    img.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)

                    'a.ienumi , a.ienumiti4, a.ieimg, Cast(null As image) As img, 1 as estado
                    TablaImagenes.Rows.Add(0, tbCodigo.Text, nombre, mstream.ToArray(), 0)
                    mstream.Dispose()

                End If

                'img.Save(RutaTemporal + nombre, System.Drawing.Imaging.ImageFormat.Jpeg)
            End If
            Return nombre
        End If

        Return "default.jpg"
    End Function

    Public Sub _prGuardarImagenes(_ruta As String)
        panelA.Controls.Clear()


        For i As Integer = 0 To TablaImagenes.Rows.Count - 1 Step 1
            Dim estado As Integer = TablaImagenes.Rows(i).Item("estado")
            If (estado = 0) Then

                Dim bm As Bitmap = Nothing
                Dim by As Byte() = TablaImagenes.Rows(i).Item("img")
                Dim ms As New MemoryStream(by)
                bm = New Bitmap(ms)
                Try
                    bm.Save(_ruta + TablaImagenes.Rows(i).Item("ieimg"), System.Drawing.Imaging.ImageFormat.Jpeg)
                Catch ex As Exception

                End Try




            End If
            If (estado = -1) Then
                Try
                    Me.pbImgProdu.Image.Dispose()
                    Me.pbImgProdu.Image = Nothing
                    Application.DoEvents()
                    TablaImagenes.Rows(i).Item("img") = Nothing



                    If (File.Exists(_ruta + TablaImagenes.Rows(i).Item("ieimg"))) Then
                        My.Computer.FileSystem.DeleteFile(_ruta + TablaImagenes.Rows(i).Item("ieimg"))
                    End If

                Catch ex As Exception

                End Try
            End If
        Next
    End Sub

    Private Sub _prCrearCarpetaReportes()
        Dim rutaDestino As String = RutaGlobal + "\Reporte\Reporte Productos\"

        If System.IO.Directory.Exists(RutaGlobal + "\Reporte\Reporte Productos\") = False Then
            If System.IO.Directory.Exists(RutaGlobal + "\Reporte") = False Then
                System.IO.Directory.CreateDirectory(RutaGlobal + "\Reporte")
                If System.IO.Directory.Exists(RutaGlobal + "\Reporte\Reporte Productos") = False Then
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Reporte\Reporte Productos")
                End If
            Else
                If System.IO.Directory.Exists(RutaGlobal + "\Reporte\Reporte Productos") = False Then
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Reporte\Reporte Productos")

                End If
            End If
        End If
    End Sub

#End Region
#Region "METODOS SOBRECARGADOS"

    Public Overrides Sub _PMOHabilitar()

        swEstado.IsReadOnly = False
        tbnombre.ReadOnly = False
        tbnombre.ReadOnly = False
        _prCrearCarpetaImagenes()
        _prCrearCarpetaTemporal()

        tbStockMinimo.IsInputReadOnly = False
        btExcel.Visible = False
        btnImprimir.Visible = False

        Modificar = True
        btDeleteImg.Visible = True
        _prCargarImagen()
        ButtonX2.Visible = False
        ButtonX1.Visible = False
    End Sub

    Public Overrides Sub _PMOInhabilitar()
        Modificado = False
        tbcategoria.ReadOnly = True
        tbgrupo.ReadOnly = True
        tbnombre.ReadOnly = True
        tbnombre.ReadOnly = True
        tbproducto.ReadOnly = True
        tbestructura.ReadOnly = True
        tbsubgrupo.ReadOnly = True
        tbclase.ReadOnly = True
        swEstado.IsReadOnly = True

        tbStockMinimo.IsInputReadOnly = True
        _prStyleJanus()
        JGrM_Buscador.Focus()
        Limpiar = False
        btExcel.Visible = True
        btnImprimir.Visible = True
        tbCodauto.ReadOnly = True
        btDeleteImg.Visible = False

        ButtonX2.Visible = False
        ButtonX1.Visible = True
    End Sub

    Public Overrides Sub _PMOLimpiar()
        tbCodigo.Clear()
        TablaImagenes = L_prCargarImagenes(-1)
        _prCargarImagen()
        Modificar = True
        tbnombre.Clear()
        tbnombre.Clear()
        CbCategoria = 0
        CbGrupo = 0
        CbProducto = 0
        CbEstructura = 0
        CbSubgrupo = 0
        CbClase = 0

        CodCategoria = ""
        CodGrupo = ""
        CodProducto = ""
        CodEstructura = ""
        CodSubGrupo = ""
        CodClase = ""

        ImgCategoria.Visible = False
        ImgGrupo.Visible = False
        ImgProducto.Visible = False
        ImgEstructura.Visible = False
        ImgSubGrupo.Visible = False
        ImgClase.Visible = False

        tbCodauto.Clear()
        tbcategoria.Clear()
        tbgrupo.Clear()
        tbproducto.Clear()
        tbestructura.Clear()
        tbsubgrupo.Clear()
        tbclase.Clear()
        tbnombre.Focus()
    End Sub
    Public Sub _prSeleccionarCombo(mCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo)
        If (CType(mCombo.DataSource, DataTable).Rows.Count > 0) Then
            mCombo.SelectedIndex = 0
        Else
            mCombo.SelectedIndex = -1
        End If
    End Sub


    Public Overrides Sub _PMOLimpiarErrores()
        MEP.Clear()

        cbgrupo1.BackColor = Color.White
        cbgrupo2.BackColor = Color.White
        cbgrupo3.BackColor = Color.White
        cbgrupo4.BackColor = Color.White
    End Sub

    Public Overrides Function _PMOGrabarRegistro() As Boolean

        'ByRef _yfnumi As String, _yfcprod As String,
        '                                      _yfcbarra As String, _yfcdprod1 As String,
        '                                      _yfcdprod2 As String, _yfgr1 As Integer, _yfgr2 As Integer,
        '                                      _yfgr3 As Integer, _yfgr4 As Integer, _yfMed As Integer, _yfumin As Integer,
        '_yfusup As Integer, _yfvsup As Double, _yfsmin As Integer, _yfap As Integer, _yfimg As String
        'Dim CbCategoria As Integer = 0  _yfgr1
        'Dim CbGrupo As Integer = 0  _yfgr2
        'Dim CbProducto As Integer = 0  _yfgr3
        'Dim CbEstructura As Integer = 0  _yfgr4
        'Dim CbSubgrupo As Integer = 0  _yfMed
        'Dim CbClase As Integer = 0  _yfuMin

        Dim res As Boolean = L_fnGrabarProducto(tbCodigo.Text, CodCategoria + "." + CodGrupo + "." + CodProducto + "." + CodEstructura + "." + CodSubGrupo + "." + CodClase, "", tbnombre.Text, tbdesc.Text, CbCategoria, CbGrupo, CbProducto, CbEstructura, CbSubgrupo, CbClase, 0, 0, IIf(tbStockMinimo.Text = String.Empty, 0, tbStockMinimo.Text), IIf(swEstado.Value = True, 1, 0), nameImg, TablaImagenes)


        If res Then


            Modificado = False
            _prCrearCarpetaImagenes("Producto_" + tbCodigo.Text.Trim)
            nameImg = "Default.jpg"
            _prGuardarImagenes(RutaGlobal + "\Imagenes\Imagenes ProductoDino\" + "Producto_" + tbCodigo.Text.Trim + "\")
            Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
            ToastNotification.Show(Me, "Código de Producto ".ToUpper + tbCodigo.Text + " Grabado con Exito.".ToUpper,
                                      img, 2000,
                                      eToastGlowColor.Green,
                                      eToastPosition.TopCenter
                                      )
            tbCodigo.Focus()
            Limpiar = True
        Else
            Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
            ToastNotification.Show(Me, "El producto no pudo ser insertado".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)

        End If
        Return res

    End Function

    Public Overrides Function _PMOModificarRegistro() As Boolean
        Dim res As Boolean

        Dim nameImage As String = JGrM_Buscador.GetValue("yfimg")

        res = L_fnModificarProducto(tbCodigo.Text, CodCategoria + "." + CodGrupo + "." + CodProducto + "." + CodEstructura + "." + CodSubGrupo + "." + CodClase, "", tbnombre.Text, tbdesc.Text, CbCategoria, CbGrupo, CbProducto, CbEstructura, CbSubgrupo, CbClase, 0, 0, IIf(tbStockMinimo.Text = String.Empty, 0, tbStockMinimo.Text), IIf(swEstado.Value = True, 1, 0), nameImg, TablaImagenes)

        If res Then
            Modificar = False
            _prCrearCarpetaImagenes("Producto_" + tbCodigo.Text.Trim)

            _prGuardarImagenes(RutaGlobal + "\Imagenes\Imagenes ProductoDino\" + "Producto_" + tbCodigo.Text.Trim + "\")


            Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
            ToastNotification.Show(Me, "Código de Producto ".ToUpper + tbCodigo.Text + " modificado con Exito.".ToUpper,
                                      img, 2000,
                                      eToastGlowColor.Green,
                                      eToastPosition.TopCenter)

        Else
            Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
            ToastNotification.Show(Me, "EL producto no pudo ser modificado".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)

        End If
        _PMInhabilitar()
        _PMPrimerRegistro()
        Return res
    End Function

    Public Function _fnActionNuevo() As Boolean
        Return tbCodigo.Text = String.Empty And tbnombre.ReadOnly = False
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
            Dim res As Boolean = L_fnEliminarProducto(tbCodigo.Text, mensajeError)
            If res Then
                _prEliminarCarpeta(RutaGlobal + "\Imagenes\Imagenes ProductoDino\" + "Activo_" + tbCodigo.Text.Trim)

                Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)

                ToastNotification.Show(Me, "Código de Producto ".ToUpper + tbCodigo.Text + " eliminado con Exito.".ToUpper,
                                          img, 2000,
                                          eToastGlowColor.Green,
                                          eToastPosition.TopCenter)

                _PMFiltrar()
            Else
                Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
                ToastNotification.Show(Me, mensajeError, img, 3000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            End If
        End If


    End Sub
    Public Overrides Function _PMOValidarCampos() As Boolean
        Dim _ok As Boolean = True
        MEP.Clear()

        If tbnombre.Text = String.Empty Then
            tbnombre.BackColor = Color.Red
            AddHandler tbnombre.KeyDown, AddressOf TextBox_KeyDown
            MEP.SetError(tbnombre, "ingrese el descripcion del producto!".ToUpper)
            _ok = False
        Else
            tbnombre.BackColor = Color.White
            MEP.SetError(tbnombre, "")
        End If
        'If tbDescCort.Text = String.Empty Then
        '    tbDescCort.BackColor = Color.Red
        '    MEP.SetError(tbDescCort, "ingrese la Descripcion Corta del Producto!".ToUpper)
        '    AddHandler tbDescCort.KeyDown, AddressOf TextBox_KeyDown
        '    _ok = False
        'Else
        '    tbDescCort.BackColor = Color.White
        '    MEP.SetError(tbDescCort, "")
        'End If

        MHighlighterFocus.UpdateHighlights()
        Return _ok
    End Function

    Public Overrides Function _PMOGetTablaBuscador() As DataTable
        Dim dtBuscador As DataTable = L_fnGeneralProductos()
        Return dtBuscador
    End Function

    Public Overrides Function _PMOGetListEstructuraBuscador() As List(Of Modelo.Celda)
        Dim listEstCeldas As New List(Of Modelo.Celda)
        '      a.yfnumi , a.yfcprod, a.yfcbarra, a.yfcdprod1, a.yfcdprod2, a.yfgr1, gr1.ygnombre  As grupo1,
        '      gr1.ygcodigo as codigo1, gr1.ygimg As img1, a.yfgr2
        ',gr2.ygnombre  as grupo2,gr2.ygcodigo as codigo2, gr2.ygimg as img2 ,a.yfgr3,gr3.ygnombre  as grupo3,
        'gr3.ygcodigo as codigo3 , gr3.ygimg As img3, a.yfgr4, gr4.ygnombre  As grupo4,
        '      gr4.ygcodigo as codigo4 , gr4.ygimg As img4,
        '      a.yfMed , gr5.ygnombre  As Umedida, gr5.ygcodigo As codigo5 , gr5.ygimg As img5, a.yfumin, gr6.ygnombre  as UnidMin
        ',gr6.ygcodigo as codigo6 , gr6.ygimg as img6,a.yfusup ,'' as Umax
        ',a.yfvsup ,a.yfmstk ,a.yfclot 
        ',a.yfsmin ,cast(a.yfap as bit) as yfap,a.yfimg ,a.yffact ,a.yfhact ,a.yfuact  
        listEstCeldas.Add(New Modelo.Celda("yfnumi", False, "Código".ToUpper, 80))
        listEstCeldas.Add(New Modelo.Celda("yfcprod", True, "Codificacion".ToUpper, 200))
        listEstCeldas.Add(New Modelo.Celda("yfcbarra", False))
        listEstCeldas.Add(New Modelo.Celda("yfcdprod1", True, "Descripcion Producto".ToUpper, 300))
        listEstCeldas.Add(New Modelo.Celda("yfcdprod2", False, "Descripcion Corta".ToUpper, 170))

        listEstCeldas.Add(New Modelo.Celda("yfgr1", False))
        listEstCeldas.Add(New Modelo.Celda("grupo1", True, "Categoria", 120))
        listEstCeldas.Add(New Modelo.Celda("codigo1", False))
        listEstCeldas.Add(New Modelo.Celda("img1", False))


        listEstCeldas.Add(New Modelo.Celda("yfgr2", False))
        listEstCeldas.Add(New Modelo.Celda("grupo2", True, "Grupo", 120))
        listEstCeldas.Add(New Modelo.Celda("codigo2", False))
        listEstCeldas.Add(New Modelo.Celda("img2", False))

        listEstCeldas.Add(New Modelo.Celda("yfgr3", False))
        listEstCeldas.Add(New Modelo.Celda("grupo3", True, "Producto", 120))
        listEstCeldas.Add(New Modelo.Celda("codigo3", False))
        listEstCeldas.Add(New Modelo.Celda("img3", False))

        listEstCeldas.Add(New Modelo.Celda("yfgr4", False))
        listEstCeldas.Add(New Modelo.Celda("grupo4", True, "Estructura", 120))
        listEstCeldas.Add(New Modelo.Celda("codigo4", False))
        listEstCeldas.Add(New Modelo.Celda("img4", False))

        listEstCeldas.Add(New Modelo.Celda("yfMed", False))
        listEstCeldas.Add(New Modelo.Celda("grupo5", True, "SubGrupo", 120))
        listEstCeldas.Add(New Modelo.Celda("codigo5", False))
        listEstCeldas.Add(New Modelo.Celda("img5", False))

        listEstCeldas.Add(New Modelo.Celda("yfumin", False))
        listEstCeldas.Add(New Modelo.Celda("grupo6", True, "Clase", 120))
        listEstCeldas.Add(New Modelo.Celda("codigo6", False))
        listEstCeldas.Add(New Modelo.Celda("img6", False))

        listEstCeldas.Add(New Modelo.Celda("yfusup", False))
        listEstCeldas.Add(New Modelo.Celda("yfvsup", False))
        listEstCeldas.Add(New Modelo.Celda("yfmstk", False))
        listEstCeldas.Add(New Modelo.Celda("yfclot", False))
        listEstCeldas.Add(New Modelo.Celda("yfsmin", False))
        listEstCeldas.Add(New Modelo.Celda("yfap", False))
        listEstCeldas.Add(New Modelo.Celda("yfimg", False))
        listEstCeldas.Add(New Modelo.Celda("yffact", False))
        listEstCeldas.Add(New Modelo.Celda("yfhact", False))
        listEstCeldas.Add(New Modelo.Celda("yfuact", False))
        listEstCeldas.Add(New Modelo.Celda("Umax", False))

        'listEstCeldas.Add(New Modelo.Celda("Umedida", False, "UMedida".ToUpper, 150))
        'listEstCeldas.Add(New Modelo.Celda("UnidMin", False, "UniVenta".ToUpper, 150))
        'listEstCeldas.Add(New Modelo.Celda("Umax", False, "UniMaxima".ToUpper, 150))

        Return listEstCeldas
    End Function

    Public Overrides Sub _PMOMostrarRegistro(_N As Integer)
        JGrM_Buscador.Row = _MPos
        '      a.yfnumi , a.yfcprod, a.yfcbarra, a.yfcdprod1, a.yfcdprod2, a.yfgr1, gr1.ygnombre  As grupo1,
        '      gr1.ygcodigo as codigo1, gr1.ygimg As img1, a.yfgr2
        ',gr2.ygnombre  as grupo2,gr2.ygcodigo as codigo2, gr2.ygimg as img2 ,a.yfgr3,gr3.ygnombre  as grupo3,
        'gr3.ygcodigo as codigo3 , gr3.ygimg As img3, a.yfgr4, gr4.ygnombre  As grupo4,
        '      gr4.ygcodigo as codigo4 , gr4.ygimg As img4,
        '      a.yfMed , gr5.ygnombre  As Umedida, gr5.ygcodigo As codigo5 , gr5.ygimg As img5, a.yfumin, gr6.ygnombre  as UnidMin
        ',gr6.ygcodigo as codigo6 , gr6.ygimg as img6,a.yfusup ,'' as Umax
        ',a.yfvsup ,a.yfmstk ,a.yfclot 
        ',a.yfsmin ,cast(a.yfap as bit) as yfap,a.yfimg ,a.yffact ,a.yfhact ,a.yfuact 

        If (PosicionFinal <> _MPos) Then
            Dim dt As DataTable = CType(JGrM_Buscador.DataSource, DataTable)
            Try
                tbCodigo.Text = JGrM_Buscador.GetValue("yfnumi").ToString
            Catch ex As Exception
                Exit Sub
            End Try
            With JGrM_Buscador
                tbCodigo.Text = .GetValue("yfnumi").ToString
                tbnombre.Text = .GetValue("yfcdprod1").ToString
                tbdesc.Text = .GetValue("yfcdprod2").ToString
                tbCodauto.Text = .GetValue("yfcprod").ToString
                tbStockMinimo.Text = .GetValue("yfsmin")
                swEstado.Value = .GetValue("yfap")
                lbFecha.Text = CType(.GetValue("yffact"), Date).ToString("dd/MM/yyyy")
                lbHora.Text = .GetValue("yfhact").ToString
                lbUsuario.Text = .GetValue("yfuact").ToString
                TablaImagenes = L_prCargarImagenes(.GetValue("yfnumi"))
            End With
            _prCargarImagen()
            _prCargarGrupos()
            PosicionFinal = _MPos
            LblPaginacion.Text = Str(_MPos + 1) + "/" + JGrM_Buscador.RowCount.ToString
        Else
            PosicionFinal = -1
        End If




    End Sub
    Public Sub _prCargarGrupos()
        '      a.yfnumi , a.yfcprod, a.yfcbarra, a.yfcdprod1, a.yfcdprod2, a.yfgr1, gr1.ygnombre  As grupo1,
        '      gr1.ygcodigo as codigo1, gr1.ygimg As img1, a.yfgr2
        ',gr2.ygnombre  as grupo2,gr2.ygcodigo as codigo2, gr2.ygimg as img2 ,a.yfgr3,gr3.ygnombre  as grupo3,
        'gr3.ygcodigo as codigo3 , gr3.ygimg As img3, a.yfgr4, gr4.ygnombre  As grupo4,
        '      gr4.ygcodigo as codigo4 , gr4.ygimg As img4,
        '      a.yfMed , gr5.ygnombre  As Umedida, gr5.ygcodigo As codigo5 , gr5.ygimg As img5, a.yfumin, gr6.ygnombre  as UnidMin
        ',gr6.ygcodigo as codigo6 , gr6.ygimg as img6,a.yfusup ,'' as Umax
        ',a.yfvsup ,a.yfmstk ,a.yfclot 
        ',a.yfsmin ,cast(a.yfap as bit) as yfap,a.yfimg ,a.yffact ,a.yfhact ,a.yfuact 
        tbcategoria.Text = JGrM_Buscador.GetValue("grupo1").ToString
        CodCategoria = JGrM_Buscador.GetValue("codigo1").ToString
        CbCategoria = JGrM_Buscador.GetValue("yfgr1")
        Dim img1 As String = JGrM_Buscador.GetValue("img1").ToString
        If (File.Exists(RutaGlobal + "\Imagenes\Imagenes Categoria" + img1)) Then
            ImgCategoria.Visible = True
            Dim Bin As New MemoryStream
            Dim im As New Bitmap(New Bitmap(RutaGlobal + "\Imagenes\Imagenes Categoria" + img1))
            im.Save(Bin, System.Drawing.Imaging.ImageFormat.Jpeg)
            ImgCategoria.pbImage.SizeMode = PictureBoxSizeMode.StretchImage
            ImgCategoria.pbImage.SizeMode = PictureBoxSizeMode.StretchImage
            ImgCategoria.pbImage.Image = Image.FromStream(Bin)
            Bin.Dispose()
            ImgCategoria.pbImage.Tag = RutaGlobal + "\Imagenes\Imagenes Categoria" + img1
        Else
            ImgCategoria.Visible = False

        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        tbgrupo.Text = JGrM_Buscador.GetValue("grupo2").ToString
        CodGrupo = JGrM_Buscador.GetValue("codigo2").ToString
        CbGrupo = JGrM_Buscador.GetValue("yfgr2")
        Dim img2 As String = JGrM_Buscador.GetValue("img2").ToString
        If (File.Exists(RutaGlobal + "\Imagenes\Imagenes Categoria" + img2)) Then
            ImgGrupo.Visible = True
            Dim Bin As New MemoryStream
            Dim im As New Bitmap(New Bitmap(RutaGlobal + "\Imagenes\Imagenes Categoria" + img2))
            im.Save(Bin, System.Drawing.Imaging.ImageFormat.Jpeg)
            ImgGrupo.pbImage.SizeMode = PictureBoxSizeMode.StretchImage
            ImgGrupo.pbImage.SizeMode = PictureBoxSizeMode.StretchImage
            ImgGrupo.pbImage.Image = Image.FromStream(Bin)
            Bin.Dispose()
            ImgGrupo.pbImage.Tag = RutaGlobal + "\Imagenes\Imagenes Categoria" + img2
        Else
            ImgGrupo.Visible = False

        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        tbproducto.Text = JGrM_Buscador.GetValue("grupo3").ToString
        CodProducto = JGrM_Buscador.GetValue("codigo3").ToString
        CbProducto = JGrM_Buscador.GetValue("yfgr3")
        Dim img3 As String = JGrM_Buscador.GetValue("img3").ToString
        If (File.Exists(RutaGlobal + "\Imagenes\Imagenes Categoria" + img3)) Then
            ImgProducto.Visible = True
            Dim Bin As New MemoryStream
            Dim im As New Bitmap(New Bitmap(RutaGlobal + "\Imagenes\Imagenes Categoria" + img3))
            im.Save(Bin, System.Drawing.Imaging.ImageFormat.Jpeg)
            ImgProducto.pbImage.SizeMode = PictureBoxSizeMode.StretchImage
            ImgProducto.pbImage.SizeMode = PictureBoxSizeMode.StretchImage
            ImgProducto.pbImage.Image = Image.FromStream(Bin)
            Bin.Dispose()
            ImgProducto.pbImage.Tag = RutaGlobal + "\Imagenes\Imagenes Categoria" + img3
        Else
            ImgProducto.Visible = False

        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        tbestructura.Text = JGrM_Buscador.GetValue("grupo4").ToString
        CodEstructura = JGrM_Buscador.GetValue("codigo4").ToString
        CbEstructura = JGrM_Buscador.GetValue("yfgr4")
        Dim img4 As String = JGrM_Buscador.GetValue("img4").ToString
        If (File.Exists(RutaGlobal + "\Imagenes\Imagenes Categoria" + img4)) Then
            ImgEstructura.Visible = True
            Dim Bin As New MemoryStream
            Dim im As New Bitmap(New Bitmap(RutaGlobal + "\Imagenes\Imagenes Categoria" + img4))
            im.Save(Bin, System.Drawing.Imaging.ImageFormat.Jpeg)
            ImgEstructura.pbImage.SizeMode = PictureBoxSizeMode.StretchImage
            ImgEstructura.pbImage.SizeMode = PictureBoxSizeMode.StretchImage
            ImgEstructura.pbImage.Image = Image.FromStream(Bin)
            Bin.Dispose()
            ImgEstructura.pbImage.Tag = RutaGlobal + "\Imagenes\Imagenes Categoria" + img4
        Else
            ImgEstructura.Visible = False

        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        tbsubgrupo.Text = JGrM_Buscador.GetValue("grupo5").ToString
        CodSubGrupo = JGrM_Buscador.GetValue("codigo5").ToString
        CbSubgrupo = JGrM_Buscador.GetValue("yfMed")
        Dim img5 As String = JGrM_Buscador.GetValue("img5").ToString
        If (File.Exists(RutaGlobal + "\Imagenes\Imagenes Categoria" + img5)) Then
            ImgSubGrupo.Visible = True
            Dim Bin As New MemoryStream
            Dim im As New Bitmap(New Bitmap(RutaGlobal + "\Imagenes\Imagenes Categoria" + img5))
            im.Save(Bin, System.Drawing.Imaging.ImageFormat.Jpeg)
            ImgSubGrupo.pbImage.SizeMode = PictureBoxSizeMode.StretchImage
            ImgSubGrupo.pbImage.SizeMode = PictureBoxSizeMode.StretchImage
            ImgSubGrupo.pbImage.Image = Image.FromStream(Bin)
            Bin.Dispose()
            ImgSubGrupo.pbImage.Tag = RutaGlobal + "\Imagenes\Imagenes Categoria" + img5
        Else
            ImgSubGrupo.Visible = False

        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        tbclase.Text = JGrM_Buscador.GetValue("grupo6").ToString
        CodClase = JGrM_Buscador.GetValue("codigo6").ToString
        CbClase = JGrM_Buscador.GetValue("yfumin")
        Dim img6 As String = JGrM_Buscador.GetValue("img6").ToString
        If (File.Exists(RutaGlobal + "\Imagenes\Imagenes Categoria" + img6)) Then
            ImgClase.Visible = True
            Dim Bin As New MemoryStream
            Dim im As New Bitmap(New Bitmap(RutaGlobal + "\Imagenes\Imagenes Categoria" + img6))
            im.Save(Bin, System.Drawing.Imaging.ImageFormat.Jpeg)
            ImgClase.pbImage.SizeMode = PictureBoxSizeMode.StretchImage
            ImgClase.pbImage.SizeMode = PictureBoxSizeMode.StretchImage
            ImgClase.pbImage.Image = Image.FromStream(Bin)
            Bin.Dispose()
            ImgClase.pbImage.Tag = RutaGlobal + "\Imagenes\Imagenes Categoria" + img6
        Else
            ImgClase.Visible = False

        End If
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

#End Region






    Private Sub F1_Productos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub








    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles btExcel.Click
        _prCrearCarpetaReportes()
        Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
        If (P_ExportarExcel(RutaGlobal + "\Reporte\Reporte Productos")) Then
            ToastNotification.Show(Me, "EXPORTACIÓN DE LISTA DE PRODUCTOS EXITOSA..!!!",
                                       img, 2000,
                                       eToastGlowColor.Green,
                                       eToastPosition.BottomCenter)
        Else
            ToastNotification.Show(Me, "FALLO AL EXPORTACIÓN DE LISTA DE PRODUCTOS..!!!",
                                       My.Resources.WARNING, 2000,
                                       eToastGlowColor.Red,
                                       eToastPosition.BottomLeft)
        End If
    End Sub


    Public Function P_ExportarExcel(_ruta As String) As Boolean
        Dim _ubicacion As String
        'Dim _directorio As New FolderBrowserDialog

        If (1 = 1) Then 'If(_directorio.ShowDialog = Windows.Forms.DialogResult.OK) Then
            '_ubicacion = _directorio.SelectedPath
            _ubicacion = _ruta
            Try
                Dim _stream As Stream
                Dim _escritor As StreamWriter
                Dim _fila As Integer = JGrM_Buscador.GetRows.Length
                Dim _columna As Integer = JGrM_Buscador.RootTable.Columns.Count
                Dim _archivo As String = _ubicacion & "\ListaDeProductos_" & Now.Date.Day &
                    "." & Now.Date.Month & "." & Now.Date.Year & "_" & Now.Hour & "." & Now.Minute & "." & Now.Second & ".csv"
                Dim _linea As String = ""
                Dim _filadata = 0, columndata As Int32 = 0
                File.Delete(_archivo)
                _stream = File.OpenWrite(_archivo)
                _escritor = New StreamWriter(_stream, System.Text.Encoding.UTF8)

                For Each _col As GridEXColumn In JGrM_Buscador.RootTable.Columns
                    If (_col.Visible) Then
                        _linea = _linea & _col.Caption & ";"
                    End If
                Next
                _linea = Mid(CStr(_linea), 1, _linea.Length - 1)
                _escritor.WriteLine(_linea)
                _linea = Nothing

                'Pbx_Precios.Visible = True
                'Pbx_Precios.Minimum = 1
                'Pbx_Precios.Maximum = Dgv_Precios.RowCount
                'Pbx_Precios.Value = 1

                For Each _fil As GridEXRow In JGrM_Buscador.GetRows
                    For Each _col As GridEXColumn In JGrM_Buscador.RootTable.Columns
                        If (_col.Visible) Then
                            Dim data As String = CStr(_fil.Cells(_col.Key).Value)
                            data = data.Replace(";", ",")
                            _linea = _linea & data & ";"
                        End If
                    Next
                    _linea = Mid(CStr(_linea), 1, _linea.Length - 1)
                    _escritor.WriteLine(_linea)
                    _linea = Nothing
                    'Pbx_Precios.Value += 1
                Next
                _escritor.Close()
                'Pbx_Precios.Visible = False
                Try
                    Dim ef = New Efecto
                    ef._archivo = _archivo

                    ef.tipo = 1
                    ef.Context = "Su archivo ha sido Guardado en la ruta: " + _archivo + vbLf + "DESEA ABRIR EL ARCHIVO?"
                    ef.Header = "PREGUNTA"
                    ef.ShowDialog()
                    Dim bandera As Boolean = False
                    bandera = ef.band
                    If (bandera = True) Then
                        Process.Start(_archivo)
                    End If

                    'If (MessageBox.Show("Su archivo ha sido Guardado en la ruta: " + _archivo + vbLf + "DESEA ABRIR EL ARCHIVO?", "PREGUNTA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                    '    Process.Start(_archivo)
                    'End If
                    Return True
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return False
                End Try
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
        End If
        Return False
    End Function

    Private Sub JGrM_Buscador_DoubleClick(sender As Object, e As EventArgs) Handles JGrM_Buscador.DoubleClick
        If (MPanelSup.Visible = True) Then
            JGrM_Buscador.GroupByBoxVisible = True
            MPanelSup.Visible = False
            JGrM_Buscador.UseGroupRowSelector = True

        Else
            JGrM_Buscador.GroupByBoxVisible = False
            JGrM_Buscador.UseGroupRowSelector = True
            MPanelSup.Visible = True
        End If
    End Sub



    Private Sub JGrM_Buscador_KeyDown(sender As Object, e As KeyEventArgs) Handles JGrM_Buscador.KeyDown
        If e.KeyData = Keys.Enter Then
            If (MPanelSup.Visible = True) Then
                JGrM_Buscador.GroupByBoxVisible = True
                MPanelSup.Visible = False
                JGrM_Buscador.UseGroupRowSelector = True

            Else
                JGrM_Buscador.GroupByBoxVisible = False
                JGrM_Buscador.UseGroupRowSelector = True
                MPanelSup.Visible = True
            End If
        End If
    End Sub

    Private Sub TextBox_KeyDown(sender As Object, e As KeyEventArgs)
        Dim tb As TextBoxX = CType(sender, TextBoxX)
        If tb.Text = String.Empty Then

        Else
            tb.BackColor = Color.White
            MEP.SetError(tb, "")
        End If
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

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click

    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        P_GenerarReporte()
    End Sub
    Private Sub P_GenerarReporte()
        'Dim dt As DataTable = L_fnReporteproducto()

        'If Not IsNothing(P_Global.Visualizador) Then
        '    P_Global.Visualizador.Close()
        'End If

        'P_Global.Visualizador = New Visualizador

        'Dim objrep As New R_Productos
        ''' GenerarNro(_dt)
        '''objrep.SetDataSource(Dt1Kardex)
        'objrep.SetDataSource(dt)

        'P_Global.Visualizador.CrGeneral.ReportSource = objrep 'Comentar
        'P_Global.Visualizador.Show() 'Comentar
        'P_Global.Visualizador.BringToFront() 'Comentar

    End Sub

    Private Sub tbCodBarra_TextChanged(sender As Object, e As EventArgs)
    End Sub

    Private Sub btDeleteImg_Click(sender As Object, e As EventArgs) Handles btDeleteImg.Click
        Dim pos As Integer = CType(pbImgProdu.Tag, Integer)

        If (pos >= 0) Then
            TablaImagenes.Rows(pos).Item("estado") = -1
            _prCargarImagen()
        End If
    End Sub

    Private Sub tbcategoria_KeyDown(sender As Object, e As KeyEventArgs) Handles tbcategoria.KeyDown
        If (tbnombre.ReadOnly = False) Then
            If e.KeyData = Keys.Control + Keys.Enter Then

                Dim dt As DataTable

                dt = L_fnListarCategoria(1)  ''''Categoria
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

                    CbCategoria = Row.Cells("ygnumi").Value
                    tbcategoria.Text = Row.Cells("ygnombre").Value
                    Dim nameImagen = Row.Cells("ygimg").Value
                    CodCategoria = Row.Cells("ygcodigo").Value
                    tbgrupo.Focus()

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

    Private Sub tbgrupo_KeyDown(sender As Object, e As KeyEventArgs) Handles tbgrupo.KeyDown
        If (tbnombre.ReadOnly = False) Then
            If e.KeyData = Keys.Control + Keys.Enter Then

                Dim dt As DataTable

                dt = L_fnListarCategoria(2)  ''''Categoria
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
                    CodGrupo = Row.Cells("ygcodigo").Value
                    CbGrupo = Row.Cells("ygnumi").Value
                    tbgrupo.Text = Row.Cells("ygnombre").Value
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

    Private Sub tbproducto_KeyDown(sender As Object, e As KeyEventArgs) Handles tbproducto.KeyDown
        If (tbnombre.ReadOnly = False) Then
            If e.KeyData = Keys.Control + Keys.Enter Then

                Dim dt As DataTable

                dt = L_fnListarCategoria(3)  ''''Categoria
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
                ef.Context = "Seleccione Producto".ToUpper
                ef.ShowDialog()
                Dim bandera As Boolean = False
                bandera = ef.band
                If (bandera = True) Then
                    Dim Row As Janus.Windows.GridEX.GridEXRow = ef.Row
                    Dim Bin As New MemoryStream
                    CodProducto = Row.Cells("ygcodigo").Value
                    CbProducto = Row.Cells("ygnumi").Value
                    tbproducto.Text = Row.Cells("ygnombre").Value
                    Dim nameImagen = Row.Cells("ygimg").Value
                    If (nameImagen.Equals("Default.jpg")) Then

                        ImgProducto.Visible = False
                    Else

                        If (File.Exists(RutaGlobal + "\Imagenes\Imagenes Categoria" + nameImagen)) Then
                            ImgProducto.Visible = True
                            ImgProducto.pbImage.Image = Row.Cells("img").Value
                            ImgProducto.pbImage.Tag = RutaGlobal + "\Imagenes\Imagenes Categoria" + nameImagen
                        Else
                            ImgProducto.Visible = False

                        End If
                    End If



                End If
            End If
        End If
    End Sub

    Private Sub tbestructura_KeyDown(sender As Object, e As KeyEventArgs) Handles tbestructura.KeyDown
        If (tbnombre.ReadOnly = False) Then
            If e.KeyData = Keys.Control + Keys.Enter Then

                Dim dt As DataTable

                dt = L_fnListarCategoria(4)  ''''Categoria
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
                ef.Context = "Seleccione ESTRUCTURA".ToUpper
                ef.ShowDialog()
                Dim bandera As Boolean = False
                bandera = ef.band
                If (bandera = True) Then
                    Dim Row As Janus.Windows.GridEX.GridEXRow = ef.Row
                    Dim Bin As New MemoryStream
                    CodEstructura = Row.Cells("ygcodigo").Value
                    CbEstructura = Row.Cells("ygnumi").Value
                    tbestructura.Text = Row.Cells("ygnombre").Value
                    Dim nameImagen = Row.Cells("ygimg").Value
                    If (nameImagen.Equals("Default.jpg")) Then

                        ImgEstructura.Visible = False
                    Else

                        If (File.Exists(RutaGlobal + "\Imagenes\Imagenes Categoria" + nameImagen)) Then
                            ImgEstructura.Visible = True
                            ImgEstructura.pbImage.Image = Row.Cells("img").Value
                            ImgEstructura.pbImage.Tag = RutaGlobal + "\Imagenes\Imagenes Categoria" + nameImagen
                        Else
                            ImgEstructura.Visible = False

                        End If
                    End If



                End If
            End If
        End If
    End Sub

    Private Sub tbsubgrupo_KeyDown(sender As Object, e As KeyEventArgs) Handles tbsubgrupo.KeyDown
        If (tbnombre.ReadOnly = False) Then
            If e.KeyData = Keys.Control + Keys.Enter Then

                Dim dt As DataTable

                dt = L_fnListarCategoria(5)  ''''Categoria
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
                ef.Context = "Seleccione subgrupo".ToUpper
                ef.ShowDialog()
                Dim bandera As Boolean = False
                bandera = ef.band
                If (bandera = True) Then
                    Dim Row As Janus.Windows.GridEX.GridEXRow = ef.Row
                    Dim Bin As New MemoryStream
                    CodSubGrupo = Row.Cells("ygcodigo").Value
                    CbSubgrupo = Row.Cells("ygnumi").Value
                    tbsubgrupo.Text = Row.Cells("ygnombre").Value
                    Dim nameImagen = Row.Cells("ygimg").Value
                    If (nameImagen.Equals("Default.jpg")) Then

                        ImgSubGrupo.Visible = False
                    Else

                        If (File.Exists(RutaGlobal + "\Imagenes\Imagenes Categoria" + nameImagen)) Then
                            ImgSubGrupo.Visible = True
                            ImgSubGrupo.pbImage.Image = Row.Cells("img").Value
                            ImgSubGrupo.pbImage.Tag = RutaGlobal + "\Imagenes\Imagenes Categoria" + nameImagen
                        Else
                            ImgSubGrupo.Visible = False

                        End If
                    End If



                End If
            End If
        End If
    End Sub

    Private Sub tbclase_KeyDown(sender As Object, e As KeyEventArgs) Handles tbclase.KeyDown
        If (tbnombre.ReadOnly = False) Then
            If e.KeyData = Keys.Control + Keys.Enter Then

                Dim dt As DataTable

                dt = L_fnListarCategoria(6)  ''''Categoria
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
                ef.Context = "Seleccione CLASE".ToUpper
                ef.ShowDialog()
                Dim bandera As Boolean = False
                bandera = ef.band
                If (bandera = True) Then
                    Dim Row As Janus.Windows.GridEX.GridEXRow = ef.Row
                    Dim Bin As New MemoryStream
                    CodClase = Row.Cells("ygcodigo").Value
                    CbClase = Row.Cells("ygnumi").Value
                    tbclase.Text = Row.Cells("ygnombre").Value
                    Dim nameImagen = Row.Cells("ygimg").Value
                    If (nameImagen.Equals("Default.jpg")) Then

                        ImgClase.Visible = False
                    Else

                        If (File.Exists(RutaGlobal + "\Imagenes\Imagenes Categoria" + nameImagen)) Then
                            ImgClase.Visible = True
                            ImgClase.pbImage.Image = Row.Cells("img").Value
                            ImgClase.pbImage.Tag = RutaGlobal + "\Imagenes\Imagenes Categoria" + nameImagen
                        Else
                            ImgClase.Visible = False

                        End If
                    End If



                End If
            End If
        End If
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        MPanelSup.Visible = False
        GroupPanelBuscador.Visible = True
        GroupPanelBuscador.Dock = DockStyle.Fill
        'JGrM_Buscador.Focus()
        'JGrM_Buscador.MoveTo(JGrM_Buscador.FilterRow)
        'JGrM_Buscador.Col = 3

        ButtonX2.Visible = True
        ButtonX1.Visible = False
    End Sub

    Private Sub ButtonX2_Click_1(sender As Object, e As EventArgs) Handles ButtonX2.Click
        MPanelSup.Visible = True
        GroupPanelBuscador.Visible = False
        'MPanelSup.Dock = DockStyle.Top
        PanelSuperior.Visible = True
        ButtonX2.Visible = False
        ButtonX1.Visible = True
    End Sub

    Private Sub TextBoxX1_TextChanged(sender As Object, e As EventArgs) Handles tbnombre.TextChanged

    End Sub
End Class
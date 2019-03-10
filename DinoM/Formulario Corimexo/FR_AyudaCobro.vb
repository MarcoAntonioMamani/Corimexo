Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.ToolTips
Imports System.Drawing
Imports DevComponents.DotNetBar.Controls
Imports System.Threading
Imports System.Drawing.Text
Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX
Imports DevComponents.DotNetBar
Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid
Imports GMap.NET.MapProviders
Imports GMap.NET
Imports GMap.NET.WindowsForms.Markers
Imports System.Reflection
Imports System.Runtime.InteropServices
Public Class FR_AyudaCobro
    Public NumiVendedor As Integer
    Public NumiVenta As Integer
    Public NumiCliente As Integer
    Public MontoPendiente As Double
    Public MBandera As Boolean = False

    Private Sub _IniciarTodo()

        L_prAbrirConexion(gs_Ip, gs_UsuarioSql, gs_ClaveSql, gs_NombreBD)

        cbdocumento.Focus()
        Me.Text = "PAGO ANTICIPADO"
        Dim blah As New Bitmap(New Bitmap(My.Resources.cobro), 20, 20)
        Dim ico As Icon = Icon.FromHandle(blah.GetHicon())
        Me.Icon = ico
        _prCargarComboLibreria(cbdocumento, 8, 2)
        _prCargarComboLibreria(cbbanco, 6, 1)
    End Sub

    Private Sub _prCargarComboLibreria(mCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo, cod1 As String, cod2 As String)
        Dim dt As New DataTable
        dt = L_prLibreriaClienteLGeneral(cod1, cod2)
        With mCombo
            .DropDownList.Columns.Clear()
            .DropDownList.Columns.Add("yccod3").Width = 70
            .DropDownList.Columns("yccod3").Caption = "COD"
            .DropDownList.Columns.Add("ycdes3").Width = 200
            .DropDownList.Columns("ycdes3").Caption = "DESCRIPCION"
            .ValueMember = "yccod3"
            .DisplayMember = "ycdes3"
            .DataSource = dt
            .Refresh()
        End With
    End Sub


    Private Sub FR_AyudaCobro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _IniciarTodo()
    End Sub

    Private Sub cbdocumento_ValueChanged(sender As Object, e As EventArgs) Handles cbdocumento.ValueChanged
        If (cbdocumento.Value = 1) Then
            lbbanco.Visible = False
            cbbanco.Visible = False
            lbnrodocumento.Text = "Nro Recibo:"
            lbnrodocumento.Visible = True
            tbnrodocumento.Visible = True
        End If
        If (cbdocumento.Value = 2) Then
            lbbanco.Visible = True
            cbbanco.Visible = True
            lbnrodocumento.Text = "Nro Cheque:"
        End If
        If (cbdocumento.Value = 3) Then
            lbbanco.Visible = True
            cbbanco.Visible = True
            lbnrodocumento.Text = "Nro Documento:"
        End If
    End Sub

    Private Sub Bt1Generar_Click(sender As Object, e As EventArgs) Handles Bt1Generar.Click
        Dim numi As String = ""
        Dim img2 As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
        If (cbdocumento.SelectedIndex < 0) Then
            ToastNotification.Show(Me, "Por favor seleccione un Documento de Cobro".ToUpper, img2, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            cbdocumento.Focus()
            Return

        End If
        If (cbdocumento.Value = 1 And tbnrodocumento.Text.Trim = String.Empty) Then
            ToastNotification.Show(Me, "Por favor Inserte un Numero de Recibo".ToUpper, img2, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            tbnrodocumento.Focus()
            Return

        End If
        If (cbdocumento.Value = 2 And tbnrodocumento.Text.Trim = String.Empty) Then
            ToastNotification.Show(Me, "Por favor Inserte un Numero de Cheque".ToUpper, img2, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            tbnrodocumento.Focus()
            Return

        End If
        If (cbdocumento.Value = 2 And cbbanco.SelectedIndex < 0) Then
            ToastNotification.Show(Me, "Por favor seleccione un banco".ToUpper, img2, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            cbbanco.Focus()
            Return

        End If
        If (cbdocumento.Value = 3 And tbnrodocumento.Text.Trim = String.Empty) Then
            ToastNotification.Show(Me, "Por favor Inserte un Numero de Documento".ToUpper, img2, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            tbnrodocumento.Focus()
            Return

        End If
        If (cbdocumento.Value = 3 And cbbanco.SelectedIndex < 0) Then
            ToastNotification.Show(Me, "Por favor seleccione un banco".ToUpper, img2, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            cbbanco.Focus()
            Return

        End If
        Dim dtCobro As DataTable = L_fnCobranzasObtenerLosPagos(-1)
        Dim bandera As Boolean = False

        _prInterpretarDatosCobranza(dtCobro, bandera)


        Dim res As Boolean = L_fnGrabarCobranzaAnticipados(NumiVenta, Now.Date.ToString("yyyy/MM/dd"), NumiVendedor, "", dtCobro, NumiVenta, MontoPendiente)


        If res Then
            bandera = True
            Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
            ToastNotification.Show(Me, "El Pago Ha Sido ".ToUpper + " Grabado con Exito.".ToUpper,
                                      img, 2000,
                                      eToastGlowColor.Green,
                                      eToastPosition.TopCenter
                                      )
            MBandera = True
            Me.Close()



        Else
            Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
            ToastNotification.Show(Me, "La Compra no pudo ser insertado".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)

        End If
    End Sub

    Sub _prInterpretarDatosCobranza(ByRef dt As DataTable, ByRef bandera As Boolean)


        '       numidetalle, NroDoc, factura, numiCredito, numiCobranza, A.tctv1numi
        ',a.tcty4clie ,cliente,detalle.tdfechaPago, PagoAc, NumeroRecibo, DescBanco, banco, detalle.tdnrocheque,
        'img,estado,pendiente
        Dim Bin As New MemoryStream
        Dim img As New Bitmap(My.Resources.delete, 28, 28)
        img.Save(Bin, Imaging.ImageFormat.Png)
        Dim Pagos As DataTable = L_fnObtenerNumiPago(NumiVenta)
        '    a.tdnumi , a.tdtv12numi, a.tdtv13numi, a.tdnrodoc, a.tdfechaPago, a.tdmonto, a.tdnrorecibo, a.tdty3banco,
        'a.tdnrocheque, a.tdfact, a.tdhact, a.tduact, Cast('' as image) as img,1 as estado
        If (Pagos.Rows.Count > 0) Then
            dt.Rows.Add(0, Pagos.Rows(0).Item("tcnumi"), 0, cbdocumento.Value,
                                                       Now.Date, MontoPendiente, tbnrodocumento.Text, cbbanco.Value, tbnrodocumento.Text, Now.Date,
                                                       "", "", Bin.ToArray, 0)
        End If


    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Me.Close()
    End Sub
End Class
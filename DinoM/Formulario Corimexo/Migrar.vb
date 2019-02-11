Imports Logica.AccesoLogica
Imports System.IO
Imports System.Drawing
Imports System.Data.OleDb
Imports System.Windows.Forms
Public Class Migrar
    Dim _BindingSource, _BindingSource1 As BindingSource

    Public Sub _prMigrarMaterial()
        L_prAbrirConexion(gs_Ip, gs_UsuarioSql, gs_ClaveSql, "DBDinoM_Corimexo")
        Dim dt As DataTable = Import()

        For i As Integer = 0 To dt.Rows.Count - 1 Step 1
            'ByRef _yhnumi As String, _yhnombre As String, _yhcodigo As String,
            '                                   _yhcategoria As Integer, _yhimg As String, _yhestado As Integer
            Dim bandera As Boolean = L_fnGrabarMateriales(0, dt.Rows(i).Item("NOMBRE"), dt.Rows(i).Item("CODIGO"), dt.Rows(i).Item("NUMI"), "Default.jpg", 1)


        Next
    End Sub

    Public Sub _prMigrarCategorias()
        L_prAbrirConexion(gs_Ip, gs_UsuarioSql, gs_ClaveSql, "DBDinoM_Corimexo")
        Dim dt As DataTable = Import()

        For i As Integer = 0 To dt.Rows.Count - 1 Step 1
            'ByRef _yhnumi As String, _yhnombre As String, _yhcodigo As String,
            '                                   _yhcategoria As Integer, _yhimg As String, _yhestado As Integer
            Dim bandera As Boolean = L_fnGrabarCategoria(0, dt.Rows(i).Item("categoria"), dt.Rows(i).Item("codigo"), 0, "Default.jpg", 1)


        Next
    End Sub

    Public Sub _prMigrarGrupos()
        L_prAbrirConexion(gs_Ip, gs_UsuarioSql, gs_ClaveSql, "DBDinoM_Corimexo")
        Dim dt As DataTable = Import()

        For i As Integer = 0 To dt.Rows.Count - 1 Step 1
            'ByRef _yhnumi As String, _yhnombre As String, _yhcodigo As String,
            '                                   _yhcategoria As Integer, _yhimg As String, _yhestado As Integer
            Dim bandera As Boolean = L_fnGrabarGrupo(0, IIf(IsDBNull(dt.Rows(i).Item("grupo")), " ", dt.Rows(i).Item("grupo")), dt.Rows(i).Item("codigo"), dt.Rows(i).Item("codcategoria"), "Default.jpg", 1)


        Next
    End Sub





    Public Function _fnObtenerIDGrupoCategoria(ByRef _codcategoria As Integer, ByRef _codgrupo As Integer, ByVal codigoa As Integer, ByVal n As Integer, dt As DataTable) As Boolean
        Dim bandera As Boolean = False
        Dim i As Integer = 0
        While (i <= n And bandera = False)
            Dim codigob As String = dt.Rows(i).Item("ygnumi")
            If (codigoa = codigob) Then
                bandera = True
                _codcategoria = dt.Rows(i).Item("ygty0051")
                _codgrupo = dt.Rows(i).Item("ygnumi")
            End If
            i += 1

        End While
        Return bandera
    End Function


    Public Sub _prarmarcodigos(ByRef _dt As DataTable)
        Dim numero As Integer = 0
        Dim cadena As String = ""
        Dim Cadena2 As String = ""
        For i As Integer = 0 To _dt.Rows.Count - 1 Step 1
            Dim grupo As String = _dt.Rows(i).Item("GRUPO").ToString
            If ((Not cadena.Equals(_dt.Rows(i).Item("codigogrupo")) Or Not Cadena2.Equals(grupo)) And Not String.IsNullOrEmpty(_dt.Rows(i).Item("codigogrupo").ToString) And Not String.IsNullOrEmpty(_dt.Rows(i).Item("GRUPO").ToString)) Then
                numero += 1
                cadena = _dt.Rows(i).Item("codigogrupo")
                Cadena2 = _dt.Rows(i).Item("GRUPO")
            End If
            _dt.Rows(i).Item("numi") = numero


        Next



    End Sub

    Public Sub _prarmarcodigosCategoria(ByRef _dt As DataTable)
        Dim numero As Integer = 0
        Dim cadena As String = ""
        Dim Cadena2 As String = ""
        For i As Integer = 0 To _dt.Rows.Count - 1 Step 1
            Dim grupo As String = _dt.Rows(i).Item("categoria").ToString
            If ((Not cadena.Equals(_dt.Rows(i).Item("codigocategoria")) Or Not Cadena2.Equals(grupo)) And Not String.IsNullOrEmpty(_dt.Rows(i).Item("codigocategoria").ToString) And Not String.IsNullOrEmpty(_dt.Rows(i).Item("categoria").ToString)) Then
                numero += 1
                cadena = _dt.Rows(i).Item("codigocategoria")
                Cadena2 = _dt.Rows(i).Item("categoria")
            End If
            _dt.Rows(i).Item("numi2") = numero


        Next



    End Sub


    Public Sub _prMigrarSubGrupos()
        L_prAbrirConexion(gs_Ip, gs_UsuarioSql, gs_ClaveSql, "DBDinoM_Corimexo")
        Dim dt As DataTable = Import()
        _prarmarcodigos(dt)

        Dim dtgrupo As DataTable = L_fnGeneralGrupo()

        For i As Integer = 0 To dt.Rows.Count - 1 Step 1

            Dim codigocategoria As Integer = 0
            Dim codigogrupo As Integer = 0
            Dim bandera As Boolean = False
            bandera = _fnObtenerIDGrupoCategoria(codigocategoria, codigogrupo, dt.Rows(i).Item("numi"), dtgrupo.Rows.Count - 1, dtgrupo)
            'ByRef _yhnumi As String, _yhnombre As String, _yhcodigo As String,
            '                                   _yhcategoria As Integer, _yhimg As String, _yhestado As Integer
            Dim inserto As Boolean = L_fnGrabarSubGrupo(0, IIf(IsDBNull(dt.Rows(i).Item("subgrupo")), " ", dt.Rows(i).Item("subgrupo")), dt.Rows(i).Item("codigo"), codigocategoria, codigogrupo, "Default.jpg", 1)


        Next
    End Sub


    Public Sub _prMigrarModelos()
        L_prAbrirConexion(gs_Ip, gs_UsuarioSql, gs_ClaveSql, "DBDinoM_Corimexo")
        Dim dt2 As DataTable = ImportGuia()
        _prarmarcodigos(dt2)
        _prarmarcodigosCategoria(dt2)
        Dim j As Integer = 0
        Dim n As Integer = dt2.Rows.Count - 1
        Dim numero As Integer = -1
        While (j < n)
            Dim codigocategoria As Integer = dt2.Rows(j).Item("numi2")
            Dim codigogrupo As Integer = dt2.Rows(j).Item("numi")
            Dim dt As DataTable
            If (Import(dt, Str(codigogrupo)) And codigogrupo >= 52 And codigogrupo <= 55 And numero <> codigogrupo) Then
                numero = codigogrupo
                For i As Integer = 0 To dt.Rows.Count - 1 Step 1


                    Dim bandera As Boolean = False
                    ''''Categoria, grupo

                    'ByRef _yhnumi As String, _yhnombre As String, _yhcodigo As String,
                    '                                   _yhcategoria As Integer,_yggrupo as integer, _yhimg As String, _yhestado As Integer
                    If (Not String.IsNullOrEmpty(dt.Rows(i).Item("codigo").ToString)) Then
                        Dim inserto As Boolean = L_fnGrabarModelo(0, IIf(IsDBNull(dt.Rows(i).Item("modelo")), " ", dt.Rows(i).Item("modelo")), dt.Rows(i).Item("codigo"), codigocategoria, codigogrupo, "Default.jpg", 1)
                    End If



                Next
            End If

            j += 1

        End While






    End Sub


    Public Sub _prMigrarClase()
        L_prAbrirConexion(gs_Ip, gs_UsuarioSql, gs_ClaveSql, "DBDinoM_Corimexo")
        Dim dt As DataTable = Import()
        _prarmarcodigos(dt)

        Dim dtgrupo As DataTable = L_fnGeneralGrupo()

        For i As Integer = 0 To dt.Rows.Count - 1 Step 1

            Dim codigocategoria As Integer = 0
            Dim codigogrupo As Integer = 0
            Dim bandera As Boolean = False
            bandera = _fnObtenerIDGrupoCategoria(codigocategoria, codigogrupo, dt.Rows(i).Item("numi"), dtgrupo.Rows.Count - 1, dtgrupo)
            'ByRef _yhnumi As String, _yhnombre As String, _yhcodigo As String,
            '                                   _yhcategoria As Integer, _yhimg As String, _yhestado As Integer
            Dim inserto As Boolean = L_fnGrabarClase(0, IIf(IsDBNull(dt.Rows(i).Item("clase")), " ", dt.Rows(i).Item("clase")), dt.Rows(i).Item("codigo"), codigocategoria, codigogrupo, "Default.jpg", 1)


        Next
    End Sub


    Public Sub _prCargarClientes()
        L_prAbrirConexion(gs_Ip, gs_UsuarioSql, gs_ClaveSql, "DBDinoM_Corimexo")
        Dim dt As DataTable = Import()

        For i As Integer = 0 To dt.Rows.Count - 1 Step 1
            'ByRef _ydnumi As String,
            '                                 _ydcod As String, _ydrazonsocial As String, _yddesc As String,
            '                                 _ydnumiVendedor As Integer, _ydzona As Integer, _yddct As Integer,
            '                                 _yddctnum As String, _yddirec As String, _ydtelf1 As String,
            '                                 _ydtelf2 As String, _ydcat As Integer, _ydest As Integer,
            '                                 _ydlat As Double, _ydlongi As Double, _ydobs As String,
            '                                 _ydfnac As String, _ydnomfac As String, _ydtip As Integer,
            '                                 _ydnit As String, _yddias As String, _ydlcred As String,
            '                                 _ydfecing As String, _ydultvent As String, _ydimg As String, _ydrut As String
            Dim bandera As Boolean = L_fnGrabarCLiente("0", "0", "", dt.Rows(i).Item("NOMBRE"), 0, 1, 2, IIf(IsDBNull(dt.Rows(i).Item("NUMDOC")), "", dt.Rows(i).Item("NUMDOC")), IIf(IsDBNull(dt.Rows(i).Item("DIRECCION")), "", dt.Rows(i).Item("DIRECCION")), IIf(IsDBNull(dt.Rows(i).Item("TELEFONO")), "", dt.Rows(i).Item("TELEFONO")), IIf(IsDBNull(dt.Rows(i).Item("CELULAR")), "", dt.Rows(i).Item("CELULAR")), 0, 1, 0, 0, "", "01/01/1990", "", 2, "", "", "", "01/01/2000", "01/01/2000", "Default.jpg", "")


        Next

    End Sub

    Private Shared Function Import(ByRef table As DataTable, name As String) As Boolean
        Dim conStr As String = ""
        Dim dtExcelSchema As DataTable
        Dim dt As DataSet = New DataSet

        conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes'"
        conStr = String.Format(conStr, "A:\DINASES\Cambios Marco\Corimexo\Migracion\nomenclatura.xlsx")
        Dim connExcel As New OleDbConnection(conStr)
        Dim cmdExcel As New OleDbCommand()
        Dim oda As New OleDbDataAdapter()
        cmdExcel.Connection = connExcel
        'Get the name of First Sheet
        connExcel.Open()
        dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)

        Dim SheetName As String = name.Trim + "$"
        'If dtExcelSchema.Rows.Count > 0 Then
        '    SheetName = dtExcelSchema.Rows(dtExcelSchema.Rows.Count - 1)("TABLE_NAME").ToString()
        'End If
        connExcel.Close()
        'Read Data from First Sheet
        connExcel.Open()
        cmdExcel.CommandText = "SELECT * From [" & SheetName & "]"
        oda.SelectCommand = cmdExcel
        Try
            oda.Fill(dt)
            Dim dtt As DataTable = dt.Tables(0)


            'dt.TableName = SheetName.ToString().Replace("$", "")
            connExcel.Close()
            table = dtt
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    Private Shared Function Import() As DataTable
        Dim conStr As String = ""
        Dim dtExcelSchema As DataTable
        Dim dt As DataSet = New DataSet

        conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes'"
        conStr = String.Format(conStr, "A:\DINASES\Cambios Marco\Corimexo\Migracion\guia.xlsx")
        Dim connExcel As New OleDbConnection(conStr)
        Dim cmdExcel As New OleDbCommand()
        Dim oda As New OleDbDataAdapter()
        cmdExcel.Connection = connExcel
        'Get the name of First Sheet
        connExcel.Open()
        dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
        Dim name As String = "guia"
        Dim SheetName As String = name + "$"
        'If dtExcelSchema.Rows.Count > 0 Then
        '    SheetName = dtExcelSchema.Rows(dtExcelSchema.Rows.Count - 1)("TABLE_NAME").ToString()
        'End If
        connExcel.Close()
        'Read Data from First Sheet
        connExcel.Open()
        cmdExcel.CommandText = "SELECT * From [" & SheetName & "]"
        oda.SelectCommand = cmdExcel
        oda.Fill(dt)
        Dim dtt As DataTable = dt.Tables(0)


        'dt.TableName = SheetName.ToString().Replace("$", "")
        connExcel.Close()
        Return dtt
    End Function
    Private Shared Function ImportGuia() As DataTable
        Dim conStr As String = ""
        Dim dtExcelSchema As DataTable
        Dim dt As DataSet = New DataSet

        conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes'"
        conStr = String.Format(conStr, "A:\DINASES\Cambios Marco\Corimexo\Migracion\guia.xlsx")
        Dim connExcel As New OleDbConnection(conStr)
        Dim cmdExcel As New OleDbCommand()
        Dim oda As New OleDbDataAdapter()
        cmdExcel.Connection = connExcel
        'Get the name of First Sheet
        connExcel.Open()
        dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
        Dim name As String = "guia"
        Dim SheetName As String = name + "$"
        'If dtExcelSchema.Rows.Count > 0 Then
        '    SheetName = dtExcelSchema.Rows(dtExcelSchema.Rows.Count - 1)("TABLE_NAME").ToString()
        'End If
        connExcel.Close()
        'Read Data from First Sheet
        connExcel.Open()
        cmdExcel.CommandText = "SELECT * From [" & SheetName & "]"
        oda.SelectCommand = cmdExcel
        oda.Fill(dt)
        Dim dtt As DataTable = dt.Tables(0)


        'dt.TableName = SheetName.ToString().Replace("$", "")
        connExcel.Close()
        Return dtt
    End Function
    Private Sub Migrar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '_prCargarClientes()
        '_prMigrarCategorias()
        '_prMigrarGrupos()
        '_prMigrarClase()
        '_prMigrarModelos()
    End Sub
End Class
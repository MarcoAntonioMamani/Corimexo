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

    Private Shared Function Import() As DataTable
        Dim conStr As String = ""
        Dim dtExcelSchema As DataTable
        Dim dt As DataSet = New DataSet

        conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes'"
        conStr = String.Format(conStr, "A:\DINASES\proyectos\Corimexo\Excel\vendedores.xlsx")
        Dim connExcel As New OleDbConnection(conStr)
        Dim cmdExcel As New OleDbCommand()
        Dim oda As New OleDbDataAdapter()
        cmdExcel.Connection = connExcel
        'Get the name of First Sheet
        connExcel.Open()
        dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
        Dim SheetName As String = "Cliente"
        If dtExcelSchema.Rows.Count > 0 Then
            SheetName = dtExcelSchema.Rows(dtExcelSchema.Rows.Count - 1)("TABLE_NAME").ToString()
        End If
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
    End Sub
End Class
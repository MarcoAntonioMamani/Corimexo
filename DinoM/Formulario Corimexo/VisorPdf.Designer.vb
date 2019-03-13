<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VisorPdf
    Inherits MaterialSkin.Controls.MaterialForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VisorPdf))
        Me.PdfView = New AxAcroPDFLib.AxAcroPDF()
        CType(Me.PdfView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PdfView
        '
        Me.PdfView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PdfView.Enabled = True
        Me.PdfView.Location = New System.Drawing.Point(0, 0)
        Me.PdfView.Name = "PdfView"
        Me.PdfView.OcxState = CType(resources.GetObject("PdfView.OcxState"), System.Windows.Forms.AxHost.State)
        Me.PdfView.Size = New System.Drawing.Size(1363, 820)
        Me.PdfView.TabIndex = 0
        '
        'VisorPdf
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1363, 820)
        Me.Controls.Add(Me.PdfView)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "VisorPdf"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VisorPdf"
        CType(Me.PdfView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PdfView As AxAcroPDFLib.AxAcroPDF
End Class

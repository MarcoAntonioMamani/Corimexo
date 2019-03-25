<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class F0_VisualizadoPdf
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F0_VisualizadoPdf))
        Me.PdfView = New AxAcroPDFLib.AxAcroPDF()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbtitulo = New System.Windows.Forms.Label()
        CType(Me.PdfView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PdfView
        '
        Me.PdfView.AllowDrop = True
        Me.PdfView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PdfView.Enabled = True
        Me.PdfView.Location = New System.Drawing.Point(0, 65)
        Me.PdfView.Margin = New System.Windows.Forms.Padding(0)
        Me.PdfView.Name = "PdfView"
        Me.PdfView.OcxState = CType(resources.GetObject("PdfView.OcxState"), System.Windows.Forms.AxHost.State)
        Me.PdfView.Size = New System.Drawing.Size(1088, 701)
        Me.PdfView.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Panel1.BackgroundImage = Global.DinoM.My.Resources.Resources.fondo1
        Me.Panel1.Controls.Add(Me.lbtitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1081, 67)
        Me.Panel1.TabIndex = 2
        '
        'lbtitulo
        '
        Me.lbtitulo.AutoSize = True
        Me.lbtitulo.BackColor = System.Drawing.Color.Transparent
        Me.lbtitulo.Font = New System.Drawing.Font("Georgia", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbtitulo.ForeColor = System.Drawing.Color.White
        Me.lbtitulo.Location = New System.Drawing.Point(12, 9)
        Me.lbtitulo.Name = "lbtitulo"
        Me.lbtitulo.Size = New System.Drawing.Size(147, 43)
        Me.lbtitulo.TabIndex = 0
        Me.lbtitulo.Text = "Label1"
        '
        'F0_VisualizadoPdf
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1081, 766)
        Me.Controls.Add(Me.PdfView)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "F0_VisualizadoPdf"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VISUALIZADOR PDF"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PdfView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PdfView As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lbtitulo As Label
End Class

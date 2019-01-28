<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F0_ModeloAyudaImagenes
    Inherits System.Windows.Forms.Form

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
        Me.GPPanelP = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.grJBuscador = New Janus.Windows.GridEX.GridEX()
        Me.GPPanelP.SuspendLayout()
        CType(Me.grJBuscador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GPPanelP
        '
        Me.GPPanelP.BackColor = System.Drawing.Color.Transparent
        Me.GPPanelP.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2010
        Me.GPPanelP.Controls.Add(Me.grJBuscador)
        Me.GPPanelP.DisabledBackColor = System.Drawing.Color.Empty
        Me.GPPanelP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GPPanelP.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GPPanelP.Location = New System.Drawing.Point(0, 0)
        Me.GPPanelP.Margin = New System.Windows.Forms.Padding(4)
        Me.GPPanelP.Name = "GPPanelP"
        Me.GPPanelP.Size = New System.Drawing.Size(922, 452)
        '
        '
        '
        Me.GPPanelP.Style.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.GPPanelP.Style.BackColor2 = System.Drawing.SystemColors.MenuHighlight
        Me.GPPanelP.Style.BackColorGradientAngle = 90
        Me.GPPanelP.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPPanelP.Style.BorderBottomWidth = 1
        Me.GPPanelP.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionBackground
        Me.GPPanelP.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPPanelP.Style.BorderLeftWidth = 1
        Me.GPPanelP.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPPanelP.Style.BorderRightWidth = 1
        Me.GPPanelP.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPPanelP.Style.BorderTopWidth = 1
        Me.GPPanelP.Style.CornerDiameter = 4
        Me.GPPanelP.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GPPanelP.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GPPanelP.Style.TextColor = System.Drawing.Color.White
        Me.GPPanelP.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GPPanelP.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GPPanelP.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GPPanelP.TabIndex = 2
        Me.GPPanelP.Text = "GroupPanel1"
        '
        'grJBuscador
        '
        Me.grJBuscador.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.grJBuscador.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grJBuscador.Font = New System.Drawing.Font("Open Sans Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grJBuscador.HeaderFormatStyle.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grJBuscador.HeaderFormatStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.grJBuscador.Location = New System.Drawing.Point(0, 0)
        Me.grJBuscador.Margin = New System.Windows.Forms.Padding(4)
        Me.grJBuscador.Name = "grJBuscador"
        Me.grJBuscador.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.grJBuscador.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.grJBuscador.Size = New System.Drawing.Size(916, 423)
        Me.grJBuscador.TabIndex = 0
        Me.grJBuscador.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'F0_ModeloAyudaImagenes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(922, 452)
        Me.Controls.Add(Me.GPPanelP)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "F0_ModeloAyudaImagenes"
        Me.Text = "F0_ModeloAyudaImagenes"
        Me.GPPanelP.ResumeLayout(False)
        CType(Me.grJBuscador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GPPanelP As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents grJBuscador As Janus.Windows.GridEX.GridEX
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FR_AyudaCobro
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
        Dim cbbanco_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FR_AyudaCobro))
        Dim cbdocumento_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.PanelPrincipal = New System.Windows.Forms.Panel()
        Me.panelcontennt = New System.Windows.Forms.Panel()
        Me.tbglosa = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.Bt1Generar = New DevComponents.DotNetBar.ButtonX()
        Me.lbbanco = New DevComponents.DotNetBar.LabelX()
        Me.cbbanco = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.lbnrodocumento = New DevComponents.DotNetBar.LabelX()
        Me.tbnrodocumento = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX()
        Me.cbdocumento = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelPrincipal.SuspendLayout()
        Me.panelcontennt.SuspendLayout()
        CType(Me.cbbanco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbdocumento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelPrincipal
        '
        Me.PanelPrincipal.BackgroundImage = Global.DinoM.My.Resources.Resources.fondo1
        Me.PanelPrincipal.Controls.Add(Me.panelcontennt)
        Me.PanelPrincipal.Controls.Add(Me.Panel1)
        Me.PanelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.PanelPrincipal.Name = "PanelPrincipal"
        Me.PanelPrincipal.Padding = New System.Windows.Forms.Padding(5)
        Me.PanelPrincipal.Size = New System.Drawing.Size(736, 488)
        Me.PanelPrincipal.TabIndex = 0
        '
        'panelcontennt
        '
        Me.panelcontennt.Controls.Add(Me.tbglosa)
        Me.panelcontennt.Controls.Add(Me.LabelX1)
        Me.panelcontennt.Controls.Add(Me.ButtonX1)
        Me.panelcontennt.Controls.Add(Me.Bt1Generar)
        Me.panelcontennt.Controls.Add(Me.lbbanco)
        Me.panelcontennt.Controls.Add(Me.cbbanco)
        Me.panelcontennt.Controls.Add(Me.lbnrodocumento)
        Me.panelcontennt.Controls.Add(Me.tbnrodocumento)
        Me.panelcontennt.Controls.Add(Me.LabelX17)
        Me.panelcontennt.Controls.Add(Me.cbdocumento)
        Me.panelcontennt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelcontennt.Location = New System.Drawing.Point(5, 89)
        Me.panelcontennt.Name = "panelcontennt"
        Me.panelcontennt.Size = New System.Drawing.Size(726, 394)
        Me.panelcontennt.TabIndex = 1
        '
        'tbglosa
        '
        Me.tbglosa.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.tbglosa.Border.Class = "TextBoxBorder"
        Me.tbglosa.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbglosa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbglosa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.tbglosa.Location = New System.Drawing.Point(334, 176)
        Me.tbglosa.Margin = New System.Windows.Forms.Padding(4)
        Me.tbglosa.MaxLength = 300
        Me.tbglosa.Multiline = True
        Me.tbglosa.Name = "tbglosa"
        Me.tbglosa.PreventEnterBeep = True
        Me.tbglosa.Size = New System.Drawing.Size(308, 79)
        Me.tbglosa.TabIndex = 268
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(170, 176)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX1.Size = New System.Drawing.Size(125, 28)
        Me.LabelX1.TabIndex = 267
        Me.LabelX1.Text = "Glosa:"
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.ButtonX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX1.Image = Global.DinoM.My.Resources.Resources.cancel
        Me.ButtonX1.ImageFixedSize = New System.Drawing.Size(40, 40)
        Me.ButtonX1.Location = New System.Drawing.Point(378, 289)
        Me.ButtonX1.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(145, 57)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 266
        Me.ButtonX1.Text = "Salir"
        '
        'Bt1Generar
        '
        Me.Bt1Generar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Bt1Generar.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.Bt1Generar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bt1Generar.Image = Global.DinoM.My.Resources.Resources.cobro
        Me.Bt1Generar.ImageFixedSize = New System.Drawing.Size(40, 40)
        Me.Bt1Generar.Location = New System.Drawing.Point(177, 289)
        Me.Bt1Generar.Margin = New System.Windows.Forms.Padding(4)
        Me.Bt1Generar.Name = "Bt1Generar"
        Me.Bt1Generar.Size = New System.Drawing.Size(193, 57)
        Me.Bt1Generar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bt1Generar.TabIndex = 3
        Me.Bt1Generar.Text = "Cobrar"
        '
        'lbbanco
        '
        Me.lbbanco.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lbbanco.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbbanco.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbbanco.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lbbanco.Location = New System.Drawing.Point(170, 140)
        Me.lbbanco.Margin = New System.Windows.Forms.Padding(4)
        Me.lbbanco.Name = "lbbanco"
        Me.lbbanco.SingleLineColor = System.Drawing.SystemColors.Control
        Me.lbbanco.Size = New System.Drawing.Size(125, 28)
        Me.lbbanco.TabIndex = 264
        Me.lbbanco.Text = "Banco:"
        '
        'cbbanco
        '
        cbbanco_DesignTimeLayout.LayoutString = resources.GetString("cbbanco_DesignTimeLayout.LayoutString")
        Me.cbbanco.DesignTimeLayout = cbbanco_DesignTimeLayout
        Me.cbbanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbbanco.Location = New System.Drawing.Point(334, 142)
        Me.cbbanco.Margin = New System.Windows.Forms.Padding(4)
        Me.cbbanco.Name = "cbbanco"
        Me.cbbanco.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.cbbanco.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.cbbanco.SelectedIndex = -1
        Me.cbbanco.SelectedItem = Nothing
        Me.cbbanco.Size = New System.Drawing.Size(219, 26)
        Me.cbbanco.TabIndex = 2
        Me.cbbanco.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'lbnrodocumento
        '
        Me.lbnrodocumento.AutoSize = True
        Me.lbnrodocumento.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lbnrodocumento.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lbnrodocumento.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnrodocumento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lbnrodocumento.Location = New System.Drawing.Point(170, 111)
        Me.lbnrodocumento.Margin = New System.Windows.Forms.Padding(4)
        Me.lbnrodocumento.Name = "lbnrodocumento"
        Me.lbnrodocumento.SingleLineColor = System.Drawing.SystemColors.Control
        Me.lbnrodocumento.Size = New System.Drawing.Size(132, 20)
        Me.lbnrodocumento.TabIndex = 262
        Me.lbnrodocumento.Text = "Nro Documento:"
        '
        'tbnrodocumento
        '
        Me.tbnrodocumento.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.tbnrodocumento.Border.Class = "TextBoxBorder"
        Me.tbnrodocumento.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tbnrodocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbnrodocumento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.tbnrodocumento.Location = New System.Drawing.Point(334, 108)
        Me.tbnrodocumento.Margin = New System.Windows.Forms.Padding(4)
        Me.tbnrodocumento.MaxLength = 15
        Me.tbnrodocumento.Name = "tbnrodocumento"
        Me.tbnrodocumento.PreventEnterBeep = True
        Me.tbnrodocumento.Size = New System.Drawing.Size(180, 26)
        Me.tbnrodocumento.TabIndex = 1
        '
        'LabelX17
        '
        Me.LabelX17.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX17.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX17.Location = New System.Drawing.Point(170, 63)
        Me.LabelX17.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX17.Name = "LabelX17"
        Me.LabelX17.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX17.Size = New System.Drawing.Size(125, 28)
        Me.LabelX17.TabIndex = 240
        Me.LabelX17.Text = "Tipo de Cobro:"
        '
        'cbdocumento
        '
        cbdocumento_DesignTimeLayout.LayoutString = resources.GetString("cbdocumento_DesignTimeLayout.LayoutString")
        Me.cbdocumento.DesignTimeLayout = cbdocumento_DesignTimeLayout
        Me.cbdocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbdocumento.Location = New System.Drawing.Point(334, 65)
        Me.cbdocumento.Margin = New System.Windows.Forms.Padding(4)
        Me.cbdocumento.Name = "cbdocumento"
        Me.cbdocumento.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.cbdocumento.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.cbdocumento.SelectedIndex = -1
        Me.cbdocumento.SelectedItem = Nothing
        Me.cbdocumento.Size = New System.Drawing.Size(219, 26)
        Me.cbdocumento.TabIndex = 0
        Me.cbdocumento.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.DinoM.My.Resources.Resources.fondo1
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(5, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(726, 84)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(169, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(420, 46)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Documento de Cobro"
        '
        'FR_AyudaCobro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 488)
        Me.Controls.Add(Me.PanelPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(400, 0)
        Me.Name = "FR_AyudaCobro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FR_AyudaCobro"
        Me.PanelPrincipal.ResumeLayout(False)
        Me.panelcontennt.ResumeLayout(False)
        Me.panelcontennt.PerformLayout()
        CType(Me.cbbanco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbdocumento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelPrincipal As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents panelcontennt As Panel
    Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbdocumento As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents lbnrodocumento As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbnrodocumento As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lbbanco As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbbanco As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents Bt1Generar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tbglosa As DevComponents.DotNetBar.Controls.TextBoxX
End Class

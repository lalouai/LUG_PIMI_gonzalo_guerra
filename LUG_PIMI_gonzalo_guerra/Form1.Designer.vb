<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.DGV_jugadas = New System.Windows.Forms.DataGridView()
        Me.btn_agregar = New System.Windows.Forms.Button()
        Me.btn_salir = New System.Windows.Forms.Button()
        CType(Me.DGV_jugadas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV_jugadas
        '
        Me.DGV_jugadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_jugadas.Location = New System.Drawing.Point(12, 12)
        Me.DGV_jugadas.Name = "DGV_jugadas"
        Me.DGV_jugadas.Size = New System.Drawing.Size(618, 660)
        Me.DGV_jugadas.TabIndex = 0
        '
        'btn_agregar
        '
        Me.btn_agregar.Location = New System.Drawing.Point(636, 12)
        Me.btn_agregar.Name = "btn_agregar"
        Me.btn_agregar.Size = New System.Drawing.Size(75, 23)
        Me.btn_agregar.TabIndex = 1
        Me.btn_agregar.Text = "agregar"
        Me.btn_agregar.UseVisualStyleBackColor = True
        '
        'btn_salir
        '
        Me.btn_salir.Location = New System.Drawing.Point(637, 42)
        Me.btn_salir.Name = "btn_salir"
        Me.btn_salir.Size = New System.Drawing.Size(75, 23)
        Me.btn_salir.TabIndex = 2
        Me.btn_salir.Text = "salir"
        Me.btn_salir.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(723, 684)
        Me.Controls.Add(Me.btn_salir)
        Me.Controls.Add(Me.btn_agregar)
        Me.Controls.Add(Me.DGV_jugadas)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.DGV_jugadas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DGV_jugadas As DataGridView
    Friend WithEvents btn_agregar As Button
    Friend WithEvents btn_salir As Button
End Class

Imports LUG_PIMI_gonzalo_guerra

Public Class Form1

    Dim ctrl As Controlador
    Dim jugadas As List(Of Secuencia)
    Dim bindingSource As BindingSource
    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        DGV_jugadas.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        ctrl = New Controlador
        Try
            jugadas = ctrl.listadoJugadas()
            If jugadas.Count > 0 Then
                DGV_jugadas.DataSource = bindingSource
                DGV_jugadas.DataSource = jugadas
            End If
        Catch ex As NullReferenceException
            MsgBox("Sin jugadas para mostrar " + ex.ToString)
        End Try


    End Sub

    Private Sub cargarJugadas(jugadas As List(Of Secuencia))
        DGV_jugadas.DataSource = bindingSource
        DGV_jugadas.DataSource = jugadas
    End Sub

    Private Sub btn_agregar_Click(sender As Object, e As EventArgs) Handles btn_agregar.Click
        ctrl.crearSecuencia()
        cargarJugadas(ctrl.listadoJugadas())
    End Sub

    Private Sub btn_salir_Click(sender As Object, e As EventArgs) Handles btn_salir.Click
        If ctrl.guardar() Then
            Me.Close()
        Else
            MsgBox("Lo siento, no se ha podido guardar las jugadas")
        End If
    End Sub
End Class

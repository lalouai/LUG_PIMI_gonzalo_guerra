Imports LUG_PIMI_gonzalo_guerra

Public Class Form1

    Dim ctrl As Controlador
    Dim bS_juegos As BindingSource
    Dim bS_jugadas As BindingSource

    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        ctrl = New Controlador

        DGV_juegos.RowHeadersVisible = False
        DGV_jugadas.RowHeadersVisible = False

        Dim juegos As List(Of Juego)

        Try
            juegos = ctrl.listadoJuegos()
            If juegos.Count > 0 Then
                DGV_juegos.DataSource = bS_juegos
                DGV_juegos.DataSource = juegos
            End If
        Catch ex As NullReferenceException
            MsgBox("Sin jugadas para mostrar ")
        End Try

    End Sub

    Private Sub btn_agregar_Click(sender As Object, e As EventArgs) Handles btn_agregar.Click
        ctrl.crearJuego()
        cargarJuegos(ctrl.listadoJuegos())
    End Sub

    Private Sub btn_salir_Click(sender As Object, e As EventArgs) Handles btn_salir.Click
        If ctrl.guardar() Then
            Me.Close()
        Else
            MsgBox("Lo siento, no se ha podido guardar las jugadas")
        End If
    End Sub

    Private Sub DGV_juegos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_juegos.CellClick
        If Me.DGV_juegos.SelectedRows.Count > 0 Then
            cargarJugadas(DGV_juegos.SelectedRows(0).DataBoundItem.listaJugadas())
        End If
    End Sub

    Private Sub cargarJugadas(jugadas As List(Of Valor))
        DGV_jugadas.DataSource = bS_jugadas
        DGV_jugadas.DataSource = jugadas
    End Sub

    Private Sub cargarJuegos(juegos As List(Of Juego))
        DGV_juegos.DataSource = bS_juegos
        DGV_juegos.DataSource = juegos
    End Sub


    Private Sub Form1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim result As Integer = MessageBox.Show("Desea salir?" & vbCrLf & "Perderá todos los cambios", "Confirme", MessageBoxButtons.OKCancel)
        If result = DialogResult.Cancel Then
            e.Cancel = True
        End If
    End Sub

End Class

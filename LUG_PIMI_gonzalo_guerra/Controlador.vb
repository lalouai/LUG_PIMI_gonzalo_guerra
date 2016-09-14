Public Class Controlador

    Private dao As DaoXml
    Private jugada As List(Of Secuencia)

    Sub New()
        dao = New DaoXml("persistencia")
        Try
            jugada = dao.cargar()
        Catch ex As Exception
            jugada = New List(Of Secuencia)
        End Try

    End Sub

    Public Sub crearSecuencia()
        Dim actual As Secuencia
        Dim ultima As Secuencia = Nothing
        Dim id As Integer
        Dim anterior As Integer
        Dim valor As Integer

        Try
            ultima = jugada.Last()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        valor = valorNuevo()

        If ultima Is Nothing Then
            id = 1
            anterior = Nothing
        Else
            jugada.Remove(ultima)
            ultima.posterior = valor
            jugada.Add(ultima)
            id = ultima.id + 1
            anterior = ultima.valor
        End If
        actual = New Secuencia(id, anterior)
        actual.valor = valor
        jugada.Add(actual)
    End Sub

    Friend Function listadoJugadas() As List(Of Secuencia)
        Return jugada
    End Function

    Private Function valorNuevo() As Integer
        Return CInt(Math.Floor((4) * Rnd())) + 1
    End Function

    Friend Function guardar() As Boolean
        If dao.guardar(jugada) Then
            Return True
        Else
            Return False
        End If
    End Function
End Class

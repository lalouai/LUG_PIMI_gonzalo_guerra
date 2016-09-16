Public Class Controlador

    Private dao As DaoXml
    Private juegos As List(Of Juego)


    Sub New()

        juegos = New List(Of Juego)

        dao = New DaoXml("persistencia")


        Try
            juegos = dao.cargar()
        Catch ex As Exception
            juegos = New List(Of Juego)
        End Try

    End Sub

    Public Sub crearJuego()
        Dim id As Integer = 0
        Dim juego As Juego
        Try
            If juegos.Count = 0 Then
                id = 1
            Else
                id = juegos.Last().getId() + 1
            End If
        Catch ex As NullReferenceException
            id = 1
        End Try
        juego = New Juego(id)
        juego.agregarJugadas(crearSecuencia(3))
        juegos.Add(juego)
    End Sub



    Private Function crearSecuencia(ByVal Optional cant = 15) As List(Of Valor)
        Dim jugada As List(Of Valor)
        Dim actual As Valor
        Dim ultima As Valor = Nothing
        Dim id As Integer
        Dim anterior As Integer
        Dim valor As Integer

        jugada = New List(Of Valor)

        For i As Integer = 0 To cant - 1

            Try
                ultima = jugada.Last()
            Catch ex As Exception
                ''MsgBox(ex.ToString)
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
            actual = New Valor(id, anterior)
            actual.valor = valor
            jugada.Add(actual)

        Next



        Return jugada
    End Function

    Friend Function listadoJuegos() As List(Of Juego)
        Return juegos
    End Function

    Private Function valorNuevo() As Integer
        Return CInt(Math.Floor((4) * Rnd())) + 1
    End Function

    Friend Function guardar() As Boolean
        If dao.guardar(juegos) Then
            Return True
        Else
            Return False
        End If
    End Function
End Class

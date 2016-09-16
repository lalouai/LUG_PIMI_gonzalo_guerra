Public Class Juego

    Private id As Integer
    Private jugadas As List(Of Valor)

    Sub New(ByVal numero As Integer)
        id = numero
        jugadas = New List(Of Valor)
    End Sub

    Public Sub agregarJugada(ByVal sec As Valor)
        jugadas.Add(sec)
    End Sub

    Public Function listaJugadas() As List(Of Valor)
        Return jugadas
    End Function

    Public Function cantJugadas() As Integer
        Return jugadas.Count
    End Function

    Public Function getId() As Integer
        Return id
    End Function

    Public Sub agregarJugadas(jugadas As List(Of Valor))
        Me.jugadas = jugadas
    End Sub

    Public ReadOnly Property numero As Integer
        Get
            Return id
        End Get
    End Property

    Public ReadOnly Property cantidad As Integer
        Get
            Return jugadas.Count
        End Get
    End Property

End Class

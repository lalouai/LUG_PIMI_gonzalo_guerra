Public Class Secuencia

    Private _id As Integer
    Private _valor As Integer
    Private _anterior As Integer
    Private _posterior As Integer

    Public Sub New(id As Integer, anterior As Integer)
        _id = id
        _anterior = anterior
        _posterior = Nothing
    End Sub

    Public Sub New(ByVal id As Integer, ByVal valor As Integer, ByVal anterior As Integer, ByVal posterior As Integer)
        _id = id
        _valor = valor
        _anterior = anterior
        _posterior = posterior
    End Sub

    Public ReadOnly Property id As Integer
        Get
            Return _id
        End Get
    End Property

    Public Property valor As Integer
        Get
            Return _valor
        End Get
        Set(valor As Integer)
            _valor = valor
        End Set
    End Property

    Public ReadOnly Property anterior
        Get
            Return _anterior
        End Get
    End Property

    Public Property posterior As Integer
        Get
            Return _posterior
        End Get
        Set(posterior As Integer)
            _posterior = posterior
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return "id->" & _id & " valor->" & _valor & " anterior->" & _anterior & " posterior->" & _posterior
    End Function
End Class

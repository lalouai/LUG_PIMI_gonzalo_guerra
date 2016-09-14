Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

Class DaoXml
    Dim documento As XmlDocument
    Dim archivo As String

    Sub New(ByVal archivo As String)
        Me.archivo = archivo + ".xml"
    End Sub

    Public Function cargar() As List(Of Secuencia)
        documento = New XmlDocument()
        Dim lista As List(Of Secuencia)
        Try
            documento.Load(archivo)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        lista = New List(Of Secuencia)

        Dim elemento As XmlNode = documento.DocumentElement.LastChild
        Dim id, anterior, posterior, valor As Integer

        For Each f As XmlNode In elemento.ChildNodes
            For Each objeto As XmlNode In f

                For Each nodo As XmlNode In objeto
                    If nodo.ParentNode.Name = "id" Then
                        id = nodo.Value
                    ElseIf nodo.ParentNode.Name = "valor" Then
                        valor = nodo.Value
                    ElseIf nodo.ParentNode.Name = "anterior" Then
                        anterior = nodo.Value
                    ElseIf nodo.ParentNode.Name = "posterior" Then
                        posterior = nodo.Value
                    End If
                Next

            Next
            lista.Add(New Secuencia(id, valor, anterior, posterior))
        Next
        Return lista
    End Function

    Public Function guardar(jugadas As List(Of Secuencia)) As Boolean
        Dim resultado As Boolean = False

        Try
            Dim archivoxml As New XmlTextWriter(archivo, System.Text.Encoding.UTF8)
            archivoxml.Formatting = Formatting.Indented
            archivoxml.Indentation = 2
            archivoxml.WriteStartDocument(True)
            archivoxml.WriteStartElement("Simon")
            archivoxml.WriteElementString("Juego", 1)
            archivoxml.WriteStartElement("secuencia")
            For Each jugada As Secuencia In jugadas
                archivoxml.WriteStartElement("objeto")
                archivoxml.WriteElementString("id", jugada.id)
                archivoxml.WriteElementString("valor", jugada.valor)
                archivoxml.WriteElementString("anterior", jugada.anterior)
                archivoxml.WriteElementString("posterior", jugada.posterior)
                archivoxml.WriteEndElement()
            Next
            archivoxml.WriteEndElement()
            archivoxml.WriteEndElement()
            archivoxml.WriteEndDocument()
            archivoxml.Close()
            resultado = True
        Catch ex As Exception
            MsgBox(ex.ToString)
            resultado = False
        End Try

        Return resultado
    End Function





End Class
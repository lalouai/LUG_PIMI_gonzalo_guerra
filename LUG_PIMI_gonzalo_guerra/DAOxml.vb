Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

Class DaoXml
    Dim documento As XmlDocument
    Dim archivo As String

    Sub New(ByVal archivo As String)
        Me.archivo = archivo + ".xml"
    End Sub

    Public Function cargar() As List(Of Juego)
        documento = New XmlDocument()
        Dim lista As List(Of Juego)
        Dim juego As Juego
        Try
            documento.Load(archivo)
        Catch ex As Exception
            MsgBox("Lo siento no hay ninguna jugada guardada" & vbCrLf & "Cuando abra la ventana presione crear para inicializar" & vbCrLf & "nuevas jugadas")
        End Try
        lista = New List(Of Juego)

        Dim elemento As XmlNode = documento.DocumentElement
        Dim id, anterior, posterior, valor As Integer

        For Each j As XmlNode In elemento

            If j.Name = "Juego" Then
                juego = New Juego(j.InnerText)
            ElseIf j.Name = "secuencia" Then

                Dim cant = j.Attributes.GetNamedItem("cantidad").Value

                For Each f As XmlNode In j.ChildNodes
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
                    juego.agregarJugada(New Valor(id, valor, anterior, posterior))
                    If juego.cantidad = cant Then
                        lista.Add(juego)
                        Exit For
                    End If
                Next
            End If
        Next
        Return lista
    End Function

    Public Function guardar(jugadas As List(Of Juego)) As Boolean

        Dim resultado As Boolean = False

        Try
            Dim archivoxml As New XmlTextWriter(archivo, System.Text.Encoding.UTF8)
            archivoxml.Formatting = Formatting.Indented
            archivoxml.Indentation = 2
            archivoxml.WriteStartDocument(True)
            archivoxml.WriteStartElement("Simon")
            For Each j As Juego In jugadas
                archivoxml.WriteElementString("Juego", j.getId())
                archivoxml.WriteStartElement("secuencia")
                archivoxml.WriteAttributeString("cantidad", j.cantidad)
                For Each jugada As Valor In j.listaJugadas()
                    archivoxml.WriteStartElement("objeto")
                    archivoxml.WriteElementString("id", jugada.id)
                    archivoxml.WriteElementString("valor", jugada.valor)
                    archivoxml.WriteElementString("anterior", jugada.anterior)
                    archivoxml.WriteElementString("posterior", jugada.posterior)
                    archivoxml.WriteEndElement()
                Next
                archivoxml.WriteEndElement()
            Next
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
Public Class file
    Public Sub write(ByVal input As String, ByVal fileName As String, ByVal append As Boolean) 'Write text to a file
        If IO.File.Exists(fileName) = False Or append = True Then
            IO.File.Create(fileName).Dispose()
        Else
            If MsgBox(fileName & " already exists. Overwrite?", MsgBoxStyle.YesNo + MsgBoxStyle.SystemModal, "Overwrite file?") = MsgBoxResult.Yes Then
                IO.File.Delete(fileName)
            End If
        End If
        Try
            Dim objWriter As New IO.StreamWriter(fileName, True)
            objWriter.WriteLine(input)
            objWriter.Close()
        Catch ex As Exception
            MsgBox("Please close the file first.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Function textBetweenStrings(input As String, startString As String, endString As String) As String 'Find a string within a string using start and stop strings/characters
        Dim x As Integer = (input.IndexOf(startString) + Len(startString))
        Dim output As String = ""
        Try
            While input(x) <> endString(0)
                output += input(x)
                x += 1
            End While
        Catch ex As Exception
            MsgBox("Can't find what you're looking for.")
        End Try
        Return output
    End Function
End Class

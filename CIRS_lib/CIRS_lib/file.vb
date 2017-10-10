Public Class file
    Public Sub write(ByVal input As String, ByVal fileName As String, Optional ByVal append As Boolean = True) 'Write text to a file
        If IO.File.Exists(fileName) = True And append = False Then
            If MsgBox(fileName & " already exists. Are you sure you want to overwrite it?", MsgBoxStyle.YesNo + MsgBoxStyle.SystemModal, "Overwrite file?") = MsgBoxResult.No Then
                append = True
            End If
        End If
        Try
            Dim objWriter As New IO.StreamWriter(fileName, append)
            objWriter.WriteLine(input)
            objWriter.Close()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message & vbCrLf & "Please try closing the file.", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Function parseInString(input As String, startStr As String, Optional ByVal endStr As String = "") 'Find a string within a string using start and stop strings/characters
        Dim output As String = ""
        Dim x As Integer = 0
        Try
            If startStr <> "" Then
                x = (input.IndexOf(startStr) + Len(startStr))
            End If
            If endStr = "" Then
                output = input.Substring(x, Len(input) - x)
            Else
                While input(x) <> endStr(0)
                    output += input(x)
                    x += 1
                End While
            End If
        Catch ex As Exception
            MsgBox("Can't find what you're looking for.")
        End Try
        Return output
    End Function
End Class

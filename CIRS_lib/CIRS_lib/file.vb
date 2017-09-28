Public Class file
    Public Sub writeToFile(ByVal input As String, ByVal fileName As String)
        If IO.File.Exists(fileName) = False Then
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
End Class
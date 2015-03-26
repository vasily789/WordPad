Public Class Form1
    Dim index As Integer
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FindMyText(searchText:=TextBox1.Text, searchStart:=index, searchEnd:=RichTextBox1.TextLength)
    End Sub
    Public Function FindMyText(ByVal searchText As String, ByVal searchStart As Integer, ByVal searchEnd As Integer) As Integer
        ' Initialize the return value to false by default. 
        Dim returnValue As Integer = -1

        ' Ensure that a search string and a valid starting point are specified. 
        If searchText.Length > 0 And searchStart >= 0 Then
            ' Ensure that a valid ending value is provided.
            While index < RichTextBox1.TextLength
                If searchEnd > searchStart Or searchEnd = -1 Then
                    ' Obtain the location of the search string in richTextBox1. 
                    Dim indexToText As Integer = RichTextBox1.Find(searchText, searchStart, searchEnd, RichTextBoxFinds.MatchCase)
                    RichTextBox1.SelectionBackColor = Color.Yellow
                    index = indexToText + index
                    ' Determine whether the text was found in richTextBox1. 
                    If indexToText >= 0 Then
                        ' Return the index to the specified search text.
                        returnValue = indexToText
                    End If
                End If
            End While
        End If

        Return returnValue
    End Function
End Class

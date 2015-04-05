Public Class Form1
    Dim index As Integer
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FindMyText(SearchText:=TextBox1.Text, SearchStartPosition:=index, SearchEndPosition:=WordPadForm.RichTextBox1.TextLength)
        With TextBox1
            .SelectAll()
            .Focus()
        End With
    End Sub

    Public Function FindMyText(ByVal SearchText As String, ByVal SearchStartPosition As Integer, ByVal SearchEndPosition As Integer) As Integer

        ' Initialize the return value to false by default. 
        Dim returnValue As Integer = -1

        If SearchText.Length > 0 And SearchStartPosition >= 0 Then
            Dim FoundTextPosition As Integer = 0

            Dim wordString As String = WordPadForm.RichTextBox1.Text
            WordPadForm.RichTextBox1.Text = ""
            WordPadForm.RichTextBox1.Text = wordString
            While SearchStartPosition < WordPadForm.RichTextBox1.TextLength
                ' Obtain the location of the search string in richTextBox1.
                FoundTextPosition = WordPadForm.RichTextBox1.Find(SearchText, SearchStartPosition, SearchEndPosition, RichTextBoxFinds.None)
                'highlight found text
                WordPadForm.RichTextBox1.SelectionBackColor = Color.Yellow

                'Update the Search Start Position
                If FoundTextPosition > -1 Then
                    SearchStartPosition = FoundTextPosition + 1
                Else
                    SearchStartPosition = WordPadForm.RichTextBox1.TextLength
                End If

                ' Determine whether the text was found in richTextBox1.
                If FoundTextPosition = 0 Then
                    SearchStartPosition += 1
                    ' Return the index to the specified search text.
                    returnValue = FoundTextPosition
                End If
            End While
        End If
        Return returnValue
    End Function

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        With WordPadForm.RichTextBox1
            .SelectAll()
            .SelectionBackColor = Color.White
            .Select(.Text.Length, 0)
        End With
        TextBox1.Clear()
    End Sub

End Class
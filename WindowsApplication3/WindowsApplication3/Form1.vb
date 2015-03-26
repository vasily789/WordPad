Public Class Form1
    Dim index As Integer
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FindMyText(searchText:=TextBox1.Text, searchStartPosition:=index, searchEndPosition:=RichTextBox1.TextLength)
    End Sub
    Public Function FindMyText(ByVal searchText As String, ByVal searchStartPosition As Integer, ByVal searchEndPosition As Integer) As Integer
        ' Initialize the return value to false by default. 
        Dim returnValue As Integer = -1

        ' Ensure that a search string and a valid starting point are specified. 
        If searchText.Length > 0 And searchStartPosition >= 0 Then
            Dim foundTextPosition As Integer = 0
            ' Ensure that a valid ending value is provided.
            While searchStartPosition < RichTextBox1.TextLength
                If caseSensitiveCheckBox.Checked Then
                    ' Obtain the location of the search string in richTextBox1. 
                    foundTextPosition = RichTextBox1.Find(searchText, searchStartPosition, searchEndPosition, RichTextBoxFinds.MatchCase)
                Else
                    ' Obtain the location of the search string in richTextBox1. 
                    foundTextPosition = RichTextBox1.Find(searchText, searchStartPosition, searchEndPosition, RichTextBoxFinds.WholeWord)
                End If


                'highlight found text
                RichTextBox1.SelectionBackColor = Color.Yellow

                'Update the Search Start Position
                If foundTextPosition > -1 Then
                    searchStartPosition = foundTextPosition + 1
                Else
                    searchStartPosition = RichTextBox1.TextLength
                End If

                ' Determine whether the text was found in richTextBox1.
                If foundTextPosition = 0 Then
                    searchStartPosition += 1

                    ' Return the index to the specified search text.
                    returnValue = foundTextPosition
                End If

            End While

        End If

        Return returnValue
    End Function
End Class

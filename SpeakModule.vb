Imports System.Speech.Synthesis

Module SpeakModule

    Dim speaker As New SpeechSynthesizer
    Dim checkedBoolen As Boolean

    Sub Main()
        AddHandler speaker.SpeakCompleted, AddressOf SpeachComplete
        If checkedBoolen = False Then
            checkedBoolen = True
            speaker.SpeakAsync(WordPadForm.RichTextBox1.SelectedText)
        Else
            speaker.SpeakAsyncCancelAll()
        End If
        'Console.ReadLine()
    End Sub

    Private Sub SpeachComplete(ByVal sender As Object, ByVal e As SpeakCompletedEventArgs)
        checkedBoolen = False
    End Sub
End Module

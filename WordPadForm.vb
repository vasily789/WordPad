Imports System.IO

Public Class WordPadForm
    Private TextBoolean As Boolean = False

    Private BoldBoolean As Boolean = False
    Private ItalicBoolean As Boolean = False
    Private UnderlineBoolean As Boolean = False
    Private StrikeoutBoolean As Boolean = False

    Dim StringToPrint As String

    Private Sub BoldToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BoldToolStripButton.Click
        If RichTextBox1.SelectionFont.Italic Then 'its already italic, so set it to regular
            RichTextBox1.SelectionFont = New Font(Convert.ToString(FontStyleStripComboBox.SelectedItem), Convert.ToSingle(FontSizeToolStripComboBox.SelectedItem), FontStyle.Regular)
            'BoldBoolean = False
        Else 'make it italic
            RichTextBox1.SelectionFont = New Font(Convert.ToString(FontStyleStripComboBox.SelectedItem), Convert.ToSingle(FontSizeToolStripComboBox.SelectedItem), FontStyle.Bold)
            'BoldBoolean = True
        End If
    End Sub
    Private Sub ItalicToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItalicToolStripButton.Click
        If RichTextBox1.SelectionFont.Italic Then 'its already italic, so set it to regular
            RichTextBox1.SelectionFont = New Font(FontStyleStripComboBox.SelectedItem.ToString(), Convert.ToSingle(FontSizeToolStripComboBox.SelectedItem), FontStyle.Regular)
            'ItalicBoolean = False
        Else 'make it italic
            RichTextBox1.SelectionFont = New Font(FontStyleStripComboBox.SelectedItem.ToString(), Convert.ToSingle(FontSizeToolStripComboBox.SelectedItem), FontStyle.Italic)
            'ItalicBoolean = True
        End If
    End Sub
    Private Sub UnderlineToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnderlineToolStripButton.Click
        If RichTextBox1.SelectionFont.Italic Then 'its already italic, so set it to regular
            RichTextBox1.SelectionFont = New Font(FontStyleStripComboBox.SelectedItem.ToString(), Convert.ToSingle(FontSizeToolStripComboBox.SelectedItem), FontStyle.Regular)
            'UnderlineBoolean = False
        Else 'make it italic
            RichTextBox1.SelectionFont = New Font(FontStyleStripComboBox.SelectedItem.ToString(), Convert.ToSingle(FontSizeToolStripComboBox.SelectedItem), FontStyle.Underline)
            'UnderlineBoolean = True
        End If
    End Sub
    Private Sub StrikeoutToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StrikeoutToolStripButton.Click
        If RichTextBox1.SelectionFont.Italic Then 'its already italic, so set it to regular
            RichTextBox1.SelectionFont = New Font(FontStyleStripComboBox.SelectedItem.ToString(), Convert.ToSingle(FontSizeToolStripComboBox.SelectedItem), FontStyle.Regular)
            'StrikeoutBoolean = False
        Else 'make it italic
            RichTextBox1.SelectionFont = New Font(FontStyleStripComboBox.SelectedItem.ToString(), Convert.ToSingle(FontSizeToolStripComboBox.SelectedItem), FontStyle.Strikeout)
            'StrikeoutBoolean = True
        End If
    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontColorToolStripButton.Click
        ColorDialog1.ShowDialog()
        RichTextBox1.SelectionColor = ColorDialog1.Color()
    End Sub

    Private Sub Open()
        Dim ResponseDialogResult As DialogResult

        With OpenFileDialog1
            ' Begin in the current folder.
            .InitialDirectory = Directory.GetCurrentDirectory
            .FileName = ""
            .Title = "Select File or Directory for File"
            .DefaultExt = "*.rtf"
            .Filter = "RTF Files|*.rtf"
            ' Display the Open File dialog box.
            ResponseDialogResult = .ShowDialog()
        End With

        ' Make sure user didn't click the Cancel button.
        If ResponseDialogResult <> DialogResult.Cancel Then
            RichTextBox1.Text = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
            Me.Text = OpenFileDialog1.FileName & " - WordPad"
            SaveToolStripButton.Enabled = True
            SaveToolStripMenuItem.Enabled = True
            SaveAsToolStripMenuItem.Enabled = True
            TextBoolean = True
        End If
    End Sub
    Private Sub Save()
        RichTextBox1.SaveFile(OpenFileDialog1.FileName, RichTextBoxStreamType.PlainText)
        TextBoolean = False
    End Sub
    Private Sub SaveAs()
        Dim ResponseDialogResult As DialogResult

        With SaveFileDialog1
            ' Begin in the current folder.
            .InitialDirectory = Directory.GetCurrentDirectory
            .FileName = IO.Path.GetFileNameWithoutExtension(Me.Text.Remove(Me.Text.Length - 10))
            .Title = "Select File or Directory for File"
            .DefaultExt = "*.rtf"
            .Filter = "RTF Files|*.rtf"
            ' Display the Open File dialog box.
            ResponseDialogResult = .ShowDialog()
        End With

        ' Make sure user didn't click the Cancel button.
        If ResponseDialogResult <> DialogResult.Cancel Then
            RichTextBox1.SaveFile(SaveFileDialog1.FileName, RichTextBoxStreamType.PlainText)
            Me.Text = SaveFileDialog1.FileName & " - WordPad"
            TextBoolean = False
            SaveToolStripButton.Enabled = True
            SaveToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub RichTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RichTextBox1.TextChanged
        TextBoolean = True
        SaveAsToolStripMenuItem.Enabled = True
    End Sub

    Private Sub NewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripButton.Click
        If TextBoolean = True Then
            Dim Response As Integer
            Response = MessageBox.Show("Do you want to save changes?", "Saving...", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If Response = vbYes Then
                SaveAs()
                RichTextBox1.Clear()
                SaveToolStripButton.Enabled = False
                SaveToolStripMenuItem.Enabled = False
                SaveAsToolStripMenuItem.Enabled = False
                TextBoolean = False
                Me.Text = "New Rich Text Document.rtf - WordPad"
            ElseIf Response = vbNo Then
                RichTextBox1.Clear()
                SaveToolStripButton.Enabled = False
                SaveToolStripMenuItem.Enabled = False
                SaveAsToolStripMenuItem.Enabled = False
                TextBoolean = False
                Me.Text = "New Rich Text Document.rtf - WordPad"
            End If
        Else
            RichTextBox1.Clear()
            SaveToolStripButton.Enabled = False
            SaveToolStripMenuItem.Enabled = False
            SaveAsToolStripMenuItem.Enabled = False
            TextBoolean = False
            Me.Text = "New Rich Text Document.rtf - WordPad"
        End If
    End Sub
    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        If TextBoolean = False Then
            Open()
        Else
            Dim Response As Integer
            Response = MessageBox.Show("Do you want to save changes?", "Saving...", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If Response = vbYes Then
                SaveAs()
                Open()
            ElseIf Response = vbNo Then
                Open()
            End If
        End If
    End Sub
    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        If TextBoolean = True Then
            Save()
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        SaveToolStripButton_Click(sender, e)
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsToolStripMenuItem.Click
        If TextBoolean = True Then
            SaveAs()
        End If
    End Sub

    Private Sub CopyToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripButton.Click
        RichTextBox1.Copy()
    End Sub

    Private Sub PasteToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripButton.Click
        RichTextBox1.Paste()
    End Sub

    Private Sub CutToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripButton.Click
        RichTextBox1.Cut()
    End Sub

    Private Sub SelectAllToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripButton.Click
        RichTextBox1.SelectAll()
    End Sub

    Private Sub UndoToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoToolStripButton.Click
        RichTextBox1.Undo()
    End Sub

    Private Sub FindToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindToolStripButton.Click
        If TextBoolean = True Then
            Form1.ShowDialog()
        Else
            MessageBox.Show("There is nothing to find")
        End If
    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        OpenToolStripButton_Click(sender, e)
    End Sub

    Private Sub UndoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoToolStripMenuItem.Click
        UndoToolStripButton_Click(sender, e)
    End Sub
    Private Sub RedoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RedoToolStripMenuItem.Click
        RichTextBox1.Redo()
    End Sub
    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        CopyToolStripButton_Click(sender, e)
    End Sub
    Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        PasteToolStripButton_Click(sender, e)
    End Sub
    Private Sub CutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripMenuItem.Click
        CutToolStripButton_Click(sender, e)
    End Sub
    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        SelectAllToolStripButton_Click(sender, e)
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatusBarToolStripMenuItem.Click
        ' Show/close Status bar
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub
    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolBarToolStripMenuItem.Click
        ' Show/close tool bar
        Me.ToolBarStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub
    Private Sub StyleBarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StyleBarToolStripMenuItem.Click
        ' Show/close style bar
        Me.StyleBarStrip.Visible = Me.StyleBarToolStripMenuItem.Checked
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub PrintToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem1.Click
        If PrintDialog1.ShowDialog() = DialogResult.OK Then
            PrintDocument1.Print()
        End If
    End Sub
    Private Sub PrintPreviewToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPreviewToolStripMenuItem1.Click
        ' Print Preview 
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.ShowDialog()
    End Sub
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim PrintFont As New Font(Convert.ToString(FontStyleStripComboBox.SelectedItem), Convert.ToSingle(FontSizeToolStripComboBox.SelectedItem))
        Dim StringToPrint As String = RichTextBox1.Text

        Dim numChars As Integer
        Dim numLines As Integer
        Dim stringForPage As String
        Dim strFormat As New StringFormat
        'based on page setup, define drawable retangle on page
        Dim rectDraw As New RectangleF(e.MarginBounds.Left, e.MarginBounds.Top, e.MarginBounds.Width, e.MarginBounds.Height)
        'define area to determine how much text can fit on a page
        'Make height one line shorter to enshure text doesn't clip
        Dim sizeMeasure As New SizeF(e.MarginBounds.Width, e.MarginBounds.Height - PrintFont.GetHeight(e.Graphics))

        'when drawing long strings, break between words
        strFormat.Trimming = StringTrimming.Word
        'compute how many char and lines can fit based on sizeMeazure
        e.Graphics.MeasureString(StringToPrint, PrintFont, sizeMeasure, strFormat, numChars, numLines)
        'compute string that will fit on a page
        stringForPage = StringToPrint.Substring(0, numChars)
        'Print string on current page
        e.Graphics.DrawString(stringForPage, PrintFont, Brushes.Black, rectDraw, strFormat)
        'If there is more text, indicate there are more pages
        If numChars < StringToPrint.Length Then
            'subtract text from string that has been printed
            StringToPrint = StringToPrint.Substring(numChars)
            e.HasMorePages = True
        Else
            e.HasMorePages = False
            'All text has been printed, so restoring string
            StringToPrint = RichTextBox1.Text
        End If
    End Sub


    Private Sub LeftAlignToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LeftAlignToolStripButton.Click
        ' Alignment left
        RichTextBox1.SelectionAlignment = HorizontalAlignment.Left
    End Sub
    Private Sub CenterAlignToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CenterAlignToolStripButton.Click
        ' Alignment center
        RichTextBox1.SelectionAlignment = HorizontalAlignment.Center
    End Sub
    Private Sub RightAlignToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RightAlignToolStripButton.Click
        ' Alignment right
        RichTextBox1.SelectionAlignment = HorizontalAlignment.Right
    End Sub

    Private Sub SpeakToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpeakToolStripButton.Click

        SpeakModule.Main()

    End Sub

    Private Sub WordPadForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim colFonts As Drawing.Text.InstalledFontCollection = New Drawing.Text.InstalledFontCollection
        Dim fontFamilies() As FontFamily = colFonts.Families
        Dim i As Integer

        For i = 0 To fontFamilies.Length - 1 Step 1
            FontStyleStripComboBox.Items.Add(fontFamilies(i).Name)
        Next
        Me.Text = "New Rich Text Document.rtf - WordPad"
    End Sub
    Private Sub FontStyleStripComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontStyleStripComboBox.SelectedIndexChanged
        RichTextBox1.SelectionFont = New System.Drawing.Font(FontStyleStripComboBox.Text, FontSizeToolStripComboBox.Text)
    End Sub

    Private Sub FontSizeToolStripComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontSizeToolStripComboBox.SelectedIndexChanged
        Dim Size As Single = Trim(Mid(FontSizeToolStripComboBox.Text, 1, 2))
        RichTextBox1.SelectionFont = New System.Drawing.Font(FontStyleStripComboBox.Text, Size, FontStyle.Regular)
    End Sub
End Class

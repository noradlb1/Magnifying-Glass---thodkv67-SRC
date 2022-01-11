Imports System.Drawing.Drawing2D

Public Class Form2
    Public OriSize As Integer = 100
    Public MagnSize As Integer = 150
    Dim bmpOriCopy As Bitmap
    Dim bmpgrOriCopy As Graphics
    Dim rctOri As Rectangle
    Dim rctOriCopy As Rectangle
    Dim rctMagn As Rectangle
    Dim Desktop As Image
    Dim picgr As Graphics
    Dim gpath As GraphicsPath
    Dim rgn As Region
    Dim pn As Pen = New Pen(Color.FromArgb(74, 74, 80), 15)

    Private Sub Form2_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        bmpOriCopy = New Bitmap(OriSize, OriSize)
        bmpgrOriCopy = Graphics.FromImage(bmpOriCopy)
        rctOriCopy = New Rectangle(0, 0, OriSize, OriSize)
        rctOri = New Rectangle(0, 0, OriSize, OriSize)
        rctMagn = New Rectangle(0, 0, MagnSize, MagnSize)

        Dim SC As New ScreenShot.ScreenCapture
        PictureBox1.SetBounds(0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)
        PictureBox1.Image = SC.CaptureScreen
        Desktop = PictureBox1.Image.Clone
        picgr = PictureBox1.CreateGraphics
    End Sub

    Private Sub Form2_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        rgn.Dispose()
        gpath.Dispose()
        bmpgrOriCopy.Dispose()
        bmpOriCopy.Dispose()
        Desktop.Dispose()
        picgr.Dispose()
    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        rctOri.X = e.X - OriSize \ 2
        rctOri.Y = e.Y - OriSize \ 2
        bmpgrOriCopy.DrawImage(PictureBox1.Image, rctOriCopy, rctOri, GraphicsUnit.Pixel)
        picgr.DrawImage(Desktop, rctMagn, rctMagn, GraphicsUnit.Pixel)
        rctMagn.X = e.X - MagnSize \ 2
        rctMagn.Y = e.Y - MagnSize \ 2
        gpath = New GraphicsPath
        gpath.AddEllipse(rctMagn)
        rgn = New Region(gpath)
        picgr.Clip = rgn
        picgr.DrawImage(bmpOriCopy, rctMagn, rctOriCopy, GraphicsUnit.Pixel)
        picgr.DrawEllipse(pn, rctMagn)
    End Sub

    Private Sub Form2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Keys.Escape Then
            Me.Close()
            Form1.Show()
            Form1.Opacity = 0
            Form1.Timer1.Enabled = True
            Form1.Timer1.Start()
            Cursor.Show()
        End If
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor.Hide()
    End Sub
End Class
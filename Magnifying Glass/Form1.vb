Imports System.Drawing.Drawing2D

Public Class Form1

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Opacity += 0.1
        If Me.Opacity >= 0.85 Then
            Timer1.Enabled = False
            Timer1.Stop()
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Me.Opacity -= 0.1
        If Me.Opacity <= 0.05 Then
            Me.Opacity = 0
            Timer2.Enabled = False
            Timer2.Stop()
            Me.Hide()
            Dim MagnSize As Integer = 150
            Form2.MagnSize = MagnSize
            Form2.OriSize = 100
            Form2.Show(Me)
        End If
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Me.Opacity -= 0.1
        If Me.Opacity <= 0.05 Then
            Me.Opacity = 0
            Timer3.Enabled = False
            Timer3.Stop()
            Me.Close()
        End If
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select e.KeyCode
            Case Keys.Escape
                Timer3.Interval = 10
                Timer3.Enabled = True
                Timer3.Start()
        End Select
    End Sub

    Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Keys.ControlKey AndAlso Keys.Shift AndAlso Keys.M Then
            Timer2.Interval = 10
            Timer2.Enabled = True
            Timer2.Start()
        End If
    End Sub
End Class

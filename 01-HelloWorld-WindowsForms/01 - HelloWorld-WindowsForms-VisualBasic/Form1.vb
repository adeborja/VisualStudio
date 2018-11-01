Imports _01___HelloWorld_WindowsForms_Csharp



Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim nombre As String
        nombre = Me.TextBox1.Text
        'MessageBox.Show("Hola " & nombre)

        Dim persona1 As New clsPersona
        persona1.nombre = "Angel"
        persona1.apellido = "David"

        MessageBox.Show("Hola " & persona1.nombre & " " & persona1.apellido)
    End Sub
End Class

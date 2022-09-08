Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.Configuration.ConfigurationManager
Imports System.Configuration
Imports System.Runtime.InteropServices

Public Class Registro
    Dim conn As New MySqlConnection
    Dim objetoconexion As New conexion
    Dim cmd As MySqlCommand
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox6.Text = TextBox7.Text Then
            conn = objetoconexion.AbrirCon
            Try
                cmd = conn.CreateCommand
                cmd.CommandText = "INSERT INTO usuario(id_usuario, Nombre, Apellido, Direccion_usuario, telefono_Usuario, usuario, contra) VALUES ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "');"
                cmd.ExecuteNonQuery()
                conn.Close()
                conn.Dispose()
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()
                TextBox6.Clear()
                TextBox7.Clear()

            Catch ex As Exception

            End Try
            Me.Close()
            Form1.Show()
        Else
            MessageBox.Show("Las contraseñas no coinciden")
            TextBox7.Clear()
            TextBox7.Focus()
        End If
    End Sub

End Class
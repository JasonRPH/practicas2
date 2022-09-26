Imports System.Runtime.InteropServices
Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class Form1
    Dim conexion As MySqlConnection = New MySqlConnection
    Dim comando As MySqlCommand = New MySqlCommand


    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        comando.Connection = conexion
        Try
            conexion.ConnectionString = "Server = localhost; Database = practicas; Uid = root; Pwd =;"
            conexion.Open()

        Catch ex As Exception

        End Try
        comando.CommandText = "SELECT * FROM usuario WHERE usuario = '" + TextBox1.Text + "' AND contra = '" + TextBox2.Text + "'"
        Dim r As MySqlDataReader
        r = comando.ExecuteReader
        If r.HasRows <> False Then
            r.Read()
            Me.Hide()
            Seleccion_de_modulo.Show()
        Else
            MessageBox.Show("Usuario o contraseña incorrectos")
            TextBox2.Clear()
            TextBox2.Focus()

        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox2.PasswordChar = ""
        Else
            TextBox2.PasswordChar = "*"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Registro.Show()
        Me.Hide()

    End Sub
End Class


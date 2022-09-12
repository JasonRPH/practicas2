Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration
Public Class Cuentas
    Dim CadenaConexion = "Server = localhost;Database=practicas;User id=root;Password=;Port=3306;"
    Dim conn As New MySqlConnection(CadenaConexion)
    Dim cmd As MySqlCommand
    Private Sub Cuentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
    End Sub
    Private Sub limpiar()
        NumericUpDown1.Text = ""
        TextBox1.Text = ""
        TextBox3.Text = ""
    End Sub
End Class
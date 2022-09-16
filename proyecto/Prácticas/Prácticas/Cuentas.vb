Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration
Public Class Cuentas
    Public cuentas_bancarias(20) As String
    Public saldo_cuentas(20) As String
    Public creditos_cuentas(20) As String
    Public debitos_cuentas(20) As String
    Public contador_cuentas As Integer
    Dim CadenaConexion = "Server = localhost;Database=practicas;User id=root;Password=;Port=3306;"
    Dim conn As New MySqlConnection(CadenaConexion)
    Dim cmd As MySqlCommand
    Private Sub Cuentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Call conectar()
    End Sub
    Private Sub conectar()

        Dim squery As String = "SELECT cuenta_bancarias,creditos,saldo, debito from bancos "
        Dim adpt As New MySqlDataAdapter(squery, conn)
        Dim ds As New DataSet()
        adpt.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        conn.Close()
        conn.Dispose()
    End Sub
    Private Sub limpiar()
        TextBox1.Text = ""
        NumericUpDown1.Text = ""
        TextBox3.Text = ""
        NumericUpDown2.Text = ""
    End Sub
End Class
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

        Dim squery As String = "SELECT cuenta_bancarias,creditos,saldo, debito from cuentas "
        Dim adpt As New MySqlDataAdapter(squery, conn)
        Dim ds As New DataSet()
        adpt.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        conn.Close()
        conn.Dispose()
    End Sub
    Private Sub limpiar()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)

    End Sub
    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        Dim cmd As New MySqlCommand("INSERT  INTO cuentas (cuentas_bancarias,creditos,saldo,debito) VALUES ('" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "')", conn)


        cmd.ExecuteNonQuery()

        If conn.State = ConnectionState.Open Then
            conn.Clone()
        End If
        conectar()
        conn.Close()
        conn.Dispose()


        limpiar()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim cmd1 As New MySqlCommand("UPDATE cuentas SET cuentas_bancarias = '" & TextBox1.Text & "' WHERE codigo_cuentas = " & TextBox2.Text, conn)
        cmd1.ExecuteNonQuery()
        Dim cmd2 As New MySqlCommand("UPDATE cuentas SET creditos = '" & TextBox2.Text & "' WHERE codigo_cuentas = " & TextBox2.Text, conn)
        cmd2.ExecuteNonQuery()
        Dim cmd3 As New MySqlCommand("UPDATE cuentas SET saldo = '" & TextBox3.Text & "' WHERE codigo_cuentas = " & TextBox2.Text, conn)
        cmd3.ExecuteNonQuery()
        Dim cmd4 As New MySqlCommand("UPDATE cuentass SET debito = '" & TextBox4.Text & "' WHERE codigo_cuentas = " & TextBox2.Text, conn)
        cmd4.ExecuteNonQuery()
        conectar()
        limpiar()
        conn.Close()
        conn.Dispose()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If




        conectar()
        conn.Close()
        conn.Dispose()
        limpiar()
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim row As DataGridViewRow = DataGridView1.CurrentRow

        TextBox1.Text = row.Cells(1).Value.ToString()
        TextBox2.Text = row.Cells(2).Value.ToString()
        TextBox3.Text = row.Cells(3).Value.ToString()
        TextBox4.Text = row.Cells(4).Value.ToString()

    End Sub
End Class
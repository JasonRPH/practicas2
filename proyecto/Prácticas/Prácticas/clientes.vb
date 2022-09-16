Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration
Public Class clientes
    Public codigo_cliente(20) As String
    Public nombre_cliente(20) As String
    Public direccion_cliente(20) As String
    Public telefono_cliente(20) As String
    Public nit_cliente(20) As Integer
    Public contador_clientes As Integer
    Dim CadenaConexion = "Server = localhost;Database=practicas;User id=root;Password=;Port=3306;"
    Dim conn As New MySqlConnection(CadenaConexion)
    Dim cmd As MySqlCommand
    Private Sub clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Call conectar()
    End Sub
    Private Sub conectar()

        Dim squery As String = "SELECT codigo_cliente, nombre,direccion, telefono,nit from clientes "
        Dim adpt As New MySqlDataAdapter(squery, conn)
        Dim ds As New DataSet()
        adpt.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        conn.Close()
        conn.Dispose()
    End Sub
    Private Sub limpiar()
        TextBox4.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox5.Text = ""
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

        Dim cmd As New MySqlCommand("INSERT  INTO clientes (nombre,direccion,telefono, nit) VALUES ('" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & TextBox3.Text & "', '" & TextBox5.Text & "')", conn)


        cmd.ExecuteNonQuery()

        If conn.State = ConnectionState.Open Then
            conn.Clone()
        End If
        conectar()
        conn.Close()
        conn.Dispose()


        limpiar()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Dim squery As String = "SELECT * FROM clientes"
        Dim adpt As New MySqlDataAdapter(squery, conn)
        Dim ds As New DataSet()
        adpt.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        conn.Close()
        conn.Dispose()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        limpiar()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim cmd1 As New MySqlCommand("UPDATE clientes SET nombre = '" & TextBox1.Text & "' WHERE codigo_cliente = " & TextBox4.Text, conn)
        cmd1.ExecuteNonQuery()
        Dim cmd2 As New MySqlCommand("UPDATE clientes SET direccion = '" & TextBox2.Text & "' WHERE codigo_cliente = " & TextBox4.Text, conn)
        cmd2.ExecuteNonQuery()
        Dim cmd3 As New MySqlCommand("UPDATE clientes SET telefono = '" & TextBox3.Text & "' WHERE codigo_cliente = " & TextBox4.Text, conn)
        cmd3.ExecuteNonQuery()
        Dim cmd4 As New MySqlCommand("UPDATE clientes SET nit = '" & TextBox5.Text & "' WHERE codigo_cliente = " & TextBox4.Text, conn)
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

        Dim cmd1 As New MySqlCommand("DELETE from clientes WHERE codigo_cliente = " & TextBox4.Text, conn)
        cmd1.ExecuteNonQuery()


        conectar()
        conn.Close()
        conn.Dispose()
        limpiar()

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim row As DataGridViewRow = DataGridView1.CurrentRow

        TextBox4.Text = row.Cells(0).Value.ToString()
        TextBox1.Text = row.Cells(1).Value.ToString()
        TextBox2.Text = row.Cells(2).Value.ToString()
        TextBox3.Text = row.Cells(3).Value.ToString()
        TextBox5.Text = row.Cells(4).Value.ToString()
    End Sub
End Class
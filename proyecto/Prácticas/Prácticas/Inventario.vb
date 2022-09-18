Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration
Public Class Inventario
    Public producto_inventario(20) As String
    Public codigo_inventario(20) As String
    Public cantidad_inventario(20) As String
    Public precio_inventario(20) As String
    Public contador_inventario As Integer
    Dim CadenaConexion = "Server = localhost;Database=practicas;User id=root;Password=;Port=3306;"
    Dim conn As New MySqlConnection(CadenaConexion)
    Dim cmd As MySqlCommand
    Private Sub Inventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Call conectar()
    End Sub
    Private Sub conectar()
        Dim squery As String = "SELECT id_inventario,producto,precio,cantidad from Inventario "
        Dim adpt As New MySqlDataAdapter(squery, conn)
        Dim ds As New DataSet()
        adpt.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        conn.Close()
        conn.Dispose()
    End Sub
    Private Sub limpiar()
        TextBox2.Text = ""
        ComboBox1.Text = ""
        TextBox4.Text = ""
        TextBox3.Text = ""
    End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)

    End Sub
    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim cmd As New MySqlCommand("INSERT  INTO inventario (producto,precio,cantidad) VALUES ( '" & ComboBox1.Text & "', '" & TextBox4.Text & "', '" & TextBox3.Text & "')", conn)


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
        Dim cmd1 As New MySqlCommand("UPDATE inventario SET producto = '" & ComboBox1.Text & "' WHERE id_inventario = " & TextBox2.Text, conn)
        cmd1.ExecuteNonQuery()
        Dim cmd2 As New MySqlCommand("UPDATE inventario SET precio = '" & TextBox4.Text & "' WHERE id_inventario = " & TextBox2.Text, conn)
        cmd2.ExecuteNonQuery()
        Dim cmd3 As New MySqlCommand("UPDATE inventario SET cantidad = '" & TextBox3.Text & "' WHERE id_inventario = " & TextBox2.Text, conn)
        cmd3.ExecuteNonQuery()
        conectar()
        limpiar()
        conn.Close()
        conn.Dispose()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        Dim cmd1 As New MySqlCommand("DELETE from inventario WHERE id_inventario = " & TextBox2.Text, conn)
        cmd1.ExecuteNonQuery()


        conectar()
        conn.Close()
        conn.Dispose()
        limpiar()

    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Seleccion_de_modulo.Show()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim row As DataGridViewRow = DataGridView1.CurrentRow

        TextBox2.Text = row.Cells(0).Value.ToString()
        ComboBox1.Text = row.Cells(1).Value.ToString()
        TextBox4.Text = row.Cells(2).Value.ToString()
        TextBox3.Text = row.Cells(3).Value.ToString()
    End Sub
End Class
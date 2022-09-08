Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration
Public Class clientes
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

        Dim squery As String = "SELECT id_clientes, numero, nit, nombre, direccion,"
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




        cmd.ExecuteNonQuery()

        If conn.State = ConnectionState.Open Then
            conn.Clone()
        End If
        conectar()
        conn.Close()
        conn.Dispose()


        limpiar()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class
Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration
Public Class Inventario
    Dim conn As New MySqlConnection
    Dim objetoconexion As New conexion
    Dim cmd As MySqlCommand

    Private Sub mostrar()
        conn = objetoconexion.AbrirCon
        Dim query As String = "select * from inventario"
        Dim adpt As New MySqlDataAdapter(query, conn)
        Dim ds As New DataSet()
        adpt.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        conn.Close()
        conn.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        conn = objetoconexion.AbrirCon
        Try
            cmd = conn.CreateCommand
            cmd.CommandText = "INSERT INTO inventario(producto, cantidad, precio) VALUES ( '" & TextBox1.Text & "', '" & NumericUpDown1.Value & "', '" & TextBox3.Text & "');"

            cmd.ExecuteNonQuery()
            conn.Close()
            conn.Dispose()
            TextBox1.Clear()
            NumericUpDown1.Value = 0
            TextBox3.Clear()
            mostrar()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim row As DataGridViewRow = DataGridView1.CurrentRow
        Try
            TextBox1.Text = row.Cells(0).Value.ToString()
            NumericUpDown1.Text = row.Cells(1).Value.ToString()
            TextBox3.Text = row.Cells(2).Value.ToString()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        conn = objetoconexion.AbrirCon
        Try
            cmd = conn.CreateCommand
            cmd.CommandText = "UPDATE inventario SET producto =@nom, cantidad =@can, precio=@prec WHERE id_producto =@cod"
            cmd.Parameters.AddWithValue("@nom", TextBox1.Text)
            cmd.Parameters.AddWithValue("@can", NumericUpDown1.Text)
            cmd.Parameters.AddWithValue("@prec", TextBox3.Text)
            mostrar()
            conn.Close()
            conn.Dispose()
            TextBox1.Clear()
            NumericUpDown1.Value = 0
            TextBox3.Clear()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        conn = objetoconexion.AbrirCon

        Try
            cmd = conn.CreateCommand
            cmd.CommandText = "delete from inventario where producto =@nom"
            cmd.Parameters.AddWithValue("@nom", TextBox1.Text)
            cmd.ExecuteNonQuery()
            mostrar()

            conn.Close()
            conn.Dispose()
            TextBox1.Clear()
            NumericUpDown1.Value = 0
            TextBox3.Clear()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Inventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar()

    End Sub
End Class
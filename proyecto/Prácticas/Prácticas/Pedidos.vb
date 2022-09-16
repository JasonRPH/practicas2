Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration
Public Class Pedidos
    Public codigo_pedido(20) As String
    Public codigo_cliente(20) As String
    Public direccion_pedido(20) As String
    Public producto_pedido(20) As String
    Public fecha_pedido(20) As Integer
    Public precio_pedido(20) As Integer
    Public cantidad_pedido(20) As Integer
    Public contador_pedido As Integer
    Dim CadenaConexion = "Server = localhost;Database=practicas;User id=root;Password=;Port=3306;"
    Dim conn As New MySqlConnection(CadenaConexion)
    Dim cmd As MySqlCommand

    Private Sub Pedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Call conectar()
        Dim squery As String = "SELECT codigo_cliente from clientes "

        Dim adpt As New MySqlDataAdapter(squery, conn)
        Dim ds As New DataSet()
        adpt.Fill(ds)
        ComboBox3.DataSource = ds.Tables(0).

    End Sub
    Private Sub conectar()

        Dim squery As String = "SELECT codigo_pedido, codigo_cliente,direccion,producto,fecha_pedido,precio,cantidad from pedidos "
        Dim adpt As New MySqlDataAdapter(squery, conn)
        Dim ds As New DataSet()
        adpt.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        conn.Close()
        conn.Dispose()
    End Sub
    Private Sub limpiar()
        TextBox3.Text = ""
        ComboBox3.Text = ""
        TextBox1.Text = ""
        DateTimePicker1.Text = ""
        ComboBox2.Text = ""
        NumericUpDown1.Text = ""
        ComboBox1.Text = ""
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

        '        ´´Dim cmd As New MySqlCommand("INSERT  INTO pedidos (codigo_cliente,nombre_cliente ,direccion,nit,producto,fecha_pedido,precio,cantidad) VALUES ('" & combobox3.Text & "', '" & TextBox1.Text & "', '" & datetimepicker1.Text & "', '" & combobox2.Text & "','" & numericupdown1.Text & "','" & combobox1.Text & "')", conn)



        cmd.ExecuteNonQuery()

        If conn.State = ConnectionState.Open Then
            conn.Clone()
        End If
        conectar()
        conn.Close()
        conn.Dispose()


        limpiar()
    End Sub

    Private Sub button2_Click(sender As Object, e As EventArgs) Handles button2.Click
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        'Dim cmd1 As New MySqlCommand("UPDATE pedidos SET codigo_cliente = '" & textbox3.Text & "' WHERE codigo_pedido = " & TextBox3.Text, conn)
        'cmd1.ExecuteNonQuery()
        Dim cmd2 As New MySqlCommand("UPDATE pedidos SET nombre_cliente = '" & ComboBox3.Text & "' WHERE codigo_pedido = " & TextBox3.Text, conn)
        cmd2.ExecuteNonQuery()
        Dim cmd3 As New MySqlCommand("UPDATE pedidos SET direccion = '" & TextBox1.Text & "' WHERE codigo_pedido = " & TextBox3.Text, conn)
        cmd3.ExecuteNonQuery()
        'Dim cmd1 As New MySqlCommand("UPDATE pedidos SET nit = '" & datetimepicker1.Text & "' WHERE codigo_pedido = " & TextBox3.Text, conn)
        'cmd1.ExecuteNonQuery()
        Dim cmd2 As New MySqlCommand("UPDATE pedidos SET direccion = '" & TextBox1.Text & "' WHERE codigo_pedido = " & TextBox3.Text, conn)
        cmd2.ExecuteNonQuery()
        Dim cmd3 As New MySqlCommand("UPDATE pedidos SET producto = '" & DateTimePicker1.Text & "' WHERE codigo_pedido = " & TextBox3.Text, conn)
        cmd3.ExecuteNonQuery()
        Dim cmd4 As New MySqlCommand("UPDATE pedidos SET fecha_pedido = '" & ComboBox2.Text & "' WHERE codigo_pedido = " & TextBox3.Text, conn)
        cmd4.ExecuteNonQuery()
        Dim cmd5 As New MySqlCommand("UPDATE pedidos SET precio = '" & NumericUpDown1.Text & "' WHERE codigo_pedido = " & TextBox3.Text, conn)
        cmd5.ExecuteNonQuery()
        Dim cmd6 As New MySqlCommand("UPDATE pedidos SET cantidad = '" & ComboBox1.Text & "' WHERE codigo_pedido = " & TextBox3.Text, conn)
        cmd6.ExecuteNonQuery()
        conectar()
        limpiar()
        conn.Close()
        conn.Dispose()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        Dim cmd1 As New MySqlCommand("DELETE from pedidos WHERE codigo_pedido = " & TextBox3.Text, conn)
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

        TextBox3.Text = row.Cells(1).Value.ToString()
        ComboBox3.Text = row.Cells(2).Value.ToString()
        TextBox1.Text = row.Cells(1).Value.ToString()
        DateTimePicker1.Text = row.Cells(3).Value.ToString()
        ComboBox2.Text = row.Cells(4).Value.ToString()
        NumericUpDown1.Text = row.Cells(5).Value.ToString()
        ComboBox1.Text = row.Cells(2).Value.ToString()
    End Sub
End Class
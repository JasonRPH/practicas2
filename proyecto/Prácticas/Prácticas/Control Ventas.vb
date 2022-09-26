Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration
Public Class Control_Ventas
    Public codigo_control_ventas(20) As String
    Public codigo_cliente(20) As String
    Public fecha_control_ventas(20) As String
    Public producto_control_ventas(20) As Integer
    Public precio_control_ventas(20) As Integer
    Public cantidad_control_ventas(20) As Integer
    Public total_control_ventas(20) As Integer
    Public contador_control_ventas As String
    Dim CadenaConexion = "Server = localhost;Database=practicas;User id=root;Password=;Port=3306;"
    Dim conn As New MySqlConnection(CadenaConexion)
    Dim cmd As MySqlCommand
    Private Sub Control_Ventas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CadenaConexion = "Driver={MySQL ODBC 5.3 ANSI Driver};Server=127.0.0.1;Database=practicas;User=root;Password=;Option=3;"
        Dim cnn As New ADODB.Connection
        Dim rs As New ADODB.Recordset

        cnn.Open(CadenaConexion)
        rs.Open("SELECT codigo_cliente from clientes ", cnn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)
        While Not rs.EOF
            ComboBox3.Items.Add(rs.Fields(0).Value)
            rs.MoveNext()
        End While
        rs.Close()
        rs.Open("SELECT id_inventario from inventario ", cnn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)
        While Not rs.EOF
            ComboBox1.Items.Add(rs.Fields(0).Value)
            rs.MoveNext()
        End While
        rs.Close()
        cnn.Close()

        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Call conectar()


    End Sub
    Private Sub conectar()

        Dim squery As String = "SELECT codigo_control_ventas, codigo_cliente,fecha,producto,precio,cantidad,total from control_ventas "
        Dim adpt As New MySqlDataAdapter(squery, conn)
        Dim ds As New DataSet()
        adpt.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        conn.Close()
        conn.Dispose()
    End Sub
    Private Sub limpiar()
        TextBox1.Text = ""
        ComboBox3.Text = ""
        DateTimePicker1.Text = ""
        ComboBox1.Text = ""
        TBprecio.Text = ""
        TBcantidad.Text = ""
        TBtotal.Text = ""
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
        Dim fecha As Date
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        fecha = DateTimePicker1.Value
        Dim cmd As New MySqlCommand("INSERT  INTO control_ventas (codigo_cliente,fecha,producto,precio,cantidad,total) VALUES ('" & ComboBox3.Text & "', '" & fecha.Year & "-" & fecha.Month & "-" & fecha.Day & "', '" & ComboBox1.Text & "','" & TBprecio.Text & "','" & TBcantidad.Text & "','" & TBtotal.Text & "')", conn)

        MsgBox(" han sido ingresado los datos")

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
        Dim fecha As Date
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        fecha = DateTimePicker1.Value

        Dim cmd1 As New MySqlCommand("UPDATE control_ventas SET codigo_cliente = '" & ComboBox3.Text & "' WHERE codigo_control_ventas = " & TextBox1.Text, conn)
        cmd1.ExecuteNonQuery()
        Dim cmd2 As New MySqlCommand("UPDATE control_ventas SET fecha = '" & fecha.Year & "-" & fecha.Month & "-" & fecha.Day & "' WHERE codigo_control_ventas = " & TextBox1.Text, conn)
        cmd2.ExecuteNonQuery()
        Dim cmd3 As New MySqlCommand("UPDATE control_ventas SET producto = '" & ComboBox1.Text & "' WHERE codigo_control_ventas = " & TextBox1.Text, conn)
        cmd3.ExecuteNonQuery()
        Dim cmd4 As New MySqlCommand("UPDATE control_ventas SET precio = '" & TBprecio.Text & "' WHERE codigo_control_ventas = " & TextBox1.Text, conn)
        cmd4.ExecuteNonQuery()
        Dim cmd5 As New MySqlCommand("UPDATE control_ventas SET cantidad = '" & TBcantidad.Text & "' WHERE codigo_control_ventas = " & TextBox1.Text, conn)
        cmd5.ExecuteNonQuery()
        Dim cmd6 As New MySqlCommand("UPDATE control_ventas SET total = '" & TBtotal.Text & "' WHERE codigo_control_ventas = " & TextBox1.Text, conn)
        cmd6.ExecuteNonQuery()
        MsgBox(" ha sido actualizado control de ventas ")
        conectar()
        limpiar()
        conn.Close()
        conn.Dispose()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        Dim cmd1 As New MySqlCommand("DELETE from control_ventas WHERE codigo_control_ventas = " & TextBox1.Text, conn)
        cmd1.ExecuteNonQuery()
        MsgBox(" han sido eliminado este control de ventas")

        conectar()
        conn.Close()
        conn.Dispose()
        limpiar()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim row As DataGridViewRow = DataGridView1.CurrentRow

        TextBox1.Text = row.Cells(0).Value.ToString()
        ComboBox3.Text = row.Cells(1).Value.ToString()
        DateTimePicker1.Text = row.Cells(2).Value
        ComboBox1.Text = row.Cells(3).Value.ToString()
        TBprecio.Text = row.Cells(4).Value
        TBcantidad.Text = row.Cells(5).Value
        TBtotal.Text = row.Cells(6).Value
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        Dim CadenaConexion = "Driver={MySQL ODBC 5.3 ANSI Driver};Server=127.0.0.1;Database=practicas;User=root;Password=;Option=3;"
        Dim cnn As New ADODB.Connection
        Dim rs As New ADODB.Recordset

        cnn.Open(CadenaConexion)
        rs.Open("SELECT * from clientes where codigo_cliente = " & ComboBox3.Text, cnn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)
        If Not rs.EOF Then
            Label11.Text = rs.Fields("nombre").Value
            Label10.Text = rs.Fields("direccion").Value
            Label9.Text = rs.Fields("nit").Value
        End If
        rs.Close()
        cnn.Close()
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim CadenaConexion = "Driver={MySQL ODBC 5.3 ANSI Driver};Server=127.0.0.1;Database=practicas;User=root;Password=;Option=3;"
        Dim cnn As New ADODB.Connection
        Dim rs As New ADODB.Recordset

        cnn.Open(CadenaConexion)
        rs.Open("SELECT * from inventario where id_inventario = " & ComboBox1.Text, cnn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)
        If Not rs.EOF Then
            Label2.Text = rs.Fields("producto").Value
            TBprecio.Text = rs.Fields("precio").Value
            TBcantidad.Text = rs.Fields("cantidad").Value
        End If
        rs.Close()
        cnn.Close()
    End Sub

    Private Sub TBcantidad_TextChanged(sender As Object, e As EventArgs) Handles TBcantidad.TextChanged
        If TBcantidad.Text.Length > 0 Then
            TBtotal.Text = TBcantidad.Text * TBprecio.Text

        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Seleccion_de_modulo.Show()
    End Sub
End Class
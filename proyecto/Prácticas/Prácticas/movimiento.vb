Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration
Public Class movimiento
    Public codigo_movimiento(20) As String
    Public tipo_movimiento(20) As String
    Public numero_movimiento(20) As String
    Public cuenta_movimiento(20) As String
    Public descripcion_movimiento(20) As Integer
    Public monto_movimiento As Integer
    Dim CadenaConexion = "Server = localhost;Database=practicas;User id=root;Password=;Port=3306;"
    Dim conn As New MySqlConnection(CadenaConexion)
    Dim cmd As MySqlCommand
    Private Sub movimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CadenaConexion = "Driver={MySQL ODBC 5.3 ANSI Driver};Server=127.0.0.1;Database=practicas;User=root;Password=;Option=3;"
        Dim cnn As New ADODB.Connection
        Dim rs As New ADODB.Recordset

        cnn.Open(CadenaConexion)
        rs.Open("SELECT numero_cuenta from cuentas ", cnn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockReadOnly)
        While Not rs.EOF
            ComboBox2.Items.Add(rs.Fields(0).Value)
            rs.MoveNext()
        End While
        rs.Close()
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Call conectar()
    End Sub
    Private Sub conectar()

        Dim squery As String = "SELECT codigo_movimiento, tipo,numero,cuenta,descripcion,monto from movimiento "
        Dim adpt As New MySqlDataAdapter(squery, conn)
        Dim ds As New DataSet()
        adpt.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        conn.Close()
        conn.Dispose()
    End Sub
    Private Sub limpiar()
        TextBox1.Text = ""
        ComboBox1.Text = ""
        TextBox2.Text = ""
        ComboBox2.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
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

        Dim cmd As New MySqlCommand("INSERT  INTO movimiento (tipo,numero,cuenta, descripcion, monto) VALUES ('" & ComboBox1.Text & "', '" & TextBox2.Text & "', '" & ComboBox2.Text & "', '" & TextBox5.Text & "' , '" & TextBox6.Text & "')", conn)
        cmd.ExecuteNonQuery()
        If ComboBox1.Text = "CHEQUES" Then
            Dim cmd1 As New MySqlCommand("UPDATE cuentas SET cheques = cheques + " & TextBox6.Text & " WHERE cuenta_bancaria = '" & ComboBox2.Text & "'", conn)
            cmd1.ExecuteNonQuery()
            Dim cmd2 As New MySqlCommand("UPDATE cuentas SET saldo = saldo - " & TextBox6.Text & " WHERE cuenta_bancaria = '" & ComboBox2.Text & "'", conn)
            cmd2.ExecuteNonQuery()
        End If
        If ComboBox1.Text = "DEPOSITOS" Then
            Dim cmd3 As New MySqlCommand("UPDATE cuentas SET depositos = depositos + " & TextBox6.Text & " WHERE cuenta_bancaria = '" & ComboBox2.Text & "'", conn)
            cmd3.ExecuteNonQuery()
            Dim cmd4 As New MySqlCommand("UPDATE cuentas SET saldo = saldo + " & TextBox6.Text & " WHERE cuenta_bancaria = '" & ComboBox2.Text & "'", conn)
            cmd4.ExecuteNonQuery()
            MsgBox(" este movimiento ha sido ingresado")
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        Dim cmd As New MySqlCommand("DELETE from movimiento WHERE codigo_movimiento = " & TextBox1.Text, conn)
        cmd.ExecuteNonQuery()
        If ComboBox1.Text = "CHEQUES" Then

            Dim cmd3 As New MySqlCommand("UPDATE cuentas SET cheques = cheques - " & TextBox6.Text & " WHERE cuenta_bancaria = '" & ComboBox2.Text & "'", conn)
            cmd3.ExecuteNonQuery()
            Dim cmd4 As New MySqlCommand("UPDATE cuentas SET saldo = saldo + " & TextBox6.Text & " WHERE cuenta_bancaria = '" & ComboBox2.Text & "'", conn)
            cmd4.ExecuteNonQuery()
        End If
        If ComboBox1.Text = "DEPOSITOS" Then
            Dim cmd4 As New MySqlCommand("UPDATE cuentas SET depositos = depositos - " & TextBox6.Text & " WHERE cuenta_bancaria = '" & ComboBox2.Text & "'", conn)
            cmd4.ExecuteNonQuery()
            Dim cmd5 As New MySqlCommand("UPDATE cuentas SET saldo = saldo - " & TextBox6.Text & " WHERE cuenta_bancaria = '" & ComboBox2.Text & "'", conn)
            cmd5.ExecuteNonQuery()
            MsgBox(" este movimiento ha sido eliminado")
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

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim row As DataGridViewRow = DataGridView1.CurrentRow

        TextBox1.Text = row.Cells(0).Value.ToString()
        ComboBox1.Text = row.Cells(1).Value.ToString()
        TextBox2.Text = row.Cells(2).Value.ToString()
        ComboBox2.Text = row.Cells(3).Value.ToString()
        TextBox5.Text = row.Cells(4).Value.ToString()
        TextBox6.Text = row.Cells(5).Value.ToString()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Seleccion_de_modulo.Show()
    End Sub
End Class
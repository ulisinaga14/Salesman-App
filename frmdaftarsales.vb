Imports Oracle.DataAccess.Client
Public Class frmdaftarsales
    Dim con As New OracleConnection
    Dim cmd As New OracleCommand
    Dim sql As String
    Dim da As New OracleDataAdapter
    Dim ds As New DataSet
    Sub daftarsales()
        DGV.Columns.Clear()
        'header()
        ds.Tables.Clear()

        sql = "Select * from salesman where id_salesman like'%" & txtcari.Text & "%' or name like'%" & txtcari.Text & "%' order by id_salesman asc"
        ' sql = "Select * from salesman order by id_salesman asc"

        bukadatabase()
        da = New OracleDataAdapter(sql, con)
        da.Fill(ds, "salesman")
      
        DGV.DataSource = ds.Tables("Salesman")
    End Sub

    Sub bukadatabase()
        con = New OracleConnection
        Try
            con.ConnectionString = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME =pdborcl.com))); user id=salesman;password=sales"
            con.Open()
            'MsgBox("Koneksi berhasil")

        Catch ex As Exception
            MsgBox("Terjadi kesalahan koneksi")
        End Try

    End Sub
    Sub header()
        Try
            DGV.Columns(0).Width = 100
            DGV.Columns(1).Width = 200
            DGV.Columns(2).Width = 100
            DGV.Columns(3).Width = 100
            DGV.Columns(0).HeaderText = "ID Salesman"
            DGV.Columns(1).HeaderText = "Nama Salesman"
            DGV.Columns(2).HeaderText = "City"
            DGV.Columns(3).HeaderText = "Commission"
        Catch ex As Exception

        End Try
    End Sub
    Private Sub frmdaftarsales_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        header()
        daftarsales()


    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        Frminputsalesman.ShowDialog()

    End Sub

    Private Sub txtcari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcari.TextChanged
        '  header()
        daftarsales()
    End Sub

    Private Sub DGV_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellContentClick

    End Sub
End Class
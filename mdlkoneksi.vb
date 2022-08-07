Imports Oracle.DataAccess.Client
Module mdlkoneksi
    Public con As New OracleConnection
    Public cmd As New OracleCommand
    Public sql As String
    Public da As New OracleDataAdapter
    Public ds As New DataSet
    Public rd As OracleDataReader
    Public Sub bukadatabase()
        con = New OracleConnection
        Try
            con.ConnectionString = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME =pdborcl.com))); user id=salesman;password=sales"
            con.Open()
            'MsgBox("Koneksi berhasil")

        Catch ex As Exception
            MsgBox("Terjadi kesalahan koneksi")
        End Try

    End Sub
End Module

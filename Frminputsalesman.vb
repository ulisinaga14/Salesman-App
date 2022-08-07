Imports Oracle.DataAccess.Client
Public Class Frminputsalesman
  
    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If txtid.Text.Trim = "" Then MsgBox("ID Salesman tidak boleh kosong") : Exit Sub
        If txtname.Text.Trim = "" Then MsgBox("Name tidak boleh kosong") : Exit Sub
        bukadatabase()
        If btnsave.Text = "SAVE" Then
            sql = "Insert into salesman values('" & txtid.Text & "','" & txtname.Text & "','" & txtcity.Text & "'," & txtcomision.Text & ")"
        Else
            sql = "Update salesman set name='" & txtname.Text & "',city='" & txtcity.Text & "',comission='" & txtcomision.Text & "' where id_salesman='" & txtid.Text & "'"
        End If

        cmd = New OracleCommand(sql, con)
        cmd.ExecuteNonQuery()
        frmdaftarsales.daftarsales()
        MsgBox("Data tersimpan berhasil")
        clearobject()

    End Sub

    Sub clearobject()
        txtid.Clear()
        txtname.Clear()
        txtcomision.Clear()
        txtcity.Clear()

    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Me.Dispose()

    End Sub
End Class

Imports Oracle.DataAccess.Client

Public Class frmlistsales

    Sub displaydata()
        ds.Tables.Clear()

        sql = "Select * from salesman where id_salesman like'%" & txtcari.Text & "%' or name like '%" & txtcari.Text & "%' order by id_salesman asc"
        bukadatabase()
        da = New OracleDataAdapter(sql, con)
        da.Fill(ds, "salesman")
        DGV.DataSource = ds.Tables("salesman")

    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        displaydata()

    End Sub

    Private Sub frmlistsales_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        displaydata()
    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        Frminputsalesman.btnsave.Text = "SAVE"
        Frminputsalesman.ShowDialog()

    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        sql = "Delete from salesman where id_salesman='" & DGV.SelectedCells(0).Value & "'"
        bukadatabase()
        cmd = New OracleCommand(sql, con)
        cmd.ExecuteNonQuery()
        MsgBox("Success Deleted")
        displaydata()

    End Sub

    Private Sub btnedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedit.Click
        sql = "Select * from salesman where id_salesman='" & DGV.SelectedCells(0).Value & "'"
        bukadatabase()
        cmd = New OracleCommand(sql, con)
        rd = cmd.ExecuteReader
        If rd.Read Then
            Frminputsalesman.btnsave.Text = "EDIT"
            Frminputsalesman.txtid.Text = rd("id_salesman")
            Frminputsalesman.txtname.Text = rd("name")
            Frminputsalesman.txtcity.Text = rd("city")
            Frminputsalesman.txtcomision.Text = rd("comission")
            Frminputsalesman.ShowDialog()
        End If
    End Sub

    Private Sub txtcari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcari.TextChanged
        displaydata()

    End Sub
End Class
Public Class frmEnv

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        Me.Close()

    End Sub

    Private Sub frmEnv_Load(sender As Object, e As EventArgs) Handles Me.Load

        cboSec.DropDownStyle = ComboBoxStyle.DropDownList
        For i As Integer = 3 To 10
            cboSec.Items.Add(i)
        Next

        txtCompanyIDX.Text = DecryptString(GetIni("Settings", "CompanyIdx", gAppPath))
        txtCompanyCode.Text = DecryptString(GetIni("Settings", "CompanyCode", gAppPath))

        Dim savedSec As String = GetIni("Settings", "Sec", gAppPath)
        If IsNumeric(savedSec) AndAlso CInt(savedSec) >= 3 AndAlso CInt(savedSec) <= 10 Then
            cboSec.Text = savedSec
        Else
            cboSec.Text = "10"
        End If

    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim result As DialogResult = MessageBox.Show("설정을 저장하시겠습니까? 설정 변경후 Golf Server 프로그램 재 실행 바랍니다.", "설정 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            PutIni("Settings", "CompanyIdx", EncryptString(txtCompanyIDX.Text.Trim), gAppPath)
            PutIni("Settings", "CompanyCode", EncryptString(txtCompanyCode.Text.Trim), gAppPath)
            PutIni("Settings", "Sec", cboSec.Text.Trim, gAppPath)
            Me.Close()
        End If

    End Sub

End Class
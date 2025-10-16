<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEnv
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEnv))
        btnExit = New Button()
        btnSave = New Button()
        pnlCompanyCode = New Panel()
        Label2 = New Label()
        txtCompanyCode = New TextBox()
        pnlCompanyIDX = New Panel()
        Label1 = New Label()
        txtCompanyIDX = New TextBox()
        Panel1 = New Panel()
        Label3 = New Label()
        Label4 = New Label()
        cboSec = New ComboBox()
        pnlCompanyCode.SuspendLayout()
        pnlCompanyIDX.SuspendLayout()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnExit
        ' 
        btnExit.BackColor = Color.MidnightBlue
        btnExit.Font = New Font("맑은 고딕", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(129))
        btnExit.ForeColor = Color.White
        btnExit.Location = New Point(250, 212)
        btnExit.Name = "btnExit"
        btnExit.Size = New Size(106, 48)
        btnExit.TabIndex = 2
        btnExit.Text = "닫 기"
        btnExit.UseVisualStyleBackColor = False
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = Color.MidnightBlue
        btnSave.Font = New Font("맑은 고딕", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(129))
        btnSave.ForeColor = Color.White
        btnSave.Location = New Point(89, 212)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(106, 48)
        btnSave.TabIndex = 2
        btnSave.Text = "저 장"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' pnlCompanyCode
        ' 
        pnlCompanyCode.BackColor = SystemColors.ActiveCaption
        pnlCompanyCode.Controls.Add(Label2)
        pnlCompanyCode.Location = New Point(37, 94)
        pnlCompanyCode.Name = "pnlCompanyCode"
        pnlCompanyCode.Size = New Size(112, 33)
        pnlCompanyCode.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("맑은 고딕", 12F, FontStyle.Bold)
        Label2.Location = New Point(10, 6)
        Label2.Name = "Label2"
        Label2.Size = New Size(90, 21)
        Label2.TabIndex = 0
        Label2.Text = "컴퍼니코드"
        ' 
        ' txtCompanyCode
        ' 
        txtCompanyCode.Font = New Font("맑은 고딕", 14F, FontStyle.Bold)
        txtCompanyCode.Location = New Point(155, 95)
        txtCompanyCode.Name = "txtCompanyCode"
        txtCompanyCode.Size = New Size(264, 32)
        txtCompanyCode.TabIndex = 5
        ' 
        ' pnlCompanyIDX
        ' 
        pnlCompanyIDX.BackColor = SystemColors.ActiveCaption
        pnlCompanyIDX.Controls.Add(Label1)
        pnlCompanyIDX.Location = New Point(37, 38)
        pnlCompanyIDX.Name = "pnlCompanyIDX"
        pnlCompanyIDX.Size = New Size(112, 33)
        pnlCompanyIDX.TabIndex = 3
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("맑은 고딕", 12F, FontStyle.Bold)
        Label1.Location = New Point(10, 6)
        Label1.Name = "Label1"
        Label1.Size = New Size(85, 21)
        Label1.TabIndex = 0
        Label1.Text = "컴퍼니IDX"
        ' 
        ' txtCompanyIDX
        ' 
        txtCompanyIDX.Font = New Font("맑은 고딕", 14F, FontStyle.Bold)
        txtCompanyIDX.Location = New Point(155, 38)
        txtCompanyIDX.Name = "txtCompanyIDX"
        txtCompanyIDX.Size = New Size(139, 32)
        txtCompanyIDX.TabIndex = 5
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.ActiveCaption
        Panel1.Controls.Add(Label3)
        Panel1.Location = New Point(37, 151)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(112, 33)
        Panel1.TabIndex = 3
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("맑은 고딕", 12F, FontStyle.Bold)
        Label3.Location = New Point(15, 6)
        Label3.Name = "Label3"
        Label3.Size = New Size(80, 21)
        Label3.TabIndex = 0
        Label3.Text = "서버 갱신"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(250, 161)
        Label4.Name = "Label4"
        Label4.Size = New Size(19, 15)
        Label4.TabIndex = 6
        Label4.Text = "초"
        ' 
        ' cboSec
        ' 
        cboSec.Font = New Font("맑은 고딕", 14F, FontStyle.Bold)
        cboSec.FormattingEnabled = True
        cboSec.Location = New Point(157, 151)
        cboSec.Name = "cboSec"
        cboSec.Size = New Size(87, 33)
        cboSec.TabIndex = 7
        ' 
        ' frmEnv
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(456, 284)
        Controls.Add(cboSec)
        Controls.Add(Label4)
        Controls.Add(txtCompanyIDX)
        Controls.Add(txtCompanyCode)
        Controls.Add(pnlCompanyIDX)
        Controls.Add(Panel1)
        Controls.Add(pnlCompanyCode)
        Controls.Add(btnSave)
        Controls.Add(btnExit)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        KeyPreview = True
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmEnv"
        StartPosition = FormStartPosition.CenterScreen
        Text = "환경설정"
        pnlCompanyCode.ResumeLayout(False)
        pnlCompanyCode.PerformLayout()
        pnlCompanyIDX.ResumeLayout(False)
        pnlCompanyIDX.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents pnlCompanyCode As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCompanyCode As TextBox
    Friend WithEvents pnlCompanyIDX As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCompanyIDX As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cboSec As ComboBox
End Class

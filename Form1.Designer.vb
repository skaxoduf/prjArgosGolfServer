<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        pnlGolfDemon = New Panel()
        WebView21 = New Microsoft.Web.WebView2.WinForms.WebView2()
        txtGolfDemonDisp = New TextBox()
        pnlMain = New Panel()
        btnExit = New Button()
        btnClear = New Button()
        btnEnv = New Button()
        pnlGolfDemon.SuspendLayout()
        CType(WebView21, ComponentModel.ISupportInitialize).BeginInit()
        pnlMain.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlGolfDemon
        ' 
        pnlGolfDemon.BorderStyle = BorderStyle.FixedSingle
        pnlGolfDemon.Controls.Add(WebView21)
        pnlGolfDemon.Controls.Add(txtGolfDemonDisp)
        pnlGolfDemon.Location = New Point(12, 88)
        pnlGolfDemon.Name = "pnlGolfDemon"
        pnlGolfDemon.Size = New Size(745, 419)
        pnlGolfDemon.TabIndex = 2
        ' 
        ' WebView21
        ' 
        WebView21.AllowExternalDrop = True
        WebView21.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        WebView21.CreationProperties = Nothing
        WebView21.DefaultBackgroundColor = Color.White
        WebView21.ForeColor = Color.White
        WebView21.Location = New Point(19, 44)
        WebView21.Name = "WebView21"
        WebView21.Size = New Size(689, 338)
        WebView21.TabIndex = 1
        WebView21.Visible = False
        WebView21.ZoomFactor = 1R
        ' 
        ' txtGolfDemonDisp
        ' 
        txtGolfDemonDisp.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        txtGolfDemonDisp.ForeColor = Color.White
        txtGolfDemonDisp.Location = New Point(9, 9)
        txtGolfDemonDisp.Multiline = True
        txtGolfDemonDisp.Name = "txtGolfDemonDisp"
        txtGolfDemonDisp.Size = New Size(724, 399)
        txtGolfDemonDisp.TabIndex = 0
        ' 
        ' pnlMain
        ' 
        pnlMain.Controls.Add(btnExit)
        pnlMain.Controls.Add(btnClear)
        pnlMain.Controls.Add(btnEnv)
        pnlMain.Location = New Point(12, 12)
        pnlMain.Name = "pnlMain"
        pnlMain.Size = New Size(745, 69)
        pnlMain.TabIndex = 3
        ' 
        ' btnExit
        ' 
        btnExit.BackColor = Color.MidnightBlue
        btnExit.Font = New Font("맑은 고딕", 16F, FontStyle.Bold)
        btnExit.ForeColor = Color.White
        btnExit.Location = New Point(618, 11)
        btnExit.Name = "btnExit"
        btnExit.Size = New Size(116, 48)
        btnExit.TabIndex = 0
        btnExit.Text = "종 료"
        btnExit.UseVisualStyleBackColor = False
        ' 
        ' btnClear
        ' 
        btnClear.BackColor = Color.MidnightBlue
        btnClear.Font = New Font("맑은 고딕", 14F, FontStyle.Bold)
        btnClear.ForeColor = Color.White
        btnClear.Location = New Point(131, 13)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(116, 48)
        btnClear.TabIndex = 0
        btnClear.Text = "화면초기화"
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' btnEnv
        ' 
        btnEnv.BackColor = Color.MidnightBlue
        btnEnv.Font = New Font("맑은 고딕", 16F, FontStyle.Bold)
        btnEnv.ForeColor = Color.White
        btnEnv.Location = New Point(9, 13)
        btnEnv.Name = "btnEnv"
        btnEnv.Size = New Size(116, 48)
        btnEnv.TabIndex = 0
        btnEnv.Text = "환경설정"
        btnEnv.UseVisualStyleBackColor = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        ClientSize = New Size(769, 519)
        Controls.Add(pnlMain)
        Controls.Add(pnlGolfDemon)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "ArgosAPT Golf Server"
        pnlGolfDemon.ResumeLayout(False)
        pnlGolfDemon.PerformLayout()
        CType(WebView21, ComponentModel.ISupportInitialize).EndInit()
        pnlMain.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents pnlGolfDemon As Panel
    Friend WithEvents pnlMain As Panel
    Friend WithEvents btnEnv As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents txtGolfDemonDisp As TextBox
    Friend WithEvents WebView21 As Microsoft.Web.WebView2.WinForms.WebView2
    Friend WithEvents btnClear As Button

End Class

Imports Microsoft.Web.WebView2.Core
Imports System.ComponentModel
Imports System.Threading
Imports System.IO ' Path 관련 기능을 위해 추가
Imports System.Net.Http ' HttpClient 사용을 위해 추가
Imports Newtonsoft.Json ' JSON 파싱을 위해 NuGet 패키지 추가 필요


Public Class Form1
    Private WithEvents trayIcon As New NotifyIcon()
    Private WithEvents trayMenu As New ContextMenuStrip()
    Private mainTimer As Timer
    Private WithEvents refreshTimer As New System.Windows.Forms.Timer()

    Private isExiting As Boolean = False

    Private WithEvents tmrLog1 As New System.Windows.Forms.Timer()
    Private rnd As New Random()

    Private systemWords As New List(Of String) From {
        "Initializing kernel...",
        "System.Core.dll loaded.",
        "Authenticating user...",
        "Access granted.",
        "Compiling shader module...",
        "Memory allocation: 0x7FFD... OK",
        "Connecting to secure node...", "Firewall rule updated.", "Packet sent... ACK received.",
        "Decrypting data block...", "Running diagnostics...", "CPU usage: normal",
        "Disk I/O check... PASS", "Syncing with NTP server...", "Host resolved.",
        "Establishing TLSv1.3 connection...", "Handshake complete.", "Daemon process started.",
        "Querying database...", "Record found.", "Closing connection.", "Buffer overflow detected... patched.",
        "Executing query : 1 Row Recv.....",
        "Transaction started.",
        "Commit complete.",
        "Insex Complete.",
        "Data Receive : INFRARED_02 ACTIVATED"
    }
    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' 폼 설정
        Me.Text = "ArgosAPT Golf Server"
        '  Me.Size = New System.Drawing.Size(1024, 768)

        WebView21.Visible = False  ' 웹뷰는 숨긴다.

        If Await subFormLoad() = False Then
            Using frm As New frmEnv()
                frm.ShowDialog()
            End Using
            WriteLog("Golf Server 프로그램 재 실행 요망!!!", LOG_TO_FILE, LOG_FILE_NAME)
            Return
        End If

        If WebView21 IsNot Nothing Then
            ' WebView2 초기화
            Await WebView21.EnsureCoreWebView2Async(Nothing)
            ' NavigationCompleted 이벤트 핸들러 추가
            AddHandler WebView21.CoreWebView2.NavigationCompleted, AddressOf CoreWebView2_NavigationCompleted
            ' NavigationStarting : 페이지 로드 시도 로그 남기는용도
            AddHandler WebView21.CoreWebView2.NavigationStarting, AddressOf CoreWebView2_NavigationStarting
        Else
            WriteLog("Golf Server 컨트롤을 찾을 수 없습니다. Golf Server 기능 비활성화.", LOG_TO_FILE, LOG_FILE_NAME)
        End If


        ' 프로그램 시작 시 웹페이지 호출
        Dim url As String = $"http://julist.webpos.co.kr/Golf/Server/Server.asp?Company_IDX={gCompanyIdx}&Company_Code={gCompanyCode}&sec={gSec}"
        WebView21.Source = New Uri(url)


        ' 웹페이지 새로고침 타이머 설정 (5분에 한번)
        refreshTimer.Interval = 300000 ' 60,000 밀리초 = 1분
        refreshTimer.Start()


        ' 트레이 메뉴 설정
        trayMenu.Items.Add("화면보기", Nothing, AddressOf ShowWindow)
        trayMenu.Items.Add("종료", Nothing, AddressOf ExitApplication)

        ' 트레이 아이콘 설정
        trayIcon.Icon = Me.Icon
        trayIcon.Text = "ArgosAPT Golf Server"
        trayIcon.Visible = True
        trayIcon.ContextMenuStrip = trayMenu ' 메뉴 연결

        TmrFormLoad()

    End Sub
    Private Sub TmrFormLoad()
        ' 첫 번째 타이머 설정
        tmrLog1.Interval = rnd.Next(2000, 5000)  ' 2초~5초사이
        tmrLog1.Start()
    End Sub
    ' 첫 번째 타이머 이벤트: 랜덤 단어 표시
    Private Sub tmrLog1_Tick(sender As Object, e As EventArgs) Handles tmrLog1.Tick
        ' 랜덤 단어 선택
        Dim randomIndex As Integer = rnd.Next(0, systemWords.Count)
        Dim randomWord As String = systemWords(randomIndex)

        ' 텍스트 박스에 추가
        AppendLog(txtGolfDemonDisp, randomWord)

        ' 다음 실행 간격을 다시 랜덤으로 설정
        tmrLog1.Interval = rnd.Next(2000, 5000)
    End Sub
    Private Async Function subFormLoad() As Task(Of Boolean)

        ' 현재 모니터 해상도 가져오기 (웹뷰를 최대화 하지않음...)
        'Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        'Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height

        If Config_Load() = False Then
            Return False
        End If
        Return True

    End Function
    ''' <summary>
    ''' 로그를 텍스트 박스에 표시하고, 선택적으로 파일에 날짜별로 기록합니다.
    ''' </summary>
    ''' <param name="message">기록할 로그 메시지입니다.</param>
    ''' <param name="writeToFile">로그를 파일에 기록할지 여부 (True/False)입니다.</param>
    ''' <param name="baseFileName">로그 파일의 기본 이름입니다. (예: "FingerAuth.log")</param>
    Private Sub WriteLog(message As String, Optional writeToFile As Boolean = False, Optional baseFileName As String = "AppLog.log")
        ' 1. 타임스탬프가 포함된 전체 로그 메시지 생성
        Dim logEntry As String = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}"

        ' 2. 화면의 텍스트 박스에 로그 추가 (UI 스레드 접근 처리 포함)
        If txtGolfDemonDisp.InvokeRequired Then
            txtGolfDemonDisp.Invoke(New Action(Sub()
                                                   txtGolfDemonDisp.AppendText(logEntry & Environment.NewLine)
                                               End Sub))
        Else
            txtGolfDemonDisp.AppendText(logEntry & Environment.NewLine)
        End If

        ' 3. 파일에 로그 기록 (writeToFile이 True일 경우)
        If writeToFile Then
            Try
                ' --- 파일명에 날짜를 추가하는 로직 (수정된 부분) ---
                ' (1) 기본 파일명에서 이름과 확장자를 분리합니다.
                '     예: "FingerAuth.log" -> "FingerAuth", ".log"
                Dim fileNameWithoutExt As String = IO.Path.GetFileNameWithoutExtension(baseFileName)
                Dim fileExtension As String = IO.Path.GetExtension(baseFileName)

                ' (2) 오늘 날짜를 "yyyy-MM-dd" 형식의 문자열로 만듭니다.
                Dim currentDate As String = DateTime.Now.ToString("yyyy-MM-dd")

                ' (3) "파일명_날짜.확장자" 형식으로 새로운 파일명을 조합합니다.
                '     예: "FingerAuth_2025-09-19.log"
                Dim datedFileName As String = $"{fileNameWithoutExt}_{currentDate}{fileExtension}"

                Dim logDirectory As String = My.Application.Info.DirectoryPath
                Dim logFilePath As String = IO.Path.Combine(logDirectory, datedFileName)

                Using writer As New IO.StreamWriter(logFilePath, True)
                    writer.WriteLine(logEntry)
                End Using

            Catch ex As Exception
                ' 파일 쓰기 실패 시 화면에만 오류 로그를 남깁니다.
                Dim errorLog As String = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] FILE LOGGING ERROR: {ex.Message}"
                If txtGolfDemonDisp.InvokeRequired Then
                    txtGolfDemonDisp.Invoke(New Action(Sub()
                                                           txtGolfDemonDisp.AppendText(errorLog & Environment.NewLine)
                                                       End Sub))
                Else
                    txtGolfDemonDisp.AppendText(errorLog & Environment.NewLine)
                End If
            End Try
        End If
    End Sub
    ' 텍스트 박스에 로그를 추가하는 공통 함수
    Private Sub AppendLog(textBox As TextBox, message As String)
        ' 타임스탬프와 함께 메시지 추가
        Dim logEntry As String = $"[{DateAndTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] {message}{Environment.NewLine}"
        textBox.AppendText(logEntry)

        If textBox.Lines.Length > 200 Then  ' 텍스트박스에 200라인 이상이면 50라인을 삭제
            Dim newLines As String() = textBox.Lines.Skip(50).ToArray()
            textBox.Text = String.Join(Environment.NewLine, newLines)
        End If

        ' 스크롤을 항상 맨 아래로 이동
        textBox.SelectionStart = textBox.Text.Length
        textBox.ScrollToCaret()   ' 스크롤을 맨 아래로 이동
    End Sub
    Private Sub CoreWebView2_NavigationStarting(sender As Object, e As CoreWebView2NavigationStartingEventArgs)
        ' WebView2가 무언가를 로드하려고 시도 중임을 알려줍니다.

        WriteLog($"Golf Server 탐색 시작", LOG_TO_FILE, LOG_FILE_NAME)
    End Sub
    Private Sub CoreWebView2_NavigationCompleted(sender As Object, e As CoreWebView2NavigationCompletedEventArgs)

        WriteLog($"Golf Server 이벤트 시작", LOG_TO_FILE, LOG_FILE_NAME)

        If e.IsSuccess Then
            WriteLog($"Golf Server 로드 성공", LOG_TO_FILE, LOG_FILE_NAME)
        Else
            WriteLog($"Golf Server 로드 실패: {WebView21.Source.ToString()}, 오류 상태: {e.WebErrorStatus}, HTTP 상태: {e.HttpStatusCode}", LOG_TO_FILE, LOG_FILE_NAME)
            Me.Invoke(Sub()
                          MessageBox.Show($"Golf Server 로드 실패: {WebView21.Source.ToString()}{Environment.NewLine}오류 상태: {e.WebErrorStatus}{Environment.NewLine}HTTP 상태 코드: {e.HttpStatusCode}", "WebView2 오류", MessageBoxButtons.OK, MessageBoxIcon.Error)
                      End Sub)

        End If
    End Sub
    Private Function Config_Load() As Boolean

        Config_Load = True
        Try
            gAppPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), INI_FILENAME)
            gCompanyIdx = DecryptString(GetIni("Settings", "CompanyIDX", gAppPath))
            gCompanyCode = DecryptString(GetIni("Settings", "CompanyCode", gAppPath))

            Dim secValueString As String = GetIni("Settings", "Sec", gAppPath)
            If IsNumeric(secValueString) AndAlso CInt(secValueString) >= 3 AndAlso CInt(secValueString) <= 10 Then
                gSec = CInt(secValueString)
            Else
                gSec = 10
            End If

            If gCompanyIdx = "" Or gCompanyCode = "" Then
                WriteLog($"Golf Server 설정이 잘못되었습니다.", LOG_TO_FILE, LOG_FILE_NAME)
                Config_Load = False
            End If

        Catch ex As Exception
            WriteLog($"설정 파일을 읽는 중 오류가 발생했습니다: " & ex.Message, LOG_TO_FILE, LOG_FILE_NAME)
            Config_Load = False
        End Try

    End Function
    ' 폼 크기 변경 시 트레이로 이동
    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Hide()
            trayIcon.Visible = True
        End If
    End Sub
    Private Sub TrayIcon_DoubleClick(sender As Object, e As EventArgs) Handles trayIcon.DoubleClick
        ShowWindow()
    End Sub
    Private Sub ShowWindow()
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        ' 트레이 상태일 때만 Visible을 false로 변경하는 것이 좋지만,
        ' 단순화를 위해 여기서는 보일 때마다 false 처리
    End Sub
    Private Sub ExitApplication()
        If MessageBox.Show("Golf Server를 종료하시겠습니까?", "확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub
    Private Sub btnEnv_Click(sender As Object, e As EventArgs) Handles btnEnv.Click
        If AuthenticateWithPassword() = True Then
            Using frm As New frmEnv()
                frm.ShowDialog()
            End Using
        End If
    End Sub
    ''' <summary>
    ''' 로그를 지정된 텍스트 박스에 표시하고, 선택적으로 파일에 날짜별로 기록합니다.
    ''' </summary>
    ''' <param name="targetTextBox">로그를 표시할 TextBox 컨트롤입니다.</param>
    ''' <param name="message">기록할 로그 메시지입니다.</param>
    ''' <param name="writeToFile">로그를 파일에 기록할지 여부 (True/False)입니다.</param>
    ''' <param name="baseFileName">로그 파일의 기본 이름입니다. (예: "FingerAuth.log")</param>
    Private Sub WriteLogDisp(targetTextBox As TextBox, message As String, Optional writeToFile As Boolean = False, Optional baseFileName As String = "AppLog.log")
        ' 1. 타임스탬프가 포함된 전체 로그 메시지 생성
        Dim logEntry As String = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}"

        ' 2. 화면의 텍스트 박스에 로그 추가 (UI 스레드 접근 처리 포함)
        If targetTextBox.InvokeRequired Then
            targetTextBox.Invoke(New Action(Sub()
                                                targetTextBox.AppendText(logEntry & Environment.NewLine)
                                            End Sub))
        Else
            targetTextBox.AppendText(logEntry & Environment.NewLine)
        End If

        ' 3. 파일에 로그 기록 (writeToFile이 True일 경우)
        If writeToFile Then
            Try
                ' --- 파일명에 날짜를 추가하는 로직 ---
                Dim fileNameWithoutExt As String = IO.Path.GetFileNameWithoutExtension(baseFileName)
                Dim fileExtension As String = IO.Path.GetExtension(baseFileName)
                Dim currentDate As String = DateTime.Now.ToString("yyyy-MM-dd")
                Dim datedFileName As String = $"{fileNameWithoutExt}_{currentDate}{fileExtension}"

                Dim logDirectory As String = My.Application.Info.DirectoryPath
                Dim logFilePath As String = IO.Path.Combine(logDirectory, datedFileName)

                Using writer As New IO.StreamWriter(logFilePath, True)
                    writer.WriteLine(logEntry)
                End Using

            Catch ex As Exception
                ' 파일 쓰기 실패 시 화면에만 오류 로그를 남깁니다.
                Dim errorLog As String = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] FILE LOGGING ERROR: {ex.Message}"
                If targetTextBox.InvokeRequired Then
                    targetTextBox.Invoke(New Action(Sub()
                                                        targetTextBox.AppendText(errorLog & Environment.NewLine)
                                                    End Sub))
                Else
                    targetTextBox.AppendText(errorLog & Environment.NewLine)
                End If
            End Try
        End If
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        ' 이 코드는 사용자가 어떤 방식으로든 폼을 닫으려고 할 때 실행됩니다 (X 버튼 포함).
        ' 비밀번호 인증 함수를 호출해서 인증에 실패했다면(False),
        If AuthenticateWithPassword() = False Then
            ' 폼이 닫히는 이벤트를 취소합니다.
            e.Cancel = True
            Return
        End If
    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtGolfDemonDisp.Clear()
    End Sub
    Private Sub refreshTimer_Tick(sender As Object, e As EventArgs) Handles refreshTimer.Tick
        Try
            ' WebView2 컨트롤이 존재하고 CoreWebView2 개체가 초기화되었는지 확인
            If WebView21 IsNot Nothing AndAlso WebView21.CoreWebView2 IsNot Nothing Then
                WebView21.Reload()
                WriteLog("Golf Server Reload", LOG_TO_FILE, LOG_FILE_NAME)
            End If
        Catch ex As Exception
            WriteLog($"Golf Server Reload 중 오류 발생: {ex.Message}", LOG_TO_FILE, LOG_FILE_NAME)
        End Try

    End Sub
End Class
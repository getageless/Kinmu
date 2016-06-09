Imports System
Imports System.Threading



Module Module1


    'クラス名 or キャプションを与えてウィンドウのハンドルを取得
    Public Declare Function FindWindowEx Lib "user32.dll" Alias "FindWindowExA" (ByVal hwndParent As Integer, ByVal hwndChildAfter As Integer, ByVal lpszClass As String, ByVal lpszWindow As String) As Integer
    'ウィンドウキャプションを取得
    Public Declare Function GetWindowText Lib "user32.dll" Alias "GetWindowTextA" (ByVal hWnd As Integer, ByVal lpString As String, ByVal nMaxCount As Integer) As Integer
    'クラス名取得
    Public Declare Function GetClassName Lib "user32.dll" Alias "GetClassNameA" (ByVal hWnd As Integer, ByVal lpClass As String, ByVal nMaxCount As Integer) As Integer
    'ハンドルを与えてウィンドウをアクティブにする
    Declare Function SetActiveWindow Lib "user32.dll" (ByVal hWnd As Integer) As Integer
    '指定のウィンドウをZウィンドウのトップ位置に移動しアクティブにする
    Declare Function SetForegroundWindow Lib "user32.dll" (ByVal hWnd As Integer) As Integer
    'Zオーダーのトップ位置のウィンドウのハンドルを取得
    Declare Function GetTopWindow Lib "user32.dll" (ByVal hWnd As Integer) As Integer
    'ユーザーが操作中のウィンドウのハンドルを取得
    Declare Function GetForegroundWindow Lib "user32.dll" () As Long
    Declare Function GetWindowTextLength Lib "user32.dll" (ByVal hwnd As Integer) As Integer

    'マウスを操作するAPI
    Declare Sub mouse_event Lib "user32" Alias "mouse_event" (ByVal dwFlags As Integer, ByVal dx As Integer, ByVal dy As Integer, ByVal cButtons As Integer, ByVal dwExtraInfo As Integer)
    'マウス操作のための定数
    Public Const MOUSEEVENTF_ABSOLUTE = &H8000 '絶対座標
    Public Const MOUSEEVENTF_LEFTDOWN = &H2 '左押
    Public Const MOUSEEVENTF_LEFTUP = &H4 '左離
    'マウスのカーソル位置を設定する関数
    Public Declare Function SetCursorPos Lib "USER32" (ByVal x As Long, ByVal y As Long) As Long
    Public KinmuX As Integer
    Public KinmuY As Integer
    Public KyukaX As Integer
    Public KyukaY As Integer
    Public KanseiKinmuX As Integer
    Public KanseiKinmuY As Integer
    Public KanseiKyukaX As Integer
    Public KanseiKyukaY As Integer
    Public KanseiSigyouX As Integer
    Public KanseiSigyouY As Integer
    Public KanseiSyugyouX As Integer
    Public KanseiSyugyouY As Integer
    Public KanseiJoubanX As Integer
    Public KanseiJoubanY As Integer
    Public KanseiKabanX As Integer
    Public KanseiKabanY As Integer
    'sendkey間のストップするタイム
    Public Stoptime As Integer = 100

    Public KinmuHwnd As Integer

    Public Tai As Integer = 0
    Public hWnd As Integer

    Public ClassName As String = "ThunderRT6FormDC" '勤務管理システムのクラス
    Public WindowNameKanseiNyuryoku As String = "管制日報入力"
    Public WindowNameMeisaiTouroku As String = "勤務日程明細登録"
    Public WindowNameMeisai As String = "勤務日程明細"
    Public WindowNameJisseki As String = "勤務日程入力＜実績＞"
    Public WindowNameChosei As String = "勤務日程入力＜調整＞"
    Public WindowNameYotei As String = "勤務日程入力＜予定＞"
    Public WindowNameHaichisyusei As String = "配置修正"
    Public WindowNameHaichikijunsyusei As String = "配置基準修正"
    Public aeForm As System.Windows.Automation.AutomationElement
    Public aeControl As System.Windows.Automation.AutomationElement
    Public aeListBox As System.Windows.Automation.AutomationElement
    Public aeListItem As System.Windows.Automation.AutomationElement
    Public aecListItem As System.Windows.Automation.AutomationElementCollection
    Public ptnMVP As System.Windows.Automation.BasePattern
    Public ptnValue As System.Windows.Automation.ValuePattern
    Public ptnListItem As System.Windows.Automation.SelectionItemPattern
    Public ptnInvoke As System.Windows.Automation.InvokePattern
    Public pcFirst As Windows.Automation.PropertyCondition
    Public pcSecond As Windows.Automation.PropertyCondition
    Public pcThird As Windows.Automation.PropertyCondition
    Public txtTime As String
    Public hWndParent As Integer
    Public hWndChildAfter As Integer
    Public 法定休出 As Boolean = False
    Public 休出 As Boolean = False
    Public 翌日法定休 As Boolean = False
    Public 翌日休 As Boolean = False
    Public 昼夜勤判定 As Boolean = False
    Public 既に休出処理 As Boolean = False
    Public 既に法定休出処理 As Boolean = False
    Public 夜勤判定 As Boolean = False
    Public WindowKinmuNitteiNyuryoku As String
End Module

Delegate Function Bottun_Delegate()

Public Class Bottun_Invoke


    Public Function 管制登録ボタン押下()
        '全体の登録ボタンを押す処理　ここから

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "70")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのInvokePatternを取得する。
        ptnInvoke = aeControl.GetCurrentPattern(Windows.Automation.InvokePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        ptnInvoke.Invoke()

        '勤務明細ボタンを押す処理　ここまで
        ptnInvoke = Nothing
        管制登録ボタン押下 = True
    End Function
    Public Function 管制追加ボタン押下()
        '全体の登録ボタンを押す処理　ここから

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "5")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのInvokePatternを取得する。
        ptnInvoke = aeControl.GetCurrentPattern(Windows.Automation.InvokePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        ptnInvoke.Invoke()

        '勤務明細ボタンを押す処理　ここまで
        ptnInvoke = Nothing
        管制追加ボタン押下 = True
    End Function
    Public Function 勤務明細ボタン押下()
        '勤務明細ボタンを押す処理　ここから

        'プロパティコンディションを設定（NamePropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.NameProperty, "勤務明細(M)")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)


        'コントロールのInvokePatternを取得する。
        ptnInvoke = aeControl.GetCurrentPattern(Windows.Automation.InvokePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        ptnInvoke.Invoke()

        '勤務明細ボタンを押す処理　ここまで
        ptnInvoke = Nothing
        勤務明細ボタン押下 = True

    End Function
    Public Function 閉じるボタン押下()
        '勤務明細ボタンを押す処理　ここから

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "4")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのInvokePatternを取得する。
        ptnInvoke = aeControl.GetCurrentPattern(Windows.Automation.InvokePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        ptnInvoke.Invoke()

        '勤務明細ボタンを押す処理　ここまで
        ptnInvoke = Nothing
        閉じるボタン押下 = True

    End Function
    Public Function 追加ボタン押下()
        '勤務明細ボタンを押す処理　ここから

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "3")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのInvokePatternを取得する。
        ptnInvoke = aeControl.GetCurrentPattern(Windows.Automation.InvokePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        ptnInvoke.Invoke()

        '勤務明細ボタンを押す処理　ここまで
        ptnInvoke = Nothing
        追加ボタン押下 = True

    End Function
    Public Function 登録ボタン全体押下()
        '全体の登録ボタンを押す処理　ここから

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "2")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのInvokePatternを取得する。
        ptnInvoke = aeControl.GetCurrentPattern(Windows.Automation.InvokePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        ptnInvoke.Invoke()

        '勤務明細ボタンを押す処理　ここまで
        ptnInvoke = Nothing
        登録ボタン全体押下 = True

    End Function
    Public Function 更新ボタン押下()
        '更新ボタンを押す処理　ここから

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "2")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのInvokePatternを取得する。
        ptnInvoke = aeControl.GetCurrentPattern(Windows.Automation.InvokePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        ptnInvoke.Invoke()

        '更新ボタンを押す処理　ここまで
        ptnInvoke = Nothing
        更新ボタン押下 = True

    End Function
    Public Function 登録ボタン押下()
        '登録ボタンを押す処理　ここから

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "67")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのInvokePatternを取得する。
        ptnInvoke = aeControl.GetCurrentPattern(Windows.Automation.InvokePattern.Pattern)

        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        ptnInvoke.Invoke()

        '登録ボタンを押す処理　ここまで
        ptnInvoke = Nothing

        登録ボタン押下 = True

    End Function
End Class

Module Module2
    Public Sub 日入力(ByVal Bangou As String)
        '1日分の勤務日程を入力する
        Dim TopHwnd As Long
        Dim i As Integer

        Dim blKinmu As Boolean
        Dim intBangou As Integer


        blKinmu = True

        '勤務日程明細登録画面を出す
        If IsNumeric(Bangou) Then
        Else
            Bangou = Replace(Bangou, "k", "")
            blKinmu = False
        End If

        If IsNumeric(Bangou) Then
            TopHwnd = GetForegroundWindow
            SendKeys.SendWait("%M")

            'エラーでストップするためのi
            i = 0

            Do
                If GetForegroundWindow = TopHwnd Then
                    System.Threading.Thread.Sleep(Stoptime)
                Else
                    TopHwnd = GetForegroundWindow
                    Exit Do
                End If
                i = i + 1
                '1000の時に、もう一回Mを押してみる
                If i = 1000 Then
                    SendKeys.SendWait("%M")
                End If
                If i = 2000 Then
                    MessageBox.Show("error")
                    Exit Sub
                End If
            Loop

            SendKeys.SendWait("%A")
            System.Threading.Thread.Sleep(Stoptime)
            i = 0
            Do
                If GetForegroundWindow = TopHwnd Then
                    System.Threading.Thread.Sleep(Stoptime)
                Else
                    TopHwnd = GetForegroundWindow
                    Exit Do
                End If
                i = i + 1

                '1000の時に、もう一回Aを押してみる
                If i = 1000 Then
                    SendKeys.SendWait("%A")
                    System.Threading.Thread.Sleep(Stoptime)
                End If
                If i = 2000 Then
                    MessageBox.Show("error")
                    Exit Sub
                End If
            Loop
            '勤務選択　ここから

            '隊を選択
            For i = 0 To Tai
                SendKeys.SendWait("{DOWN}")
                System.Threading.Thread.Sleep(Stoptime)
            Next i

            '勤務か教育等のクリック処理とbangouの変換
            If blKinmu Then
                Cursor.Position = New Point(KinmuX, KinmuY)
                'マウスの左ボタンを押す
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
                'マウスの左ボタンを離す
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)
                System.Threading.Thread.Sleep(Stoptime)
                SendKeys.SendWait("{TAB}")
                System.Threading.Thread.Sleep(Stoptime)
            Else
                Cursor.Position = New Point(KyukaX, KyukaY)
                'マウスの左ボタンを押す
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
                'マウスの左ボタンを離す
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)
            End If

            System.Threading.Thread.Sleep(Stoptime)
            SendKeys.SendWait("{TAB}")
            System.Threading.Thread.Sleep(Stoptime)

            intBangou = CInt(Bangou) - 1

            '勤務番号の選択処理
            For i = 0 To intBangou
                SendKeys.SendWait("{DOWN}")
                System.Threading.Thread.Sleep(Stoptime)

            Next i

            'SendKeys.SendWait("{TAB}")
            'System.Threading.Thread.Sleep(Stoptime)

            '休日の選択処理

            'SendKeys.SendWait("{TAB}")
            'System.Threading.Thread.Sleep(Stoptime)

            '始業時刻入力

            'SendKeys.SendWait("{TAB}")
            'System.Threading.Thread.Sleep(Stoptime)

            '終業時刻入力

            'SendKeys.SendWait("{TAB}")
            'System.Threading.Thread.Sleep(Stoptime)

            '就業時間（時）入力

            'SendKeys.SendWait("{TAB}")
            'System.Threading.Thread.Sleep(Stoptime)

            '就業時間（分）入力

            '備考まで移動
            'For i = 0 To 9
            'SendKeys.SendWait("{TAB}")
            'System.Threading.Thread.Sleep(Stoptime)

            'Next i


            '勤務選択　ここまで

            '勤務日程明細登録画面を閉じる
            SendKeys.SendWait("%R")
            System.Threading.Thread.Sleep(Stoptime)

            i = 0
            Do
                If GetForegroundWindow = TopHwnd Then
                    System.Threading.Thread.Sleep(Stoptime)
                Else
                    TopHwnd = GetForegroundWindow
                    Exit Do
                End If
                i = i + 1

                '1000の時に、もう一回Rを押してみる
                If i = 1000 Then
                    SendKeys.SendWait("%R")
                    System.Threading.Thread.Sleep(Stoptime)
                End If
                If i = 2000 Then
                    MessageBox.Show("error")
                    Exit Sub
                End If
            Loop


            SendKeys.SendWait("%C")
            System.Threading.Thread.Sleep(Stoptime + Stoptime * 1.5)

            i = 0
            Do
                If GetForegroundWindow = TopHwnd Then
                    System.Threading.Thread.Sleep(Stoptime)
                Else
                    TopHwnd = GetForegroundWindow
                    Exit Do
                End If
                i = i + 1

                '1000の時に、もう一回Cを押してみる
                If i = 1000 Then
                    System.Threading.Thread.Sleep(Stoptime)
                    SendKeys.SendWait("%C")
                    System.Threading.Thread.Sleep(Stoptime + Stoptime * 1.5)
                End If

                If i = 2000 Then
                    MessageBox.Show("error")
                    Exit Sub
                End If


            Loop
        End If
    End Sub
    Public Sub 入力(ByVal DefaultStoptime As Integer)
        'CSV形式ファイルパスを設定してください。
        Dim csvfilepath As String
        'csvfilepath = GetAppPath()
        csvfilepath = "c:\kinmu.csv"
        Dim objFile As New System.IO.StreamReader(csvfilepath _
        , System.Text.Encoding.GetEncoding(932))
        Dim strLine As String       '１行の配列を格納する変数
        Dim Kinmulist As String()
        Dim kinmu As String()
        Dim taibangou As String()
        Dim i As Long
        Dim ii As Long
        Dim iii As Long

        'フォームの画面から、スリープする時間を持ってくる。
        Stoptime = DefaultStoptime

        Do
            '次の行へ
            strLine = objFile.ReadLine()

            If strLine = "" Then
                Exit Do
            End If
            Kinmulist = Split(strLine, ",")

            For i = LBound(Kinmulist) To UBound(Kinmulist)

                '"#"で記述されている隊の番号を取り出す
                If InStr(Kinmulist(i), "#") Then
                    taibangou = Split(Kinmulist(i), "#")
                    Tai = CInt(taibangou(0)) - 1

                    'taibangou(1)を&で分けて、中抜け勤務に対応する
                    kinmu = Split(taibangou(1), "&")

                    'kinmuを引数にして、日毎の入力を行う
                    For iii = LBound(kinmu) To UBound(kinmu)

                        日入力(kinmu(iii))

                    Next iii

                End If

                '一日分の入力が終わったら、ひとつ右に移動する
                SendKeys.SendWait("{RIGHT}")
                System.Threading.Thread.Sleep(Stoptime)



                '強制終了の処理
                If Form1.canceled = True Then Exit Sub

            Next i

            SetActiveWindow(KinmuHwnd)
            SetForegroundWindow(KinmuHwnd)


            '進んだ分だけ左に戻す
            ii = i - 2
            For i = 0 To ii
                SendKeys.SendWait("{LEFT}")
                System.Threading.Thread.Sleep(Stoptime)
            Next i

            '下の行に移動
            For i = 0 To 2
                SendKeys.SendWait("{DOWN}")
                System.Threading.Thread.Sleep(Stoptime)
            Next i
        Loop

        'ファイルのクローズ
        objFile.Close()

    End Sub
    Public Function GetAppPath() As String
        '実行ファイルのあるパスを返す
        Return System.IO.Path.GetDirectoryName( _
            System.Reflection.Assembly.GetExecutingAssembly().Location)
    End Function
    Public Function 勤務日程入力画面開け閉め()


        Do
            System.Threading.Thread.Sleep(Stoptime)

            'ウィンドウが勤務日程入力なら終了する
            Try
                AppActivate(aeForm.Current.Name)
                Exit Do
            Catch ex As Exception

            End Try
        Loop

    End Function
    Public Function 勤務日程入力画面取得()
        '勤務日程明細画面を開く

        'トップレベルウィンドウから検索する
        hWnd = FindWindowEx(0, 0, ClassName, WindowNameYotei)
        KinmuHwnd = hWnd

        WindowKinmuNitteiNyuryoku = WindowNameYotei
        WindowKinmuNitteiNyuryoku = "勤務日程入力＜予定＞"
        '見つからなかった場合、調整画面を探す
        If hWnd = 0 Then
            hWnd = FindWindowEx(0, 0, ClassName, WindowNameChosei)
            KinmuHwnd = hWnd
            WindowKinmuNitteiNyuryoku = "勤務日程入力＜調整＞"
            '見つからなかった場合、終了
            If hWnd = 0 Then
                hWnd = FindWindowEx(0, 0, ClassName, WindowNameJisseki)
                KinmuHwnd = hWnd
                WindowKinmuNitteiNyuryoku = "勤務日程入力＜実績＞"
                '見つからなかった場合、終了
                If hWnd = 0 Then

                    MessageBox.Show("勤務日程入力画面のウィンドウが見つかりません")
                    勤務日程入力画面取得 = False
                    Exit Function
                End If
            End If
        End If

        'ハンドルから勤務管理システムのフォームを取得
        aeForm = System.Windows.Automation.AutomationElement.FromHandle(hWnd)

        勤務日程入力画面取得 = True

    End Function
    Public Function 勤務日程明細画面取得()
        '勤務日程明細画面を開く

        'トップレベルウィンドウから検索する
        hWnd = FindWindowEx(0, 0, ClassName, WindowNameMeisai)
        KinmuHwnd = hWnd



        '見つからなかった場合、終了する
        If hWnd = 0 Then
            MessageBox.Show("勤務日程明細画面のウィンドウが見つかりません")
            勤務日程明細画面取得 = False
            Exit Function
        End If

        'ハンドルから勤務管理システムのフォームを取得
        aeForm = System.Windows.Automation.AutomationElement.FromHandle(hWnd)

        勤務日程明細画面取得 = True

    End Function
    Public Function 管制日報入力画面取得()
        '勤務日程明細画面を開く

        'トップレベルウィンドウから検索する
        hWnd = FindWindowEx(0, 0, ClassName, WindowNameKanseiNyuryoku)

        KinmuHwnd = hWnd

        '見つからなかった場合、終了する
        If hWnd = 0 Then
            'MessageBox.Show("管制日報入力画面のウィンドウが見つかりません")
            管制日報入力画面取得 = False

            Exit Function
        End If

        'ハンドルから勤務管理システムのフォームを取得
        aeForm = System.Windows.Automation.AutomationElement.FromHandle(hWnd)

        管制日報入力画面取得 = True

    End Function

    Public Function 勤務日程明細登録画面取得()
        '勤務日程明細画面を開く

        'トップレベルウィンドウから検索する
        hWnd = FindWindowEx(0, 0, ClassName, WindowNameMeisaiTouroku)




        '見つからなかった場合、終了する
        If hWnd = 0 Then
            MessageBox.Show("勤務日程明細登録画面のウィンドウが見つかりません")
            勤務日程明細登録画面取得 = False
            Exit Function
        End If

        'ハンドルから勤務管理システムのフォームを取得
        aeForm = System.Windows.Automation.AutomationElement.FromHandle(hWnd)

        勤務日程明細登録画面取得 = True

    End Function
    Public Function 勤務タブ勤務選択(ByVal リストインデックス As Integer)

        '勤務タブの選択　ここから

        '勤務選択コンボボックスのIDは20
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "20", Windows.Automation.PropertyConditionFlags.IgnoreCase)

        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)

        'aeControl.SetFocus()



        'うち、リストボックスを取得
        pcSecond = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "ListBox", Windows.Automation.PropertyConditionFlags.IgnoreCase)

        aeListBox = aeControl.FindFirst(Windows.Automation.TreeScope.Subtree, pcSecond)
        Try

            'リストボックスのItemを全て取得
            aecListItem = aeListBox.FindAll(Windows.Automation.TreeScope.Children, Windows.Automation.Condition.TrueCondition)


            For Each LItem In aecListItem
                If CInt(Trim(Mid(LItem.Current.Name, 2, 2))) = リストインデックス Then
                    'Itemのインデックスで勤務番号を選ぶ
                    ptnListItem = LItem.GetCurrentPattern(Windows.Automation.SelectionItemPattern.Pattern)
                    ptnListItem.Select()
                    Exit For
                End If

            Next LItem
        Catch ex As Exception
        End Try


        '昼夜勤判定
        If Left(aeControl.Current.Name, 1) = "○" Then
            昼夜勤判定 = True
        End If

        If Left(aeControl.Current.Name, 1) = "▽" Then
            夜勤判定 = True
        End If


        勤務タブ勤務選択 = True

    End Function
    Public Function 勤務タブ休み選択(ByVal リストインデックス As Integer)

        '勤務タブの選択　ここから

        '休み選択コンボボックスのIDは23
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "23", Windows.Automation.PropertyConditionFlags.IgnoreCase)

        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)

        'aeControl.SetFocus()



        'うち、リストボックスを取得
        pcSecond = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "ListBox", Windows.Automation.PropertyConditionFlags.IgnoreCase)

        aeListBox = aeControl.FindFirst(Windows.Automation.TreeScope.Subtree, pcSecond)

        Try
            'リストボックスのItemを全て取得
            aecListItem = aeListBox.FindAll(Windows.Automation.TreeScope.Children, Windows.Automation.Condition.TrueCondition)

            'Itemのインデックスで勤務番号を選ぶ
            ptnListItem = aecListItem.Item(リストインデックス).GetCurrentPattern(Windows.Automation.SelectionItemPattern.Pattern)

            ptnListItem.Select()
            '勤務タブの選択　ここまで
        Catch ex As Exception
        End Try

        勤務タブ休み選択 = True

    End Function
    Public Function 勤務所定時間(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "81")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで



        勤務所定時間 = True

    End Function
    Public Function 勤務所定分(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "82")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで

        勤務所定分 = True

    End Function
    Public Function 勤務残業時間(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "83")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで

        勤務残業時間 = True

    End Function
    Public Function 勤務残業分(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "84")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで

        勤務残業分 = True

    End Function
    Public Function 勤務休出時間(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "87")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで

        勤務休出時間 = True

    End Function
    Public Function 勤務休出分(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "88")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで

        勤務休出分 = True

    End Function
    Public Function 勤務深夜時間(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "89")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで

        勤務深夜時間 = True

    End Function
    Public Function 勤務深夜分(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "90")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで

        勤務深夜分 = True

    End Function
    Public Function 備考(ByVal 備考文字列 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 備考文字列

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "66")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する

        If 既に休出処理 Or 既に法定休出処理 Then
            txtTime = txtTime & " " & ptnValue.Current.Value
        End If

        Try
            If ptnValue.Current.Value <> txtTime Then

                ptnValue.SetValue(txtTime)

            End If
        Catch ex As Exception
        End Try
        '勤務時間のテキストボックス処理　ここまで

        備考 = True

    End Function
    Public Function 警備物件選択(ByVal リストインデックス As Integer)

        '勤務タブの選択　ここから

        '勤務選択コンボボックスのIDは20
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "6", Windows.Automation.PropertyConditionFlags.IgnoreCase)

        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)

        'aeControl.SetFocus()



        'うち、リストボックスを取得
        pcSecond = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "ListBox", Windows.Automation.PropertyConditionFlags.IgnoreCase)

        aeListBox = aeControl.FindFirst(Windows.Automation.TreeScope.Subtree, pcSecond)

        Try
            'リストボックスのItemを全て取得
            aecListItem = aeListBox.FindAll(Windows.Automation.TreeScope.Children, Windows.Automation.Condition.TrueCondition)

            'Itemのインデックスで勤務番号を選ぶ
            ptnListItem = aecListItem.Item(リストインデックス).GetCurrentPattern(Windows.Automation.SelectionItemPattern.Pattern)

            ptnListItem.Select()
        Catch ex As Exception
        End Try

        '勤務タブの選択　ここまで
        警備物件選択 = True

    End Function
    Public Function 教育等タブ勤務選択(ByVal リストインデックス As Integer)

        '教育等タブの選択　ここから
        Dim LItem As Windows.Automation.AutomationElement

        '教育等選択コンボボックスのIDは20
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "60", Windows.Automation.PropertyConditionFlags.IgnoreCase)

        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)

        'aeControl.SetFocus()



        'うち、リストボックスを取得
        pcSecond = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "ListBox", Windows.Automation.PropertyConditionFlags.IgnoreCase)

        aeListBox = aeControl.FindFirst(Windows.Automation.TreeScope.Subtree, pcSecond)


        Try

            'リストボックスのItemを全て取得
            aecListItem = aeListBox.FindAll(Windows.Automation.TreeScope.Children, Windows.Automation.Condition.TrueCondition)

            For Each LItem In aecListItem
                If CInt(Trim(Mid(LItem.Current.Name, 2, 2))) = リストインデックス Then
                    'Itemのインデックスで勤務番号を選ぶ
                    ptnListItem = LItem.GetCurrentPattern(Windows.Automation.SelectionItemPattern.Pattern)
                    ptnListItem.Select()
                    Exit For
                End If

            Next LItem

        Catch ex As Exception
        End Try
        '教育等タブの選択　ここまで
        教育等タブ勤務選択 = True

    End Function
    Public Function 教育等タブ休み選択(ByVal リストインデックス As Integer)

        '勤務タブの選択　ここから

        '休み選択コンボボックスのIDは23
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "62", Windows.Automation.PropertyConditionFlags.IgnoreCase)

        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)

        'aeControl.SetFocus()



        'うち、リストボックスを取得
        pcSecond = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "ListBox", Windows.Automation.PropertyConditionFlags.IgnoreCase)

        aeListBox = aeControl.FindFirst(Windows.Automation.TreeScope.Subtree, pcSecond)
        Try

            'リストボックスのItemを全て取得
            aecListItem = aeListBox.FindAll(Windows.Automation.TreeScope.Children, Windows.Automation.Condition.TrueCondition)

            'Itemのインデックスで勤務番号を選ぶ
            ptnListItem = aecListItem.Item(リストインデックス).GetCurrentPattern(Windows.Automation.SelectionItemPattern.Pattern)

            ptnListItem.Select()
        Catch ex As Exception
        End Try
        '勤務タブの選択　ここまで
        教育等タブ休み選択 = True

    End Function

    Public Function 教育等所定時間(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "103")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで

        教育等所定時間 = True

    End Function
    Public Function 教育等所定分(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "104")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで

        教育等所定分 = True

    End Function
    Public Function 教育等残業時間(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "105")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで

        教育等残業時間 = True

    End Function
    Public Function 教育等残業分(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "106")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで

        教育等残業分 = True

    End Function
    Public Function 教育等休出時間(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "109")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで

        教育等休出時間 = True

    End Function
    Public Function 教育等休出分(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "110")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで

        教育等休出分 = True

    End Function
    Public Function 教育等深夜時間(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "111")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで

        教育等深夜時間 = True

    End Function
    Public Function 教育等深夜分(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "112")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで

        教育等深夜分 = True

    End Function
    Public Function 教育等法定休出処理()
        Dim 休出に持ってく時間 As Integer
        Dim 休出に持ってく分 As Integer
        Dim 残す時間 As Integer

        If Not 既に法定休出処理 Then
            '注意！！2011年3月現在、休日タブでエラー発生中のため、タブ選択しない！！
            教育等タブ休み選択(1)
        End If

        If Not 既に法定休出処理 Then
            '備考の入力
            備考("法定休出")
        End If

        休出に持ってく時間 = 0
        休出に持ってく分 = 0
        残す時間 = 0
        教育等法定休出処理 = True

    End Function
    Public Function 教育等翌日法定休処理()
        Dim 休出に持ってく時間 As Integer
        Dim 休出に持ってく分 As Integer
        Dim 残す時間 As Integer
        If 夜勤判定 = False And 昼夜勤判定 = False Then
            教育等翌日法定休処理 = True
            Exit Function
        End If


        '備考の入力
        備考("翌日法定休")

        休出に持ってく時間 = 0
        休出に持ってく分 = 0
        残す時間 = 0
        教育等翌日法定休処理 = True

    End Function
    Public Function 教育等休出処理()
        Dim 休出に持ってく時間 As Integer
        Dim 休出に持ってく分 As Integer
        Dim 残す時間 As Integer

        If Not 既に休出処理 Then
            '注意！！2011年3月現在、休日タブでエラー発生中のため、タブ選択しない！！
            教育等タブ休み選択(2)
        End If

        If Not 既に休出処理 Then
            '備考の入力
            備考("休出")
        End If

        休出に持ってく時間 = 0
        休出に持ってく分 = 0
        残す時間 = 0
        教育等休出処理 = True

    End Function
    Public Function 教育等翌日休処理()
        Dim 休出に持ってく時間 As Integer
        Dim 休出に持ってく分 As Integer
        Dim 残す時間 As Integer
        If 夜勤判定 = False And 昼夜勤判定 = False Then
            教育等翌日休処理 = True
            Exit Function
        End If

        '備考の入力
        備考("翌日休")

        休出に持ってく時間 = 0
        休出に持ってく分 = 0
        残す時間 = 0
        教育等翌日休処理 = True

    End Function

    Public Function 勤務法定休出処理()
        Dim 休出に持ってく時間 As Integer
        Dim 休出に持ってく分 As Integer
        Dim 残す時間 As Integer

        If Not 既に法定休出処理 Then
            '注意！！2011年3月現在、休日タブでエラー発生中のため、タブ選択しない！！
            勤務タブ休み選択(1)
        End If
        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "81")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する

        If 昼夜勤判定 Then
            Try
                休出に持ってく時間 = 8
                残す時間 = CInt(ptnValue.Current.Value) - 8
                ptnValue.SetValue(CStr(残す時間))
            Catch ex As Exception
                休出に持ってく時間 = 0
            End Try
        Else
            Try
                休出に持ってく時間 = CInt(ptnValue.Current.Value)
                ptnValue.SetValue("")
            Catch ex As Exception
                休出に持ってく時間 = 0
            End Try
        End If


        '勤務時間のテキストボックス処理　ここまで
        '勤務分のテキストボックス処理　ここから



        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "82")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        Try
            休出に持ってく分 = CInt(ptnValue.Current.Value)
            ptnValue.SetValue("")
        Catch ex As Exception
            休出に持ってく分 = 0

        End Try

        '勤務分のテキストボックス処理　ここまで

        '休出時間の入力
        勤務休出時間(CStr(休出に持ってく時間))
        勤務休出分(CStr(休出に持ってく分))

        If Not 既に法定休出処理 Then
            '備考の入力
            備考("法定休出")
        End If

        休出に持ってく時間 = 0
        休出に持ってく分 = 0
        残す時間 = 0
        既に法定休出処理 = True
        勤務法定休出処理 = True

    End Function
    Public Function 勤務翌日法定休処理()
        Dim 休出に持ってく時間 As Integer
        Dim 休出に持ってく分 As Integer
        Dim 残す時間 As Integer

        If 夜勤判定 = False And 昼夜勤判定 = False Then
            勤務翌日法定休処理 = True
            Exit Function
        End If


        '勤務時間のテキストボックス処理　ここから
        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "81")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する

        If 昼夜勤判定 And Not 既に休出処理 And Not 既に法定休出処理 Then
            Try
                休出に持ってく時間 = 8
                残す時間 = CInt(ptnValue.Current.Value) - 8
                ptnValue.SetValue(CStr(残す時間))
            Catch ex As Exception
                休出に持ってく時間 = 0
            End Try
        Else
            Try
                休出に持ってく時間 = CInt(ptnValue.Current.Value)
                ptnValue.SetValue("")
            Catch ex As Exception
                休出に持ってく時間 = 0
            End Try
        End If


        '勤務時間のテキストボックス処理　ここまで
        '勤務分のテキストボックス処理　ここから



        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "82")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する


        Try
            休出に持ってく分 = CInt(ptnValue.Current.Value)
            ptnValue.SetValue("")
        Catch ex As Exception
            休出に持ってく分 = 0

        End Try

        If 既に法定休出処理 Then
            休出に持ってく時間 = 休出に持ってく時間 + 8
        End If


        '勤務分のテキストボックス処理　ここまで

        If 既に法定休出処理 Or 既に休出処理 Then
            If Not 昼夜勤判定 Then
                '備考の入力
                備考("翌日法定休")

                休出に持ってく時間 = 0
                休出に持ってく分 = 0
                残す時間 = 0
                勤務翌日法定休処理 = True
                Exit Function
            End If
        End If
        '休出時間の入力
        勤務休出時間(CStr(休出に持ってく時間))
        勤務休出分(CStr(休出に持ってく分))

        '備考の入力
        備考("翌日法定休")

        休出に持ってく時間 = 0
        休出に持ってく分 = 0
        残す時間 = 0
        勤務翌日法定休処理 = True

    End Function
    Public Function 勤務休出処理()
        Dim 休出に持ってく時間 As Integer
        Dim 休出に持ってく分 As Integer
        Dim 残す時間 As Integer

        '勤務時間のテキストボックス処理　ここから
        If Not 既に休出処理 Then
            '注意！！2011年3月現在、休日タブでエラー発生中のため、タブ選択しない！！
            勤務タブ休み選択(2)
        End If
        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "81")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する

        If 昼夜勤判定 And Not 既に休出処理 Then
            Try
                休出に持ってく時間 = 8
                残す時間 = CInt(ptnValue.Current.Value) - 8
                ptnValue.SetValue(CStr(残す時間))
            Catch ex As Exception
                休出に持ってく時間 = 0
            End Try
        Else
            Try
                休出に持ってく時間 = CInt(ptnValue.Current.Value)
                ptnValue.SetValue("")
            Catch ex As Exception
                休出に持ってく時間 = 0
            End Try
        End If


        '勤務時間のテキストボックス処理　ここまで
        '勤務分のテキストボックス処理　ここから



        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "82")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        Try
            休出に持ってく分 = CInt(ptnValue.Current.Value)
            ptnValue.SetValue("")
        Catch ex As Exception
            休出に持ってく分 = 0

        End Try

        '勤務分のテキストボックス処理　ここまで

        '休出時間の入力
        勤務残業時間(CStr(休出に持ってく時間))
        勤務残業分(CStr(休出に持ってく分))

        If Not 既に休出処理 Then
            '備考の入力
            備考("休出")
        End If

        休出に持ってく時間 = 0
        休出に持ってく分 = 0
        残す時間 = 0

        既に休出処理 = True
        勤務休出処理 = True

    End Function
    Public Function 勤務翌日休処理()
        Dim 休出に持ってく時間 As Integer
        Dim 休出に持ってく分 As Integer
        Dim 残す時間 As Integer

        If 夜勤判定 = False And 昼夜勤判定 = False Then
            勤務翌日休処理 = True
            Exit Function
        End If


        '勤務時間のテキストボックス処理　ここから
        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "81")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する

        If 昼夜勤判定 And Not 既に休出処理 And Not 既に法定休出処理 Then
            Try
                休出に持ってく時間 = 8
                残す時間 = CInt(ptnValue.Current.Value) - 8
                ptnValue.SetValue(CStr(残す時間))
            Catch ex As Exception
                休出に持ってく時間 = 0
            End Try
        Else
            Try
                休出に持ってく時間 = CInt(ptnValue.Current.Value)
                ptnValue.SetValue("")
            Catch ex As Exception
                休出に持ってく時間 = 0
            End Try
        End If


        '勤務時間のテキストボックス処理　ここまで
        '勤務分のテキストボックス処理　ここから



        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "82")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        Try
            休出に持ってく分 = CInt(ptnValue.Current.Value)
            ptnValue.SetValue("")
        Catch ex As Exception
            休出に持ってく分 = 0

        End Try

        If 既に休出処理 Then
            休出に持ってく時間 = 休出に持ってく時間 + 8
        End If
        '勤務分のテキストボックス処理　ここまで

        If 既に法定休出処理 Or 既に休出処理 Then
            If Not 昼夜勤判定 Then
                '備考の入力
                備考("翌日休")

                休出に持ってく時間 = 0
                休出に持ってく分 = 0
                残す時間 = 0
                勤務翌日休処理 = True
                Exit Function
            End If
        End If

        '休出時間の入力
        勤務残業時間(CStr(休出に持ってく時間))
        勤務残業分(CStr(休出に持ってく分))

        '備考の入力
        備考("翌日休")

        休出に持ってく時間 = 0
        休出に持ってく分 = 0
        残す時間 = 0
        勤務翌日休処理 = True

    End Function

    Public Sub 日入力2(ByVal Bangou As String)
        '1日分の勤務日程を入力する
        Dim blKinmu As Boolean
        Dim intBangou As Integer
        Dim Bottun_Instance As New Bottun_Invoke
        Dim InvokeBottunMethod As Bottun_Delegate
        Dim hForegroundWnd As Long

        Dim length As Integer = 1000

        Dim buf As String = ""

        blKinmu = True

        buf = buf.PadRight(length, vbNullChar)


        '勤務日程明細登録画面を出す
        If IsNumeric(Bangou) Then
        Else
            Bangou = Replace(Bangou, "Z", "")
            blKinmu = False
        End If

        If IsNumeric(Bangou) Then
            System.Threading.Thread.Sleep(Stoptime)
            System.Threading.Thread.Sleep(Stoptime)



            InvokeBottunMethod = New Bottun_Delegate(AddressOf Bottun_Instance.勤務明細ボタン押下)
            InvokeBottunMethod.BeginInvoke(Nothing, Nothing)

            Do
                System.Threading.Thread.Sleep(Stoptime)

                'フォアグラウンドウィンドウの取得
                hForegroundWnd = GetForegroundWindow()


                'ウィンドウが勤務日程明細なら終了する
                Try
                    AppActivate(WindowNameMeisai)
                    Exit Do
                Catch ex As Exception

                End Try
            Loop

            InvokeBottunMethod = New Bottun_Delegate(AddressOf Bottun_Instance.追加ボタン押下)
            InvokeBottunMethod.BeginInvoke(Nothing, Nothing)



            Do
                System.Threading.Thread.Sleep(Stoptime)

                'ウィンドウが勤務日程明細登録なら終了する
                Try
                    AppActivate(WindowNameMeisaiTouroku)
                    Exit Do
                Catch ex As Exception

                End Try
            Loop

            '勤務選択　ここから

            '隊を選択
            警備物件選択(Tai)

            intBangou = CInt(Bangou)


            '勤務か教育等のクリック処理とbangouの変換
            If blKinmu Then
                SetForegroundWindow(KinmuHwnd)
                Cursor.Position = New Point(KinmuX, KinmuY)
                'マウスの左ボタンを押す

                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
                'マウスの左ボタンを離す

                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)
                System.Threading.Thread.Sleep(Stoptime)

                勤務タブ勤務選択(intBangou)


                If 法定休出 Then
                    勤務法定休出処理()
                ElseIf 休出 Then
                    勤務休出処理()
                End If

                If 翌日法定休 Then
                    勤務翌日法定休処理()
                ElseIf 翌日休 Then
                    勤務翌日休処理()
                End If


            Else
                SetForegroundWindow(KinmuHwnd)
                Cursor.Position = New Point(KyukaX, KyukaY)
                'マウスの左ボタンを押す

                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
                'マウスの左ボタンを離す

                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)
                System.Threading.Thread.Sleep(Stoptime)

                教育等タブ勤務選択(intBangou)

                If 法定休出 Then
                    教育等法定休出処理()
                ElseIf 休出 Then
                    教育等休出処理()
                End If

                If 翌日法定休 Then
                    教育等翌日法定休処理()
                ElseIf 翌日休 Then
                    教育等翌日休処理()
                End If



            End If


            '勤務選択　ここまで

            '勤務日程明細登録画面を閉じる
            InvokeBottunMethod = New Bottun_Delegate(AddressOf Bottun_Instance.登録ボタン押下)
            InvokeBottunMethod()
            System.Threading.Thread.Sleep(Stoptime)

            Do
                System.Threading.Thread.Sleep(Stoptime)

                'ウィンドウが勤務日程明細登録なら終了する
                Try
                    AppActivate(WindowNameMeisai)
                    Exit Do
                Catch ex As Exception

                End Try
            Loop

            InvokeBottunMethod = New Bottun_Delegate(AddressOf Bottun_Instance.閉じるボタン押下)
            InvokeBottunMethod()
            System.Threading.Thread.Sleep(Stoptime)

            Do
                System.Threading.Thread.Sleep(Stoptime)

                'ウィンドウが勤務日程入力なら終了する
                Try
                    AppActivate(WindowKinmuNitteiNyuryoku)
                    Exit Do
                Catch ex As Exception

                End Try
            Loop

            昼夜勤判定 = False
            夜勤判定 = False
        End If



    End Sub

    Public Sub 入力2(ByVal DefaultStoptime As Integer)
        'CSV形式ファイルパスを設定してください。
        Dim csvfilepath As String
        'csvfilepath = GetAppPath()
        csvfilepath = Form1.lstファイルリスト.Items(0)
        Dim objFile As New System.IO.StreamReader(csvfilepath _
        , System.Text.Encoding.GetEncoding(932))
        Dim strLine As String       '１行の配列を格納する変数
        Dim Kinmulist As String()
        Dim kinmu As String()
        Dim taibangou(2) As String
        Dim i As Long
        Dim ii As Long
        Dim iii As Long
        Dim Bottun_Instance As New Bottun_Invoke
        Dim InvokeBottunMethod As Bottun_Delegate




        'フォームの画面から、スリープする時間を持ってくる。
        Stoptime = DefaultStoptime
        勤務日程入力画面取得()
        SetActiveWindow(KinmuHwnd)
        SetForegroundWindow(KinmuHwnd)
        System.Threading.Thread.Sleep(Stoptime)
        System.Threading.Thread.Sleep(Stoptime)
        Do
            '次の行へ
            strLine = objFile.ReadLine()

            If strLine = "" Then
                Exit Do
            End If
            Kinmulist = Split(strLine, ",")

            For i = LBound(Kinmulist) To UBound(Kinmulist)


                '法定休出の調査
                If Right(Kinmulist(i), 1) = "H" Then
                    Kinmulist(i) = Replace(Kinmulist(i), "H", "")
                    法定休出 = True
                End If
                '休出の調査
                If Right(Kinmulist(i), 1) = "Q" Then
                    Kinmulist(i) = Replace(Kinmulist(i), "Q", "")
                    休出 = True
                End If
                If i < UBound(Kinmulist) Then
                    '翌日法定休の調査
                    If Right(Kinmulist(i + 1), 1) = "H" Then
                        翌日法定休 = True
                    End If
                    '翌日休の調査
                    If Right(Kinmulist(i + 1), 1) = "Q" Then
                        翌日休 = True
                    End If

                End If


                '"#"で記述されている隊の番号を取り出す
                'If InStr(Kinmulist(i), "#") Then

                'taibangou = Split(Kinmulist(i), "#")
                taibangou(1) = Kinmulist(i)
                'Tai = CInt(taibangou(0))
                Tai = 0
                'taibangou(1)を&で分けて、中抜け勤務に対応する
                kinmu = Split(taibangou(1), "+")

                'kinmuを引数にして、日毎の入力を行う
                For iii = LBound(kinmu) To UBound(kinmu)

                    日入力2(kinmu(iii))

                Next iii

                'End If
                '一日分の入力が終わったら、ひとつ右に移動する
                SetActiveWindow(KinmuHwnd)
                SetForegroundWindow(KinmuHwnd)
                System.Threading.Thread.Sleep(Stoptime)
                System.Threading.Thread.Sleep(Stoptime)
                SendKeys.SendWait("{RIGHT}")


                法定休出 = False
                休出 = False
                翌日休 = False
                翌日法定休 = False
                既に休出処理 = False
                既に法定休出処理 = False

            Next i

            SetActiveWindow(KinmuHwnd)
            SetForegroundWindow(KinmuHwnd)


            '進んだ分だけ左に戻す
            ii = i - 1
            For i = 0 To ii
                SendKeys.SendWait("{LEFT}")
                System.Threading.Thread.Sleep(Stoptime)
            Next i

            '下の行に移動
            For i = 0 To 2
                SendKeys.SendWait("{DOWN}")
                System.Threading.Thread.Sleep(Stoptime)
            Next i
        Loop
        Stoptime = DefaultStoptime


        InvokeBottunMethod = New Bottun_Delegate(AddressOf Bottun_Instance.登録ボタン全体押下)
        InvokeBottunMethod.BeginInvoke(Nothing, Nothing)


        'ファイルのクローズ
        objFile.Close()

    End Sub

    Public Sub 配置数入力(ByVal DefaultStoptime As Integer)
        Dim csvfilepath As String

        csvfilepath = Form1.lstファイルリスト.Items(0)
        Dim objFile As New System.IO.StreamReader(csvfilepath _
        , System.Text.Encoding.GetEncoding(932))
        Dim strLine As String
        Dim Haichilist As String()
        Dim i As Long, ii As Long

        Stoptime = DefaultStoptime
        Do


            System.Threading.Thread.Sleep(Stoptime)

            'ウィンドウが配置修正なら終了する
            Try
                AppActivate(WindowNameHaichisyusei)
                Exit Do
            Catch ex As Exception
                Do
                    System.Threading.Thread.Sleep(Stoptime)

                    'ウィンドウが配置基準修正なら終了する
                    Try
                        AppActivate(WindowNameHaichikijunsyusei)
                        Exit Do
                    Catch ex2 As Exception
                        MessageBox.Show("画面が見つかりません")
                        Exit Sub
                    End Try
                Loop
                Exit Do
            End Try
        Loop


        Do
            '次の行へ
            strLine = objFile.ReadLine()

            If strLine = "" Then
                Exit Do
            End If
            Haichilist = Split(strLine, ",")

            For i = LBound(Haichilist) To UBound(Haichilist)
                SendKeys.SendWait(CStr(Haichilist(i)))
                '一日分の入力が終わったら、ひとつ右に移動する
                SendKeys.SendWait("{TAB}")
                System.Threading.Thread.Sleep(Stoptime)
            Next

            '進んだ分だけ左に戻す
            ii = i - 1
            For i = 0 To ii
                SendKeys.SendWait("+{TAB}")
                System.Threading.Thread.Sleep(Stoptime)
            Next i
            '下の行に移動
            SendKeys.SendWait("{DOWN}")
            System.Threading.Thread.Sleep(Stoptime)
        Loop

        'ファイルのクローズ
        objFile.Close()
        Form1.lstファイルリスト.Items.Remove(0)
    End Sub
    Public Function 管制登録ボタン()
        Dim Bottun_Instance As New Bottun_Invoke
        Dim InvokeBottunMethod As Bottun_Delegate

        InvokeBottunMethod = New Bottun_Delegate(AddressOf Bottun_Instance.管制登録ボタン押下)
        InvokeBottunMethod.BeginInvoke(Nothing, Nothing)

        管制登録ボタン = True
    End Function
    Public Function 管制登録はいボタン()

        Windows.Forms.SendKeys.SendWait("%Y")
        管制登録はいボタン = True
    End Function
    Public Function 管制追加ボタン()
        Dim Bottun_Instance As New Bottun_Invoke
        Dim InvokeBottunMethod As Bottun_Delegate

        InvokeBottunMethod = New Bottun_Delegate(AddressOf Bottun_Instance.管制追加ボタン押下)
        InvokeBottunMethod.BeginInvoke(Nothing, Nothing)

        管制追加ボタン = True
    End Function
    Public Function 管制勤務所定時間(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "84")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで



        管制勤務所定時間 = True

    End Function
    Public Function 管制勤務所定分(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "85")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで

        管制勤務所定分 = True

    End Function
    Public Function 管制勤務残業時間(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "86")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで

        管制勤務残業時間 = True

    End Function
    Public Function 管制勤務残業分(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "87")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで

        管制勤務残業分 = True

    End Function
    Public Function 管制勤務休出時間(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "90")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで

        管制勤務休出時間 = True

    End Function
    Public Function 管制勤務休出分(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "91")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで

        管制勤務休出分 = True

    End Function
    Public Function 管制勤務深夜時間(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "92")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで

        管制勤務深夜時間 = True

    End Function
    Public Function 管制勤務深夜分(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "93")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで

        管制勤務深夜分 = True

    End Function
    Public Function 管制備考(ByVal 備考文字列 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 備考文字列

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "69")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する

        'If 既に休出処理 Or 既に法定休出処理 Then
        txtTime = txtTime & " " & ptnValue.Current.Value
        'End If

        Try
            If ptnValue.Current.Value <> txtTime Then

                ptnValue.SetValue(txtTime)

            End If
        Catch ex As Exception
        End Try
        '勤務時間のテキストボックス処理　ここまで

        管制備考 = True

    End Function

    Public Function 管制教育等所定時間(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "106")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで

        管制教育等所定時間 = True

    End Function
    Public Function 管制教育等所定分(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "107")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで

        管制教育等所定分 = True

    End Function
    Public Function 管制教育等残業時間(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "108")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで

        管制教育等残業時間 = True

    End Function
    Public Function 管制教育等残業分(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "109")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで

        管制教育等残業分 = True

    End Function
    Public Function 管制教育等休出時間(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "112")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで

        管制教育等休出時間 = True

    End Function
    Public Function 管制教育等休出分(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "113")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで

        管制教育等休出分 = True

    End Function
    Public Function 管制教育等深夜時間(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "114")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで

        管制教育等深夜時間 = True

    End Function
    Public Function 管制教育等深夜分(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "115")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで

        管制教育等深夜分 = True

    End Function

    Public Function 管制勤務就業時間(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "72")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで



        管制勤務就業時間 = True

    End Function
    Public Function 管制勤務就業分(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "73")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで



        管制勤務就業分 = True

    End Function
    Public Function 管制勤務勤務時間(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "74")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで



        管制勤務勤務時間 = True

    End Function
    Public Function 管制勤務勤務分(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "75")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで



        管制勤務勤務分 = True

    End Function

    Public Function 管制教育就業時間(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "94")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで



        管制教育就業時間 = True

    End Function
    Public Function 管制教育就業分(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "95")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで



        管制教育就業分 = True

    End Function
    Public Function 管制教育勤務時間(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "96")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで



        管制教育勤務時間 = True

    End Function
    Public Function 管制教育勤務分(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "97")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで



        管制教育勤務分 = True

    End Function

    Public Function 管制始業時刻(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間
        Dim aPoint As New System.Windows.Point(KanseiSigyouX, KanseiSigyouY)


        aeControl = Windows.Automation.AutomationElement.FromPoint(aPoint)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）

        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで



        管制始業時刻 = True

    End Function
    Public Function 管制終業時刻(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間

        Dim aPoint As New System.Windows.Point(KanseiSyugyouX, KanseiSyugyouY)


        aeControl = Windows.Automation.AutomationElement.FromPoint(aPoint)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)

        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで



        管制終業時刻 = True

    End Function
    Public Function 管制上番時刻(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間



        Dim aPoint As New System.Windows.Point(KanseiJoubanX, KanseiJoubanY)


        aeControl = Windows.Automation.AutomationElement.FromPoint(aPoint)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで



        管制上番時刻 = True

    End Function
    Public Function 管制下番時刻(ByVal 時間 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 時間


        Dim aPoint As New System.Windows.Point(KanseiKabanX, KanseiKabanY)


        aeControl = Windows.Automation.AutomationElement.FromPoint(aPoint)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する
        If ptnValue.Current.Value <> txtTime Then
            ptnValue.SetValue(txtTime)
        End If

        '勤務時間のテキストボックス処理　ここまで



        管制下番時刻 = True

    End Function
    Public Function 管制勤務タブ勤務選択(ByVal リストインデックス As Integer)

        '勤務タブの選択　ここから


        '勤務選択コンボボックスのIDは20
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "23", Windows.Automation.PropertyConditionFlags.IgnoreCase)

        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)

        'うち、リストボックスを取得
        pcSecond = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "ListBox", Windows.Automation.PropertyConditionFlags.IgnoreCase)

        aeListBox = aeControl.FindFirst(Windows.Automation.TreeScope.Subtree, pcSecond)
        Try

            'リストボックスのItemを全て取得
            aecListItem = aeListBox.FindAll(Windows.Automation.TreeScope.Children, Windows.Automation.Condition.TrueCondition)

            'Itemのインデックスで勤務番号を選ぶ
            ptnListItem = aecListItem.Item(リストインデックス).GetCurrentPattern(Windows.Automation.SelectionItemPattern.Pattern)

            ptnListItem.Select()
            '勤務タブの選択　ここまで
        Catch ex As Exception
        End Try




        管制勤務タブ勤務選択 = True

    End Function

    Public Function 管制教育タブ教育選択(ByVal 項目名 As String)


        Dim c As Windows.Automation.AutomationElement
        '社員選択コンボボックスのIDは3
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "63", Windows.Automation.PropertyConditionFlags.IgnoreCase)

        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)

        'うち、リストボックスを取得
        pcSecond = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "ListBox", Windows.Automation.PropertyConditionFlags.IgnoreCase)

        aeListBox = aeControl.FindFirst(Windows.Automation.TreeScope.Subtree, pcSecond)

        pcThird = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.NameProperty, 項目名)
        Try
            Try
                'リストボックスのItemを全て取得
                aeListItem = aeListBox.FindFirst(Windows.Automation.TreeScope.Children, pcThird)


                c = aeListItem

                'Itemの名前で勤務番号を選ぶ
                ptnListItem = aeListItem.GetCurrentPattern(Windows.Automation.SelectionItemPattern.Pattern)
                ptnListItem.Select()
            Catch ex As Exception
                ptnListItem.Select()
            End Try
            '社員タブの選択　ここまで
            管制教育タブ教育選択 = True
        Catch ex As Exception
            Stop
            管制教育タブ教育選択 = False
        End Try


    End Function
    Public Function 管制社員(ByVal 社員名 As String)


        Dim c As Windows.Automation.AutomationElement
        '社員選択コンボボックスのIDは3
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "3", Windows.Automation.PropertyConditionFlags.IgnoreCase)

        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)

        'aeControl.SetFocus()

        'うち、リストボックスを取得
        pcSecond = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "ListBox", Windows.Automation.PropertyConditionFlags.IgnoreCase)

        aeListBox = aeControl.FindFirst(Windows.Automation.TreeScope.Subtree, pcSecond)

        pcThird = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.NameProperty, 社員名)
        Try

            'リストボックスのItemを全て取得
            aeListItem = aeListBox.FindFirst(Windows.Automation.TreeScope.Children, pcThird)


            c = aeListItem

            'Itemの名前で勤務番号を選ぶ
            ptnListItem = aeListItem.GetCurrentPattern(Windows.Automation.SelectionItemPattern.Pattern)

            ptnListItem.Select()
            '社員タブの選択　ここまで
            管制社員 = True
        Catch ex As Exception
            管制社員 = False
        End Try


    End Function
    Public Function 管制警備隊(ByVal リストインデックス As Integer)


        '勤務タブの選択　ここから


        '勤務選択コンボボックスのIDは9
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "9", Windows.Automation.PropertyConditionFlags.IgnoreCase)

        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)

        'うち、リストボックスを取得
        pcSecond = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "ListBox", Windows.Automation.PropertyConditionFlags.IgnoreCase)

        aeListBox = aeControl.FindFirst(Windows.Automation.TreeScope.Subtree, pcSecond)
        Try

            'リストボックスのItemを全て取得
            aecListItem = aeListBox.FindAll(Windows.Automation.TreeScope.Children, Windows.Automation.Condition.TrueCondition)

            'Itemのインデックスで勤務番号を選ぶ
            ptnListItem = aecListItem.Item(リストインデックス).GetCurrentPattern(Windows.Automation.SelectionItemPattern.Pattern)

            ptnListItem.Select()
            '勤務タブの選択　ここまで
        Catch ex As Exception
        End Try




        管制警備隊 = True


    End Function


    Public Function 取得管制勤務所定時間()
        '勤務時間のテキストボックス処理　ここから



        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "84")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)


        取得管制勤務所定時間 = ptnValue.Current.Value


        '勤務時間のテキストボックス処理　ここまで




    End Function
    Public Function 取得管制勤務所定分()
        '勤務時間のテキストボックス処理　ここから



        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "85")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する

        取得管制勤務所定分 = ptnValue.Current.Value


        '勤務時間のテキストボックス処理　ここまで



    End Function
    Public Function 取得管制勤務残業時間()
        '勤務時間のテキストボックス処理　ここから



        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "86")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        取得管制勤務残業時間 = ptnValue.Current.Value

        '勤務時間のテキストボックス処理　ここまで



    End Function
    Public Function 取得管制勤務残業分()
        '勤務時間のテキストボックス処理　ここから



        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "87")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        取得管制勤務残業分 = ptnValue.Current.Value

    End Function
    Public Function 取得管制勤務休出時間()
        '勤務時間のテキストボックス処理　ここから



        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "90")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)


        取得管制勤務休出時間 = ptnValue.Current.Value

    End Function
    Public Function 取得管制勤務休出分()
        '勤務時間のテキストボックス処理　ここから



        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "91")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        '現在の値と同じ値を入れるとエラーになるみたいなので、違う場合のみ設定する

        '勤務時間のテキストボックス処理　ここまで

        取得管制勤務休出分 = ptnValue.Current.Value

    End Function
    Public Function 取得管制勤務深夜時間()
        '勤務時間のテキストボックス処理　ここから



        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "92")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)


        取得管制勤務深夜時間 = ptnValue.Current.Value


    End Function
    Public Function 取得管制勤務深夜分()
        '勤務時間のテキストボックス処理　ここから



        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "93")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)


        取得管制勤務深夜分 = ptnValue.Current.Value


    End Function
    Public Function 取得管制備考(ByVal 備考文字列 As String)
        '勤務時間のテキストボックス処理　ここから

        txtTime = 備考文字列

        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "69")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)

        '勤務時間のテキストボックス処理　ここまで

        取得管制備考 = ptnValue.Current.Value


    End Function
    Public Function 取得管制教育等所定時間()
        '勤務時間のテキストボックス処理　ここから



        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "106")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)


        取得管制教育等所定時間 = ptnValue.Current.Value


    End Function
    Public Function 取得管制教育等所定分()
        '勤務時間のテキストボックス処理　ここから



        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "107")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)


        取得管制教育等所定分 = ptnValue.Current.Value


    End Function
    Public Function 取得管制教育等残業時間()
        '勤務時間のテキストボックス処理　ここから



        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "108")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)


        取得管制教育等残業時間 = ptnValue.Current.Value


    End Function
    Public Function 取得管制教育等残業分()
        '勤務時間のテキストボックス処理　ここから



        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "109")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)


        取得管制教育等残業分 = ptnValue.Current.Value


    End Function
    Public Function 取得管制教育等休出時間()
        '勤務時間のテキストボックス処理　ここから



        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "112")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)


        取得管制教育等休出時間 = ptnValue.Current.Value


    End Function
    Public Function 取得管制教育等休出分()
        '勤務時間のテキストボックス処理　ここから



        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "113")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)


        取得管制教育等休出分 = ptnValue.Current.Value


    End Function
    Public Function 取得管制教育等深夜時間()
        '勤務時間のテキストボックス処理　ここから



        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "114")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)


        取得管制教育等深夜時間 = ptnValue.Current.Value


    End Function
    Public Function 取得管制教育等深夜分()
        '勤務時間のテキストボックス処理　ここから



        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "115")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)


        取得管制教育等深夜分 = ptnValue.Current.Value


    End Function
    Public Function 取得管制勤務就業時間()
        '勤務時間のテキストボックス処理　ここから



        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "72")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)




        取得管制勤務就業時間 = ptnValue.Current.Value


    End Function
    Public Function 取得管制勤務就業分()
        '勤務時間のテキストボックス処理　ここから



        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "73")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)




        取得管制勤務就業分 = ptnValue.Current.Value


    End Function
    Public Function 取得管制勤務勤務時間()
        '勤務時間のテキストボックス処理　ここから



        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "74")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)




        取得管制勤務勤務時間 = ptnValue.Current.Value


    End Function
    Public Function 取得管制勤務勤務分()
        '勤務時間のテキストボックス処理　ここから



        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "75")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)




        取得管制勤務勤務分 = ptnValue.Current.Value


    End Function
    Public Function 取得管制教育就業時間()
        '勤務時間のテキストボックス処理　ここから



        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "94")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)




        取得管制教育就業時間 = ptnValue.Current.Value


    End Function
    Public Function 取得管制教育就業分()
        '勤務時間のテキストボックス処理　ここから



        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "95")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)




        取得管制教育就業分 = ptnValue.Current.Value


    End Function
    Public Function 取得管制教育勤務時間()
        '勤務時間のテキストボックス処理　ここから



        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "96")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)




        取得管制教育勤務時間 = ptnValue.Current.Value


    End Function
    Public Function 取得管制教育勤務分()
        '勤務時間のテキストボックス処理　ここから



        'プロパティコンディションを設定（AutomationIDPropertyを識別用に設定する）
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "97")
        'プロパティコンディションから、コントロールを検索する
        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)

        取得管制教育勤務分 = ptnValue.Current.Value


    End Function
    Public Function 取得管制始業時刻()
        '勤務時間のテキストボックス処理　ここから


        Dim aPoint As New System.Windows.Point(KanseiSigyouX, KanseiSigyouY)


        aeControl = Windows.Automation.AutomationElement.FromPoint(aPoint)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)


        取得管制始業時刻 = ptnValue.Current.Value


    End Function
    Public Function 取得管制終業時刻()
        '勤務時間のテキストボックス処理　ここから

        Dim aPoint As New System.Windows.Point(KanseiSyugyouX, KanseiSyugyouY)


        aeControl = Windows.Automation.AutomationElement.FromPoint(aPoint)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)

        取得管制終業時刻 = ptnValue.Current.Value


    End Function
    Public Function 取得管制上番時刻()
        '勤務時間のテキストボックス処理　ここから

        Dim aPoint As New System.Windows.Point(KanseiJoubanX, KanseiJoubanY)


        aeControl = Windows.Automation.AutomationElement.FromPoint(aPoint)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)
        取得管制上番時刻 = ptnValue.Current.Value


    End Function
    Public Function 取得管制下番時刻()
        '勤務時間のテキストボックス処理　ここから


        Dim aPoint As New System.Windows.Point(KanseiKabanX, KanseiKabanY)


        aeControl = Windows.Automation.AutomationElement.FromPoint(aPoint)
        'コントロールのValuePatternを取得する。
        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)

        取得管制下番時刻 = ptnValue.Current.Value


    End Function
    Public Function 取得管制社員()

        '勤務タブの選択　ここから

        '勤務選択コンボボックスのIDは7
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "7", Windows.Automation.PropertyConditionFlags.IgnoreCase)

        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)

        'aeControl.SetFocus()

        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)



        取得管制社員 = ptnValue.Current.Value

    End Function
    Public Function 取得管制日付()

        '勤務タブの選択　ここから

        '勤務選択コンボボックスのIDは6
        pcFirst = New Windows.Automation.PropertyCondition(Windows.Automation.AutomationElement.AutomationIdProperty, "6", Windows.Automation.PropertyConditionFlags.IgnoreCase)

        aeControl = aeForm.FindFirst(Windows.Automation.TreeScope.Subtree, pcFirst)

        'aeControl.SetFocus()

        ptnValue = aeControl.GetCurrentPattern(Windows.Automation.ValuePattern.Pattern)



        取得管制日付 = ptnValue.Current.Value

    End Function
    Public Function クリック(ByVal X As Integer, ByVal Y As Integer)
        Cursor.Position = New Point(X, Y)
        'マウスの左ボタンを押す
        mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
        'マウスの左ボタンを離す
        mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)
        System.Threading.Thread.Sleep(Stoptime)
        クリック = True
    End Function
End Module
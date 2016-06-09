Public Class Form1

    Public hWnd As Integer
    Public KinmuHwnd As Integer
    Public ClassName As String = "ThunderRT6FormDC" '勤務管理システムのクラス
    Public WindowNameMeisaiTouroku As String = "勤務日程明細登録"
    Public WindowNameMeisai As String = "勤務日程明細"
    Public WindowNameChosei As String = "勤務日程入力＜調整＞"
    Public WindowNameYotei As String = "勤務日程入力＜予定＞"
    Public aeForm As System.Windows.Automation.AutomationElement
    Public aeControl As System.Windows.Automation.AutomationElement
    Public aeListBox As System.Windows.Automation.AutomationElement
    Public aecListItem As System.Windows.Automation.AutomationElementCollection
    Public ptnValue As System.Windows.Automation.ValuePattern
    Public ptnListItem As System.Windows.Automation.SelectionItemPattern
    Public ptnInvoke As System.Windows.Automation.InvokePattern
    Public pcFirst As Windows.Automation.PropertyCondition
    Public pcSecond As Windows.Automation.PropertyCondition
    Public txtTime As String
    Public hWndParent As Integer
    Public hWndChildAfter As Integer

    Public canceled As Boolean

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim hWnd As Integer
        Dim ClassName, WindowName As String
        Dim メッセージ As String

        canceled = False
        メッセージ = "これから勤務を入力します。" & vbCrLf & "勤務管理システムの予定画面の入力を開始するセルを選択してからＯＫを押してください。"

        MessageBox.Show(メッセージ)
        '検索文字列
        ClassName = "ThunderRT6FormDC" '勤務管理システムのクラス
        WindowName = vbNullString


        'トップレベルウィンドウから検索する
        hWnd = FindWindowEx(0, 0, ClassName, WindowName)
        KinmuHwnd = hWnd
        '見つからなかった場合、終了する
        If hWnd = 0 Then
            MessageBox.Show("勤務管理システムのウィンドウが見つかりません")
            Exit Sub
        End If
        '見つかったウィンドウを最前面に出し、アクティブにする
        SetActiveWindow(hWnd)
        SetForegroundWindow(hWnd)

        If IsNumeric(CInt(TextBox5.Text)) Then
        Else
            MessageBox.Show("時間は半角の数字のみ入れてください（/ミリ秒）")
            Exit Sub
        End If



        On Error GoTo エラー処理
        入力(DefaultStoptime:=CInt(TextBox5.Text))

        MessageBox.Show("入力終了")
        Exit Sub
エラー処理:
        MessageBox.Show("エラーが発生したので終了します")
        Exit Sub

    End Sub

    Private Sub Form1_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate

        If CheckBox1.Checked = True Then
            TextBox1.Text = System.Windows.Forms.Cursor.Position.X
            TextBox2.Text = System.Windows.Forms.Cursor.Position.Y
            KinmuX = CInt(TextBox1.Text)
            KinmuY = CInt(TextBox2.Text)
            Me.Activate()
        End If
        If CheckBox2.Checked = True Then
            TextBox3.Text = System.Windows.Forms.Cursor.Position.X
            TextBox4.Text = System.Windows.Forms.Cursor.Position.Y
            KyukaX = CInt(TextBox3.Text)
            KyukaY = CInt(TextBox4.Text)
            Me.Activate()
        End If
        If CheckBox3.Checked = True Then
            TextBox6.Text = System.Windows.Forms.Cursor.Position.X
            TextBox7.Text = System.Windows.Forms.Cursor.Position.Y
            KanseiKinmuX = CInt(TextBox6.Text)
            KanseiKinmuY = CInt(TextBox7.Text)
            Me.Activate()
        End If
        If CheckBox4.Checked = True Then
            TextBox8.Text = System.Windows.Forms.Cursor.Position.X
            TextBox9.Text = System.Windows.Forms.Cursor.Position.Y
            KanseiKyukaX = CInt(TextBox8.Text)
            KanseiKyukaY = CInt(TextBox9.Text)
            Me.Activate()
        End If
        If CheckBox5.Checked = True Then
            TextBox10.Text = System.Windows.Forms.Cursor.Position.X
            TextBox11.Text = System.Windows.Forms.Cursor.Position.Y
            KanseiSigyouX = CInt(TextBox10.Text)
            KanseiSigyouY = CInt(TextBox11.Text)
            Me.Activate()
        End If
        If CheckBox6.Checked = True Then
            TextBox12.Text = System.Windows.Forms.Cursor.Position.X
            TextBox13.Text = System.Windows.Forms.Cursor.Position.Y
            KanseiSyugyouX = CInt(TextBox12.Text)
            KanseiSyugyouY = CInt(TextBox13.Text)
            Me.Activate()
        End If
        If CheckBox7.Checked = True Then
            TextBox14.Text = System.Windows.Forms.Cursor.Position.X
            TextBox15.Text = System.Windows.Forms.Cursor.Position.Y
            KanseiJoubanX = CInt(TextBox14.Text)
            KanseiJoubanY = CInt(TextBox15.Text)
            Me.Activate()
        End If
        If CheckBox8.Checked = True Then
            TextBox16.Text = System.Windows.Forms.Cursor.Position.X
            TextBox17.Text = System.Windows.Forms.Cursor.Position.Y
            KanseiKabanX = CInt(TextBox16.Text)
            KanseiKabanY = CInt(TextBox17.Text)
            Me.Activate()
        End If

    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        My.Settings.KinmuX = KinmuX
        My.Settings.KinmuY = KinmuY
        My.Settings.KyukaX = KyukaX
        My.Settings.KyukaY = KyukaY
        My.Settings.KanseiKinmuX = KanseiKinmuX
        My.Settings.KanseiKinmuY = KanseiKinmuY
        My.Settings.KanseiKyukaX = KanseiKyukaX
        My.Settings.KanseiKyukaY = KanseiKyukaY
        My.Settings.KanseiSigyouX = KanseiSigyouX
        My.Settings.KanseiSigyouY = KanseiSigyouY
        My.Settings.KanseiSyugyouX = KanseiSyugyouX
        My.Settings.KanseiSyugyouY = KanseiSyugyouY
        My.Settings.KanseiJoubanX = KanseiJoubanX
        My.Settings.KanseiJoubanY = KanseiJoubanY
        My.Settings.KanseiKabanX = KanseiKabanX
        My.Settings.KanseiKabanY = KanseiKabanY




        My.Settings.Save()
    End Sub

    Private Sub Form1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            canceled = True
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        KinmuX = My.Settings.KinmuX
        KinmuY = My.Settings.KinmuY
        KyukaX = My.Settings.KyukaX
        KyukaY = My.Settings.KyukaY
        KanseiKinmuX = My.Settings.KanseiKinmuX
        KanseiKinmuY = My.Settings.KanseiKinmuY
        KanseiKyukaX = My.Settings.KanseiKyukaX
        KanseiKyukaY = My.Settings.KanseiKyukaY
        KanseiSigyouX = My.Settings.KanseiSigyouX
        KanseiSigyouY = My.Settings.KanseiSigyouY
        KanseiSyugyouX = My.Settings.KanseiSyugyouX
        KanseiSyugyouY = My.Settings.KanseiSyugyouY
        KanseiJoubanX = My.Settings.KanseiJoubanX
        KanseiJoubanY = My.Settings.KanseiJoubanY
        KanseiKabanX = My.Settings.KanseiKabanX
        KanseiKabanY = My.Settings.KanseiKabanY

        TextBox1.Text = KinmuX
        TextBox2.Text = KinmuY
        TextBox3.Text = KyukaX
        TextBox4.Text = KyukaY
        TextBox6.Text = KanseiKinmuX
        TextBox7.Text = KanseiKinmuY
        TextBox8.Text = KanseiKyukaX
        TextBox9.Text = KanseiKyukaY
        TextBox10.Text = KanseiSigyouX
        TextBox11.Text = KanseiSigyouY
        TextBox12.Text = KanseiSyugyouX
        TextBox13.Text = KanseiSyugyouY
        TextBox14.Text = KanseiJoubanX
        TextBox15.Text = KanseiJoubanY
        TextBox16.Text = KanseiKabanX
        TextBox17.Text = KanseiKabanY
    End Sub

    Private Sub Command2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Command2.Click



        '見つかったウィンドウを最前面に出し、アクティブにする

        'On Error GoTo エラー処理



        入力2(DefaultStoptime:=CInt(TextBox5.Text))

        MessageBox.Show("入力終了")
        Exit Sub
エラー処理:
        MessageBox.Show("エラーが発生したので終了します")
        Exit Sub


        'SendKeys.SendWait("%C")
    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub CBhaiti_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBhaiti.Click
        MessageBox.Show("配置修正もしくは配置基準修正の" & vbCrLf & "左上のセルをクリックして" & "IMEを半角英数モードにしてからＯＫを押してください")
        配置数入力(DefaultStoptime:=CInt(TextBox5.Text))
        MessageBox.Show("入力終了")
    End Sub

    Private Sub ListBox1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
        Dim FilePath() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())
        lstファイルリスト.Items.Add(FilePath(0))

    End Sub

    Private Sub lstファイルリスト_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstファイルリスト.DragDrop
        Dim i As Integer
        lstファイルリスト.Items.Clear()
        If e.Data.GetDataPresent(Windows.Forms.DataFormats.FileDrop) Then
            Dim objData As Object = e.Data.GetData(Windows.Forms.DataFormats.FileDrop)
            Dim strFiles As String() = CType(objData, String())
            For i = 0 To UBound(strFiles)
                lstファイルリスト.Items.Add(strFiles(i))
            Next
        End If

    End Sub

    Private Sub lstファイルリスト_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstファイルリスト.DragEnter
        'DragEnterイベントで、FileDropタイプを受け入れられるかどうかを調べてEffect（copyで受け入れる）をセットする
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub btnKobetsu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKobetsu.Click
        Me.Hide()
        Form2.Show()
    End Sub

    Private Sub btnUchiwake_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUchiwake.Click
        Me.Hide()
        frm打ち分け.Show()
    End Sub

    Private Sub lstファイルリスト_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstファイルリスト.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frm法定外実地教育.Show()
        Me.Hide()
    End Sub

    Private Sub BtnNyuryoku_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNyuryoku.Click
        Me.Hide()
        frm入力.Show()
    End Sub
End Class

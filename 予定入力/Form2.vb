Public Class Form2

    Private Sub Form2_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form1.Show()
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        勤務日程入力画面取得()
    End Sub


    Private Sub btn勤務法定休出_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn勤務法定休出.Click
        予定画面から更新を押して勤務明細登録画面へ()
        'ここに処理を入力
        勤務法定休出処理()
        'ここまで
        勤務明細登録画面から登録を押して予定画面へ()
        Me.TopMost = True
    End Sub
    Public Sub 勤務明細登録画面から登録を押して予定画面へ()

        Dim Bottun_Instance As New Bottun_Invoke
        Dim InvokeBottunMethod As Bottun_Delegate
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

        法定休出 = False
        休出 = False
        翌日休 = False
        翌日法定休 = False
        既に休出処理 = False
        既に法定休出処理 = False
        昼夜勤判定 = False
        夜勤判定 = False
    End Sub
    Public Sub 予定画面から更新を押して勤務明細登録画面へ()
        Dim hForegroundWnd As Long
        Dim Bottun_Instance As New Bottun_Invoke
        Dim InvokeBottunMethod As Bottun_Delegate




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

        InvokeBottunMethod = New Bottun_Delegate(AddressOf Bottun_Instance.更新ボタン押下)
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

    End Sub

    Private Sub btn勤務休出_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn勤務休出.Click
        予定画面から更新を押して勤務明細登録画面へ()
        'ここに処理を入力
        勤務休出処理()
        'ここまで
        勤務明細登録画面から登録を押して予定画面へ()
        Me.TopMost = True

    End Sub

    Private Sub btn24勤務翌日法定休_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn24勤務翌日法定休.Click


        予定画面から更新を押して勤務明細登録画面へ()
        'ここに処理を入力
        昼夜勤判定 = True
        勤務翌日法定休処理()
        'ここまで
        勤務明細登録画面から登録を押して予定画面へ()
        Me.TopMost = True

    End Sub

    Private Sub btn24勤務翌日休_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn24勤務翌日休.Click
        予定画面から更新を押して勤務明細登録画面へ()
        'ここに処理を入力
        昼夜勤判定 = True
        勤務翌日休処理()
        'ここまで
        勤務明細登録画面から登録を押して予定画面へ()
        Me.TopMost = True

    End Sub

    Private Sub btn教育等法定休出_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn教育等法定休出.Click
        予定画面から更新を押して勤務明細登録画面へ()
        'ここに処理を入力
        教育等法定休出処理()
        'ここまで
        勤務明細登録画面から登録を押して予定画面へ()
        Me.TopMost = True

    End Sub

    Private Sub btn教育等休出_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn教育等休出.Click
        予定画面から更新を押して勤務明細登録画面へ()
        'ここに処理を入力
        教育等休出処理()
        'ここまで
        勤務明細登録画面から登録を押して予定画面へ()
        Me.TopMost = True

    End Sub

    Private Sub btn教育等翌日法定休_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn教育等翌日法定休.Click
        予定画面から更新を押して勤務明細登録画面へ()
        'ここに処理を入力
        翌日法定休 = True
        教育等翌日法定休処理()
        'ここまで
        勤務明細登録画面から登録を押して予定画面へ()
        Me.TopMost = True

    End Sub

    Private Sub btn教育等翌日休_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn教育等翌日休.Click
        予定画面から更新を押して勤務明細登録画面へ()
        'ここに処理を入力
        翌日休 = True
        教育等翌日休処理()
        'ここまで
        勤務明細登録画面から登録を押して予定画面へ()
        Me.TopMost = True

    End Sub

    Private Sub btn夜勤翌日法定休_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn夜勤翌日法定休.Click
        予定画面から更新を押して勤務明細登録画面へ()
        'ここに処理を入力
        夜勤判定 = True
        勤務翌日法定休処理()
        'ここまで
        勤務明細登録画面から登録を押して予定画面へ()
        Me.TopMost = True
    End Sub

    Private Sub btn夜勤翌日休_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn夜勤翌日休.Click
        予定画面から更新を押して勤務明細登録画面へ()
        'ここに処理を入力
        夜勤判定 = True
        勤務翌日休処理()
        'ここまで
        勤務明細登録画面から登録を押して予定画面へ()
        Me.TopMost = True
    End Sub

    Private Sub btn24勤務法定休出_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn24勤務法定休出.Click
        予定画面から更新を押して勤務明細登録画面へ()
        'ここに処理を入力
        昼夜勤判定 = True
        勤務法定休出処理()
        'ここまで
        勤務明細登録画面から登録を押して予定画面へ()
        Me.TopMost = True
    End Sub

    Private Sub btn24勤務休出_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn24勤務休出.Click
        予定画面から更新を押して勤務明細登録画面へ()
        'ここに処理を入力
        昼夜勤判定 = True
        勤務休出処理()
        'ここまで
        勤務明細登録画面から登録を押して予定画面へ()
        Me.TopMost = True
    End Sub

    Private Sub btn勤務法定休出2_Click(sender As System.Object, e As System.EventArgs) Handles btn勤務法定休出2.Click
        Dim hForegroundWnd As Long
        Dim Bottun_Instance As New Bottun_Invoke
        Dim InvokeBottunMethod As Bottun_Delegate
        予定画面から更新を押して勤務明細登録画面へ()
        'ここに処理を入力
        勤務法定休出処理()
        既に法定休出処理 = True

        '2回目の処理
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

        InvokeBottunMethod = New Bottun_Delegate(AddressOf Bottun_Instance.更新ボタン押下)
        InvokeBottunMethod.BeginInvoke(Nothing, Nothing)
        '2回目の処理おわり




        Do
            System.Threading.Thread.Sleep(Stoptime)

            'ウィンドウが勤務日程明細登録なら終了する
            Try
                AppActivate(WindowNameMeisaiTouroku)
                Exit Do
            Catch ex As Exception

            End Try
        Loop

        勤務法定休出処理()
        'ここまで
        勤務明細登録画面から登録を押して予定画面へ()
        既に法定休出処理 = False
        Me.TopMost = True
    End Sub
End Class
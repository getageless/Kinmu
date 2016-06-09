Public Class frm入力
    Declare Sub Sleep Lib "kernel32" _
     (ByVal dwMilliseconds As Long)
    Public MotoKinmu As New SyainKinmuJikan
    Public ShinKinmu As New SyainKinmuJikan
    Public CopyKinmu1 As New SyainKinmuJikan
    Public CopyKinmu2 As New SyainKinmuJikan
    Public CopyKinmu3 As New SyainKinmuJikan
    Public CopyKinmu4 As New SyainKinmuJikan
    Public CopyKinmu5 As New SyainKinmuJikan
    Public CopyKinmu6 As New SyainKinmuJikan
    Dim strKoumoku As String

    Public Structure SyainKinmuJikan
        Dim Simei As String
        Dim HSyotei As String
        Dim MSyotei As String
        Dim HZangyo As String
        Dim MZangyo As String
        Dim HShinya As String
        Dim MShinya As String
        Dim HKyusyutsu As String
        Dim MKyusyutsu As String
        Dim Sigyou As String
        Dim Syugyou As String
        Dim HSyugyou As String
        Dim MSyugyou As String
        Dim HKinmu As String
        Dim MKinmu As String
        Dim Jouban As String
        Dim Kaban As String

        Function GetSyainKinmuJikan()
            Try

                Simei = 取得管制社員()
                HSyotei = 取得管制勤務所定時間()
                MSyotei = 取得管制勤務所定分()
                HZangyo = 取得管制勤務残業時間()
                MZangyo = 取得管制勤務残業分()
                HShinya = 取得管制勤務深夜時間()
                MShinya = 取得管制勤務深夜分()
                HKyusyutsu = 取得管制勤務休出時間()
                MKyusyutsu = 取得管制勤務休出分()
                Sigyou = 取得管制始業時刻()
                Syugyou = 取得管制終業時刻()
                HSyugyou = 取得管制勤務就業時間()
                MSyugyou = 取得管制勤務就業分()
                HKinmu = 取得管制勤務勤務時間()
                MKinmu = 取得管制勤務勤務分()
                Jouban = 取得管制上番時刻()
                Kaban = 取得管制下番時刻()

                GetSyainKinmuJikan = True
            Catch ex As Exception
                GetSyainKinmuJikan = False
            End Try
        End Function
        Sub Seikika()



            If HSyotei = "" Then HSyotei = "00"
            If MSyotei = "" Then MSyotei = "00"
            If HZangyo = "" Then HZangyo = "00"
            If MZangyo = "" Then MZangyo = "00"
            If HShinya = "" Then HShinya = "00"
            If MShinya = "" Then MShinya = "00"
            If HKyusyutsu = "" Then HKyusyutsu = "00"
            If MKyusyutsu = "" Then MKyusyutsu = "00"
            If HSyugyou = "" Then HSyugyou = "00"
            If MSyugyou = "" Then MSyugyou = "00"
            If HKinmu = "" Then HKinmu = "00"
            If MKinmu = "" Then MKinmu = "00"


        End Sub
        Function SetSyainKinmuJikan(Optional ByVal Bikou As String = "")
            Try

                管制始業時刻(Sigyou)
                管制終業時刻(Syugyou)
                管制勤務就業時間(HSyugyou)
                管制勤務就業分(MSyugyou)
                管制上番時刻(Jouban)
                管制下番時刻(Kaban)
                管制勤務勤務時間(HKinmu)
                管制勤務勤務分(MKinmu)
                管制勤務所定時間(HSyotei)
                管制勤務所定分(MSyotei)
                管制勤務残業時間(HZangyo)
                管制勤務残業分(MZangyo)
                管制勤務深夜時間(HShinya)
                管制勤務深夜分(MShinya)
                管制勤務休出時間(HKyusyutsu)
                管制勤務休出分(MKyusyutsu)
                管制備考(Bikou)

                SetSyainKinmuJikan = True
            Catch ex As Exception

                SetSyainKinmuJikan = False
            End Try
        End Function
        Function SetSyainKinmuJikannomi(Optional ByVal Bikou As String = "")
            Try

                管制始業時刻(Sigyou)
                管制終業時刻(Syugyou)
                管制勤務就業時間(HSyugyou)
                管制勤務就業分(MSyugyou)
                管制上番時刻(Jouban)
                管制下番時刻(Kaban)
                管制勤務勤務時間(HKinmu)
                管制勤務勤務分(MKinmu)
                管制勤務所定時間(HSyotei)
                管制勤務所定分(MSyotei)
                管制勤務残業時間(HZangyo)
                管制勤務残業分(MZangyo)
                管制勤務深夜時間(HShinya)
                管制勤務深夜分(MShinya)
                管制勤務休出時間(HKyusyutsu)
                管制勤務休出分(MKyusyutsu)

                SetSyainKinmuJikannomi = True
            Catch ex As Exception

                SetSyainKinmuJikannomi = False
            End Try
        End Function
        Function AdjustNightTime()
            Dim starttime As TimeSpan, endtime As TimeSpan, juuji As TimeSpan, goji As TimeSpan, nijuukuji As TimeSpan
            Dim shinyajikan As TimeSpan

            Try
                starttime = TimeSpan.Parse(Jouban)
                endtime = TimeSpan.Parse(Kaban)
                juuji = TimeSpan.FromHours(22)
                goji = TimeSpan.FromHours(5)
                nijuukuji = TimeSpan.FromHours(29)

                '開始が５時から２２時の間は開始を２２時にする
                If starttime >= goji And starttime < juuji Then
                    starttime = juuji
                End If
                '終了が５時から２２時の間は、終了を２２時にする
                If endtime >= goji And endtime < juuji Then
                    endtime = juuji
                End If
                '開始が５時より前で終了が２２時以前の場合は、終了を５時にしておく
                If starttime < goji And endtime <= juuji Then
                    endtime = goji
                End If
                '開始が５時より後で２２時未満、終了が２２時より後、０時より前の場合は、対応なし
                '開始が０時より後で、５時までの間、終了も同じだったら対応なし

                '開始と終了が０時をまたぐ場合
                If starttime > endtime Then
                    endtime = endtime + TimeSpan.FromHours(24)
                End If


                shinyajikan = endtime - starttime

                HShinya = shinyajikan.Hours
                MShinya = shinyajikan.Minutes

                AdjustNightTime = True
            Catch ex As Exception
                AdjustNightTime = False
            End Try
        End Function

        Function AdjustTimeTable()
            Try
                Dim Jitsudou As TimeSpan, Kousoku As TimeSpan
                Dim gojikan As TimeSpan, kujikan As TimeSpan, juuitijikan As TimeSpan, juunijikanjuugofun As TimeSpan

                gojikan = TimeSpan.FromHours(5)
                kujikan = TimeSpan.FromHours(9)
                juuitijikan = TimeSpan.FromHours(11)
                juunijikanjuugofun = TimeSpan.FromHours(12) + TimeSpan.FromMinutes(15)


                Kousoku = TimeSpan.FromHours(HKinmu) + TimeSpan.FromMinutes(MKinmu)

                Select Case Kousoku
                    Case Is < gojikan
                        Jitsudou = Kousoku
                    Case Is < kujikan
                        Jitsudou = Kousoku - TimeSpan.FromMinutes(45)
                    Case Is < juuitijikan
                        Jitsudou = Kousoku - TimeSpan.FromHours(1)
                    Case Is < juunijikanjuugofun
                        Jitsudou = Kousoku - TimeSpan.FromHours(1) - TimeSpan.FromMinutes(30)
                    Case Is >= juunijikanjuugofun
                        Jitsudou = Kousoku - TimeSpan.FromHours(2)
                End Select


                If HSyotei + MSyotei <> 0 Then
                    HSyotei = Jitsudou.Hours
                    MSyotei = Jitsudou.Minutes
                    Seikika()

                ElseIf HZangyo + MZangyo <> 0 Then
                    HZangyo = Jitsudou.Hours
                    MZangyo = Jitsudou.Minutes
                    Seikika()

                ElseIf HKyusyutsu + MKyusyutsu <> 0 Then
                    HKyusyutsu = Jitsudou.Hours
                    MKyusyutsu = Jitsudou.Minutes
 
                End If

                AdjustTimeTable = True
            Catch ex As Exception
                AdjustTimeTable = False
            End Try



        End Function
        Function SetSyainKyouikuJikan(ByVal Bikou As String, ByVal strKoumoku As String)



            Try


                管制社員(Simei)

                管制教育タブ教育選択(strKoumoku)
                管制教育等所定時間(HSyotei)
                管制教育等所定分(MSyotei)
                管制教育等残業時間(HZangyo)
                管制教育等残業分(MZangyo)
                管制教育等深夜時間(HShinya)
                管制教育等深夜分(MShinya)
                管制教育等休出時間(HKyusyutsu)
                管制教育等休出分(MKyusyutsu)
                管制始業時刻(Sigyou)
                管制終業時刻(Syugyou)
                管制教育就業時間(HSyugyou)
                管制教育就業分(MSyugyou)
                管制上番時刻(Jouban)
                管制下番時刻(Kaban)
                管制教育勤務時間(HKinmu)
                管制教育勤務分(MKinmu)


                管制備考(Bikou)
                SetSyainKyouikuJikan = True
            Catch ex As Exception
                SetSyainKyouikuJikan = False
            End Try
        End Function

    End Structure
    Private Sub frm入力_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form1.Show()
    End Sub
    Private Sub btnTableJouban_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTableJouban.Click
        JoubanHenkou(True)
    End Sub
    Private Sub btnTanjunJouban_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTanjunJouban.Click

        JoubanHenkou(False)
    End Sub
    Private Sub btnTanjunKaban_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTanjunKaban.Click
        KabanHenkou(False)
    End Sub
    Private Sub btnTableKaban_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTableKaban.Click
        KabanHenkou(True)
    End Sub
    Public Sub JoubanHenkou(ByVal blTimeTable As Boolean)
        Dim KTime As New System.TimeSpan, STime As New System.TimeSpan, ZTime As New System.TimeSpan
        Dim KyuTime As New System.TimeSpan, ZeroTime As New System.TimeSpan
        Dim c As Object
        Dim HendouTime As New System.TimeSpan
        Dim PlusMinus As Integer
        Dim rc As Object
        PlusMinus = 1

        Me.Hide()
        管制入力画面を前面に()
        管制日報入力画面取得()

        '社員の勤務情報を取得して、新しい勤務時間を作成し、セットする。
        If MotoKinmu.GetSyainKinmuJikan() = False Then
            MessageBox.Show("勤務時間の取得ができませんでした。")
            Me.Show()
            Exit Sub
        End If
        c = MotoKinmu
        MotoKinmu.Seikika()
        '社員の勤務情報
        ShinKinmu = MotoKinmu

        '後ろから勤務時間を抜いて、残る勤務を作る
        '変更後時間を作成

        KTime = TimeSpan.FromHours(NUDJoubanJikan.Value)
        KTime = KTime + TimeSpan.FromMinutes(NUDJoubanFun.Value)

        '変動時間を作成しておく
        If TimeSpan.Parse(MotoKinmu.Jouban) < KTime Then
            '上番時刻が遅くなったら、後で引く
            HendouTime = KTime - TimeSpan.Parse(MotoKinmu.Jouban)
            PlusMinus = -1
        ElseIf TimeSpan.Parse(MotoKinmu.Jouban) >= KTime Then
            '上番時刻が早くなったら、後で足す
            HendouTime = TimeSpan.Parse(MotoKinmu.Jouban) - KTime
            PlusMinus = 1
        End If

        '時間を取得して、再設定していく
        '上番時刻と始業時刻の設定
        MotoKinmu.Sigyou = CStr(Format(KTime.Hours, "00") & ":" & Format(KTime.Minutes, "00"))
        MotoKinmu.Jouban = CStr(Format(KTime.Hours, "00") & ":" & Format(KTime.Minutes, "00"))
        MotoKinmu.Seikika()


        '深夜時間を作っておく
        MotoKinmu.AdjustNightTime()


        ''就業時間から変動時間を調整する。
        '就業時間・勤務時間の設定をするために、元勤務から就業時間を取得
        STime = TimeSpan.Parse(MotoKinmu.HSyugyou & ":" & MotoKinmu.MSyugyou)
        If PlusMinus = 1 Then
            STime = STime + HendouTime
        ElseIf PlusMinus = -1 Then
            STime = STime - HendouTime
        End If
        MotoKinmu.HSyugyou = STime.Hours
        MotoKinmu.MSyugyou = STime.Minutes
        MotoKinmu.HKinmu = STime.Hours
        MotoKinmu.MKinmu = STime.Minutes
        MotoKinmu.Seikika()

        '所定時間の調査
        STime = TimeSpan.FromHours(MotoKinmu.HSyotei)
        STime = STime + TimeSpan.FromMinutes(MotoKinmu.MSyotei)
        If PlusMinus = 1 Then
            STime = STime + HendouTime
        ElseIf PlusMinus = -1 Then
            STime = STime - HendouTime
        End If
        '残業時間の調査
        ZTime = TimeSpan.FromHours(MotoKinmu.HZangyo)
        ZTime = ZTime + TimeSpan.FromMinutes(MotoKinmu.MZangyo)
        If PlusMinus = 1 Then
            ZTime = ZTime + HendouTime
        ElseIf PlusMinus = -1 Then
            ZTime = ZTime - HendouTime
        End If

        '休出時間の調査
        KyuTime = TimeSpan.FromHours(MotoKinmu.HKyusyutsu)
        KyuTime = KyuTime + TimeSpan.FromMinutes(MotoKinmu.MKyusyutsu)

        If PlusMinus = 1 Then
            KyuTime = KyuTime + HendouTime
        ElseIf PlusMinus = -1 Then
            KyuTime = KyuTime - HendouTime
        End If


        '所定・残業・休出のどれを変更するか決める
        If MotoKinmu.HSyotei + MotoKinmu.MSyotei <> 0 Then
            MotoKinmu.HSyotei = STime.Hours
            MotoKinmu.MSyotei = STime.Minutes
            MotoKinmu.Seikika()
            '勤務時間の入力
            管制入力画面を前面に()
            管制日報入力画面取得()
            c = MotoKinmu
            '\\\\\\\\\\\\\\\\\\\\\\
            'タイムテーブルを使うなら、ここで処理する。
            If blTimeTable = True Then
                rc = MotoKinmu.AdjustTimeTable()
            End If

            '\\\\\\\\\\\\\\\\\\\\\\
            If MotoKinmu.SetSyainKinmuJikan(txtBikou.Text) = False Then
                MessageBox.Show("エラーが出ました。もう一度やり直してください")
                Me.Show()
                Exit Sub
            End If
            c = MotoKinmu

        ElseIf MotoKinmu.HZangyo + MotoKinmu.MZangyo <> 0 Then
            MotoKinmu.HZangyo = ZTime.Hours
            MotoKinmu.MZangyo = ZTime.Minutes
            MotoKinmu.Seikika()
            '残される勤務時間の入力
            管制入力画面を前面に()
            管制日報入力画面取得()
            c = MotoKinmu
            '\\\\\\\\\\\\\\\\\\\\\\
            'タイムテーブルを使うなら、ここで処理する。
            If blTimeTable = True Then
                rc = MotoKinmu.AdjustTimeTable()
            End If

            '\\\\\\\\\\\\\\\\\\\\\\
            If MotoKinmu.SetSyainKinmuJikan(txtBikou.Text) = False Then
                MessageBox.Show("エラーが出ました。もう一度やり直してください")
                Me.Show()
                Exit Sub
            End If
            c = MotoKinmu

        ElseIf MotoKinmu.HKyusyutsu + MotoKinmu.MKyusyutsu <> 0 Then
            MotoKinmu.HKyusyutsu = KyuTime.Hours
            MotoKinmu.MKyusyutsu = KyuTime.Minutes
            MotoKinmu.Seikika()
            '残される勤務時間の入力
            管制入力画面を前面に()
            管制日報入力画面取得()
            c = MotoKinmu
            '\\\\\\\\\\\\\\\\\\\\\\
            'タイムテーブルを使うなら、ここで処理する。
            If blTimeTable = True Then
                rc = MotoKinmu.AdjustTimeTable()
            End If

            '\\\\\\\\\\\\\\\\\\\\\\
            If MotoKinmu.SetSyainKinmuJikan(txtBikou.Text) = False Then
                MessageBox.Show("エラーが出ました。もう一度やり直してください")
                Me.Show()
                Exit Sub
            End If
            c = MotoKinmu

        Else
            MessageBox.Show("うまくいきませんでした")
            Me.Show()
            Exit Sub
        End If


        Me.Show()

        MotoKinmu.Seikika()


    End Sub
    Public Sub KabanHenkou(ByVal blTimeTable As Boolean)
        Dim KTime As New System.TimeSpan, STime As New System.TimeSpan, ZTime As New System.TimeSpan
        Dim KyuTime As New System.TimeSpan, ZeroTime As New System.TimeSpan
        Dim c As Object
        Dim HendouTime As New System.TimeSpan
        Dim PlusMinus As Integer
        Dim rc As Object
        PlusMinus = 1

        Me.Hide()
        管制入力画面を前面に()
        管制日報入力画面取得()

        '社員の勤務情報を取得して、新しい勤務時間を作成し、セットする。
        If MotoKinmu.GetSyainKinmuJikan() = False Then
            MessageBox.Show("勤務時間の取得ができませんでした。")
            Exit Sub
        End If
        c = MotoKinmu
        MotoKinmu.Seikika()
        '社員の勤務情報
        ShinKinmu = MotoKinmu

        '後ろから勤務時間を抜いて、残る勤務を作る
        '変更後時間を作成

        KTime = TimeSpan.FromHours(NUDKabanJikan.Value)
        KTime = KTime + TimeSpan.FromMinutes(NUDKabanFun.Value)

        '変動時間を作成しておく
        If TimeSpan.Parse(MotoKinmu.Kaban) < KTime Then
            '下番時刻が遅くなったら、後で足す
            HendouTime = KTime - TimeSpan.Parse(MotoKinmu.Kaban)
            PlusMinus = 1
        ElseIf TimeSpan.Parse(MotoKinmu.Kaban) >= KTime Then
            '下番時刻が早くなったら、後で引く
            HendouTime = TimeSpan.Parse(MotoKinmu.Kaban) - KTime
            PlusMinus = -1
        End If

        '時間を取得して、再設定していく
        '上番時刻と始業時刻の設定
        MotoKinmu.Syugyou = CStr(Format(KTime.Hours, "00") & ":" & Format(KTime.Minutes, "00"))
        MotoKinmu.Kaban = CStr(Format(KTime.Hours, "00") & ":" & Format(KTime.Minutes, "00"))
        MotoKinmu.Seikika()


        '深夜時間を作っておく
        MotoKinmu.AdjustNightTime()


        ''就業時間から変動時間を調整する。
        '就業時間・勤務時間の設定をするために、元勤務から就業時間を取得
        STime = TimeSpan.Parse(MotoKinmu.HSyugyou & ":" & MotoKinmu.MSyugyou)
        If PlusMinus = 1 Then
            STime = STime + HendouTime
        ElseIf PlusMinus = -1 Then
            STime = STime - HendouTime
        End If
        MotoKinmu.HSyugyou = STime.Hours
        MotoKinmu.MSyugyou = STime.Minutes
        MotoKinmu.HKinmu = STime.Hours
        MotoKinmu.MKinmu = STime.Minutes
        MotoKinmu.Seikika()

        '所定時間の調査
        STime = TimeSpan.FromHours(MotoKinmu.HSyotei)
        STime = STime + TimeSpan.FromMinutes(MotoKinmu.MSyotei)
        If PlusMinus = 1 Then
            STime = STime + HendouTime
        ElseIf PlusMinus = -1 Then
            STime = STime - HendouTime
        End If
        '残業時間の調査
        ZTime = TimeSpan.FromHours(MotoKinmu.HZangyo)
        ZTime = ZTime + TimeSpan.FromMinutes(MotoKinmu.MZangyo)
        If PlusMinus = 1 Then
            ZTime = ZTime + HendouTime
        ElseIf PlusMinus = -1 Then
            ZTime = ZTime - HendouTime
        End If

        '休出時間の調査
        KyuTime = TimeSpan.FromHours(MotoKinmu.HKyusyutsu)
        KyuTime = KyuTime + TimeSpan.FromMinutes(MotoKinmu.MKyusyutsu)

        If PlusMinus = 1 Then
            KyuTime = KyuTime + HendouTime
        ElseIf PlusMinus = -1 Then
            KyuTime = KyuTime - HendouTime
        End If


        '所定・残業・休出のどれを変更するか決める
        If MotoKinmu.HSyotei + MotoKinmu.MSyotei <> 0 Then
            MotoKinmu.HSyotei = STime.Hours
            MotoKinmu.MSyotei = STime.Minutes
            MotoKinmu.Seikika()
            '勤務時間の入力
            管制入力画面を前面に()
            管制日報入力画面取得()
            c = MotoKinmu
            '\\\\\\\\\\\\\\\\\\\\\\
            'タイムテーブルを使うなら、ここで処理する。
            If blTimeTable = True Then
                rc = MotoKinmu.AdjustTimeTable()
            End If

            '\\\\\\\\\\\\\\\\\\\\\\
            If MotoKinmu.SetSyainKinmuJikan(txtBikou.Text) = False Then
                MessageBox.Show("エラーが出ました。もう一度やり直してください")
                Exit Sub
            End If
            c = MotoKinmu

        ElseIf MotoKinmu.HZangyo + MotoKinmu.MZangyo <> 0 Then
            MotoKinmu.HZangyo = ZTime.Hours
            MotoKinmu.MZangyo = ZTime.Minutes
            MotoKinmu.Seikika()
            '残される勤務時間の入力
            管制入力画面を前面に()
            管制日報入力画面取得()
            c = MotoKinmu
            '\\\\\\\\\\\\\\\\\\\\\\
            'タイムテーブルを使うなら、ここで処理する。
            If blTimeTable = True Then
                rc = MotoKinmu.AdjustTimeTable()
            End If

            '\\\\\\\\\\\\\\\\\\\\\\
            If MotoKinmu.SetSyainKinmuJikan(txtBikou.Text) = False Then
                MessageBox.Show("エラーが出ました。もう一度やり直してください")
                Exit Sub
            End If
            c = MotoKinmu

        ElseIf MotoKinmu.HKyusyutsu + MotoKinmu.MKyusyutsu <> 0 Then
            MotoKinmu.HKyusyutsu = KyuTime.Hours
            MotoKinmu.MKyusyutsu = KyuTime.Minutes
            MotoKinmu.Seikika()
            '残される勤務時間の入力
            管制入力画面を前面に()
            管制日報入力画面取得()
            c = MotoKinmu
            '\\\\\\\\\\\\\\\\\\\\\\
            'タイムテーブルを使うなら、ここで処理する。
            If blTimeTable = True Then
                rc = MotoKinmu.AdjustTimeTable()
            End If

            '\\\\\\\\\\\\\\\\\\\\\\
            If MotoKinmu.SetSyainKinmuJikan(txtBikou.Text) = False Then
                MessageBox.Show("エラーが出ました。もう一度やり直してください")
                Exit Sub
            End If
            c = MotoKinmu

        Else
            MessageBox.Show("うまくいきませんでした")
            Exit Sub
        End If


        Me.Show()

        MotoKinmu.Seikika()


    End Sub
    Public Sub 管制入力画面を前面に()

        Do
            System.Threading.Thread.Sleep(Stoptime)
            WindowNameKanseiNyuryoku = "管制日報入力"
            'ウィンドウが勤務日程明細登録なら終了する
            Try
                AppActivate(WindowNameKanseiNyuryoku)
                Exit Do
            Catch ex As Exception

            End Try
        Loop
    End Sub
    Private Sub frm入力_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub RB15fun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB15fun.CheckedChanged
        If RB5fun.Checked = True Then
            NUDKabanFun.Increment = 5
            NUDJoubanFun.Increment = 5
            NUDKabanFun.Maximum = 55
            NUDJoubanFun.Maximum = 55
        ElseIf RB15fun.Checked = True Then
            NUDKabanFun.Increment = 15
            NUDJoubanFun.Increment = 15
            NUDKabanFun.Maximum = 45
            NUDJoubanFun.Maximum = 45
        End If
    End Sub
    Private Sub RB5fun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB5fun.CheckedChanged
        If RB5fun.Checked = True Then
            NUDKabanFun.Increment = 5
            NUDJoubanFun.Increment = 5
            NUDKabanFun.Maximum = 55
            NUDJoubanFun.Maximum = 55
        ElseIf RB15fun.Checked = True Then
            NUDKabanFun.Increment = 15
            NUDJoubanFun.Increment = 15
            NUDKabanFun.Maximum = 45
            NUDJoubanFun.Maximum = 45
        End If
    End Sub
    Private Sub btnKousin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKousin.Click


        管制入力画面を前面に()
        管制日報入力画面取得()

        '社員の勤務情報を取得して、新しい勤務時間を作成し、セットする。
        If MotoKinmu.GetSyainKinmuJikan() = False Then
            MessageBox.Show("勤務時間の取得ができませんでした。")
            Exit Sub
        End If
        MotoKinmu.Seikika()

        Me.NUDJoubanJikan.Value = System.TimeSpan.Parse(MotoKinmu.Jouban).Hours
        Me.NUDJoubanFun.Value = System.TimeSpan.Parse(MotoKinmu.Jouban).Minutes
        Me.NUDKabanJikan.Value = System.TimeSpan.Parse(MotoKinmu.Kaban).Hours
        Me.NUDKabanFun.Value = System.TimeSpan.Parse(MotoKinmu.Kaban).Minutes

    End Sub
    Private Sub btnToroku_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToroku.Click
        Dim r As Object
        r = TorokuRY()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        frm法定外実地教育.Show()
    End Sub
    Private Sub btnJikanCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJikanCopy.Click

        管制入力画面を前面に()
        管制日報入力画面取得()
        If RBCopy1.Checked = True Then
            CopyKinmu1.GetSyainKinmuJikan()
            RBCopy1.Text = CopyKinmu1.Jouban & "～" & CopyKinmu1.Kaban
        ElseIf RBCopy2.Checked = True Then
            CopyKinmu2.GetSyainKinmuJikan()
            RBCopy2.Text = CopyKinmu2.Jouban & "～" & CopyKinmu2.Kaban
        ElseIf RBCopy3.Checked = True Then
            CopyKinmu3.GetSyainKinmuJikan()
            RBCopy3.Text = CopyKinmu3.Jouban & "～" & CopyKinmu3.Kaban
        ElseIf RBCopy4.Checked = True Then
            CopyKinmu4.GetSyainKinmuJikan()
            RBCopy4.Text = CopyKinmu4.Jouban & "～" & CopyKinmu4.Kaban
        ElseIf RBCopy5.Checked = True Then
            CopyKinmu5.GetSyainKinmuJikan()
            RBCopy5.Text = CopyKinmu5.Jouban & "～" & CopyKinmu5.Kaban
        ElseIf RBCopy6.Checked = True Then
            CopyKinmu6.GetSyainKinmuJikan()
            RBCopy6.Text = CopyKinmu6.Jouban & "～" & CopyKinmu6.Kaban
        End If

        Me.Activate()
    End Sub
    Private Sub btnHaritsuke_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHaritsuke.Click
        Dim rc As Object
        Dim r As Object
        管制入力画面を前面に()
        管制日報入力画面取得()
        rc = False
        If RBCopy1.Checked = True Then
            rc = CopyKinmu1.SetSyainKinmuJikannomi()
            RBCopy1.Text = CopyKinmu1.Jouban & "～" & CopyKinmu1.Kaban
        ElseIf RBCopy2.Checked = True Then
            rc = CopyKinmu2.SetSyainKinmuJikannomi()
            RBCopy2.Text = CopyKinmu2.Jouban & "～" & CopyKinmu2.Kaban
        ElseIf RBCopy3.Checked = True Then
            rc = CopyKinmu3.SetSyainKinmuJikannomi()
            RBCopy3.Text = CopyKinmu3.Jouban & "～" & CopyKinmu3.Kaban
        ElseIf RBCopy4.Checked = True Then
            rc = CopyKinmu4.SetSyainKinmuJikannomi()
            RBCopy4.Text = CopyKinmu4.Jouban & "～" & CopyKinmu4.Kaban
        ElseIf RBCopy5.Checked = True Then
            rc = CopyKinmu5.SetSyainKinmuJikannomi()
            RBCopy5.Text = CopyKinmu5.Jouban & "～" & CopyKinmu5.Kaban
        ElseIf RBCopy6.Checked = True Then
            rc = CopyKinmu6.SetSyainKinmuJikannomi()
            RBCopy6.Text = CopyKinmu6.Jouban & "～" & CopyKinmu6.Kaban
        End If
        If rc = False Then
            MessageBox.Show("失敗しました")
        End If
        Me.Activate()

        r = TorokuRY()

    End Sub
    Private Sub btnToroku2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToroku2.Click
        Dim r As Object
        r = TorokuRY()
    End Sub
    Private Function TorokuRY()

        Me.Hide()
        管制入力画面を前面に()
        管制日報入力画面取得()
        SendKeys.SendWait("%R")
        Sleep(300)
        SendKeys.SendWait("%Y")
        Me.Show()
        管制入力画面を前面に()
        TorokuRY = True

    End Function

    Private Sub RBCopy1_CheckedChanged(sender As Object, e As EventArgs) Handles RBCopy1.CheckedChanged

    End Sub
End Class



Public Class frm法定外実地教育
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

    Public MotoKinmu As New SyainKinmuJikan
    Public ShinKinmu As New SyainKinmuJikan
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
    Private Sub Button1_切り取り(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn切り取り.Click

        Dim KTime As New System.TimeSpan, STime As New System.TimeSpan, ZTime As New System.TimeSpan
        Dim KyuTime As New System.TimeSpan, ZeroTime As New System.TimeSpan
        Dim c As Object
        Me.Hide()
        管制入力画面を前面に()
        管制日報入力画面取得()

        '社員の勤務情報を取得して、残る勤務と教育の勤務時間を作成し、セットする。
        If MotoKinmu.GetSyainKinmuJikan() = False Then
            MessageBox.Show("管制日報入力画面で切り取りしてください")
            Me.Show()
            Exit Sub
        End If
        c = MotoKinmu
        MotoKinmu.Seikika()
        '社員の勤務情報
        ShinKinmu = MotoKinmu

        '後ろから勤務時間を抜いて、残る勤務を作る
        '教育時間を作成

        KTime = TimeSpan.FromHours(NUDJikan.Value)
        KTime = KTime + TimeSpan.FromMinutes(NUDFun.Value)


        '時間を取得して、再設定していく
        '下番時刻と終業時刻の設定
        STime = TimeSpan.Parse(MotoKinmu.Kaban)

        STime = STime - KTime
        MotoKinmu.Syugyou = CStr(Format(STime.Hours, "00") & ":" & Format(STime.Minutes, "00"))
        MotoKinmu.Kaban = CStr(Format(STime.Hours, "00") & ":" & Format(STime.Minutes, "00"))
        MotoKinmu.Seikika()
        '就業時間・勤務時間の設定

        STime = TimeSpan.Parse(MotoKinmu.HSyugyou & ":" & MotoKinmu.MSyugyou)
        STime = STime - KTime
        MotoKinmu.HSyugyou = STime.Hours
        MotoKinmu.MSyugyou = STime.Minutes
        MotoKinmu.HKinmu = STime.Hours
        MotoKinmu.MKinmu = STime.Minutes
        MotoKinmu.Seikika()

        '所定時間の調査
        STime = TimeSpan.FromHours(MotoKinmu.HSyotei)
        STime = STime + TimeSpan.FromMinutes(MotoKinmu.MSyotei)

        STime = STime - KTime
        '残業時間の調査
        ZTime = TimeSpan.FromHours(MotoKinmu.HZangyo)
        ZTime = ZTime + TimeSpan.FromMinutes(MotoKinmu.MZangyo)

        ZTime = ZTime - KTime
        '休出時間の調査
        KyuTime = TimeSpan.FromHours(MotoKinmu.HKyusyutsu)
        KyuTime = KyuTime + TimeSpan.FromMinutes(MotoKinmu.MKyusyutsu)

        KyuTime = KyuTime - KTime

        If MotoKinmu.HSyotei + MotoKinmu.MSyotei <> 0 Then
            MotoKinmu.HSyotei = STime.Hours
            MotoKinmu.MSyotei = STime.Minutes
            MotoKinmu.Seikika()
            '残される勤務時間の入力
            管制入力画面を前面に()
            管制日報入力画面取得()
            c = MotoKinmu
            If MotoKinmu.SetSyainKinmuJikan() = False Then
                MessageBox.Show("エラーが出ました。もう一度やり直してください")
                Exit Sub
            End If
            c = MotoKinmu
            '作られる勤務時間の設定
            ShinKinmu.Sigyou = MotoKinmu.Syugyou
            ShinKinmu.Jouban = MotoKinmu.Kaban
            ShinKinmu.HSyugyou = KTime.Hours
            ShinKinmu.MSyugyou = KTime.Minutes
            ShinKinmu.HKinmu = KTime.Hours
            ShinKinmu.MKinmu = KTime.Minutes
            ShinKinmu.HSyotei = KTime.Hours
            ShinKinmu.MSyotei = KTime.Minutes
            ShinKinmu.HZangyo = "00"
            ShinKinmu.MZangyo = "00"
            ShinKinmu.HKyusyutsu = "00"
            ShinKinmu.MKyusyutsu = "00"
            ShinKinmu.HShinya = "00"
            ShinKinmu.MShinya = "00"


        ElseIf MotoKinmu.HZangyo + MotoKinmu.MZangyo <> 0 Then
            MotoKinmu.HZangyo = ZTime.Hours
            MotoKinmu.MZangyo = ZTime.Minutes
            MotoKinmu.Seikika()
            '残される勤務時間の入力
            管制入力画面を前面に()
            管制日報入力画面取得()
            c = MotoKinmu
            If MotoKinmu.SetSyainKinmuJikan() = False Then
                MessageBox.Show("エラーが出ました。もう一度やり直してください")
                Exit Sub
            End If
            c = MotoKinmu
            '作られる勤務時間の設定
            ShinKinmu.Sigyou = MotoKinmu.Syugyou
            ShinKinmu.Jouban = MotoKinmu.Kaban
            ShinKinmu.HSyugyou = KTime.Hours
            ShinKinmu.MSyugyou = KTime.Minutes
            ShinKinmu.HKinmu = KTime.Hours
            ShinKinmu.MKinmu = KTime.Minutes
            ShinKinmu.HSyotei = "00"
            ShinKinmu.MSyotei = "00"
            ShinKinmu.HZangyo = KTime.Hours
            ShinKinmu.MZangyo = KTime.Minutes
            ShinKinmu.HKyusyutsu = "00"
            ShinKinmu.MKyusyutsu = "00"
            ShinKinmu.HShinya = "00"
            ShinKinmu.MShinya = "00"
        ElseIf MotoKinmu.HKyusyutsu + MotoKinmu.MKyusyutsu <> 0 Then
            MotoKinmu.HKyusyutsu = KyuTime.Hours
            MotoKinmu.MKyusyutsu = KyuTime.Minutes
            MotoKinmu.Seikika()
            '残される勤務時間の入力
            管制入力画面を前面に()
            管制日報入力画面取得()
            c = MotoKinmu
            If MotoKinmu.SetSyainKinmuJikan() = False Then
                MessageBox.Show("エラーが出ました。もう一度やり直してください")
                Exit Sub
            End If
            c = MotoKinmu
            '作られる勤務時間の設定
            ShinKinmu.Sigyou = MotoKinmu.Syugyou
            ShinKinmu.Jouban = MotoKinmu.Kaban
            ShinKinmu.HSyugyou = KTime.Hours
            ShinKinmu.MSyugyou = KTime.Minutes
            ShinKinmu.HKinmu = KTime.Hours
            ShinKinmu.MKinmu = KTime.Minutes
            ShinKinmu.HSyotei = "00"
            ShinKinmu.MSyotei = "00"
            ShinKinmu.HZangyo = "00"
            ShinKinmu.MZangyo = "00"
            ShinKinmu.HKyusyutsu = KTime.Hours
            ShinKinmu.MKyusyutsu = KTime.Minutes
            ShinKinmu.HShinya = "00"
            ShinKinmu.MShinya = "00"
        Else
            MessageBox.Show("実働時間より教育時間が多くないですか?")
            Me.Show()
            Exit Sub
        End If

        Label4.Text = "現在、" & vbCrLf & MotoKinmu.Simei & vbCrLf & "が切り取られています"
        btn貼り付け.Enabled = True
        Me.Show()
    End Sub
    Private Sub frm法定外実地教育_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form1.Show()
    End Sub
    Private Sub btn貼り付け_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn貼り付け.Click
        'ラジオボタンの項目を貼り付ける
        If RB_HouteigaiJittiKyouiku.Checked = True Then
            strKoumoku = RB_HouteigaiJittiKyouiku.Text
        ElseIf RB_JunsatsuSidouKeimu.Checked = True Then
            strKoumoku = RB_JunsatsuSidouKeimu.Text
        ElseIf RB_SisyatouKensyu.Checked = True Then
            strKoumoku = RB_SisyatouKensyu.Text
        ElseIf RB_SonotaKousyu.Checked = True Then
            strKoumoku = RB_SonotaKousyu.Text
        End If

        Me.Hide()
        管制入力画面を前面に()
        管制日報入力画面取得()

        クリック(KanseiKyukaX, KanseiKyukaY)

        If ShinKinmu.SetSyainKyouikuJikan(txtBikou.Text, strKoumoku) = False Then
            MessageBox.Show("教育・休暇タブに変更してから貼り付けしてください")
        End If

        Me.Show()
    End Sub
    Private Sub RB_HouteigaiJittiKyouiku_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_HouteigaiJittiKyouiku.CheckedChanged
        strKoumoku = RB_HouteigaiJittiKyouiku.Text
    End Sub
    Private Sub RB_SisyatouKensyu_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_SisyatouKensyu.CheckedChanged
        strKoumoku = RB_SisyatouKensyu.Text
    End Sub
    Private Sub RB_SonotaKousyu_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_SonotaKousyu.CheckedChanged
        strKoumoku = RB_SonotaKousyu.Text
    End Sub
    Private Sub RB_JunsatsuSidouKeimu_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_JunsatsuSidouKeimu.CheckedChanged
        strKoumoku = RB_JunsatsuSidouKeimu.Text
    End Sub
    Private Sub frm法定外実地教育_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        RB_HouteigaiJittiKyouiku.Checked = True
    End Sub
    Private Sub RB_KinmuNittei_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_KinmuNittei.CheckedChanged
        strKoumoku = RB_JunsatsuSidouKeimu.Text
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        frm入力.Show()
    End Sub
End Class
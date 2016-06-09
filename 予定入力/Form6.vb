﻿Public Class frmKanseiJidouNyuryoku
    Dim stcJidouListBox1 As New Collections.Specialized.StringCollection
    Dim stcJidouListBox2 As New Collections.Specialized.StringCollection
    Declare Sub Sleep Lib "kernel32" _
     (ByVal dwMilliseconds As Long)

    Public myKanseiKinmuJikan As New SyainKinmuJikan
 
    Dim strKoumoku As String

    Public Structure SyainKinmuJikan
        Dim Simei As String
        Dim SyainID As String
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
        Dim KeibiBukken As String
        Dim Keibitai As String
        Dim KinmuBango As String
        Dim Bikou As String


        Function GetSyainKinmuJikanFromCsv(ByVal LineOfCSV As String)
            Dim splitCSV() As String = Split(LineOfCSV, ",")
            Dim s As Object
            Try

                SyainID = Replace(splitCSV(0), "ID:", "")
                HSyotei = splitCSV(1)
                MSyotei = splitCSV(2)
                HZangyo = splitCSV(3)
                MZangyo = splitCSV(4)
                HShinya = splitCSV(5)
                MShinya = splitCSV(6)
                HKyusyutsu = splitCSV(7)
                MKyusyutsu = splitCSV(8)
                Sigyou = splitCSV(9)
                Syugyou = splitCSV(10)
                HSyugyou = splitCSV(11)
                MSyugyou = splitCSV(12)
                HKinmu = splitCSV(13)
                MKinmu = splitCSV(14)
                Jouban = splitCSV(15)
                Kaban = splitCSV(16)
                KinmuBango = splitCSV(19) - 1
                If splitCSV(18) Then
                    KeibiBukken = 0
                Else
                    KeibiBukken = 1
                End If

                Keibitai = ""

                Bikou = splitCSV(17)
                s = Seikika()
                GetSyainKinmuJikanFromCsv = True
            Catch ex As Exception
                GetSyainKinmuJikanFromCsv = False
            End Try
        End Function
        Private Function Seikika()

            Try

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
                If Len(Syugyou) = 4 Then Syugyou = "0" & Syugyou
                If Len(Sigyou) = 4 Then Sigyou = "0" & Sigyou
                If Len(Jouban) = 4 Then Jouban = "0" & Jouban
                If Len(Kaban) = 4 Then Kaban = "0" & Kaban
                Seikika = True
            Catch ex As Exception

                Seikika = False
            End Try


        End Function
        Function SetSyainKinmuJikan(Optional ByVal Bikou As String = "")

            Try
                社員番号から管制社員(SyainID)
                管制物件選択(KeibiBukken)
                管制勤務タブ勤務選択(KinmuBango)
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
        Function SetSyainKinmuJikan24(Optional ByVal Bikou As String = "")
            Try
                社員番号から管制社員(SyainID)
                管制物件選択(KeibiBukken)
                管制勤務タブ勤務選択(24)
                管制始業時刻(Sigyou)
                管制終業時刻(Syugyou)
                管制勤務就業時間(HSyugyou)
                管制勤務就業分(MSyugyou)
                管制上番時刻(Jouban)
                管制下番時刻(Kaban)
                管制勤務勤務時間(HKinmu)
                管制勤務勤務時間(HKinmu)
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

                SetSyainKinmuJikan24 = True
            Catch ex As Exception

                SetSyainKinmuJikan24 = False
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
            Dim s As Object
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
                    s = Seikika()

                ElseIf HZangyo + MZangyo <> 0 Then
                    HZangyo = Jitsudou.Hours
                    MZangyo = Jitsudou.Minutes
                    s = Seikika()

                ElseIf HKyusyutsu + MKyusyutsu <> 0 Then
                    HKyusyutsu = Jitsudou.Hours
                    MKyusyutsu = Jitsudou.Minutes

                End If

                AdjustTimeTable = True
            Catch ex As Exception
                MessageBox.Show("エラーが出たので、入力を中止しました")
                AdjustTimeTable = False
            End Try



        End Function
        Function SetSyainKyouikuJikan(ByVal Bikou As String, ByVal strKoumoku As String)

            Try


                社員番号から管制社員(SyainID)
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
                MessageBox.Show("エラーが出たので、入力を中止しました")
                SetSyainKyouikuJikan = False
            End Try
        End Function

    End Structure
    Private Sub frmKanseiJidouNyuryoku_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        fnc設定保存()
        Form1.Show()
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
                MessageBox.Show("「管制入力画面を前面に」でエラーが出たので、入力を中止しました")
            End Try
        Loop
    End Sub
    
    Private Sub btnToroku_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToroku.Click
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
    Private Function TuikaA()
        Me.Hide()

        管制入力画面を前面に()
        管制日報入力画面取得()
        管制追加ボタン()
        Me.Show()

        TuikaA = True
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn反映.Click

        Try
            管制入力画面を前面に()
            管制日報入力画面取得()
            myKanseiKinmuJikan.GetSyainKinmuJikanFromCsv(lst勤務リスト.SelectedItem)
            myKanseiKinmuJikan.SetSyainKinmuJikan()

            Me.lstKinmuZumi.Items.Add(Me.lst勤務リスト.SelectedItem)
            Me.lst勤務リスト.Items.Remove(Me.lst勤務リスト.SelectedItem)

        Catch ex As Exception
        End Try
    End Sub

    Private Sub lstファイルリスト_DragDrop(sender As Object, e As DragEventArgs) Handles lstファイルリスト.DragDrop
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


    Private Sub lstファイルリスト_DragEnter(sender As Object, e As DragEventArgs) Handles lstファイルリスト.DragEnter
        'DragEnterイベントで、FileDropタイプを受け入れられるかどうかを調べてEffect（copyで受け入れる）をセットする
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub


    Private Sub btncsv取込_Click(sender As Object, e As EventArgs) Handles btncsv取込.Click
        'CSV形式ファイルパスを設定してください。
        Dim csvfilepath As String
        'csvfilepath = GetAppPath()
        csvfilepath = Me.lstファイルリスト.Items(0)
        Dim objFile As New System.IO.StreamReader(csvfilepath _
        , System.Text.Encoding.GetEncoding(932))
        Dim strLine As String       '１行の配列を格納する変数
        Dim taibangou(2) As String


        'フォームの画面から、スリープする時間を持ってくる。

        Do
            '次の行へ
            strLine = objFile.ReadLine()

            If strLine = "" Then
                Exit Do
            End If

            lst勤務リスト.Items.Add(strLine)


        Loop

        'ファイルのクローズ
        objFile.Close()
    End Sub

    Private Sub btnリスト移動_Click(sender As Object, e As EventArgs) Handles btnリスト移動.Click
        Try
            Me.lst勤務リスト.Items.Add(Me.lstKinmuZumi.SelectedItem)
            Me.lstKinmuZumi.Items.Remove(Me.lstKinmuZumi.SelectedItem)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click


        Try
            管制入力画面を前面に()
            管制日報入力画面取得()
            myKanseiKinmuJikan.GetSyainKinmuJikanFromCsv(lst勤務リスト.SelectedItem)
            myKanseiKinmuJikan.SetSyainKinmuJikan()

            Me.lstKinmuZumi.Items.Add(Me.lst勤務リスト.SelectedItem)
            Me.lst勤務リスト.Items.Remove(Me.lst勤務リスト.SelectedItem)
            Sleep(300)
            TorokuRY()
            Sleep(300)
            TuikaA()
            Sleep(300)
            If Me.lst勤務リスト.Items.Count > 0 Then
                lst勤務リスト.SelectedIndex = 0
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnClr_Click(sender As Object, e As EventArgs) Handles btnClr.Click
        Me.lstKinmuZumi.Items.Clear()
    End Sub

    Private Function fnc設定保存()
        Dim c As Object

        Try

            '設定に保存
            stcJidouListBox1.Clear()
            stcJidouListBox2.Clear()

            For Each c In Me.lst勤務リスト.Items
                If Not c Is Nothing Then
                    stcJidouListBox1.Add(c.ToString)
                End If
            Next
            For Each c In Me.lstKinmuZumi.Items
                If Not c Is Nothing Then
                    stcJidouListBox2.Add(c.ToString)
                End If
            Next

            My.Settings.JidounyuryokuListBox1 = stcJidouListBox1
            My.Settings.JidounyuryokuListBox2 = stcJidouListBox2


            '設定に保存終わり
        Catch ex As Exception

            fnc設定保存 = False
        End Try

        fnc設定保存 = True
    End Function

    Private Function fnc設定反映()
        Dim c As Object

        Try
            '設定に保存


            For Each c In My.Settings.JidounyuryokuListBox1
                Me.lst勤務リスト.Items.Add(c.ToString)
            Next
            For Each c In My.Settings.JidounyuryokuListBox2
                Me.lstKinmuZumi.Items.Add(c.ToString)
            Next
            '設定に保存終わり


        Catch ex As Exception
            fnc設定反映 = False
        End Try

        fnc設定反映 = True
    End Function

    Private Sub frmKanseiJidouNyuryoku_Load(sender As Object, e As EventArgs) Handles Me.Load
        fnc設定反映()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        lst勤務リスト.Items.Clear()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            管制入力画面を前面に()
            管制日報入力画面取得()
            myKanseiKinmuJikan.GetSyainKinmuJikanFromCsv(lst勤務リスト.SelectedItem)
            myKanseiKinmuJikan.SetSyainKinmuJikan24()

            Me.lstKinmuZumi.Items.Add(Me.lst勤務リスト.SelectedItem)
            Me.lst勤務リスト.Items.Remove(Me.lst勤務リスト.SelectedItem)
            Sleep(300)
            TorokuRY()
            Sleep(300)
            TuikaA()
            Sleep(300)
            If Me.lst勤務リスト.Items.Count > 0 Then
                lst勤務リスト.SelectedIndex = 0
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
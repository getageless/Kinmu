Public Class frm打ち分け
    Dim 記録時間 As Double
    Dim 記録確定時間 As Double
    Dim stcListBox1 As New Collections.Specialized.StringCollection
    Dim stcListBox2 As New Collections.Specialized.StringCollection
    Sub 管制入力画面を前面に()
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

    Private Function fnc設定保存()
        Dim c As Object

        Try

            '設定に保存
            stcListBox1.Clear()
            stcListBox2.Clear()

            For Each c In Me.ListBox1.Items
                If Not c Is Nothing Then
                    stcListBox1.Add(c.ToString)
                End If
            Next
            For Each c In Me.ListBox2.Items
                If Not c Is Nothing Then
                    stcListBox2.Add(c.ToString)
                End If
            Next

            My.Settings.UchiwakeListBox1 = stcListBox1
            My.Settings.UchiwakeListBox2 = stcListBox2


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


            For Each c In My.Settings.UchiwakeListBox1
                Me.ListBox1.Items.Add(c.ToString)
            Next
            For Each c In My.Settings.UchiwakeListBox2
                Me.ListBox2.Items.Add(c.ToString)
            Next
            '設定に保存終わり


        Catch ex As Exception
            fnc設定反映 = False
        End Try

        fnc設定反映 = True
    End Function
    Private Sub btn記録_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn記録.Click
        Dim ListItem As String

        btn記録.Enabled = False

        管制入力画面を前面に()

        Try
            管制日報入力画面取得()
            ListItem = 取得管制日付() & ":" & 取得管制社員()
            ListItem = ListItem & ","
            'System.Threading.Thread.Sleep(Stoptime)
            管制入力画面を前面に()
            ListItem = ListItem & 取得管制始業時刻()
            ListItem = ListItem & ","
            'System.Threading.Thread.Sleep(Stoptime)
            ListItem = ListItem & 取得管制終業時刻()
            ListItem = ListItem & ","
            'System.Threading.Thread.Sleep(Stoptime)
            ListItem = ListItem & 取得管制勤務就業時間()
            ListItem = ListItem & ","
            'System.Threading.Thread.Sleep(Stoptime)
            ListItem = ListItem & 取得管制勤務就業分()
            ListItem = ListItem & ","
            'System.Threading.Thread.Sleep(Stoptime)
            ListItem = ListItem & 取得管制上番時刻()
            ListItem = ListItem & ","
            'System.Threading.Thread.Sleep(Stoptime)
            ListItem = ListItem & 取得管制下番時刻()
            ListItem = ListItem & ","
            'System.Threading.Thread.Sleep(Stoptime)
            ListItem = ListItem & 取得管制勤務勤務時間()
            ListItem = ListItem & ","
            'System.Threading.Thread.Sleep(Stoptime)
            ListItem = ListItem & 取得管制勤務勤務分()
            ListItem = ListItem & ","
            'System.Threading.Thread.Sleep(Stoptime)
            ListItem = ListItem & 取得管制勤務所定時間()
            ListItem = ListItem & ","
            'System.Threading.Thread.Sleep(Stoptime)
            ListItem = ListItem & 取得管制勤務所定分()
            ListItem = ListItem & ","
            'System.Threading.Thread.Sleep(Stoptime)
            ListItem = ListItem & 取得管制勤務残業時間()
            ListItem = ListItem & ","
            'System.Threading.Thread.Sleep(Stoptime)
            ListItem = ListItem & 取得管制勤務残業分()
            ListItem = ListItem & ","
            'System.Threading.Thread.Sleep(Stoptime)
            ListItem = ListItem & 取得管制勤務休出時間()
            ListItem = ListItem & ","
            'System.Threading.Thread.Sleep(Stoptime)
            ListItem = ListItem & 取得管制勤務休出分()
            ListItem = ListItem & ","
            'System.Threading.Thread.Sleep(Stoptime)
            ListItem = ListItem & 取得管制勤務深夜時間()
            ListItem = ListItem & ","
            'System.Threading.Thread.Sleep(Stoptime)
            ListItem = ListItem & 取得管制勤務深夜分()

            If Not 取得管制勤務所定時間() = "" Then
                記録時間 = 記録時間 + 取得管制勤務所定時間()
            End If
            'System.Threading.Thread.Sleep(Stoptime)
            If Not 取得管制勤務所定分() = "" Then
                記録時間 = 記録時間 + 取得管制勤務所定分() / 60
            End If
            If Not 取得管制勤務残業時間() = "" Then
                'System.Threading.Thread.Sleep(Stoptime)
                記録時間 = 記録時間 + 取得管制勤務残業時間()
            End If
            If Not 取得管制勤務残業分() = "" Then
                'System.Threading.Thread.Sleep(Stoptime)
                記録時間 = 記録時間 + 取得管制勤務残業分() / 60
            End If
            If Not 取得管制勤務休出時間() = "" Then
                'System.Threading.Thread.Sleep(Stoptime)
                記録時間 = 記録時間 + 取得管制勤務休出時間()
            End If
            If Not 取得管制勤務休出分() = "" Then
                'System.Threading.Thread.Sleep(Stoptime)
                記録時間 = 記録時間 + 取得管制勤務休出分() / 60
            End If


            Me.ListBox1.Items.Add(ListItem)
            Me.lbl記録時間累計.Text = "記録時間累計:" & 記録時間
        Catch ex As Exception

        End Try

        ListItem = ""
        fnc設定保存()
        リストボックス集計更新()
        btn記録.Enabled = True
    End Sub
    Private Sub frm打ち分け_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        記録時間 = 0
        記録確定時間 = 0
        fnc設定保存()
        Form1.Show()
    End Sub
    Private Sub frm打ち分け_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fnc設定反映()
        リストボックス集計更新()
    End Sub
    Private Sub btn反映_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn反映.Click
        Dim ListItem As Object
        Dim i As Long, j As Long
        Dim List1 As Object
        Dim 社員 As String, 日付 As String
        i = 0

        btn反映.Enabled = False

        管制日報入力画面取得()
        ListItem = Split(Me.ListBox1.SelectedItem, ",")

        For j = LBound(ListItem) To UBound(ListItem)
            If ListItem(j) = "" Then
                ListItem(j) = "0"
            End If
        Next


        Try

            List1 = Split(ListItem(i), ":")
            日付 = List1(0)
            社員 = List1(1)
            i = i + 1
            If Not 日付 = 取得管制日付() Then
                MessageBox.Show("日付が違うので中止します")
                Exit Sub
            End If


            If Not 管制社員(社員) = True Then

                MessageBox.Show("社員が見つからないので中止します。補勤登録がされているか確認して下さい。")
                Exit Sub
            End If

            If Not 管制物件選択(CLng(txt警備隊反映番号.Text)) = True Then

                MessageBox.Show("勤務番号が見つからないので中止します")
                Exit Sub
            End If


            管制勤務タブ勤務選択(CLng(txt勤務反映番号.Text))

            管制始業時刻(ListItem(i))
            i = i + 1
            'System.Threading.Thread.Sleep(Stoptime)
            管制終業時刻(ListItem(i))
            i = i + 1
            'System.Threading.Thread.Sleep(Stoptime)
            管制勤務就業時間(ListItem(i))
            i = i + 1
            'System.Threading.Thread.Sleep(Stoptime)
            管制勤務就業分(ListItem(i))
            i = i + 1
            'System.Threading.Thread.Sleep(Stoptime)
            管制上番時刻(ListItem(i))
            i = i + 1
            'System.Threading.Thread.Sleep(Stoptime)
            管制下番時刻(ListItem(i))
            i = i + 1
            'System.Threading.Thread.Sleep(Stoptime)
            管制勤務勤務時間(ListItem(i))
            i = i + 1
            'System.Threading.Thread.Sleep(Stoptime)
            管制勤務勤務分(ListItem(i))
            i = i + 1
            'System.Threading.Thread.Sleep(Stoptime)
            管制勤務所定時間(ListItem(i))
            記録確定時間 = 記録確定時間 + ListItem(i)
            i = i + 1
            'System.Threading.Thread.Sleep(Stoptime)
            管制勤務所定分(ListItem(i))
            記録確定時間 = 記録確定時間 + ListItem(i) / 60
            i = i + 1
            'System.Threading.Thread.Sleep(Stoptime)
            管制勤務残業時間(ListItem(i))
            記録確定時間 = 記録確定時間 + ListItem(i)
            i = i + 1
            'System.Threading.Thread.Sleep(Stoptime)
            管制勤務残業分(ListItem(i))
            記録確定時間 = 記録確定時間 + ListItem(i) / 60
            i = i + 1
            'System.Threading.Thread.Sleep(Stoptime)
            管制勤務休出時間(ListItem(i))
            記録確定時間 = 記録確定時間 + ListItem(i)
            i = i + 1
            'System.Threading.Thread.Sleep(Stoptime)
            管制勤務休出分(ListItem(i))
            記録確定時間 = 記録確定時間 + ListItem(i) / 60
            i = i + 1
            'System.Threading.Thread.Sleep(Stoptime)
            管制勤務深夜時間(ListItem(i))
            i = i + 1
            'System.Threading.Thread.Sleep(Stoptime)
            管制勤務深夜分(ListItem(i))
            i = i + 1
            'System.Threading.Thread.Sleep(Stoptime)
            管制入力画面を前面に()
            Me.ListBox2.Items.Add(Me.ListBox1.SelectedItem)
            Me.ListBox1.Items.Remove(Me.ListBox1.SelectedItem)
            Me.lbl記録確定時間累計.Text = "記録確定時間累計:" & 記録確定時間
        Catch ex As Exception


        End Try
        リストボックス集計更新()
        fnc設定保存()
        btn反映.Enabled = True
    End Sub
    Sub リストボックス集計更新()
        Dim ListItem As Object
        Dim i As Long, j As Long
        i = 1
        Dim c As Object

        記録時間 = 0
        'ListBox2の更新
        For Each c In Me.ListBox1.Items

            ListItem = Split(c, ",")

            For j = LBound(ListItem) To UBound(ListItem)
                If ListItem(j) = "" Then
                    ListItem(j) = "0"
                End If
            Next

            Try

                i = 9

                記録時間 = 記録時間 + ListItem(i)
                i = i + 1
                記録時間 = 記録時間 + ListItem(i) / 60
                i = i + 1
                記録時間 = 記録時間 + ListItem(i)
                i = i + 1
                記録時間 = 記録時間 + ListItem(i) / 60
                i = i + 1
                記録時間 = 記録時間 + ListItem(i)
                i = i + 1
                記録時間 = 記録時間 + ListItem(i) / 60
                i = i + 1




            Catch ex As Exception

            End Try
        Next c

        Me.lbl記録時間累計.Text = "記録時間累計:" & 記録時間

        記録確定時間 = 0
        'ListBox2の更新
        For Each c In Me.ListBox2.Items

            ListItem = Split(c, ",")

            For j = LBound(ListItem) To UBound(ListItem)
                If ListItem(j) = "" Then
                    ListItem(j) = "0"
                End If
            Next

            Try

                i = 9

                記録確定時間 = 記録確定時間 + ListItem(i)
                i = i + 1
                記録確定時間 = 記録確定時間 + ListItem(i) / 60
                i = i + 1
                記録確定時間 = 記録確定時間 + ListItem(i)
                i = i + 1
                記録確定時間 = 記録確定時間 + ListItem(i) / 60
                i = i + 1
                記録確定時間 = 記録確定時間 + ListItem(i)
                i = i + 1
                記録確定時間 = 記録確定時間 + ListItem(i) / 60
                i = i + 1




            Catch ex As Exception

            End Try
        Next c

        Me.lbl記録確定時間累計.Text = "記録確定時間累計:" & 記録確定時間
    End Sub
    Private Sub btnリスト移動_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnリスト移動.Click
        Try
            Me.ListBox1.Items.Add(Me.ListBox2.SelectedItem)
            Me.ListBox2.Items.Remove(Me.ListBox2.SelectedItem)
            リストボックス集計更新()
        Catch ex As Exception
        End Try
        fnc設定保存()
    End Sub
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click

        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        リストボックス集計更新()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub
End Class
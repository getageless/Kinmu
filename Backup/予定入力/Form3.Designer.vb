<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm打ち分け
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ListBox2 = New System.Windows.Forms.ListBox
        Me.btn反映 = New System.Windows.Forms.Button
        Me.btnリスト移動 = New System.Windows.Forms.Button
        Me.btn記録 = New System.Windows.Forms.Button
        Me.lbl記録時間累計 = New System.Windows.Forms.Label
        Me.lbl記録確定時間累計 = New System.Windows.Forms.Label
        Me.txt勤務反映番号 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt警備隊反映番号 = New System.Windows.Forms.TextBox
        Me.btnClear = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 11
        Me.ListBox1.Location = New System.Drawing.Point(5, 34)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(213, 48)
        Me.ListBox1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "記録"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 210)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "記録確定履歴"
        '
        'ListBox2
        '
        Me.ListBox2.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.ItemHeight = 11
        Me.ListBox2.Location = New System.Drawing.Point(5, 225)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(213, 48)
        Me.ListBox2.TabIndex = 2
        '
        'btn反映
        '
        Me.btn反映.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btn反映.Location = New System.Drawing.Point(117, 161)
        Me.btn反映.Name = "btn反映"
        Me.btn反映.Size = New System.Drawing.Size(101, 36)
        Me.btn反映.TabIndex = 4
        Me.btn反映.Text = "③反映↓"
        Me.btn反映.UseVisualStyleBackColor = False
        '
        'btnリスト移動
        '
        Me.btnリスト移動.Location = New System.Drawing.Point(5, 161)
        Me.btnリスト移動.Name = "btnリスト移動"
        Me.btnリスト移動.Size = New System.Drawing.Size(104, 36)
        Me.btnリスト移動.TabIndex = 5
        Me.btnリスト移動.Text = "リスト戻し↑"
        Me.btnリスト移動.UseVisualStyleBackColor = True
        '
        'btn記録
        '
        Me.btn記録.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btn記録.Location = New System.Drawing.Point(117, 3)
        Me.btn記録.Name = "btn記録"
        Me.btn記録.Size = New System.Drawing.Size(101, 25)
        Me.btn記録.TabIndex = 6
        Me.btn記録.Text = "①記録"
        Me.btn記録.UseVisualStyleBackColor = False
        '
        'lbl記録時間累計
        '
        Me.lbl記録時間累計.AutoSize = True
        Me.lbl記録時間累計.Location = New System.Drawing.Point(8, 89)
        Me.lbl記録時間累計.Name = "lbl記録時間累計"
        Me.lbl記録時間累計.Size = New System.Drawing.Size(77, 12)
        Me.lbl記録時間累計.TabIndex = 7
        Me.lbl記録時間累計.Text = "記録時間累計"
        '
        'lbl記録確定時間累計
        '
        Me.lbl記録確定時間累計.AutoSize = True
        Me.lbl記録確定時間累計.Location = New System.Drawing.Point(8, 283)
        Me.lbl記録確定時間累計.Name = "lbl記録確定時間累計"
        Me.lbl記録確定時間累計.Size = New System.Drawing.Size(101, 12)
        Me.lbl記録確定時間累計.TabIndex = 8
        Me.lbl記録確定時間累計.Text = "記録確定時間累計"
        '
        'txt勤務反映番号
        '
        Me.txt勤務反映番号.Location = New System.Drawing.Point(144, 330)
        Me.txt勤務反映番号.Name = "txt勤務反映番号"
        Me.txt勤務反映番号.Size = New System.Drawing.Size(54, 19)
        Me.txt勤務反映番号.TabIndex = 9
        Me.txt勤務反映番号.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 337)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 12)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "反映時勤務番号指定"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label4.Location = New System.Drawing.Point(10, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 12)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "②記録した勤務を削除します"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 364)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(125, 12)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "反映時警備隊番号指定"
        '
        'txt警備隊反映番号
        '
        Me.txt警備隊反映番号.Location = New System.Drawing.Point(144, 357)
        Me.txt警備隊反映番号.Name = "txt警備隊反映番号"
        Me.txt警備隊反映番号.Size = New System.Drawing.Size(54, 19)
        Me.txt警備隊反映番号.TabIndex = 12
        Me.txt警備隊反映番号.Text = "0"
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(13, 407)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(184, 32)
        Me.btnClear.TabIndex = 14
        Me.btnClear.Text = "リストの内容を消去"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'frm打ち分け
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(221, 489)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt警備隊反映番号)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt勤務反映番号)
        Me.Controls.Add(Me.lbl記録確定時間累計)
        Me.Controls.Add(Me.lbl記録時間累計)
        Me.Controls.Add(Me.btn記録)
        Me.Controls.Add(Me.btnリスト移動)
        Me.Controls.Add(Me.btn反映)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListBox1)
        Me.Name = "frm打ち分け"
        Me.Text = "打ち分け！"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents btn反映 As System.Windows.Forms.Button
    Friend WithEvents btnリスト移動 As System.Windows.Forms.Button
    Friend WithEvents btn記録 As System.Windows.Forms.Button
    Friend WithEvents lbl記録時間累計 As System.Windows.Forms.Label
    Friend WithEvents lbl記録確定時間累計 As System.Windows.Forms.Label
    Friend WithEvents txt勤務反映番号 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt警備隊反映番号 As System.Windows.Forms.TextBox
    Friend WithEvents btnClear As System.Windows.Forms.Button
End Class

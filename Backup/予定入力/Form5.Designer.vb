<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm入力
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.NUDJoubanJikan = New System.Windows.Forms.NumericUpDown
        Me.NUDJoubanFun = New System.Windows.Forms.NumericUpDown
        Me.txtBikou = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.NUDKabanJikan = New System.Windows.Forms.NumericUpDown
        Me.NUDKabanFun = New System.Windows.Forms.NumericUpDown
        Me.btnTanjunJouban = New System.Windows.Forms.Button
        Me.btnTableJouban = New System.Windows.Forms.Button
        Me.btnTableKaban = New System.Windows.Forms.Button
        Me.btnTanjunKaban = New System.Windows.Forms.Button
        Me.RB15fun = New System.Windows.Forms.RadioButton
        Me.RB5fun = New System.Windows.Forms.RadioButton
        Me.btnKousin = New System.Windows.Forms.Button
        Me.btnToroku = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.RBCopy1 = New System.Windows.Forms.RadioButton
        Me.RBCopy2 = New System.Windows.Forms.RadioButton
        Me.RBCopy3 = New System.Windows.Forms.RadioButton
        Me.btnJikanCopy = New System.Windows.Forms.Button
        Me.btnHaritsuke = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.RBCopy6 = New System.Windows.Forms.RadioButton
        Me.RBCopy5 = New System.Windows.Forms.RadioButton
        Me.RBCopy4 = New System.Windows.Forms.RadioButton
        Me.btnToroku2 = New System.Windows.Forms.Button
        CType(Me.NUDJoubanJikan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUDJoubanFun, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUDKabanJikan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUDKabanFun, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "上番"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(105, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 16)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "："
        '
        'NUDJoubanJikan
        '
        Me.NUDJoubanJikan.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.NUDJoubanJikan.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NUDJoubanJikan.Location = New System.Drawing.Point(57, 59)
        Me.NUDJoubanJikan.Maximum = New Decimal(New Integer() {23, 0, 0, 0})
        Me.NUDJoubanJikan.Name = "NUDJoubanJikan"
        Me.NUDJoubanJikan.Size = New System.Drawing.Size(42, 23)
        Me.NUDJoubanJikan.TabIndex = 12
        '
        'NUDJoubanFun
        '
        Me.NUDJoubanFun.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.NUDJoubanFun.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NUDJoubanFun.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NUDJoubanFun.Location = New System.Drawing.Point(127, 59)
        Me.NUDJoubanFun.Maximum = New Decimal(New Integer() {55, 0, 0, 0})
        Me.NUDJoubanFun.Name = "NUDJoubanFun"
        Me.NUDJoubanFun.Size = New System.Drawing.Size(43, 23)
        Me.NUDJoubanFun.TabIndex = 11
        '
        'txtBikou
        '
        Me.txtBikou.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtBikou.Location = New System.Drawing.Point(12, 283)
        Me.txtBikou.Name = "txtBikou"
        Me.txtBikou.Size = New System.Drawing.Size(167, 23)
        Me.txtBikou.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 264)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "備考"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 139)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "下番"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(108, 139)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(16, 16)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "："
        '
        'NUDKabanJikan
        '
        Me.NUDKabanJikan.BackColor = System.Drawing.SystemColors.Info
        Me.NUDKabanJikan.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NUDKabanJikan.Location = New System.Drawing.Point(60, 137)
        Me.NUDKabanJikan.Maximum = New Decimal(New Integer() {23, 0, 0, 0})
        Me.NUDKabanJikan.Name = "NUDKabanJikan"
        Me.NUDKabanJikan.Size = New System.Drawing.Size(42, 23)
        Me.NUDKabanJikan.TabIndex = 18
        '
        'NUDKabanFun
        '
        Me.NUDKabanFun.BackColor = System.Drawing.SystemColors.Info
        Me.NUDKabanFun.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NUDKabanFun.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NUDKabanFun.Location = New System.Drawing.Point(130, 137)
        Me.NUDKabanFun.Maximum = New Decimal(New Integer() {55, 0, 0, 0})
        Me.NUDKabanFun.Name = "NUDKabanFun"
        Me.NUDKabanFun.Size = New System.Drawing.Size(43, 23)
        Me.NUDKabanFun.TabIndex = 17
        '
        'btnTanjunJouban
        '
        Me.btnTanjunJouban.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.btnTanjunJouban.Location = New System.Drawing.Point(12, 88)
        Me.btnTanjunJouban.Name = "btnTanjunJouban"
        Me.btnTanjunJouban.Size = New System.Drawing.Size(79, 39)
        Me.btnTanjunJouban.TabIndex = 23
        Me.btnTanjunJouban.Text = "単純変更"
        Me.btnTanjunJouban.UseVisualStyleBackColor = False
        '
        'btnTableJouban
        '
        Me.btnTableJouban.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.btnTableJouban.Location = New System.Drawing.Point(94, 88)
        Me.btnTableJouban.Name = "btnTableJouban"
        Me.btnTableJouban.Size = New System.Drawing.Size(79, 39)
        Me.btnTableJouban.TabIndex = 24
        Me.btnTableJouban.Text = "タイムテーブルどおり"
        Me.btnTableJouban.UseVisualStyleBackColor = False
        '
        'btnTableKaban
        '
        Me.btnTableKaban.BackColor = System.Drawing.SystemColors.Info
        Me.btnTableKaban.Location = New System.Drawing.Point(94, 170)
        Me.btnTableKaban.Name = "btnTableKaban"
        Me.btnTableKaban.Size = New System.Drawing.Size(79, 39)
        Me.btnTableKaban.TabIndex = 26
        Me.btnTableKaban.Text = "タイムテーブルどおり"
        Me.btnTableKaban.UseVisualStyleBackColor = False
        '
        'btnTanjunKaban
        '
        Me.btnTanjunKaban.BackColor = System.Drawing.SystemColors.Info
        Me.btnTanjunKaban.Location = New System.Drawing.Point(12, 170)
        Me.btnTanjunKaban.Name = "btnTanjunKaban"
        Me.btnTanjunKaban.Size = New System.Drawing.Size(79, 39)
        Me.btnTanjunKaban.TabIndex = 25
        Me.btnTanjunKaban.Text = "単純変更"
        Me.btnTanjunKaban.UseVisualStyleBackColor = False
        '
        'RB15fun
        '
        Me.RB15fun.AutoSize = True
        Me.RB15fun.Location = New System.Drawing.Point(8, 11)
        Me.RB15fun.Name = "RB15fun"
        Me.RB15fun.Size = New System.Drawing.Size(71, 16)
        Me.RB15fun.TabIndex = 27
        Me.RB15fun.Text = "15分単位"
        Me.RB15fun.UseVisualStyleBackColor = True
        '
        'RB5fun
        '
        Me.RB5fun.AutoSize = True
        Me.RB5fun.Checked = True
        Me.RB5fun.Location = New System.Drawing.Point(8, 33)
        Me.RB5fun.Name = "RB5fun"
        Me.RB5fun.Size = New System.Drawing.Size(65, 16)
        Me.RB5fun.TabIndex = 28
        Me.RB5fun.TabStop = True
        Me.RB5fun.Text = "5分単位"
        Me.RB5fun.UseVisualStyleBackColor = True
        '
        'btnKousin
        '
        Me.btnKousin.Location = New System.Drawing.Point(99, 3)
        Me.btnKousin.Name = "btnKousin"
        Me.btnKousin.Size = New System.Drawing.Size(71, 39)
        Me.btnKousin.TabIndex = 29
        Me.btnKousin.Text = "時間取得"
        Me.btnKousin.UseVisualStyleBackColor = True
        '
        'btnToroku
        '
        Me.btnToroku.Location = New System.Drawing.Point(12, 215)
        Me.btnToroku.Name = "btnToroku"
        Me.btnToroku.Size = New System.Drawing.Size(164, 45)
        Me.btnToroku.TabIndex = 30
        Me.btnToroku.Text = "登録"
        Me.btnToroku.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(114, 312)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(65, 19)
        Me.Button1.TabIndex = 31
        Me.Button1.Text = "教育入力"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'RBCopy1
        '
        Me.RBCopy1.AutoSize = True
        Me.RBCopy1.Checked = True
        Me.RBCopy1.Location = New System.Drawing.Point(9, 13)
        Me.RBCopy1.Name = "RBCopy1"
        Me.RBCopy1.Size = New System.Drawing.Size(70, 16)
        Me.RBCopy1.TabIndex = 32
        Me.RBCopy1.TabStop = True
        Me.RBCopy1.Text = "データなし"
        Me.RBCopy1.UseVisualStyleBackColor = True
        '
        'RBCopy2
        '
        Me.RBCopy2.AutoSize = True
        Me.RBCopy2.Location = New System.Drawing.Point(9, 35)
        Me.RBCopy2.Name = "RBCopy2"
        Me.RBCopy2.Size = New System.Drawing.Size(70, 16)
        Me.RBCopy2.TabIndex = 33
        Me.RBCopy2.Text = "データなし"
        Me.RBCopy2.UseVisualStyleBackColor = True
        '
        'RBCopy3
        '
        Me.RBCopy3.AutoSize = True
        Me.RBCopy3.Location = New System.Drawing.Point(9, 57)
        Me.RBCopy3.Name = "RBCopy3"
        Me.RBCopy3.Size = New System.Drawing.Size(70, 16)
        Me.RBCopy3.TabIndex = 34
        Me.RBCopy3.Text = "データなし"
        Me.RBCopy3.UseVisualStyleBackColor = True
        '
        'btnJikanCopy
        '
        Me.btnJikanCopy.Location = New System.Drawing.Point(4, 478)
        Me.btnJikanCopy.Name = "btnJikanCopy"
        Me.btnJikanCopy.Size = New System.Drawing.Size(85, 30)
        Me.btnJikanCopy.TabIndex = 35
        Me.btnJikanCopy.Text = "時間コピー"
        Me.btnJikanCopy.UseVisualStyleBackColor = True
        '
        'btnHaritsuke
        '
        Me.btnHaritsuke.Location = New System.Drawing.Point(98, 478)
        Me.btnHaritsuke.Name = "btnHaritsuke"
        Me.btnHaritsuke.Size = New System.Drawing.Size(85, 30)
        Me.btnHaritsuke.TabIndex = 36
        Me.btnHaritsuke.Text = "時間貼付"
        Me.btnHaritsuke.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RB5fun)
        Me.GroupBox1.Controls.Add(Me.RB15fun)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(86, 50)
        Me.GroupBox1.TabIndex = 37
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "時間単位"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RBCopy6)
        Me.GroupBox2.Controls.Add(Me.RBCopy5)
        Me.GroupBox2.Controls.Add(Me.RBCopy4)
        Me.GroupBox2.Controls.Add(Me.RBCopy3)
        Me.GroupBox2.Controls.Add(Me.RBCopy2)
        Me.GroupBox2.Controls.Add(Me.RBCopy1)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 331)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(180, 141)
        Me.GroupBox2.TabIndex = 38
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "切り取りスロット"
        '
        'RBCopy6
        '
        Me.RBCopy6.AutoSize = True
        Me.RBCopy6.Location = New System.Drawing.Point(9, 122)
        Me.RBCopy6.Name = "RBCopy6"
        Me.RBCopy6.Size = New System.Drawing.Size(70, 16)
        Me.RBCopy6.TabIndex = 37
        Me.RBCopy6.Text = "データなし"
        Me.RBCopy6.UseVisualStyleBackColor = True
        '
        'RBCopy5
        '
        Me.RBCopy5.AutoSize = True
        Me.RBCopy5.Location = New System.Drawing.Point(9, 101)
        Me.RBCopy5.Name = "RBCopy5"
        Me.RBCopy5.Size = New System.Drawing.Size(70, 16)
        Me.RBCopy5.TabIndex = 36
        Me.RBCopy5.Text = "データなし"
        Me.RBCopy5.UseVisualStyleBackColor = True
        '
        'RBCopy4
        '
        Me.RBCopy4.AutoSize = True
        Me.RBCopy4.Location = New System.Drawing.Point(9, 79)
        Me.RBCopy4.Name = "RBCopy4"
        Me.RBCopy4.Size = New System.Drawing.Size(70, 16)
        Me.RBCopy4.TabIndex = 35
        Me.RBCopy4.Text = "データなし"
        Me.RBCopy4.UseVisualStyleBackColor = True
        '
        'btnToroku2
        '
        Me.btnToroku2.Location = New System.Drawing.Point(4, 514)
        Me.btnToroku2.Name = "btnToroku2"
        Me.btnToroku2.Size = New System.Drawing.Size(179, 27)
        Me.btnToroku2.TabIndex = 39
        Me.btnToroku2.Text = "登録"
        Me.btnToroku2.UseVisualStyleBackColor = True
        '
        'frm入力
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(185, 543)
        Me.Controls.Add(Me.btnToroku2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnHaritsuke)
        Me.Controls.Add(Me.btnJikanCopy)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnToroku)
        Me.Controls.Add(Me.btnKousin)
        Me.Controls.Add(Me.btnTableKaban)
        Me.Controls.Add(Me.btnTanjunKaban)
        Me.Controls.Add(Me.btnTableJouban)
        Me.Controls.Add(Me.btnTanjunJouban)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.NUDKabanJikan)
        Me.Controls.Add(Me.NUDKabanFun)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NUDJoubanJikan)
        Me.Controls.Add(Me.NUDJoubanFun)
        Me.Controls.Add(Me.txtBikou)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frm入力"
        Me.Text = "入力"
        Me.TopMost = True
        CType(Me.NUDJoubanJikan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUDJoubanFun, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUDKabanJikan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUDKabanFun, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NUDJoubanJikan As System.Windows.Forms.NumericUpDown
    Friend WithEvents NUDJoubanFun As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtBikou As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents NUDKabanJikan As System.Windows.Forms.NumericUpDown
    Friend WithEvents NUDKabanFun As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnTanjunJouban As System.Windows.Forms.Button
    Friend WithEvents btnTableJouban As System.Windows.Forms.Button
    Friend WithEvents btnTableKaban As System.Windows.Forms.Button
    Friend WithEvents btnTanjunKaban As System.Windows.Forms.Button
    Friend WithEvents RB15fun As System.Windows.Forms.RadioButton
    Friend WithEvents RB5fun As System.Windows.Forms.RadioButton
    Friend WithEvents btnKousin As System.Windows.Forms.Button
    Friend WithEvents btnToroku As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents RBCopy1 As System.Windows.Forms.RadioButton
    Friend WithEvents RBCopy2 As System.Windows.Forms.RadioButton
    Friend WithEvents RBCopy3 As System.Windows.Forms.RadioButton
    Friend WithEvents btnJikanCopy As System.Windows.Forms.Button
    Friend WithEvents btnHaritsuke As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RBCopy6 As System.Windows.Forms.RadioButton
    Friend WithEvents RBCopy5 As System.Windows.Forms.RadioButton
    Friend WithEvents RBCopy4 As System.Windows.Forms.RadioButton
    Friend WithEvents btnToroku2 As System.Windows.Forms.Button
End Class

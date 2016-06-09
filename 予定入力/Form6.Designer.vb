<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKanseiJidouNyuryoku
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnToroku = New System.Windows.Forms.Button()
        Me.btn反映 = New System.Windows.Forms.Button()
        Me.btncsv取込 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lstファイルリスト = New System.Windows.Forms.ListBox()
        Me.lst勤務リスト = New System.Windows.Forms.ListBox()
        Me.btnリスト移動 = New System.Windows.Forms.Button()
        Me.lstKinmuZumi = New System.Windows.Forms.ListBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnClr = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnToroku
        '
        Me.btnToroku.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnToroku.Location = New System.Drawing.Point(148, 215)
        Me.btnToroku.Name = "btnToroku"
        Me.btnToroku.Size = New System.Drawing.Size(78, 48)
        Me.btnToroku.TabIndex = 0
        Me.btnToroku.Text = "登録"
        Me.btnToroku.UseVisualStyleBackColor = True
        '
        'btn反映
        '
        Me.btn反映.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn反映.Location = New System.Drawing.Point(12, 212)
        Me.btn反映.Name = "btn反映"
        Me.btn反映.Size = New System.Drawing.Size(78, 51)
        Me.btn反映.TabIndex = 2
        Me.btn反映.Text = "反映"
        Me.btn反映.UseVisualStyleBackColor = True
        '
        'btncsv取込
        '
        Me.btncsv取込.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btncsv取込.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btncsv取込.Location = New System.Drawing.Point(118, 55)
        Me.btncsv取込.Name = "btncsv取込"
        Me.btncsv取込.Size = New System.Drawing.Size(104, 25)
        Me.btncsv取込.TabIndex = 9
        Me.btncsv取込.Text = "csv取込"
        Me.btncsv取込.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "記録"
        '
        'lstファイルリスト
        '
        Me.lstファイルリスト.AllowDrop = True
        Me.lstファイルリスト.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstファイルリスト.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lstファイルリスト.FormattingEnabled = True
        Me.lstファイルリスト.ItemHeight = 11
        Me.lstファイルリスト.Location = New System.Drawing.Point(12, 12)
        Me.lstファイルリスト.Name = "lstファイルリスト"
        Me.lstファイルリスト.Size = New System.Drawing.Size(218, 37)
        Me.lstファイルリスト.TabIndex = 7
        '
        'lst勤務リスト
        '
        Me.lst勤務リスト.AllowDrop = True
        Me.lst勤務リスト.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lst勤務リスト.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lst勤務リスト.FormattingEnabled = True
        Me.lst勤務リスト.ItemHeight = 11
        Me.lst勤務リスト.Location = New System.Drawing.Point(12, 103)
        Me.lst勤務リスト.Name = "lst勤務リスト"
        Me.lst勤務リスト.Size = New System.Drawing.Size(218, 103)
        Me.lst勤務リスト.TabIndex = 10
        '
        'btnリスト移動
        '
        Me.btnリスト移動.Location = New System.Drawing.Point(12, 283)
        Me.btnリスト移動.Name = "btnリスト移動"
        Me.btnリスト移動.Size = New System.Drawing.Size(77, 51)
        Me.btnリスト移動.TabIndex = 11
        Me.btnリスト移動.Text = "リスト戻し↑"
        Me.btnリスト移動.UseVisualStyleBackColor = True
        '
        'lstKinmuZumi
        '
        Me.lstKinmuZumi.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lstKinmuZumi.FormattingEnabled = True
        Me.lstKinmuZumi.ItemHeight = 11
        Me.lstKinmuZumi.Location = New System.Drawing.Point(12, 340)
        Me.lstKinmuZumi.Name = "lstKinmuZumi"
        Me.lstKinmuZumi.Size = New System.Drawing.Size(257, 103)
        Me.lstKinmuZumi.TabIndex = 12
        '
        'Button1
        '
        Me.Button1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(95, 286)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(78, 48)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "反映登録選択追加"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnClr
        '
        Me.btnClr.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClr.Location = New System.Drawing.Point(275, 385)
        Me.btnClr.Name = "btnClr"
        Me.btnClr.Size = New System.Drawing.Size(0, 48)
        Me.btnClr.TabIndex = 14
        Me.btnClr.Text = "Clr"
        Me.btnClr.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(275, 158)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(0, 48)
        Me.Button2.TabIndex = 15
        Me.Button2.Text = "Clr"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Location = New System.Drawing.Point(179, 283)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(78, 48)
        Me.Button3.TabIndex = 16
        Me.Button3.Text = "反映登録選択追加24"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'frmKanseiJidouNyuryoku
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(268, 445)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnClr)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lstKinmuZumi)
        Me.Controls.Add(Me.btnリスト移動)
        Me.Controls.Add(Me.lst勤務リスト)
        Me.Controls.Add(Me.btncsv取込)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lstファイルリスト)
        Me.Controls.Add(Me.btn反映)
        Me.Controls.Add(Me.btnToroku)
        Me.Name = "frmKanseiJidouNyuryoku"
        Me.Text = "管制日報自動入力"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnToroku As System.Windows.Forms.Button
    Friend WithEvents btn反映 As System.Windows.Forms.Button
    Friend WithEvents btncsv取込 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lstファイルリスト As System.Windows.Forms.ListBox
    Friend WithEvents lst勤務リスト As System.Windows.Forms.ListBox
    Friend WithEvents btnリスト移動 As System.Windows.Forms.Button
    Friend WithEvents lstKinmuZumi As System.Windows.Forms.ListBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnClr As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm法定外実地教育
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
        Me.btn切り取り = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtBikou = New System.Windows.Forms.TextBox
        Me.NUDFun = New System.Windows.Forms.NumericUpDown
        Me.NUDJikan = New System.Windows.Forms.NumericUpDown
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btn貼り付け = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.RB_HouteigaiJittiKyouiku = New System.Windows.Forms.RadioButton
        Me.RB_SisyatouKensyu = New System.Windows.Forms.RadioButton
        Me.RB_SonotaKousyu = New System.Windows.Forms.RadioButton
        Me.RB_JunsatsuSidouKeimu = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RB_KinmuNittei = New System.Windows.Forms.RadioButton
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.NUDFun, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUDJikan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn切り取り
        '
        Me.btn切り取り.BackColor = System.Drawing.SystemColors.Info
        Me.btn切り取り.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn切り取り.Location = New System.Drawing.Point(15, 203)
        Me.btn切り取り.Name = "btn切り取り"
        Me.btn切り取り.Size = New System.Drawing.Size(156, 30)
        Me.btn切り取り.TabIndex = 0
        Me.btn切り取り.Text = "切り取り！&C"
        Me.btn切り取り.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 174)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "備考"
        '
        'txtBikou
        '
        Me.txtBikou.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtBikou.Location = New System.Drawing.Point(58, 174)
        Me.txtBikou.Name = "txtBikou"
        Me.txtBikou.Size = New System.Drawing.Size(113, 23)
        Me.txtBikou.TabIndex = 2
        '
        'NUDFun
        '
        Me.NUDFun.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NUDFun.Increment = New Decimal(New Integer() {15, 0, 0, 0})
        Me.NUDFun.Location = New System.Drawing.Point(128, 139)
        Me.NUDFun.Name = "NUDFun"
        Me.NUDFun.Size = New System.Drawing.Size(43, 23)
        Me.NUDFun.TabIndex = 5
        '
        'NUDJikan
        '
        Me.NUDJikan.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NUDJikan.Location = New System.Drawing.Point(58, 139)
        Me.NUDJikan.Name = "NUDJikan"
        Me.NUDJikan.Size = New System.Drawing.Size(42, 23)
        Me.NUDJikan.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(106, 141)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 16)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 141)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "時間"
        '
        'btn貼り付け
        '
        Me.btn貼り付け.BackColor = System.Drawing.SystemColors.Info
        Me.btn貼り付け.Enabled = False
        Me.btn貼り付け.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn貼り付け.Location = New System.Drawing.Point(15, 308)
        Me.btn貼り付け.Name = "btn貼り付け"
        Me.btn貼り付け.Size = New System.Drawing.Size(156, 30)
        Me.btn貼り付け.TabIndex = 9
        Me.btn貼り付け.Text = "貼り付け！&V"
        Me.btn貼り付け.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 236)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 12)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "誰も切り取られてません"
        '
        'RB_HouteigaiJittiKyouiku
        '
        Me.RB_HouteigaiJittiKyouiku.AutoSize = True
        Me.RB_HouteigaiJittiKyouiku.Checked = True
        Me.RB_HouteigaiJittiKyouiku.Location = New System.Drawing.Point(4, 18)
        Me.RB_HouteigaiJittiKyouiku.Name = "RB_HouteigaiJittiKyouiku"
        Me.RB_HouteigaiJittiKyouiku.Size = New System.Drawing.Size(127, 16)
        Me.RB_HouteigaiJittiKyouiku.TabIndex = 11
        Me.RB_HouteigaiJittiKyouiku.TabStop = True
        Me.RB_HouteigaiJittiKyouiku.Text = " 11 法定外実地教育"
        Me.RB_HouteigaiJittiKyouiku.UseVisualStyleBackColor = True
        '
        'RB_SisyatouKensyu
        '
        Me.RB_SisyatouKensyu.AutoSize = True
        Me.RB_SisyatouKensyu.Location = New System.Drawing.Point(4, 40)
        Me.RB_SisyatouKensyu.Name = "RB_SisyatouKensyu"
        Me.RB_SisyatouKensyu.Size = New System.Drawing.Size(103, 16)
        Me.RB_SisyatouKensyu.TabIndex = 12
        Me.RB_SisyatouKensyu.Text = " 32 支社等研修"
        Me.RB_SisyatouKensyu.UseVisualStyleBackColor = True
        '
        'RB_SonotaKousyu
        '
        Me.RB_SonotaKousyu.AutoSize = True
        Me.RB_SonotaKousyu.Location = New System.Drawing.Point(4, 62)
        Me.RB_SonotaKousyu.Name = "RB_SonotaKousyu"
        Me.RB_SonotaKousyu.Size = New System.Drawing.Size(98, 16)
        Me.RB_SonotaKousyu.TabIndex = 13
        Me.RB_SonotaKousyu.Text = " 49 その他講習"
        Me.RB_SonotaKousyu.UseVisualStyleBackColor = True
        '
        'RB_JunsatsuSidouKeimu
        '
        Me.RB_JunsatsuSidouKeimu.AutoSize = True
        Me.RB_JunsatsuSidouKeimu.Location = New System.Drawing.Point(4, 84)
        Me.RB_JunsatsuSidouKeimu.Name = "RB_JunsatsuSidouKeimu"
        Me.RB_JunsatsuSidouKeimu.Size = New System.Drawing.Size(163, 16)
        Me.RB_JunsatsuSidouKeimu.TabIndex = 14
        Me.RB_JunsatsuSidouKeimu.Text = " 72 巡察指導監督（警務職）"
        Me.RB_JunsatsuSidouKeimu.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RB_KinmuNittei)
        Me.GroupBox1.Controls.Add(Me.RB_SisyatouKensyu)
        Me.GroupBox1.Controls.Add(Me.RB_JunsatsuSidouKeimu)
        Me.GroupBox1.Controls.Add(Me.RB_HouteigaiJittiKyouiku)
        Me.GroupBox1.Controls.Add(Me.RB_SonotaKousyu)
        Me.GroupBox1.Location = New System.Drawing.Point(1, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(170, 130)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "項目"
        '
        'RB_KinmuNittei
        '
        Me.RB_KinmuNittei.AutoSize = True
        Me.RB_KinmuNittei.Location = New System.Drawing.Point(4, 106)
        Me.RB_KinmuNittei.Name = "RB_KinmuNittei"
        Me.RB_KinmuNittei.Size = New System.Drawing.Size(127, 16)
        Me.RB_KinmuNittei.TabIndex = 15
        Me.RB_KinmuNittei.Text = " 95 勤務日程表作成"
        Me.RB_KinmuNittei.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(129, 344)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(39, 36)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = "入力へ"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frm法定外実地教育
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(175, 392)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btn貼り付け)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NUDJikan)
        Me.Controls.Add(Me.NUDFun)
        Me.Controls.Add(Me.txtBikou)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn切り取り)
        Me.Name = "frm法定外実地教育"
        Me.Text = "法定外実地教育"
        Me.TopMost = True
        CType(Me.NUDFun, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUDJikan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn切り取り As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBikou As System.Windows.Forms.TextBox
    Friend WithEvents NUDFun As System.Windows.Forms.NumericUpDown
    Friend WithEvents NUDJikan As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn貼り付け As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents RB_HouteigaiJittiKyouiku As System.Windows.Forms.RadioButton
    Friend WithEvents RB_SisyatouKensyu As System.Windows.Forms.RadioButton
    Friend WithEvents RB_SonotaKousyu As System.Windows.Forms.RadioButton
    Friend WithEvents RB_JunsatsuSidouKeimu As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RB_KinmuNittei As System.Windows.Forms.RadioButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class

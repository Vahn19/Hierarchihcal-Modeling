<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Screen_PctrBx = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Rotational_ScrollBar = New System.Windows.Forms.HScrollBar()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Rotation_ScrollBar = New System.Windows.Forms.HScrollBar()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Backward_Button = New System.Windows.Forms.Button()
        Me.Forward_Button = New System.Windows.Forms.Button()
        Me.Right_Button = New System.Windows.Forms.Button()
        Me.Left_button = New System.Windows.Forms.Button()
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Reset_Button = New System.Windows.Forms.Button()
        CType(Me.Screen_PctrBx, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Screen_PctrBx
        '
        Me.Screen_PctrBx.BackColor = System.Drawing.Color.White
        Me.Screen_PctrBx.Location = New System.Drawing.Point(12, 12)
        Me.Screen_PctrBx.Name = "Screen_PctrBx"
        Me.Screen_PctrBx.Size = New System.Drawing.Size(880, 650)
        Me.Screen_PctrBx.TabIndex = 0
        Me.Screen_PctrBx.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Rotational_ScrollBar)
        Me.GroupBox1.Controls.Add(Me.RadioButton5)
        Me.GroupBox1.Controls.Add(Me.CheckBox2)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.RadioButton4)
        Me.GroupBox1.Controls.Add(Me.RadioButton3)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Controls.Add(Me.Rotation_ScrollBar)
        Me.GroupBox1.Location = New System.Drawing.Point(931, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(361, 250)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Head"
        '
        'Rotational_ScrollBar
        '
        Me.Rotational_ScrollBar.Location = New System.Drawing.Point(38, 179)
        Me.Rotational_ScrollBar.Maximum = 180
        Me.Rotational_ScrollBar.Minimum = -180
        Me.Rotational_ScrollBar.Name = "Rotational_ScrollBar"
        Me.Rotational_ScrollBar.Size = New System.Drawing.Size(283, 21)
        Me.Rotational_ScrollBar.TabIndex = 9
        Me.Rotational_ScrollBar.Visible = False
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.Location = New System.Drawing.Point(38, 140)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(73, 21)
        Me.RadioButton5.TabIndex = 8
        Me.RadioButton5.TabStop = True
        Me.RadioButton5.Text = "Bottom"
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(219, 86)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(83, 21)
        Me.CheckBox2.TabIndex = 7
        Me.CheckBox2.Text = "Left Arm"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(219, 60)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(92, 21)
        Me.CheckBox1.TabIndex = 6
        Me.CheckBox1.Text = "Right Arm"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Location = New System.Drawing.Point(38, 113)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(58, 21)
        Me.RadioButton4.TabIndex = 5
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "Claw"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(38, 86)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(96, 21)
        Me.RadioButton3.TabIndex = 4
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "Lower Arm"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(38, 59)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(97, 21)
        Me.RadioButton2.TabIndex = 3
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Upper Arm"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(38, 32)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(63, 21)
        Me.RadioButton1.TabIndex = 2
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Head"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Rotation_ScrollBar
        '
        Me.Rotation_ScrollBar.Location = New System.Drawing.Point(38, 209)
        Me.Rotation_ScrollBar.Maximum = 90
        Me.Rotation_ScrollBar.Minimum = -90
        Me.Rotation_ScrollBar.Name = "Rotation_ScrollBar"
        Me.Rotation_ScrollBar.Size = New System.Drawing.Size(281, 21)
        Me.Rotation_ScrollBar.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.Backward_Button)
        Me.GroupBox2.Controls.Add(Me.Forward_Button)
        Me.GroupBox2.Controls.Add(Me.Right_Button)
        Me.GroupBox2.Controls.Add(Me.Left_button)
        Me.GroupBox2.Location = New System.Drawing.Point(931, 294)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(361, 133)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Robot Movement"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Info
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Cursor = System.Windows.Forms.Cursors.Help
        Me.TextBox1.Location = New System.Drawing.Point(326, 21)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(19, 15)
        Me.TextBox1.TabIndex = 3
        Me.TextBox1.Text = "?"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.TextBox1, "You can also use Arrow Keys on your keyboard!")
        '
        'Backward_Button
        '
        Me.Backward_Button.Location = New System.Drawing.Point(137, 74)
        Me.Backward_Button.Name = "Backward_Button"
        Me.Backward_Button.Size = New System.Drawing.Size(89, 38)
        Me.Backward_Button.TabIndex = 3
        Me.Backward_Button.Text = "Backward"
        Me.Backward_Button.UseVisualStyleBackColor = True
        '
        'Forward_Button
        '
        Me.Forward_Button.Location = New System.Drawing.Point(137, 21)
        Me.Forward_Button.Name = "Forward_Button"
        Me.Forward_Button.Size = New System.Drawing.Size(89, 38)
        Me.Forward_Button.TabIndex = 2
        Me.Forward_Button.Text = "Forward"
        Me.Forward_Button.UseVisualStyleBackColor = True
        '
        'Right_Button
        '
        Me.Right_Button.Location = New System.Drawing.Point(232, 74)
        Me.Right_Button.Name = "Right_Button"
        Me.Right_Button.Size = New System.Drawing.Size(89, 38)
        Me.Right_Button.TabIndex = 1
        Me.Right_Button.Text = "Right"
        Me.Right_Button.UseVisualStyleBackColor = True
        '
        'Left_button
        '
        Me.Left_button.Location = New System.Drawing.Point(42, 74)
        Me.Left_button.Name = "Left_button"
        Me.Left_button.Size = New System.Drawing.Size(89, 38)
        Me.Left_button.TabIndex = 0
        Me.Left_button.Text = "Left"
        Me.Left_button.UseVisualStyleBackColor = True
        '
        'Timer
        '
        Me.Timer.Interval = 50
        '
        'Reset_Button
        '
        Me.Reset_Button.Location = New System.Drawing.Point(931, 623)
        Me.Reset_Button.Name = "Reset_Button"
        Me.Reset_Button.Size = New System.Drawing.Size(96, 45)
        Me.Reset_Button.TabIndex = 4
        Me.Reset_Button.Text = "Reset"
        Me.Reset_Button.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1328, 703)
        Me.Controls.Add(Me.Reset_Button)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Screen_PctrBx)
        Me.Name = "Form1"
        Me.Text = "Robot (Karen)"
        CType(Me.Screen_PctrBx, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Screen_PctrBx As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Rotation_ScrollBar As HScrollBar
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Right_Button As Button
    Friend WithEvents Left_button As Button
    Friend WithEvents Timer As Timer
    Friend WithEvents Backward_Button As Button
    Friend WithEvents Forward_Button As Button
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents RadioButton4 As RadioButton
    Friend WithEvents RadioButton5 As RadioButton
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Reset_Button As Button
    Friend WithEvents Rotational_ScrollBar As HScrollBar
End Class

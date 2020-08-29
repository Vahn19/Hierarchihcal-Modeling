Public Class Form1

    Dim Bmp As Bitmap
    Dim Graphic As Graphics

    Dim Degree As Integer = 0
    Dim Head_Degree, RUpperArm_Degree, RLowerArm_Degree, LUpperArm_Degree, LLowerArm_Degree, RClaw_Degree, LClaw_Degree, BottomLegs_Degree As Integer
    Dim Move_Right, Move_Left, Move_Forward, Move_Backward As Boolean

    Dim Hierarchy_stack As New Stack

    Dim Vt(3, 3), Perspective(3, 3), St(3, 3) As Double

    Dim World As New ObjectsProjection
    Dim Head, Spine, Rotor, BottomLegs,
           RUpperArm, RLowerArm, RClaw1, RClaw2,
           LUpperArm, LLowerArm, LClaw1, LClaw2 As ObjectsProjection

    Dim Calculation As Matrix = New Matrix

    Dim MovingX As Integer

    Dim IsMoving As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Bmp = New Bitmap(Screen_PctrBx.Width, Screen_PctrBx.Height)
        Graphic = Graphics.FromImage(Bmp)
        Graphic.Clear(Color.White)

        InitValue()
        InitRobots()

        Start_Draw()
    End Sub

    Sub Start_Draw()
        Graphic.Clear(Color.White)

        Dim Matrix(3, 3) As Double
        Matrix = Calculation.MatrixMatrix(Vt, Perspective)

        Hierarchy_stack.Push(Matrix)

        Draw(World)
    End Sub

    Sub Draw(robot As ObjectsProjection)
        Dim Matrix(3, 3) As Double

        While Not IsNothing(robot)
            Matrix = Calculation.MatrixMatrix(robot.Matrices, Hierarchy_stack.Peek())
            Hierarchy_stack.Push(Matrix)

            Draw(robot.Child)

            If Not IsNothing(robot.Objects) Then
                Dim V(,) As Double

                V = Hierarchy_stack.Pop()

                Dim ver(7) As Vertex
                Dim P1, P2 As Point

                For i = 0 To ver.Length - 1
                    ver(i) = Calculation.PointMatrix(robot.Objects.vertices(i), V)
                    ver(i) = Calculation.PointMatrix(ver(i), St)
                Next

                For i = 0 To 11
                    P1.X = ver(robot.Objects.edges(i).P1).x / ver(robot.Objects.edges(i).P1).w
                    P1.Y = ver(robot.Objects.edges(i).P1).y / ver(robot.Objects.edges(i).P1).w
                    P2.X = ver(robot.Objects.edges(i).P2).x / ver(robot.Objects.edges(i).P2).w
                    P2.Y = ver(robot.Objects.edges(i).P2).y / ver(robot.Objects.edges(i).P2).w

                    If i <= 3 Then
                        Graphic.DrawLine(Pens.Red, P1, P2)
                    Else
                        Graphic.DrawLine(Pens.Black, P1, P2)
                    End If
                Next
            Else
                Hierarchy_stack.Pop()
            End If
            robot = robot.NextSibling
        End While
        Screen_PctrBx.Image = Bmp
    End Sub

    Sub InitRobots()

        World = New ObjectsProjection
        World.Create(0, 0, 0)

        Spine = New ObjectsProjection
        Spine.Create(0, -3, 0)
        Spine.Objects = New Objects(-0.2, -2, -0.2, 0.2, 2, 0.2)
        World.Child = Spine

        Head = New ObjectsProjection
        Head.Create(0, 0, 0)
        Head.Objects = New Objects(-1, -1, -1, 1, 1, 1)
        Spine.NextSibling = Head

        BottomLegs = New ObjectsProjection
        BottomLegs.Create(0, -5, 0.2)
        BottomLegs.Objects = New Objects(-0.8, -0.3, 0.8,
                                         0.8, -0.3, 0.8,
                                         0.8, 0.2, 0.6,
                                         -0.8, 0.2, 0.6,
                                         -0.8, -0.3, -0.8,
                                         0.8, -0.3, -0.8,
                                         0.8, 0.2, -0.8,
                                         -0.8, 0.2, -0.8)
        Head.NextSibling = BottomLegs

        Rotor = New ObjectsProjection
        Rotor.Create(0, 1, 0)
        Rotor.Objects = New Objects(-0.3, -0.2, -0.2, 0.3, 0.2, 0.2)
        Spine.Child = Rotor

        RUpperArm = New ObjectsProjection
        RUpperArm.Create(-0.3, 0, 0)
        RUpperArm.Objects = New Objects(-1.4, -0.1, -0.1, 0, 0.1, 0.1)
        Rotor.Child = RUpperArm

        RLowerArm = New ObjectsProjection
        RLowerArm.Create(-1.35, 0, 0)
        RLowerArm.Objects = New Objects(-1.4, -0.1, -0.1, 0, 0.1, 0.1)
        RLowerArm.Rotate(90, "y")
        RUpperArm.Child = RLowerArm

        RClaw1 = New ObjectsProjection
        RClaw1.Create(-1.4, 0, -0.1)
        RClaw1.Objects = New Objects(-0.2, -0.05, 0.4,
                                      0.2, -0.05, 0.4,
                                      0.2, 0.1, 0.3,
                                     -0.2, 0.1, 0.3,
                                     -0.2, -0.05, 0,
                                      0.2, -0.05, 0,
                                      0.2, 0.1, 0,
                                     -0.2, 0.1, 0)
        RClaw1.Rotate(-90, "x")
        RClaw1.Rotate(-90, "y")
        RLowerArm.Child = RClaw1

        RClaw2 = New ObjectsProjection
        RClaw2.Create(-1.4, 0, 0.15)
        RClaw2.Objects = New Objects(-0.2, -0.05, 0.4,
                                      0.2, -0.05, 0.4,
                                      0.2, 0.1, 0.3,
                                     -0.2, 0.1, 0.3,
                                     -0.2, -0.05, 0,
                                      0.2, -0.05, 0,
                                      0.2, 0.1, 0,
                                     -0.2, 0.1, 0)
        RClaw2.Rotate(-90, "x")
        RClaw2.Rotate(-90, "y")
        RClaw2.Rotate(180, "z")
        RClaw1.NextSibling = RClaw2

        LUpperArm = New ObjectsProjection
        LUpperArm.Create(0.3, 0, 0)
        LUpperArm.Objects = New Objects(0, -0.1, -0.1, 1.4, 0.1, 0.1)
        RUpperArm.NextSibling = LUpperArm

        LLowerArm = New ObjectsProjection
        LLowerArm.Create(1.35, 0, 0)
        LLowerArm.Objects = New Objects(0, -0.1, -0.1, 1.4, 0.1, 0.1)
        LLowerArm.Rotate(-90, "y")
        LUpperArm.Child = LLowerArm

        LClaw1 = New ObjectsProjection
        LClaw1.Create(1.4, 0, 0.1)
        LClaw1.Objects = New Objects(-0.2, -0.05, 0.4,
                                      0.2, -0.05, 0.4,
                                      0.2, 0.1, 0.3,
                                     -0.2, 0.1, 0.3,
                                     -0.2, -0.05, 0,
                                      0.2, -0.05, 0,
                                      0.2, 0.1, 0,
                                     -0.2, 0.1, 0)
        LClaw1.Rotate(90, "y")
        LClaw1.Rotate(90, "z")
        LLowerArm.Child = LClaw1

        LClaw2 = New ObjectsProjection
        LClaw2.Create(1.4, 0, -0.15)
        LClaw2.Objects = New Objects(-0.2, -0.05, 0.4,
                                      0.2, -0.05, 0.4,
                                      0.2, 0.1, 0.3,
                                     -0.2, 0.1, 0.3,
                                     -0.2, -0.05, 0,
                                      0.2, -0.05, 0,
                                      0.2, 0.1, 0,
                                     -0.2, 0.1, 0)
        LClaw2.Rotate(90, "y")
        LClaw2.Rotate(-90, "z")
        LClaw1.NextSibling = LClaw2

    End Sub

    Sub InitValue()
        Dim Vt1(3, 3), Vt2(3, 3), St1(3, 3), St2(3, 3) As Double

        Vt1 = New Double(3, 3) {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 1, -0.25},
            {0, 0, 0, 1}
        }

        Vt2 = New Double(3, 3) {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 0, 0},
            {0, 0, 0, 1}
        }

        Perspective = Calculation.MatrixMatrix(Vt1, Vt2)

        St1 = New Double(3, 3) {
            {30, 0, 0, 0},
            {0, -30, 0, 0},
            {0, 0, 0, 0},
            {0, 0, 0, 1}
        }

        St2 = New Double(3, 3) {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 1, 0},
            {300, 200, 0, 1}
        }

        St = Calculation.MatrixMatrix(St1, St2)

        Vt = New Double(3, 3) {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 1, 0},
            {0, 0, 0, 1}
        }
    End Sub

    Private Sub Rotation_ScrollBar_ValueChanged(sender As Object, e As EventArgs) Handles Rotation_ScrollBar.ValueChanged, Rotational_ScrollBar.ValueChanged
        Dim Rotate_val, Rotational_val As Double

        Rotate_val = Rotation_ScrollBar.Value
        Rotational_val = Rotational_ScrollBar.Value
        If RadioButton1.Checked = True Then
            Head_Degree = Rotation_ScrollBar.Value
            Head.Rotate(Rotate_val, "y")
            Start_Draw()
        ElseIf RadioButton2.Checked = True Then
            If CheckBox1.Checked = True And CheckBox2.Checked = False Then
                If Rotation_ScrollBar.Value >= -50 Then
                    RUpperArm_Degree = Rotation_ScrollBar.Value
                    RUpperArm.Rotate(Rotate_val, "z")
                    Start_Draw()
                End If
            ElseIf CheckBox2.Checked = True And CheckBox1.Checked = False Then
                If Rotation_ScrollBar.Value <= 50 And Rotation_ScrollBar.Value >= -80 Then
                    LUpperArm_Degree = Rotation_ScrollBar.Value
                    LUpperArm.Rotate(Rotate_val, "z")
                    Start_Draw()
                End If
            ElseIf CheckBox1.Checked = True And CheckBox2.Checked = True Then
                If Rotation_ScrollBar.Value >= -50 Then
                    RUpperArm.Rotate(Rotate_val, "z")
                    LUpperArm.Rotate(-Rotate_val, "z")
                    Start_Draw()
                End If
            End If
        ElseIf RadioButton3.Checked = True Then
            If CheckBox1.Checked = True And CheckBox2.Checked = False Then
                RLowerArm_Degree = Rotation_ScrollBar.Value
                RLowerArm.Rotate(Rotate_val + 10, "y")
                Start_Draw()
            ElseIf CheckBox2.Checked = True And CheckBox1.Checked = False Then
                LLowerArm_Degree = Rotation_ScrollBar.Value
                LLowerArm.Rotate(-Rotate_val - 10, "y")
                Start_Draw()
            ElseIf CheckBox1.Checked = True And CheckBox2.Checked = True Then
                RLowerArm.Rotate(Rotate_val + 10, "y")
                LLowerArm.Rotate(-Rotate_val - 10, "y")
                Start_Draw()
            End If
        ElseIf RadioButton4.Checked = True Then
            If CheckBox1.Checked = True And CheckBox2.Checked = False Then
                If Rotation_ScrollBar.Value <= 0 Then
                    RClaw_Degree = Rotation_ScrollBar.Value
                    RLowerArm.Rotate(Rotational_val, "x")
                    RClaw1.Rotate(Rotate_val + 270, "x")
                    RClaw2.Rotate(Rotate_val + 270, "x")
                    Start_Draw()
                End If
            ElseIf CheckBox2.Checked = True And CheckBox1.Checked = False Then
                If Rotation_ScrollBar.Value <= 0 Then
                    LClaw_Degree = Rotation_ScrollBar.Value
                    LLowerArm.Rotate(Rotational_val, "x")
                    LClaw1.Rotate(Rotate_val, "x")
                    LClaw2.Rotate(Rotate_val, "x")
                    Start_Draw()
                End If
            ElseIf CheckBox1.Checked = True And CheckBox2.Checked = True Then
                If Rotation_ScrollBar.Value <= 0 Then
                    LClaw_Degree = Rotation_ScrollBar.Value
                    RClaw_Degree = Rotation_ScrollBar.Value

                    RLowerArm.Rotate(Rotational_val, "x")
                    LLowerArm.Rotate(Rotational_val, "x")

                    LClaw1.Rotate(LClaw_Degree, "x")
                    LClaw2.Rotate(LClaw_Degree, "x")

                    RClaw1.Rotate(RClaw_Degree + 270, "x")
                    RClaw2.Rotate(RClaw_Degree + 270, "x")
                    Start_Draw()
                End If
            End If
        ElseIf RadioButton5.Checked = True Then
            BottomLegs_Degree = Rotation_ScrollBar.Value
            BottomLegs.Rotate(Rotate_val, "y")
            Start_Draw()
        End If
    End Sub

    Private Sub RadioButtons_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged, RadioButton3.CheckedChanged, RadioButton4.CheckedChanged
        If RadioButton1.Checked = True Then
            Rotation_ScrollBar.Value = Head_Degree
            Rotational_ScrollBar.Visible = False
        ElseIf RadioButton2.Checked = True Then
            Rotational_ScrollBar.Visible = False
            If CheckBox1.Checked = True And CheckBox2.Checked = False Then
                Rotation_ScrollBar.Value = RUpperArm_Degree
            ElseIf CheckBox2.Checked = True And CheckBox1.Checked = False Then
                Rotation_ScrollBar.Value = LUpperArm_Degree
            ElseIf CheckBox1.Checked = True And CheckBox2.Checked = True Then
                Rotation_ScrollBar.Value = 0
            End If
        ElseIf RadioButton3.Checked = True Then
            Rotational_ScrollBar.Visible = False
            If CheckBox1.Checked = True And CheckBox2.Checked = False Then
                If RLowerArm_Degree = 0 Then
                    Rotation_ScrollBar.Value = 90
                Else
                    Rotation_ScrollBar.Value = RLowerArm_Degree
                End If
            ElseIf CheckBox2.Checked = True And CheckBox1.Checked = False Then
                If LLowerArm_Degree = 0 Then
                    Rotation_ScrollBar.Value = 90
                Else
                    Rotation_ScrollBar.Value = LLowerArm_Degree
                End If
            ElseIf CheckBox1.Checked = True And CheckBox2.Checked = True Then
                Rotation_ScrollBar.Value = 90
            End If
        ElseIf RadioButton4.Checked = True Then
            Rotational_ScrollBar.Visible = True
            If CheckBox1.Checked = True And CheckBox2.Checked = False Then
                Rotation_ScrollBar.Value = RClaw_Degree
            ElseIf CheckBox2.Checked = True And CheckBox1.Checked = False Then
                Rotation_ScrollBar.Value = LClaw_Degree
            ElseIf CheckBox1.Checked = True And CheckBox2.Checked = True Then
                Rotation_ScrollBar.Value = 0
            End If
        ElseIf RadioButton5.Checked = True Then
            Rotation_ScrollBar.Value = BottomLegs_Degree
            Rotational_ScrollBar.Visible = False
        End If
    End Sub

    Private Sub CheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged, CheckBox2.CheckedChanged
        If RadioButton2.Checked = True Then
            If CheckBox1.Checked = True And CheckBox2.Checked = True Then
                Rotation_ScrollBar.Value = 0
            End If
        ElseIf RadioButton3.Checked = True Then
            If CheckBox1.Checked = True And CheckBox2.Checked = False Then
                If RLowerArm_Degree = 0 Then
                    Rotation_ScrollBar.Value = 90
                Else
                    Rotation_ScrollBar.Value = RLowerArm_Degree
                End If
            ElseIf CheckBox1.Checked = False And CheckBox2.Checked = True Then
                If LLowerArm_Degree = 0 Then
                    Rotation_ScrollBar.Value = 90
                Else
                    Rotation_ScrollBar.Value = LLowerArm_Degree
                End If
            ElseIf CheckBox1.Checked = True And CheckBox2.Checked = True Then
                Rotation_ScrollBar.Value = 90
            End If
        ElseIf RadioButton4.Checked = True Then
            If CheckBox1.Checked = True And CheckBox2.Checked = False Then
                Rotation_ScrollBar.Value = RClaw_Degree
            ElseIf CheckBox1.Checked = False And CheckBox2.Checked = True Then
                Rotation_ScrollBar.Value = LClaw_Degree
            ElseIf CheckBox1.Checked = True And CheckBox2.Checked = True Then
                Rotation_ScrollBar.Value = 0
            End If
        End If
    End Sub

    'timer

    Private Sub TimeRotation_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        If (Move_Right = True) Then
            Degree -= 1
            World.Rotate(Degree, "y")
            Start_Draw()
        ElseIf (Move_Left = True) Then
            Degree += 1
            World.Rotate(Degree, "y")
            Start_Draw()
        ElseIf (Move_Forward = True) Then
            World.MoveOnZ(0.05)
            Start_Draw()
        ElseIf (Move_Backward = True) Then
            World.MoveOnZ(-0.05)
            Start_Draw()
        End If
    End Sub

    'RobotMovement_GroupBox

    Private Sub Forward_Button_MouseDown(sender As Object, e As EventArgs) Handles Forward_Button.MouseDown
        Timer.Start()
        Move_Forward = True
    End Sub

    Private Sub Forward_Button_MouseUp(sender As Object, e As EventArgs) Handles Forward_Button.MouseUp
        Timer.Stop()
        Move_Forward = False
    End Sub

    Private Sub Backward_Button_MouseDown(sender As Object, e As EventArgs) Handles Backward_Button.MouseDown
        Timer.Start()
        Move_Backward = True
    End Sub

    Private Sub Backward_Button_MouseUp(sender As Object, e As EventArgs) Handles Backward_Button.MouseUp
        Timer.Stop()
        Move_Backward = False
    End Sub

    Private Sub Right_Button_MouseDown(sender As Object, e As MouseEventArgs) Handles Right_Button.MouseDown
        Timer.Start()
        Move_Right = True
    End Sub

    Private Sub Right_Button_MouseUp(sender As Object, e As MouseEventArgs) Handles Right_Button.MouseUp
        Timer.Stop()
        Move_Right = False
    End Sub

    Private Sub Left_Button_MouseDown(sender As Object, e As MouseEventArgs) Handles Left_button.MouseDown
        Timer.Start()
        Move_Left = True
    End Sub

    Private Sub Left_Button_MouseUp(sender As Object, e As MouseEventArgs) Handles Left_button.MouseUp
        Timer.Stop()
        Move_Left = False
    End Sub

    'Mouse Movement

    Private Sub Screen_PctrBx_MouseDown(sender As Object, e As MouseEventArgs) Handles Screen_PctrBx.MouseDown
        IsMoving = True
        MovingX = e.X
    End Sub

    Private Sub Screen_PctrBx_MouseUp(sender As Object, e As MouseEventArgs) Handles Screen_PctrBx.MouseUp
        IsMoving = False
    End Sub

    Private Sub Screen_PctrBx_MouseMove(sender As Object, e As MouseEventArgs) Handles Screen_PctrBx.MouseMove
        If IsMoving Then
            World.Rotate(MovingX + e.X, "y")
            Start_Draw()
        End If
    End Sub

    'Arrow Keys
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = Keys.Up Then
            World.MoveOnZ(0.05)
            Start_Draw()
            Return True
        End If
        If keyData = Keys.Down Then
            World.MoveOnZ(-0.05)
            Start_Draw()
            Return True
        End If
        If keyData = Keys.Left Then
            Degree += 1
            World.Rotate(Degree, "y")
            Start_Draw()
            Return True
        End If
        If keyData = Keys.Right Then
            Degree -= 1
            World.Rotate(Degree, "y")
            Start_Draw()
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    'Reset
    Private Sub Reset_Button_Click(sender As Object, e As EventArgs) Handles Reset_Button.Click
        Bmp = New Bitmap(Screen_PctrBx.Width, Screen_PctrBx.Height)
        Graphic = Graphics.FromImage(Bmp)
        Graphic.Clear(Color.White)

        Degree = 0

        RadioButton1.Checked = True
        CheckBox1.Checked = False
        CheckBox2.Checked = False

        Head_Degree = 0
        LUpperArm_Degree = 0
        LLowerArm_Degree = 0
        LClaw_Degree = 0
        RUpperArm_Degree = 0
        RLowerArm_Degree = 0
        RClaw_Degree = 0
        BottomLegs_Degree = 0

        Rotation_ScrollBar.Value = 0

        InitValue()
        InitRobots()

        Start_Draw()
    End Sub
End Class

Public Class Vertex
    Public x, y, z, w As Double

    Public Sub New(a As Double, b As Double, c As Double, d As Double)
        Me.x = a
        Me.y = b
        Me.z = c
        Me.w = d
    End Sub
End Class

Public Class Line
    Public P1, P2 As Integer

    Sub New(a As Integer, b As Integer)
        Me.P1 = a
        Me.P2 = b
    End Sub

End Class

Public Class Objects
    Public edges As List(Of Line) = New List(Of Line)
    Public vertices As List(Of Vertex) = New List(Of Vertex)

    Sub New(Xmin As Double, Ymin As Double, Zmin As Double, Xmax As Double, Ymax As Double, Zmax As Double)
        vertices.Add(New Vertex(Xmin, Ymax, Zmax, 1))
        vertices.Add(New Vertex(Xmax, Ymax, Zmax, 1))

        vertices.Add(New Vertex(Xmax, Ymin, Zmax, 1))
        vertices.Add(New Vertex(Xmin, Ymin, Zmax, 1))

        vertices.Add(New Vertex(Xmin, Ymax, Zmin, 1))
        vertices.Add(New Vertex(Xmax, Ymax, Zmin, 1))

        vertices.Add(New Vertex(Xmax, Ymin, Zmin, 1))
        vertices.Add(New Vertex(Xmin, Ymin, Zmin, 1))

        edges.Add(New Line(0, 1))
        edges.Add(New Line(1, 2))
        edges.Add(New Line(2, 3))
        edges.Add(New Line(3, 0))
        edges.Add(New Line(0, 4))
        edges.Add(New Line(1, 5))
        edges.Add(New Line(2, 6))
        edges.Add(New Line(3, 7))
        edges.Add(New Line(4, 5))
        edges.Add(New Line(5, 6))
        edges.Add(New Line(6, 7))
        edges.Add(New Line(7, 4))
    End Sub

    Sub New(X1 As Double, Y1 As Double, Z1 As Double,
            X2 As Double, Y2 As Double, Z2 As Double,
            X3 As Double, Y3 As Double, Z3 As Double,
            X4 As Double, Y4 As Double, Z4 As Double,
            X5 As Double, Y5 As Double, Z5 As Double,
            X6 As Double, Y6 As Double, Z6 As Double,
            X7 As Double, Y7 As Double, Z7 As Double,
            X8 As Double, Y8 As Double, Z8 As Double)
        vertices.Add(New Vertex(X1, Y1, Z1, 1))
        vertices.Add(New Vertex(X2, Y2, Z2, 1))

        vertices.Add(New Vertex(X3, Y3, Z3, 1))
        vertices.Add(New Vertex(X4, Y4, Z4, 1))

        vertices.Add(New Vertex(X5, Y5, Z5, 1))
        vertices.Add(New Vertex(X6, Y6, Z6, 1))

        vertices.Add(New Vertex(X7, Y7, Z7, 1))
        vertices.Add(New Vertex(X8, Y8, Z8, 1))

        edges.Add(New Line(0, 1))
        edges.Add(New Line(1, 2))
        edges.Add(New Line(2, 3))
        edges.Add(New Line(3, 0))
        edges.Add(New Line(0, 4))
        edges.Add(New Line(1, 5))
        edges.Add(New Line(2, 6))
        edges.Add(New Line(3, 7))
        edges.Add(New Line(4, 5))
        edges.Add(New Line(5, 6))
        edges.Add(New Line(6, 7))
        edges.Add(New Line(7, 4))
    End Sub
End Class

Public Class ObjectsProjection
    Public Mat As Matrix = New Matrix
    Public Matrices(3, 3) As Double

    Public Objects As Objects
    Public Child As ObjectsProjection
    Public NextSibling As ObjectsProjection

    Public x, y, z As Double
    Public Tx, Ty, Tz As Double

    Public Sub Create(a As Double, b As Double, c As Double)
        x = 0
        y = 0
        z = 0

        Tx = 0
        Ty = 0
        Tz = 0

        Matrices = Mat.InitMatrixTranslate(a, b, c)
    End Sub

    Public Sub Rotate(degree As Double, Axis As Char)
        Dim t1(3, 3) As Double
        Dim deg, sintet, costet As Double

        If Axis = "x" Then
            deg = degree - x
            x = degree
        ElseIf Axis = "y" Then
            deg = degree - y
            y = degree
        ElseIf Axis = "z" Then
            deg = degree - z
            z = degree
        End If

        deg = Math.PI * (deg / 180)
        sintet = Math.Sin(deg)
        costet = Math.Cos(deg)

        If (Axis = "x") Then
            t1 = New Double(3, 3) {
                    {1, 0, 0, 0},
                    {0, costet, sintet, 0},
                    {0, -sintet, costet, 0},
                    {0, 0, 0, 1}
                }
        ElseIf (Axis = "y") Then
            t1 = New Double(3, 3) {
                    {costet, 0, -sintet, 0},
                    {0, 1, 0, 0},
                    {sintet, 0, costet, 0},
                    {0, 0, 0, 1}
                }
        ElseIf (Axis = "z") Then
            t1 = New Double(3, 3) {
                    {costet, sintet, 0, 0},
                    {-sintet, costet, 0, 0},
                    {0, 0, 1, 0},
                    {0, 0, 0, 1}
                }
        End If

        Matrices = Mat.MatrixMatrix(t1, Matrices)
    End Sub

    Public Sub Translate(move As Double, Axis As Char)
        Dim curr As Double
        Dim Matrix(3, 3) As Double

        If Axis = "x" Then
            curr = move - Tx
            Tx = move
        ElseIf Axis = "y" Then
            curr = move - Ty
            Ty = move
        ElseIf Axis = "z" Then
            curr = move - Tz
            Tz = move
        End If

        If (Axis = "x") Then
            Matrix = Mat.InitMatrixTranslate(curr, 0, 0)
        ElseIf (Axis = "y") Then
            Matrix = Mat.InitMatrixTranslate(0, curr, 0)
        ElseIf (Axis = "z") Then
            Matrix = Mat.InitMatrixTranslate(0, 0, curr)
        End If

        Matrices = Mat.MatrixMatrix(Matrix, Matrices)
    End Sub

    Public Sub Scale(a As Double, b As Double, c As Double)
        Dim Matrix(3, 3) As Double

        Matrix = Mat.InitMatrixScale(a, b, c)

        Matrices = Mat.MatrixMatrix(Matrix, Matrices)
    End Sub

    Public Sub MoveOnZ(a As Double)
        Dim Matrix(3, 3) As Double
        Matrix = {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 1, 0},
            {0, 0, a, 1}
        }

        Matrices = Mat.MatrixMatrix(Matrix, Matrices)
    End Sub

End Class

Public Class Matrix

    Function MatrixMatrix(M1(,) As Double, M2(,) As Double) As Double(,)
        Dim M(3, 3) As Double
        For i = 0 To 3
            M(i, 0) = M1(i, 0) * M2(0, 0) + M1(i, 1) * M2(1, 0) + M1(i, 2) * M2(2, 0) + M1(i, 3) * M2(3, 0)
            M(i, 1) = M1(i, 0) * M2(0, 1) + M1(i, 1) * M2(1, 1) + M1(i, 2) * M2(2, 1) + M1(i, 3) * M2(3, 1)
            M(i, 2) = M1(i, 0) * M2(0, 2) + M1(i, 1) * M2(1, 2) + M1(i, 2) * M2(2, 2) + M1(i, 3) * M2(3, 2)
            M(i, 3) = M1(i, 0) * M2(0, 3) + M1(i, 1) * M2(1, 3) + M1(i, 2) * M2(2, 3) + M1(i, 3) * M2(3, 3)
        Next
        Return M
    End Function

    Function PointMatrix(Point As Vertex, Marix(,) As Double) As Vertex
        Return New Vertex(Point.x * Marix(0, 0) + Point.y * Marix(1, 0) + Point.z * Marix(2, 0) + Point.w * Marix(3, 0),
                       Point.x * Marix(0, 1) + Point.y * Marix(1, 1) + Point.z * Marix(2, 1) + Point.w * Marix(3, 1),
                       Point.x * Marix(0, 2) + Point.y * Marix(1, 2) + Point.z * Marix(2, 2) + Point.w * Marix(3, 2),
                       Point.x * Marix(0, 3) + Point.y * Marix(1, 3) + Point.z * Marix(2, 3) + Point.w * Marix(3, 3))
    End Function

    Overloads Function InitMatrixTranslate(x As Double, y As Double, z As Double) As Double(,)
        Return New Double(3, 3) {
                {1, 0, 0, 0},
                {0, 1, 0, 0},
                {0, 0, 1, 0},
                {x, y, z, 1}
            }
    End Function

    Overloads Function InitMatrixScale(sx As Double, sy As Double, sz As Double) As Double(,)
        Return New Double(3, 3) {
                {sx, 0, 0, 0},
                {0, sy, 0, 0},
                {0, 0, sz, 0},
                {0, 0, 0, 1}
            }
    End Function
End Class
Imports System
Imports System.Collections
Imports System.Text
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic


Public Class Diff

    Public Structure Item
        Public StartA As Integer
        Public StartB As Integer
        Public deletedA As Integer
        Public insertedB As Integer
    End Structure

    Private Structure SMSRD
        Friend x, y As Integer
    End Structure


#Region "self-Test"

#If SELFTEST Then
    Public Shared Function Main(ByVal args As String()) As Integer
        Dim ret As StringBuilder = New StringBuilder
        Dim a, b As String

        Dim ctl As System.Diagnostics.ConsoleTraceListener = New System.Diagnostics.ConsoleTraceListener(False)
        System.Diagnostics.Debug.Listeners.Add(ctl)

        System.Console.WriteLine("Diff Self Test...")

        a = "a,b,c,d,e,f,g,h,i,j,k,l".Replace(",", "\n")
        b = "0,1,2,3,4,5,6,7,8,9".Replace(",", "\n")
        System.Diagnostics.Debug.Assert(TestHelper(Diff.DiffText(a, b, False, False, False)) = "12.10.0.0*", "all-changes test failed.")
        System.Diagnostics.Debug.WriteLine("all-changes test passed.")
        a = "a,b,c,d,e,f,g,h,i,j,k,l".Replace(",", "\n")
        b = a
        System.Diagnostics.Debug.Assert(TestHelper(Diff.DiffText(a, b, False, False, False)) = "", "all-same test failed.")
        System.Diagnostics.Debug.WriteLine("all-same test passed.")

        a = "a,b,c,d,e,f".Replace(",", "\n")
        b = "b,c,d,e,f,x".Replace(",", "\n")
        System.Diagnostics.Debug.Assert(TestHelper(Diff.DiffText(a, b, False, False, False)) = "1.0.0.0*0.1.6.5*", "snake test failed.")
        System.Diagnostics.Debug.WriteLine("snake test passed.")

        a = "c1,a,c2,b,c,d,e,g,h,i,j,c3,k,l".Replace(",", "\n")
        b = "C1,a,C2,b,c,d,e,I1,e,g,h,i,j,C3,k,I2,l".Replace(",", "\n")
        System.Diagnostics.Debug.Assert(TestHelper(Diff.DiffText(a, b, False, False, False)) = "1.1.0.0*1.1.2.2*0.2.7.7*1.1.11.13*0.1.13.15*", "repro20020920 test failed.")
        System.Diagnostics.Debug.WriteLine("repro20020920 test passed.")

        a = "F".Replace(",", "\n")
        b = "0,F,1,2,3,4,5,6,7".Replace(",", "\n")
        System.Diagnostics.Debug.Assert(TestHelper(Diff.DiffText(a, b, False, False, False)) = "0.1.0.0*0.7.1.2*", "repro20030207 test failed.")
        System.Diagnostics.Debug.WriteLine("repro20030207 test passed.")

        a = "HELLO\nWORLD"
        b = "\n\nhello\n\n\n\nworld\n"
        System.Diagnostics.Debug.Assert(TestHelper(Diff.DiffText(a, b, False, False, False)) = "2.8.0.0*", "repro20030409 test failed.")
        System.Diagnostics.Debug.WriteLine("repro20030409 test passed.")

        a = "a,b,-,c,d,e,f,f".Replace(",", "\n")
        b = "a,b,x,c,e,f".Replace(",", "\n")
        System.Diagnostics.Debug.Assert(TestHelper(Diff.DiffText(a, b, False, False, False)) = "1.1.2.2*1.0.4.4*1.0.6.5*", "some-changes test failed.")
        System.Diagnostics.Debug.WriteLine("some-changes test passed.")

        System.Diagnostics.Debug.WriteLine("End.")
        System.Diagnostics.Debug.Flush()

        Return 0
    End Function


    Public Shared Function TestHelper(ByVal f As Item()) As String
        Dim ret As StringBuilder = New StringBuilder
        For n As Integer = 0 To f.Length - 1
            ret.Append(f(n).deletedA.ToString() + "." + f(n).insertedB.ToString() + "." + f(n).StartA.ToString() + "." + f(n).StartB.ToString() + "*")
        Next n
        Return ret.ToString()
    End Function
#End If
#End Region


    Public Function DiffText(ByVal TextA As String, ByVal TextB As String) As Item()
        Return (DiffText(TextA, TextB, False, False, False))
    End Function


    Public Shared Function DiffText(ByVal TextA As String, ByVal TextB As String, ByVal trimSpace As Boolean, ByVal ignoreSpace As Boolean, ByVal ignoreCase As Boolean) As Item()
        Dim h As Hashtable = New Hashtable(TextA.Length + TextB.Length)

        Dim DataA As DiffData = New DiffData(DiffCodes(TextA, h, trimSpace, ignoreSpace, ignoreCase))

        Dim DataB As DiffData = New DiffData(DiffCodes(TextB, h, trimSpace, ignoreSpace, ignoreCase))

        h = Nothing

        LCS(DataA, 0, DataA.Length, DataB, 0, DataB.Length)
        Return CreateDiffs(DataA, DataB)
    End Function


    Public Shared Function DiffInt(ByVal ArrayA As Integer(), ByVal ArrayB As Integer()) As Item()
        Dim DataA As DiffData = New DiffData(ArrayA)

        Dim DataB As DiffData = New DiffData(ArrayB)

        LCS(DataA, 0, DataA.Length, DataB, 0, DataB.Length)
        Return CreateDiffs(DataA, DataB)
    End Function


    Private Shared Function DiffCodes(ByVal aText As String, ByVal h As Hashtable, ByVal trimSpace As Boolean, ByVal ignoreSpace As Boolean, ByVal ignoreCase As Boolean) As Integer()
        Dim Lines As String()
        Dim Codes() As Integer
        Dim lastUsedCode As Integer = h.Count
        Dim aCode As Object
        Dim s As String

        aText = aText.Replace(Chr(13), "")
        Lines = aText.Split(Chr(10))

        Codes = New Integer(Lines.Length) {}

        For i As Integer = 0 To Lines.Length - 1
            s = Lines(i)
            If (trimSpace) Then
                s = s.Trim()
            End If

            If (ignoreSpace) Then
                s = Regex.Replace(s, "\\s+", " ")
            End If

            If (ignoreCase) Then
                s = s.ToLower()
            End If

            aCode = h(s)
            If (aCode Is Nothing) Then
                lastUsedCode = lastUsedCode + 1
                h(s) = lastUsedCode
                Codes(i) = lastUsedCode
            Else
                Codes(i) = CType(aCode, Integer)
            End If
        Next i
        Return Codes
    End Function


    Private Shared Function SMS(ByVal DataA As DiffData, ByVal LowerA As Integer, ByVal UpperA As Integer, ByVal DataB As DiffData, ByVal LowerB As Integer, ByVal UpperB As Integer) As SMSRD
        Dim ret As SMSRD
        Dim MAX As Integer = DataA.Length + DataB.Length + 1

        Dim DownK As Integer = LowerA - LowerB
        Dim UpK As Integer = UpperA - UpperB

        Dim Delta As Integer = (UpperA - LowerA) - (UpperB - LowerB)
        Dim oddDelta As Boolean = (Delta And 1) <> 0

        Dim DownVector As Integer() = New Integer(2 * MAX + 2) {}

        Dim UpVector As Integer() = New Integer(2 * MAX + 2) {}


        Dim DownOffset As Integer = MAX - DownK
        Dim UpOffset As Integer = MAX - UpK

        Dim MaxD As Integer = ((UpperA - LowerA + UpperB - LowerB) \ 2) + 1

        DownVector(DownOffset + DownK + 1) = LowerA
        UpVector(UpOffset + UpK - 1) = UpperA

        For D As Integer = 0 To MaxD

            For k As Integer = DownK - D To DownK + D Step 2
                Dim x, y As Integer
                If (k = DownK - D) Then
                    x = DownVector(DownOffset + k + 1)
                Else
                    x = DownVector(DownOffset + k - 1) + 1
                    If ((k < DownK + D) And (DownVector(DownOffset + k + 1) >= x)) Then
                        x = DownVector(DownOffset + k + 1)
                    End If
                End If
                y = x - k

                While ((x < UpperA) And (y < UpperB) And (DataA.data(x) = DataB.data(y)))
                    x = x + 1
                    y = y + 1
                End While
                DownVector(DownOffset + k) = x

                If (oddDelta And (UpK - D < k) And (k < UpK + D)) Then
                    If (UpVector(UpOffset + k) <= DownVector(DownOffset + k)) Then
                        ret.x = DownVector(DownOffset + k)
                        ret.y = DownVector(DownOffset + k) - k
                        Return ret
                    End If
                End If

            Next k

            For k As Integer = UpK - D To UpK + D Step 2
                Dim x, y As Integer
                If (k = UpK + D) Then
                    x = UpVector(UpOffset + k - 1)
                Else
                    x = UpVector(UpOffset + k + 1) - 1
                    If ((k > UpK - D) And (UpVector(UpOffset + k - 1) < x)) Then
                        x = UpVector(UpOffset + k - 1)
                    End If
                End If
                y = x - k

                While ((x > LowerA) And (y > LowerB) And (x > 0) And (y > 0))
                    If DataA.data(x - 1) = DataB.data(y - 1) Then
                        x = x - 1
                        y = y - 1
                    Else
                        Exit While
                    End If
                End While
                UpVector(UpOffset + k) = x

                If (Not oddDelta And (DownK - D <= k) And (k <= DownK + D)) Then
                    If (UpVector(UpOffset + k) <= DownVector(DownOffset + k)) Then
                        ret.x = DownVector(DownOffset + k)
                        ret.y = DownVector(DownOffset + k) - k
                        Return ret
                    End If
                End If

            Next k

        Next D

        Throw New ApplicationException("the algorithm should never come here.")
    End Function


    Private Shared Sub LCS(ByVal DataA As DiffData, ByVal LowerA As Integer, ByVal UpperA As Integer, ByVal DataB As DiffData, ByVal LowerB As Integer, ByVal UpperB As Integer)
        While (LowerA < UpperA And LowerB < UpperB And DataA.data(LowerA) = DataB.data(LowerB))
            LowerA = LowerA + 1
            LowerB = LowerB + 1
        End While

        While (LowerA < UpperA And LowerB < UpperB And UpperA > 0 And UpperB > 0) 'DataA.data(UpperA - 1) = DataB.data(UpperB - 1))
            If DataA.data(UpperA - 1) = DataB.data(UpperB - 1) Then
                UpperA = UpperA - 1
                UpperB = UpperB - 1
            Else
                Exit While
            End If
        End While

        If (LowerA = UpperA) Then
            While (LowerB < UpperB)
                DataB.modified(LowerB) = True
                LowerB = LowerB + 1
            End While

        ElseIf (LowerB = UpperB) Then
            While (LowerA < UpperA)
                DataA.modified(LowerA) = True
                LowerA = LowerA + 1
            End While

        Else
            Dim smsrd As SMSRD = SMS(DataA, LowerA, UpperA, DataB, LowerB, UpperB)
            LCS(DataA, LowerA, smsrd.x, DataB, LowerB, smsrd.y)
            LCS(DataA, smsrd.x, UpperA, DataB, smsrd.y, UpperB)
        End If
    End Sub


    Private Shared Function CreateDiffs(ByVal DataA As DiffData, ByVal DataB As DiffData) As Item()
        Dim a As ArrayList = New ArrayList
        Dim aItem As Item
        Dim result() As Item

        Dim StartA, StartB As Integer
        Dim LineA, LineB As Integer

        LineA = 0
        LineB = 0
        While (LineA < DataA.Length Or LineB < DataB.Length)
            If ((LineA < DataA.Length) And (Not DataA.modified(LineA)) And (LineB < DataB.Length) And (Not DataB.modified(LineB))) Then
                LineA = LineA + 1
                LineB = LineB + 1

            Else
                StartA = LineA
                StartB = LineB

                While (LineA < DataA.Length And (LineB >= DataB.Length Or DataA.modified(LineA)))
                    LineA = LineA + 1
                End While

                While (LineB < DataB.Length And (LineA >= DataA.Length Or DataB.modified(LineB)))
                    LineB = LineB + 1
                End While

                If ((StartA < LineA) Or (StartB < LineB)) Then
                    aItem = New Item
                    aItem.StartA = StartA
                    aItem.StartB = StartB
                    aItem.deletedA = LineA - StartA
                    aItem.insertedB = LineB - StartB
                    a.Add(aItem)
                End If
            End If
        End While

        result = New Item(a.Count) {}
        a.CopyTo(result)

        Return (result)
    End Function

End Class

Friend Class DiffData

    Friend Length As Integer

    Friend data() As Integer

    Friend modified() As Boolean

    Friend Sub New(ByVal initData As Integer())
        data = initData
        Length = initData.Length
        modified = New Boolean(Length + 2) {}
    End Sub
End Class

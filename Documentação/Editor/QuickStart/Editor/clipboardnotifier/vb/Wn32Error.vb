Imports System
Imports System.Runtime.InteropServices
Imports System.Security.Permissions
Imports System.Text


Public Class Win32Error
    Private Const FORMAT_MESSAGE_ALLOCATE_BUFFER As Integer = &H100
    Private Const FORMAT_MESSAGE_ARGUMENT_ARRAY As Integer = &H2000
    Private Const FORMAT_MESSAGE_FROM_HMODULE As Integer = &H800
    Private Const FORMAT_MESSAGE_FROM_STRING As Integer = &H400
    Private Const FORMAT_MESSAGE_FROM_SYSTEM As Integer = &H1000
    Private Const FORMAT_MESSAGE_IGNORE_INSERTS As Integer = &H200
    Private Const FORMAT_MESSAGE_MAX_WIDTH_MASK As Integer = &HFF

    Private Declare Auto Function FormatMessage Lib "kernel32" (ByVal dwFlags As Integer, ByVal lpSource As IntPtr, _
    ByVal dwMessageId As Integer, ByVal dwLanguageId As Integer, <MarshalAs(UnmanagedType.LPTStr)> ByVal lpBuffer As StringBuilder, _
    ByVal nSize As Integer, ByVal Arguments As IntPtr) As Integer

    Public Shared Function ErrorMessage(ByVal lastWin32Error As Integer) As String
        Dim msg As StringBuilder = New StringBuilder(256, 256)
        Dim size As Integer = FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM Or FORMAT_MESSAGE_IGNORE_INSERTS, IntPtr.Zero, lastWin32Error, 0, msg, msg.MaxCapacity, IntPtr.Zero)
        Return msg.ToString()
    End Function

    Private Sub New()
        ' intentionally blank
    End Sub
End Class

Imports System
Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports System.Security.Permissions
Imports System.Windows.Forms

'Requires unmanaged code
<Assembly: SecurityPermissionAttribute(SecurityAction.RequestMinimum, UnmanagedCode:=True)> 
' Requires all clipboard access
<Assembly: UIPermissionAttribute(SecurityAction.RequestMinimum, Clipboard:=UIPermissionClipboard.AllClipboard)> 
' Is CLSCompliant
<Assembly: CLSCompliantAttribute(True)> 

Public Class ClipboardChangeNotifier
    Inherits NativeWindow
    Implements IDisposable

#Region "Unmanaged Code"
    Private Declare Function SetClipboardViewer Lib "user32" (ByVal hWnd As IntPtr) As IntPtr
    Private Declare Function ChangeClipboardChain Lib "user32" (ByVal hWnd As IntPtr, ByVal hWndNext As IntPtr) As Integer
    Private Declare Auto Function SendMessage Lib "user32" (ByVal hWnd As IntPtr, ByVal wMsg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer

    Private Const WM_DESTROY As Integer = &H2
    Private Const WM_DRAWCLIPBOARD As Integer = &H308
    Private Const WM_CHANGECBCHAIN As Integer = &H30D
#End Region

#Region "Member Variables"
    Protected nextViewerHandle As IntPtr = IntPtr.Zero
    Protected disposed As Boolean = False
    Protected installedHandle As IntPtr = IntPtr.Zero
#End Region

#Region "Events"
    Public Event ClipboardChanged As System.EventHandler
#End Region

    Protected Overrides Sub WndProc(ByRef e As Message)
        ' if the message is a clipboard change notification
        Select Case (e.Msg)

        Case WM_CHANGECBCHAIN
                ' Store the changed handle of the next item 
                ' in the clipboard chain:
                Me.nextViewerHandle = e.LParam

                If (Not Me.nextViewerHandle.Equals(IntPtr.Zero)) Then
                    ' pass the message on:
                    SendMessage(Me.nextViewerHandle, e.Msg, e.WParam, e.LParam)
                End If

                ' We have processed this message:
                e.Result = IntPtr.Zero

				case WM_DRAWCLIPBOARD:
                ' content of clipboard has changed:
                Dim clipChange As EventArgs = New EventArgs
                OnClipboardChanged(clipChange)

                ' pass the message on:
                If (Not Me.nextViewerHandle.Equals(IntPtr.Zero)) Then
                    SendMessage(Me.nextViewerHandle, e.Msg, e.WParam, e.LParam)
                End If

                ' We have processed this message:
                e.Result = IntPtr.Zero

				case WM_DESTROY:
                ' Very important: ensure we are uninstalled.
                Uninstall()
                'And call the superclass:
                MyBase.WndProc(e)

            Case Else
                ' call the superclass implementation:
                MyBase.WndProc(e)
        End Select
    End Sub

    Protected Overrides Sub OnHandleChange()
        Uninstall()
        MyBase.OnHandleChange()
    End Sub

    Public Sub Install()
        Me.Uninstall()
        If (Not Me.Handle.Equals(IntPtr.Zero)) Then

            Me.nextViewerHandle = SetClipboardViewer(Me.Handle)
            Me.installedHandle = Me.Handle
        End If
    End Sub

    Public Sub Uninstall()
        If (Not Me.installedHandle.Equals(IntPtr.Zero)) Then
            ChangeClipboardChain(Me.installedHandle, Me.nextViewerHandle)
            Dim err As Integer = System.Runtime.InteropServices.Marshal.GetLastWin32Error()
            Debug.Assert(err = 0, String.Format("{0} Failed to uninstall from Clipboard Chain", Me), Win32Error.ErrorMessage(err))
            Me.nextViewerHandle = IntPtr.Zero
            Me.installedHandle = IntPtr.Zero
        End If
    End Sub

    Protected Overridable Sub OnClipboardChanged(ByVal e As EventArgs)
        RaiseEvent ClipboardChanged(Me, e)
    End Sub

    Public Overridable Sub Dispose() Implements IDisposable.Dispose
        If (Not Me.disposed) Then
            Uninstall()
            Me.disposed = True
        End If
    End Sub

    Public Sub New()
        MyBase.New()
        ' intentionally blank
    End Sub

End Class

﻿Imports System.Net.Mail

Public Class Form1
    Public Declare Function VirtualAllocEx Lib "kernel32" (ByVal hProcess As Integer, ByVal lpAddress As Integer, ByVal dwSize As Integer, ByVal flAllocationType As Integer, ByVal flProtect As Integer) As Integer
    Public Const MEM_COMMIT = 4096, PAGE_EXECUTE_READWRITE = &H40
    Public Declare Function WriteProcessMemory Lib "kernel32" (ByVal hProcess As Integer, ByVal lpBaseAddress As Integer, ByVal lpBuffer As Byte(), ByVal nSize As Integer, ByRef lpNumberOfBytesWritten As Integer) As Integer
    Public Declare Function GetProcAddress Lib "kernel32" (ByVal hModule As Integer, ByVal lpProcName As String) As Integer
    Private Declare Function GetModuleHandle Lib "Kernel32" Alias "GetModuleHandleA" (ByVal lpModuleName As String) As Integer
    Public Declare Function CreateRemoteThread Lib "kernel32" (ByVal hProcess As Integer, ByVal lpThreadAttributes As Integer, ByVal dwStackSize As Integer, ByVal lpStartAddress As Integer, ByVal lpParameter As Integer, ByVal dwCreationFlags As Integer, ByRef lpThreadId As Integer) As Integer

    Public Sub dsfadsfadsf()
        Dim asdfgafdgdfg As Integer = 34643523
        Dim SFGSFDFCX As String = "dsfgvsdvds"
        Dim dsfgdfgdffsg As Integer = 12312456
        Dim sdfgdfhg As String = "zdfhgfgvbdfbdfgdfz"
        Dim gfhjhgfjdfg As Integer = 23513
        Dim xcvbxcvbcv As Integer = 346123463
        Dim ngfxcvgbcvxh As String = "fdgzfdgfdxfhdf"
        Dim xghtgxhzdbcv As Integer = 134523
        Dim xgfbhfghbhxfgdb As Integer = 4567457
        Dim fgxhretgdf As Integer = 2314
        Dim xgbgbxdfghb As String = "xfgbncvbfghdfgh"
        Dim xbfgdbfg As String = "xfghfgbcvbzdfg"
        Console.WriteLine("xgfhfgbcvxbdgfxh")
        Dim fgzfdzvbcb As Integer = 8956785
        Dim xfgbfgbcvb As Integer = 6354654
        Dim zdrfgdfvbcx As String = "fgyjyguifghh"
        Dim cvbncnxgfh As String = "zdfbxvcbfhgdfh"
        Dim nxgfncvbf As Integer = 564756
    End Sub

    Private Sub ButtonClick() Handles Button1.Click
        Dim DllPath As String = Application.StartupPath + "/cschanger.dll"

        If (Process.GetProcessesByName("csgo").Length = 0) Then
            MsgBox("Błąd uruchamiania uruchom na początku CSGO")
            Exit Sub
        End If

        Dim TargetHandle As IntPtr = Process.GetProcessesByName("csgo")(0).Handle
        If (TargetHandle.Equals(IntPtr.Zero)) Then
            MsgBox("Błąd uruchamiania CSChangera w CSGO, spróbuj ponownie")
            Exit Sub
        End If

        Dim GetAdrOfLLBA As IntPtr = GetProcAddress(GetModuleHandle("Kernel32"), "LoadLibraryA")
        If (GetAdrOfLLBA.Equals(IntPtr.Zero)) Then
            MsgBox("Nie można uzyskać adresu podstawowego funkcji API LoadLibraryA.")
            Exit Sub
        End If

        Dim OperaChar As Byte() = System.Text.Encoding.Default.GetBytes(DllPath)

        Dim DllMemPathAdr = VirtualAllocEx(TargetHandle, 0&, &H64, MEM_COMMIT, PAGE_EXECUTE_READWRITE)
        If (DllMemPathAdr.Equals(IntPtr.Zero)) Then
            MsgBox("Wystąpił błąd podczas uzupełniania danych sygnatur.")
            Exit Sub
        End If

        If (WriteProcessMemory(TargetHandle, DllMemPathAdr, OperaChar, OperaChar.Length, 0) = False) Then
            MsgBox("Błąd podczas uzupełniania procesu.")
            Exit Sub
        End If

        CreateRemoteThread(TargetHandle, 0, 0, GetAdrOfLLBA, DllMemPathAdr, 0, 0)
        MsgBox("CSChanger jest uruchomiony użyj ` oraz HOME w grze.")
    End Sub
    '==========================================================================================
    Private Sub ComboBoxDropDown(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(sender, ComboBox).Items.Clear()
        For Each p As Process In Process.GetProcesses
            CType(sender, ComboBox).Items.Add(p.ProcessName)
        Next
    End Sub

End Class


Option Explicit

Dim oApp
Set oApp = CreateObject("AltimailServer.Application")

' BEGIN: Authenticate the client.
Dim sAdminPwd
sAdminPwd = InputBox("Enter your main Altimail Server administrator password.", "Altimail Server")
Call oApp.Authenticate ("Administrator", sAdminPwd)
' END: Authenticate the client.

dim sInput
sInput = Inputbox("Enter encrypted password", "Altimail Server")

dim sOutput
sOutput = oApp.Utilities.BlowfishDecrypt(sInput)

MsgBox sOutput

Set oApp = Nothing
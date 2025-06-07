option explicit

Dim oApp
Set oApp = CreateObject("AltimailServer.Application")

' BEGIN: Authenticate the client.
Dim sAdminPwd
sAdminPwd = InputBox("Enter your main Altimail Server administrator password.", "Altimail Server")
Call oApp.Authenticate ("Administrator", sAdminPwd)
' END: Authenticate the client.

dim oUtilities
set oUtilities = oApp.Utilities

Dim sName
sName = InputBox("Enter the name of the service Altimail Server should be dependent on", "Altimail Server")

If sName <> "" Then
	oUtilities.MakeDependent(sName)
End If

MsgBox "Done"
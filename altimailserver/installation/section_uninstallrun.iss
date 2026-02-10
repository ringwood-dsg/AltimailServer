[UninstallRun]
Filename: "{sys}\net.exe"; Parameters: "STOP AltimailServer"; Flags: runhidden;
Filename: "{app}\Bin\AltimailServer.exe"; Parameters: "/Unregister"; Flags: runhidden;

;Filename: "{sys}\net.exe"; Parameters: "STOP AltimailServerMySQL"; Flags: runhidden;
;Filename: "{app}\MySQL\Bin\mysqld-nt.exe"; Parameters: "--remove AltimailServerMySQL"; Flags: runhidden;
;Filename: "{app}\Bin\hSMTPServer.exe"; Parameters: "unregister"; Flags: runhidden;
;Filename: "{app}\Bin\hPOP3Server.exe"; Parameters: "unregister"; Flags: runhidden;

[UninstallDelete] 
Type: filesandordirs; Name: "{app}\Bin"
Type: filesandordirs; Name: "{app}\DBScripts"
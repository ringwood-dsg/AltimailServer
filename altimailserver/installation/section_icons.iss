[Icons]
Name: "{group}\Altimail Server DB Setup Utility"; Filename: "{app}\Bin\DBSetup.exe"; Components: server;
Name: "{group}\Altimail Server Administrator"; Filename: "{app}\Bin\AltimailServerAdmin.exe"; Components: admintools;
Name: "{group}\Addons\Data Directory Synchronizer"; Filename: "{app}\Addons\DataDirectorySynchronizer\DataDirectorySynchronizer.exe"; Components: server;
Name: "{group}\Installation\Uninstall hMailServer"; Filename: "{app}\unins000.exe"; Components: admintools server;
Name: "{group}\Service\Start Service"; Filename: "{sys}\net.exe"; Parameters: "START AltimailServer"; Components: server;
Name: "{group}\Service\Stop Service"; Filename: "{sys}\net.exe"; Parameters: "STOP AltimailServer"; Components: server;

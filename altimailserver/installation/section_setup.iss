[Setup]
AppId={{78203AB6-A5A9-46B4-8F17-E4B3D4D9FE25}
AppName={#MyAppName}
AppVersion={#MyAppVersionStd}
AppVerName={#MyAppName} {#MyAppVersion}
AppCopyright=(c) 2008-{#CurrentYearVal} Altimail Server Authors and Contributors. All rights reserved.
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppPublisherUrl}
AppSupportURL={#MyAppSupportUrl}
AppUpdatesURL={#MyAppUpdatesUrl}

;For the setup bootstrap:
VersionInfoVersion={#MyAppVersionStd}
VersionInfoCopyright=(c) 2008-{#CurrentYearVal} Altimail Server Authors and Contributors. All rights reserved.

DefaultDirName={pf}\{#MyAppName}
DefaultGroupName={#MyAppName}

PrivilegesRequired=admin
SolidCompression=yes

WizardImageFile=setup.bmp
WizardStyle=modern
DisableWelcomePage=False

LicenseFile=License.rtf
;InfoBeforeFile=C:\...
SetupIconFile=main-setup-icon.ico

AllowNoIcons=yes
CreateAppDir=true
DirExistsWarning=no

Uninstallable=true
UninstallDisplayName={#MyAppName} {#MyAppVersion}
UninstallDisplayIcon={uninstallexe}

MinVersion=6.1.7601
ArchitecturesInstallIn64BitMode=x64
ArchitecturesAllowed=x64

OutputBaseFilename={#MyAppNameShort}-{#MyAppVersionFull}_Setup-amd64
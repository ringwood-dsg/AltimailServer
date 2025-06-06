#define ALTIMAILSERVERLIBS = GetEnv("AltimailServerLibs")
#define OPENSSL_LIBS_PATH ALTIMAILSERVERLIBS + "\openssl-3.0.16\out64\bin"

#define MyAppName "Altimail Server" 
#define MyAppNameShort "AltimailServer"
#define MyAppVersion "6.0"
#define MyAppVersionFull "6.0.0B2506.3"
#define MyAppVersionStd "6.0.0.2506"
#define MyAppPublisher "Ringwood Digital Solutions Group (Pty) Ltd"
#define MyAppPublisherUrl "https://www.ringwoodgroup.co.za"
#define MyAppSupportUrl "https://www.altimailserver.org"
#define MyAppUpdatesUrl "https://www.altimailserver.org"

#define CurrentYearVal GetDateTimeString('YYYY', '', '')

#include "section_setup.iss"
#include "section_custom_messages.iss"
#include "section_languages.iss"
#include "section_istool.iss"
#include "section_types.iss"
#include "section_components.iss"

#include "section_files_common.iss"

#include "section_files_64.iss"

#include "section_messages.iss"
#include "section_ini.iss"
#include "section_dirs.iss"
#include "section_run.iss"
#include "section_uninstallrun.iss"

#include "section_icons.iss"

#include "AltimailServerInnoExtension.iss"


<?php
	if (!defined('IN_WEBADMIN'))
		exit();
      
	if (altimailGetAdminLevel() != ADMIN_SERVER)
		altimailHackingAttempt(); // The user is not server administrator.
  
   $TestType = altimailGetVar("TestType", "");
   $AntiVirusSettings = $obBaseApp->Settings->AntiVirus;
   
   $result = "";
   $message = "";

   switch ($TestType)
   {
	  case "ClamWin":
		$Executable = altimailGetVar("Executable", "");
		$DatabaseFolder = altimailGetVar("DatabaseFolder", "");
		$result = $AntiVirusSettings->TestClamWinScanner($Executable, $DatabaseFolder, $message);
		break;
	  case "ClamAV":
		$Hostname = altimailGetVar("Hostname", "localhost");
		$Port = altimailGetVar("Port", 783);
		$result = $AntiVirusSettings->TestClamAVScanner($Hostname, $Port, $message);
		break;
	  case "External":
		$Executable = altimailGetVar("Executable", "");
		$ReturnValue = altimailGetVar("ReturnValue", 0);
		$result = $AntiVirusSettings->TestCustomerScanner($Executable, $ReturnValue, $message);
		break;
      default:
		die;
   }
     
   echo $result;
?>
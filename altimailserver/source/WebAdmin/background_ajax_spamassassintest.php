<?php
   if (!defined('IN_WEBADMIN'))
      exit();
      
   if (altimailGetAdminLevel() != ADMIN_SERVER)
   	altimailHackingAttempt(); // The user is not server administrator.
   
   $Hostname = altimailGetVar("Hostname", "localhost");
   $Port = altimailGetVar("Port", 783);
   
   $message = "";
   $AntiSpam = $obBaseApp->Settings->AntiSpam;
   $result = $AntiSpam->TestSpamAssassinConnection($Hostname, $Port, $message);
   
   echo $result;
?>
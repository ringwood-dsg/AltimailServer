<?php
   if (!defined('IN_WEBADMIN'))
      exit();

   if (altimailGetAdminLevel() != ADMIN_SERVER)
   	altimailHackingAttempt(); // The user is not server administrator.
   
   $action	            = altimailGetVar("action","");
   $relayid	   = altimailGetVar("relayid",0);
   
   if ($action == "edit")
      $obIncomingRelay     = $obBaseApp->Settings->IncomingRelays->ItemByDBID($relayid);
   elseif ($action == "add")
      $obIncomingRelay     = $obBaseApp->Settings->IncomingRelays->Add();
   elseif ($action == "delete")
   {
      $obBaseApp->Settings->IncomingRelays->DeleteByDBID($relayid);
      header("Location: index.php?page=incomingrelays");
   }
      
   // Fetch form
   $relayname		         = altimailGetVar("relayname","0");
   $relaylowerip	         = altimailGetVar("relaylowerip","0");
   $relayupperip	         = altimailGetVar("relayupperip","0");

   // Save the changes
   $obIncomingRelay->Name = $relayname;
   $obIncomingRelay->LowerIP = $relaylowerip;
   $obIncomingRelay->UpperIP = $relayupperip;

   $obIncomingRelay->Save();
   
   $relayid = $obIncomingRelay->ID;
   
   header("Location: index.php?page=incomingrelay&action=edit&relayid=$relayid");
?>


<?php
   if (!defined('IN_WEBADMIN'))
      exit();

   if (altimailGetAdminLevel() != ADMIN_SERVER)
   	altimailHackingAttempt(); // The user is not server administrator.
   
   $action	   = altimailGetVar("action","");
   $id	      = altimailGetVar("id",0);
   $Active	      = altimailGetVar("Active",0);
   $DNSHost	      = altimailGetVar("DNSHost","");
   $RejectMessage	= altimailGetVar("RejectMessage","");
   $Score	      = altimailGetVar("Score",0);
   
   $surblServers = $obBaseApp->Settings->AntiSpam->SURBLServers;
   
   if ($action == "edit")
      $surblServer     = $surblServers->ItemByDBID($id);
   elseif ($action == "add")
      $surblServer     = $surblServers->Add();
   elseif ($action == "delete")
   {
      $surblServers->DeleteByDBID($id);
      header("Location: index.php?page=surblservers");
   }

   // Save the changes
   $surblServer->Active = $Active;
   $surblServer->DNSHost = $DNSHost;
   $surblServer->RejectMessage = $RejectMessage;
   $surblServer->Score = $Score;   

   $surblServer->Save();
   
   header("Location: index.php?page=surblservers");
?>


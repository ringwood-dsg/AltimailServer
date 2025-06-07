<?php
   if (!defined('IN_WEBADMIN'))
      exit();

   if (altimailGetAdminLevel() != ADMIN_SERVER)
   	altimailHackingAttempt(); // The user is not server administrator.
   
   $action	   = altimailGetVar("action","");
   $id	      = altimailGetVar("id",0);
   $Active	      = altimailGetVar("Active",0);
   $DNSHost	      = altimailGetVar("DNSHost","");
   $ExpectedResult= altimailGetVar("ExpectedResult","");
   $RejectMessage	= altimailGetVar("RejectMessage","");
   $Score	      = altimailGetVar("Score",0);
   
   $dnsBlackLists = $obBaseApp->Settings->AntiSpam->DNSBlackLists;
   
   if ($action == "edit")
      $dnsBlackList     = $dnsBlackLists->ItemByDBID($id);
   elseif ($action == "add")
      $dnsBlackList     = $dnsBlackLists->Add();
   elseif ($action == "delete")
   {
      $dnsBlackLists->DeleteByDBID($id);
      header("Location: index.php?page=dnsblacklists");
   }

   // Save the changes
   $dnsBlackList->Active = $Active;
   $dnsBlackList->DNSHost = $DNSHost;
   $dnsBlackList->ExpectedResult = $ExpectedResult;
   $dnsBlackList->RejectMessage = $RejectMessage;
   $dnsBlackList->Score = $Score;   

   $dnsBlackList->Save();
   
   $id = $dnsBlackList->ID;
   
   header("Location: index.php?page=dnsblacklists");
?>


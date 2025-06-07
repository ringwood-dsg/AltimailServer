<?php
   if (!defined('IN_WEBADMIN'))
      exit();

   if (altimailGetAdminLevel() != 2)
   	altimailHackingAttempt(); // Only server admins can change this.

   $iphomeid 	= altimailGetVar("iphomeid",0);
   $iphomeaddress	= altimailGetVar("iphomeaddress",0);
   $action	   = altimailGetVar("action","");
   
   $obSettings	= $obBaseApp->Settings();
   $obIPHomes  = $obSettings->IPHomes;

   if ($action == "edit")
      $obIPHome = $obIPHomes->ItemByDBID($iphomeid);
   elseif ($action == "add")
      $obIPHome = $obIPHomes->Add();
   elseif ($action == "delete")
   {
      $obIPHomes->DeleteByDBID($iphomeid);
      header("Location: index.php?page=multihoming");
      exit();
   }

   $obIPHome->IPAddress = $iphomeaddress;
   $obIPHome->Save();
   
   $iphomeid = $obIPHome->ID;
   
   header("Location: index.php?page=iphome&action=edit&iphomeid=$iphomeid");

?>


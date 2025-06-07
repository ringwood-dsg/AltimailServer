<?php
   if (!defined('IN_WEBADMIN'))
      exit();

   if (altimailGetAdminLevel() != 2)
   	altimailHackingAttempt(); // Only server admins can change this.
   
   $ID 		= altimailGetVar("ID",0);
   $action	      = altimailGetVar("action","");
   
   $obWhiteListAddresses	= $obBaseApp->Settings()->AntiSpam()->WhiteListAddresses;

   if ($action == "edit")
      $obAddress = $obWhiteListAddresses->ItemByDBID($ID);  
   elseif ($action == "add")
      $obAddress = $obWhiteListAddresses->Add();  
   elseif ($action == "delete")
   {
      $obWhiteListAddresses->DeleteByDBID($ID);  
      header("Location: index.php?page=whitelistaddresses");
      exit();
   }
      
   $LowerIPAddress = altimailGetVar("LowerIPAddress",0);
   $UpperIPAddress = altimailGetVar("UpperIPAddress",0);
   $EmailAddress   = altimailGetVar("EmailAddress",0);
   $Description    = altimailGetVar("Description",0);
   
   if ($LowerIPAddress == "")
      $LowerIPAddress = "0.0.0.0";
   
   if ($UpperIPAddress == "")
      $UpperIPAddress = "255.255.255.255";

   if ($EmailAddress == "")
      $EmailAddress = "*";

   $obAddress->LowerIPAddress  = $LowerIPAddress;
   $obAddress->UpperIPAddress  = $UpperIPAddress;
   $obAddress->EmailAddress    = $EmailAddress;
   $obAddress->Description     = $Description;
   
   $obAddress->Save();
   
   
   
   header("Location: index.php?page=whitelistaddresses");
?>


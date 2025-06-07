<?php
   if (!defined('IN_WEBADMIN'))
      exit();

   $distributionlistid 	= altimailGetVar("distributionlistid",0);
   $recipientid	      = altimailGetVar("recipientid",0);
   $domainid	         = altimailGetVar("domainid",0,true);
   $action	            = altimailGetVar("action","");
   $recipientaddress    = altimailGetVar("recipientaddress","");
   
   if (altimailGetAdminLevel() == 0)
      altimailHackingAttempt();
   
   if (altimailGetAdminLevel() == 1 && $domainid != altimailGetDomainID())
   	altimailHackingAttempt(); // Domain admin but not for this domain.

   $obDomain	= $obBaseApp->Domains->ItemByDBID($domainid);
   $obList = $obDomain->DistributionLists->ItemByDBID($distributionlistid);

   if ($action == "edit")
      $obRecipient = $obList->Recipients->ItemByDBID($recipientid);
   elseif ($action == "add")
      $obRecipient = $obList->Recipients->Add();
   elseif ($action == "delete")
   {
      $obRecipient = $obList->Recipients->ItemByDBID($recipientid);
      $obRecipient->Delete();
      
      header("Location: index.php?page=distributionlist_recipients&domainid=$domainid&distributionlistid=$distributionlistid");
      exit();
      
   }
   
   $obRecipient->RecipientAddress = $recipientaddress;
   $obRecipient->Save();
   
   $recipientid = $obRecipient->ID;
   
   header("Location: index.php?page=distributionlist_recipient&action=edit&domainid=$domainid&distributionlistid=$distributionlistid&recipientid=$recipientid");

?>


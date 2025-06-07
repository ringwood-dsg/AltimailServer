<?php
   if (!defined('IN_WEBADMIN'))
      exit();

   if (altimailGetAdminLevel() != ADMIN_SERVER)
   	altimailHackingAttempt(); // Only server can change these settings.      
      
   $domainid	= altimailGetVar("domainid",0,true);
   $aliasid	   = altimailGetVar("aliasid",0);
   $action	   = altimailGetVar("action","");
   $aliasname  = altimailGetVar("aliasname","");

   $obDomain	= $obBaseApp->Domains->ItemByDBID($domainid);
    
   if ($action == "add")
   {
      $alias =  $obDomain->DomainAliases->Add();
      $alias->AliasName = $aliasname;
      $alias->Save();
   }
   elseif ($action == "delete")
   {
      $obDomain->DomainAliases->DeleteByDBID($aliasid);
   }
   
   header("Location: index.php?page=domain&action=edit&domainid=$domainid");
?>


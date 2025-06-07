<?php



   if (!defined('IN_WEBADMIN'))
      exit();

   if (altimailGetAdminLevel() != ADMIN_SERVER)
   	altimailHackingAttempt(); // Only server can change these settings.      
      
   $id	            = altimailGetVar("id",0);
   $wildcard	      = altimailGetVar("wildcard","");
   $description	   = altimailGetVar("description","");
   
   $action	   = altimailGetVar("action","");
  
   $obSettings	= $obBaseApp->Settings();
   $obAntivirus	= $obSettings->AntiVirus();
   $blockedAttachments = $obAntivirus->BlockedAttachments;
   
   
   if ($action == "add")
   {
      $blockedAttachment = $blockedAttachments->Add();
      
      $blockedAttachment->Wildcard = $wildcard;
      $blockedAttachment->Description = $description;
      $blockedAttachment->Save();
   }
   else if ($action == "delete")
   {
      $blockedAttachments->DeleteByDBID($id);
   }
   else if ($action == "edit")
   {
   
      $blockedAttachment = $blockedAttachments->ItemByDBID($id);
      
      
      $blockedAttachment->Wildcard = $wildcard;
      $blockedAttachment->Description = $description;
      $blockedAttachment->Save();      
   }
   
   header("Location: index.php?page=smtp_antivirus");
   
   
?>


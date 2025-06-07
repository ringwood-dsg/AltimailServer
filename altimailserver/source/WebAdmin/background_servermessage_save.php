<?php
   if (!defined('IN_WEBADMIN'))
      exit();

   if (altimailGetAdminLevel() != ADMIN_SERVER)
   	altimailHackingAttempt(); // The user is not server administrator.
   
   $messageid	      = altimailGetVar("messageid",0);
   $messagename	   = altimailGetVar("messagename",0);
   $messagetext	   = altimailGetVar("messagetext",0);
   
   $obServerMessage     = $obBaseApp->Settings->ServerMessages->ItemByDBID($messageid);
   
   if ($obServerMessage->Name != $messagename)
      altimailHackingAttempt();
      
   $obServerMessage->Text = $messagetext;
   $obServerMessage->Save();
   
   header("Location: index.php?page=servermessage&messageid=$messageid");
?>


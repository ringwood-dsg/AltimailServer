<?php
   if (!defined('IN_WEBADMIN'))
      exit();

   if (altimailGetAdminLevel() != ADMIN_SERVER)
   	altimailHackingAttempt(); // The user is not server administrator.
   
   $action	            = altimailGetVar("action","");
   $securityrangeid	   = altimailGetVar("securityrangeid","");
   
   if ($action == "edit")
      $obSecurityRange     = $obBaseApp->Settings->SecurityRanges->ItemByDBID($securityrangeid);
   elseif ($action == "add")
      $obSecurityRange     = $obBaseApp->Settings->SecurityRanges->Add();
   elseif ($action == "delete")
   {
      $obBaseApp->Settings->SecurityRanges->DeleteByDBID($securityrangeid);
      header("Location: index.php?page=securityranges");
   }
      
   // Fetch form
   $securityrangename		= altimailGetVar("securityrangename","");
   $securityrangepriority	= altimailGetVar("securityrangepriority","0");
   $securityrangelowerip	= altimailGetVar("securityrangelowerip","0");
   $securityrangeupperip	= altimailGetVar("securityrangeupperip","0");
   
   $allowsmtpconnections	= altimailGetVar("allowsmtpconnections","0");
   $allowpop3connections	= altimailGetVar("allowpop3connections","0");
   $allowimapconnections	= altimailGetVar("allowimapconnections","0");
   
   $allowlocaltolocal		= altimailGetVar("allowlocaltolocal","0");
   $allowlocaltoremote		= altimailGetVar("allowlocaltoremote","0");
   $allowremotetolocal		= altimailGetVar("allowremotetolocal","0");
   $allowremotetoremote		= altimailGetVar("allowremotetoremote","0");

   $enablespamprotection	= altimailGetVar("enablespamprotection","0");
   $EnableAntiVirus         = altimailGetVar("EnableAntiVirus","0");
   
   $IsForwardingRelay	   = altimailGetVar("IsForwardingRelay","0");
   $RequireSSLTLSForAuth   = altimailGetVar("RequireSSLTLSForAuth","0");
   
   $Expires	   = altimailGetVar("Expires",0);
   $ExpiresTime	   = altimailGetVar("ExpiresTime","");
   
   // Save the changes
   $obSecurityRange->Name = $securityrangename;
   $obSecurityRange->Priority = $securityrangepriority;
   $obSecurityRange->LowerIP = $securityrangelowerip;
   $obSecurityRange->UpperIP = $securityrangeupperip;
   
   $obSecurityRange->AllowSMTPConnections = $allowsmtpconnections;
   $obSecurityRange->AllowPOP3Connections = $allowpop3connections;
   $obSecurityRange->AllowIMAPConnections = $allowimapconnections;
   
   $obSecurityRange->AllowDeliveryFromLocalToLocal = $allowlocaltolocal;
   $obSecurityRange->AllowDeliveryFromLocalToRemote = $allowlocaltoremote;
   $obSecurityRange->AllowDeliveryFromRemoteToLocal = $allowremotetolocal;
   $obSecurityRange->AllowDeliveryFromRemoteToRemote = $allowremotetoremote;

   $obSecurityRange->RequireSMTPAuthLocalToLocal = altimailGetVar("RequireSMTPAuthLocalToLocal", 0);
   $obSecurityRange->RequireSMTPAuthLocalToExternal = altimailGetVar("RequireSMTPAuthLocalToExternal", 0);
   $obSecurityRange->RequireSMTPAuthExternalToLocal = altimailGetVar("RequireSMTPAuthExternalToLocal", 0);
   $obSecurityRange->RequireSMTPAuthExternalToExternal = altimailGetVar("RequireSMTPAuthExternalToExternal", 0);

   $obSecurityRange->EnableSpamProtection = $enablespamprotection;
   $obSecurityRange->EnableAntiVirus = $EnableAntiVirus;
   $obSecurityRange->IsForwardingRelay = $IsForwardingRelay;
   $obSecurityRange->RequireSSLTLSForAuth = $RequireSSLTLSForAuth;
   
   $obSecurityRange->Expires = $Expires;
   $obSecurityRange->ExpiresTime = $ExpiresTime;

   $obSecurityRange->Save();
   
   $securityrangeid = $obSecurityRange->ID;
   
   header("Location: index.php?page=securityrange&action=edit&securityrangeid=$securityrangeid");
?>


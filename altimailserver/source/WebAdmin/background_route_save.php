<?php

   if (!defined('IN_WEBADMIN'))
      exit();

   if (altimailGetAdminLevel() != 2)
   	altimailHackingAttempt(); // Domain admin but not for this domain.
   
   $action	            = altimailGetVar("action","");
   $routeid	   = altimailGetVar("routeid","");
   
   if ($action == "edit")
      $obRoute     = $obBaseApp->Settings->Routes->ItemByDBID($routeid);
   elseif ($action == "add")
      $obRoute    = $obBaseApp->Settings->Routes->Add();
   elseif ($action == "delete")
   {
      $obBaseApp->Settings->Routes->DeleteByDBID($routeid);
      header("Location: index.php?page=routes");
      exit();
   }
   
   
   $routedomainname  = altimailGetVar("routedomainname","");
   $routetargetsmtphost   = altimailGetVar("routetargetsmtphost","0");
   $routetargetsmtpport   = altimailGetVar("routetargetsmtpport","0");
   $TreatSenderAsLocalDomain   = altimailGetVar("TreatSenderAsLocalDomain","0");
   $TreatRecipientAsLocalDomain   = altimailGetVar("TreatRecipientAsLocalDomain","0");
   
   $routenumberoftries        = altimailGetVar("routenumberoftries","0");
   $routemminutesbetweentry   = altimailGetVar("routemminutesbetweentry","0");
   $routerequiresauth   = altimailGetVar("routerequiresauth","0");
   $routeauthusername   = altimailGetVar("routeauthusername","0");
   $routeauthpassword   = altimailGetVar("routeauthpassword","0");
   $ConnectionSecurity   = altimailGetVar("ConnectionSecurity","0");
   
   $obRoute->DomainName = $routedomainname;
   $obRoute->TargetSMTPHost = $routetargetsmtphost;
   $obRoute->TargetSMTPPort = $routetargetsmtpport;
   $obRoute->TreatSenderAsLocalDomain = $TreatSenderAsLocalDomain;
   $obRoute->TreatRecipientAsLocalDomain = $TreatRecipientAsLocalDomain;
   
   $obRoute->NumberOfTries = $routenumberoftries;
   $obRoute->MinutesBetweenTry = $routemminutesbetweentry;
   $obRoute->RelayerRequiresAuth = $routerequiresauth;
   $obRoute->RelayerAuthUsername = $routeauthusername;
   
   $obRoute->AllAddresses = altimailGetVar("AllAddresses","0");
   
   $obRoute->ConnectionSecurity = $ConnectionSecurity;
   
   if ($routeauthpassword != "")
      $obRoute->SetRelayerAuthPassword($routeauthpassword);

   $obRoute->Save();
   
   $routeid = $obRoute->ID;
   
   header("Location: index.php?page=route&action=edit&routeid=$routeid");
?>


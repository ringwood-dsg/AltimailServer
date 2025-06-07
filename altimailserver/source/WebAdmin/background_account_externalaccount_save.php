<?php
   if (!defined('IN_WEBADMIN'))
      exit();

   $domainid	= altimailGetVar("domainid",0, true);
   $accountid 	= altimailGetVar("accountid",0,true);
   $faid 		= altimailGetVar("faid",0, true);
   $action	   = altimailGetVar("action","");
   
   if (altimailGetAdminLevel() == 0 && ($accountid != altimailGetAccountID() || $domainid != altimailGetDomainID()))
      altimailHackingAttempt();

	if (altimailGetAdminLevel() == 1 && $domainid != altimailGetDomainID())
		altimailHackingAttempt(); // Domain admin but not for this domain.
	
	$obDomain	= $obBaseApp->Domains->ItemByDBID($domainid);
	$obAccount  = $obDomain->Accounts->ItemByDBID($accountid);  
	$obFetchAccounts = $obAccount->FetchAccounts();

   if ($action == "edit")
      $obFA = $obFetchAccounts->ItemByDBID($faid);  
   elseif ($action == "add")
      $obFA = $obFetchAccounts->Add();  
   elseif ($action == "delete")
   {
      $obFetchAccounts->DeleteByDBID($faid);  
      header("Location: index.php?page=account_externalaccounts&domainid=$domainid&accountid=$accountid");
      exit();
   }
   elseif ($action == "downloadnow")
   {
      $obFA = $obFetchAccounts->ItemByDBID($faid); 
      $obFA->DownloadNow();
      header("Location: index.php?page=account_externalaccounts&domainid=$domainid&accountid=$accountid");
      exit();       
   }
   
   $DaysToKeepMessages      = altimailGetVar("DaysToKeepMessages",0);
   $DaysToKeepMessagesValue = altimailGetVar("DaysToKeepMessagesValue",0);
   
   $obFA->Enabled               = altimailGetVar("Enabled",0);
   $obFA->Name                  = altimailGetVar("Name",0);
   $obFA->MinutesBetweenFetch   = altimailGetVar("MinutesBetweenFetch",0);
   $obFA->Port                  = altimailGetVar("Port",0);
   $obFA->MIMERecipientHeaders  = altimailGetVar("MIMERecipientHeaders","To,CC,X-RCPT-To,X-Envelope-To");
   if (strlen($obFA->MIMERecipientHeaders) > 0)
      $obFA->ProcessMIMERecipients = altimailGetVar("ProcessMIMERecipients",0);
   else
      $obFA->ProcessMIMERecipients = 0;
   $obFA->ProcessMIMEDate       = altimailGetVar("ProcessMIMEDate",0);
   $obFA->ServerAddress         = altimailGetVar("ServerAddress",0);
   $obFA->ServerType            = altimailGetVar("ServerType",0);
   $obFA->Username              = altimailGetVar("Username",0);
   $obFA->UseAntiVirus          = altimailGetVar("UseAntiVirus",0);
   $obFA->UseAntiSpam           = altimailGetVar("UseAntiSpam",0);
   if ($obFA->ProcessMIMERecipients != 0)
      $obFA->EnableRouteRecipients = altimailGetVar("EnableRouteRecipients",0);
   else
      $obFA->EnableRouteRecipients = 0;
   $obFA->ConnectionSecurity 	= altimailGetVar("ConnectionSecurity",0);
   
   if (strlen($DaysToKeepMessages) > 0 && $DaysToKeepMessages <= 0)
      $obFA->DaysToKeepMessages = $DaysToKeepMessages; 
   else 
      $obFA->DaysToKeepMessages = $DaysToKeepMessagesValue; 
   
   $Password = altimailGetVar("Password",0);
   
   if (strlen($Password) > 0)
      $obFA->Password = $Password;
   
   $obFA->Save();
   
   $faid = $obFA->ID;
   
   
   
   header("Location: index.php?page=account_externalaccount&action=edit&domainid=$domainid&accountid=$accountid&faid=$faid");
?>


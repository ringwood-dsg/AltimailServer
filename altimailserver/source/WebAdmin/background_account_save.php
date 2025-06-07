<?php

   if (!defined('IN_WEBADMIN'))
      exit();

   $domainid	= altimailGetVar("domainid",0,true);
   $accountid	= altimailGetVar("accountid",0,true);
   $action	   = altimailGetVar("action","");
   
   $obDomain	= $obBaseApp->Domains->ItemByDBID($domainid);
   
   if (altimailGetAdminLevel() == 0 && ($accountid != altimailGetAccountID() || $action != "edit"))
      altimailHackingAttempt();
   
   if (altimailGetAdminLevel() == 1 && $domainid != altimailGetDomainID())
   	altimailHackingAttempt(); // Domain admin but not for this domain.
   	
   $accountpassword  = altimailGetVar("accountpassword","");
   $accountmaxsize   = altimailGetVar("accountmaxsize","0");
   $accountaddress   = altimailGetVar("accountaddress","") . "@". $obDomain->Name;
   $accountactive    = altimailGetVar("accountactive","0");
   $accountadminlevel  = altimailGetVar("accountadminlevel","0");
   $PersonFirstName  = altimailGetVar("PersonFirstName","0");
   $PersonLastName   = altimailGetVar("PersonLastName","0");
   
   $vacationmessageon  = altimailGetVar("vacationmessageon","");
   $vacationsubject   = altimailGetVar("vacationsubject","0");
   $vacationmessage   =   altimailGetVar("vacationmessage","");
   $vacationmessageexpires   =   altimailGetVar("vacationmessageexpires","0");
   $vacationmessageexpiresdate   =   altimailGetVar("vacationmessageexpiresdate","2001-01-01");
   $vacationmessageabortspamflagged = altimailGetVar("vacationmessageabortspamflagged","0");
   
   $forwardenabled  = altimailGetVar("forwardenabled","0");
   $forwardaddress   = altimailGetVar("forwardaddress","");
   $forwardkeeporiginal   =   altimailGetVar("forwardkeeporiginal","0");
   $forwardabortspamflagged = altimailGetVar("forwardabortspamflagged","0");
   
   $adenabled   = altimailGetVar("adenabled","");
   $addomain    = altimailGetVar("addomain","0");
   $adusername  =   altimailGetVar("adusername","");
  
   $SignatureEnabled     = altimailGetVar("SignatureEnabled","0");
   $SignatureHTML        = altimailGetVar("SignatureHTML","");
   $SignaturePlainText   =   altimailGetVar("SignaturePlainText","0");

  
   if ($action == "edit")
      $obAccount = $obDomain->Accounts->ItemByDBID($accountid);  
   elseif ($action == "add")
      $obAccount = $obDomain->Accounts->Add();  
   elseif ($action == "delete")
   {
      $obAccount = $obDomain->Accounts->DeleteByDBID($accountid);  
      header("Location: index.php?page=accounts&domainid=$domainid");
      exit();
   }
  
   // If this is the current user, we need to update the session password.
   if ($action == "edit" &&
       $accountid == altimailGetAccountID())
   {
      if ($accountpassword != "")
         $_SESSION['session_password'] = $accountpassword;  
   }
   
   if ($accountpassword != "")
      $obAccount->Password = "$accountpassword";
   
   $obAccount->PersonFirstName = $PersonFirstName;
   $obAccount->PersonLastName = $PersonLastName;
   
   $obAccount->VacationMessageIsOn = $vacationmessageon == "1";
   $obAccount->VacationSubject     = $vacationsubject;
   $obAccount->VacationMessage     = $vacationmessage;
   $obAccount->VacationMessageExpires      = $vacationmessageexpires;
   $obAccount->VacationMessageExpiresDate  = $vacationmessageexpiresdate;
   $obAccount->VacationMessageAbortSpamFlagged = $vacationmessageabortspamflagged == "1";

   $obAccount->ForwardEnabled		= $forwardenabled == "1";
   $obAccount->ForwardAddress		= $forwardaddress;
   $obAccount->ForwardKeepOriginal	= $forwardkeeporiginal == "1";
   $obAccount->ForwardAbortSpamFlagged = $forwardabortspamflagged == "1";

   $obAccount->SignatureEnabled		= $SignatureEnabled == "1";
   $obAccount->SignatureHTML		   = $SignatureHTML;
   $obAccount->SignaturePlainText	= $SignaturePlainText;
     
   
   if (altimailGetAdminLevel() != ADMIN_USER)
   {
      $accountmaxsize = str_replace(".", ",", $accountmaxsize);

      // Save other properties
      $obAccount->Address = $accountaddress;
      $obAccount->MaxSize = $accountmaxsize;
      $obAccount->Active  = $accountactive;
      
      $obAccount->IsAD         = $adenabled == "1";
      $obAccount->ADDomain     = $addomain;
      $obAccount->ADUsername   = $adusername;   
      
      if (altimailGetAdminLevel() == 1)
      {
         // The web user is domain administrator. Don't allow him
         // to change the user to server admin, unless he already
         // is this.
         
         if ($accountadminlevel == 0 || $accountadminlevel == 1)
         {
            $obAccount->AdminLevel = $accountadminlevel;
         }
      }
      else if (altimailGetAdminLevel() == 2)
      {
         // The web user is server administrator. Allow any change
         $obAccount->AdminLevel = $accountadminlevel;
      }
   }
   
   
   $obAccount->Save();
   $accountid = $obAccount->ID;
   
   header("Location: index.php?page=account&action=edit&domainid=$domainid&accountid=$accountid");
   

?>


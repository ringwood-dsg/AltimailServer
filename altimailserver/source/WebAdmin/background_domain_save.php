<?php
   if (!defined('IN_WEBADMIN'))
      exit();

   $domainid	= altimailGetVar("domainid",0,true);
   $action	   = altimailGetVar("action","");
   $domainname     = altimailGetVar("domainname","");
   $domainactive   = altimailGetVar("domainactive","0");
   $domainpostmaster   =   altimailGetVar("domainpostmaster","");
   $domainmaxsize   = altimailGetVar("domainmaxsize","0");
   $domainmaxmessagesize   = altimailGetVar("domainmaxmessagesize","0");
   $domainplusaddressingenabled = altimailGetVar("domainplusaddressingenabled","0");
   $domainplusaddressingcharacter = altimailGetVar("domainplusaddressingcharacter","+");
   $domainantispamenablegreylisting = altimailGetVar("domainantispamenablegreylisting","0");
   
   $SignatureEnabled   = altimailGetVar("SignatureEnabled","0");
   $SignatureHTML  	  = altimailGetVar("SignatureHTML","");
   $SignaturePlainText = altimailGetVar("SignaturePlainText","");
   $SignatureMethod    = altimailGetVar("SignatureMethod","1");
   
   $AddSignaturesToLocalMail = altimailGetVar("AddSignaturesToLocalMail","0");
   $AddSignaturesToReplies   = altimailGetVar("AddSignaturesToReplies","0");
   
   $MaxAccountSize       = altimailGetVar("MaxAccountSize","0");
   
   $MaxNumberOfAccounts            = altimailGetVar("MaxNumberOfAccounts","0");
   $MaxNumberOfAliases             = altimailGetVar("MaxNumberOfAliases","0");
   $MaxNumberOfDistributionLists   = altimailGetVar("MaxNumberOfDistributionLists","0");
   
   $MaxNumberOfAccountsEnabled          = altimailGetVar("MaxNumberOfAccountsEnabled","0");
   $MaxNumberOfAliasesEnabled           = altimailGetVar("MaxNumberOfAliasesEnabled","0");
   $MaxNumberOfDistributionListsEnabled = altimailGetVar("MaxNumberOfDistributionListsEnabled","0");
   
   $DKIMSignEnabled = altimailGetVar("DKIMSignEnabled", "0");
   $DKIMSignAliasesEnabled = altimailGetVar("DKIMSignAliasesEnabled", "0");
   $DKIMPrivateKeyFile = altimailGetVar("DKIMPrivateKeyFile", "");
   $DKIMSelector = altimailGetVar("DKIMSelector", "");
   
   $DKIMHeaderCanonicalizationMethod = altimailGetVar("DKIMHeaderCanonicalizationMethod", "2");
   $DKIMBodyCanonicalizationMethod = altimailGetVar("DKIMBodyCanonicalizationMethod", "2");
   $DKIMSigningAlgorithm = altimailGetVar("DKIMSigningAlgorithm", "2");
   
   if ($domainactive == "")
      $domainactive = 0;
   
   if (altimailGetAdminLevel() == 1 && ($domainid != altimailGetDomainID() || $action != "edit"))
   	altimailHackingAttempt(); // Domain admin but not for this domain.   

   if ($action == "edit")   
      $obDomain	= $obBaseApp->Domains->ItemByDBID($domainid);
   elseif ($action == "add")
      $obDomain	= $obBaseApp->Domains->Add();
   elseif ($action == "delete")
   {
      $obDomain	= $obBaseApp->Domains->ItemByDBID($domainid);
      $obDomain->Delete();
      
      header("Location: index.php?page=domains");
      exit();
      
   }
      
   $obDomain->Postmaster = $domainpostmaster;
   
   $obDomain->PlusAddressingEnabled = $domainplusaddressingenabled == "1";
   $obDomain->PlusAddressingCharacter = $domainplusaddressingcharacter;
   $obDomain->AntiSpamEnableGreylisting = $domainantispamenablegreylisting == "1";
   
   $obDomain->SignatureEnabled   = $SignatureEnabled == "1";
   $obDomain->SignaturePlainText = $SignaturePlainText;
   $obDomain->SignatureHTML      = $SignatureHTML;
   $obDomain->SignatureMethod    = $SignatureMethod;
      
   $obDomain->AddSignaturesToLocalMail = $AddSignaturesToLocalMail;
   $obDomain->AddSignaturesToReplies   = $AddSignaturesToReplies;
   
   $obDomain->DKIMSignEnabled = $DKIMSignEnabled;
   if ($obDomain->DomainAliases->Count > 0){
      $obDomain->DKIMSignAliasesEnabled = $DKIMSignAliasesEnabled;
   }
   else {
      $obDomain->DKIMSignAliasesEnabled = 0;
   }
   $obDomain->DKIMPrivateKeyFile = $DKIMPrivateKeyFile;
   $obDomain->DKIMSelector = $DKIMSelector;
   $obDomain->DKIMHeaderCanonicalizationMethod = $DKIMHeaderCanonicalizationMethod;
   $obDomain->DKIMBodyCanonicalizationMethod = $DKIMBodyCanonicalizationMethod;
   $obDomain->DKIMSigningAlgorithm = $DKIMSigningAlgorithm;
   
   if (altimailGetAdminLevel() == 2)
   {
      // Save other properties
      $obDomain->Active = $domainactive;
      $obDomain->Name = $domainname;
      $obDomain->MaxSize = $domainmaxsize;
      $obDomain->MaxMessageSize = $domainmaxmessagesize;
      $obDomain->MaxAccountSize      = $MaxAccountSize;
      
      $obDomain->MaxNumberOfAccounts = $MaxNumberOfAccounts;
      $obDomain->MaxNumberOfAliases  = $MaxNumberOfAliases;
      $obDomain->MaxNumberOfDistributionLists = $MaxNumberOfDistributionLists;

      $obDomain->MaxNumberOfAccountsEnabled = $MaxNumberOfAccountsEnabled;
      $obDomain->MaxNumberOfAliasesEnabled  = $MaxNumberOfAliasesEnabled;
      $obDomain->MaxNumberOfDistributionListsEnabled = $MaxNumberOfDistributionListsEnabled;
   }

   $obDomain->Save();
   $domainid = $obDomain->ID;
   
   header("Location: index.php?page=domain&action=edit&domainid=$domainid");
?>


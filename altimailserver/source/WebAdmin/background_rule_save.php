<?php

   if (!defined('IN_WEBADMIN'))
      exit();

   $action	   = altimailGetVar("action","");
   $domainid   = altimailGetVar("domainid", 0, true);
   $accountid  = altimailGetVar("accountid", 0, true);
   $ruleid     = altimailGetVar("ruleid", 0);
   $criteriaid = altimailGetVar("criteriaid", 0);
   $actionid   = altimailGetVar("actionid", 0);
   $savetype   = altimailGetVar("savetype", 0);
      
   if (!GetHasRuleAccess($domainid, $accountid))
   	altimailHackingAttempt();

   include "include/rule_strings.php";
      
   $rule_link = "index.php?page=rule&action=edit&domainid=$domainid&accountid=$accountid&ruleid=$ruleid";
   
   if ($action == "add" && $savetype == "rule")
   {
      if ($domainid == 0)
         $rule = $obBaseApp->Rules->Add();
      else
         $rule = $obBaseApp->Domains->ItemByDBID($domainid)->Accounts->ItemByDBID($accountid)->Rules->Add();
   }
   else
   {
      if ($domainid == 0)
         $rule = $obBaseApp->Rules->ItemByDBID($ruleid);
      else
         $rule = $obBaseApp->Domains->ItemByDBID($domainid)->Accounts->ItemByDBID($accountid)->Rules->ItemByDBID($ruleid);
   }  
 

   if ($action == "delete")
   {
   
      if ($savetype == "criteria")
         $rule->Criterias->ItemByDBID($criteriaid)->Delete();
      else if ($savetype == "action")
         $rule->Actions->ItemByDBID($actionid)->Delete();
      else if ($savetype == "rule")
         $rule->Delete();
      
      if ($savetype == "criteria" || $savetype == "action")
         header("Location: $rule_link");
      else
      {
         if ($domainid == 0)
            header("Location: index.php?page=rules");
         else
            header("Location: index.php?page=account&action=edit&accountid=$accountid&domainid=$domainid");
      }
         
      die;
   }
   
   if ($savetype == "criteria")
   {
      
      if ($action == "edit")
         $criteria = $rule->Criterias->ItemByDBID($criteriaid);
      else if ($action == "add")
      {
         $criteria = $rule->Criterias->Add();
      }
   
      $criteria->UsePredefined = altimailGetVar("UsePredefined", 0);
      $criteria->PredefinedField = altimailGetVar("PredefinedField", 0);
      $criteria->MatchType = altimailGetVar("MatchType", 0);
      $criteria->MatchValue = altimailGetVar("MatchValue", 0);
      $criteria->HeaderField = altimailGetVar("HeaderField", 0);
      
      $criteria->Save();
      
      $rule->Save();
    
      header("Location: $rule_link");
      die;
   }
   else if ($savetype == "action")
   {
   
      if ($action == "edit")
         $actionObj = $rule->Actions->ItemByDBID($actionid);
      else if ($action == "add")
         $actionObj = $rule->Actions->Add();
   
      $type = altimailGetVar("Type", 0);
      
      if (altimailGetAdminLevel() != ADMIN_SERVER)
      {
         if ($type != eRADeleteEmail && 
             $type != eRAForwardEmail &&
             $type != eRAReply &&
             $type != eRAMoveToImapFolder &&
             $type != eRAStopRuleProcessing &&
             $type != eRASetHeaderValue)
         {
            altimailHackingAttempt();
         }  
      }
   
      $actionObj->To = altimailGetVar("To", "");
      $actionObj->IMAPFolder = altimailGetVar("IMAPFolder", "");
      $actionObj->ScriptFunction = altimailGetVar("ScriptFunction", "");
      $actionObj->FromName = altimailGetVar("FromName", "");
      $actionObj->FromAddress = altimailGetVar("FromAddress", "");
      $actionObj->Subject = altimailGetVar("Subject", "");
      $actionObj->Body = altimailGetVar("Body", "");
      $actionObj->HeaderName = altimailGetVar("HeaderName", "");
      
      $replyabortspamflagged = altimailGetVar("replyabortspamflagged", "0");
      $forwardabortspamflagged = altimailGetVar("forwardabortspamflagged", "0");
      
	  switch ($type)
	  {
		case eRASetHeaderValue:
			$actionObj->Value = altimailGetVar("Value", "");
			break;
		case eRABindToAddress:
			$actionObj->Value = altimailGetVar("BindToAddress", "");
			break;
		case eRAForwardEmail:
			$actionObj->AbortSpamFlagged = $forwardabortspamflagged == 1;
			break;
		case eRAReply:
			$actionObj->AbortSpamFlagged = $replyabortspamflagged == 1;
			break;
	  }
      
	  $actionObj->Type = $type;

      $actionObj->Save();
      
      $rule->Save();
      
      header("Location: $rule_link");   
      die;
   }
   else if ($savetype == "rule")
   {
      $rule->Name = altimailGetVar("Name", "");
      $rule->Active = altimailGetVar("Active", "") == "1";
      $rule->UseAND = altimailGetVar("UseAND", "") == "1";
      $rule->Save();
      
      $ruleid = $rule->ID;
      
      // can't re-use rule_link since the rule id might be new (if add)
      header("Location: index.php?page=rule&action=edit&domainid=$domainid&accountid=$accountid&ruleid=$ruleid");   
      die;
   }

   
?>


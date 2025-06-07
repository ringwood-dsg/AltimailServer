<?php
if (!defined('IN_WEBADMIN'))
   exit();

if (altimailGetAdminLevel() != ADMIN_SERVER)
	altimailHackingAttempt();

$obSettings	= $obBaseApp->Settings();

$action	   = altimailGetVar("action","");

if($action == "save")
{
	$obSettings->AutoBanOnLogonFailure= altimailGetVar("AutoBanOnLogonFailure",0);
   $obSettings->MaxInvalidLogonAttempts= altimailGetVar("MaxInvalidLogonAttempts",0);
   $obSettings->MaxInvalidLogonAttemptsWithin= altimailGetVar("MaxInvalidLogonAttemptsWithin",0);
   $obSettings->AutoBanMinutes= altimailGetVar("AutoBanMinutes",0);
	
}

$AutoBanOnLogonFailure = $obSettings->AutoBanOnLogonFailure;     
$MaxInvalidLogonAttempts = $obSettings->MaxInvalidLogonAttempts;     
$MaxInvalidLogonAttemptsWithin = $obSettings->MaxInvalidLogonAttemptsWithin;     
$AutoBanMinutes = $obSettings->AutoBanMinutes;     
?>

<h1><?php EchoTranslation("Auto-ban")?></h1>

<form action="index.php" method="post" onSubmit="return formCheck(this);">
   <?php
      PrintHiddenCsrfToken();
      PrintHidden("page", "autoban");
      PrintHidden("action", "save");
   ?>
   
   <div class="tabber">
      <div class="tabbertab">
         <h2><?php EchoTranslation("General")?></h2>       
   
      	<table border="0" width="100%" cellpadding="5">
            <tr>
               <th width="30%"></th>
               <th width="70%"></th>
            </tr>            
         <?php
            PrintCheckboxRow("AutoBanOnLogonFailure", "Enabled", $AutoBanOnLogonFailure);
            PrintPropertyEditRow("MaxInvalidLogonAttempts", "Max invalid logon attempts", $MaxInvalidLogonAttempts, 4, "number");
            PrintPropertyEditRow("MaxInvalidLogonAttemptsWithin", "Minutes before reset", $MaxInvalidLogonAttemptsWithin, 4, "number");
            PrintPropertyEditRow("AutoBanMinutes", "Minutes to auto-ban", $AutoBanMinutes, 4, "number");
            
         ?>
      	</table>
      </div>
   </div>
   <?php
      PrintSaveButton();
   ?>
</form>
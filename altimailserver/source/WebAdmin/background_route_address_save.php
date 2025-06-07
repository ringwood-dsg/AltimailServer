<?php

   if (!defined('IN_WEBADMIN'))
      exit();

   if (altimailGetAdminLevel() != 2)
   	  altimailHackingAttempt(); // Domain admin but not for this domain.

   $obSettings = $obBaseApp->Settings;
   $obRoutes	= $obSettings->Routes;
   
   $routeid 	= altimailGetVar("routeid",0);
   $routeaddressid	= altimailGetVar("routeaddressid",0);
   $action	   = altimailGetVar("action","");

   $obRoute       = $obRoutes->ItemByDBID($routeid);
   $obAddresses	= $obRoute->Addresses;
   
   $routeaddress = altimailGetVar("routeaddress","");
   
   if ($action == "edit")
      $obAddress = $obAddresses->ItemByDBID($routeaddressid);
   elseif ($action == "add")
      $obAddress = $obAddresses->Add();
   elseif ($action == "delete")
   {
      $obAddresses->DeleteByDBID($routeaddressid);
      header("Location: index.php?page=route_addresses&routeid=$routeid");
      exit();
   }

   $obAddress->Address = $routeaddress;
   $obAddress->RouteID = $routeid;
         
   $obAddress->Save();
   
   header("Location: index.php?page=route_addresses&routeid=$routeid");

?>


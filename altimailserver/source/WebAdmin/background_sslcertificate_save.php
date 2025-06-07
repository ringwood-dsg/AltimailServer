<?php
   if (!defined('IN_WEBADMIN'))
      exit();

   if (altimailGetAdminLevel() != ADMIN_SERVER)
   	altimailHackingAttempt(); // The user is not server administrator.
   
   $action	   = altimailGetVar("action","");
   $id	      = altimailGetVar("id",0);
   
   $Name	      = altimailGetVar("Name",0);
   $CertificateFile	      = altimailGetVar("CertificateFile","");
   $PrivateKeyFile= altimailGetVar("PrivateKeyFile","");
   
   $sslCertificates = $obBaseApp->Settings->SSLCertificates;
   
   if ($action == "edit")
      $sslCertificate     = $sslCertificates->ItemByDBID($id);
   elseif ($action == "add")
      $sslCertificate     = $sslCertificates->Add();
   elseif ($action == "delete")
   {
      $sslCertificates->DeleteByDBID($id);
      header("Location: index.php?page=sslcertificates");
   }

   // Save the changes
   $sslCertificate->Name = $Name;
   $sslCertificate->CertificateFile = $CertificateFile;
   $sslCertificate->PrivateKeyFile = $PrivateKeyFile;
   $sslCertificate->Save();
   
   header("Location: index.php?page=sslcertificates");
?>


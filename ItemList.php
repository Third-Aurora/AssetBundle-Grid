<?php

$folder = "AssetBundles/";
$mask = "*Android*";
$files = glob("" . $folder . $mask);

foreach ($files as $file) {
   $file_name = basename($file,substr($mask,1));
   $name = split ("-", $file_name);
   echo  $name[0].",";
}

?>
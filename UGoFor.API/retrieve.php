<?php
  $data = file_get_contents('php://input');
  header("Location: http://ugoforapi.azurewebsites.net/home/udid?data=".rawurlencode($data));
?>
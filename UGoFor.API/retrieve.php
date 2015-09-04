<?php
  $data = file_get_contents('php://input');
  header("Location: http://www.google.com/Results?data=".rawurlencode($data));
?>
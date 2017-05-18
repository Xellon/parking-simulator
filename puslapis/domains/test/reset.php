<?php
require "db.php";
$data = $_POST;
if(isset($data['do_login']))
{
	$email = $data["email"];
	$username = getloginonEmail($email);
	$new_password = substr(md5(time()),0 ,6);
	setPassword($username, md5($new_password));
	$to = $email;
	$from = "parkavimo@simuliatorius.lt";
	$subject = "Slaptazodzio atkurimas";
	$header = "From \r\nReply - To: $from \r\nContent-type : text/plan; charset= windows-1251\r\n  ";
	$massage = " Jusu naujas slaptazodi: $new_password";
	mail($to, $subject, $massage, $header);


 	function getloginonEmail($email){
 		$mysqli = connectDb();
 		$reset_set = $mysqli-> query("select `login` from `users` where `email` = '$email'  ");
 		$row = $reset_set->fetch_assocc();
 		$result_set->close();
 		closeDB($mysqli);
 		return $row['username'];
 	
}
function setPassword($username, $PASSWORD){
	if (($username == "") || ($PASSWORD == "")) return folse;
	$mysqli = connectDB();
	$mysqli -> query("update users set PASSWORD='$PASSWORD' where username = '$username'");
	closeDB($mysqli);
}
?>
<!DOCTYPE html>
<html>
<head>
	<title>Slaptazodzio atkurimas</title>
</head>
<body>
<h1>Pamirsote slaptazodi? </h1>
<p>
<label>Jusu email'as:</label>
<input type="text" name="email" placeholder="myusername@myusername.com" >
</p>
<p class="login button">
	<button type="submit" name="do_login">Reset </button>

</body>
</html>
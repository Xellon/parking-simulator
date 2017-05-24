<?php
require "db.php";
 
if(empty($errors))
 	{
 		//viskas gerai
 		$user = R::dispense('users');
 		$user ->password = password_hash($data['PASSWORD'], PASSWORD_DEFAULT);
 		R::store($user);
}
 	
?>
<!DOCTYPE html>
<html>
<head>
	<title>My profile</title>
</head>
<body>
<form action="signup.php" method="POST">
<h1> My profile</h1>
<br>
<br>
<p>
<h3>Mano username: <?php echo $_SESSION['logged_user']->username;?></h3>
<h3>Mano pastas: <?php echo $_SESSION['logged_user']->email;?></h3>
<h3><strong>Naujas slaptazodis</strong>:</h3>
	<input type="text" name="PASSWORD" placeholder="password" value="<?php echo @$data['PASSWORD']; ?>">
	<br>
	 <p class="signin button">
	<button type="submit" name="change">Pakeisti </button> <a href="/logout.php">Išeiti</a>
	</p>
</form>
</body>
</html>
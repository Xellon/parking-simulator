<?php
require "db.php";
$data = $_POST;
if(isset($data['do_login']))
{
	$errors = array();
	$user = R::findOne('users', 'username = ?' , array($data['login']));
	if ( $user ) {
if(PASSWORD_verify($data['PASSWORD'], $user->PASSWORD))
{
//viskas gerai
	$_SESSION['logged_user'] = $user;
	echo '<div style="color:green ;">Jus avtarizuoti<br/>Galite pereiti i<a href="index.html"> pagrindini</a> puslpapi</div><hr>';
}else
{
 $errors[] = 'Ne teisingai ivestas slaptazuodis';
}
		
	}else{
		$errors[] = 'Ne teisingas ivestas username';
	}
	if(!empty($errors))
 	{
 	echo '<div style="color:red ;">'.array_shift($errors). '</div><hr>';
 	}
}
?>

<!DOCTYPE html>
<html>
<head>
	<meta charset="utf-8"/>
	<title>Log in</title>
    <link rel="icon" href="Icon1.ico">
    <link rel="stylesheet" type="text/css" href="style.css"/>
</head>
<body>
<form action="login.php" method="POST">
<div id="wrapper">
<h1>Log in</h1>
<p>
	<p><strong>Your username</strong>:</p>
	<input type="text" name="login" value="<?php echo @$data['login']; ?>" placeholder="myusername ">
	</p>

	<p>
	<p><strong>Your password</strong>:</p>
	<input type="PASSWORD" name="PASSWORD" value="<?php echo @$data['PASSWORD']; ?>" placeholder="eg. X8df!90EO">
	</p>

 <p class="login button">
	<button type="submit" name="do_login">Log in </button>
</p>
<p class="forgot password">
<div style="color:blue ;"><a href="reset.php"> Forgot password?</a></div><hr>
</p>
 <p class="change_link">
                    Not a member yet ?
                    <a href="signup.php" class="to_subscribe">Join us</a>
                </p>
</div>
</form>
</body>
</html>
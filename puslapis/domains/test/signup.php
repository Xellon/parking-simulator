<?php
require "db.php";
 $data =$_POST;
 if(isset($data['do_signup']))
 {
 	//registracija
 	$errors = array(); 
 	if (trim($data['login']) == '') {
 		$errors[] = 'Iveskite username';
 	}
 	if ($data['email'] == '') {
 		$errors[] = 'Iveskite pasta';
 	}

 	if ($data['PASSWORD'] == '') {
 		$errors[] = 'Iveskite slaptazodi';
 	}

 	if ($data['PASSWORD_2'] != $data[PASSWORD]) {
 		$errors[] = '2 slaptazuodis ivestas ne teisingai';
 	}

    if ( R::count('users', "username = ?" , array($data['login'])) > 0) {
 		$errors[] = 'Toks vartotojas jau yra';
 	}
 	 if ( R::count('users', "email = ?" , array($data['email'])) > 0) {
 		$errors[] = 'Toks pastas jau uzimtas';
 	}


 	if(empty($errors))
 	{
 		//viskas gerai
 		$user = R::dispense('users');
 		$user ->username = $data['login'];
 		$user ->email = $data['email'];
 		$user ->password = password_hash($data['PASSWORD'], PASSWORD_DEFAULT);
 		R::store($user);
 		echo '<div style="color:green ;">Jus uzsiregistravote</div><hr>';
 	
 	}else{
 		echo '<div style="color:red ;">'.array_shift($errors). '</div><hr>';
 	}
 }

?>
<!DOCTYPE html>
<html>
<head>
	<meta charset="utf-8"/>
	<title>Registration form</title>
    <link rel="icon" href="Icon1.ico">
    <link rel="stylesheet" type="text/css" href="style.css"/>
</head>
<body>
<form action="signup.php" method="POST">

    <div id="wrapper">
     
     <h1> Sign up </h1>

	<p>
	<p><strong>Your username</strong>:</p>
	<input type="text" name="login" value="<?php echo @$data['login']; ?>">
	</p>
	<p>
	<p><strong>Your email</strong>:</p>
    <input type="text" name="email" value="<?php echo @$data['email']; ?>">
    </p>
	<p>
	<p><strong>Your password</strong>:</p>
	<input type="PASSWORD" name="PASSWORD" value="<?php echo @$data['PASSWORD']; ?>">
	</p>

	<p>
	<p><strong>Please confirm your password</strong>:</p>
	<input type="PASSWORD" name="PASSWORD_2" value="<?php echo @$data['PASSWORD_2']; ?>">
	</p>

  <p class="signin button">
	<button type="submit" name="do_signup"> Sign up</button>
</p>
<p class="change_link">
Already a member ?
<a href="login.php" class="to_subscribe"> Go and log in </a>
</p>
  </div>
  
</form> 
</body>
</html>
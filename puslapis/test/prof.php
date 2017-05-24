<?php
require "db.php";
 

 	
?>
<!DOCTYPE html>
<html>
<head>
	<title>My profile</title>

</head>
<body>
<h1> My profile</h1>
<br>
<br>
<p>
<h3>Mano username: <?php echo $_SESSION['logged_user']->username;?></h3>
<h3>Mano pastas: <?php echo $_SESSION['logged_user']->email;?></h3>
<h3><strong>Pakeisti slaptazodis</strong>:</h3>
<div>
<p class="signin_button">
	<button type="submit" name="change">Pakeisti </button>
	 <a href="index.php"><button>Grįžti į pagrindinį</button></a>
	</p>
	</div>
	<input type="password" name="PASSWORD" placeholder="password" value="<?php echo @$data['PASSWORD']; ?>">
	<br>

	
	<style type="text/css">
		body {
    color: #8f8f8f;
    font: 12px Tahoma, sans-serif;
    background-color: #f8f8f8;
    border-top: 5px solid #7e7e7e;
    margin: 0;
}
.signin_button {
    display: inline-block;
    left: : 30px;
    bottom: 50%;
    position: fixed;
}

.signin_button button {
    display: inline-block;
    
    margin:  10px 10px 10px 10px;
    padding: 5px 5px 5px 5px;
    
    height: 40px;
    width: 200px;
    font-size: 24px;
    
    cursor: pointer;
    color: #888888;
    background-color: #FFFFFF;
    border: none;
    border-radius: 8px;
    box-shadow: 0 1px grey;

}

.signin_button button:hover {
    background-color: #AAAAAA;
    color: #FFFFFF;
}

.signin_button button:active {
    background-color: #3e8e41;
    box-shadow: 0 5px #666;
    transform: translateY(4px);
}

	</style>
</form>
</body>
</html>
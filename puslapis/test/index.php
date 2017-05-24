<?php
require "db.php";
?>

<!DOCTYPE html>
<html>

<head>
	<script src="jquery-1.11.0.min.js"></script>

	<link rel="stylesheet" type="text/css" href="style/index.css">
	<script src="style/index.js"></script>

	<meta charset="utf-8"/>
	
	<link rel="icon" href="style/icon.ico">
	<title>Home page</title>
</head>
<body>
    <div class = "toolbar">
		<div class = "toolbar_title">
			<p>PARKING</p>
			<img src="style/icon2.png"></img>
			<p>SIMULATOR</p>
		</div>

		<?php if(isset($_SESSION['logged_user'])) : ?>
		<div class = "toolbar_buttons">
		<a href="/prof.php"><button>Profilis</button></a>
	    <a href="/logout.php"><button>Atsijungti</button></a>
	</div>
	<?php else : ?>
		<div class = "toolbar_buttons">
			<a href="signup.php"><button>Registruotis</button></a>
			<a href="login.php"><button>Prisijungti</button></a>
		</div>
		<?php endif;?>

	</div>
	<div class = "main_screen">
		<img src="style/icon2.png"></img>
		<h1>PARKAVIMO SIMULIATORIUS</h1>
		<p>Nemoki parkuotis? Išbandyk šį žaidimuką,</p>
		<p>gal ko nors išmoksi!</p>
		<a href="Build/index.html"><button class="button_start">PRADĖTI</button></a>
	</div>
	<div class = "info">
		<img src="style/yellow_box.png" height = "200" align="left" >
			<h2>APIE MUS</h2>
		</img>
		<p>Mes esame studentų komanda, kuri sukūre šį žaidimuką. Lengvai prieinamas internetu žaidimukas, kuris moko bei lavina mašinos statymo įgūdžius su įvairiom mašinom, aikštelėm ar situacijom.</p>
	</div>
	<div class = "contacts">
		<h2>Kontaktai</h2>
		<p>email: eseviakov@gmail.com</p>
	</div>
	<p id = "end">All rights reserved bla bla bla  SoonTM</p>
</body>

</html>


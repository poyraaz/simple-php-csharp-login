<?php
header("Content-Type: application/json");
$servername = "localhost"; // Sunucu
$username = "root"; // Kullanıcı Adı
$password = ""; // Şifre

try
{
    $conn = new PDO("mysql:host=$servername;dbname=dbName", $username, $password);
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
}
catch(PDOException $e)
{
    echo "Connection failed: " . $e->getMessage();
}

$id = $_GET['username'];
$query = $conn->query("SELECT * FROM users WHERE name = '{$id}'")->fetch(PDO::FETCH_ASSOC);
if ($query)
{
    if ($_GET['get'] == "credit")
    {
        print_r($query['credit']);
    }
    else if ($_GET['get'] == "uuid")
    {
        print_r($query['uuid']);
    }
    else if ($_GET['get'] == "name")
    {
        print_r($query['name']);
    }
}
else
{
    print_r("");
}

?>

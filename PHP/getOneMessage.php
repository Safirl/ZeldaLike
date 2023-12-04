<?php

$host = "localhost";
$database = "nugget";
$user = "root";
$password = "";

try {
    $conn = new PDO("mysql:host=$host;dbname=$database", $user, $password);
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

    $query = "SELECT * FROM messages";

    $stmt = $conn->query($query);

    $messages = $stmt->fetchAll(PDO::FETCH_ASSOC);

    shuffle($messages);
    // echo $messages[0];

    header('Content-Type: application/json');
    echo json_encode($messages[0]);
} catch (PDOException $e) {
    echo "Erreur: " . $e->getMessage();
}

$conn = null;

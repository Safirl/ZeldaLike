<?php

$host = "localhost";
$database = "nugget";
$user = "root";
$password = "";

try {
    $conn = new PDO("mysql:host=$host;dbname=$database", $user, $password);
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

    $playerMessage = $_GET['playerMessage'];
    $numberOfDefenders = $_GET['numberOfDefenders'];
    $defendersNames = $_GET['defendersNames'];

    $query = "INSERT INTO messages (playerMessage, numberOfDefenders, defendersNames) VALUES (:playerMessage, :numberOfDefenders, :defendersNames)";

    $stmt = $conn->prepare($query);

    $stmt->bindParam(':playerMessage', $playerMessage, PDO::PARAM_STR);
    $stmt->bindParam(':numberOfDefenders', $numberOfDefenders, PDO::PARAM_INT);
    $stmt->bindParam(':defendersNames', $defendersNames, PDO::PARAM_STR);

    $stmt->execute();

    echo "<b>Message bien inséré !</b>";
} catch (PDOException $e) {
    echo "Erreur: " . $e->getMessage();
}

$conn = null;

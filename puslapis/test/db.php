<?php
require "libs/rb.php";
    R::setup( 'mysql:host=localhost;dbname=Parkavimo_Simuliatorius',
        'root', 'simuliatorius' ); //for both mysql or mariaDB 
    
session_start();
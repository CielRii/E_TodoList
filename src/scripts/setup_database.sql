CREATE DATABASE IF NOT EXISTS setup_database;
USE setup_database;

CREATE TABLE IF NOT EXISTS t_user(
   user_id INT AUTO_INCREMENT,
   username VARCHAR(50) NOT NULL,
   password VARCHAR(72) NOT NULL,
   salt VARBINARY(20) NOT NULL,
   PRIMARY KEY(user_id),
   UNIQUE(username)
);

CREATE TABLE IF NOT EXISTS t_task(
   task_id INT AUTO_INCREMENT,
   name VARCHAR(50) NOT NULL,
   done BOOLEAN NOT NULL,
   user_id INT NOT NULL,
   PRIMARY KEY(task_id),
   FOREIGN KEY(user_id) REFERENCES t_user(user_id)
);
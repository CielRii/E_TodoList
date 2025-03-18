CREATE DATABASE IF NOT EXISTS setup_database;
USE setup_database;

CREATE TABLE IF NOT EXISTS t_user(
   user_id INT AUTO_INCREMENT,
   username VARCHAR(50) NOT NULL,
   password VARCHAR(50) NOT NULL,
   PRIMARY KEY(user_id),
   UNIQUE(username)
);

CREATE TABLE IF NOT EXISTS t_task(
   task_id INT AUTO_INCREMENT,
   name VARCHAR(50) NOT NULL,
   user_id INT NOT NULL,
   user_id_1 INT NOT NULL,
   user_id_2 INT NOT NULL,
   user_id_3 INT NOT NULL,
   user_id_4 INT NOT NULL,
   PRIMARY KEY(task_id),
   FOREIGN KEY(user_id) REFERENCES t_user(user_id),
   FOREIGN KEY(user_id_1) REFERENCES t_user(user_id),
   FOREIGN KEY(user_id_2) REFERENCES t_user(user_id),
   FOREIGN KEY(user_id_3) REFERENCES t_user(user_id),
   FOREIGN KEY(user_id_4) REFERENCES t_user(user_id)
);

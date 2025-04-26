USE setup_database;

INSERT INTO `t_user`(`user_id`, `username`, `password`) VALUES
(NULL, "Zka", "Jacobus12."),
(NULL, "Maeve", "Batista223."),
(NULL, "Akaba", "Gomes979."),
(NULL, "IrisV", "Moe293."),
(NULL, "Gioele", "Corradini982.");

INSERT INTO `t_task` (task_id, name, user_id) VALUES
(NULL, "Faire mes devoirs", 1),
(NULL, "Préparer le rapport mensuel", 1),
(NULL, "Réviser pour l'examen", 2),
(NULL, "Organiser la réunion d'équipe", 2),
(NULL, "Acheter les courses", 3),
(NULL, "Répondre aux emails importants", 3),
(NULL, "Mettre à jour le site web", 4),
(NULL, "Planifier les vacances", 4),
(NULL, "Ecrire un article de blog", 5),
(NULL, "Faire une présentation PowerPoint", 5);

DELIMITER $$

CREATE PROCEDURE UpdatePasswords()
BEGIN
  DECLARE done INT DEFAULT FALSE;
  DECLARE v_user_id INT;
  DECLARE v_password VARCHAR(255);

  DECLARE cur CURSOR FOR SELECT user_id, password FROM t_user;
  DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;

  OPEN cur;

  read_loop: LOOP
    FETCH cur INTO v_user_id, v_password;
    IF done THEN
      LEAVE read_loop;
    END IF;

    -- Générer un salt binaire de 20 octets
    SET @salt := UNHEX(SHA2(CONCAT(RAND(), NOW()), 256)); -- SHA2 donne 32 octets, on tronque après
    SET @salt := LEFT(@salt, 20);

    -- Concaténer password et salt comme en C#
    SET @password_bytes := CONVERT(v_password USING utf8mb4);
    SET @salted := CONCAT(@password_bytes, @salt);

    -- Hacher le mot de passe salé
    SET @hashed := UNHEX(SHA2(@salted, 256));

    -- Concaténer salt + hash
    SET @final := TO_BASE64(CONCAT(@salt, @hashed));

    -- Mettre à jour
    UPDATE t_user
    SET password = @final, salt = @salt
    WHERE user_id = v_user_id;

  END LOOP;

  CLOSE cur;
END$$

DELIMITER ;

CALL UpdatePasswords();
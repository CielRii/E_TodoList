USE setup_database;

INSERT INTO `t_user`(`user_id`, `username`, `password`) VALUES
(NULL, "Zka", "Jacobus12."),
(NULL, "Maeve", "Batista223."),
(NULL, "Akaba", "Gomes979."),
(NULL, "IrisV", "Moe293."),
(NULL, "Gioele", "Corradini982.");

INSERT INTO `t_task` (task_id, name, user_id, user_id_1, user_id_2, user_id_3, user_id_4) VALUES
(NULL, "Faire mes devoirs", 1, 1, 1, 1, 1),
(NULL, "Pr�parer le rapport mensuel", 1, 1, 1, 1, 1),
(NULL, "R�viser pour l'examen", 2, 2, 2, 2, 2),
(NULL, "Organiser la r�union d'�quipe", 2, 2, 2, 2, 2),
(NULL, "Acheter les courses", 3, 3, 3, 3, 3),
(NULL, "R�pondre aux emails importants", 3, 3, 3, 3, 3),
(NULL, "Mettre � jour le site web", 4, 4, 4, 4, 4),
(NULL, "Planifier les vacances", 4, 4, 4, 4, 4),
(NULL, "�crire un article de blog", 5, 5, 5, 5, 5),
(NULL, "Faire une pr�sentation PowerPoint", 5, 5, 5, 5, 5);
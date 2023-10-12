DROP procedure IF EXISTS `check_user_group_sp`;

DELIMITER $$
USE `ingress`$$
CREATE DEFINER=`ingress`@`%` PROCEDURE `check_user_group_sp`(IN user_group_id INT, IN group_name VARCHAR(200), OUT result INT)
BEGIN

DECLARE parent_id INT;
SET parent_id = (SELECT parentId FROM user_group WHERE id = user_group_id);

IF (SELECT gName FROM user_group WHERE id = user_group_id) = group_name THEN
	SET result = 1;
ELSE    
    IF parent_id IS NOT NULL THEN
		CALL check_user_group_sp(parent_id, group_name, result);
	ELSE
		SET result = 0;
    END IF;
END IF;
END$$

DELIMITER ;
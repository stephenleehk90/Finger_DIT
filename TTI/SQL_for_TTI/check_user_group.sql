USE `ingress`;
DROP function IF EXISTS `check_user_group`;

DELIMITER $$
USE `ingress`$$
CREATE DEFINER=`ingress`@`%` FUNCTION `check_user_group`(user_group_id INT, group_name VARCHAR(200)) RETURNS int(11)
BEGIN

DECLARE result INT;
SET max_sp_recursion_depth=255;
CALL check_user_group_sp(user_group_id, group_name, result);

RETURN result;
END$$

DELIMITER ;


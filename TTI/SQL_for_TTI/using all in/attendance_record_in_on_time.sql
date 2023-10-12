CREATE OR REPLACE VIEW `attendance_record_in_on_time` AS
    SELECT 
        `u`.`userid` AS `User ID`,
        CONCAT(CONCAT((CASE
                            WHEN ISNULL(`u`.`Name`) THEN ' '
                            ELSE `u`.`Name`
                        END),
                        ' '),
                (CASE
                    WHEN ISNULL(`u`.`lastname`) THEN ' '
                    ELSE `u`.`lastname`
                END)) AS `User Name`,
        `u`.`Email` AS `Email`,
        `att`.`date` AS `In Date`,
        STR_TO_DATE(`att`.`att_in`, '%H:%i:%s') AS `In Time`,
        'AM' AS `Session ID`
    FROM
        (((`user` `u`
        LEFT JOIN `user_info` `ui` ON ((`u`.`userid` = `ui`.`userid`)))
        LEFT JOIN `user_group` `ug` ON ((`u`.`User_Group` = `ug`.`id`)))
        LEFT JOIN `attendance` `att` ON ((`u`.`userid` = `att`.`userid`)))
    WHERE
        ((`att`.`in_s` = 0)
            AND (`att`.`att_in` IS NOT NULL)
            AND CHECK_USER_GROUP(`ug`.`id`, 'AM') = 1)
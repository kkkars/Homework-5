CREATE FUNCTION select_user_notes_count()
RETURNS TABLE(id int, first_name varchar, last_name varchar, notes_amount bigint) AS
    $$
    SELECT id, first_name, last_name, COALESCE((
            SELECT COUNT(user_id)
            FROM notes
            WHERE is_deleted = false  AND users.id=user_id
            GROUP BY user_id
            ),0) AS notes_amount
   FROM users;
    $$LANGUAGE SQL;

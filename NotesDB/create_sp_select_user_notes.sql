CREATE FUNCTION select_user_notes(usr_id int)
RETURNS TABLE (note_id uuid, header varchar, body varchar, is_deleted bool, user_id int, modified_at timestamp with time zone) AS
    $$
SELECT id, header, body, is_deleted, user_id, modified_at
    FROM notes
    WHERE is_deleted = false AND user_id = usr_id;
    $$LANGUAGE SQL;
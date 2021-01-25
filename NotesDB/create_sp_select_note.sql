CREATE FUNCTION select_note(note_id uuid)
RETURNS TABLE(id uuid, header varchar, body varchar, is_deleted bool,user_id int,
              modified_at timestamp with time zone,usr_id int, first_name varchar, last_name varchar)
AS
    $$
    SELECT notes.id, notes.header, notes.body, notes.is_deleted, notes.user_id,
           notes.modified_at,users.id, users.first_name, users.last_name
    FROM notes
    INNER JOIN users on users.id = notes.user_id
    WHERE notes.id = note_id;
    $$LANGUAGE SQL;
CREATE FUNCTION insert_user(first_name varchar(128), last_name varchar(128))
RETURNS void AS
    $$
        INSERT INTO users (first_name, last_name) VALUES (first_name, last_name);
    $$LANGUAGE SQL;
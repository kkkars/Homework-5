CREATE TABLE notes
(
    id uuid PRIMARY KEY,
    header varchar(128) NOT NULL,
    body varchar(1024) NOT NULL,
    is_deleted bool NOT NULL default false,
    user_id int REFERENCES users(id) NOT NULL,
    modified_at timestamp with time zone not null default current_timestamp NOT NULL
);
create index modified_at_index on notes (modified_at);
SELECT insert_user('Lara', 'Kraft');
SELECT insert_user('Oggy', 'Milk');
SELECT insert_user('Joy', 'Kinder');
SELECT insert_user('Martin', 'Skarlet');

SELECT insert_note('79d93ca0-b2a1-4acf-b396-294e096f38bc', 'list to to','dont forget to buy the milk and cottage cheese', 2);
SELECT insert_note('07bef1d2-80fb-4e71-b890-8215540ad040', 'The cool toy','check the link from the Joy', 2);
SELECT insert_note('1961b288-a526-45b5-a0d9-d8d74a4f93b9', 'How to','to how cut your fur if you have paws', 2);
SELECT insert_note('1961b288-a526-45b5-a0d9-d8d74a4f93b3', 'Cool songs for training','Dzin Dzin by ...', 1);
SELECT insert_note('1961b288-a536-45b5-a0d9-d4d74a4f93b3', 'Sent to Oggy','The link where he can buy scratching post', 3);
SELECT insert_note('1961b288-a536-45b6-a0d9-d4d74a4f93b9', 'Important','Add to the calendar that a new course will start at 9:30 10.10.2021 ', 3);

SELECT select_note('79d93ca0-b2a1-4acf-b396-294e096f38bc');
SELECT select_note('1961b288-a526-45b5-a0d9-d8d74a4f93b3');
SELECT select_note('1961b288-a536-45b5-a0d9-d4d74a4f93b3');

SELECT select_user_notes_count();

SELECT select_user_notes(3);
SELECT update_note_mark_deleted('1961b288-a536-45b5-a0d9-d4d74a4f93b3');
SELECT select_user_notes(3);

SELECT select_user_notes_count();

SELECT select_user_notes(2);
SELECT update_note_mark_deleted('07bef1d2-80fb-4e71-b890-8215540ad040');
SELECT select_user_notes(2);

SELECT select_user_notes_count();
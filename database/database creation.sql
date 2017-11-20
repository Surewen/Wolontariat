CREATE TABLE users(
  id INTEGER PRIMARY KEY, 
  nickname VARCHAR(20) NOT NULL,
  pesel INTEGER NOT NULL, 
  email VARCHAR(30) NOT NULL,
  telephone VARCHAR(9),
  name VARCHAR(20) NOT NULL,
  surname VARCHAR(20) NOT NULL,
  birth_date DATE NOT NULL,
  sex VARCHAR(10) NOT NULL,
  type VARCHAR(20) NOT NULL
);


CREATE TABLE newsletters(
  id INTEGER PRIMARY KEY,
  to_email VARCHAR(20) NOT NULL,
  from_email VARCHAR(20) NOT NULL,
  title VARCHAR(40) NOT NULL,
  content VARCHAR(250) NOT NULL,
  post_date DATETIME NOT NULL
);


CREATE TABLE announcements(
  id INTEGER PRIMARY KEY,
  post_date DATETIME NOT NULL,
  created_by VARCHAR(20) NOT NULL,
  current_status VARCHAR(10) NOT NULL,
  type VARCHAR(20) NOT NULL,
  content VARCHAR(1000) NOT NULL
);


CREATE TABLE invitations(
  id INTEGER PRIMARY KEY,
  announcement_id INTEGER NOT NULL,
  to_email VARCHAR(20) NOT NULL,
  from_email VARCHAR(20) NOT NULL,
  title VARCHAR(40) NOT NULL,
  content VARCHAR(250) NOT NULL,
  post_date DATETIME NOT NULL,
  FOREIGN KEY (announcement_id) REFERENCES announcements(id)
);



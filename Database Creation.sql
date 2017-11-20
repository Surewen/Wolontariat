CREATE TABLE users(
  id INTEGER PRIMARY KEY, 
  nickname NOT NULL VARCHAR(20) ,
  pesel NOT NULL INTEGER, 
  email NOT NULL VARCHAR(30),
  telephone VARCHAR(9),
  name NOT NULL VARCHAR(20),
  surname NOT NULL VARCHAR(20),
  birth_date NOT NULL DATE,
  sex NOT NULL VARCHAR(10),
  type NOT NULL VARCHAR(20)
);


CREATE TABLE newsletters(
  id INTEGER PRIMARY KEY,
  to_email NOT NULL VARCHAR(20),
  from_email NOT NULL VARCHAR(20),
  title NOT NULL VARCHAR(40),
  content NOT NULL VARCHAR(250),
  post_date NOT NULL DATETIME
);


CREATE TABLE announcements(
  id INTEGER PRIMARY KEY,
  post_date NOT NULL DATETIME,
  created_by NOT NULL VARCHAR(20),
  current_status NOT NULL VARCHAR(10),
  type NOT NULL VARCHAR(20),
  content NOT NULL VARCHAR(1000)
);


CREATE TABLE invitations(
  id INTEGER PRIMARY KEY,
  announcement_id INTEGER FOREIGN KEY REFERENCES announcements(id),
  to_email NOT NULL VARCHAR(20),
  from_email NOT NULL VARCHAR(20),
  title NOT NULL VARCHAR(40),
  content NOT NULL VARCHAR(250),
  post_date NOT NULL DATETIME
);



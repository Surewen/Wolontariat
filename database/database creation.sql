CREATE TABLE users(
  id INTEGER PRIMARY KEY IDENTITY(1,1), 
  nickname VARCHAR(20) NOT NULL,
  password VARCHAR(30) NOT NULL,
  pesel VARCHAR(11) NOT NULL, 
  email VARCHAR(30) NOT NULL,
  telephone VARCHAR(9),
  name VARCHAR(20) NOT NULL,
  surname VARCHAR(20) NOT NULL,
  birth_date DATE NOT NULL,
  sex VARCHAR(10) NOT NULL,
  type VARCHAR(20) NOT NULL
);


CREATE TABLE announcements(
  id INTEGER PRIMARY KEY IDENTITY(1,1),
  id_user INTEGER NOT NULL,
  post_date DATETIME NOT NULL,
  end_date DATETIME,
  type_help VARCHAR(30) NOT NULL,
  current_status VARCHAR(20) NOT NULL,
  title VARCHAR(100) NOT NULL,
  content VARCHAR(1000) NOT NULL,
  FOREIGN KEY (id_user) REFERENCES users(id)
);


CREATE TABLE events(
  id INTEGER PRIMARY KEY IDENTITY(1,1),
  id_announcement INTEGER,
  id_user INTEGER NOT NULL,
  post_date DATETIME NOT NULL,
  due_date DATETIME NOT NULL,
  title VARCHAR(40) NOT NULL,
  content VARCHAR(250) NOT NULL,
  FOREIGN KEY (id_announcement) REFERENCES announcements(id)
);


CREATE TABLE invitations(
  id INTEGER PRIMARY KEY IDENTITY(1,1),
  id_event INTEGER NOT NULL,
  id_sender INTEGER NOT NULL,
  id_receiver INTEGER NOT NULL,
  title VARCHAR(40) NOT NULL,
  content VARCHAR(250) NOT NULL,
  post_date DATETIME NOT NULL,
  FOREIGN KEY (id_event) REFERENCES events(id),
  FOREIGN KEY (id_sender) REFERENCES users(id),
  FOREIGN KEY (id_receiver) REFERENCES users(id)
);

CREATE TABLE users_assigned_announcement(
  id INTEGER PRIMARY KEY IDENTITY(1,1),
  id_announcement INTEGER NOT NULL,
  id_user INTEGER NOT NULL,
  from_hour VARCHAR (2),
  to_hour VARCHAR (2),
  FOREIGN KEY (id_announcement) REFERENCES announcements(id),
  FOREIGN KEY (id_user) REFERENCES users(id)
);

CREATE TABLE users_joined_event(
  id INTEGER PRIMARY KEY IDENTITY(1,1),
  id_event INTEGER NOT NULL,
  id_user INTEGER NOT NULL,
  FOREIGN KEY (id_event) REFERENCES events(id),
  FOREIGN KEY (id_user) REFERENCES users(id)
);


CREATE TABLE newsletters(
  id INTEGER PRIMARY KEY IDENTITY(1,1),
  to_type VARCHAR(20) NOT NULL,
  from_email VARCHAR(20) NOT NULL,
  title VARCHAR(40) NOT NULL,
  content VARCHAR(250) NOT NULL,
  post_date DATETIME NOT NULL
);

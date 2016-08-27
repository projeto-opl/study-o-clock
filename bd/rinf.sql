create database rinf;
use rinf;

/*o usuario cadastra as cidades, mas pra cadastrar, a caixa de texto onde ele vai colocar o nome dela, vai mostrar os resultados que ja existem. estilo auto complete*/
create table city(
  id int auto_increment,
  name varchar(50),
  primary key (id)
);

/*o usuario cadastra as escolas, mas pra cadastrar, a caixa de texto onde ele vai colocar o nome dela, vai mostrar os resultados que ja existem. estilo auto complete*/
create table school(
  id int auto_increment,
  name varchar(50),
  primary key (id)
);

create table user(
  id int auto_increment,
  name varchar(50),
  password varchar(40),
  id_school int,
  grade varchar(10),
  sex char(1),
  id_city int,
  cellphone varchar(20),
  birthdate date,
  primary key (id),
  foreign key (id_city) references city(id),
  foreign key (id_school) references school(id),
  constraint cs1 check(sex in ('f','m','o'))
);

/*o usuário pode ter mais de um email vinculado à conta*/
create table email(
  email varchar(100) not null,
  id_user int not null,
  is_main bool not null,
  primary key (email),
  foreign key (id_user) references user(id)
);

create table friends(
  id int auto_increment,
  id_request int not null,
  id_target int not null,
  date_sent datetime not null,
  date_anwser datetime,
  status char(1),
  primary key (id),
  foreign key (id_request) references user(id),
  foreign key (id_target) references user(id),
  constraint c1 check(status in ('p','a','d'))
);

create table tag(
  id int auto_increment,
  description varchar(50),
  primary key (id)
);

create groups(
  id int auto_increment,
  name varchar(40),
  tag int,
  primary key (id),
  foreign key (tag) references tag(id)
);

create table rel_groups(
  id_user int,
  id_groups int,
  foreign key (id_user) references user(id),
  foreign key (id_groups) references groups(id)
);

create table rel_adms(
  id_user int,
  id_groups int,
  foreign key (id_user) references user(id),
  foreign key (id_groups) references groups(id)
);

create table type_post(
  id int auto_increment,
  description varchar(30),
  primary key (id)
);

create table post(
  id int auto_increment,
  id_user int not null,
  id_groups int,
  content text,
  id_type int,
  primary key (id),
  foreign key (id_user) references user(id),
  foreign key (id_groups) references groups(id),
  foreign key (id_type) references type_post(id)
);

create table comment(
  id int auto_increment,
  id_user int,
  content text not null,
  primary key (id),
  foreign key (id_user) references user(id)
);

create table reply(
  id int auto_increment,
  id_comment int not null,
  id_user int not null,
  content text not null,
  primary key (id)
  foreign key (id_user) references user(id),
  foreign key (id_comment) references comment(id)
);

create table rel_comment(
  id_comment int not null,
  id_post int not null,
  id_user int not null,
  foreign key (id_comment) references comment(id),
  foreign key (id_post) references post(id),
  foreign key (id_user) references user(id)
);

create table area_post(
  id int auto_increment,
  description varchar(30),
  primary key (id)
);

create table rel_area(
  id_post int not null,
  id_area int not nuil,
  foreign key (id_post) references post(id),
  foreign key (id_area) references area_post(id)
);
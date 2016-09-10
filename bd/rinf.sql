drop database if exists rinf;
create database rinf;
use rinf;

/*o usuario cadastra as cidades, mas pra cadastrar, a caixa de texto onde ele vai colocar o nome dela, vai mostrar os resultados que ja existem. estilo auto complete*/
create table cities(
    id int auto_increment,
    name varchar(50),
    primary key (id)
);

/*o usuario cadastra as escolas, mas pra cadastrar, a caixa de texto onde ele vai colocar o nome dela, vai mostrar os resultados que ja existem. estilo auto complete*/
create table schools(
    id int auto_increment,
    name varchar(50),
    primary key (id)
);

create table users(
    id int auto_increment,
    name varchar(50),
    pass varchar(40),
    id_schools int,
    grade varchar(10),
    sex char(1),
    id_cities int,
    cellphone varchar(20),
    birthdate date,
    primary key (id),
    foreign key (id_cities) references cities(id),
    foreign key (id_schools) references schools(id),
    constraint cs_sex check(sex in ('f','m','o'))
);

create table reputation(
    id int auto_increment,
    id_target int not null,
    id_commenter int not null,
    stance char(1) not null, -- posição, postura: em relação ao comentario
    message text not null,
    primary key (id),
    foreign key (id_target) references users(id),
    foreign key (id_commenter) references users(id),
    constraint cs_stance check(stance in ('l','d')) -- 'l'ike / 'd'islike
);

/*o usuário pode ter mais de um email vinculado à conta*/
create table emails(
    email varchar(100) not null,
    id_users int not null,
    is_main bool not null,
    primary key (email),
    foreign key (id_users) references users(id)
);

create table friends(
    id int auto_increment,
    id_request int not null,
    id_target int not null,
    date_sent datetime not null,
    date_anwser datetime,
    status char(1),
    primary key (id),
    foreign key (id_request) references users(id),
    foreign key (id_target) references users(id),
    constraint cs_status check(status in ('p','a','d'))
);

create table tags(
    id int auto_increment,
    description varchar(50),
    primary key (id)
);

create table groups(
    id int auto_increment,
    name varchar(40),
    tags int,
    primary key (id),
    foreign key (tags) references tags(id)
);

create table rel_groups(
    id_users int,
    id_groups int,
    foreign key (id_users) references users(id),
    foreign key (id_groups) references groups(id)
);

create table rel_adms(
    id_users int,
    id_groups int,
    foreign key (id_users) references users(id),
    foreign key (id_groups) references groups(id)
);

create table type_posts(
    id int auto_increment,
    description varchar(30),
    primary key (id)
);

create table posts(
    id int auto_increment,
    id_users int not null,
    id_groups int,
    content text not null,
    id_type int,
    date_ date not null, 
    time_ time not null,
    can_comments tinyint(1) default 1, -- recebe {0, 1}. 1: true; 0: false;
    primary key (id),
    foreign key (id_users) references users(id),
    foreign key (id_groups) references groups(id),
    foreign key (id_type) references type_posts(id),
    constraint cs_cc check(can_comments in (0,1))
);

create table comments(
    id int auto_increment,
    id_users int,
    content text not null,
    date_ date not null,
    time_ time not null,
    primary key (id),
    foreign key (id_users) references users(id)
);

create table replies(
    id int auto_increment,
    id_comments int not null,
    id_users int not null,
    content text not null,
    date_ date not null,
    time_ time not null,
    primary key (id),
    foreign key (id_users) references users(id),
    foreign key (id_comments) references comments(id)
);

create table rel_comments(
    id_comments int not null,
    id_posts int not null,
    id_users int not null,
    foreign key (id_comments) references comments(id),
    foreign key (id_posts) references posts(id),
    foreign key (id_users) references users(id)
);

create table area_posts(
    id int auto_increment,
    description varchar(30),
    primary key (id)
);

create table rel_areas(
    id_posts int not null,
    id_area int not null,
    foreign key (id_posts) references posts(id),
    foreign key (id_area) references area_posts(id)
);

create table feeds(
    id_me int not null,
    id_following int not null,
    primary key (id_me, id_following),
    foreign key (id_me) references users(id) ,
    foreign key (id_following) references users(id)
);

create table notifications(
    id int auto_increment,
    content text not null,
    date_ date not null,
    time_ time not null,
    seen tinyint default 0, -- 1: visto / 0:não visto
    primary key (id),
    constraint cs_s0 check(seen in (0,1))
);

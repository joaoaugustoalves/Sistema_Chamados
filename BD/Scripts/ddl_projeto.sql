CREATE DATABASE Projetos;

USE Projetos;

create table TipoUsuario(
    IdTipoUsuario INT auto_increment PRIMARY KEY,
    nome varchar(50) unique not null
);

create table Setor(
    IdSetor INT auto_increment PRIMARY KEY,
    nome varchar(50) unique not null
);

create table Usuario(
    IdUsuario INT auto_increment PRIMARY KEY,
    nome varchar(50) unique not null,
    email varchar(50) unique null,
    senha varchar(50) unique null,
    cpf varchar(50) unique null,
    telefone int,
    IdSetor int not null,
    IdTipoUsuario int not null,
    foreign key (IdSetor) references Setor(IdSetor),
    foreign key (IdTipoUsuario) references TipoUsuario(IdTipoUsuario)
)ENGINE=INNODB;

create table Chamado(
    IdChamado INT auto_increment PRIMARY KEY,
    descricao varchar(50) unique not null,
    tipo varchar(50) unique null,
    IdColaborador int,
    IdEspecialista int,
    status bool,
    dataAbertura datetime,
    dataFinalizacao datetime,
    prioridade int,
    IdUsuario int,
    foreign key (IdUsuario) references Usuario(IdUsuario)
)ENGINE=INNODB;

create table Material(
    IdMaterial INT auto_increment primary KEY,
    nome varchar(50) unique not null,
    descricao varchar(50) unique null,
    tipo varchar(50) unique null,
    IdChamado int,
    foreign key(IdChamado) references Chamado(IdChamado)
)ENGINE=INNODB;
create database Gym
use Gym

create table GymMasters(
Id int primary key identity not null,
Name varchar(30) not null,
Surname varchar(40) not null,
PhoneNumber varchar(13) null,
)

create table Slaves(
Id int primary key identity not null,
Name varchar(30) not null,
Surname varchar(40) not null,
PhoneNumber varchar(13) null,
MasterId int null,
constraint FK_SlaveId_GymMasterId foreign key (MasterId)
references GymMasters(Id)
)

insert into GymMasters(Name, Surname, PhoneNumber) values 
('Vasya', 'Pupkin', '+375293518518'),
('Ivan', 'Kolnov', '+375294268951'),
('Anton', 'Periev', '+375294123512')

insert into Slaves(Name, Surname, PhoneNumber, MasterId) values 
('Sun', 'Tszi', '+375291112233', 1),
('Keanu', 'Reeves', '+375294412551', 1),
('Semen', 'Semenov', '+375291223899', 3)
--create database
create database BikeStore
--drop database BikeStore
create table Bikes(
id int primary key,
name varchar(50) not null,
stock varchar(20) not null
)

alter table Bikes
alter column stock int

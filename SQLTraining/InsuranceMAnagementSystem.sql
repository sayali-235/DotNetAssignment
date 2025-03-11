create database InsurancePolicyManagementSystem

create table Policies(
 PolicyID int identity primary key,
 HolderName varchar(30)not null,
 PolicyType int Not null,
 StartDate date not null,
 EndDate date not null
)

select * from Policies
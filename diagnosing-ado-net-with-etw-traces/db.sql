create database TestDb;

use TestDb;

create table Products (
  ProductKey varchar(20) primary key,
  Price smallmoney
);

insert into Products values ('P1', 20);
insert into Products values ('P2', 12);
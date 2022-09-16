

create database Sri_Arungarai_Amman_Traders

use Sri_Arungarai_Amman_Traders

create table Admin_Login(UserName varchar(20) primary key,FirstName varchar(20) not null,LastName varchar(20) not null,Password varchar(20) not null)

create table User_Login(UserName varchar(20) primary key,FirstName varchar(20) not null,LastName varchar(20) not null,PhoneNumber bigint,Email varchar(20),Password varchar(20) not null)

create table Seeds(ProductID int primary key identity(1,1),ProductName varchar(20) not null,QuantityAvailable float not null,ProductUnit varchar(3) not null,Price float not null,PurchaseDate varchar(15))

create table Chemicals(ProductID int primary key identity(1,1),ProductName varchar(20) not null,QuantityAvailable float not null,ProductUnit varchar(3) not null,Price float not null,PurchaseDate varchar(15))

create table Fertilizers(ProductID int primary key identity(1,1),ProductName varchar(20) not null,QuantityAvailable float not null,ProductUnit varchar(3) not null,Price float not null,PurchaseDate varchar(15))

create table Billings(SerialNo int primary key identity(1,1),ProductType varchar(10) not null,ProductID int not null,ProductName varchar(20) not null,Quantity float not null,Price float not null)

create table Bills(BillNo int primary key identity(1,1),BillDate varchar(15),CustomerName varchar(20) not null,PhoneNumber bigint not null,BillAmount float not null,BillPaid float not null)


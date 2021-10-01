CREATE DATABASE ZEMO_Bank

CREATE TABLE UserAccountDetails (
  Name varchar(25),
  AccNo varchar (10) Primary key,
  Password varchar(10),
  Address varchar(20),
  Contact_number varchar(10) ,
  Birth_of_date date,
  Pin varchar (4),
  Balance decimal(18,2)
)

CREATE TABLE RecentT (
  AccNo varchar (10) foreign key references AccountDetails(AccNo),
  Type varchar(30),
  Date datetime,
  Amount decimal(18,2)
)

CREATE TABLE BillPayment (
  AccNo varchar (10) foreign key references AccountDetails(AccNo),
  BillNo varchar (10),
  Type varchar(30),
  Date datetime,
  Amount decimal(18,2)
)

CREATE TABLE FundTransfer (
  AccNo varchar (10) foreign key references AccountDetails(AccNo),
  RAccNo varchar (10),
  Date datetime,
  Amount decimal(18,2)
)

CREATE TABLE NearbyATMs (
  ATMNo varchar (10) Primary key,
  Branch varchar (30),
  Location varchar (30),
  Distance varchar (6)
)

CREATE TABLE EReceipt (
  AccNo varchar (10) foreign key references AccountDetails(AccNo),
  Status varchar (10)
)

CREATE TABLE ManagementAccountDetails (
  Name varchar(25),
  AccNo varchar (10) Primary key,
  Password varchar(10)
)

ALTER TABLE EReceipt
ADD Date datetime;

CREATE TABLE SecurityAlerts (
  AccNo varchar (10) foreign key references UserAccountDetails(AccNo),
  Type varchar(30),
  Date datetime,
  Amount decimal(18,2)
)
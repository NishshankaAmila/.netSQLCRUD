CREATE TABLE Customer (
  CId INT PRIMARY KEY,
  CName VARCHAR(50),
  Mobile VARCHAR(11)
);

CREATE TABLE Goods (
  GId INT PRIMARY KEY,
  GName VARCHAR(50),
  GPrice FLOAT
);

CREATE TABLE Bill (
  InvoiceNo INT PRIMARY KEY,
  QTY INT,
  TotalPrice FLOAT,

);


insert into Customer (CId,CName,Mobile)
values(1,'kamal','071456789')

insert into Goods (GId,GName,GPrice)
values(1,'Laptop',125000.00)


insert into Bill (InvoiceNo,QTY,TotalPrice)
values(1,2,250000.00)

select* from Customer,Goods,Bill
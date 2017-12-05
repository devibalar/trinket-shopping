USE Boutique;
GO
CREATE SCHEMA jade;
GO

CREATE TABLE jade.tblProductType(
TypeID INTEGER IDENTITY(1,1) NOT NULL,
Name VARCHAR(15) NOT NULL ,
CONSTRAINT PK_tblProductType PRIMARY KEY (TypeID) ,
CONSTRAINT Def_tblProductType DEFAULT 1
);

CREATE TABLE jade.tblProduct(
ProductID INTEGER IDENTITY(1,1) NOT NULL,
Name VARCHAR(30) NOT NULL,
Price INTEGER NOT NULL,
[Description] VARCHAR(500) NOT NULL,
ImageUrl VARCHAR(100) NOT NULL,
TypeID INTEGER NOT NULL,
CONSTRAINT PK_tblProduct PRIMARY KEY (ProductID),
CONSTRAINT FK_tblProduct FOREIGN KEY (TypeID) REFERENCES jade.tblProductType(TypeID),
CONSTRAINT Def_tblProduct DEFAULT 1 
);



CREATE TABLE jade.tblUser(
UserID INTEGER IDENTITY(1,1) NOT NULL,
FirstName VARCHAR(40) NOT NULL,
LastName VARCHAR(40) NOT NULL,
UserName VARCHAR(20) NOT NULL, 
Email VARCHAR(50) NOT NULL,
PhoneNumber VARCHAR(12) NOT NULL,
[Password] VARCHAR(30) NOT NULL,
[Address] VARCHAR(300) NOT NULL,
CONSTRAINT PK_tblUser PRIMARY KEY (UserID),
CONSTRAINT Uni2_tblUser UNIQUE (Email)
);

CREATE TABLE jade.tblCart(
UserID INTEGER NOT NULL,
ProductID INTEGER NOT NULL,
Quantity INTEGER NOT NULL,
Amount DECIMAL NOT NULL,
TotalAmount DECIMAL NOT NULL,
CONSTRAINT PK_tblCart PRIMARY KEY (UserID,ProductID),
CONSTRAINT FK1_tblCart FOREIGN KEY (UserID) REFERENCES jade.tblUser(UserID),
CONSTRAINT FK2_tblCart FOREIGN KEY (ProductID) REFERENCES jade.tblProduct(ProductID)
);

CREATE TABLE jade.tblOrder(
OrderID INTEGER IDENTITY(1,1) NOT NULL,
UserID INTEGER NOT NULL, 
OrderDate DATE NOT NULL,
DeliveryDate DATE,
ShippingDate DATE,
OrderStatus VARCHAR(40) NOT NULL,
TotalAmount DECIMAL NOT NULL,
ShippingCharges DECIMAL NOT NULL,
BillAmount DECIMAL NOT NULL,
DeliveryAddress VARCHAR(300) NOT NULL,
CONSTRAINT PK_tblOrder PRIMARY KEY (OrderID),
CONSTRAINT CHK_OrderStatus CHECK (OrderStatus IN ('Paid','ShippingDone','Delivered')),
CONSTRAINT FK_tblOrder FOREIGN KEY (UserID) REFERENCES jade.tblUser(UserID)
);

CREATE TABLE jade.tblOrderedProducts(
OrderID INTEGER NOT NULL,
ProductID INTEGER NOT NULL,
Quantity INTEGER NOT NULL,
Amount INTEGER NOT NULL,
CONSTRAINT PK_tblOrderedProducts PRIMARY KEY (OrderID,ProductID),
CONSTRAINT FK1_tblOrderedProducts FOREIGN KEY (OrderID) REFERENCES jade.tblOrder(OrderID),
CONSTRAINT FK2_tblOrderedProducts FOREIGN KEY (ProductID) REFERENCES jade.tblProduct(ProductID)
);

CREATE TABLE jade.tblInventory(
ProductID INTEGER NOT NULL,
Quantity INTEGER NOT NULL,
OutOfStock BIT,
CONSTRAINT PK_tblInventory PRIMARY KEY (ProductID),
CONSTRAINT FK_tblInventory FOREIGN KEY (ProductID) REFERENCES jade.tblProduct(ProductID)
);

INSERT INTO jade.tblUser (FirstName,LastName,UserName,Email,PhoneNumber,[Password],[Address]) values(
'Sanderson','Justin','Sam','sam@gmail.com','098746865','abc@123','23,inkerman road,greenlane,auckland'
);


INSERT INTO jade.tblUser (FirstName,LastName,UserName,Email,PhoneNumber,[Password],[Address]) values(
'admin','admin','admin','admin@gmail.com','098746865','admin@123','23,inkerman road,greenlane,auckland'
);


INSERT INTO jade.tblInventory VALUES (1,2,0);
INSERT INTO jade.tblInventory VALUES (2,3,0);
INSERT INTO jade.tblInventory VALUES (3,2,0);
INSERT INTO jade.tblInventory VALUES (4,10,0);
INSERT INTO jade.tblInventory VALUES (5,5,0);
INSERT INTO jade.tblInventory VALUES (6,7,0);
INSERT INTO jade.tblInventory VALUES (7,10,0);
INSERT INTO jade.tblInventory VALUES (8,10,0);
INSERT INTO jade.tblInventory VALUES (9,10,0);
INSERT INTO jade.tblInventory VALUES (10,5,0);
INSERT INTO jade.tblInventory VALUES (11,4,0);
INSERT INTO jade.tblInventory VALUES (12,5,0);

insert into jade.tblProduct (Name,Price, [Description], ImageUrl, TypeID, Active) values ('Ring1',3.0,'White stones','image\ring1.jpg',3,1);
insert into jade.tblProduct (Name,Price, [Description], ImageUrl, TypeID, Active) values ('Ring2',3.0,'White stones','image\ring2.jpg',3,1);
insert into jade.tblProduct (Name,Price, [Description], ImageUrl, TypeID, Active) values ('Ring3',3.0,'White stones','image\ring3.jpg',3,1);
insert into jade.tblProduct (Name,Price, [Description], ImageUrl, TypeID, Active) values ('Ring4',3.0,'White stones','image\ring4.jpg',3,1);
insert into jade.tblProduct (Name,Price, [Description], ImageUrl, TypeID, Active) values ('Ring5',3.0,'White stones','image\ring5.jpg',3,1);
insert into jade.tblProduct (Name,Price, [Description], ImageUrl, TypeID, Active) values ('Ring6',3.0,'White stones','image\ring6.jpg',3,1);
insert into jade.tblProduct (Name,Price, [Description], ImageUrl, TypeID, Active) values ('Ring7',3.0,'White stones','image\ring7.jpg',3,1);


insert into jade.tblProduct (Name,Price, [Description], ImageUrl, TypeID, Active) values ('Necklace1',3.0,'Necklace Set','image\Necklace1.jpg',2,1);
insert into jade.tblProduct (Name,Price, [Description], ImageUrl, TypeID, Active) values ('Necklace2',3.0,'Necklace Set','image\Necklace2.jpg',2,1);
insert into jade.tblProduct (Name,Price, [Description], ImageUrl, TypeID, Active) values ('Necklace3',3.0,'Necklace Set','image\Necklace3.jpg',2,1);
insert into jade.tblProduct (Name,Price, [Description], ImageUrl, TypeID, Active) values ('Necklace4',3.0,'Necklace Set','image\Necklace4.jpg',2,1);
insert into jade.tblProduct (Name,Price, [Description], ImageUrl, TypeID, Active) values ('Necklace5',3.0,'Necklace Set','image\Necklace5.jpg',2,1);
insert into jade.tblProduct (Name,Price, [Description], ImageUrl, TypeID, Active) values ('Necklace6',3.0,'Necklace Set','image\Necklace6.jpg',2,1);
insert into jade.tblProduct (Name,Price, [Description], ImageUrl, TypeID, Active) values ('Necklace7',3.0,'Necklace Set','image\Necklace7.jpg',2,1);
insert into jade.tblProduct (Name,Price, [Description], ImageUrl, TypeID, Active) values ('Necklace8',3.0,'Necklace Set','image\Necklace8.jpg',2,1);
insert into jade.tblProduct (Name,Price, [Description], ImageUrl, TypeID, Active) values ('Necklace9',3.0,'Necklace Set','image\Necklace9.jpg',2,1);
insert into jade.tblProduct (Name,Price, [Description], ImageUrl, TypeID, Active) values ('Necklace10',3.0,'Necklace Set','image\Necklace10.jpg',2,1);


insert into jade.tblInventory values(2005,10,0);
insert into jade.tblInventory values(2006,10,0);
insert into jade.tblInventory values(2007,15,0);
insert into jade.tblInventory values(2008,15,0);
insert into jade.tblInventory values(2009,12,0);
insert into jade.tblInventory values(2010,9,0);
insert into jade.tblInventory values(2011,8,0);
insert into jade.tblInventory values(2012,5,0);
insert into jade.tblInventory values(2013,6,0);
insert into jade.tblInventory values(2014,10,0);
insert into jade.tblInventory values(2015,15,0);
insert into jade.tblInventory values(2016,12,0);
insert into jade.tblInventory values(2017,13,0);
insert into jade.tblInventory values(2018,14,0);
insert into jade.tblInventory values(2019,13,0);
insert into jade.tblInventory values(2020,10,0);
insert into jade.tblInventory values(2021,8,0);
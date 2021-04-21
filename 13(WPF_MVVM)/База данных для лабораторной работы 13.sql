use master;

CREATE DATABASE SHOP;

use SHOP;

CREATE TABLE PRODUCT
(
id int identity(1,1) constraint PK_PRODUCT primary key (id),
productName varchar(50) NOT NULL,
price decimal NOT NULL,
quantity int NOT NULL default('0')
)
use master;

CREATE DATABASE CLOTHES;
DROP DATABASE CLOTHES;

USE CLOTHES;

CREATE TABLE CLOTHES_SIZES
(
ID int  not null identity(1,1) constraint PK_SIZES primary key(ID) ,
RUSSIAN_SIZE_CLOTH int,
USA_SIZE_CLOTH char(5),
RUSSIAN_SIZE_SHOOES int,
USA_SIZE_SHOOES numeric(3,1)
)

CREATE TABLE CLOTHES
(
SHORT_NAME nvarchar(255) not null,
FULL_NAME nvarchar(255) not null constraint PK_CLOTHES primary key(FULL_NAME),
DESCRIPTION_CLOTH nvarchar(1028) not null,
IMAGE_ADRESS image not null,
CATEGORY nvarchar(50) not null,
RATE int not null,
COST money not null,
COLOR nvarchar(255),
SIZE int
)

go
CREATE PROCEDURE INSERT_PRODUCT @sn nvarchar(255), @fn nvarchar(255),@dc nvarchar(1028), @ia char(255), @ctgr nvarchar(50), @rate int, @cost money, @clr nvarchar(255),@size int,@Id int out
as
begin
	INSERT into CLOTHES values(@sn,@fn,@dc, @ia, @ctgr, @rate, @cost, @clr,@size )
	SET @Id=SCOPE_IDENTITY()
end;

DROP PROCEDURE INSERT_PRODUCT

insert into CLOTHES(SHORT_NAME,FULL_NAME,DESCRIPTION_CLOTH,CATEGORY,RATE,COST,COLOR,SIZE,IMAGE_ADRESS)
SELECT 'Джемпер','Мужской джемпер','Зимний мужской джемпер','Одежда','10','15','Чёрный', '33', BulkColumn
FROM Openrowset( Bulk 'D:\ALEX\STUDY\4SEM_2COURSE\ООТП\Лабораторные работы\6-7,8(WPF_shop_service,WPF_ресурсы_стили_триггеры)\WearShop\WearShop\Pictures\джемпер.jfif', Single_Blob) as img

insert into CLOTHES(SHORT_NAME,FULL_NAME,DESCRIPTION_CLOTH,CATEGORY,RATE,COST,COLOR,SIZE,IMAGE_ADRESS)
SELECT 'Nike Air Monarch','Кроссовки','Белые кроссовки','Обувь','9','36','Белый', '40', BulkColumn
FROM Openrowset( Bulk 'D:\ALEX\STUDY\4SEM_2COURSE\ООТП\Лабораторные работы\6-7,8(WPF_shop_service,WPF_ресурсы_стили_триггеры)\WearShop\WearShop\Pictures\кроссовки.jfif', Single_Blob) as img

TRUNCATE TABLE CLOTHES
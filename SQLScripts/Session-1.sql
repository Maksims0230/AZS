use master
go

create database [AZS_Db]
go

use [AZS_Db]
go

create table [FuelType]
(
	[FuelName] [nvarchar] (100) not null primary key
)
go

create table [Station]
(
	[Station_ID] [int] not null primary key constraint [CheckValue] check ([Station_ID]> 0 and [Station_ID] < 100),
	[Address] [nvarchar] (max) not null
)
go

create table [Data] 
(
	[Id] [int] not null identity (1, 1) primary key,
	[Name] [nvarchar] (100) not null constraint [FK_data_FuelType] foreign key ([Name]) references [FuelType] ([FuelName]) ON UPDATE CASCADE ON DELETE CASCADE,
	[Price] [decimal](38,2) not null default 0.0,
	[AmountOfFuel] [int] not null default 0,
	[Station_ID] [int] not null constraint [FK_Data_Station] foreign key ([Station_ID]) references [Station] ([Station_ID]) ON DELETE CASCADE,
)
go


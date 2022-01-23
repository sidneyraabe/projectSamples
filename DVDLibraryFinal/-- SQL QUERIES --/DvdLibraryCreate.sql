USE [master]
GO

if exists (select * from sys.databases where name = N'DvdLibraryApp')
begin
	EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'DvdLibraryApp';
	ALTER DATABASE DvdLibraryApp SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE DvdLibraryApp;
end

CREATE DATABASE DvdLibraryApp;
GO

USE DvdLibraryApp;
GO

CREATE TABLE DVD (
Id int identity(1,1) primary key,
Title nvarchar(50) not null,
ReleaseYear int not null,
Director nvarchar(50) not null,
Rating varchar(5) not null,
Notes nvarchar(100) null
)

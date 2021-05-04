use usersdb
create table UserInfo(
	Id int primary key identity(1, 1),
	UserLog_Id int,
	Name nvarchar(50) not null,
	LastName nvarchar(50) not null,
	Mail nvarchar(50) not null,
	Birthday date not null,
	ImageData varbinary(max) not null)
select * from UserInfo
drop table UserInfo
delete from UserInfo where Id = 1

delete from UserInfo where UserLog_Id = @UserLog_Id
insert into UserInfo(Name, LastName, Mail, Birthday, ImageData, UserLog_Id)
                values(@name, @lastName, @mail, @birthDay, @imageData, @UserLog_Id)

create table UserLogInfo(
	Id int primary key identity(1, 1),
	Password int not null,
	NickName nvarchar(50))

select * from UserLogInfo
insert into UserLogInfo(Password, NickName)
values(123, 'Anton')
delete from UserLogInfo where Id = 1
drop table UserLogInfo
-------------------------------------------------

go
create procedure [dbo].[checkLog]
	@logedUser int out,
	@password int,
	@nickName nvarchar(50)
	as
	set @logedUser = (select count(*) from UserLogInfo where Password = @password and NickName = @nickName	)
go
create procedure [dbo].[getUserInfo]
	@password int,
	@nickName nvarchar(50),

	@Name nvarchar(50) out,
	@LastName nvarchar(50) out,
	@Mail nvarchar(50) out,
	@Birthday date out,
	@ImageData varbinary(max) out
	as
	select @Name = 
	from UserLogInfo ul inner join UserInfo ui on ul.Id = ui. where Password = @password and NickName = @nickName	)
go

CREATE PROCEDURE [dbo].[sp_InsertUser]
	@UserLog_Id int,
    @name nvarchar(50),
    @lastName nvarchar(50),
	@mail nvarchar(50),
	@birthDay date,
	@imageData varbinary(max)
AS
    insert into UserInfo(Name, LastName, Mail, Birthday, ImageData, UserLog_Id)
                values(@name, @lastName, @mail, @birthDay, @imageData, @UserLog_Id)
GO
create procedure [dbo].[editUser]
	@password int,
	@nickName nvarchar(50),

    @name nvarchar(50),
    @lastName nvarchar(50),
	@mail nvarchar(50),
	@birthDay date,
	@imageData varbinary(max)
AS
	declare @UserLog_Id int = (select top(1) ul.Id from UserLogInfo ul where Password = @password and NickName = @nickName)
	delete from UserInfo where UserLog_Id = @UserLog_Id

    insert into UserInfo(Name, LastName, Mail, Birthday, ImageData, UserLog_Id)
                values(@name, @lastName, @mail, @birthDay, @imageData, @UserLog_Id)
go

drop procedure editUser


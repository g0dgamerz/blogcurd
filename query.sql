create table blog(
id int identity(1,1) not null,
title varchar(50),
body varchar(500)
)

create procedure blogInsert @title varchar(50),@body varchar(500)
as
begin
insert into blog values (@title,@body)
end

create procedure blogSelect
as
	select * from blog
go


create procedure blogSelectbyid @id nchar(10)
as
select * from blog where id= @id
go

create procedure blogUpdate @id int,@title varchar(50),@body varchar(500)
AS
	Update blog set title=@title,body=@body where id=@id
GO

create procedure blogDelete @id int
AS
	Delete from blog where id=@id
GO

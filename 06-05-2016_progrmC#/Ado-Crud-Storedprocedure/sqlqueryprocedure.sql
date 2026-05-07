use TaskDB
use DemoDB
use employeedb;
---in employeedb
select * From TblUsers

insert into TblUsers (username , password , Firstname) 
values ('prakash_123','india@123','Prakash');
sp_tables


---select count(*) from TblUsers where username = '{username}' and password='{password}
--demodb
select * from Student


--creating a stored procedure to insert a record
create procedure sp_AddStudent 
@Name varchar(30), @Course varchar(30)
as
begin
	Begin Transaction 
	   insert into student (name,course)values(@Name,@Course)
	Commit transaction 
end

select * from Student;

-- create a procedure that give the identity value 
create procedure Sp_StudentIdente @countident int out 
as 
begin 
	SELECT @countident=IDENT_CURRENT('Student');
end;

declare @lastid int ;
execute Sp_StudentIdente @countident=@lastid out;
print @lastid

select max(id) from  student;


-- creating procedure for deletion 
Alter  procedure Sp_UpdateStudent @name varchar(30) , @Course varchar(30) , @id int 
as
begin
	begin Transaction 
		update Student set Name=@name , Course=@Course where  Id=@id
	commit Transaction 
end;

exec Sp_UpdateStudent 'shiva','java',12;

select * from Student;


-- create a procedure to delete the records 

create  procedure Sp_deleteStudentDetaild @id int
as 
begin 
	begin Transaction

	delete from student where id=@id
	commit Transaction
end ;

Execute Sp_deleteStudentDetaild 1;


--- Creation the Stored Procedure to display
create procedure Sp_DisplayStudentDetails 
as
begin
	begin Transaction 
		select * from Student
	commit Transaction
end;

Execute Sp_DisplayStudentDetails





CREATE DATABASE ProductDb
USE ProductDb


CREATE TABLE Products(
ProductId int primary key Identity(1,1),
ProductName varchar(25) not null,
Category varchar(25) ,
Price   money );

select * from Products;











--- creation Of WebAPIadoCRUDDB
create database WebAPIadoCRUDDB;
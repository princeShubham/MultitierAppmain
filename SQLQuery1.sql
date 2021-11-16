alter proc sp_insert_employee
@name varchar(100)=null,
@email varchar(100)=null,
@salary money=0
as
begin
insert into employees (name,email,salary)values
(@name,@email,@salary)
select 1 as created
end;



create proc sp_update_employee
@id int,
@name varchar(100),
@email varchar(100),
@salary money
as
begin
update employees set name=@name,email=@email,salary=@salary where id=@id
select 1 as updated
end

create proc sp_delete_employee
@id int
as
begin
delete from employees where id=@id
select 1 as deleted
end

create proc sp_get_employee_byid
@id int
as
begin
select* from employees where id=@id
end

exec sp_get_employee_byid 2




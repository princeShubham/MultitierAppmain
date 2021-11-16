create table employees
(id int primary key identity,
name varchar(100),
email varchar(100),
salary money
);

create proc sp_get_employees
as
begin
select* from employees;
end

exec sp_get_employees

insert into employees values
('deepak','deepak89@gmail.com',12000),
('rohit','rohit9@gmail.com',16000)





















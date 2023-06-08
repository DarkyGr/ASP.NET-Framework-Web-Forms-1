-- ============ DATABASE ===============
create database db_AspNetWebForms1

use db_AspNetWebForms1


-- ============ TABLES ===============
create table Department(
	departmentId int primary key identity,
	departmentName varchar(50)
)

create table Employee(
	employeeId int primary key identity,
	employeeName varchar(50),
	departmentId int references Department(departmentId),
	salary decimal(10,2),
	contractDate date
)


-- ============ DATA ===============
insert into Department (departmentName) values
('Management'),
('Commerce'),
('Sales'),
('Marketing')

insert into Employee (employeeName, departmentId, salary, contractDate) values
('John Smith', 3, 2000, getdate())


-- ============ Functions ===============
-- *** READ ***
create function fn_departments()
returns table
as return
	select departmentId, departmentName from Department


create function fn_employees()
returns table
as return
	select e.employeeId, e.employeeName, 
	d.departmentId, d.departmentName, 
	e.salary, convert(char(10), e.contractDate, 103)[contractDate]
	from Employee e
	inner join Department d on d.departmentId = e.departmentId

create function fn_employee(@employeeId int)
returns table
as return
	select e.employeeId, e.employeeName, 
	d.departmentId, d.departmentName, 
	e.salary, convert(char(10), e.contractDate, 103)[contractDate]
	from Employee e
	inner join Department d on d.departmentId = e.departmentId
	where e.employeeId = @employeeId


-- ============ Stored Procedures ===============
-- *** CREATE ***
create proc sp_CreateEmployee(
	@employeeName varchar(50),
	@departmentId int,
	@salary decimal(10,2),
	@contractDate date
)
as
begin
	set dateformat dmy
	insert into Employee(employeeName, departmentId, salary, contractDate) values (
		@employeeName, 
		@departmentId, 
		@salary, 
		CONVERT(date, @contractDate)
	)
end

-- *** UPDATE ***
create proc sp_UpdateEmployee(
	@employeeId int,
	@employeeName varchar(50),
	@departmentId int,
	@salary decimal(10,2),
	@contractDate date
)
as
begin
	set dateformat dmy	
	update Employee set
		employeeName = @employeeName,
		departmentId = @departmentId,
		salary = @salary,
		contractDate = CONVERT(date, @contractDate)
	where employeeId = @employeeId
end

-- *** DELETE ***
create proc sp_DeleteEmployee(
	@employeeId int
)
as
begin
	delete from Employee
	where employeeId = @employeeId
end
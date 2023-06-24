--UC1 create Database--
create database payroll_service
use payroll_service
--UC2- Create Table--
create table employee_payroll (id int identity(1,1) primary key, name varchar(200),salary int, startdate date)
select * from employee_payroll
--UC3 Insert--
insert into employee_payroll values('Ganapati', 50000,'2023-06-21'),('Sonali',30000,'2022-10-05'),
('Panu',30000,'2022-10-06')
--UC4 Retrive Data--
select * from employee_payroll
--UC5 retrive salary data for a particular employee  and joined date
select * from employee_payroll where name='Ganapati'
select * from employee_payroll where startdate between cast ('2023-06-21' as date) and getdate();
--UC6 Ability to add Gender column and reflect it in table--
alter table employee_payroll add gender varchar(200)
update employee_payroll set gender='M' where name='Ganapati'
update employee_payroll set gender='F' where name='Sonali'
update employee_payroll set gender='F' where name='Panu'
select * from employee_payroll
--UC7 Agragate Functions--
--Function Sum
select sum(salary) as TotalSum from employee_payroll
--Fuction Avg
select avg(salary) as TotalAvg from employee_payroll
--Function Min
select min(salary) as MinSalary from employee_payroll
--Function Max
select max(salary) as MaxSalary from employee_payroll
--Function Count
select count(salary) as TotalRecords from employee_payroll
--Group By Gender
select sum(salary) as TotalSum from employee_payroll where gender='F' group by gender

--UC8 Ability to extend Employee Payroll data info like phone,address,department
alter table employee_payroll add
phonenumber bigint,
address varchar(200) not null default 'Address Unavailable',
department varchar(200) not null default 'General Dept' 
select * from employee_payroll

--UC9 Ability to extend table to Basic pay,Deduction,Taxable pay,Income tax,Net pay
alter table employee_payroll add BasicPay float, Deduction float, TaxablePay float, IncomeTax float,NetPay float

--UC10 Make Ganapati as a part of Sales and Marketing Department
update employee_payroll set
	phonenumber=7798051897,
	address='Bhandara',
	department='Sales',
	BasicPay=20000,
	Deduction=2000,
	TaxablePay=1000,
	IncomeTax=200,
	NetPay=18000 where name='Ganapati'
select * from employee_payroll
--here Ganapati works in Sales and Marketing even though he is one 
--person but in table it shows two names with different departments
insert into employee_payroll values('Ganapati',30000,'2022-10-04','M',7798051897,'Bhandara','Marketing',20000,2000,1000,200,18000);
select * from employee_payroll where name='Ganapati'
select name from employee_payroll order by name desc
select * from employee_payroll
--UC11 Implementation of ER Diagram and creating tables given in th diagram
--1)Creating Department Table 
create table Departments (Dept_id int identity(1,1) primary key,Dept_Name varchar(200))
--Inserting Values to the Dept table
insert into Departments values('Sales'),('Marketing'),('Account'),('Store'),('HR');
--2)Creating Company table
create table Company(Comp_id int identity (1,1) primary key,comp_name varchar(200))
--Inserting Values in Company table
insert into Company values('Bosch'),('Veritas'),('TCS'),('Microsoft'),('Infosys')
--3)Creating Employee Table (Columns name taken Randomly)
create table Employee
	(Emp_id int identity(1,1) primary key,
	Deptid int foreign key references Departments(Dept_id),
	Emp_name varchar(200),
	Emp_Gender varchar(10),
	phonenumber varchar(15),
	Emp_address varchar(200),
	Company_id int foreign key references Company(Comp_id));
	--Inserting Values in the table
insert into Employee values
	(1,'Hemant','M','7798051897','Bhandara',1),
	(2,'Sonu','M','7788554422','Banglore',2),
	(3,'bhagyashree','F','7744115897','Nagpur',3),
	(4,'Prachi','F','9632589632','Pune',4),
	(5,'Nikhil','M','8899556327','Latur',5);

	--4)Creating payroll Table
create table Payroll
(Emp_id int foreign key references Employee(Emp_id),
	BasicPay float,                          --taking data type float because it may be in decimal value
	Deduction float,
	TaxablePay float,
	IncomeTax float,
	NetPay float);
	--Inserting Values in the Table
	select * from Employee
	select * from Payroll
insert into Payroll values
(1,60000,3000,1100,700,55000),
(2,70000,4000,1400,600,65000),
(3,80000,5000,2000,800,73000),
(4,50000,2500,1200,300,41000),
(5,60000,3500,1600,500,56000);
--UC12 Retrieve all data from the queries	
--UC4 reusing to make sure it working fine

select * from Departments;
select * from Company;
select * from Employee;
select * from Payroll;

--UC5 reusing
--comparing two tables to get output for UC5
select Employee.Emp_id,Employee.Emp_name,Payroll.BasicPay,Payroll.NetPay
from Employee, Payroll
where Employee.Emp_id=Payroll.Emp_id;

--UC7 reusing

--Count function to check total count of employees present
select COUNT(Emp_id) as TotalEmployee from Employee;
--Min function 
select MIN(BasicPay) as MinPay from Payroll;
--Max function
select MAX(BasicPay) as MaxPay from Payroll;
--Avg function
select AVG(BasicPay) as AvgPay from Payroll;
--Sum function group by gender
select SUM(BasicPay) as TotalSum from Employee,Payroll where Emp_Gender='M' group by Emp_Gender
--Sum function grop by Employee name
select Employee.Emp_name,SUM(BasicPay) as TotalSum from Employee,Payroll group by Emp_name

select * from Payroll;


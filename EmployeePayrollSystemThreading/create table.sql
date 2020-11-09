create database payroll;

use payroll;

create table EmployeePayroll
(
EmployeeID int primary key not null,
EmployeeName varchar(50) not null,
PhoneNumber decimal not null,
Address varchar(50),
Department varchar(50) not null,
Gender char not null,
BasicPay decimal not null,
Deductions decimal ,
TaxablePay decimal,
Tax decimal,
NetPay decimal,
City varchar(50) , 
Country varchar(50) 
)

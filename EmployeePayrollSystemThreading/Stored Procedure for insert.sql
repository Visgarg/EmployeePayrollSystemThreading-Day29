use payroll;

create procedure spInsertData
(
@EmployeeId int,
@EmployeeName varchar(50),
@PhoneNumber varchar(50),
@Address varchar(50),
@Department varchar(50),
@Gender char ,
@BasicPay decimal,
@Deductions decimal ,
@TaxablePay decimal,
@Tax decimal,
@NetPay decimal,
@City varchar(50) , 
@Country varchar(50) 
)

select * from EmployeePayroll;
as
begin 
insert into EmployeePayroll 
values(@EmployeeId,@EmployeeName,@PhoneNumber,@Address,@Department,@Gender,@BasicPay,@Deductions,@TaxablePay,@Tax,@NetPay,@City,@Country);
end

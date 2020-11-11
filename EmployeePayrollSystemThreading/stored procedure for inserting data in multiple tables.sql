--Stored Procedure for insertion in multiple table
alter Procedure insertingdatainmultipletable
(
@basicpay decimal,
@deductions decimal,
@taxablepay decimal,
@tax decimal,
@netpay decimal,
@employeeid int,
@employeename varchar(150),
@gender char,
@phonenumber decimal,
@address varchar(150),
@department varchar(50),
@city varchar(30),
@country varchar(30)
)
as
Begin
     --set nocount on added to prevent extra result sets from
	 --interfering with select statements
Set nocount on;
begin try
Begin transaction
declare @employeeidExists int

			select @employeeidExists= employeeid from employees where EmployeeId=@employeeid;
			--insert into payroll_detail table secondly
			if(@employeeidExists is null)

				insert into payroll_details values(@employeeid,@basicpay,@deductions,@taxablepay,@tax,@netpay)

			if(@employeeidExists is null)
				 --insert into employeetable first
				insert into employees values(@employeeid,@employeename,@phonenumber,@address,@city,@country,@department,@gender)
			

 --if not error, commit transaction 
commit transaction
End Try
Begin catch
--if error, roll back changes done by any of the sql queries
Rollback transaction
End catch
End

Exec insertingdatainmultipletable 25000,2000,23000,3000,20000,1,'Vishal','M','8570934858','Barwala','IT','Hisar','Haryana'
select * from employees
select * from payroll_details
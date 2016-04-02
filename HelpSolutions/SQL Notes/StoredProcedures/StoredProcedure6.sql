-- =============================================
-- Author:		Michael Whitfield
-- Create date: 3/16/2016
-- Description:	<Description,,>
-- =============================================
--CREATE PROCEDURE GetEmployeesByAddressID
Alter PROCEDURE GetEmployeesByAddressID
	@AddressId INT
AS
BEGIN

	SET NOCOUNT ON;


	select 
	--write case statement
	--case 
	--	when Salary > 5000 then 'High'
	--	when Salary <= 5000 then 'Low'
	--end as 'Salary'

	--ISNULL(e.AddressId, 0) as 'AddressId', -- Use ifyou can use coalese, but use coalese (its standard)

	Coalesce(e.AddressId, 0) as 'AddressId' -- if value is null return a 0 in its place

	e.Id as 'EmployeeId',
	e.Name as 'EmployeeName',
	e.Salary,
	a.Id as 'Address Id'

	from Employee e
	--inner join [Address] a on e.Addressid = a.Id
	where e.AddressId = @AddressId or e.AddressId is null
END 
GO
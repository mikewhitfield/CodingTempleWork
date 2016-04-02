-- =============================================
-- Author:		Michael Whitfield
-- Create date: 3/16/2016
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE GetEmployeesByPositionName
	@PositionName varChar(50)
AS
BEGIN

	SET NOCOUNT ON;


	select 
	e.Id as 'EmployeeId',
	e.Name as 'EmployeeName',
	e.Salary,
	p.Name as 'Position Name'

	from Employee e
	inner join Position p on e.Positionid = p.Id

	where p.Name = @PositionName
END 
GO


-- =============================================
-- Author:		Michael Whitfield
-- Create date: 3/16/2016
-- Description:	<Description,,>
-- =============================================
Alter PROCEDURE GetEmployeePositionById
	@EmployeeId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--Select * from Employee e
	--Select * from Position p

	select 
	e.Id as 'EmployeeId',
	e.Name as 'EmployyeName',
	e.Salary,
	p.Name as 'Position'

	from Employee e
	inner join Position p on e.Positionid = p.Id

	where e.Id = @EmployeeId
	--where p.Id = @EmployeeId
END 
GO

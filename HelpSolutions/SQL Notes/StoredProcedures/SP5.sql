-- =============================================
-- Author:		Michael Whitfield
-- Create date: 3/16/2016
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE GetEmployeesByLevelId
	@LevelId INT
AS
BEGIN

	SET NOCOUNT ON;


	select 
	e.Id as 'EmployeeId',
	e.Name as 'EmployeeName',
	e.Salary,
	l.Id as 'Level ID'

	from Employee e
	inner join Position p on e.Positionid = p.Id
	inner join [level] l on p.LevelId = P.Id

	where l.Id = @LevelId
END 
GO
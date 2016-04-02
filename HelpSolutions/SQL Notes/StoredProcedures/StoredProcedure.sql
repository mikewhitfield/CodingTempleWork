-- =============================================
-- Author:		Michael Whitfield
-- Create date: 3/16/2016
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE GetEmployeesByLevelName
	@LevelName varChar(50)
AS
BEGIN

	SET NOCOUNT ON;


	select 
	e.Id as 'EmployeeId',
	e.Name as 'EmployeeName',
	e.Salary,
	l.Name as 'Level Name'

	from Employee e
	inner join Position p on e.Positionid = p.Id
	inner join [level] l on p.LevelId = P.Id

	where l.Name = @LevelName
END 
GO

USE Store

go

--truncate table [Level]

--INsert into [Level](Name)
--values('Mid Level'),('Entry Level'), ('Senior Level')
-- values ('Junior Level')
--select * from [Level]

--INSERT INTO Position
--            (Levelid, NAME)

--VALUES      (1,'.Net Developer'),
--            (2,'.Net Developer'),
--            (3,'.Net Developer'),
--            (4,'.Net Developer'),
--            (1,'Web Developer'),
--            (2,'Web Developer'),
--            (3,'Web Developer'),
--            (4,'Web Developer')

--SELECT *
--FROM   POsition 

--begin tran 

--delete from [Position]
--Where Levelid = 4;

--commit

--SELECT *
--FROM   POsition

--Select * from [Level]
--Select * from Position 

--Select * from [Level] l
--select
--l.Name as 'Level Name', -- give them aliases
--p.Name as 'PostionName',
--e.id  as 'EmployeeId',
--e.Name as 'EmployeeName',
--e.AddressId,
--e.salary
--from [level]l
--inner join Position p on l.id = p.LevelId
--join Employee  e on p.Id = e.PositionId

--select * from vwEmployeePosition


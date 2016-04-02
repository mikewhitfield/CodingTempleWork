


select 
	*
from (
	select e.*, 
	p.LevelId, 
	p.Name as 'Position Name'
	
	from Employee e
	join Position p 
	on e.PositionId = p.Id
	where e.Salary > 800)  ep -- SubQuery - runs small query first (makes temp table stored in ep (derived table),	
	Join [level] l
	on ep.LevelId = l.id
where l.Id =3

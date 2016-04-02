--Select * 
--Into #temp
--from Employee e

--Select * from #temp


Select e.*,
p.LevelId,
l.Name as 'Level Name'
Into #temp
from Employee e
	Join position p
	on e.positionId = p.Id
	join [Level] l
	on p.LevelId = l.Id


Select * from #temp
-- delete , update
begin tran
--select * 
-- delete from Employee
	--delete e
	--select *
	update p
	 set p.Name = 'Ux Designer'
	from Employee e	
	inner join Position p on e.PositionId = p.Id

	where p.Name = 'Web Developer' 
	--and p.LevelId =1
	

rollback
--commit

--select * from Employee
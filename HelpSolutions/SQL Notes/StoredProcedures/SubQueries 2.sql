--In Claus
--SELECT *
--FROM   [Level]l
--WHERE  l.Id IN (SELECT p.LevelId
--                FROM   Employee e
--                       JOIN Position p
--                         ON e.PositionId = p.Id
--                WHERE  e.Salary > 800)


-- Exists
--SELECT *
--FROM   [Level]l
--WHERE  Exists (SELECT p.LevelId
--                FROM   Employee e
--                       JOIN Position p
--                         ON e.PositionId = p.Id
--                WHERE  l.Id  = p.LevelId) -- doesnot create an alias as soon as subquery run it deletes
--										  -- in an exist always return Id 
--										  -- find out how long it took to run the query - 'INclude client Statistics'

-- Quicker way to run subquery than running in where clause
SELECT *
FROM  (
		SELECT p.LevelId
        FROM   Employee e
                JOIN Position p
                    ON e.PositionId = p.Id
        WHERE  e.Salary > 800) ep
		join  [Level] l on l.Id = ep.LevelId
WHERE  l.Id  = ep.LevelId
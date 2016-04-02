use cityTour
go

-- Display 3 Products From each category on index page, and caterogry page (default)

create View  GetFeaturedProducts as

select 
p.Id,
p.ImageUrl, 
p.Price, 
p.Name, 
c.Name as 'CategoryName'
			 
from Product p
inner join featured f on p.Id = f.ProductId
inner join Category c on c.Id = p.CategoryId
 
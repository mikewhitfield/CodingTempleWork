Use CityTour 

go

create view GetGalleryImages AS

Select pic.URL
from ProductImage pic 
inner join Product p  on p.Id = pic.ProductId 

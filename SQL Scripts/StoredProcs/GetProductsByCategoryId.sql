use CityTour
go

-- =============================================
-- Author:		Michael Whitfield
-- Create date: 3/18/2016
-- Description:	<filter results by category type: Museum, Histori Building, Church>
-- =============================================
Create PROCEDURE GetProductsByCategoryId
	@CategoryId INT
AS
BEGIN

	SET NOCOUNT ON;

	select 
	p.Id,
	p.ImageUrl as 'ProductImage',
	p.Summary as 'Summary',
	p.Price as 'Price',
	p.Name as 'ProductName'
	
	from Product p
	where p.CategoryId = @CategoryId
END 
GO
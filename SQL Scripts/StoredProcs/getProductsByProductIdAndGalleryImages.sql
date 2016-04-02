use CityTour
go

-- =============================================
-- Author:		Michael Whitfield
-- Create date: 3/18/2016
-- Description:	<Show the Product information on the details page>
-- =============================================

alter PROCEDURE GetInfoByProductId
	@ProductIdInfo INT
AS
BEGIN

	SET NOCOUNT ON;
	select 
	p.ImageUrl as 'Product Image',
	p.Summary as 'Summary',
	pic.Url
	
	from Product p
	inner join ProductImage pic on p.Id = pic.ProductId
	where p.Id = @ProductIdInfo
END 
GO
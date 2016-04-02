use CityTour
go


-- =============================================
-- Author:		Michael Whitfield
-- Create date: 3/18/2016
-- Description:	<Show the Product Images associated with the chosen product>
-- =============================================
Create PROCEDURE GetProductpicsById
	@ProductPic INT
AS
BEGIN

	SET NOCOUNT ON;
 
	select pic.URL

	from ProductImage pic
	inner join Product p on p.Id = pic.ProductId

	where pic.ProductId = @ProductPic -- this would be the product Id actually
END 
GO
use CityTour
go

-- =============================================
-- Author:		Michael Whitfield
-- Create date: 3/18/2016
-- Description:	<Show the Product information on the details page>
-- =============================================
Create PROCEDURE GetProductsByProductId
	@ProductId INT
AS
BEGIN

	SET NOCOUNT ON;

	select 
	p.ImageUrl as 'Product Image',
	p.Summary as 'Summary'
	
	from Product p
	where p.Id = @ProductId
END 
GO
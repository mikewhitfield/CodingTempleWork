USE [Store]
GO
/****** Object:  StoredProcedure [dbo].[GetEmployeesByLevelId]    Script Date: 3/21/2016 10:22:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Michael Whitfield
-- Create date: 3/16/2016
-- Description:	<Description,,>
-- =============================================
Alter PROCEDURE [dbo].[GetEmployeesByAddressId]
	@AddressId INT
AS
BEGIN

	SET NOCOUNT ON;


	select 
	e.Id ,
	e.Name ,
	e.PositionId,
	e.AddressId,
	e.Salary

	from Employee e
	where AddressId = @AddressId

END 

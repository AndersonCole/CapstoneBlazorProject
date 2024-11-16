CREATE PROCEDURE spModifyRoute (
	@RouteId int,
	@Name nvarchar(50),
	@Order int
)
AS
BEGIN
SET NOCOUNT ON
UPDATE routes
SET route_name = @Name, progression_order = @Order
WHERE route_id = @RouteId
END
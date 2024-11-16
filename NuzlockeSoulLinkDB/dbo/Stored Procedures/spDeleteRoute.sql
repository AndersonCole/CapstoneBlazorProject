CREATE PROCEDURE [dbo].[spDeleteRoute] (
	@RouteId int
)
AS
BEGIN
SET NOCOUNT ON
DELETE re
FROM run_encounters as re
WHERE re.route_id = @RouteId

DELETE r
FROM routes as r
WHERE r.route_id = @RouteId
END
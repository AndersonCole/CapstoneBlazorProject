CREATE PROCEDURE [dbo].[spGetRoutesFromGameId] (
	@GameId int
)
AS
BEGIN
SET NOCOUNT ON
SELECT route_id, game_id, route_name, progression_order
FROM routes
WHERE game_id = @GameId
END
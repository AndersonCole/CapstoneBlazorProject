CREATE PROCEDURE [dbo].[spCreateNewRoute] (
	@GameId int,
	@Name nvarchar(50),
	@Order int
)
AS
DECLARE @RouteId int;
BEGIN
SET NOCOUNT ON
INSERT INTO routes (game_id, route_name, progression_order)
VALUES (@GameId, @Name, @Order)

SET @RouteId = SCOPE_IDENTITY();

--loads new route into any active runs
INSERT INTO run_encounters (run_player_id, route_id, dex_number, is_alive)
SELECT rp.run_player_id, @RouteId AS route_id, NULL, NULL
FROM run_players rp
JOIN runs r ON rp.run_id = r.run_id
WHERE r.game_id = @GameId;
END
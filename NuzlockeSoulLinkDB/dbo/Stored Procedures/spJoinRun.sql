CREATE PROCEDURE [dbo].[spJoinRun] (
	@PlayerId int,
	@RunId int
)
AS
DECLARE @RunPlayerId int;
BEGIN
SET NOCOUNT ON
INSERT INTO run_players (player_id, run_id)
VALUES (@PlayerId, @RunId)

SET @RunPlayerId = SCOPE_IDENTITY();

--pre loads run encounters table
INSERT INTO run_encounters (run_player_id, route_id, dex_number, is_alive)
SELECT @RunPlayerId, rt.route_id, NULL, NULL
FROM routes as rt
JOIN runs as r ON r.game_id = rt.game_id
WHERE r.run_id = @RunId

-- pre loads run battles table
INSERT INTO run_battles (run_player_id, battle_id, pokemon_used, battle_completed)
SELECT @RunPlayerId, b.battle_id, NULL, 0
FROM battles as b
JOIN runs as r ON r.game_id = b.game_id
WHERE r.run_id = @RunId
END

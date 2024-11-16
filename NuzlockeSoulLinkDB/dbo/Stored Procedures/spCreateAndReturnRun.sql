CREATE PROCEDURE [dbo].[spCreateAndReturnRun] (
	@RunName nvarchar(50),
	@RunDescription nvarchar(255),
	@Password nvarchar(255),
	@RunCreatorId int,
	@MaxPlayers int,
	@GameId int,
	@CreatedDate datetimeoffset,
	@LastUpdated datetimeoffset
)
AS
DECLARE @RunId int
DECLARE @RunPlayerId int;
BEGIN
SET NOCOUNT ON
--creates run entry
INSERT INTO runs(run_name, run_description, run_password, run_creator_id, max_players, game_id, created_date, last_updated, run_complete)
VALUES(@RunName, @RunDescription, @Password, @RunCreatorId, @MaxPlayers, @GameId, @CreatedDate, @LastUpdated, 0)

SET @RunId = SCOPE_IDENTITY();

--creates run_players entry
INSERT INTO run_players (player_id, run_id)
VALUES (@RunCreatorId, @RunId)

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

SELECT @RunId
END
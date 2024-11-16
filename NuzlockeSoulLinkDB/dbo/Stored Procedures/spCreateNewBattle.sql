CREATE PROCEDURE [dbo].[spCreateNewBattle] (
	@GameId int,
	@Name nvarchar(50),
	@Location nvarchar(50),
	@PokemonUsed nvarchar(50),
	@HighestLevel int,
	@ImageLink nvarchar(max),
	@Order int
)
AS
BEGIN
DECLARE @BattleId int;
SET NOCOUNT ON
INSERT INTO battles (game_id, battle_name, battle_location, pokemon_used, highest_level, image_link, progression_order)
VALUES (@GameId, @Name, @Location, @PokemonUsed, @HighestLevel, @ImageLink, @Order)

SET @BattleId = SCOPE_IDENTITY();

--loads new battle into any active runs
INSERT INTO run_battles (run_player_id, battle_id, pokemon_used, battle_completed)
SELECT rp.run_player_id, @BattleId AS battle_id, NULL, 0
FROM run_players rp
JOIN runs r ON rp.run_id = r.run_id
WHERE r.game_id = @GameId;
END
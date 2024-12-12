CREATE PROCEDURE [dbo].[spGetBattlesFromGameId] (
	@GameId int
)
AS
BEGIN
SET NOCOUNT ON
SELECT battle_id, game_id, battle_name, battle_location, pokemon_used, highest_level, progression_order, image_link
FROM battles
WHERE game_id = @GameId
END
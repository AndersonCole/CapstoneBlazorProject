CREATE PROCEDURE [dbo].[spGetBattlesFromRunId] (
	@RunId uniqueidentifier
)
AS
BEGIN
SET NOCOUNT ON
SELECT rb.run_battle_id, rb.run_player_id, rb.pokemon_used, rb.battle_completed, b.battle_id as battle_id, b.game_id, b.battle_name, b.battle_location, b.pokemon_used, b.highest_level, b.progression_order, b.image_link
FROM run_battles as rb
JOIN run_players as rp ON rb.run_player_id = rp.run_player_id
JOIN battles as b ON rb.battle_id = b.battle_id
WHERE rp.run_id = @RunId
END
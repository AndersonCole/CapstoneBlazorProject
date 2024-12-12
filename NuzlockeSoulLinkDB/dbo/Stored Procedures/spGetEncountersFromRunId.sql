CREATE PROCEDURE [dbo].[spGetEncountersFromRunId] (
	@RunId uniqueidentifier
)
AS
BEGIN
SET NOCOUNT ON
SELECT encounter_id, re.run_player_id, re.dex_number, p.pokemon_name, is_alive, r.route_id, r.game_id, r.route_name, r.progression_order
FROM run_encounters as re
JOIN run_players as rp ON re.run_player_id = rp.run_player_id
JOIN routes as r ON re.route_id = r.route_id
LEFT JOIN pokemon as p ON re.dex_number = p.dex_number
WHERE rp.run_id = @RunId
END
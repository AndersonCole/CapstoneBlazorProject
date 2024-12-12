CREATE PROCEDURE [dbo].[spGetOngoingRunsByGen] (
	@GenId int
)
AS
BEGIN
SET NOCOUNT ON
SELECT runs.run_id, runs.game_id, games.game_name, run_creator_id, p.username as run_creator_name, run_name, run_password, run_description, max_players, runs.created_date, runs.last_updated, run_complete, run_player_id, rp.player_id, rp.run_id
FROM runs
JOIN games ON runs.game_id = games.game_id
JOIN players as p ON p.player_id = runs.run_creator_id 
JOIN run_players as rp ON runs.run_id = rp.run_id
WHERE run_complete = 0
AND games.gen_id = @GenId
ORDER BY runs.last_updated DESC;
END
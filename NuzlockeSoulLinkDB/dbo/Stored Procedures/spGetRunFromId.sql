CREATE PROCEDURE [dbo].[spGetRunFromId] (
	@Id int
)
AS
BEGIN
SET NOCOUNT ON
SELECT runs.run_id, runs.game_id, games.game_name, run_creator_id, players.username as run_creator_name, run_name, run_password, run_description, max_players, runs.created_date, last_updated, run_complete, run_player_id, rp.player_id, rp.run_id
FROM runs
JOIN games ON runs.game_id = games.game_id
JOIN players ON runs.run_creator_id = players.player_id
JOIN run_players as rp ON players.player_id = rp.player_id
WHERE runs.run_id = @Id
END
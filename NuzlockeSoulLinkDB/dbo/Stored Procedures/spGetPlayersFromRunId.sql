CREATE PROCEDURE [dbo].[spGetPlayersFromRunId] (
	@RunId uniqueidentifier
)
AS
BEGIN
SET NOCOUNT ON
SELECT run_player_id, run_players.player_id, players.username as player_name, players.last_win_time, run_id
FROM run_players
JOIN players ON run_players.player_id = players.player_id
WHERE run_id = @RunId
END
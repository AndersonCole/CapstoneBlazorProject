CREATE PROCEDURE spGetPlayersFromRunId (
	@Id int
)
AS
BEGIN
SET NOCOUNT ON
SELECT run_player_id, run_players.player_id, players.username as player_name, run_id
FROM run_players
JOIN players ON run_players.player_id = players.player_id
WHERE run_id = @Id
END
CREATE PROCEDURE [dbo].[spUpdateWins] (
	@RunPlayerId int
)
AS
BEGIN
SET NOCOUNT ON
UPDATE players
SET completed_runs = completed_runs + 1, last_win_time = SYSDATETIMEOFFSET()
WHERE player_id = (
	SELECT player_id
	FROM run_players
	WHERE run_player_id = @RunPlayerId
)
END
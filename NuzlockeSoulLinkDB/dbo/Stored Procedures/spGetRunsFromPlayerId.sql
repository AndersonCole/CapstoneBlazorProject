CREATE PROCEDURE spGetRunsFromPlayerId (
	@PlayerId int
)
AS
BEGIN
SET NOCOUNT ON
SELECT *
FROM runs
JOIN run_players ON runs.run_id = run_players.run_id
WHERE player_id = @PlayerId
END

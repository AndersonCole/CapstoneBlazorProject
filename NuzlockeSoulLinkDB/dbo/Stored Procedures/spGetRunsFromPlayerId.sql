CREATE PROCEDURE [dbo].[spGetRunsFromPlayerId] (
	@PlayerId int
)
AS
BEGIN
SET NOCOUNT ON
SELECT *
FROM runs
JOIN run_players ON runs.run_id = run_players.run_id
WHERE player_id = @PlayerId
AND runs.run_complete = 0
END
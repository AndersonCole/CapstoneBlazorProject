CREATE PROCEDURE [dbo].[spGetLeaderboardUsers]
AS
BEGIN
SET NOCOUNT ON
SELECT username, completed_runs
FROM players
WHERE completed_runs > 0
ORDER BY completed_runs DESC;
END
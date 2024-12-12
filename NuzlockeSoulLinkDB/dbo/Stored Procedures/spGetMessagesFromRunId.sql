CREATE PROCEDURE [dbo].[spGetMessagesFromRunId] (
	@RunId uniqueidentifier
)
AS
BEGIN
SET NOCOUNT ON
SELECT chat_id, rc.run_player_id, players.username as PlayerName, run_id, chat_message, time_sent
FROM run_chat as rc
JOIN run_players as rp ON rp.run_player_id = rc.run_player_id
JOIN players ON rp.player_id = players.player_id
WHERE run_id = @RunId
ORDER BY time_sent ASC;
END
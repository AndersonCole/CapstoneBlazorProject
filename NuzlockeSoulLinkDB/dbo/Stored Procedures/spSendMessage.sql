CREATE PROCEDURE [dbo].[spSendMessage] (
	@RunPlayerId int,
	@ChatMessage nvarchar(255),
	@TimeSent datetimeoffset
)
AS
BEGIN
SET NOCOUNT ON
UPDATE runs
SET last_updated = SYSDATETIMEOFFSET()
WHERE run_id = (
	SELECT run_id
	FROM run_players
	WHERE run_player_id = @RunPlayerId
)

INSERT INTO run_chat(run_player_id, chat_message, time_sent)
VALUES (@RunPlayerId, @ChatMessage, @TimeSent)
END
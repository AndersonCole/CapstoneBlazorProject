CREATE PROCEDURE [dbo].[spDeleteGame] (
	@GameId int
)
AS
BEGIN
SET NOCOUNT ON
DELETE rb
FROM run_battles as rb
JOIN battles as b ON rb.battle_id = b.battle_id
WHERE b.game_id = @GameId

DELETE b
FROM battles as b
WHERE b.game_id = @GameId

DELETE re
FROM run_encounters as re
JOIN routes as r ON re.route_id = r.route_id
WHERE r.game_id = @GameId

DELETE r
FROM routes as r
WHERE r.game_id = @GameId

DELETE rc
FROM run_chat as rc
JOIN run_players as rp ON rc.run_player_id = rp.run_player_id
JOIN runs as r ON rp.run_id = r.run_id
WHERE r.game_id = @GameId

DELETE rp
FROM run_players as rp
JOIN runs as r ON rp.run_id = r.run_id
WHERE r.game_id = @GameId

DELETE r
FROM runs as r
WHERE r.game_id = @GameId

DELETE g
FROM games as g
WHERE game_id = @GameId
END
CREATE PROCEDURE spDeleteGen (
	@GenId int
)
AS
BEGIN
SET NOCOUNT ON
DELETE rb
FROM run_battles as rb
JOIN battles as b ON rb.battle_id = b.battle_id
JOIN games as g ON b.game_id = g.game_id
WHERE g.gen_id = @GenId

DELETE b
FROM battles as b
JOIN games as g ON b.game_id = g.game_id
WHERE g.gen_id = @GenId

DELETE re
FROM run_encounters as re
JOIN routes as r ON re.route_id = r.route_id
JOIN games as g ON r.game_id = g.game_id
WHERE g.gen_id = @GenId

DELETE r
FROM routes as r
JOIN games as g ON r.game_id = g.game_id
WHERE g.gen_id = @GenId

DELETE rc
FROM run_chat as rc
JOIN run_players as rp ON rc.run_player_id = rp.run_player_id
JOIN runs as r ON rp.run_id = r.run_id
JOIN games as g ON r.game_id = g.game_id
WHERE g.gen_id = @GenId

DELETE rp
FROM run_players as rp
JOIN runs as r ON rp.run_id = r.run_id
JOIN games as g ON r.game_id = g.game_id
WHERE g.gen_id = @GenId

DELETE r
FROM runs as r
JOIN games as g ON r.game_id = g.game_id
WHERE g.gen_id = @GenId

DELETE g
FROM games as g
WHERE gen_id = @GenId

DELETE generations
FROM generations
WHERE gen_id = @GenId
END


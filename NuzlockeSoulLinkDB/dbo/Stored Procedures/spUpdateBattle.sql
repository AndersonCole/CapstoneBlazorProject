CREATE PROCEDURE [dbo].[spUpdateBattle](
	@RunBattleId int,
	@IsComplete bit
)
AS
BEGIN
SET NOCOUNT ON
UPDATE runs
SET last_updated = SYSDATETIMEOFFSET()
WHERE run_id = (
	SELECT run_id
	FROM run_players as rp
	JOIN run_battles as rb ON rb.run_player_id = rp.run_player_id
	WHERE run_battle_id = @RunBattleId
)

UPDATE run_battles
SET battle_completed = @IsComplete
WHERE run_battle_id = @RunBattleId
END
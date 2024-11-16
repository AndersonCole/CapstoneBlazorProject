CREATE PROCEDURE spUpdateBattle(
	@RunBattleId int,
	@IsComplete bit
)
AS
BEGIN
SET NOCOUNT ON
UPDATE run_battles
SET battle_completed = @IsComplete
WHERE run_battle_id = @RunBattleId
END
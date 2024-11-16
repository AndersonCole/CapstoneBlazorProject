CREATE PROCEDURE [dbo].[spDeleteBattle] (
	@BattleId int
)
AS
BEGIN
SET NOCOUNT ON
DELETE rb
FROM run_battles as rb
WHERE rb.battle_id = @BattleId

DELETE b
FROM battles as b
WHERE b.battle_id = @BattleId
END
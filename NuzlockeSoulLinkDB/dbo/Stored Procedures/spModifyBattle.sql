CREATE PROCEDURE spModifyBattle (
	@BattleId int,
	@Name nvarchar(50),
	@Location nvarchar(50),
	@PokemonUsed nvarchar(50),
	@HighestLevel int,
	@ImageLink nvarchar(max),
	@Order int
)
AS
BEGIN
SET NOCOUNT ON
UPDATE battles
SET battle_name = @Name, battle_location = @Location, pokemon_used = @PokemonUsed, highest_level = @HighestLevel, image_link = @ImageLink, progression_order = @Order
WHERE battle_id = @BattleId
END
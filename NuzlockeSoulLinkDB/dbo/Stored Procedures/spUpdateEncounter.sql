CREATE PROCEDURE spUpdateEncounter(
	@RunEncounterId int,
	@DexNum int,
	@IsAlive bit
)
AS
BEGIN
SET NOCOUNT ON
UPDATE run_encounters
SET dex_number = @DexNum, is_alive = @IsAlive
WHERE encounter_id = @RunEncounterId;
END
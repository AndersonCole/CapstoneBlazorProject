CREATE PROCEDURE [dbo].[spUpdateEncounter](
	@RunEncounterId int,
	@DexNum int,
	@IsAlive int
)
AS
BEGIN
SET NOCOUNT ON
UPDATE runs
SET last_updated = SYSDATETIMEOFFSET()
WHERE run_id = (
	SELECT run_id
	FROM run_players as rp
	JOIN run_encounters as re ON re.run_player_id = rp.run_player_id
	WHERE encounter_id = @RunEncounterId
)

UPDATE run_encounters
SET dex_number = @DexNum, is_alive = @IsAlive
WHERE encounter_id = @RunEncounterId;
END
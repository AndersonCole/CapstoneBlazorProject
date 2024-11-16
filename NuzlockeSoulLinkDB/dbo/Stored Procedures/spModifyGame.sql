CREATE PROCEDURE spModifyGame (
	@GameId int,
	@Name nvarchar(50),
	@Abbreviation nvarchar(2),
	@Region nvarchar(15)
)
AS
BEGIN
SET NOCOUNT ON
UPDATE games
SET game_name = @Name, abbreviation = @Abbreviation, region = @Region
WHERE game_id = @GameId
END

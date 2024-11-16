CREATE PROCEDURE spCreateNewGame (
	@GenId int,
	@Name nvarchar(50),
	@Abbreviation nvarchar(2),
	@Region nvarchar(15)
)
AS
BEGIN
SET NOCOUNT ON
INSERT INTO games (gen_id, game_name, abbreviation, region)
VALUES (@GenId, @Name, @Abbreviation, @Region)
END

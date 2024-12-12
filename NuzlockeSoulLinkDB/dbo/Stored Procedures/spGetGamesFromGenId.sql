CREATE PROCEDURE [dbo].[spGetGamesFromGenId] (
	@GenId int
)
AS
BEGIN
SET NOCOUNT ON
SELECT *
FROM games
WHERE gen_id = @GenId
END
CREATE PROCEDURE [dbo].[spGetPlayerFromUsername] (
		@Username nvarchar(25)
)
AS
BEGIN
SET NOCOUNT ON
SELECT *
FROM players
WHERE username = @Username
END
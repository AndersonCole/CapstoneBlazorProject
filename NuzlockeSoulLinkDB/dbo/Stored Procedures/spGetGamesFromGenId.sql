﻿CREATE PROCEDURE spGetGamesFromGenId (
	@Id int
)
AS
BEGIN
SET NOCOUNT ON
SELECT *
FROM games
WHERE gen_id = @Id
END

CREATE PROCEDURE spGetRunFromName (
	@Name nvarchar(50)
)
AS
BEGIN
SET NOCOUNT ON
SELECT *
FROM runs
WHERE run_name = @Name
END
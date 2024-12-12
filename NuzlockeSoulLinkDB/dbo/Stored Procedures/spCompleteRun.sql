CREATE PROCEDURE [dbo].[spCompleteRun] (
	@RunId uniqueidentifier
)
AS
BEGIN
SET NOCOUNT ON
UPDATE runs
SET run_complete = 1
WHERE run_id = @RunId
END
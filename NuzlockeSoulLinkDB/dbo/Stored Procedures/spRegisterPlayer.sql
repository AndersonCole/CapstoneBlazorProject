CREATE PROCEDURE spRegisterPlayer (
		@Username nvarchar(50),
		@Password nvarchar(255),
		@CreatedDate datetimeoffset
)
AS
BEGIN
SET NOCOUNT ON
INSERT INTO players (username, password, created_date, completed_runs, is_admin)
VALUES (@Username, @Password, @CreatedDate, 0, 0)
END
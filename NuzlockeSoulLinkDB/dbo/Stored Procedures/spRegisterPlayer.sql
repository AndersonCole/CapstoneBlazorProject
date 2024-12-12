CREATE PROCEDURE [dbo].[spRegisterPlayer] (
		@Username nvarchar(50),
		@Password nvarchar(255),
		@CreatedDate datetimeoffset
)
AS
BEGIN
SET NOCOUNT ON
INSERT INTO players (username, password, created_date, completed_runs, last_win_time, is_admin)
VALUES (@Username, @Password, @CreatedDate, 0, @CreatedDate, 0)
END
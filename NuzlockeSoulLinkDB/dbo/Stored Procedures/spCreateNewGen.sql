CREATE PROCEDURE spCreateNewGen (
	@RomanNumeral nvarchar(5)
)
AS
BEGIN
SET NOCOUNT ON
INSERT INTO generations (roman_numeral)
VALUES (@RomanNumeral)
END


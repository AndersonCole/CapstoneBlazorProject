CREATE PROCEDURE spModifyGen (
	@GenId int,
	@RomanNumeral nvarchar(5)
)
AS
BEGIN
SET NOCOUNT ON
UPDATE generations
SET roman_numeral = @RomanNumeral
WHERE gen_id = @GenId
END


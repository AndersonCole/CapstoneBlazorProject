CREATE TABLE [dbo].[generations] (
    [gen_id]        INT          IDENTITY (1, 1) NOT NULL,
    [roman_numeral] NVARCHAR (5) NULL,
    PRIMARY KEY CLUSTERED ([gen_id] ASC)
);


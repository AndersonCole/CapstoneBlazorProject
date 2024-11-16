CREATE TABLE [dbo].[games] (
    [game_id]      INT           IDENTITY (1, 1) NOT NULL,
    [game_name]    NVARCHAR (50) NULL,
    [abbreviation] NVARCHAR (2)  NULL,
    [region]       NVARCHAR (15) NULL,
    [gen_id]       INT           NULL,
    PRIMARY KEY CLUSTERED ([game_id] ASC),
    CONSTRAINT [FK_Games_Gen] FOREIGN KEY ([gen_id]) REFERENCES [dbo].[generations] ([gen_id])
);


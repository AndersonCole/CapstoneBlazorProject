CREATE TABLE [dbo].[routes] (
    [route_id]          INT           IDENTITY (1, 1) NOT NULL,
    [route_name]        NVARCHAR (50) NULL,
    [game_id]           INT           NULL,
    [progression_order] INT           NULL,
    PRIMARY KEY CLUSTERED ([route_id] ASC),
    CONSTRAINT [FK_Routes_Game] FOREIGN KEY ([game_id]) REFERENCES [dbo].[games] ([game_id])
);


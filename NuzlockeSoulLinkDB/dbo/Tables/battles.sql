CREATE TABLE [dbo].[battles] (
    [battle_id]         INT            IDENTITY (1, 1) NOT NULL,
    [battle_name]       NVARCHAR (50)  NULL,
    [battle_location]   NVARCHAR (50)  NULL,
    [progression_order] INT            NULL,
    [pokemon_used]      NVARCHAR (50)  NULL,
    [image_link]        NVARCHAR (MAX) NULL,
    [game_id]           INT            NULL,
    [highest_level]     INT            NULL,
    PRIMARY KEY CLUSTERED ([battle_id] ASC),
    CONSTRAINT [FK_Battles_Game] FOREIGN KEY ([game_id]) REFERENCES [dbo].[games] ([game_id])
);


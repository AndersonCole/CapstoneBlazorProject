CREATE TABLE [dbo].[runs] (
    [run_name]        NVARCHAR (50)      NULL,
    [run_password]    NVARCHAR (255)     NULL,
    [run_creator_id]  INT                NULL,
    [created_date]    DATETIMEOFFSET (7) NULL,
    [run_complete]    BIT                NULL,
    [last_updated]    DATETIMEOFFSET (7) NULL,
    [run_description] NVARCHAR (255)     NULL,
    [game_id]         INT                NULL,
    [max_players]     INT                NULL,
    [run_id]          UNIQUEIDENTIFIER   DEFAULT (newid()) NOT NULL,
    CONSTRAINT [PK_runs] PRIMARY KEY CLUSTERED ([run_id] ASC),
    CONSTRAINT [FK_Player_Id] FOREIGN KEY ([run_creator_id]) REFERENCES [dbo].[players] ([player_id]),
    CONSTRAINT [FK_Runs_Game] FOREIGN KEY ([game_id]) REFERENCES [dbo].[games] ([game_id])
);


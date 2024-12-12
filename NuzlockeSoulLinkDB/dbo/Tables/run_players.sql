CREATE TABLE [dbo].[run_players] (
    [run_player_id] INT              IDENTITY (1, 1) NOT NULL,
    [player_id]     INT              NULL,
    [run_id]        UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([run_player_id] ASC),
    CONSTRAINT [FK_RunPlayers_PlayerId] FOREIGN KEY ([player_id]) REFERENCES [dbo].[players] ([player_id]),
    CONSTRAINT [FK_RunPlayers_RunId] FOREIGN KEY ([run_id]) REFERENCES [dbo].[runs] ([run_id])
);


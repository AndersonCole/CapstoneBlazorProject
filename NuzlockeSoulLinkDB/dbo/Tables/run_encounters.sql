CREATE TABLE [dbo].[run_encounters] (
    [encounter_id]  INT IDENTITY (1, 1) NOT NULL,
    [run_player_id] INT NULL,
    [route_id]      INT NULL,
    [dex_number]    INT NULL,
    [is_alive]      BIT NULL,
    PRIMARY KEY CLUSTERED ([encounter_id] ASC),
    CONSTRAINT [FK_RunEncounters_DexNumber] FOREIGN KEY ([dex_number]) REFERENCES [dbo].[pokemon] ([dex_number]),
    CONSTRAINT [FK_RunEncounters_Route] FOREIGN KEY ([route_id]) REFERENCES [dbo].[routes] ([route_id]),
    CONSTRAINT [FK_RunEncounters_RunPlayer] FOREIGN KEY ([run_player_id]) REFERENCES [dbo].[run_players] ([run_player_id])
);


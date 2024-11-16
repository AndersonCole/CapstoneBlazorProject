CREATE TABLE [dbo].[run_battles] (
    [run_battle_id]    INT           IDENTITY (1, 1) NOT NULL,
    [run_player_id]    INT           NULL,
    [battle_id]        INT           NULL,
    [pokemon_used]     NVARCHAR (50) NULL,
    [battle_completed] BIT           NULL,
    PRIMARY KEY CLUSTERED ([run_battle_id] ASC),
    CONSTRAINT [FK_RunBattles_Battles] FOREIGN KEY ([battle_id]) REFERENCES [dbo].[battles] ([battle_id]),
    CONSTRAINT [FK_RunBattles_RunPlayers] FOREIGN KEY ([run_player_id]) REFERENCES [dbo].[run_players] ([run_player_id])
);


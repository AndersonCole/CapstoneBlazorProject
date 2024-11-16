CREATE TABLE [dbo].[run_chat] (
    [chat_id]       INT                IDENTITY (1, 1) NOT NULL,
    [chat_message]  NVARCHAR (255)     NULL,
    [time_sent]     DATETIMEOFFSET (7) NULL,
    [run_player_id] INT                NULL,
    PRIMARY KEY CLUSTERED ([chat_id] ASC),
    CONSTRAINT [FK_Chat_RunPlayerId] FOREIGN KEY ([run_player_id]) REFERENCES [dbo].[run_players] ([run_player_id])
);


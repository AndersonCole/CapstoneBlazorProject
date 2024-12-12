CREATE TABLE [dbo].[players] (
    [player_id]      INT                IDENTITY (1, 1) NOT NULL,
    [username]       NVARCHAR (50)      NULL,
    [password]       NVARCHAR (MAX)     NULL,
    [created_date]   DATETIMEOFFSET (7) NULL,
    [completed_runs] INT                NULL,
    [is_admin]       BIT                NULL,
    [last_win_time]  DATETIMEOFFSET (7) NULL,
    PRIMARY KEY CLUSTERED ([player_id] ASC)
);


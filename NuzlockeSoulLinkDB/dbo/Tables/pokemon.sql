CREATE TABLE [dbo].[pokemon] (
    [dex_number]     INT           NOT NULL,
    [pokemon_name]   NVARCHAR (50) NULL,
    [primary_type]   NVARCHAR (10) NULL,
    [secondary_type] NVARCHAR (10) NULL,
    [evolves_from]   INT           NULL,
    [evolves_into]   NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([dex_number] ASC)
);


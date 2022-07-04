IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Humidity] (
    [TimeStamp] datetime2 NOT NULL,
    [Measure] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Humidity] PRIMARY KEY ([TimeStamp])
);
GO

CREATE TABLE [Rainfall] (
    [TimeStamp] datetime2 NOT NULL,
    [Measure] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Rainfall] PRIMARY KEY ([TimeStamp])
);
GO

CREATE TABLE [Temperatures] (
    [TimeStamp] datetime2 NOT NULL,
    [Measure] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Temperatures] PRIMARY KEY ([TimeStamp])
);
GO

CREATE UNIQUE INDEX [IX_Humidity_TimeStamp] ON [Humidity] ([TimeStamp]);
GO

CREATE UNIQUE INDEX [IX_Rainfall_TimeStamp] ON [Rainfall] ([TimeStamp]);
GO

CREATE UNIQUE INDEX [IX_Temperatures_TimeStamp] ON [Temperatures] ([TimeStamp]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220704033854_InitialCreate', N'6.0.0');
GO

CREATE VIEW [vw_weather]
AS
    SELECT DISTINCT t.TimeStamp, t.Measure as temperature, h.Measure as humidity, r.Measure as rainfall
    FROM temperatures AS t
    INNER JOIN humidity AS h ON t.TimeStamp = h.TimeStamp
    INNER JOIN rainfall AS r ON t.TimeStamp = r.TimeStamp;
GO

COMMIT;
GO
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [Guid] uniqueidentifier NOT NULL DEFAULT (NEWID()),
    [Version] int NULL DEFAULT 1,
    [Created] datetime2 NOT NULL DEFAULT (GETDATE()),
    [LastModified] datetime2 NULL,
    [IsDeleted] bit NOT NULL DEFAULT CAST(0 AS bit),
    [FirstName] nvarchar(255) NULL,
    [LastName] nvarchar(255) NULL,
    [NickName] nvarchar(25) NULL,
    [MiddleName] nvarchar(255) NULL,
    [Email] nvarchar(255) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201002121612_Initial', N'3.1.8');

GO


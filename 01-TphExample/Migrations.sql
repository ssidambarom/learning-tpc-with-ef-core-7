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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211141820_InitialCreate')
BEGIN
    CREATE SEQUENCE [EmployeeIdSequence] AS int START WITH 1 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211141820_InitialCreate')
BEGIN
    CREATE TABLE [Persons] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [SurName] nvarchar(max) NOT NULL,
        [Discriminator] nvarchar(max) NOT NULL,
        [CompanyName] nvarchar(max) NULL,
        [EmployeeId] int NULL DEFAULT (NEXT VALUE FOR EmployeeIdSequence),
        [Expertise] nvarchar(max) NULL,
        CONSTRAINT [PK_Persons] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211141820_InitialCreate')
BEGIN
    CREATE TABLE [CustomersBusinessManagers] (
        [ContactsId] int NOT NULL,
        [PortfolioId] int NOT NULL,
        CONSTRAINT [PK_CustomersBusinessManagers] PRIMARY KEY ([ContactsId], [PortfolioId]),
        CONSTRAINT [FK_CustomersBusinessManagers_Persons_ContactsId] FOREIGN KEY ([ContactsId]) REFERENCES [Persons] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_CustomersBusinessManagers_Persons_PortfolioId] FOREIGN KEY ([PortfolioId]) REFERENCES [Persons] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211141820_InitialCreate')
BEGIN
    CREATE INDEX [IX_CustomersBusinessManagers_PortfolioId] ON [CustomersBusinessManagers] ([PortfolioId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211141820_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221211141820_InitialCreate', N'7.0.0');
END;
GO

COMMIT;
GO


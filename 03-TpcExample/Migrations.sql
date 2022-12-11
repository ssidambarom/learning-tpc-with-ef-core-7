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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211205842_InitialCreate')
BEGIN
    CREATE SEQUENCE [EmployeeIdSequence] AS int START WITH 1 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211205842_InitialCreate')
BEGIN
    CREATE SEQUENCE [PersonSequence] START WITH 1 INCREMENT BY 1 NO MINVALUE NO MAXVALUE NO CYCLE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211205842_InitialCreate')
BEGIN
    CREATE TABLE [Customers] (
        [Id] int NOT NULL DEFAULT (NEXT VALUE FOR [PersonSequence]),
        [Name] nvarchar(max) NOT NULL,
        [SurName] nvarchar(max) NOT NULL,
        [CompanyName] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Customers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211205842_InitialCreate')
BEGIN
    CREATE TABLE [Managers] (
        [Id] int NOT NULL DEFAULT (NEXT VALUE FOR [PersonSequence]),
        [Name] nvarchar(max) NOT NULL,
        [SurName] nvarchar(max) NOT NULL,
        [EmployeeId] int NOT NULL DEFAULT (NEXT VALUE FOR EmployeeIdSequence),
        CONSTRAINT [PK_Managers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211205842_InitialCreate')
BEGIN
    CREATE TABLE [Technicians] (
        [Id] int NOT NULL DEFAULT (NEXT VALUE FOR [PersonSequence]),
        [Name] nvarchar(max) NOT NULL,
        [SurName] nvarchar(max) NOT NULL,
        [EmployeeId] int NOT NULL DEFAULT (NEXT VALUE FOR EmployeeIdSequence),
        [Expertise] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Technicians] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211205842_InitialCreate')
BEGIN
    CREATE TABLE [CustomersBusinessManagers] (
        [ContactsId] int NOT NULL,
        [PortfolioId] int NOT NULL,
        CONSTRAINT [PK_CustomersBusinessManagers] PRIMARY KEY ([ContactsId], [PortfolioId]),
        CONSTRAINT [FK_CustomersBusinessManagers_Customers_PortfolioId] FOREIGN KEY ([PortfolioId]) REFERENCES [Customers] ([Id]),
        CONSTRAINT [FK_CustomersBusinessManagers_Managers_ContactsId] FOREIGN KEY ([ContactsId]) REFERENCES [Managers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211205842_InitialCreate')
BEGIN
    CREATE INDEX [IX_CustomersBusinessManagers_PortfolioId] ON [CustomersBusinessManagers] ([PortfolioId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221211205842_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221211205842_InitialCreate', N'7.0.0');
END;
GO

COMMIT;
GO


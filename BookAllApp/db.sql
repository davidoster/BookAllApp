IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

ALTER TABLE [AspNetUsers] ADD [DOB] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [AspNetUsers] ADD [Name] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220527123002_UpdateIdentityUser', N'3.1.25');

GO

CREATE TABLE [Customers] (
    [CustomerID] nvarchar(450) NOT NULL,
    [FullName] nvarchar(max) NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY ([CustomerID])
);

GO

CREATE TABLE [Orders] (
    [OrderID] nvarchar(450) NOT NULL,
    [BookID] nvarchar(max) NULL,
    [CustomerID] nvarchar(450) NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([OrderID]),
    CONSTRAINT [FK_Orders_Customers_CustomerID] FOREIGN KEY ([CustomerID]) REFERENCES [Customers] ([CustomerID]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Orders_CustomerID] ON [Orders] ([CustomerID]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220528072056_ExtraEntities', N'3.1.25');

GO


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
IF SCHEMA_ID(N'Core') IS NULL EXEC(N'CREATE SCHEMA [Core];');

CREATE TABLE [Core].[Brands] (
    [Id] bigint NOT NULL IDENTITY,
    [Name] nvarchar(255) NOT NULL,
    [Website] nvarchar(1024) NULL,
    [Timestamp] rowversion NULL,
    CONSTRAINT [PK_Brands] PRIMARY KEY ([Id])
);

CREATE TABLE [Core].[PriceHistory] (
    [Id] bigint NOT NULL,
    [ProductId] bigint NULL,
    [BasePrice] float NOT NULL,
    [ShopName] nvarchar(255) NOT NULL,
    [PriceDate] datetime2 NOT NULL,
    [Timestamp] rowversion NULL,
    CONSTRAINT [PK_PriceHistory] PRIMARY KEY ([Id])
);

CREATE TABLE [Core].[ProductGroups] (
    [Id] bigint NOT NULL IDENTITY,
    [Name] nvarchar(255) NOT NULL,
    [Image] nvarchar(1024) NULL,
    [Timestamp] rowversion NULL,
    CONSTRAINT [PK_ProductGroups] PRIMARY KEY ([Id])
);

CREATE TABLE [Core].[Reviewers] (
    [Id] bigint NOT NULL IDENTITY,
    [Name] nvarchar(255) NOT NULL,
    [Email] nvarchar(255) NOT NULL,
    [UserName] nvarchar(255) NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [PasswordSalt] nvarchar(max) NULL,
    [Timestamp] rowversion NULL,
    CONSTRAINT [PK_Reviewers] PRIMARY KEY ([Id])
);

CREATE TABLE [Core].[Products] (
    [Id] bigint NOT NULL IDENTITY,
    [Name] nvarchar(255) NOT NULL,
    [BrandId] bigint NOT NULL,
    [ProductGroupId] bigint NOT NULL,
    [Image] nvarchar(1024) NULL,
    [Timestamp] rowversion NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Products_Brands_BrandId] FOREIGN KEY ([BrandId]) REFERENCES [Core].[Brands] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Products_ProductGroups_ProductGroupId] FOREIGN KEY ([ProductGroupId]) REFERENCES [Core].[ProductGroups] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [Core].[SpecificationDefinitions] (
    [Id] bigint NOT NULL IDENTITY,
    [Key] nvarchar(255) NOT NULL,
    [Name] nvarchar(255) NOT NULL,
    [Unit] nvarchar(127) NULL,
    [Type] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [ProductGroupId] bigint NOT NULL,
    [Timestamp] rowversion NULL,
    CONSTRAINT [PK_SpecificationDefinitions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_SpecificationDefinitions_ProductGroups_ProductGroupId] FOREIGN KEY ([ProductGroupId]) REFERENCES [Core].[ProductGroups] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [Core].[Prices] (
    [Id] bigint NOT NULL IDENTITY,
    [ProductId] bigint NOT NULL,
    [BasePrice] float NOT NULL,
    [ShopName] nvarchar(255) NOT NULL,
    [PriceDate] datetime2 NOT NULL,
    [Timestamp] rowversion NULL,
    CONSTRAINT [PK_Prices] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Prices_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Core].[Products] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [Core].[Reviews] (
    [Id] bigint NOT NULL IDENTITY,
    [Text] nvarchar(max) NULL,
    [Score] tinyint NOT NULL,
    [ReviewType] int NOT NULL,
    [ProductId] bigint NOT NULL,
    [ReviewerId] bigint NULL,
    [DateBought] datetime2 NULL,
    [Organization] nvarchar(512) NULL,
    [ReviewUrl] nvarchar(1024) NULL,
    [Timestamp] rowversion NULL,
    CONSTRAINT [PK_Reviews] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Reviews_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Core].[Products] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Reviews_Reviewers_ReviewerId] FOREIGN KEY ([ReviewerId]) REFERENCES [Core].[Reviewers] ([Id])
);

CREATE TABLE [Core].[Specifications] (
    [Id] bigint NOT NULL IDENTITY,
    [Key] nvarchar(255) NOT NULL,
    [BoolValue] bit NULL,
    [StringValue] nvarchar(max) NULL,
    [NumberValue] float NULL,
    [ProductId] bigint NOT NULL,
    [Timestamp] rowversion NULL,
    CONSTRAINT [PK_Specifications] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Specifications_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Core].[Products] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_Prices_ProductId] ON [Core].[Prices] ([ProductId]);

CREATE INDEX [IX_Products_BrandId] ON [Core].[Products] ([BrandId]);

CREATE INDEX [IX_Products_ProductGroupId] ON [Core].[Products] ([ProductGroupId]);

CREATE INDEX [IX_Reviews_ProductId] ON [Core].[Reviews] ([ProductId]);

CREATE INDEX [IX_Reviews_ReviewerId] ON [Core].[Reviews] ([ReviewerId]);

CREATE INDEX [IX_SpecificationDefinitions_ProductGroupId] ON [Core].[SpecificationDefinitions] ([ProductGroupId]);

CREATE INDEX [IX_Specifications_ProductId] ON [Core].[Specifications] ([ProductId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250310124136_Version1', N'9.0.2');

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250310124402_Version2', N'9.0.2');

COMMIT;
GO


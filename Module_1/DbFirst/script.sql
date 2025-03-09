BEGIN TRANSACTION;
GO

ALTER TABLE [Core].[Brands] ADD [SupportEmail] nvarchar(max) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240828105749_v2', N'8.0.8');
GO

COMMIT;
GO


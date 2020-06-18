CREATE TABLE [dbo].[LocalizationKeys]
(
	[Id] INT NOT NULL,
	[KeyName] NVARCHAR(1024) NOT NULL,
	CONSTRAINT [PK_LocalizationKeys] PRIMARY KEY CLUSTERED ([Id] ASC)
)

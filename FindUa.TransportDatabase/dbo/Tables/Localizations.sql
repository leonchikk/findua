CREATE TABLE [dbo].[Localizations]
(
	[Id] INT NOT NULL,
	[LocalizationKeyId] INT	NOT NULL,
	[Language] NVARCHAR(10) NOT NULL,
	[Text] NVARCHAR(2048) NOT NULL,
	CONSTRAINT [PK_Localizations] PRIMARY KEY CLUSTERED ([Id] ASC)
)

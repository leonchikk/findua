CREATE TABLE [dbo].[TransportConditionInSaleAnnounces]
(
	[Id]					INT	NOT NULL,
	[SaleAnnounceId]		INT	NOT NULL,
	[TransportConditionId]	INT	NOT NULL,
	CONSTRAINT [PK_TransportConditionInSaleAnnounces] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_TransportConditionInSaleAnnounces_SaleAnnounceId] FOREIGN KEY ([SaleAnnounceId]) REFERENCES [dbo].[TransportSaleAnnounces] ([Id]),
	CONSTRAINT [FK_TransportConditionInSaleAnnounces_TransportConditionId] FOREIGN KEY ([TransportConditionId]) REFERENCES [dbo].[TransportConditions] ([Id])
)

CREATE TABLE [dbo].[CarHires] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [CarId]     INT           NOT NULL,
    [ClientId]  INT           NOT NULL,
    [BeginDate] DATETIME      NOT NULL,
    [EndDate]   DATETIME      NOT NULL,
    [CarState]  NVARCHAR (45) NOT NULL,
    [Discount]  AS            ([dbo].[FuncDiscount]([ClientId])),
    [Penalty]   AS            ([dbo].[FuncPenalty]([CarState])),
    [Price]     AS            ([dbo].[FuncPrice]([ClientId],[CarId],[CarState],[BeginDate],[EndDate])),
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([BeginDate]<=[EndDate]),
    CHECK ([BeginDate]<=getdate()),
    CHECK ([EndDate]<=getdate()),
    FOREIGN KEY ([CarId]) REFERENCES [dbo].[Cars] ([Id]) ON DELETE CASCADE,
    FOREIGN KEY ([CarState]) REFERENCES [dbo].[CarStates] ([State]) ON DELETE CASCADE,
    FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Clients] ([Id]) ON DELETE CASCADE
);


CREATE TABLE [dbo].[Cars] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [Brand]        NVARCHAR (45)   NOT NULL,
    [Price]        DECIMAL (19, 4) NOT NULL,
    [PricePerHour] DECIMAL (19, 4) NOT NULL,
    [Type]         NVARCHAR (45)   NULL,
    [Year]         INT             NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([Year]>=(1900) AND [Year]<=datepart(year,getdate())),
    FOREIGN KEY ([Type]) REFERENCES [dbo].[CarTypes] ([Type]) ON DELETE SET NULL
);


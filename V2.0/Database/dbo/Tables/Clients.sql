CREATE TABLE [dbo].[Clients] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [LastName]     NVARCHAR (45) NOT NULL,
    [FirstName]    NVARCHAR (45) NOT NULL,
    [SecondName]   NVARCHAR (45) NOT NULL,
    [Adress]       NVARCHAR (45) NULL,
    [PhoneNumber]  NVARCHAR (45) NULL,
    [TypeOfClient] NVARCHAR (45) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([PhoneNumber] like '+38([0-9][0-9][0-9])[0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
    FOREIGN KEY ([TypeOfClient]) REFERENCES [dbo].[ClientTypes] ([Type]) ON DELETE SET NULL
);


GO

/*
	Accounts Table
*/
CREATE TABLE [dbo].[Accounts] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Username]    VARCHAR (255) NOT NULL,
    [Password]    BINARY (128)  NOT NULL,
    [DisplayName] NVARCHAR (64) NOT NULL,
    CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UN_Account_Username] UNIQUE NONCLUSTERED ([Username] ASC),
    CONSTRAINT [UN_Account_Password] UNIQUE NONCLUSTERED ([Password] ASC)
);

GO

/*
	Rooms Table
*/
CREATE TABLE [dbo].[Rooms] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (128) NOT NULL,
    [Description] NTEXT          NOT NULL,
    CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UN_Rooms_Name] UNIQUE NONCLUSTERED ([Name] ASC)
);

GO

/*
	Friendlist Table
*/
CREATE TABLE [dbo].[Friendlist] (
    [UserId]   INT NOT NULL,
    [FriendId] INT NOT NULL,
    CONSTRAINT [PK_Friendlist] PRIMARY KEY CLUSTERED ([UserId] ASC, [FriendId] ASC),
    CONSTRAINT [FK_Friendlist_Account_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Accounts] ([Id]),
    CONSTRAINT [FK_Friendlist_Account_FriendId] FOREIGN KEY ([FriendId]) REFERENCES [dbo].[Accounts] ([Id])
);

GO

/*
	Conversations Table
*/
CREATE TABLE [dbo].[Conversations] (
    [Id]          BIGINT   IDENTITY (1, 1) NOT NULL,
    [UserId]      INT      NOT NULL,
    [RoomId]      INT      NOT NULL,
    [ContentType] INT      NOT NULL,
    [Content]     NTEXT    NOT NULL,
    [Since]       DATETIME NOT NULL,
    CONSTRAINT [PK_Conversations] PRIMARY KEY CLUSTERED ([Id] ASC, [UserId] ASC, [RoomId] ASC),
    CONSTRAINT [FK_Conversations_Accounts_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Accounts] ([Id]),
    CONSTRAINT [FK_Conversations_Rooms_RoomId] FOREIGN KEY ([RoomId]) REFERENCES [dbo].[Rooms] ([Id])
);

GO

/*
	Message Table
*/
CREATE TABLE [dbo].[Messages] (
    [Id]          INT      IDENTITY (1, 1) NOT NULL,
    [Sender]      INT      NOT NULL,
    [Receiver]    INT      NOT NULL,
    [ContentType] INT      NOT NULL,
    [Content]     NTEXT    NOT NULL,
    [Since]       DATETIME NOT NULL,
    CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED ([Id] ASC, [Sender] ASC, [Receiver] ASC),
    CONSTRAINT [FK_Messages_Account_Sender] FOREIGN KEY ([Sender]) REFERENCES [dbo].[Accounts] ([Id]),
    CONSTRAINT [FK_Messages_Account_Receiver] FOREIGN KEY ([Receiver]) REFERENCES [dbo].[Accounts] ([Id])
);
BEGIN TRANSACTION

CREATE TABLE [IBGEExplorer].[City] (
    [Id] int NOT NULL IDENTITY,
    [IBGECode] NVARCHAR(20) NOT NULL,
    [CityName] NVARCHAR(50) NOT NULL,
    [StateName] NVARCHAR(50) NOT NULL,
    [UF] NVARCHAR(5) NOT NULL,
    [Active] BIT NOT NULL DEFAULT CAST(1 AS BIT),
    CONSTRAINT [PK_City] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [IBGEExplorer].[Role] (
    [Id] smallint NOT NULL IDENTITY,
    [Name] VARCHAR(50) NOT NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [IBGEExplorer].[User] (
    [Id] int NOT NULL IDENTITY,
    [Email] VARCHAR(100) NOT NULL,
    [Password] VARCHAR(255) NOT NULL,
    [CanLogin] BIT NOT NULL DEFAULT CAST(0 AS BIT),
    [FirstName] NVARCHAR(30) NOT NULL,
    [LastName] NVARCHAR(70) NOT NULL,
    [Hash] NVARCHAR(30) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [IBGEExplorer].[UserRole] (
    [Id] smallint NOT NULL IDENTITY,
    [UserId] INT NOT NULL,
    [RoleId] smallint NOT NULL,
    CONSTRAINT [PK_UserRole] PRIMARY KEY ([Id]),
    CONSTRAINT [Fk_Roles_Users] FOREIGN KEY ([RoleId]) REFERENCES [Role] ([Id]),
    CONSTRAINT [Fk_Users_Roles] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Role]'))
    SET IDENTITY_INSERT [Role] ON;
INSERT INTO [Role] ([Id], [Name])
VALUES (CAST(1 AS smallint), 'Admin'),
(CAST(2 AS smallint), 'User');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Role]'))
    SET IDENTITY_INSERT [Role] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CanLogin', N'Email', N'FirstName', N'Hash', N'LastName', N'Password') AND [object_id] = OBJECT_ID(N'[User]'))
    SET IDENTITY_INSERT [User] ON;
INSERT INTO [User] ([Id], [CanLogin], [Email], [FirstName], [Hash], [LastName], [Password])
VALUES (1, CAST(1 AS BIT), 'joao@gmail.com', N'joao', N'NsGUqgGJ12Kcrr78jpjF', N'Silva', '0ef17aa5b7933261d055abe8cd8dff28f30fd75f1209c38641eb1527e565ea31'),
(2, CAST(1 AS BIT), 'pedro@gmail.com', N'pedro', N'IUi0+VoRkqa5cTAdK4Wu', N'oliveira', '337b092a7119944cc05543d0c4714e23d4d237925db4923c667b96309a9a6f0e');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CanLogin', N'Email', N'FirstName', N'Hash', N'LastName', N'Password') AND [object_id] = OBJECT_ID(N'[User]'))
    SET IDENTITY_INSERT [User] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[UserRole]'))
    SET IDENTITY_INSERT [UserRole] ON;
INSERT INTO [UserRole] ([Id], [RoleId], [UserId])
VALUES (CAST(1 AS smallint), CAST(1 AS smallint), 1),
(CAST(2 AS smallint), CAST(2 AS smallint), 2);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[UserRole]'))
    SET IDENTITY_INSERT [UserRole] OFF;
GO

CREATE UNIQUE INDEX [IX_City_IBGECode] ON [IBGEExplorer].[City] ([IBGECode]);
GO

CREATE UNIQUE INDEX [IX_Role_Name] ON [IBGEExplorer].[Role] ([Name]);
GO

CREATE UNIQUE INDEX [IX_User_Email] ON [IBGEExplorer].[User] ([Email]);
GO

CREATE INDEX [IX_UserRole_RoleId] ON [IBGEExplorer].[UserRole] ([RoleId]);
GO

CREATE INDEX [IX_UserRole_UserId] ON [IBGEExplorer].[UserRole] ([UserId]);
GO

ROLLBACK
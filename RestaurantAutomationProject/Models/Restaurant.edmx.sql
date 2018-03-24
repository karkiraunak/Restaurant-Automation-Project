
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/18/2018 22:26:02
-- Generated from EDMX file: C:\RestaurantAutomationProject\RestaurantAutomationProject\RestaurantAutomationProject\Models\Restaurant.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [RestaurantAutomation];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__User__UserLogin]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK__User__UserLogin];
GO
IF OBJECT_ID(N'[dbo].[FK__UserLogin_Roles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserLogin] DROP CONSTRAINT [FK__UserLogin_Roles];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Company]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Company];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[UserLogin]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserLogin];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Items'
CREATE TABLE [dbo].[Items] (
    [ItemNo] int  NOT NULL,
    [ItemName] varchar(20)  NULL,
    [ItemPrice] int  NOT NULL,
    [ItemPhotoUrl] varchar(50)  NULL,
    [TypeNo] int  NOT NULL
);
GO

-- Creating table 'ItemTypes'
CREATE TABLE [dbo].[ItemTypes] (
    [ItemTypeNo] int  NOT NULL,
    [TypeName] varchar(20)  NOT NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [OrderNo] int  NOT NULL,
    [OrderDate] datetime  NOT NULL,
    [Subtotal] int  NOT NULL,
    [Tax] int  NOT NULL,
    [TotalAmount] int  NOT NULL,
    [CustomerNo] int  NOT NULL,
    [TableNo] int  NULL
);
GO

-- Creating table 'OrderDetails'
CREATE TABLE [dbo].[OrderDetails] (
    [OrderDetailNo] int  NOT NULL,
    [OrderNo] int  NOT NULL,
    [ItemNo] int  NOT NULL,
    [Quantity] int  NOT NULL
);
GO

-- Creating table 'Companies'
CREATE TABLE [dbo].[Companies] (
    [CompanyID] int  NOT NULL,
    [CompanyName] nchar(10)  NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [RoleId] int  NOT NULL,
    [RoleName] varchar(50)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [FirstName] varchar(50)  NOT NULL,
    [LastName] varchar(50)  NOT NULL,
    [Email] varchar(50)  NULL,
    [Address1] varchar(50)  NULL,
    [Address2] varchar(50)  NULL,
    [City] varchar(50)  NULL,
    [State] varchar(2)  NULL,
    [Zip] int  NULL
);
GO

-- Creating table 'UserLogins'
CREATE TABLE [dbo].[UserLogins] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [Username] varchar(50)  NOT NULL,
    [Password] varchar(50)  NOT NULL,
    [RoleId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ItemNo] in table 'Items'
ALTER TABLE [dbo].[Items]
ADD CONSTRAINT [PK_Items]
    PRIMARY KEY CLUSTERED ([ItemNo] ASC);
GO

-- Creating primary key on [ItemTypeNo] in table 'ItemTypes'
ALTER TABLE [dbo].[ItemTypes]
ADD CONSTRAINT [PK_ItemTypes]
    PRIMARY KEY CLUSTERED ([ItemTypeNo] ASC);
GO

-- Creating primary key on [OrderNo] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([OrderNo] ASC);
GO

-- Creating primary key on [OrderDetailNo] in table 'OrderDetails'
ALTER TABLE [dbo].[OrderDetails]
ADD CONSTRAINT [PK_OrderDetails]
    PRIMARY KEY CLUSTERED ([OrderDetailNo] ASC);
GO

-- Creating primary key on [CompanyID] in table 'Companies'
ALTER TABLE [dbo].[Companies]
ADD CONSTRAINT [PK_Companies]
    PRIMARY KEY CLUSTERED ([CompanyID] ASC);
GO

-- Creating primary key on [RoleId] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([RoleId] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UserId] in table 'UserLogins'
ALTER TABLE [dbo].[UserLogins]
ADD CONSTRAINT [PK_UserLogins]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [TypeNo] in table 'Items'
ALTER TABLE [dbo].[Items]
ADD CONSTRAINT [FK_TypeN]
    FOREIGN KEY ([TypeNo])
    REFERENCES [dbo].[ItemTypes]
        ([ItemTypeNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TypeN'
CREATE INDEX [IX_FK_TypeN]
ON [dbo].[Items]
    ([TypeNo]);
GO

-- Creating foreign key on [ItemNo] in table 'OrderDetails'
ALTER TABLE [dbo].[OrderDetails]
ADD CONSTRAINT [FK_Item_No]
    FOREIGN KEY ([ItemNo])
    REFERENCES [dbo].[Items]
        ([ItemNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Item_No'
CREATE INDEX [IX_FK_Item_No]
ON [dbo].[OrderDetails]
    ([ItemNo]);
GO

-- Creating foreign key on [OrderNo] in table 'OrderDetails'
ALTER TABLE [dbo].[OrderDetails]
ADD CONSTRAINT [FK_OrderNo]
    FOREIGN KEY ([OrderNo])
    REFERENCES [dbo].[Orders]
        ([OrderNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderNo'
CREATE INDEX [IX_FK_OrderNo]
ON [dbo].[OrderDetails]
    ([OrderNo]);
GO

-- Creating foreign key on [RoleId] in table 'UserLogins'
ALTER TABLE [dbo].[UserLogins]
ADD CONSTRAINT [FK__UserLogin_Roles]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[Roles]
        ([RoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK__UserLogin_Roles'
CREATE INDEX [IX_FK__UserLogin_Roles]
ON [dbo].[UserLogins]
    ([RoleId]);
GO

-- Creating foreign key on [UserId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK__User__UserLogin]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserLogins]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK__User__UserLogin'
CREATE INDEX [IX_FK__User__UserLogin]
ON [dbo].[Users]
    ([UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
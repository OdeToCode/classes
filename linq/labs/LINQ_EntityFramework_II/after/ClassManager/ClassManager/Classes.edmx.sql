
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 06/07/2010 23:15:38
-- Generated from EDMX file: C:\dev\pluralsight\alinq\trunk\labs\LINQ_EntityFramework_II\after\ClassManager\ClassManager\Models\Classes.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Classes];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Classes'
CREATE TABLE [dbo].[Classes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Students'
CREATE TABLE [dbo].[Students] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [HomeAddress_Street] nvarchar(max)  NOT NULL,
    [HomeAddress_City] nvarchar(max)  NOT NULL,
    [HomeAddress_State] nvarchar(2)  NOT NULL
);
GO

-- Creating table 'ClassStudent'
CREATE TABLE [dbo].[ClassStudent] (
    [Classes_Id] int  NOT NULL,
    [Students_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Classes'
ALTER TABLE [dbo].[Classes]
ADD CONSTRAINT [PK_Classes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Students'
ALTER TABLE [dbo].[Students]
ADD CONSTRAINT [PK_Students]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Classes_Id], [Students_Id] in table 'ClassStudent'
ALTER TABLE [dbo].[ClassStudent]
ADD CONSTRAINT [PK_ClassStudent]
    PRIMARY KEY NONCLUSTERED ([Classes_Id], [Students_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Classes_Id] in table 'ClassStudent'
ALTER TABLE [dbo].[ClassStudent]
ADD CONSTRAINT [FK_ClassStudent_Class]
    FOREIGN KEY ([Classes_Id])
    REFERENCES [dbo].[Classes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Students_Id] in table 'ClassStudent'
ALTER TABLE [dbo].[ClassStudent]
ADD CONSTRAINT [FK_ClassStudent_Student]
    FOREIGN KEY ([Students_Id])
    REFERENCES [dbo].[Students]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ClassStudent_Student'
CREATE INDEX [IX_FK_ClassStudent_Student]
ON [dbo].[ClassStudent]
    ([Students_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
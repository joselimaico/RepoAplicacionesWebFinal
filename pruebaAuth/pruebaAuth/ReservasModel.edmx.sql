
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/16/2018 15:58:04
-- Generated from EDMX file: c:\users\jose\source\repos\pruebaAuth\pruebaAuth\ReservasModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DatabaseReserva];
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

-- Creating table 'ReservaSet'
CREATE TABLE [dbo].[ReservaSet] (
    [IdReserva] int IDENTITY(1,1) NOT NULL,
    [NombreCliente] nvarchar(max)  NOT NULL,
    [TelefonoCliente] nvarchar(max)  NOT NULL,
    [CorreoCliente] nvarchar(max)  NOT NULL,
    [NumeroPersonas] int  NOT NULL,
    [InstitucionCliente] nvarchar(max)  NULL,
    [ApellidoCliente] nvarchar(max)  NOT NULL,
    [EstadoReserva] nvarchar(max)  NOT NULL,
    [FechaInicio] datetime  NOT NULL,
    [FechaFin] datetime  NOT NULL,
    [Color] nvarchar(max)  NOT NULL,
    [IsFullDay] tinyint  NOT NULL,
    [Subject] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DiaSet'
CREATE TABLE [dbo].[DiaSet] (
    [IdDia] int IDENTITY(1,1) NOT NULL,
    [Fecha] datetime  NOT NULL,
    [Holiday] nvarchar(max)  NOT NULL,
    [IsHoliday] tinyint  NOT NULL,
    [Color] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AdministradorSet'
CREATE TABLE [dbo].[AdministradorSet] (
    [IdAdmin] int IDENTITY(1,1) NOT NULL,
    [NombreUsuario] nvarchar(max)  NOT NULL,
    [ContraseñaUsuario] nvarchar(max)  NOT NULL,
    [CargoAdmin] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdReserva] in table 'ReservaSet'
ALTER TABLE [dbo].[ReservaSet]
ADD CONSTRAINT [PK_ReservaSet]
    PRIMARY KEY CLUSTERED ([IdReserva] ASC);
GO

-- Creating primary key on [IdDia] in table 'DiaSet'
ALTER TABLE [dbo].[DiaSet]
ADD CONSTRAINT [PK_DiaSet]
    PRIMARY KEY CLUSTERED ([IdDia] ASC);
GO

-- Creating primary key on [IdAdmin] in table 'AdministradorSet'
ALTER TABLE [dbo].[AdministradorSet]
ADD CONSTRAINT [PK_AdministradorSet]
    PRIMARY KEY CLUSTERED ([IdAdmin] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
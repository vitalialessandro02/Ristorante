USE [master]
GO
/****** Object:  Database [Ristorante]    Script Date: 25/03/2024 22:59:14 ******/
CREATE DATABASE [Ristorante]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Ristorante', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Ristorante.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Ristorante_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Ristorante_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Ristorante] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Ristorante].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Ristorante] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Ristorante] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Ristorante] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Ristorante] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Ristorante] SET ARITHABORT OFF 
GO
ALTER DATABASE [Ristorante] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Ristorante] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Ristorante] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Ristorante] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Ristorante] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Ristorante] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Ristorante] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Ristorante] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Ristorante] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Ristorante] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Ristorante] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Ristorante] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Ristorante] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Ristorante] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Ristorante] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Ristorante] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Ristorante] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Ristorante] SET RECOVERY FULL 
GO
ALTER DATABASE [Ristorante] SET  MULTI_USER 
GO
ALTER DATABASE [Ristorante] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Ristorante] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Ristorante] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Ristorante] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Ristorante] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Ristorante] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Ristorante', N'ON'
GO
ALTER DATABASE [Ristorante] SET QUERY_STORE = ON
GO
ALTER DATABASE [Ristorante] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Ristorante]
GO
/****** Object:  User [ristorante]    Script Date: 25/03/2024 22:59:15 ******/
CREATE USER [ristorante] FOR LOGIN [ristorante] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [ristorante]
GO
/****** Object:  Table [dbo].[DettagliOrdini]    Script Date: 25/03/2024 22:59:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DettagliOrdini](
	[IdPortata] [int] NOT NULL,
	[IdOrdine] [int] NOT NULL,
	[Quantita] [int] NOT NULL,
 CONSTRAINT [PK_DettagliOrdini] PRIMARY KEY CLUSTERED 
(
	[IdPortata] ASC,
	[IdOrdine] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ordini]    Script Date: 25/03/2024 22:59:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ordini](
	[IdOrdine] [int] IDENTITY(1,1) NOT NULL,
	[IdUtente] [int] NOT NULL,
	[DataOrdine] [datetime] NOT NULL,
	[Indirizzo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Ordine] PRIMARY KEY CLUSTERED 
(
	[IdOrdine] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Portate]    Script Date: 25/03/2024 22:59:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Portate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Prezzo] [float] NOT NULL,
	[Tipologia] [int] NOT NULL,
 CONSTRAINT [PK_Portata] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utenti]    Script Date: 25/03/2024 22:59:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utenti](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Cognome] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Ruolo] [int] NOT NULL,
 CONSTRAINT [PK_Utenti] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Portate] ON 

INSERT [dbo].[Portate] ([Id], [Nome], [Prezzo], [Tipologia]) VALUES (1, N'Carbonara', 10, 1)
INSERT [dbo].[Portate] ([Id], [Nome], [Prezzo], [Tipologia]) VALUES (2, N'Cacio e pepe', 9, 1)
INSERT [dbo].[Portate] ([Id], [Nome], [Prezzo], [Tipologia]) VALUES (3, N'Abbacchio', 18, 2)
INSERT [dbo].[Portate] ([Id], [Nome], [Prezzo], [Tipologia]) VALUES (6, N'Fiorentina', 32, 2)
INSERT [dbo].[Portate] ([Id], [Nome], [Prezzo], [Tipologia]) VALUES (7, N'Patate', 3, 3)
INSERT [dbo].[Portate] ([Id], [Nome], [Prezzo], [Tipologia]) VALUES (8, N'Insalata', 3, 3)
INSERT [dbo].[Portate] ([Id], [Nome], [Prezzo], [Tipologia]) VALUES (9, N'Tiramisu', 5, 4)
INSERT [dbo].[Portate] ([Id], [Nome], [Prezzo], [Tipologia]) VALUES (10, N'Cannolo siciliano', 4, 4)
SET IDENTITY_INSERT [dbo].[Portate] OFF
GO
SET IDENTITY_INSERT [dbo].[Utenti] ON 

INSERT [dbo].[Utenti] ([Id], [Email], [Nome], [Cognome], [Password], [Ruolo]) VALUES (3, N'admin@admin.com', N'admin', N'admin', N'Adm1n_', 2)
INSERT [dbo].[Utenti] ([Id], [Email], [Nome], [Cognome], [Password], [Ruolo]) VALUES (4, N'teodolinda.caridi@katamail.it', N'Teodolinda', N'Caridi', N'*RY18klbzF33D', 1)
INSERT [dbo].[Utenti] ([Id], [Email], [Nome], [Cognome], [Password], [Ruolo]) VALUES (5, N'ambr.iava@yahoo.it', N'Ambra', N'Iavaroni', N'_NS08bjpyT12P', 1)
INSERT [dbo].[Utenti] ([Id], [Email], [Nome], [Cognome], [Password], [Ruolo]) VALUES (6, N'fabrizio.cadorini@tin.it', N'Fabrizio', N'Cadorini', N'GN83lkhfR03Z?', 1)
INSERT [dbo].[Utenti] ([Id], [Email], [Nome], [Cognome], [Password], [Ruolo]) VALUES (7, N'enzo.varischi@virgilio.it', N'Enzo', N'Varischi', N'eshsERWYET2135_', 1)
SET IDENTITY_INSERT [dbo].[Utenti] OFF
GO
ALTER TABLE [dbo].[DettagliOrdini]  WITH CHECK ADD  CONSTRAINT [FK_Dettagli ordine_Ordine] FOREIGN KEY([IdOrdine])
REFERENCES [dbo].[Ordini] ([IdOrdine])
GO
ALTER TABLE [dbo].[DettagliOrdini] CHECK CONSTRAINT [FK_Dettagli ordine_Ordine]
GO
ALTER TABLE [dbo].[DettagliOrdini]  WITH CHECK ADD  CONSTRAINT [FK_Dettagli ordine_Portata] FOREIGN KEY([IdPortata])
REFERENCES [dbo].[Portate] ([Id])
GO
ALTER TABLE [dbo].[DettagliOrdini] CHECK CONSTRAINT [FK_Dettagli ordine_Portata]
GO
ALTER TABLE [dbo].[Ordini]  WITH CHECK ADD  CONSTRAINT [FK_Ordine_Utenti] FOREIGN KEY([IdUtente])
REFERENCES [dbo].[Utenti] ([Id])
GO
ALTER TABLE [dbo].[Ordini] CHECK CONSTRAINT [FK_Ordine_Utenti]
GO
USE [master]
GO
ALTER DATABASE [Ristorante] SET  READ_WRITE 
GO

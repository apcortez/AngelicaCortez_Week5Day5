USE [master]
GO
/****** Object:  Database [GestioneImpegni]    Script Date: 8/27/2021 11:55:09 AM ******/
CREATE DATABASE [GestioneImpegni]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GestioneImpegni', FILENAME = N'C:\Users\angelica.cortez\GestioneImpegni.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GestioneImpegni_log', FILENAME = N'C:\Users\angelica.cortez\GestioneImpegni_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [GestioneImpegni] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GestioneImpegni].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GestioneImpegni] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GestioneImpegni] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GestioneImpegni] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GestioneImpegni] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GestioneImpegni] SET ARITHABORT OFF 
GO
ALTER DATABASE [GestioneImpegni] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GestioneImpegni] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GestioneImpegni] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GestioneImpegni] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GestioneImpegni] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GestioneImpegni] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GestioneImpegni] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GestioneImpegni] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GestioneImpegni] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GestioneImpegni] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GestioneImpegni] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GestioneImpegni] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GestioneImpegni] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GestioneImpegni] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GestioneImpegni] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GestioneImpegni] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GestioneImpegni] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GestioneImpegni] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GestioneImpegni] SET  MULTI_USER 
GO
ALTER DATABASE [GestioneImpegni] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GestioneImpegni] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GestioneImpegni] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GestioneImpegni] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GestioneImpegni] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GestioneImpegni] SET QUERY_STORE = OFF
GO
USE [GestioneImpegni]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [GestioneImpegni]
GO
/****** Object:  Table [dbo].[TaskWork]    Script Date: 8/27/2021 11:55:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskWork](
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[ExpirationDate] [date] NOT NULL,
	[Priority] [int] NOT NULL,
	[Finished] [bit] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TaskWork] ON 

INSERT [dbo].[TaskWork] ([Title], [Description], [ExpirationDate], [Priority], [Finished], [Id]) VALUES (N'Email', N'Invio email lavoro', CAST(N'2021-09-30' AS Date), 1, 1, 1)
INSERT [dbo].[TaskWork] ([Title], [Description], [ExpirationDate], [Priority], [Finished], [Id]) VALUES (N'Meeting', N'Riunione Academy', CAST(N'2021-09-03' AS Date), 2, 0, 2)
INSERT [dbo].[TaskWork] ([Title], [Description], [ExpirationDate], [Priority], [Finished], [Id]) VALUES (N'Academy', N'Studio', CAST(N'2022-01-07' AS Date), 1, 0, 6)
INSERT [dbo].[TaskWork] ([Title], [Description], [ExpirationDate], [Priority], [Finished], [Id]) VALUES (N'Studio', N'C#', CAST(N'2021-10-31' AS Date), 1, 1, 4)
INSERT [dbo].[TaskWork] ([Title], [Description], [ExpirationDate], [Priority], [Finished], [Id]) VALUES (N'Compliance', N'Sicurezza Lavoro', CAST(N'2021-10-31' AS Date), 0, 0, 5)
SET IDENTITY_INSERT [dbo].[TaskWork] OFF
GO
USE [master]
GO
ALTER DATABASE [GestioneImpegni] SET  READ_WRITE 
GO

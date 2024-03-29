USE [master]
GO
/****** Object:  Database [CertificationWorkers]    Script Date: 16.09.2023 9:26:47 ******/
CREATE DATABASE [CertificationWorkers]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CertificationWorkers', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\CertificationWorkers.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CertificationWorkers_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\CertificationWorkers_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CertificationWorkers] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CertificationWorkers].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CertificationWorkers] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CertificationWorkers] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CertificationWorkers] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CertificationWorkers] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CertificationWorkers] SET ARITHABORT OFF 
GO
ALTER DATABASE [CertificationWorkers] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CertificationWorkers] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CertificationWorkers] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CertificationWorkers] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CertificationWorkers] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CertificationWorkers] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CertificationWorkers] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CertificationWorkers] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CertificationWorkers] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CertificationWorkers] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CertificationWorkers] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CertificationWorkers] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CertificationWorkers] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CertificationWorkers] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CertificationWorkers] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CertificationWorkers] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CertificationWorkers] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CertificationWorkers] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CertificationWorkers] SET  MULTI_USER 
GO
ALTER DATABASE [CertificationWorkers] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CertificationWorkers] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CertificationWorkers] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CertificationWorkers] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [CertificationWorkers]
GO
/****** Object:  Table [dbo].[TypeCertified]    Script Date: 16.09.2023 9:26:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeCertified](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TypeCertified] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Worker]    Script Date: 16.09.2023 9:26:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Worker](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Patronymic] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[PhoneNumber] [varchar](50) NOT NULL,
	[OrganizationName] [varchar](50) NOT NULL,
	[Category] [varchar](50) NOT NULL,
	[GroupSpeciality] [varchar](50) NOT NULL,
	[YearCertified] [varchar](50) NULL,
	[Description] [varchar](max) NULL,
	[WorkerPhoto] [varbinary](max) NULL,
	[idTypeCertified] [int] NOT NULL,
	[WorkerPositionName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Worker] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Worker]  WITH CHECK ADD  CONSTRAINT [FK_Worker_TypeCertified] FOREIGN KEY([idTypeCertified])
REFERENCES [dbo].[TypeCertified] ([id])
GO
ALTER TABLE [dbo].[Worker] CHECK CONSTRAINT [FK_Worker_TypeCertified]
GO
USE [master]
GO
ALTER DATABASE [CertificationWorkers] SET  READ_WRITE 
GO

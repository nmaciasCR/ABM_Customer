GO
/****** Object:  Database [Copernicus]    Script Date: 29/01/2024 23:51:10 ******/
CREATE DATABASE [Copernicus]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Copernicus', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Copernicus.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Copernicus_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Copernicus_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Copernicus] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Copernicus].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Copernicus] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Copernicus] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Copernicus] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Copernicus] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Copernicus] SET ARITHABORT OFF 
GO
ALTER DATABASE [Copernicus] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Copernicus] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Copernicus] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Copernicus] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Copernicus] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Copernicus] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Copernicus] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Copernicus] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Copernicus] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Copernicus] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Copernicus] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Copernicus] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Copernicus] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Copernicus] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Copernicus] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Copernicus] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Copernicus] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Copernicus] SET RECOVERY FULL 
GO
ALTER DATABASE [Copernicus] SET  MULTI_USER 
GO
ALTER DATABASE [Copernicus] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Copernicus] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Copernicus] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Copernicus] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Copernicus] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Copernicus] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Copernicus', N'ON'
GO
ALTER DATABASE [Copernicus] SET QUERY_STORE = OFF
GO
USE [Copernicus]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 29/01/2024 23:51:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[id] [int] NOT NULL,
	[email] [varchar](100) NOT NULL,
	[first] [varchar](100) NOT NULL,
	[last] [varchar](100) NOT NULL,
	[company] [varchar](100) NOT NULL,
	[created] [datetime] NOT NULL,
	[country] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [Copernicus] SET  READ_WRITE 
GO

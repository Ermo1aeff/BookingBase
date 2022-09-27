USE [master]
GO
/****** Object:  Database [Booking_Base]    Script Date: 27.09.2022 20:22:26 ******/
CREATE DATABASE [Booking_Base]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Booking_Base', FILENAME = N'D:\MSSQL\Booking_Base.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'Booking_Base_log', FILENAME = N'D:\MSSQL\Booking_Base_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Booking_Base] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Booking_Base].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Booking_Base] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Booking_Base] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Booking_Base] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Booking_Base] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Booking_Base] SET ARITHABORT OFF 
GO
ALTER DATABASE [Booking_Base] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Booking_Base] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Booking_Base] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Booking_Base] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Booking_Base] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Booking_Base] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Booking_Base] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Booking_Base] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Booking_Base] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Booking_Base] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Booking_Base] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Booking_Base] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Booking_Base] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Booking_Base] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Booking_Base] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Booking_Base] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Booking_Base] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Booking_Base] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Booking_Base] SET  MULTI_USER 
GO
ALTER DATABASE [Booking_Base] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Booking_Base] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Booking_Base] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Booking_Base] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Booking_Base] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Booking_Base] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Booking_Base] SET QUERY_STORE = OFF
GO
USE [Booking_Base]
GO
/****** Object:  Table [dbo].[clients]    Script Date: 27.09.2022 20:22:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clients](
	[client_id] [int] NOT NULL,
	[first_name] [varchar](50) NULL,
	[last_name] [varchar](50) NULL,
	[patronymic] [varchar](50) NULL,
	[passport] [int] NULL,
 CONSTRAINT [PK_clients] PRIMARY KEY CLUSTERED 
(
	[client_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hotels]    Script Date: 27.09.2022 20:22:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hotels](
	[hotel_id] [int] NOT NULL,
	[hotel_name] [char](100) NULL,
	[vacancies] [int] NULL,
 CONSTRAINT [PK_hotels] PRIMARY KEY CLUSTERED 
(
	[hotel_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[locations]    Script Date: 27.09.2022 20:22:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[locations](
	[location_id] [int] NOT NULL,
	[location_name] [char](100) NULL,
 CONSTRAINT [PK_locations] PRIMARY KEY CLUSTERED 
(
	[location_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orders]    Script Date: 27.09.2022 20:22:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orders](
	[order_id] [int] NOT NULL,
	[tour_id] [int] NULL,
	[client_id] [int] NULL,
	[price] [decimal](18, 2) NULL,
	[date_begin] [date] NULL,
	[adults_count] [int] NULL,
	[kids_count] [int] NULL,
	[city] [char](50) NULL,
 CONSTRAINT [PK_orders] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[programs]    Script Date: 27.09.2022 20:22:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[programs](
	[program_id] [int] NOT NULL,
	[program_name] [char](100) NULL,
	[program_event] [char](200) NULL,
	[duration_begin] [datetime] NULL,
	[duration_end] [datetime] NULL,
 CONSTRAINT [PK_programs] PRIMARY KEY CLUSTERED 
(
	[program_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tours]    Script Date: 27.09.2022 20:22:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tours](
	[tour_id] [int] NOT NULL,
	[hotel_id] [int] NULL,
	[location_id] [int] NULL,
	[order_id] [int] NOT NULL,
	[program_id] [int] NULL,
 CONSTRAINT [PK_tours] PRIMARY KEY CLUSTERED 
(
	[tour_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[orders]  WITH CHECK ADD  CONSTRAINT [FK_orders_clients] FOREIGN KEY([client_id])
REFERENCES [dbo].[clients] ([client_id])
GO
ALTER TABLE [dbo].[orders] CHECK CONSTRAINT [FK_orders_clients]
GO
ALTER TABLE [dbo].[orders]  WITH CHECK ADD  CONSTRAINT [FK_orders_tours] FOREIGN KEY([tour_id])
REFERENCES [dbo].[tours] ([tour_id])
GO
ALTER TABLE [dbo].[orders] CHECK CONSTRAINT [FK_orders_tours]
GO
ALTER TABLE [dbo].[tours]  WITH CHECK ADD  CONSTRAINT [FK_tours_hotels] FOREIGN KEY([hotel_id])
REFERENCES [dbo].[hotels] ([hotel_id])
GO
ALTER TABLE [dbo].[tours] CHECK CONSTRAINT [FK_tours_hotels]
GO
ALTER TABLE [dbo].[tours]  WITH CHECK ADD  CONSTRAINT [FK_tours_locations] FOREIGN KEY([location_id])
REFERENCES [dbo].[locations] ([location_id])
GO
ALTER TABLE [dbo].[tours] CHECK CONSTRAINT [FK_tours_locations]
GO
ALTER TABLE [dbo].[tours]  WITH CHECK ADD  CONSTRAINT [FK_tours_programs] FOREIGN KEY([program_id])
REFERENCES [dbo].[programs] ([program_id])
GO
ALTER TABLE [dbo].[tours] CHECK CONSTRAINT [FK_tours_programs]
GO
USE [master]
GO
ALTER DATABASE [Booking_Base] SET  READ_WRITE 
GO

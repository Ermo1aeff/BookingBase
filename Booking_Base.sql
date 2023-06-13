USE [master]
GO
/****** Object:  Database [Booking_Base]    Script Date: 13.06.2023 10:54:57 ******/
CREATE DATABASE [Booking_Base]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Booking_Base', FILENAME = N'D:\MSSQL\Booking_Base.mdf' , SIZE = 31488KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'Booking_Base_log', FILENAME = N'D:\MSSQL\Booking_Base_log.ldf' , SIZE = 16576KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
EXEC sys.sp_db_vardecimal_storage_format N'Booking_Base', N'ON'
GO
ALTER DATABASE [Booking_Base] SET QUERY_STORE = OFF
GO
USE [Booking_Base]
GO
/****** Object:  Table [dbo].[accounts]    Script Date: 13.06.2023 10:54:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[accounts](
	[account_id] [int] IDENTITY(1,1) NOT NULL,
	[account_login] [varchar](16) NOT NULL,
	[account_password] [varchar](16) NULL,
	[first_name_id] [int] NULL,
	[last_name_id] [int] NULL,
	[role_id] [int] NULL,
	[image] [image] NULL,
	[phone] [bigint] NULL,
	[email] [varchar](50) NULL,
	[dayofbirth] [datetime] NULL,
 CONSTRAINT [PK_accounts] PRIMARY KEY CLUSTERED 
(
	[account_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cities]    Script Date: 13.06.2023 10:54:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cities](
	[city_id] [int] IDENTITY(1,1) NOT NULL,
	[country_id] [int] NULL,
	[city_name] [varchar](50) NULL,
 CONSTRAINT [PK_cities] PRIMARY KEY CLUSTERED 
(
	[city_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[countries]    Script Date: 13.06.2023 10:54:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[countries](
	[country_id] [int] IDENTITY(1,1) NOT NULL,
	[country_name] [varchar](200) NULL,
 CONSTRAINT [PK_countries] PRIMARY KEY CLUSTERED 
(
	[country_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[departures]    Script Date: 13.06.2023 10:54:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[departures](
	[departure_id] [int] IDENTITY(1,1) NOT NULL,
	[tour_id] [int] NULL,
	[date_begin] [date] NULL,
 CONSTRAINT [PK_departures] PRIMARY KEY CLUSTERED 
(
	[departure_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[discounts]    Script Date: 13.06.2023 10:54:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[discounts](
	[discount_id] [int] NOT NULL,
	[discount_percentage] [int] NULL,
	[tour_id] [int] NULL,
	[date_begin] [date] NULL,
	[date_end] [date] NULL,
 CONSTRAINT [PK_discounts] PRIMARY KEY CLUSTERED 
(
	[discount_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[first_names]    Script Date: 13.06.2023 10:54:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[first_names](
	[first_name_id] [int] IDENTITY(10,1) NOT NULL,
	[first_name] [varchar](25) NULL,
 CONSTRAINT [PK_first_names] PRIMARY KEY CLUSTERED 
(
	[first_name_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[grades]    Script Date: 13.06.2023 10:54:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[grades](
	[grade_id] [int] NOT NULL,
	[tour_id] [int] NULL,
	[account_id] [int] NULL,
 CONSTRAINT [PK_grades] PRIMARY KEY CLUSTERED 
(
	[grade_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[images]    Script Date: 13.06.2023 10:54:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[images](
	[image_id] [int] IDENTITY(10,1) NOT NULL,
	[tour_id] [int] NULL,
	[img] [image] NULL,
 CONSTRAINT [PK_images] PRIMARY KEY CLUSTERED 
(
	[image_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[included]    Script Date: 13.06.2023 10:54:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[included](
	[included_id] [int] IDENTITY(1,1) NOT NULL,
	[tour_id] [int] NULL,
	[inclusion_id] [int] NULL,
	[included_choice] [int] NULL,
	[included_description] [varchar](3000) NULL,
 CONSTRAINT [PK_inclusion] PRIMARY KEY CLUSTERED 
(
	[included_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[inclusions]    Script Date: 13.06.2023 10:54:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[inclusions](
	[inclusion_id] [int] IDENTITY(1,1) NOT NULL,
	[inclusion_name] [varchar](50) NULL,
 CONSTRAINT [PK_inclusions] PRIMARY KEY CLUSTERED 
(
	[inclusion_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itinerary]    Script Date: 13.06.2023 10:54:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[itinerary](
	[itinerary_id] [int] IDENTITY(1,1) NOT NULL,
	[tour_id] [int] NULL,
	[day_num] [int] NULL,
	[itinerary_name] [varchar](100) NULL,
	[itirarary_description] [varchar](1000) NULL,
 CONSTRAINT [PK_itirerary] PRIMARY KEY CLUSTERED 
(
	[itinerary_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[last_names]    Script Date: 13.06.2023 10:54:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[last_names](
	[last_name_id] [int] IDENTITY(10,1) NOT NULL,
	[last_name] [varchar](25) NULL,
 CONSTRAINT [PK_last_names] PRIMARY KEY CLUSTERED 
(
	[last_name_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[liked_tours]    Script Date: 13.06.2023 10:54:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[liked_tours](
	[liked_tour_id] [int] IDENTITY(1,1) NOT NULL,
	[tour_id] [int] NULL,
	[account_id] [int] NULL,
 CONSTRAINT [PK_wish_lists] PRIMARY KEY CLUSTERED 
(
	[liked_tour_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order_rooms]    Script Date: 13.06.2023 10:54:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order_rooms](
	[order_room_id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NULL,
	[room_id] [int] NULL,
	[room_count] [int] NULL,
 CONSTRAINT [PK_order_rooms] PRIMARY KEY CLUSTERED 
(
	[order_room_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orders]    Script Date: 13.06.2023 10:54:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orders](
	[order_id] [int] IDENTITY(1000000,1) NOT NULL,
	[departures_id] [int] NULL,
	[contact_phone] [bigint] NULL,
	[price] [decimal](18, 2) NULL,
 CONSTRAINT [PK_orders] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[passed_tours]    Script Date: 13.06.2023 10:54:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[passed_tours](
	[passed_tour_id] [int] IDENTITY(1,1) NOT NULL,
	[tour_id] [int] NULL,
	[account_id] [int] NULL,
 CONSTRAINT [PK_account_tours] PRIMARY KEY CLUSTERED 
(
	[passed_tour_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[persons]    Script Date: 13.06.2023 10:54:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[persons](
	[person_id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NULL,
	[first_name_id] [int] NULL,
	[last_name_id] [int] NULL,
	[birthday] [date] NULL,
 CONSTRAINT [PK_persons] PRIMARY KEY CLUSTERED 
(
	[person_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[roles]    Script Date: 13.06.2023 10:54:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[roles](
	[roles_id] [int] IDENTITY(1,1) NOT NULL,
	[role_name] [varchar](25) NULL,
 CONSTRAINT [PK_roles] PRIMARY KEY CLUSTERED 
(
	[roles_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rooms]    Script Date: 13.06.2023 10:54:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rooms](
	[room_id] [int] IDENTITY(1,1) NOT NULL,
	[room_name] [varchar](100) NULL,
	[tour_id] [int] NULL,
	[beds_count] [int] NULL,
	[price] [decimal](18, 2) NULL,
 CONSTRAINT [PK_hotels] PRIMARY KEY CLUSTERED 
(
	[room_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tours]    Script Date: 13.06.2023 10:54:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tours](
	[tour_id] [int] IDENTITY(1,1) NOT NULL,
	[tour_name] [varchar](100) NULL,
	[tour_description] [varchar](5000) NULL,
	[city_begin_id] [int] NULL,
	[city_end_id] [int] NULL,
	[price] [decimal](18, 2) NULL,
	[day_count] [int] NULL,
	[max_group_size] [int] NULL,
	[min_age] [int] NULL,
	[max_age] [int] NULL,
 CONSTRAINT [PK_tours] PRIMARY KEY CLUSTERED 
(
	[tour_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[viewed_tours]    Script Date: 13.06.2023 10:54:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[viewed_tours](
	[viewed_tour_id] [int] IDENTITY(1,1) NOT NULL,
	[tour_id] [int] NULL,
	[account_id] [int] NULL,
 CONSTRAINT [PK_viewed_lists] PRIMARY KEY CLUSTERED 
(
	[viewed_tour_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[accounts]  WITH CHECK ADD  CONSTRAINT [FK_accounts_first_names] FOREIGN KEY([first_name_id])
REFERENCES [dbo].[first_names] ([first_name_id])
GO
ALTER TABLE [dbo].[accounts] CHECK CONSTRAINT [FK_accounts_first_names]
GO
ALTER TABLE [dbo].[accounts]  WITH CHECK ADD  CONSTRAINT [FK_accounts_last_names] FOREIGN KEY([last_name_id])
REFERENCES [dbo].[last_names] ([last_name_id])
GO
ALTER TABLE [dbo].[accounts] CHECK CONSTRAINT [FK_accounts_last_names]
GO
ALTER TABLE [dbo].[accounts]  WITH CHECK ADD  CONSTRAINT [FK_accounts_roles] FOREIGN KEY([role_id])
REFERENCES [dbo].[roles] ([roles_id])
GO
ALTER TABLE [dbo].[accounts] CHECK CONSTRAINT [FK_accounts_roles]
GO
ALTER TABLE [dbo].[cities]  WITH CHECK ADD  CONSTRAINT [FK_cities_countries] FOREIGN KEY([country_id])
REFERENCES [dbo].[countries] ([country_id])
GO
ALTER TABLE [dbo].[cities] CHECK CONSTRAINT [FK_cities_countries]
GO
ALTER TABLE [dbo].[departures]  WITH CHECK ADD  CONSTRAINT [FK_departures_tours] FOREIGN KEY([tour_id])
REFERENCES [dbo].[tours] ([tour_id])
GO
ALTER TABLE [dbo].[departures] CHECK CONSTRAINT [FK_departures_tours]
GO
ALTER TABLE [dbo].[discounts]  WITH CHECK ADD  CONSTRAINT [FK_discounts_tours] FOREIGN KEY([tour_id])
REFERENCES [dbo].[tours] ([tour_id])
GO
ALTER TABLE [dbo].[discounts] CHECK CONSTRAINT [FK_discounts_tours]
GO
ALTER TABLE [dbo].[grades]  WITH CHECK ADD  CONSTRAINT [FK_grades_accounts] FOREIGN KEY([account_id])
REFERENCES [dbo].[accounts] ([account_id])
GO
ALTER TABLE [dbo].[grades] CHECK CONSTRAINT [FK_grades_accounts]
GO
ALTER TABLE [dbo].[grades]  WITH CHECK ADD  CONSTRAINT [FK_grades_tours] FOREIGN KEY([tour_id])
REFERENCES [dbo].[tours] ([tour_id])
GO
ALTER TABLE [dbo].[grades] CHECK CONSTRAINT [FK_grades_tours]
GO
ALTER TABLE [dbo].[images]  WITH CHECK ADD  CONSTRAINT [FK_images_tours] FOREIGN KEY([tour_id])
REFERENCES [dbo].[tours] ([tour_id])
GO
ALTER TABLE [dbo].[images] CHECK CONSTRAINT [FK_images_tours]
GO
ALTER TABLE [dbo].[included]  WITH CHECK ADD  CONSTRAINT [FK_included_inclusions] FOREIGN KEY([inclusion_id])
REFERENCES [dbo].[inclusions] ([inclusion_id])
GO
ALTER TABLE [dbo].[included] CHECK CONSTRAINT [FK_included_inclusions]
GO
ALTER TABLE [dbo].[included]  WITH CHECK ADD  CONSTRAINT [FK_included_tours] FOREIGN KEY([tour_id])
REFERENCES [dbo].[tours] ([tour_id])
GO
ALTER TABLE [dbo].[included] CHECK CONSTRAINT [FK_included_tours]
GO
ALTER TABLE [dbo].[itinerary]  WITH CHECK ADD  CONSTRAINT [FK_itirerary_tours] FOREIGN KEY([tour_id])
REFERENCES [dbo].[tours] ([tour_id])
GO
ALTER TABLE [dbo].[itinerary] CHECK CONSTRAINT [FK_itirerary_tours]
GO
ALTER TABLE [dbo].[liked_tours]  WITH CHECK ADD  CONSTRAINT [FK_wish_lists_accounts] FOREIGN KEY([account_id])
REFERENCES [dbo].[accounts] ([account_id])
GO
ALTER TABLE [dbo].[liked_tours] CHECK CONSTRAINT [FK_wish_lists_accounts]
GO
ALTER TABLE [dbo].[liked_tours]  WITH CHECK ADD  CONSTRAINT [FK_wish_lists_tours] FOREIGN KEY([tour_id])
REFERENCES [dbo].[tours] ([tour_id])
GO
ALTER TABLE [dbo].[liked_tours] CHECK CONSTRAINT [FK_wish_lists_tours]
GO
ALTER TABLE [dbo].[order_rooms]  WITH CHECK ADD  CONSTRAINT [FK_order_rooms_orders] FOREIGN KEY([order_id])
REFERENCES [dbo].[orders] ([order_id])
GO
ALTER TABLE [dbo].[order_rooms] CHECK CONSTRAINT [FK_order_rooms_orders]
GO
ALTER TABLE [dbo].[order_rooms]  WITH CHECK ADD  CONSTRAINT [FK_order_rooms_rooms] FOREIGN KEY([room_id])
REFERENCES [dbo].[rooms] ([room_id])
GO
ALTER TABLE [dbo].[order_rooms] CHECK CONSTRAINT [FK_order_rooms_rooms]
GO
ALTER TABLE [dbo].[orders]  WITH CHECK ADD  CONSTRAINT [FK_orders_departures] FOREIGN KEY([departures_id])
REFERENCES [dbo].[departures] ([departure_id])
GO
ALTER TABLE [dbo].[orders] CHECK CONSTRAINT [FK_orders_departures]
GO
ALTER TABLE [dbo].[passed_tours]  WITH CHECK ADD  CONSTRAINT [FK_account_tours_accounts] FOREIGN KEY([account_id])
REFERENCES [dbo].[accounts] ([account_id])
GO
ALTER TABLE [dbo].[passed_tours] CHECK CONSTRAINT [FK_account_tours_accounts]
GO
ALTER TABLE [dbo].[passed_tours]  WITH CHECK ADD  CONSTRAINT [FK_account_tours_tours] FOREIGN KEY([tour_id])
REFERENCES [dbo].[tours] ([tour_id])
GO
ALTER TABLE [dbo].[passed_tours] CHECK CONSTRAINT [FK_account_tours_tours]
GO
ALTER TABLE [dbo].[persons]  WITH CHECK ADD  CONSTRAINT [FK_persons_first_names] FOREIGN KEY([first_name_id])
REFERENCES [dbo].[first_names] ([first_name_id])
GO
ALTER TABLE [dbo].[persons] CHECK CONSTRAINT [FK_persons_first_names]
GO
ALTER TABLE [dbo].[persons]  WITH CHECK ADD  CONSTRAINT [FK_persons_last_names] FOREIGN KEY([last_name_id])
REFERENCES [dbo].[last_names] ([last_name_id])
GO
ALTER TABLE [dbo].[persons] CHECK CONSTRAINT [FK_persons_last_names]
GO
ALTER TABLE [dbo].[persons]  WITH CHECK ADD  CONSTRAINT [FK_persons_orders] FOREIGN KEY([order_id])
REFERENCES [dbo].[orders] ([order_id])
GO
ALTER TABLE [dbo].[persons] CHECK CONSTRAINT [FK_persons_orders]
GO
ALTER TABLE [dbo].[rooms]  WITH CHECK ADD  CONSTRAINT [FK_rooms_tours] FOREIGN KEY([tour_id])
REFERENCES [dbo].[tours] ([tour_id])
GO
ALTER TABLE [dbo].[rooms] CHECK CONSTRAINT [FK_rooms_tours]
GO
ALTER TABLE [dbo].[tours]  WITH CHECK ADD  CONSTRAINT [FK_tours_cities] FOREIGN KEY([city_begin_id])
REFERENCES [dbo].[cities] ([city_id])
GO
ALTER TABLE [dbo].[tours] CHECK CONSTRAINT [FK_tours_cities]
GO
ALTER TABLE [dbo].[tours]  WITH CHECK ADD  CONSTRAINT [FK_tours_cities1] FOREIGN KEY([city_end_id])
REFERENCES [dbo].[cities] ([city_id])
GO
ALTER TABLE [dbo].[tours] CHECK CONSTRAINT [FK_tours_cities1]
GO
ALTER TABLE [dbo].[viewed_tours]  WITH CHECK ADD  CONSTRAINT [FK_viewed_lists_accounts] FOREIGN KEY([account_id])
REFERENCES [dbo].[accounts] ([account_id])
GO
ALTER TABLE [dbo].[viewed_tours] CHECK CONSTRAINT [FK_viewed_lists_accounts]
GO
ALTER TABLE [dbo].[viewed_tours]  WITH CHECK ADD  CONSTRAINT [FK_viewed_lists_tours] FOREIGN KEY([tour_id])
REFERENCES [dbo].[tours] ([tour_id])
GO
ALTER TABLE [dbo].[viewed_tours] CHECK CONSTRAINT [FK_viewed_lists_tours]
GO
USE [master]
GO
ALTER DATABASE [Booking_Base] SET  READ_WRITE 
GO

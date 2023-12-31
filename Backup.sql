USE [master]
GO
/****** Object:  Database [FinalWebsite]    Script Date: 04.07.2023 15:52:38 ******/
CREATE DATABASE [FinalWebsite]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FinalWebsite', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS01\MSSQL\DATA\FinalWebsite.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FinalWebsite_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS01\MSSQL\DATA\FinalWebsite_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [FinalWebsite] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FinalWebsite].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FinalWebsite] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FinalWebsite] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FinalWebsite] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FinalWebsite] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FinalWebsite] SET ARITHABORT OFF 
GO
ALTER DATABASE [FinalWebsite] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [FinalWebsite] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FinalWebsite] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FinalWebsite] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FinalWebsite] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FinalWebsite] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FinalWebsite] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FinalWebsite] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FinalWebsite] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FinalWebsite] SET  ENABLE_BROKER 
GO
ALTER DATABASE [FinalWebsite] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FinalWebsite] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FinalWebsite] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FinalWebsite] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FinalWebsite] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FinalWebsite] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [FinalWebsite] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FinalWebsite] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FinalWebsite] SET  MULTI_USER 
GO
ALTER DATABASE [FinalWebsite] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FinalWebsite] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FinalWebsite] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FinalWebsite] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FinalWebsite] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FinalWebsite] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [FinalWebsite] SET QUERY_STORE = ON
GO
ALTER DATABASE [FinalWebsite] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [FinalWebsite]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 04.07.2023 15:52:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActorMovie]    Script Date: 04.07.2023 15:52:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActorMovie](
	[ActorsId] [int] NOT NULL,
	[MoviesId] [int] NOT NULL,
 CONSTRAINT [PK_ActorMovie] PRIMARY KEY CLUSTERED 
(
	[ActorsId] ASC,
	[MoviesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Actors]    Script Date: 04.07.2023 15:52:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](200) NOT NULL,
	[About] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
 CONSTRAINT [PK_Actors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 04.07.2023 15:52:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 04.07.2023 15:52:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 04.07.2023 15:52:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 04.07.2023 15:52:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 04.07.2023 15:52:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 04.07.2023 15:52:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Image] [nvarchar](max) NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 04.07.2023 15:52:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Directors]    Script Date: 04.07.2023 15:52:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Directors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](200) NOT NULL,
	[About] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
 CONSTRAINT [PK_Directors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 04.07.2023 15:52:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 04.07.2023 15:52:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Rate] [decimal](18, 1) NOT NULL,
	[RunTime] [int] NOT NULL,
	[Year] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[DirectorId] [int] NOT NULL,
	[GenreId] [int] NOT NULL,
	[Video] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230704100726_Initial_mig', N'6.0.16')
GO
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (2, 1)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (3, 1)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (4, 1)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (8, 1)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (2, 2)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (4, 2)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (8, 2)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (5, 3)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (6, 3)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (7, 3)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (5, 4)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (6, 4)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (7, 4)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (2, 5)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (3, 5)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (5, 5)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (6, 5)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (1, 6)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (2, 6)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (3, 6)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (2, 7)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (3, 7)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (4, 7)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (5, 7)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (7, 7)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (4, 8)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (5, 8)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (6, 8)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (1, 9)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (2, 9)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (3, 9)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (4, 9)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (6, 10)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (7, 10)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (8, 10)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (1, 11)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (2, 11)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (3, 11)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (6, 11)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (2, 12)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (4, 12)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (5, 12)
INSERT [dbo].[ActorMovie] ([ActorsId], [MoviesId]) VALUES (6, 12)
GO
SET IDENTITY_INSERT [dbo].[Actors] ON 

INSERT [dbo].[Actors] ([Id], [FullName], [About], [Image]) VALUES (1, N'Baran bo Odar', N'Robert Lee Zemeckis (born May 14, 1952) is an American filmmaker. He first came to public attention as the director of the action-adventure romantic comedy Romancing the Stone (1984), the science-fiction comedy Back to the Future film trilogy (1985–1990), and the live-action/animated comedy Who Framed Roger Rabbit (1988). He subsequently directed the satirical black comedy Death Becomes Her (1992) and then diversified into more dramatic fare, including Forrest Gump (1994), for which he won the Academy Award for Best Director. The film also won the Best Picture. He has directed films across a wide variety of genres, for both adults and families.', N'813d1104-2f1a-4a52-b836-feecca21df14Leonardo DiCaprio.jpg')
INSERT [dbo].[Actors] ([Id], [FullName], [About], [Image]) VALUES (2, N'Agnes Mai', N'Agnes Mai was born on 31 March 1990 in Augsburg, Germany. She is an actress and director, known for Who Am I (2014), Der Politiker and Luna Agonia.', N'00d55b82-7754-40b6-8a01-2fd248b22290Martin Scorsese.jpg')
INSERT [dbo].[Actors] ([Id], [FullName], [About], [Image]) VALUES (3, N'Alejandro González Iñárritu', N'Iñárritu began his career in 1984 as a radio host at the Mexican radio station WFM, the country''s most popular rock music station, where he "pieced together playlists into a loose narrative arc".[10][11] He worked with and interviewed artists like Robert Plant, David Gilmour, Elton John, Bob Geldof and Carlos Santana. He also wrote and broadcast small audio stories and storytelling promos. He later became the youngest producer for Televisa , the largest mass media company in Latin America. From 1987 to 1989, he composed music for six Mexican feature films. During this time, Iñárritu became acquainted with Mexican writer Guillermo Arriaga, beginning their screenwriting collaborations. Iñárritu has stated that he believes music has had a bigger influence on him as an artist than film itself.', N'3de16cde-4752-4711-a71e-864280af6d51A.jpg')
INSERT [dbo].[Actors] ([Id], [FullName], [About], [Image]) VALUES (4, N'Tijan Marei', N'Aneesh Chaganty was born in Redmond, Washington, and grew up in San Jose, California. His parents, originally from Andhra Pradesh, India, moved to the U.S. in the 1980s. His father, who obtained an MS degree in computer engineering from Drexel University, serves as a director and Chief Technology Officer at a software publishing, consultancy and supply company founded by both his parents, AppEnsure Inc.  Chaganty attended Valley Christian High School from 2005 to 2009. He graduated from USC School of Cinematic Arts in 2013 with a degree in film and television production.', N'e6802ad4-c621-41d8-86be-a7047a0cdf06Emma Stone.jpg')
INSERT [dbo].[Actors] ([Id], [FullName], [About], [Image]) VALUES (5, N'William Dickinson', N'Leonard Carow ist der Sohn der Künstlerin und Autorin Katrin Bongard und der Bruder von Isabel und Amber Bongard.[1] An der Seite seiner Schwestern hatte Carow 2004 in der Folge Große Liebe aus der Fernsehreihe Tatort seinen ersten Auftritt als Kinderdarsteller. Die Nebenrolle im deutsch-österreichischen Fernsehfilm Stauffenberg aus demselben Jahr blieb im Abspann unberücksichtigt.  Nach weiteren Auftritten in Fernsehfilmen und -serien spielte er 2008 im Filmdrama Mondkalb den Filmsohn von Axel Prahl sowie in der Komödie Die Relativitätstheorie der Liebe neben Katja Riemann und Olli Dittrich. Seinen bisherigen Karrierehöhepunkt erreichte er 2011 im oscar-nominierten US-amerikanisch-britischen Weltkriegsdrama Gefährten unter der Regie von Steven Spielberg.[2] In der Verfilmung von Michael Morpurgos Roman War Horse verkörperte er Michael Schröder, einen jungen deutschen Soldaten im Ersten Weltkrieg. Zusammen mit seinem Bruder Günther, gespielt von David Kross, kümmert er sich in der Feldambulanz um das Pferd Jo', N'9406c256-f4f6-46f3-8567-61435bda700aceb9.jpg')
INSERT [dbo].[Actors] ([Id], [FullName], [About], [Image]) VALUES (6, N'Tijan Marei', N'Agnes Mai was born on 31 March 1990 in Augsburg, Germany. She is an actress and director, known for Who Am I (2014), Der Politiker and Luna Agonia.', N'3c8a7ba0-eee5-4cff-b596-7ddb9f7da7a0ceb7.jpg')
INSERT [dbo].[Actors] ([Id], [FullName], [About], [Image]) VALUES (7, N'Aneesh Chaganty', N'Agnes Mai was born on 31 March 1990 in Augsburg, Germany. She is an actress and director, known for Who Am I (2014), Der Politiker and Luna Agonia.', N'8b9a196a-bcd3-428a-a8b8-52a01d6280e8blog-it1.jpg')
INSERT [dbo].[Actors] ([Id], [FullName], [About], [Image]) VALUES (8, N'Alejandro González Iñárritu', N'Robert Lee Zemeckis (born May 14, 1952) is an American filmmaker. He first came to public attention as the director of the action-adventure romantic comedy Romancing the Stone (1984), the science-fiction comedy Back to the Future film trilogy (1985–1990), and the live-action/animated comedy Who Framed Roger Rabbit (1988). He subsequently directed the satirical black comedy Death Becomes Her (1992) and then diversified into more dramatic fare, including Forrest Gump (1994), for which he won the Academy Award for Best Director. The film also won the Best Picture. He has directed films across a wide variety of genres, for both adults and families.', N'325dc3e4-75c6-4276-8609-ba171ce1611dblog-it2.jpg')
SET IDENTITY_INSERT [dbo].[Actors] OFF
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'b7abfb0f-52dc-4836-83c9-734c80cd68e1', N'member', N'MEMBER', N'62c83f42-5620-434c-8f3a-72e8aa8273f1')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'd68d8be8-09fa-4b68-a957-1794d388a3ce', N'admin', N'ADMIN', N'7b3c6df3-ac99-4d4e-b615-c91a61b5a05a')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a990c12b-4c1d-4bc0-b152-a4698de5df02', N'b7abfb0f-52dc-4836-83c9-734c80cd68e1')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'66f708a2-8fd7-4075-b9a3-53fba9fde68b', N'd68d8be8-09fa-4b68-a957-1794d388a3ce')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Name], [Image], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'66f708a2-8fd7-4075-b9a3-53fba9fde68b', N'Admin', NULL, N'admin', N'ADMIN', N'memmedovaaysel501@gmail.com', N'MEMMEDOVAAYSEL501@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEHeMTn46QssdkKQXmwo0o1DMpprWMsRSEsd0WEb/aRBk0zHuC8J6In7eR1T1JiRkIg==', N'CLZAZBCCEWAGI7AXHXHSVG4GPPAJZRKJ', N'01f48d60-a5c5-4022-bbd0-6bfe9ad93a8e', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Name], [Image], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'a990c12b-4c1d-4bc0-b152-a4698de5df02', N'Aysel', NULL, N'aysel', N'AYSEL', N'7pg67lv@code.edu.az', N'7PG67LV@CODE.EDU.AZ', 1, N'AQAAAAEAACcQAAAAEJIDMQ+7Cd2t0kXlqGgf5rr9FaK9hfxcvv50L/oUwPqnBZLLerq1fZXfRilZDbDOkw==', N'DS3CXQ3M5ZBAO34OLGZB6IHR7YYIPJK3', N'ba12b504-1393-4849-b671-7359c9f127ef', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Directors] ON 

INSERT [dbo].[Directors] ([Id], [FullName], [About], [Image]) VALUES (2, N'Justin Weaver', N'Francis Ford Coppola ( Italian:  born April 7, 1939)is an American film director, producer, and screenwriter. He is considered one of the major figures of the New Hollywood filmmaking movement of the 1960s and 1970s.Coppola is the recipient of five Academy Awards, six Golden Globe Awards, two Palmes d''Or and a British Academy Film Award ', N'4bb4d835-b51a-4d8d-968d-a16d563d2a58ceblist1.jpg')
INSERT [dbo].[Directors] ([Id], [FullName], [About], [Image]) VALUES (3, N'Tijan Marei', N'Leonard Carow ist der Sohn der Künstlerin und Autorin Katrin Bongard und der Bruder von Isabel und Amber Bongard.[1] An der Seite seiner Schwestern hatte Carow 2004 in der Folge Große Liebe aus der Fernsehreihe Tatort seinen ersten Auftritt als Kinderdarsteller. Die Nebenrolle im deutsch-österreichischen Fernsehfilm Stauffenberg aus demselben Jahr blieb im Abspann unberücksichtigt.  Nach weiteren Auftritten in Fernsehfilmen und -serien spielte er 2008 im Filmdrama Mondkalb den Filmsohn von Axel Prahl sowie in der Komödie Die Relativitätstheorie der Liebe neben Katja Riemann und Olli Dittrich. Seinen bisherigen Karrierehöhepunkt erreichte er 2011 im oscar-nominierten US-amerikanisch-britischen Weltkriegsdrama Gefährten unter der Regie von Steven Spielberg.[2] In der Verfilmung von Michael Morpurgos Roman War Horse verkörperte er Michael Schröder, einen jungen deutschen Soldaten im Ersten Weltkrieg. Zusammen mit seinem Bruder Günther, gespielt von David Kross, kümmert er sich in der Feldambulanz um das Pferd Jo', N'246ede83-8b25-4398-9f8a-a31bbf72afd4ava3.jpg')
INSERT [dbo].[Directors] ([Id], [FullName], [About], [Image]) VALUES (4, N'Agnes Mai', N'Agnes Mai was born on 31 March 1990 in Augsburg, Germany. She is an actress and director, known for Who Am I (2014), Der Politiker and Luna Agonia.', N'5b9b442d-09cc-4623-8b99-ad793017b89eceb28.jpg')
INSERT [dbo].[Directors] ([Id], [FullName], [About], [Image]) VALUES (5, N'Cici Leah Campbell', N'Cici Leah Campbell(born April 4, 1980) is an American actress. She is best known for her roles in films such as Observe and Report (2009), Hot Tub Time Machine (2010), Young Adult (2011), and Interstellar (2014).Wolfe was raised in Virginia, where she was the King George Fall Festival Pageant Queen of 1997. She graduated from King George High School and later attended Virginia Tech.', N'64459d68-c938-4c49-8c8f-018f9ff970c8ceb24.jpg')
SET IDENTITY_INSERT [dbo].[Directors] OFF
GO
SET IDENTITY_INSERT [dbo].[Genres] ON 

INSERT [dbo].[Genres] ([Id], [Name]) VALUES (1, N'Fantasy')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (2, N'Detective')
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (3, N'Science fiction')
SET IDENTITY_INSERT [dbo].[Genres] OFF
GO
SET IDENTITY_INSERT [dbo].[Movies] ON 

INSERT [dbo].[Movies] ([Id], [Name], [Rate], [RunTime], [Year], [Description], [DirectorId], [GenreId], [Video], [Image]) VALUES (1, N'Interstellar', CAST(9.0 AS Decimal(18, 1)), 2, 2012, N'Interstellar is a 2014 epic science fiction film co-written, directed, and produced by Christopher Nolan. It stars Matthew McConaughey, Anne Hathaway, Jessica Chastain, Bill Irwin, Ellen Burstyn, Matt Damon, and Michael Caine. Set in a dystopian future where humanity is embroiled in a catastrophic blight and famine, the film follows a group of astronauts who travel through a wormhole near Saturn in search of a new home for humankind.  Brothers Christopher and Jonathan Nolan wrote the screenplay, which had its origins in a script Jonathan developed in 2007. Kip Thorne, a Caltech theoretical physicist and 2017 Nobel laureate in Physics,[4] was an executive producer, acted as a scientific consultant, and wrote a tie-in book, The Science of Interstellar. Cinematographer Hoyte van Hoytema shot it on 35 mm movie film in the Panavision anamorphic format and IMAX 70 mm. Principal photography began in late 2013 and took place in Alberta, Iceland, and Los Angeles. Interstellar uses extensive practical and miniature eff', 3, 3, N'441d90cd-06ae-4f64-a960-e538e62acfb3yildizlararasi-filminin-en-iyi-sahnesi_(VideoMon.Biz).mp4', N'8d6f6450-b7e3-4975-8ed2-ff57abf7310cInt.jpg')
INSERT [dbo].[Movies] ([Id], [Name], [Rate], [RunTime], [Year], [Description], [DirectorId], [GenreId], [Video], [Image]) VALUES (2, N'Walter White', CAST(7.0 AS Decimal(18, 1)), 1, 2007, N'Interstellar is a 2014 epic science fiction film co-written, directed, and produced by Christopher Nolan. It stars Matthew McConaughey, Anne Hathaway, Jessica Chastain, Bill Irwin, Ellen Burstyn, Matt Damon, and Michael Caine. Set in a dystopian future where humanity is embroiled in a catastrophic blight and famine, the film follows a group of astronauts who travel through a wormhole near Saturn in search of a new home for humankind.  Brothers Christopher and Jonathan Nolan wrote the screenplay, which had its origins in a script Jonathan developed in 2007. Kip Thorne, a Caltech theoretical physicist and 2017 Nobel laureate in Physics,[4] was an executive producer, acted as a scientific consultant, and wrote a tie-in book, The Science of Interstellar. Cinematographer Hoyte van Hoytema shot it on 35 mm movie film in the Panavision anamorphic format and IMAX 70 mm. Principal photography began in late 2013 and took place in Alberta, Iceland, and Los Angeles. Interstellar uses extensive practical and miniature eff', 3, 2, N'575d656d-adbb-4235-ac21-d7713319fce3BB_a2b9ad9f-9f20-4d6f-bd56-a07797e67b1a_preview.mp4', N'bb2575b5-b215-4276-be4c-1280ff6aaa7dslider2.jpg')
INSERT [dbo].[Movies] ([Id], [Name], [Rate], [RunTime], [Year], [Description], [DirectorId], [GenreId], [Video], [Image]) VALUES (3, N'65', CAST(7.0 AS Decimal(18, 1)), 1, 2009, N'Into the Wild is a 2007 American biographical adventure drama film written, co-produced, and directed by Sean Penn. It is an adaptation of the 1996 non-fiction book of the same name written by Jon Krakauer and tells the story of Christopher McCandless ("Alexander Supertramp"), a man who hiked across North America into the Alaskan wilderness in the early 1990s. The film stars Emile Hirsch as McCandless, Marcia Gay Harden as his mother, William Hurt as his father, Jena Malone, Catherine Keener, Brian H. Dierker, Vince Vaughn, Kristen Stewart, and Hal Holbrook.', 4, 2, N'862f699d-5f64-41e2-a2d4-17852ce5582a_import_62cfbdbf78e253.53558180_preview.mp4', N'f4256c7e-614d-4956-afef-54a0d5442bd0The R.jpg')
INSERT [dbo].[Movies] ([Id], [Name], [Rate], [RunTime], [Year], [Description], [DirectorId], [GenreId], [Video], [Image]) VALUES (4, N'Ride On', CAST(5.0 AS Decimal(18, 1)), 1, 2015, N'Interstellar is a 2014 epic science fiction film co-written, directed, and produced by Christopher Nolan. It stars Matthew McConaughey, Anne Hathaway, Jessica Chastain, Bill Irwin, Ellen Burstyn, Matt Damon, and Michael Caine. Set in a dystopian future where humanity is embroiled in a catastrophic blight and famine, the film follows a group of astronauts who travel through a wormhole near Saturn in search of a new home for humankind.  Brothers Christopher and Jonathan Nolan wrote the screenplay, which had its origins in a script Jonathan developed in 2007. Kip Thorne, a Caltech theoretical physicist and 2017 Nobel laureate in Physics,[4] was an executive producer, acted as a scientific consultant, and wrote a tie-in book, The Science of Interstellar. Cinematographer Hoyte van Hoytema shot it on 35 mm movie film in the Panavision anamorphic format and IMAX 70 mm. Principal photography began in late 2013 and took place in Alberta, Iceland, and Los Angeles. Interstellar uses extensive practical and miniature eff', 2, 3, N'0f4c160e-9d81-4ce4-b73b-8d8ab8e166e6635_635-0001_preview.mp4', N'993f72a1-569b-4c38-8566-f68d54dbebc1slider4.jpg')
INSERT [dbo].[Movies] ([Id], [Name], [Rate], [RunTime], [Year], [Description], [DirectorId], [GenreId], [Video], [Image]) VALUES (5, N'Ride On', CAST(3.0 AS Decimal(18, 1)), 1, 2010, N'Interstellar is a 2014 epic science fiction film co-written, directed, and produced by Christopher Nolan. It stars Matthew McConaughey, Anne Hathaway, Jessica Chastain, Bill Irwin, Ellen Burstyn, Matt Damon, and Michael Caine. Set in a dystopian future where humanity is embroiled in a catastrophic blight and famine, the film follows a group of astronauts who travel through a wormhole near Saturn in search of a new home for humankind.  Brothers Christopher and Jonathan Nolan wrote the screenplay, which had its origins in a script Jonathan developed in 2007. Kip Thorne, a Caltech theoretical physicist and 2017 Nobel laureate in Physics,[4] was an executive producer, acted as a scientific consultant, and wrote a tie-in book, The Science of Interstellar. Cinematographer Hoyte van Hoytema shot it on 35 mm movie film in the Panavision anamorphic format and IMAX 70 mm. Principal photography began in late 2013 and took place in Alberta, Iceland, and Los Angeles. Interstellar uses extensive practical and miniature eff', 3, 2, N'b230c30d-a744-4cf9-83c0-87f9d0826a79istockphoto-1311615792-640_adpp_is.mp4', N'17dc7220-a824-414e-83c0-a7d605f4f696slider2.jpg')
INSERT [dbo].[Movies] ([Id], [Name], [Rate], [RunTime], [Year], [Description], [DirectorId], [GenreId], [Video], [Image]) VALUES (6, N'Interstellar2', CAST(8.0 AS Decimal(18, 1)), 9, 2012, N'Interstellar is a 2014 epic science fiction film co-written, directed, and produced by Christopher Nolan. It stars Matthew McConaughey, Anne Hathaway, Jessica Chastain, Bill Irwin, Ellen Burstyn, Matt Damon, and Michael Caine. Set in a dystopian future where humanity is embroiled in a catastrophic blight and famine, the film follows a group of astronauts who travel through a wormhole near Saturn in search of a new home for humankind.  Brothers Christopher and Jonathan Nolan wrote the screenplay, which had its origins in a script Jonathan developed in 2007. Kip Thorne, a Caltech theoretical physicist and 2017 Nobel laureate in Physics,[4] was an executive producer, acted as a scientific consultant, and wrote a tie-in book, The Science of Interstellar. Cinematographer Hoyte van Hoytema shot it on 35 mm movie film in the Panavision anamorphic format and IMAX 70 mm. Principal photography began in late 2013 and took place in Alberta, Iceland, and Los Angeles. Interstellar uses extensive practical and miniature eff', 3, 1, N'83706bed-4d8a-4e3a-a86c-acf560fbe0d1yildizlararasi-filminin-en-iyi-sahnesi_(VideoMon.Biz).mp4', N'd4c08f35-ce1d-4e97-9a90-a3939654ad3aInt.jpg')
INSERT [dbo].[Movies] ([Id], [Name], [Rate], [RunTime], [Year], [Description], [DirectorId], [GenreId], [Video], [Image]) VALUES (7, N'Extraction ', CAST(8.0 AS Decimal(18, 1)), 1, 2019, N'Interstellar is a 2014 epic science fiction film co-written, directed, and produced by Christopher Nolan. It stars Matthew McConaughey, Anne Hathaway, Jessica Chastain, Bill Irwin, Ellen Burstyn, Matt Damon, and Michael Caine. Set in a dystopian future where humanity is embroiled in a catastrophic blight and famine, the film follows a group of astronauts who travel through a wormhole near Saturn in search of a new home for humankind.  Brothers Christopher and Jonathan Nolan wrote the screenplay, which had its origins in a script Jonathan developed in 2007. Kip Thorne, a Caltech theoretical physicist and 2017 Nobel laureate in Physics,[4] was an executive producer, acted as a scientific consultant, and wrote a tie-in book, The Science of Interstellar. Cinematographer Hoyte van Hoytema shot it on 35 mm movie film in the Panavision anamorphic format and IMAX 70 mm. Principal photography began in late 2013 and took place in Alberta, Iceland, and Los Angeles. Interstellar uses extensive practical and miniature eff', 4, 2, N'598eea40-d0c8-42c1-bc1c-592e313abd1aBB_a2b9ad9f-9f20-4d6f-bd56-a07797e67b1a_preview.mp4', N'93bf2c49-c433-4a46-a907-d9296b7dd574slider4.jpg')
INSERT [dbo].[Movies] ([Id], [Name], [Rate], [RunTime], [Year], [Description], [DirectorId], [GenreId], [Video], [Image]) VALUES (8, N'Babylon', CAST(7.0 AS Decimal(18, 1)), 2, 2011, N'Interstellar is a 2014 epic science fiction film co-written, directed, and produced by Christopher Nolan. It stars Matthew McConaughey, Anne Hathaway, Jessica Chastain, Bill Irwin, Ellen Burstyn, Matt Damon, and Michael Caine. Set in a dystopian future where humanity is embroiled in a catastrophic blight and famine, the film follows a group of astronauts who travel through a wormhole near Saturn in search of a new home for humankind.  Brothers Christopher and Jonathan Nolan wrote the screenplay, which had its origins in a script Jonathan developed in 2007. Kip Thorne, a Caltech theoretical physicist and 2017 Nobel laureate in Physics,[4] was an executive producer, acted as a scientific consultant, and wrote a tie-in book, The Science of Interstellar. Cinematographer Hoyte van Hoytema shot it on 35 mm movie film in the Panavision anamorphic format and IMAX 70 mm. Principal photography began in late 2013 and took place in Alberta, Iceland, and Los Angeles. Interstellar uses extensive practical and miniature eff', 4, 3, N'2274ea4e-1518-49c7-b79b-b8f453ab089bistockphoto-1311615792-640_adpp_is.mp4', N'c1d5898c-6ca5-4ac0-8e98-e0f7cbbd9660slider3.jpg')
INSERT [dbo].[Movies] ([Id], [Name], [Rate], [RunTime], [Year], [Description], [DirectorId], [GenreId], [Video], [Image]) VALUES (9, N'Who AM i', CAST(7.0 AS Decimal(18, 1)), 1, 2019, N'Interstellar is a 2014 epic science fiction film co-written, directed, and produced by Christopher Nolan. It stars Matthew McConaughey, Anne Hathaway, Jessica Chastain, Bill Irwin, Ellen Burstyn, Matt Damon, and Michael Caine. Set in a dystopian future where humanity is embroiled in a catastrophic blight and famine, the film follows a group of astronauts who travel through a wormhole near Saturn in search of a new home for humankind.  Brothers Christopher and Jonathan Nolan wrote the screenplay, which had its origins in a script Jonathan developed in 2007. Kip Thorne, a Caltech theoretical physicist and 2017 Nobel laureate in Physics,[4] was an executive producer, acted as a scientific consultant, and wrote a tie-in book, The Science of Interstellar. Cinematographer Hoyte van Hoytema shot it on 35 mm movie film in the Panavision anamorphic format and IMAX 70 mm. Principal photography began in late 2013 and took place in Alberta, Iceland, and Los Angeles. Interstellar uses extensive practical and miniature eff', 2, 3, N'b0901c12-c7b7-46ac-939a-a77709aa02a9istockphoto-1311615792-640_adpp_is.mp4', N'd7f990f9-5a89-46cd-be4d-9bfc8a0c4e08The R.jpg')
INSERT [dbo].[Movies] ([Id], [Name], [Rate], [RunTime], [Year], [Description], [DirectorId], [GenreId], [Video], [Image]) VALUES (10, N'Luck', CAST(6.0 AS Decimal(18, 1)), 1, 2007, N'Into the Wild is a 2007 American biographical adventure drama film written, co-produced, and directed by Sean Penn. It is an adaptation of the 1996 non-fiction book of the same name written by Jon Krakauer and tells the story of Christopher McCandless ("Alexander Supertramp"), a man who hiked across North America into the Alaskan wilderness in the early 1990s. The film stars Emile Hirsch as McCandless, Marcia Gay Harden as his mother, William Hurt as his father, Jena Malone, Catherine Keener, Brian H. Dierker, Vince Vaughn, Kristen Stewart, and Hal Holbrook.', 2, 1, N'7978c828-dd08-4226-86ed-4a0cc313bd58635_635-0001_preview.mp4', N'a21c57d2-ea6d-4411-805e-12092a73e16dslider2.jpg')
INSERT [dbo].[Movies] ([Id], [Name], [Rate], [RunTime], [Year], [Description], [DirectorId], [GenreId], [Video], [Image]) VALUES (11, N'Matrix', CAST(7.0 AS Decimal(18, 1)), 1, 2020, N'Into the Wild is a 2007 American biographical adventure drama film written, co-produced, and directed by Sean Penn. It is an adaptation of the 1996 non-fiction book of the same name written by Jon Krakauer and tells the story of Christopher McCandless ("Alexander Supertramp"), a man who hiked across North America into the Alaskan wilderness in the early 1990s. The film stars Emile Hirsch as McCandless, Marcia Gay Harden as his mother, William Hurt as his father, Jena Malone, Catherine Keener, Brian H. Dierker, Vince Vaughn, Kristen Stewart, and Hal Holbrook.', 2, 1, N'8f153a7a-e8a0-4c95-87cb-957c59f8d0d6BB_a2b9ad9f-9f20-4d6f-bd56-a07797e67b1a_preview.mp4', N'0b77725c-1fc8-47b4-8820-d5cc0af4ce4dslider3.jpg')
INSERT [dbo].[Movies] ([Id], [Name], [Rate], [RunTime], [Year], [Description], [DirectorId], [GenreId], [Video], [Image]) VALUES (12, N'Black Man', CAST(9.0 AS Decimal(18, 1)), 2, 2022, N'Into the Wild is a 2007 American biographical adventure drama film written, co-produced, and directed by Sean Penn. It is an adaptation of the 1996 non-fiction book of the same name written by Jon Krakauer and tells the story of Christopher McCandless ("Alexander Supertramp"), a man who hiked across North America into the Alaskan wilderness in the early 1990s. The film stars Emile Hirsch as McCandless, Marcia Gay Harden as his mother, William Hurt as his father, Jena Malone, Catherine Keener, Brian H. Dierker, Vince Vaughn, Kristen Stewart, and Hal Holbrook.', 4, 1, N'c3178bb7-83fa-483e-8b8e-113208137f90_import_62cfbdbf78e253.53558180_preview.mp4', N'eb092535-1bcf-491d-931a-278a4b24872dslider3.jpg')
SET IDENTITY_INSERT [dbo].[Movies] OFF
GO
/****** Object:  Index [IX_ActorMovie_MoviesId]    Script Date: 04.07.2023 15:52:39 ******/
CREATE NONCLUSTERED INDEX [IX_ActorMovie_MoviesId] ON [dbo].[ActorMovie]
(
	[MoviesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 04.07.2023 15:52:39 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 04.07.2023 15:52:39 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 04.07.2023 15:52:39 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 04.07.2023 15:52:39 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 04.07.2023 15:52:39 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 04.07.2023 15:52:39 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 04.07.2023 15:52:39 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Movies_DirectorId]    Script Date: 04.07.2023 15:52:39 ******/
CREATE NONCLUSTERED INDEX [IX_Movies_DirectorId] ON [dbo].[Movies]
(
	[DirectorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Movies_GenreId]    Script Date: 04.07.2023 15:52:39 ******/
CREATE NONCLUSTERED INDEX [IX_Movies_GenreId] ON [dbo].[Movies]
(
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Movies] ADD  DEFAULT ((0.0)) FOR [Rate]
GO
ALTER TABLE [dbo].[Movies] ADD  DEFAULT ((0)) FOR [RunTime]
GO
ALTER TABLE [dbo].[ActorMovie]  WITH CHECK ADD  CONSTRAINT [FK_ActorMovie_Actors_ActorsId] FOREIGN KEY([ActorsId])
REFERENCES [dbo].[Actors] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ActorMovie] CHECK CONSTRAINT [FK_ActorMovie_Actors_ActorsId]
GO
ALTER TABLE [dbo].[ActorMovie]  WITH CHECK ADD  CONSTRAINT [FK_ActorMovie_Movies_MoviesId] FOREIGN KEY([MoviesId])
REFERENCES [dbo].[Movies] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ActorMovie] CHECK CONSTRAINT [FK_ActorMovie_Movies_MoviesId]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_Movies_Directors_DirectorId] FOREIGN KEY([DirectorId])
REFERENCES [dbo].[Directors] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_Movies_Directors_DirectorId]
GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_Movies_Genres_GenreId] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genres] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_Movies_Genres_GenreId]
GO
USE [master]
GO
ALTER DATABASE [FinalWebsite] SET  READ_WRITE 
GO

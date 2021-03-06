USE [master]
GO
/****** Object:  Database [ADMIN_1]    Script Date: 2/7/2022 1:24:09 PM ******/
CREATE DATABASE [ADMIN_1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ADMIN_1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL19.SQLEXPRESS\MSSQL\DATA\ADMIN_1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ADMIN_1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL19.SQLEXPRESS\MSSQL\DATA\ADMIN_1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ADMIN_1] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ADMIN_1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ADMIN_1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ADMIN_1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ADMIN_1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ADMIN_1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ADMIN_1] SET ARITHABORT OFF 
GO
ALTER DATABASE [ADMIN_1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ADMIN_1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ADMIN_1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ADMIN_1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ADMIN_1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ADMIN_1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ADMIN_1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ADMIN_1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ADMIN_1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ADMIN_1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ADMIN_1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ADMIN_1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ADMIN_1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ADMIN_1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ADMIN_1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ADMIN_1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ADMIN_1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ADMIN_1] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ADMIN_1] SET  MULTI_USER 
GO
ALTER DATABASE [ADMIN_1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ADMIN_1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ADMIN_1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ADMIN_1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ADMIN_1] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ADMIN_1] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ADMIN_1] SET QUERY_STORE = OFF
GO
USE [ADMIN_1]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2/7/2022 1:24:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[UserPass] [nvarchar](50) NOT NULL,
	[IsAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [UserName], [UserPass], [IsAdmin]) VALUES (1, N'Admin1', N'BWNjjl2r1dWXwotIHAPiXg==', 1)
INSERT [dbo].[Users] ([ID], [UserName], [UserPass], [IsAdmin]) VALUES (2, N'User1', N'YuQtjXrU3AcuP4oa4zsjZw==', 0)
INSERT [dbo].[Users] ([ID], [UserName], [UserPass], [IsAdmin]) VALUES (4, N'Admin2', N'BWNjjl2r1dVlQWwB4eVBmg==', 1)
INSERT [dbo].[Users] ([ID], [UserName], [UserPass], [IsAdmin]) VALUES (5, N'Admin3', N'BWNjjl2r1dUWIvFSwFL9lg==', 1)
INSERT [dbo].[Users] ([ID], [UserName], [UserPass], [IsAdmin]) VALUES (6, N'User2', N'BWNjjl2r1dVlQWwB4eVBmg==', 0)
INSERT [dbo].[Users] ([ID], [UserName], [UserPass], [IsAdmin]) VALUES (7, N'User3', N'BWNjjl2r1dUWIvFSwFL9lg==', 0)
INSERT [dbo].[Users] ([ID], [UserName], [UserPass], [IsAdmin]) VALUES (8, N'Nano', N'9XSRHhAEYamJ5eOFeFqtrw==', 0)
INSERT [dbo].[Users] ([ID], [UserName], [UserPass], [IsAdmin]) VALUES (9, N'Veldo', N'R0uUuwe6QMc=', 0)
INSERT [dbo].[Users] ([ID], [UserName], [UserPass], [IsAdmin]) VALUES (10, N'new', N'ojIOodQPoVKbv+brRluNHg==', 0)
INSERT [dbo].[Users] ([ID], [UserName], [UserPass], [IsAdmin]) VALUES (11, N'User6', N'rMu1jPcH64CVoSo1dZn9LwMHdMV/varHX6DmUJAxSEg=', 0)
INSERT [dbo].[Users] ([ID], [UserName], [UserPass], [IsAdmin]) VALUES (12, N'User7', N'BWNjjl2r1dXbhGqdPZGLlw==', 0)
INSERT [dbo].[Users] ([ID], [UserName], [UserPass], [IsAdmin]) VALUES (13, N'User8', N'BWNjjl2r1dVglzzpshuhiw==', 0)
INSERT [dbo].[Users] ([ID], [UserName], [UserPass], [IsAdmin]) VALUES (15, N'User9', N'BWNjjl2r1dVZ/mIyThamAA==', 0)
INSERT [dbo].[Users] ([ID], [UserName], [UserPass], [IsAdmin]) VALUES (17, N'User10', N'BWNjjl2r1dWLjfiVMM/tHQ==', 0)
INSERT [dbo].[Users] ([ID], [UserName], [UserPass], [IsAdmin]) VALUES (19, N'User11', N'BWNjjl2r1dXrL+awNxlO/g==', 0)
INSERT [dbo].[Users] ([ID], [UserName], [UserPass], [IsAdmin]) VALUES (22, N'User12', N'Ry3+zjkUSGk=', 0)
INSERT [dbo].[Users] ([ID], [UserName], [UserPass], [IsAdmin]) VALUES (23, N'User14', N'BWNjjl2r1dULibgkM2Tz2w==', 0)
INSERT [dbo].[Users] ([ID], [UserName], [UserPass], [IsAdmin]) VALUES (24, N'User15', N'BWNjjl2r1dXGXocbTCGYuyTMJXSCdEmeQduS/wa3DQs=', 0)
INSERT [dbo].[Users] ([ID], [UserName], [UserPass], [IsAdmin]) VALUES (25, N'User16', N'qjfoumBF6ZBY+ts5iO7JiA==', 0)
INSERT [dbo].[Users] ([ID], [UserName], [UserPass], [IsAdmin]) VALUES (30, N'hjk', N'10Uz1jXc3wubv+brRluNHg==', 0)
INSERT [dbo].[Users] ([ID], [UserName], [UserPass], [IsAdmin]) VALUES (34, N'fdafasdf', N'/TdyMBFzZtK33jqmm8OZIEQQo6YVNyxg', 0)
INSERT [dbo].[Users] ([ID], [UserName], [UserPass], [IsAdmin]) VALUES (35, N'fdasfaUpdated', N'7Gu37c5W6dq+lu5ioLJggQ==', 0)
INSERT [dbo].[Users] ([ID], [UserName], [UserPass], [IsAdmin]) VALUES (36, N'Kjjhh', N'0UYELHgH9pmbv+brRluNHg==', 0)
INSERT [dbo].[Users] ([ID], [UserName], [UserPass], [IsAdmin]) VALUES (37, N'fgfdgsdf', N'Lk55q5jWGm8S8TlX8+7D3Q==', 1)
INSERT [dbo].[Users] ([ID], [UserName], [UserPass], [IsAdmin]) VALUES (38, N'gjslfdjglsdk', N'DGiW7pdmShDtfFhEx5k3B/ET71rB9ZSX', 1)
INSERT [dbo].[Users] ([ID], [UserName], [UserPass], [IsAdmin]) VALUES (39, N'fdfadf', N'CoFxfcpHjmch9fRTXQ0nhQ==', 0)
INSERT [dbo].[Users] ([ID], [UserName], [UserPass], [IsAdmin]) VALUES (40, N'gfsgsdfgsdgs', N'CYuozPtLnTYS8TlX8+7D3Q==', 0)
INSERT [dbo].[Users] ([ID], [UserName], [UserPass], [IsAdmin]) VALUES (41, N'test', N'sms9bowiigqbv+brRluNHg==', 1)
INSERT [dbo].[Users] ([ID], [UserName], [UserPass], [IsAdmin]) VALUES (42, N'dasfasfd', N'7Gu37c5W6dpG4I4KfRfyqJu/5utGW40e', 0)
INSERT [dbo].[Users] ([ID], [UserName], [UserPass], [IsAdmin]) VALUES (43, N'dfasfsadfasf', N'hL6MkGa8WdKm/iwl8qLIeQ==', 0)
INSERT [dbo].[Users] ([ID], [UserName], [UserPass], [IsAdmin]) VALUES (44, N'hgfhupdatedagain', N'KMv9Zo4uAaibv+brRluNHg==', 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__C9F2845657D2D0BD]    Script Date: 2/7/2022 1:24:10 PM ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UQ__Users__C9F2845657D2D0BD] UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [ADMIN_1] SET  READ_WRITE 
GO

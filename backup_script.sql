USE [master]
GO
/****** Object:  Database [OnlineShop]    Script Date: 1/11/2021 10:47:11 PM ******/
CREATE DATABASE [OnlineShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OnlineShop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\OnlineShop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OnlineShop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\OnlineShop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [OnlineShop] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OnlineShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OnlineShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OnlineShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OnlineShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OnlineShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OnlineShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [OnlineShop] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [OnlineShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OnlineShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OnlineShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OnlineShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OnlineShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OnlineShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OnlineShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OnlineShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OnlineShop] SET  ENABLE_BROKER 
GO
ALTER DATABASE [OnlineShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OnlineShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OnlineShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OnlineShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OnlineShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OnlineShop] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [OnlineShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OnlineShop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OnlineShop] SET  MULTI_USER 
GO
ALTER DATABASE [OnlineShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OnlineShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OnlineShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OnlineShop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OnlineShop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OnlineShop] SET QUERY_STORE = OFF
GO
USE [OnlineShop]
GO
/****** Object:  Table [dbo].[About]    Script Date: 1/11/2021 10:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[About](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[MetaTitle] [varchar](250) NULL,
	[Description] [nvarchar](500) NULL,
	[Image] [nvarchar](250) NULL,
	[Detail] [ntext] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[MetaKeywords] [nvarchar](250) NULL,
	[MetaDescription] [nchar](250) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.About] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 1/11/2021 10:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[MetaTitle] [varchar](250) NULL,
	[ParentID] [bigint] NULL,
	[DisplayOrder] [int] NULL,
	[SeoTitle] [nvarchar](250) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[MetaKeywords] [nvarchar](250) NULL,
	[MetaDescription] [nchar](250) NULL,
	[Status] [bit] NOT NULL,
	[ShowOnHome] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 1/11/2021 10:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Content] [ntext] NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Contact] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Content]    Script Date: 1/11/2021 10:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Content](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[MetaTitle] [varchar](250) NULL,
	[Description] [nvarchar](500) NULL,
	[Image] [nvarchar](250) NULL,
	[CategoryID] [bigint] NOT NULL,
	[Detail] [ntext] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[MetaKeywords] [nvarchar](250) NULL,
	[MetaDescription] [nchar](250) NULL,
	[Status] [bit] NOT NULL,
	[TopHot] [datetime] NULL,
	[ViewCount] [int] NULL,
	[Tags] [nvarchar](500) NULL,
 CONSTRAINT [PK_dbo.Content] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContentTag]    Script Date: 1/11/2021 10:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContentTag](
	[ContentID] [bigint] NOT NULL,
	[TagID] [varchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.ContentTag] PRIMARY KEY CLUSTERED 
(
	[ContentID] ASC,
	[TagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Credential]    Script Date: 1/11/2021 10:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Credential](
	[UserGroupID] [varchar](20) NOT NULL,
	[RoleID] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Credential] PRIMARY KEY CLUSTERED 
(
	[UserGroupID] ASC,
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 1/11/2021 10:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[Content] [nvarchar](250) NULL,
	[CreatedDate] [datetime] NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Feedback] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Footer]    Script Date: 1/11/2021 10:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Footer](
	[ID] [varchar](50) NOT NULL,
	[Content] [ntext] NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Footer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 1/11/2021 10:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](50) NULL,
	[Link] [nvarchar](250) NULL,
	[DisplayOrder] [int] NULL,
	[Target] [nvarchar](50) NULL,
	[Status] [bit] NOT NULL,
	[TypeID] [int] NULL,
 CONSTRAINT [PK_dbo.Menu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuType]    Script Date: 1/11/2021 10:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.MenuType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 1/11/2021 10:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CustomerID] [int] NULL,
	[ShipName] [nvarchar](50) NULL,
	[ShipMobile] [nvarchar](50) NULL,
	[ShipAddress] [nvarchar](50) NULL,
	[ShipEmail] [nvarchar](50) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_dbo.Order] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 1/11/2021 10:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[ProductID] [bigint] NOT NULL,
	[OrderID] [int] NOT NULL,
	[Quantity] [int] NULL,
	[Price] [decimal](18, 0) NULL,
 CONSTRAINT [PK_dbo.OrderDetail] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC,
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 1/11/2021 10:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](20) NULL,
	[Name] [nvarchar](250) NULL,
	[MetaTitle] [varchar](250) NULL,
	[Description] [nvarchar](500) NULL,
	[Image] [nvarchar](250) NULL,
	[MoreImages] [xml] NULL,
	[Price] [decimal](18, 0) NULL,
	[PromotionPrice] [decimal](18, 0) NULL,
	[IncludedVAT] [bit] NOT NULL,
	[Quantity] [int] NULL,
	[CategoryID] [bigint] NULL,
	[Detail] [ntext] NULL,
	[Warranty] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[MetaKeywords] [nvarchar](250) NULL,
	[MetaDescription] [nchar](250) NULL,
	[Status] [bit] NOT NULL,
	[TopHot] [datetime] NULL,
	[ViewCount] [int] NULL,
 CONSTRAINT [PK_dbo.Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 1/11/2021 10:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[MetaTitle] [varchar](250) NULL,
	[ParentID] [bigint] NULL,
	[DisplayOrder] [int] NULL,
	[SeoTitle] [nvarchar](250) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[MetaKeywords] [nvarchar](250) NULL,
	[MetaDescription] [nchar](250) NULL,
	[Status] [bit] NOT NULL,
	[ShowOnHome] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.ProductCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductViewModels]    Script Date: 1/11/2021 10:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductViewModels](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Image] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NULL,
	[CategoryName] [nvarchar](max) NULL,
	[CategoryMetaTitle] [nvarchar](max) NULL,
	[MetaTitle] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ProductViewModels] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 1/11/2021 10:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [varchar](50) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Slide]    Script Date: 1/11/2021 10:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slide](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Image] [nvarchar](250) NULL,
	[DisplayOrder] [int] NULL,
	[Link] [nvarchar](250) NULL,
	[Description] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Slide] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemConfig]    Script Date: 1/11/2021 10:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemConfig](
	[ID] [varchar](50) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NULL,
	[Value] [nvarchar](50) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.SystemConfig] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tag]    Script Date: 1/11/2021 10:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tag](
	[ID] [varchar](50) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.Tag] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 1/11/2021 10:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](32) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[ProvinceID] [int] NULL,
	[DistrictID] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[GroupID] [varchar](20) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserGroup]    Script Date: 1/11/2021 10:47:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGroup](
	[ID] [varchar](20) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_UserGroup] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [SeoTitle], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [MetaKeywords], [MetaDescription], [Status], [ShowOnHome]) VALUES (1, N'Tin tức', N'tin-tuc', NULL, 1, N'Tin tức', CAST(N'2021-01-04T22:42:10.553' AS DateTime), NULL, NULL, NULL, N'tin-tuc', N'tin-tuc                                                                                                                                                                                                                                                   ', 1, 1)
INSERT [dbo].[Category] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [SeoTitle], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [MetaKeywords], [MetaDescription], [Status], [ShowOnHome]) VALUES (2, N'Chương trình khuyến mại', N'chuong-trinh-khuyen-mai', NULL, 2, N'Chương trình khuyến mại', CAST(N'2021-01-02T00:00:00.000' AS DateTime), NULL, NULL, NULL, N'khuyen-mai', N'khuyen-mai                                                                                                                                                                                                                                                ', 1, 1)
INSERT [dbo].[Category] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [SeoTitle], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [MetaKeywords], [MetaDescription], [Status], [ShowOnHome]) VALUES (3, N'Thông tin sản phẩm', N'san-pham', NULL, 3, N'Thông tin sản phẩm', CAST(N'2021-01-01T00:00:00.000' AS DateTime), NULL, NULL, NULL, N'san-pham', N'san-pham                                                                                                                                                                                                                                                  ', 1, 1)
INSERT [dbo].[Category] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [SeoTitle], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [MetaKeywords], [MetaDescription], [Status], [ShowOnHome]) VALUES (4, N'Tuyển dụng', N'tuyen-dung', NULL, 4, N'Thông tin tuyển dụng', CAST(N'2021-01-01T00:00:00.000' AS DateTime), NULL, NULL, NULL, N'tuyen-dung', N'tuyen-dung                                                                                                                                                                                                                                                ', 1, 1)
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Contact] ON 

INSERT [dbo].[Contact] ([ID], [Content], [Status]) VALUES (1, N'<p>Công ty ABC</p><p>Địa chỉ: Hai Phong</p>', 1)
SET IDENTITY_INSERT [dbo].[Contact] OFF
GO
SET IDENTITY_INSERT [dbo].[Content] ON 

INSERT [dbo].[Content] ([ID], [Name], [MetaTitle], [Description], [Image], [CategoryID], [Detail], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [MetaKeywords], [MetaDescription], [Status], [TopHot], [ViewCount], [Tags]) VALUES (1, N'Thay đổi lịch làm việc mùa đông', N'thay-doi-lich-lam-viec-mua-dong', N'Thông tin lịch làm việc mùa đông', N'http://localhost:53907/ckfinder/connector?command=Proxy&lang=vi&langCode=vi&type=Files&currentFolder=%2F&hash=c245c263ce0eced480effe66bbede6b4d46c15ae&fileName=img-3%20(2).jpg', 2, N'<p>abc</p>', NULL, NULL, CAST(N'2021-01-11T18:37:34.270' AS DateTime), N'admin', N'lich-lam-viec', N'lich-lam-viec                                                                                                                                                                                                                                             ', 1, NULL, NULL, N'Lịch làm việc')
INSERT [dbo].[Content] ([ID], [Name], [MetaTitle], [Description], [Image], [CategoryID], [Detail], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [MetaKeywords], [MetaDescription], [Status], [TopHot], [ViewCount], [Tags]) VALUES (3, N'Chậu cây shop mới mua', N'chau-cay-shop-moi-mua', N'test', N'http://localhost:53907/ckfinder/connector?command=Proxy&lang=vi&langCode=vi&type=Files&currentFolder=%2F&hash=c245c263ce0eced480effe66bbede6b4d46c15ae&fileName=img-3%20(3).jpg', 3, N'<p>test<br></p>', NULL, NULL, CAST(N'2021-01-11T12:48:52.553' AS DateTime), N'admin', N'test', N'test                                                                                                                                                                                                                                                      ', 1, NULL, NULL, N'Cây cảnh, vip pro')
INSERT [dbo].[Content] ([ID], [Name], [MetaTitle], [Description], [Image], [CategoryID], [Detail], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [MetaKeywords], [MetaDescription], [Status], [TopHot], [ViewCount], [Tags]) VALUES (4, N'Em bé đang ngắm chậu hoa', N'em-be-dang-ngam-chau-hoa', N'Không có gì', N'http://localhost:53907/ckfinder/connector?command=Proxy&lang=vi&langCode=vi&type=Files&currentFolder=%2F&hash=c245c263ce0eced480effe66bbede6b4d46c15ae&fileName=img-2.jpg', 1, N'<p><u><b>tiep tục là test</b></u><br></p>', NULL, NULL, CAST(N'2021-01-11T12:50:23.023' AS DateTime), N'admin', N'test', N'test                                                                                                                                                                                                                                                      ', 1, NULL, NULL, N'Em bé, Cây cảnh')
INSERT [dbo].[Content] ([ID], [Name], [MetaTitle], [Description], [Image], [CategoryID], [Detail], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [MetaKeywords], [MetaDescription], [Status], [TopHot], [ViewCount], [Tags]) VALUES (5, N'Số 8 treo trên tường', N'so-8-treo-tren-tuong', N'test', N'http://localhost:53907/ckfinder/connector?command=Proxy&lang=vi&langCode=vi&type=Files&currentFolder=%2F&hash=c245c263ce0eced480effe66bbede6b4d46c15ae&fileName=img-2%20(4).jpg', 2, N'<p><span style="background-color: rgb(57, 132, 198);"><font color="#000000">test</font></span><br></p>', NULL, NULL, CAST(N'2021-01-11T12:53:11.743' AS DateTime), N'admin', N'test', N'test                                                                                                                                                                                                                                                      ', 1, NULL, NULL, N'Cây cảnh, Sồ học')
INSERT [dbo].[Content] ([ID], [Name], [MetaTitle], [Description], [Image], [CategoryID], [Detail], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [MetaKeywords], [MetaDescription], [Status], [TopHot], [ViewCount], [Tags]) VALUES (6, N'Bài viết hot', N'Bai-viet-hot', N'test', N'http://localhost:53907/ckfinder/connector?command=Proxy&lang=vi&langCode=vi&type=Files&currentFolder=%2F&hash=c245c263ce0eced480effe66bbede6b4d46c15ae&fileName=img-1.jpg', 1, N'<p>test<br></p>', CAST(N'2020-01-11T00:00:00.000' AS DateTime), N'admin', CAST(N'2021-01-11T11:38:34.297' AS DateTime), N'admin', N'test', N'test                                                                                                                                                                                                                                                      ', 1, CAST(N'2021-02-01T00:00:00.000' AS DateTime), NULL, N'cuongdz, abc')
SET IDENTITY_INSERT [dbo].[Content] OFF
GO
INSERT [dbo].[ContentTag] ([ContentID], [TagID]) VALUES (1, N'lich-lam-viec')
INSERT [dbo].[ContentTag] ([ContentID], [TagID]) VALUES (3, N'cay-canh')
INSERT [dbo].[ContentTag] ([ContentID], [TagID]) VALUES (3, N'vip-pro')
INSERT [dbo].[ContentTag] ([ContentID], [TagID]) VALUES (4, N'cay-canh')
INSERT [dbo].[ContentTag] ([ContentID], [TagID]) VALUES (4, N'em-be')
INSERT [dbo].[ContentTag] ([ContentID], [TagID]) VALUES (5, N'cay-canh')
INSERT [dbo].[ContentTag] ([ContentID], [TagID]) VALUES (5, N'so-hoc')
INSERT [dbo].[ContentTag] ([ContentID], [TagID]) VALUES (6, N'abc')
INSERT [dbo].[ContentTag] ([ContentID], [TagID]) VALUES (6, N'cuongdz')
GO
INSERT [dbo].[Credential] ([UserGroupID], [RoleID]) VALUES (N'admin', N'create_content')
INSERT [dbo].[Credential] ([UserGroupID], [RoleID]) VALUES (N'admin', N'create_user')
INSERT [dbo].[Credential] ([UserGroupID], [RoleID]) VALUES (N'admin', N'delete_content')
INSERT [dbo].[Credential] ([UserGroupID], [RoleID]) VALUES (N'admin', N'delete_user')
INSERT [dbo].[Credential] ([UserGroupID], [RoleID]) VALUES (N'admin', N'edit_content')
INSERT [dbo].[Credential] ([UserGroupID], [RoleID]) VALUES (N'admin', N'edit_user')
INSERT [dbo].[Credential] ([UserGroupID], [RoleID]) VALUES (N'admin', N'view_content')
INSERT [dbo].[Credential] ([UserGroupID], [RoleID]) VALUES (N'admin', N'view_user')
GO
SET IDENTITY_INSERT [dbo].[Feedback] ON 

INSERT [dbo].[Feedback] ([ID], [Name], [Phone], [Email], [Address], [Content], [CreatedDate], [Status]) VALUES (1, N'cuongd', N'03243242', N'cuong69509@st.vimaru.edu.vn', N'HaiPhong', N'tess', CAST(N'2021-01-09T11:05:57.390' AS DateTime), 0)
INSERT [dbo].[Feedback] ([ID], [Name], [Phone], [Email], [Address], [Content], [CreatedDate], [Status]) VALUES (2, N'test', N'04242442', N'cuong69509@st.vimaru.edu.vn', N'HaiPhong', N'tessst', CAST(N'2021-01-09T11:11:24.863' AS DateTime), 0)
INSERT [dbo].[Feedback] ([ID], [Name], [Phone], [Email], [Address], [Content], [CreatedDate], [Status]) VALUES (3, N'testtsets', N'0433242', N'cuong69509@st.vimaru.edu.vn', N'HaiPhong', N'tests', CAST(N'2021-01-09T11:12:34.840' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Feedback] OFF
GO
INSERT [dbo].[Footer] ([ID], [Content], [Status]) VALUES (N'footer', N'<div class="wrap">
            <div class="section group">
                <div class="col_1_of_4 span_1_of_4">
                    <h4>Information</h4>
                    <ul>
                        <li><a href="about.html">About Us</a></li>
                        <li><a href="contact.html">Customer Service</a></li>
                        <li><a href="#">Advanced Search</a></li>
                        <li><a href="delivery.html">Orders and Returns</a></li>
                        <li><a href="contact.html">Contact Us</a></li>
                    </ul>
                </div>
                <div class="col_1_of_4 span_1_of_4">
                    <h4>Why buy from us</h4>
                    <ul>
                        <li><a href="about.html">About Us</a></li>
                        <li><a href="contact.html">Customer Service</a></li>
                        <li><a href="#">Privacy Policy</a></li>
                        <li><a href="contact.html">Site Map</a></li>
                        <li><a href="#">Search Terms</a></li>
                    </ul>
                </div>
                <div class="col_1_of_4 span_1_of_4">
                    <h4>My account</h4>
                    <ul>
                        <li><a href="contact.html">Sign In</a></li>
                        <li><a href="index.html">View Cart</a></li>
                        <li><a href="#">My Wishlist</a></li>
                        <li><a href="#">Track My Order</a></li>
                        <li><a href="contact.html">Help</a></li>
                    </ul>
                </div>
                <div class="col_1_of_4 span_1_of_4">
                    <h4>Contact</h4>
                    <ul>
                        <li><span>+91-123-456789</span></li>
                        <li><span>+00-123-000000</span></li>
                    </ul>
                    <div class="social-icons">
                        <h4>Follow Us</h4>
                        <ul>
                            <li><a href="#" target="_blank"><img src="/assets/client/images/facebook.png" alt="" /></a></li>
                            <li><a href="#" target="_blank"><img src="/assets/client/images/twitter.png" alt="" /></a></li>
                            <li><a href="#" target="_blank"><img src="/assets/client/images/skype.png" alt="" /> </a></li>
                            <li><a href="#" target="_blank"> <img src="/assets/client/images/dribbble.png" alt="" /></a></li>
                            <li><a href="#" target="_blank"> <img src="/assets/client/images/linkedin.png" alt="" /></a></li>
                            <div class="clear"></div>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <div class="copy_right">
            <p>&copy; 2013 home_shoppe. All rights reserved | Design by <a href="http://w3layouts.com/">Cuongdzz</a></p>
        </div>', 1)
GO
SET IDENTITY_INSERT [dbo].[Menu] ON 

INSERT [dbo].[Menu] ([ID], [Text], [Link], [DisplayOrder], [Target], [Status], [TypeID]) VALUES (1, N'Trang chủ', N'/', 1, N'_blank', 1, 1)
INSERT [dbo].[Menu] ([ID], [Text], [Link], [DisplayOrder], [Target], [Status], [TypeID]) VALUES (2, N'Giới thiệu', N'/gioi-thieu', 2, N'_self', 1, 1)
INSERT [dbo].[Menu] ([ID], [Text], [Link], [DisplayOrder], [Target], [Status], [TypeID]) VALUES (3, N'Tin tức', N'/tin-tuc', 3, N'_self', 1, 1)
INSERT [dbo].[Menu] ([ID], [Text], [Link], [DisplayOrder], [Target], [Status], [TypeID]) VALUES (4, N'Sản phẩm', N'/san-pham', 4, N'_self', 1, 1)
INSERT [dbo].[Menu] ([ID], [Text], [Link], [DisplayOrder], [Target], [Status], [TypeID]) VALUES (5, N'Liên hệ', N'/lien-he', 5, N'_self', 1, 1)
INSERT [dbo].[Menu] ([ID], [Text], [Link], [DisplayOrder], [Target], [Status], [TypeID]) VALUES (6, N'Đăng nhập', N'/dang-nhap', 1, N'_self', 1, 2)
INSERT [dbo].[Menu] ([ID], [Text], [Link], [DisplayOrder], [Target], [Status], [TypeID]) VALUES (7, N'Đăng ký', N'/dang-ky', 2, N'_self', 1, 2)
SET IDENTITY_INSERT [dbo].[Menu] OFF
GO
SET IDENTITY_INSERT [dbo].[MenuType] ON 

INSERT [dbo].[MenuType] ([ID], [Name]) VALUES (1, N'Menu chính')
INSERT [dbo].[MenuType] ([ID], [Name]) VALUES (2, N'Menu Top')
SET IDENTITY_INSERT [dbo].[MenuType] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([ID], [CreatedDate], [CustomerID], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (1, CAST(N'2021-01-08T14:33:47.553' AS DateTime), NULL, N'cuongdz', NULL, NULL, NULL, NULL)
INSERT [dbo].[Order] ([ID], [CreatedDate], [CustomerID], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (2, CAST(N'2021-01-08T14:37:10.350' AS DateTime), NULL, N'cuongdz', N'032424', N'Hai Phong', N'cuongdz@gmail.com', NULL)
INSERT [dbo].[Order] ([ID], [CreatedDate], [CustomerID], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (3, CAST(N'2021-01-08T14:40:22.217' AS DateTime), NULL, N'cuongdz', N'0324324', N'Hai Phong', N'cuong1998pro@gmail.com', NULL)
INSERT [dbo].[Order] ([ID], [CreatedDate], [CustomerID], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (4, CAST(N'2021-01-08T14:40:55.983' AS DateTime), NULL, N'cuongdz', N'0324324', N'Hai Phong', N'cuong1998pro@gmail.com', NULL)
INSERT [dbo].[Order] ([ID], [CreatedDate], [CustomerID], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (5, CAST(N'2021-01-08T17:54:41.303' AS DateTime), NULL, N'cuongdz', N'03324234', N'Hai Phong', N'cuong69509@st.vimaru.edu.vn', NULL)
INSERT [dbo].[Order] ([ID], [CreatedDate], [CustomerID], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (6, CAST(N'2021-01-08T17:56:48.097' AS DateTime), NULL, N'cuongdz', N'03324234', N'Hai Phong', N'cuong69509@st.vimaru.edu.vn', NULL)
INSERT [dbo].[Order] ([ID], [CreatedDate], [CustomerID], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (7, CAST(N'2021-01-08T17:57:31.530' AS DateTime), NULL, N'cuongdz', N'03324234', N'Hai Phong', N'cuong69509@st.vimaru.edu.vn', NULL)
INSERT [dbo].[Order] ([ID], [CreatedDate], [CustomerID], [ShipName], [ShipMobile], [ShipAddress], [ShipEmail], [Status]) VALUES (8, CAST(N'2021-01-08T17:59:51.340' AS DateTime), NULL, N'cuongdz', N'03324234', N'Hai Phong', N'cuong69509@st.vimaru.edu.vn', NULL)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (1, 5, 1, CAST(1200 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (1, 6, 1, CAST(1200 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (1, 7, 1, CAST(1200 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (1, 8, 1, CAST(1200 AS Decimal(18, 0)))
INSERT [dbo].[OrderDetail] ([ProductID], [OrderID], [Quantity], [Price]) VALUES (2, 4, 1, CAST(20000 AS Decimal(18, 0)))
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ID], [Code], [Name], [MetaTitle], [Description], [Image], [MoreImages], [Price], [PromotionPrice], [IncludedVAT], [Quantity], [CategoryID], [Detail], [Warranty], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [MetaKeywords], [MetaDescription], [Status], [TopHot], [ViewCount]) VALUES (1, N'pd-4l', N'Gạch 4 lỗ', N'gach-4-lo', N'Gạch 4 lỗ', N'/assets/client/images/productslide-1.jpg', NULL, CAST(1200 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), 1, 0, 1, N'<h2>Tổng quát Gạch 4 lỗ – Phú Điền</h2>
<div class="_detailed_features">
    <ul class="_all_feature clearfix">
        <li>Tên sản phẩm: Gạch 4 lỗ – Phú Điền</li>
        <li>Mã sản phẩm: PD-4L</li>
        <li>Nhà sản xuất: Phú Điền</li>
        <li>Nhãn hiệu: Phú Điền</li>
        <li>Nơi sản xuất: Quãng Ngãi, Việt Nam</li>
        <li>Tiêu chuẩn: TCVN 1450-1998</li>
        <li>Kích thước: 190x80x80 mm</li>
        <li>Chất liệu: Đất sét nung công nghệ Tuynel</li>
        <li>Chủng loại: Gạch nung</li>
        <li>Độ rỗng:30%</li>
        <li>Cường độ chịu nén:≥ 37 N/mm2</li>
        <li>Độ hút nước:&lt;= 12%</li>
        <li>Trọng lượng:1.2 kg/viên</li>
    </ul>
    <div class="_all_relate_images">
        <div class="slider-thumb da-slider owl-carousel owl-loaded owl-drag">
            <div class="owl-stage-outer">
                <div class="owl-stage"></div>
            </div>
        </div>
    </div>
</div>
<div class="_generality">Chi tiết</div>
<div>Với nguồn nguyên liệu đất sét chất lượng cao, được ngâm ủ kỹ trong vòng 3 – 6 tháng, qua hệ thống đùn nén và lò
    nung kỹ thuật cao, gạch tuynel Phú Điền có hình dáng, màu sắc đẹp và khả năng chịu lực cao &amp; khả năng thấm nước
    thấp. Gạch tuynel Phú Điền thõa TCVN 1450:1998 và TCN 1450:1998.Tính năng<p></p>
    <p>Loại:&nbsp;Gạch Tuynel<br>
        Kích thước:&nbsp;190 x 80 x 80 (mm)<br>
        Khối lượng:&nbsp;1.2 kg</p>
    <p>Sử dụng</p>
    <p>Gạch tuynel 4 lỗ là gạch xây tường được sử dụng rộng rãi cho các công trình nhà cao tầng, công trình đòi hỏi
        chiếm diện tích ít để sử dụng. Gạch 4 lỗ chuyên dùng xây tường 100 (mm).</p>
</div>', 0, CAST(N'2020-01-01T00:00:00.000' AS DateTime), N'admin', NULL, NULL, NULL, NULL, 1, CAST(N'2021-06-06T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Product] ([ID], [Code], [Name], [MetaTitle], [Description], [Image], [MoreImages], [Price], [PromotionPrice], [IncludedVAT], [Quantity], [CategoryID], [Detail], [Warranty], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [MetaKeywords], [MetaDescription], [Status], [TopHot], [ViewCount]) VALUES (2, N'test', N'test', N'test', N'test', N'/assets/client/images/productslide-2.jpg', NULL, CAST(20000 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), 1, 0, 1, N'Day la test', 0, CAST(N'2021-01-07T22:02:15.700' AS DateTime), N'admin', NULL, NULL, NULL, NULL, 1, CAST(N'1900-01-01T00:00:00.000' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductCategory] ON 

INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [SeoTitle], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [MetaKeywords], [MetaDescription], [Status], [ShowOnHome]) VALUES (1, N'Vật liệu xây dựng', N'vat-lieu-xay-dung', NULL, 1, N'Vật liệu xây dựng', CAST(N'2020-01-06T00:00:00.000' AS DateTime), N'admin', NULL, NULL, N'Vật liệu xây dựng', N'Vật liệu xây dựng                                                                                                                                                                                                                                         ', 1, 1)
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [SeoTitle], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [MetaKeywords], [MetaDescription], [Status], [ShowOnHome]) VALUES (2, N'Vật liệu thép', N'vat-lieu-thep', NULL, 2, NULL, CAST(N'2020-01-06T00:00:00.000' AS DateTime), N'admin', NULL, NULL, NULL, NULL, 1, 1)
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [SeoTitle], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [MetaKeywords], [MetaDescription], [Status], [ShowOnHome]) VALUES (3, N'Hoá chất phụ gia', N'hoa-chat-phu-gia', NULL, 3, NULL, CAST(N'2020-01-05T00:00:00.000' AS DateTime), N'admin', NULL, NULL, NULL, NULL, 1, 1)
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [SeoTitle], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [MetaKeywords], [MetaDescription], [Status], [ShowOnHome]) VALUES (4, N'Vật liệu kết cấu', N'vat-lieu-ket-cau', NULL, 4, NULL, CAST(N'2020-01-05T00:00:00.000' AS DateTime), N'admin', NULL, NULL, NULL, NULL, 1, 1)
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [SeoTitle], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [MetaKeywords], [MetaDescription], [Status], [ShowOnHome]) VALUES (5, N'Vật liệu thi công', N'vat-lieu-thi-cong', NULL, 5, NULL, CAST(N'2020-01-05T00:00:00.000' AS DateTime), N'admin', NULL, NULL, NULL, NULL, 1, 1)
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [SeoTitle], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [MetaKeywords], [MetaDescription], [Status], [ShowOnHome]) VALUES (6, N'Thiết bị máy móc', N'thiet-bi-may-moc', NULL, 6, NULL, CAST(N'2020-01-05T00:00:00.000' AS DateTime), N'admin', NULL, NULL, NULL, NULL, 1, 1)
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [SeoTitle], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [MetaKeywords], [MetaDescription], [Status], [ShowOnHome]) VALUES (7, N'Dụng cụ bảo hộ', N'dung-cu-bao-ho', NULL, 7, NULL, CAST(N'2020-01-06T00:00:00.000' AS DateTime), N'admin', NULL, NULL, NULL, NULL, 1, 1)
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [SeoTitle], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [MetaKeywords], [MetaDescription], [Status], [ShowOnHome]) VALUES (8, N'Thiết bị điện nước ', N'thiet-bi-dien-nuoc', NULL, 8, NULL, CAST(N'2020-01-06T00:00:00.000' AS DateTime), N'admin', NULL, NULL, NULL, NULL, 1, 1)
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [SeoTitle], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [MetaKeywords], [MetaDescription], [Status], [ShowOnHome]) VALUES (9, N'Vật liệu trang trí', N'vat-lieu-trang-tri', NULL, 9, NULL, CAST(N'2002-01-05T00:00:00.000' AS DateTime), N'admin', NULL, NULL, NULL, NULL, 1, 1)
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [DisplayOrder], [SeoTitle], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [MetaKeywords], [MetaDescription], [Status], [ShowOnHome]) VALUES (10, N'Cát, đá', N'cat-da', 1, 10, NULL, CAST(N'2021-01-05T00:00:00.000' AS DateTime), N'admin', NULL, NULL, NULL, NULL, 1, 1)
SET IDENTITY_INSERT [dbo].[ProductCategory] OFF
GO
INSERT [dbo].[Role] ([ID], [Name]) VALUES (N'add_content', N'Thêm tin tức')
INSERT [dbo].[Role] ([ID], [Name]) VALUES (N'add_user', N'Thêm User')
INSERT [dbo].[Role] ([ID], [Name]) VALUES (N'delete_content', N'Xoá tin tức')
INSERT [dbo].[Role] ([ID], [Name]) VALUES (N'delete_user', N'Xoá User')
INSERT [dbo].[Role] ([ID], [Name]) VALUES (N'edit_content', N'Sửa tin tức')
INSERT [dbo].[Role] ([ID], [Name]) VALUES (N'edit_user', N'Sửa User')
INSERT [dbo].[Role] ([ID], [Name]) VALUES (N'view_content', N'Xem tin tức')
INSERT [dbo].[Role] ([ID], [Name]) VALUES (N'view_user', N'Xem User')
GO
SET IDENTITY_INSERT [dbo].[Slide] ON 

INSERT [dbo].[Slide] ([ID], [Image], [DisplayOrder], [Link], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status]) VALUES (1, N'/assets/client/images/slide-1-image.png', 1, NULL, NULL, CAST(N'2021-01-06T15:35:55.370' AS DateTime), N'admin', NULL, NULL, 1)
INSERT [dbo].[Slide] ([ID], [Image], [DisplayOrder], [Link], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status]) VALUES (2, N'/assets/client/images/slide-2-image.jpg', 2, NULL, NULL, CAST(N'2021-01-06T15:35:59.257' AS DateTime), N'admin', NULL, NULL, 1)
INSERT [dbo].[Slide] ([ID], [Image], [DisplayOrder], [Link], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [Status]) VALUES (3, N'/assets/client/images/slide-3-image.jpg', 3, NULL, NULL, CAST(N'2021-01-06T00:00:00.000' AS DateTime), N'admin', NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Slide] OFF
GO
INSERT [dbo].[Tag] ([ID], [Name]) VALUES (N'abc', N' abc')
INSERT [dbo].[Tag] ([ID], [Name]) VALUES (N'cay-canh', N'Cây cảnh')
INSERT [dbo].[Tag] ([ID], [Name]) VALUES (N'cuongdz', N'cuongdz')
INSERT [dbo].[Tag] ([ID], [Name]) VALUES (N'em-be', N'Em bé')
INSERT [dbo].[Tag] ([ID], [Name]) VALUES (N'lich-lam-viec', N'Lịch làm việc')
INSERT [dbo].[Tag] ([ID], [Name]) VALUES (N'so-hoc', N' Sồ học')
INSERT [dbo].[Tag] ([ID], [Name]) VALUES (N'vip-pro', N' vip pro')
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [UserName], [Password], [Name], [Address], [Email], [Phone], [ProvinceID], [DistrictID], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [GroupID], [Status]) VALUES (5, N'admin', N'e10adc3949ba59abbe56e057f20f883e', N'Pham Cuong', N'Thuy Nguyen, Hai Phong', N'cuong1998pro@gmail.com', N'0337507167', NULL, NULL, NULL, NULL, CAST(N'2021-01-05T16:29:08.577' AS DateTime), N'admin', N'admin', 1)
INSERT [dbo].[User] ([ID], [UserName], [Password], [Name], [Address], [Email], [Phone], [ProvinceID], [DistrictID], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [GroupID], [Status]) VALUES (6, N'test', N'e10adc3949ba59abbe56e057f20f883e', N'Pham Nhu Quynh', N'Thai Ha, Ha Noi', N'jimmy98.space@gmail.com', N'0324545365', NULL, NULL, CAST(N'2020-01-01T00:00:00.000' AS DateTime), N'cuongdz', CAST(N'2021-01-05T16:32:15.557' AS DateTime), N'admin', N'member', 1)
INSERT [dbo].[User] ([ID], [UserName], [Password], [Name], [Address], [Email], [Phone], [ProvinceID], [DistrictID], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [GroupID], [Status]) VALUES (7, N'cuongdz', N'e10adc3949ba59abbe56e057f20f883e', N'Sếp Cường', N'Bốn bể là nhà', N'bodoi@gmail.com', N'đéo dùng điện thoại', NULL, NULL, CAST(N'2021-01-05T22:10:14.000' AS DateTime), N'admin', CAST(N'2021-01-05T22:13:21.740' AS DateTime), N'admin', N'mod', 1)
INSERT [dbo].[User] ([ID], [UserName], [Password], [Name], [Address], [Email], [Phone], [ProvinceID], [DistrictID], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [GroupID], [Status]) VALUES (11, N'cuong69509@st.vimaru.edu.vn', N'd41d8cd98f00b204e9800998ecf8427e', N'Cường  Phạm', NULL, N'cuong69509@st.vimaru.edu.vn', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'member', 1)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
INSERT [dbo].[UserGroup] ([ID], [Name]) VALUES (N'admin', N'Quản trị')
INSERT [dbo].[UserGroup] ([ID], [Name]) VALUES (N'member', N'Thành viên')
INSERT [dbo].[UserGroup] ([ID], [Name]) VALUES (N'Mod', N'Quản lý')
GO
/****** Object:  Index [IX_CategoryID]    Script Date: 1/11/2021 10:47:12 PM ******/
CREATE NONCLUSTERED INDEX [IX_CategoryID] ON [dbo].[Content]
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_GroupID]  DEFAULT (N'member') FOR [GroupID]
GO
ALTER TABLE [dbo].[Content]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Content_dbo.Category_CategoryID] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Content] CHECK CONSTRAINT [FK_dbo.Content_dbo.Category_CategoryID]
GO
USE [master]
GO
ALTER DATABASE [OnlineShop] SET  READ_WRITE 
GO

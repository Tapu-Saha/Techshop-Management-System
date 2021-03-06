USE [master]
GO
/****** Object:  Database [techshopdb]    Script Date: 25-Aug-21 1:44:03 AM ******/
CREATE DATABASE [techshopdb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'techshopdb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\techshopdb.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'techshopdb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\techshopdb_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [techshopdb] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [techshopdb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [techshopdb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [techshopdb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [techshopdb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [techshopdb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [techshopdb] SET ARITHABORT OFF 
GO
ALTER DATABASE [techshopdb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [techshopdb] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [techshopdb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [techshopdb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [techshopdb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [techshopdb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [techshopdb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [techshopdb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [techshopdb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [techshopdb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [techshopdb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [techshopdb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [techshopdb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [techshopdb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [techshopdb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [techshopdb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [techshopdb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [techshopdb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [techshopdb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [techshopdb] SET  MULTI_USER 
GO
ALTER DATABASE [techshopdb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [techshopdb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [techshopdb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [techshopdb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [techshopdb]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 25-Aug-21 1:44:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cart](
	[productId] [varchar](20) NOT NULL,
	[productName] [varchar](20) NOT NULL,
	[quantity] [int] NOT NULL,
	[categoryId] [varchar](20) NOT NULL,
	[price] [int] NOT NULL,
 CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED 
(
	[productId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[categorys]    Script Date: 25-Aug-21 1:44:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[categorys](
	[categoryId] [varchar](20) NOT NULL,
	[categoryName] [varchar](30) NOT NULL,
 CONSTRAINT [PK_categorys] PRIMARY KEY CLUSTERED 
(
	[categoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 25-Aug-21 1:44:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customers](
	[customerId] [varchar](10) NOT NULL,
	[customerName] [varchar](20) NOT NULL,
	[address] [varchar](20) NOT NULL,
	[contactNumber] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[customerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 25-Aug-21 1:44:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [varchar](10) NOT NULL,
	[customerName] [varchar](20) NOT NULL,
	[orderDate] [date] NOT NULL,
	[OrderNumber] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Orders] SET (LOCK_ESCALATION = AUTO)
GO
/****** Object:  Table [dbo].[Product]    Script Date: 25-Aug-21 1:44:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[productId] [varchar](30) NOT NULL,
	[productName] [varchar](30) NOT NULL,
	[categoryId] [varchar](20) NOT NULL,
	[price] [int] NOT NULL,
	[stock] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[productId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Registration]    Script Date: 25-Aug-21 1:44:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Registration](
	[userId] [varchar](30) NOT NULL,
	[userName] [varchar](20) NOT NULL,
	[password] [varchar](30) NOT NULL,
	[DOB] [date] NOT NULL,
	[address] [varchar](20) NOT NULL,
	[phoneNo] [varchar](15) NOT NULL,
	[email] [varchar](20) NOT NULL,
	[salary] [int] NOT NULL,
	[bonus] [int] NOT NULL,
	[salaryBonus] [int] NOT NULL,
	[role] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserInformation]    Script Date: 25-Aug-21 1:44:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserInformation](
	[userId] [varchar](30) NOT NULL,
	[userName] [varchar](20) NOT NULL,
	[password] [varchar](30) NOT NULL,
	[DOB] [date] NOT NULL,
	[address] [varchar](20) NOT NULL,
	[phoneNo] [varchar](15) NOT NULL,
	[email] [varchar](20) NOT NULL,
	[salary] [int] NOT NULL,
	[bonus] [int] NOT NULL,
	[salaryBonus] [int] NOT NULL,
	[role] [varchar](10) NOT NULL,
 CONSTRAINT [PK_UserInformation] PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[categorys] ([categoryId], [categoryName]) VALUES (N'cat-001', N'Laptop')
INSERT [dbo].[categorys] ([categoryId], [categoryName]) VALUES (N'cat-002', N'Accessories')
INSERT [dbo].[categorys] ([categoryId], [categoryName]) VALUES (N'cat-003', N'Monitor')
INSERT [dbo].[categorys] ([categoryId], [categoryName]) VALUES (N'cat-004', N'Build-PC')
INSERT [dbo].[Customers] ([customerId], [customerName], [address], [contactNumber]) VALUES (N'c-01', N'Ibrahim khalil', N'shafipur', N'017791231')
INSERT [dbo].[Customers] ([customerId], [customerName], [address], [contactNumber]) VALUES (N'c-02', N'Nazmul Hasan', N'kaliakoir', N'019992382')
INSERT [dbo].[Customers] ([customerId], [customerName], [address], [contactNumber]) VALUES (N'c-03', N'Anik Sarker', N'Dhaka', N'019898121')
INSERT [dbo].[Customers] ([customerId], [customerName], [address], [contactNumber]) VALUES (N'c-04', N'Mr Raaz', N'Dhaka', N'015823231')
INSERT [dbo].[Customers] ([customerId], [customerName], [address], [contactNumber]) VALUES (N'c-05', N'Tapu Saha', N'Nowakhali', N'018821311')
INSERT [dbo].[Customers] ([customerId], [customerName], [address], [contactNumber]) VALUES (N'c-06', N'Abdullah', N'Cumilla', N'019989213')
INSERT [dbo].[Customers] ([customerId], [customerName], [address], [contactNumber]) VALUES (N'c-07', N'Abdur Rahim', N'Shafipur', N'0190121212')
INSERT [dbo].[Customers] ([customerId], [customerName], [address], [contactNumber]) VALUES (N'c-08', N'Abdur Rahim', N'Shafipur', N'0190121212')
INSERT [dbo].[Customers] ([customerId], [customerName], [address], [contactNumber]) VALUES (N'c-10', N'Abdur Kalam', N'Shafipur', N'0190121212')
INSERT [dbo].[Customers] ([customerId], [customerName], [address], [contactNumber]) VALUES (N'c-11', N'Arif Mia', N'Sylhet', N'019988211')
INSERT [dbo].[Customers] ([customerId], [customerName], [address], [contactNumber]) VALUES (N'c-12', N'Arif Mia', N'Sylhet', N'019988211')
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderId], [customerName], [orderDate], [OrderNumber]) VALUES (N'o-001', N'Md. Asibur Islam', CAST(N'2021-08-21' AS Date), 16)
INSERT [dbo].[Orders] ([OrderId], [customerName], [orderDate], [OrderNumber]) VALUES (N'o-002', N'Tapu Saha', CAST(N'2021-08-21' AS Date), 18)
INSERT [dbo].[Orders] ([OrderId], [customerName], [orderDate], [OrderNumber]) VALUES (N'O-13', N'GGGG', CAST(N'2021-08-23' AS Date), 26)
INSERT [dbo].[Orders] ([OrderId], [customerName], [orderDate], [OrderNumber]) VALUES (N'O-17', N'Tapu SALA', CAST(N'2021-08-21' AS Date), 21)
INSERT [dbo].[Orders] ([OrderId], [customerName], [orderDate], [OrderNumber]) VALUES (N'O-48', N'Asraf', CAST(N'2021-08-23' AS Date), 25)
INSERT [dbo].[Orders] ([OrderId], [customerName], [orderDate], [OrderNumber]) VALUES (N'O-51', N'Abir Hossain', CAST(N'2021-08-21' AS Date), 19)
INSERT [dbo].[Orders] ([OrderId], [customerName], [orderDate], [OrderNumber]) VALUES (N'O-54', N'Nazim ', CAST(N'2021-08-22' AS Date), 23)
INSERT [dbo].[Orders] ([OrderId], [customerName], [orderDate], [OrderNumber]) VALUES (N'O-62', N'GGGGG', CAST(N'2021-08-23' AS Date), 27)
INSERT [dbo].[Orders] ([OrderId], [customerName], [orderDate], [OrderNumber]) VALUES (N'O-66', N'Rakib Islam', CAST(N'2021-08-22' AS Date), 22)
INSERT [dbo].[Orders] ([OrderId], [customerName], [orderDate], [OrderNumber]) VALUES (N'O-76', N'Shaikat', CAST(N'2021-08-21' AS Date), 20)
INSERT [dbo].[Orders] ([OrderId], [customerName], [orderDate], [OrderNumber]) VALUES (N'O-89', N'Nilima', CAST(N'2021-08-22' AS Date), 24)
SET IDENTITY_INSERT [dbo].[Orders] OFF
INSERT [dbo].[Product] ([productId], [productName], [categoryId], [price], [stock]) VALUES (N'p-001', N'Oppo Ram 16GB', N'cat-003', 10000, 18)
INSERT [dbo].[Product] ([productId], [productName], [categoryId], [price], [stock]) VALUES (N'p-003', N'Samsung HDD', N'cat-003', 7000, 20)
INSERT [dbo].[Product] ([productId], [productName], [categoryId], [price], [stock]) VALUES (N'p-004', N'LG Monitor', N'cat-002', 15000, 144)
INSERT [dbo].[Product] ([productId], [productName], [categoryId], [price], [stock]) VALUES (N'p-006', N'Samsung HDD', N'cat-003', 7000, 17)
INSERT [dbo].[Product] ([productId], [productName], [categoryId], [price], [stock]) VALUES (N'p-007', N'A-Data HDD', N'cat-003', 7000, 18)
INSERT [dbo].[Product] ([productId], [productName], [categoryId], [price], [stock]) VALUES (N'p-10', N'Acer Laptop', N'cat-001', 80000, 95)
INSERT [dbo].[Product] ([productId], [productName], [categoryId], [price], [stock]) VALUES (N'p-11', N'Toshiba HDD', N'cat-003', 4000, 17)
INSERT [dbo].[UserInformation] ([userId], [userName], [password], [DOB], [address], [phoneNo], [email], [salary], [bonus], [salaryBonus], [role]) VALUES (N'Nazmul Hasan', N'Nazmul Hasan', N'gg', CAST(N'2002-08-14' AS Date), N'Dhaka', N'019893829', N'gmail@email.com', 80000, 0, 80000, N'manager')
INSERT [dbo].[UserInformation] ([userId], [userName], [password], [DOB], [address], [phoneNo], [email], [salary], [bonus], [salaryBonus], [role]) VALUES (N'u-001', N'Nazim Hasan', N'admin', CAST(N'2000-09-29' AS Date), N'Shafipur,Gazipur', N'01777862911', N'nazim@gmail.com', 0, 0, 0, N'admin')
INSERT [dbo].[UserInformation] ([userId], [userName], [password], [DOB], [address], [phoneNo], [email], [salary], [bonus], [salaryBonus], [role]) VALUES (N'u-002', N'Tapu Saha', N'manager', CAST(N'2000-02-02' AS Date), N'Nowakhali', N'01899237291', N'tapu@gmail.com', 80000, 2000, 82000, N'manager')
INSERT [dbo].[UserInformation] ([userId], [userName], [password], [DOB], [address], [phoneNo], [email], [salary], [bonus], [salaryBonus], [role]) VALUES (N'u-004', N'Nitu Saha', N'nitu123', CAST(N'1999-01-01' AS Date), N'Gazipur', N'0197283721', N'nitu@gmail.com', 60000, 1500, 61500, N'salesman')
INSERT [dbo].[UserInformation] ([userId], [userName], [password], [DOB], [address], [phoneNo], [email], [salary], [bonus], [salaryBonus], [role]) VALUES (N'u-006', N'Sobuj Mia', N'sob123', CAST(N'2000-01-31' AS Date), N'Gazipur', N'0182037428', N'sob@gmail.com', 60000, 2000, 62000, N'salesman')
INSERT [dbo].[UserInformation] ([userId], [userName], [password], [DOB], [address], [phoneNo], [email], [salary], [bonus], [salaryBonus], [role]) VALUES (N'u-010', N'Tasnim Binte Jaman', N'tasu111', CAST(N'1998-11-19' AS Date), N'Konabari', N'0198989232', N'tasu@gmail.com', 80000, 0, 80000, N'manager')
INSERT [dbo].[UserInformation] ([userId], [userName], [password], [DOB], [address], [phoneNo], [email], [salary], [bonus], [salaryBonus], [role]) VALUES (N'u-012', N'Zihan islam', N'za123', CAST(N'2000-02-01' AS Date), N'Chittagong', N'0189794211', N'zihan@gmail.com', 80000, 5000, 85000, N'manager')
INSERT [dbo].[UserInformation] ([userId], [userName], [password], [DOB], [address], [phoneNo], [email], [salary], [bonus], [salaryBonus], [role]) VALUES (N'U-494', N'Name', N'nil', CAST(N'2004-06-08' AS Date), N'Nowakhli', N'018298129', N'nil@email.com', 60000, 0, 60000, N'salesman')
INSERT [dbo].[UserInformation] ([userId], [userName], [password], [DOB], [address], [phoneNo], [email], [salary], [bonus], [salaryBonus], [role]) VALUES (N'U-581', N'1', N'1', CAST(N'2021-08-23' AS Date), N'1', N'1', N'1', 60000, 0, 60000, N'salesman')
INSERT [dbo].[UserInformation] ([userId], [userName], [password], [DOB], [address], [phoneNo], [email], [salary], [bonus], [salaryBonus], [role]) VALUES (N'U-875', N'Name', N'akash123', CAST(N'1999-07-15' AS Date), N'Gazipur', N'0178989721', N'ak@gmail.com', 60000, 0, 60000, N'salesman')
INSERT [dbo].[UserInformation] ([userId], [userName], [password], [DOB], [address], [phoneNo], [email], [salary], [bonus], [salaryBonus], [role]) VALUES (N'Zunayed Ahmed', N'Zunayed Ahmed', N'zun123', CAST(N'2000-02-15' AS Date), N'Gazipur', N'018778781', N'zun@gmail.com', 80000, 3000, 83000, N'manager')
USE [master]
GO
ALTER DATABASE [techshopdb] SET  READ_WRITE 
GO
